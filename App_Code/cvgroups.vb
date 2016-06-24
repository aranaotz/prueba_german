Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class cvgroups
    Shared Function grupos_actuales(ByVal cn As String) As DataTable
        Dim c As New SqlConnection(cn)
        Dim cga As New SqlDataAdapter("select distinct grupo from alumnos where ciclo='" + ciclo_actual(cn) + "'", c)
        Dim cgat As New DataTable
        c.Open()
        cga.Fill(cgat)
        c.Close()
        grupos_actuales = cgat
    End Function

    Shared Function ciclo_actual(ByVal cn As String) As String
        Dim v As New SqlConnection(cn)
        Dim cycle As New SqlCommand("SELECT ciclo FROM general_ciclos WHERE active=1", v)
        v.Open()
        ciclo_actual = cycle.ExecuteScalar
        v.Close()
    End Function

    Shared Function alumnos(ByVal cn As String, ByVal grupo As String) As DataTable
        Dim c As New SqlConnection(cn)
        Dim ca As New SqlDataAdapter("select fname,grupo,status,id,matr from alumnos where grupo='" + grupo + "' and ciclo='" + ciclo_actual(cn) + "'", c)
        Dim cat As New DataTable
        c.Open()
        ca.Fill(cat)
        c.Close()
        alumnos = cat
    End Function



    ''''''''''''''''''''''''''''

    'listado para llenar el grid con las carreras activas
    Public Shared Function listadoCarreras() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("SELECT DISTINCT c.cv_carrera AS CLAVE, c.nivel AS NIVEL,c.nombre AS NOMBRE FROM basic_grupos as g " +
                                        "LEFT OUTER JOIN info_carreras as c on g.id_carrera=c.id_carrera order by nivel desc,cv_carrera asc", c)
        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    'llena el grid con los grupos por carrera
    Public Shared Function grupoCarrera(ByVal carrera As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("SELECT g.id_grupo,c.cv_carrera,c.nivel,g.grado,g.grupo, SUBSTRING(t.turno,1,1) as turno    " +
                                        "FROM basic_grupos as g   " +
                                        "LEFT OUTER JOIN info_carreras as c on g.id_carrera= c.id_carrera  " +
                                        "Left OUTER JOIN basic_turnos as t on g.turno= t.id_turno " +
                                        "WHERE cv_carrera ='" + carrera + "' ORDER BY grado asc ", c)

        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    'llena el grid con los alumnos por grupo
    Public Shared Function alumnosGrupo(ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY apellido_pat asc) AS numero, matricula, upper(apellido_pat) as apellido_pat, upper(apellido_mat) as apellido_mat, upper(nombre) as nombre," +
                                        "upper(estatus) as estatus from user_alumnos where id_grupo='" + id + "' ORDER BY apellido_pat asc,apellido_mat asc", c)

        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    'Tutor del grupo
    Shared Function tutorGrupo(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tutor As New SqlCommand("SELECT case when tutor is null then 'SIN ASIGNAR' else UPPER(tutor) end FROM basic_grupos WHERE id_grupo='" + id + "'", c)
        c.Open()
        tutorGrupo = tutor.ExecuteScalar
        c.Close()
    End Function

    'Inserta nuevo grupo de 1er grado
    Public Shared Function insertaGrupo(ByVal id As String, ByVal turno As String, ByVal carrera As String, ByVal grupo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("INSERT INTO basic_grupos (id_grupo,turno,id_carrera,grado,grupo,cupos) values " +
                                          "('" + id + "','" + turno + "','" + carrera + "','1','" + grupo + "','40')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat

    End Function

    'Seleccionar ultimo id_grupo para asignar un nuevo id_grupo
    Shared Function maxId() As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tutor As New SqlCommand("SELECT  MAX(id_grupo) from basic_grupos", c)
        c.Open()
        maxId = tutor.ExecuteScalar
        c.Close()
    End Function

    'Seleccionar ultimo id_grupo para asignar un nuevo id_grupo
    Shared Function selectCarrera(ByVal carrera As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tutor As New SqlCommand("SELECT id_carrera from info_carreras where cv_carrera='" + carrera + "'", c)
        c.Open()
        selectCarrera = tutor.ExecuteScalar
        c.Close()
    End Function



    ''''''''tutores --------------------------------------------------------------------------------------
    Shared Function selectClavetrab(ByVal user As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tutor As New SqlCommand("SELECT clavetrab from user_users where usuario='" + user + "'", c)
        c.Open()
        selectClavetrab = tutor.ExecuteScalar
        c.Close()
    End Function

    ''''llena el grid con los grupos para el tutor

    Public Shared Function llenaGruposTutor(ByVal id_tutor As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("SELECT bc.id_grupo, ic.nombre,bt.turno,bc.grado,bc.grupo FROM basic_grupos as bc LEFT OUTER JOIN info_carreras as ic on bc.id_carrera=ic.id_carrera " +
                                         "Left OUTER JOIN basic_turnos as bt on bc.turno=bt.id_turno where id_tutor='" + id_tutor + "'", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat

    End Function

    'indica el cilo actual del grupo
    Shared Function cicloGrupo(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mf As New SqlCommand("SELECT ciclo from basic_grupos where id_grupo='" + id + "'", c)

        c.Open()
        cicloGrupo = mf.ExecuteScalar.ToString

    End Function



    ''Carga listado de alumnos

    Public Shared Function cargaAlumnos(ByVal id_grupo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("SELECT  rank() OVER(ORDER BY apellido_pat,apellido_mat,nombre ) as R, matricula, upper(apellido_pat+' '+apellido_mat+' '+nombre) nombre, UPPER(estatus) estatus FROM user_alumnos where id_grupo='" + id_grupo + "'", c)
        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat

    End Function

    'foto del alumno

    Shared Function photoAlumno(ByVal usuario As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mf As New SqlCommand("select photo from user_alumnos where usuario='" + usuario + "'", c)
        Try
            c.Open()
            photoAlumno = mf.ExecuteScalar.ToString
            c.Close()
        Catch ex As Exception
            photoAlumno = "..\docstock\admindocs\images\defaultimg.jpg"
        End Try
    End Function

    'llena el drop down con las materias que lleva el alumno

    Public Shared Function cargaMaterias(ByVal matricula As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select ali.icu, m.materia from current_alicu as ali LEFT OUTER JOIN current_icurel as rel on ali.icu=rel.icu " +
                                        "LEFT OUTER JOIN info_materias as m on rel.cve_materia=m.cve_materia where ali.matricula='" + matricula + "' ", c)
        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat

    End Function

    'Inserta un tema visto en tutoria guardado sin canalizar
    Public Shared Function insertaTemas(ByVal matricula As String, ByVal tema As String, ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into info_tutoria_individual_temas (matricula,tema_abordado, fecha_guardado, status_temas,ciclo) values " +
                                          "('" + matricula + "','" + tema + "', getdate(), 1,'" + ciclo + "' )", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat

    End Function
    'Inserta un tema visto en tutoria guardado y lo canaliza
    Public Shared Function insertaTemasCanalizado(ByVal matricula As String, ByVal tema As String, ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into info_tutoria_individual_temas (matricula,tema_abordado, fecha_guardado, status_temas,ciclo) values " +
                                          "('" + matricula + "','" + tema + "', getdate(), 2,'" + ciclo + "' )", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat

    End Function

    'LLENA EL GRID CON LOS TEMAS DE TUTORIA
    Public Shared Function cargaTemas(ByVal matricula As String, ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("SELECT id, convert(varchar(11),fecha_guardado,105) as fecha, tema_abordado as descripcion, case when status_temas =1 then 'GUARDADO' else 'CANALIZADO' end  as estatus,ciclo from info_tutoria_individual_temas WHERE matricula='" + matricula + "' and ciclo='" + ciclo + "' ", c)
        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat

    End Function

    'ACTUALIZA EL TEMA DE TUTORIA
    Shared Sub actualizaTema(ByVal tema As String, ByVal id As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("update info_tutoria_individual_temas set tema_abordado='" + tema + "' where id='" + id + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function temaSeleccionado(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mf As New SqlCommand("SELECT tema_abordado FROM info_tutoria_individual_temas WHERE id='" + id + "'", c)

        c.Open()
        temaSeleccionado = mf.ExecuteScalar.ToString
        c.Close()

    End Function
    'inserta metas del alumno
    Public Shared Function insertaMetas(ByVal matricula As String, ByVal meta As String, ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into info_tutoria_individual_metas (matricula,metas_acuerdos, fecha_guardado,ciclo) values " +
                                          "('" + matricula + "','" + meta + "', getdate(),'" + ciclo + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat

    End Function


    'LLENA EL GRID CON LAS METAS DE TUTORIA
    Public Shared Function cargaMetas(ByVal matricula As String, ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("SELECT id, convert(varchar(11),fecha_guardado,105) as fecha, metas_acuerdos as descripcion,ciclo from info_tutoria_individual_metas WHERE matricula='" + matricula + "' and ciclo='" + ciclo + "' ", c)
        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat

    End Function


    'verifica si la contraseña es correcta para guardar las metas

    Shared Function validaContraseña(ByVal matricula As String, ByVal pwd As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim xs As New SqlCommand("select case when COUNT(*)>0 THEN 1 else 0 end from user_alumnos where matricula='" + matricula + "' and pass='" + pwd + "'", c)
        c.Open()
        validaContraseña = xs.ExecuteScalar.ToString
        c.Close()
    End Function

    'inserta el diagnostico del alumno

    Public Shared Function insertaDiagnostico(ByVal matricula As String, ByVal diagnostico As String, ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into info_tutoria_individual_diagnostico (matricula,diagnostico,fecha_guardado,ciclo) values " +
                                          "('" + matricula + "','" + diagnostico + "', getdate(),'" + ciclo + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat

    End Function

    'ACTUALIZA EL DIAGNOSTICO DEL ALUMNO
    Shared Sub actualizaDiagnostico(ByVal diagnostico As String, ByVal matricula As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("update info_tutoria_individual_diagnostico set diagnostico='" + diagnostico + "',fecha_guardado=getdate() where matricula='" + matricula + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()
    End Sub


    'carga el diagnostico del alumno

    Public Shared Function diagnosticoAlumno(ByVal matricula As String, ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("SELECT diagnostico, convert(varchar(11),fecha_guardado,105) as fecha,ciclo from info_tutoria_individual_diagnostico WHERE matricula='" + matricula + "' and ciclo='" + ciclo + "'", c)
        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat

    End Function


    'carga el nombre del alumno

    Public Shared Function nombreAlumno(ByVal matricula As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select nombre_completo from user_alumnos where matricula= '" + matricula + "'", c)
        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat

    End Function

    'valida que exista un diagnostico
    Shared Function validaDiagnostico(ByVal matricula As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim xs As New SqlCommand("select case WHEN COUNT(*)>0 then 1 else 0 end from info_tutoria_individual_diagnostico where matricula='" + matricula + "'", c)
        c.Open()
        validaDiagnostico = xs.ExecuteScalar.ToString
        c.Close()
    End Function



End Class
