Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Public Class se_docs

    'llenar grid con todos los aranceles
    Public Shared Function infoDocs() As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("Select descripcion as DESCRIPCION, precio as PRECIO from info_docs_se", c)
        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat

    End Function


    'Seleccionar precio de un arancel en especifico
    Shared Function precioDoc(ByVal tipo As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim version As New SqlCommand("Select precio from info_docs_se where descripcion='" + tipo + "'", c)
        c.Open()
        precioDoc = version.ExecuteScalar.ToString()
        c.Close()
    End Function


    'Seleccionar nombre de un arancel en especifico
    Shared Function descDoc(ByVal tipo As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim version As New SqlCommand("Select descripcion from info_docs_se where descripcion='" + tipo + "'", c)
        c.Open()
        descDoc = version.ExecuteScalar.ToString()
        c.Close()
    End Function

    'Actualiza arancel
    Shared Sub actualizaArancel(ByVal precio As String, ByVal tipo As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("update info_docs_se set precio='" + precio + "' where descripcion='" + tipo + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()
    End Sub




    'Busqueda de aspirantes para kardex

    Shared Function resultado_busqueda(ByVal abuscar As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim rb As New SqlDataAdapter("SELECT top(1) nombre + ' ' + apellidop+' ' + apellidom + ' - '+ matricula as item,matricula FROM history_evaldata where " +
                                     "UPPER(matricula+' '+ apellidop+' ' +apellidom+' ' + nombre) like  UPPER('%" + abuscar + "%') ORDER BY apellidop,apellidom,nombre", c)
        Dim rbt As New DataTable
        c.Open()
        rb.Fill(rbt)
        c.Close()
        Return rbt
    End Function

    'BUSQUEDA DE ALUMNOS PARA KARDEX IALVAROH
    Shared Function busqueda_alkardex(ByVal abuscar As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim rb As New SqlDataAdapter("SELECT DISTINCT nombre + ' ' + apellidop+' ' + apellidom + ' - '+ matricula as item,matricula,apellidop,apellidom,nombre FROM history_evaldata where " +
                                     "UPPER(matricula+' '+ apellidop+' ' +apellidom+' ' + nombre) like  UPPER('%" + abuscar + "%') ORDER BY apellidop,apellidom,nombre", c)
        Dim rbt As New DataTable
        c.Open()
        rb.Fill(rbt)
        c.Close()
        Return rbt
    End Function

    'Trae los ciclos del segun la matrícula
    Shared Function cicloskardex(ByVal matricula As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT DISTINCT ciclo,'" + matricula + "' as matricula FROM history_evaldata WHERE (matricula = '" + matricula + "')", cn)
        Dim cct As New DataTable
        cn.Open()
        cc.Fill(cct)
        cn.Close()
        Return cct
    End Function


    Shared Function kardex_estudiante_kardex(ByVal matricula As String, ByVal ciclo As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ke As New SqlDataAdapter("SELECT history_evaldata.nombre_materia AS materia, history_evaldata.calificacion," +
                                     "history_evaldata.definicion_calificacion As descripcion, info_tipocalificacion.cal AS tipocalificacion  " +
                                      "From history_evaldata LEFT OUTER JOIN info_tipocalificacion ON history_evaldata.tipocalificacion =  " +
                                      "info_tipocalificacion.idcal WHERE (history_evaldata.matricula = '" + matricula + "') AND " +
                                      "(history_evaldata.ciclo = '" + ciclo + "')", cn)
        Dim ket As New DataTable
        cn.Open()
        ke.Fill(ket)
        cn.Close()
        Return ket
    End Function


    'datos escolares para kardex
    Public Shared Function crvKardex(ByVal matricula As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim crvcomando As New SqlDataAdapter("set LANGUAGE 'Español'  " +
                                            "SELECT h.ciclo, gc.fechas, h.matricula, c.nombre As carrera, h.plan_estudio, c.cv_carrera, c.nivel, h.nombre_materia, h.calificacion, t.minical as tipo " +
                                            "From history_evaldata As h " +
                                            "Left outer join info_carreras as c on c.id_carrera=h.carrera   " +
                                            "Left outer join info_tipocalificacion as t on t.idcal=h.tipocalificacion " +
                                            "Left outer join general_ciclos as gc on h.ciclo COLLATE Modern_Spanish_CI_AS=gc.ciclo " +
                                            "WHERE(matricula ='" + matricula + "') order by ciclo Asc ", c)
        Dim crvcomandot As New DataTable
        c.Open()
        crvcomando.Fill(crvcomandot)
        c.Close()
        Return crvcomandot

    End Function

    'datos personales para kardex
    Public Shared Function crvDatosAlumno(ByVal matricula As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim crvcomando As New SqlDataAdapter("select  matricula,nombre,apellido_pat, apellido_mat,curp,carrera,grado_actual,grupo_actual,estatus,turno from user_alumnos where matricula='" + matricula + "'", c)
        Dim crvcomandot As New DataTable
        c.Open()
        crvcomando.Fill(crvcomandot)
        c.Close()
        Return crvcomandot

    End Function

    'foto para kardex
    Shared Function imgKardex(ByVal matricula As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim foto As New SqlCommand("Select photo from user_alumnos where matricula='" + matricula + "'", c)
        c.Open()
        imgKardex = foto.ExecuteScalar.ToString()
        c.Close()
    End Function

    'Datos director de servicios escolares
    Public Shared Function datosDirector(ByVal id_puesto As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim crvcomando As New SqlDataAdapter("select puesto,responsable from info_puesto_firma where id_puesto='" + id_puesto + "'", c)
        Dim crvcomandot As New DataTable
        c.Open()
        crvcomando.Fill(crvcomandot)
        c.Close()
        Return crvcomandot

    End Function

    'imagen para reportes
    Shared Function firmaDirector(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim firma As New SqlCommand("Select firmapath from info_puesto_firma where id_puesto='" + id + "'", c)
        c.Open()
        firmaDirector = firma.ExecuteScalar.ToString()
        c.Close()
    End Function

    'Datos para constancia

    Public Shared Function datosConstancia(ByVal matricula As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim crvcomando As New SqlDataAdapter("SELECT ua.nombre_completo,UPPER(ua.estatus) as status,convert(varchar(2),ua.grado_actual) as grado, ua.grupo_actual,upper(ua.turno) as turno,c.nivel,c.nombre,matricula " +
                                               "from user_alumnos as ua left outer JOIN info_carreras as c on ua.carrera=c.id_carrera where matricula ='" + matricula + "'", c)
        Dim crvcomandot As New DataTable
        c.Open()
        crvcomando.Fill(crvcomandot)
        c.Close()
        Return crvcomandot

    End Function

    'ciclo activo
    Public Shared Function cicloActivo() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim crvcomando As New SqlDataAdapter("SET LANGUAGE 'Español' SELECT ciclo as CICLO,((((datename(month,[startdate])+' - ')+datename(month,[finaldate]))+' de ')+datename(year,[finaldate])) as FECHAS," +
                                             "((((datename(day,[startdate])+' de ')+datename(month,[startdate]))+' de ')+datename(year,[startdate])) as INICIO," +
                                             "((((datename(day,[finaldate])+' de ')+datename(month,[finaldate]))+' de ')+datename(year,[finaldate])) AS FIN   " +
                                             "From general_ciclos Where active = 1", c)
        Dim crvcomandot As New DataTable
        c.Open()
        crvcomando.Fill(crvcomandot)
        c.Close()
        Return crvcomandot

    End Function

    'Turno del alumno
    Shared Function tAlumno(ByVal matricula As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim turno As New SqlCommand("select upper(turno) from user_alumnos where matricula='" + matricula + "'", c)
        c.Open()
        tAlumno = turno.ExecuteScalar.ToString()
        c.Close()
    End Function



    '-horario segun el turno
    Public Shared Function horaTurno(ByVal turno As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim crvcomando As New SqlDataAdapter("SELECT hora_inicio,hora_fin FROM basic_turnos where turno='" + turno + "'", c)
        Dim crvcomandot As New DataTable
        c.Open()
        crvcomando.Fill(crvcomandot)
        c.Close()
        Return crvcomandot

    End Function


End Class
