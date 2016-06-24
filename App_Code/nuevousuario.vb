Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.IO
Imports secure_tools


Public Class nuevousuario

    'Valida que la que el registro no exista en la tabla secure_logins
    Public Shared Function validaLogin(ByVal user As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case WHEN count(*)>0 THEN '1' else '0' END as duplicado from secure_logins where codigo='" + user + "'", c)
        c.Open()
        validaLogin = valida.ExecuteScalar.ToString
        c.Close()
    End Function

    'Inserta en la tabla de usuarios despues de validar
    Public Shared Function newUser(ByVal nombres As String, ByVal paterno As String, ByVal materno As String, ByVal puesto As String, ByVal clave As String, ByVal usuario As String, ByVal img As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into user_users (nombres, apellidopat,apellidomat,idpuesto,clavetrab,usuario,habilitado,photo)" +
                                          "values ('" + nombres + "','" + paterno + "','" + materno + "','" + puesto + "','" + clave + "','" + usuario + "','1','" + img + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    'Inserta en la tabla de logins despues de validar
    Public Shared Function newLogin(ByVal codigo As String, ByVal pass As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into secure_logins (codigo, pwd, tabla) values ('" + codigo + "','" + pass + "','user_users')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function


    'Carga los puestos para llenar el dropdownlist
    Public Shared Function cargaPuesto() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select id, cargo from info_cargosutj ORDER BY cargo ASC", c)

        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat
    End Function
    'Carga los puestos para agregar unicamente tutores
    Public Shared Function cargaPuestoTutor() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select id, cargo from info_cargosutj where id_categoria='2'", c)

        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat
    End Function


    'Cargar las paginas para asignar los privilegios
    Public Shared Function cargaPriv() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select nombre as CATEGORIA, extenso AS DESCRIPCION,active ACTIVO from info_userpriv order by categoria asc, id_page asc ", c)

        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat
    End Function
    'menu normal
    Shared Function topmenu() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tm As New SqlDataAdapter("select nombre,cabezal_num,css,enable,active,extenso from info_userpriv where cabezal='1' and es_alumno=0 order by cabezal_orden", c)
        Dim tmt As New DataTable
        c.Open()
        tm.Fill(tmt)
        c.Close()
        Return tmt
    End Function

    'menu tutores
    Shared Function topmenuTutor() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tm As New SqlDataAdapter("select nombre,cabezal_num,css,enable,active,extenso from info_userpriv where cabezal='1' and es_tutor='1' order by cabezal_orden", c)
        Dim tmt As New DataTable
        c.Open()
        tm.Fill(tmt)
        c.Close()
        Return tmt
    End Function

    Shared Function topmenu_lleno(ByVal usuario As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tml As New SqlDataAdapter("select nombre,cabezal_num,css,enable,active,extenso,'" + usuario + "' as usuario from info_userpriv where cabezal='1' and es_alumno=0 order by cabezal_orden", c)
        Dim tmlt As New DataTable
        c.Open()
        tml.Fill(tmlt)
        c.Close()
        Return tmlt
    End Function

    'Submenu normal
    Shared Function submenu(ByVal cabezalitem As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim sm As New SqlDataAdapter("select nombre,ruta,css,enable,active,extenso,id_page from info_userpriv where cabezal='0' and pertenece='" + cabezalitem + "' order by submenu_orden", c)
        Dim smt As New DataTable
        c.Open()
        sm.Fill(smt)
        c.Close()
        Return smt
    End Function

    'Submenu tutores
    Shared Function submenuTutor(ByVal cabezalitem As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim sm As New SqlDataAdapter("select nombre,ruta,css,enable,active,extenso,id_page from info_userpriv where cabezal='0' and pertenece='" + cabezalitem + "' and es_tutor='1' order by submenu_orden", c)
        Dim smt As New DataTable
        c.Open()
        sm.Fill(smt)
        c.Close()
        Return smt
    End Function

    Shared Function submenu_lleno(ByVal cabezalitem As String, ByVal usuario As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim sl As New SqlDataAdapter("select nombre,ruta,css,enable,active,extenso,iup.id_page,CASE WHEN ua.id_page IS NULL THEN '0' ELSE '1' END as assign from info_userpriv as iup " + _
                                     "left join (select id_page from user_access where usuario='" + usuario + "') as ua on iup.id_page=ua.id_page where cabezal='0' " + _
                                     "and pertenece='" + cabezalitem + "' order by submenu_orden", c)
        Dim slt As New DataTable
        c.Open()
        sl.Fill(slt)
        c.Close()
        Return slt
    End Function

    '---------------------------------------------------------------------------------------------------------
    'MANTENIMIENTO DE USUARIOS
    'busqueda 
    Shared Function tabla_resultados_busqueda(ByVal abuscar As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim trb As New SqlDataAdapter("SELECT UPPER(apellidopat + ' ' + apellidomat + ' ' + nombres + '  (' + usuario + ')') as item, id FROM user_users " + _
                                    "WHERE UPPER(apellidopat+' '+ apellidomat+ ' ' + nombres+ ' - ' + usuario) LIKE UPPER('%" + abuscar + "%') " + _
                                    "order by apellidopat, apellidomat, nombres", c)
        Dim trbt As New DataTable
        c.Open()
        trb.Fill(trbt)
        c.Close()
        Return trbt
    End Function

    'mostrar datos de el usuario seleccionado
    Shared Function tabla_consulta_llenado(ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tcl As New SqlDataAdapter("SELECT        dbo.user_users.nombres, dbo.user_users.apellidopat, dbo.user_users.apellidomat," +
                                      "dbo.user_users.emailper, dbo.info_cargosutj.cargo, dbo.user_users.clavetrab, dbo.user_users.emailins, dbo.user_users.telefono,dbo.user_users.usuario," +
                                      "dbo.user_users.usuario, dbo.user_users.photo " +
                                      "FROM            dbo.user_users INNER JOIN " +
                                      "dbo.info_cargosutj ON dbo.user_users.idpuesto = dbo.info_cargosutj.id " +
                                      "WHERE        (dbo.user_users.id = '" + id + "')", c)

        Dim tclt As New DataTable
        c.Open()
        tcl.Fill(tclt)
        c.Close()
        Return tclt
    End Function

    'actualizar datos tabla user_users
    Public Shared Sub actualizaUser(ByVal nombre As String, ByVal paterno As String, ByVal materno As String, ByVal personal As String,
                                     ByVal cargo As String, ByVal clave As String, ByVal insti As String, ByVal extension As String, ByVal photo As String, ByVal usuario As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("UPDATE user_users set nombres='" + nombre + "', apellidopat='" + paterno + "', apellidomat='" + materno + "'," +
                                        "emailper='" + personal + "', idpuesto='" + cargo + "', clavetrab='" + clave + "', emailins='" + insti + "'," +
                                        "telefono='" + extension + "', photo='" + photo + "' where usuario='" + usuario + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()

    End Sub

    ''---------------------------------------------------------------------
    'actualizar usuario de user_users y secure_logins

    'Seleccionar los el usuario y password de secure_logins
    Shared Function consultarLogin(ByVal codigo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim login As New SqlDataAdapter("select codigo, pwd from secure_logins where codigo='" + codigo + "'", c)

        Dim logint As New DataTable
        c.Open()
        login.Fill(logint)
        c.Close()
        Return logint
    End Function

    'actualiza la tabal secuere logins
    Public Shared Sub actualizaLogin(ByVal password As String, ByVal user As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("UPDATE secure_logins set  pwd='" + password + "' " + _
                                        "WHERE codigo='" + user + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()

    End Sub
    '-----------------------------------------------------------------------------------
    'CODIGO DE DISTPACHER

    Shared Function llenaUser(ByVal nombre As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim campos As DataTable = campos_de_tabla(nombre)
        Dim tcl As New SqlDataAdapter("SELECT " + campos.Rows(0).Item(0).ToString + "." + campos.Rows(0).Item(3).ToString + "," +
                                      "" + campos.Rows(0).Item(0).ToString + "." + campos.Rows(0).Item(4).ToString + "," +
                                      "" + campos.Rows(0).Item(0).ToString + "." + campos.Rows(0).Item(5).ToString + ",uu.emailper, " +
                                      "uc.cargo, uu.clavetrab, uu.emailins, uu.telefono,uu.usuario,uu.idpuesto FROM " + campos.Rows(0).Item(0).ToString + " INNER JOIN " +
                                      "user_users as uu ON " + campos.Rows(0).Item(0).ToString + "." + campos.Rows(0).Item(1).ToString + "=uu.usuario INNER JOIN " +
                                      "info_cargosutj as uc ON uu.idpuesto = uc.id WHERE (" + campos.Rows(0).Item(0).ToString + "." + campos.Rows(0).Item(1).ToString + " = '" + nombre + "')", c)

        Dim tclt As New DataTable
        c.Open()
        tcl.Fill(tclt)
        c.Close()
        Return tclt
    End Function

    Shared Function cargaurlfoto(ByVal nombre As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cuf As New SqlCommand("select photo from user_users where usuario='" + nombre + "'", c)
        c.Open()
        cargaurlfoto = cuf.ExecuteNonQuery()
        c.Close()
    End Function

    Shared Function llenaAlumnoCrystalRep(ByVal matricula As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim llenado As New SqlDataAdapter("select  ua.matricula,upper(ua.nombre) nombre, upper(ua.apellido_pat) primer_apellido,upper(ua.apellido_mat) segundo_apellido,ic.nombre carrera,ic.nivel, " +
                                            "upper(ua.turno) turno,ua.grado_actual,ua.grupo_actual,upper(ua.estatus) estatus,Case When ua.curp='' then 'Sin asignar' else ua.curp end curp, case when ua.rfc='' then 'Sin asignar' else ua.rfc end rfc, " +
                                            "case when ua.nss='' then 'Sin asignar' else ua.nss end nss,case when ua.correo='' then 'Sin asignar' else ua.correo end correo ,case when ua.t_fijo='' then 'Sin asignar' else ua.t_fijo end t_fijo,  " +
                                            "case when ua.t_movil='' then 'Sin asignar' else ua.t_movil end t_movil, case when ua.calle='' then 'Sin asignar' else upper(ua.calle) end  calle, " +
                                            "case WHEN ua.numero_exterior='' then 'Sin asignar' else ua.numero_exterior end numero_exterior,case WHEN ua.numero_interior='' then 'Sin asignar' else ua.numero_interior end numero_interor ," +
                                            "case when ua.cp='' then 'Sin asignar' else ua.cp end cp,case when ua.fecha_nacimiento='' then 'Sin asignar' else convert(varchar(12),ua.fecha_nacimiento,105) end as nacimento,    " +
                                             "case when ua.padre_tutor='' then 'Sin asignar' else upper(ua.padre_tutor) end padre_tutor, case when ua.tel_contacto1='' then 'Sin asignar' else ua.tel_contacto1 end tel_contacto1,case when ua.tel_contacto2='' then 'Sin asignar' else ua.tel_contacto2 end tel_contacto2 " +
                                            "from user_alumnos as ua  " +
                                            "LEFT OUTER JOIN info_carreras as ic on ua.carrera=ic.id_carrera   " +
                                            "WHERE matricula='" + matricula + "'", c)
        Dim llenadot As New DataTable
        c.Open()
        llenado.Fill(llenadot)
        c.Close()
        Return llenadot
    End Function
    Shared Function llenaAlumno(ByVal matricula As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim llenado As New SqlDataAdapter("select  ua.matricula,upper(ua.nombre) nombre, upper(ua.apellido_pat) primer_apellido,upper(ua.apellido_mat) segundo_apellido,ic.nombre carrera,ic.nivel, " +
                                            "upper(ua.turno) turno,ua.grado_actual,ua.grupo_actual,upper(ua.estatus) estatus,ua.curp , ua.rfc ,ua.nss , ua.correo  ,ua.t_fijo , ua.t_movil , upper(ua.calle) ," +
                                            "ua.numero_exterior , ua.numero_interior  ,ua.cp , convert(varchar(12),ua.fecha_nacimiento,105) ,upper(ua.padre_tutor) , ua.tel_contacto1 , ua.tel_contacto2 " +
                                            "from user_alumnos As ua LEFT OUTER JOIN info_carreras As ic On ua.carrera=ic.id_carrera  WHERE matricula='" + matricula + "'", c)
        Dim llenadot As New DataTable
        c.Open()
        llenado.Fill(llenadot)
        c.Close()
        Return llenadot
    End Function

    'Actualiza tabla user_alumnos
    Public Shared Sub actualizaAlumno(ByVal curp As String, ByVal rfc As String, ByVal nss As String, ByVal email As String, ByVal tfijo As String,
                                     ByVal tmovil As String, ByVal domicilio As String, ByVal numext As String, ByVal numint As String, ByVal cp As String,
                                     ByVal padre As String, ByVal contacto1 As String, ByVal contacto2 As String, ByVal usuario As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("UPDATE user_alumnos set curp='" + curp + "', rfc='" + rfc + "', nss='" + nss + "', correo='" + email + "', t_fijo='" + tfijo + "',t_movil='" + tmovil + "',calle='" + domicilio + "'," +
                                        "numero_exterior='" + numext + "',numero_interior='" + numint + "', cp='" + cp + "', padre_tutor='" + padre + "',tel_contacto1='" + contacto1 + "', tel_contacto2='" + contacto2 + "' where usuario='" + usuario + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()

    End Sub

    Shared Sub delPriv(ByVal usuario As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim delPriv As New SqlCommand("delete from user_access where usuario='" + usuario + "'", c)
        c.Open()
        delPriv.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub newPriv(ByVal usuario As String, ByVal idpage As String, ByVal orden As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim delPriv As New SqlCommand("insert into user_access (usuario,id_page, orden) VALUES ('" + usuario + "','" + idpage + "','" + orden + "')", c)
        c.Open()
        delPriv.ExecuteNonQuery()
        c.Close()
    End Sub

    '''Validar password para poder cambairlo
    Public Shared Function validaPass(ByVal pass As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case WHEN count(*)>0 THEN '1' else '0' END as duplicado from secure_logins where pwd='" + pass + "'", c)
        c.Open()
        validaPass = valida.ExecuteScalar.ToString
        c.Close()
    End Function
   
    'Actualiza pass
    Public Shared Sub actualizaPass(ByVal password As String, ByVal user As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("UPDATE secure_logins set  pwd='" + password + "' " + _
                                        "WHERE codigo='" + user + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()
    End Sub


    'Elimina usuario de la tabla user_users

    Shared Sub eliminaUser(ByVal nombre As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim delPriv As New SqlCommand("delete from user_users where nombre_completo='" + nombre + "'", c)
        c.Open()
        delPriv.ExecuteNonQuery()
        c.Close()
    End Sub

    'Elimina login de la tabla secuere_logins

    Shared Sub eliminaLogin(ByVal usuario As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim delPriv As New SqlCommand("delete from secure_logins where codigo='" + usuario + "'", c)
        c.Open()
        delPriv.ExecuteNonQuery()
        c.Close()
    End Sub

    'Elimina el acceso de la tabla user_acces

    Shared Sub eliminaAcceso(ByVal usuario As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim delPriv As New SqlCommand("delete from user_access where usuario='" + usuario + "'", c)
        c.Open()
        delPriv.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function uploadfile(ByVal enviador As FileUpload, ByVal registro As String) As Boolean
        If enviador.HasFile Then
            'Try
            If enviador.PostedFile.ContentType = "image/jpeg" Or enviador.PostedFile.ContentType = "image/png" Or enviador.PostedFile.ContentType = "image/gif" Or enviador.PostedFile.ContentType = "image/jpg" Then
                If enviador.PostedFile.ContentLength < 10096000 Then '***mide en kb el limite son 10 mb, pero se solicita que sea 1.5
                    Dim nombre_archivo As String = registro & Right(enviador.FileName, 4)
                    Dim path As String = HttpContext.Current.Server.MapPath("..\docstock\admindocs\images\") & nombre_archivo
                    Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                    If (file.Exists) Then
                        file.Delete()
                    End If
                    enviador.SaveAs(path)
                    uploadfile = True
                Else
                    uploadfile = False
                End If
            Else
                uploadfile = False
            End If
        Else
            uploadfile = False
        End If
    End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''
    'Llena el grid con las carreras activas para asignarlas a un profesor 
    Shared Function llenaCarrera() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tcl As New SqlDataAdapter("SELECT cv_carrera,nombre FROM info_carreras where activo=1", c)
        Dim tclt As New DataTable
        c.Open()
        tcl.Fill(tclt)
        c.Close()
        Return tclt
    End Function

    'Elimina valores en info_carrera_profesor antes de insertarlo
    Shared Sub eliminaCarrera(ByVal clave As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim delCarrera As New SqlCommand("delete from info_carrera_profesor where cv_trabajador='" + clave + "'", c)
        c.Open()
        delCarrera.ExecuteNonQuery()
        c.Close()
    End Sub

    'insertar valores en info_carrera_profesor activados
    Shared Sub carreraProf(ByVal cv_trabajador As String, ByVal cv_carrera As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim insertCarrera As New SqlCommand("insert into info_carrera_profesor(cv_trabajador,cv_carrera,pertenece) values ('" + cv_trabajador + "','" + cv_carrera + "',1)", c)
        c.Open()
        insertCarrera.ExecuteNonQuery()
        c.Close()
    End Sub

    'insertar valores en info_carrera_profesor desactivadas
    Shared Sub carreraProfDes(ByVal cv_trabajador As String, ByVal cv_carrera As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim insertCarrera As New SqlCommand("insert into info_carrera_profesor(cv_trabajador,cv_carrera,pertenece) values ('" + cv_trabajador + "','" + cv_carrera + "',0)", c)
        c.Open()
        insertCarrera.ExecuteNonQuery()
        c.Close()
    End Sub

    'Llena el grid con las carreras asignadas al profesor para poder modificarlas 
    Shared Function llenaCarreraAsignada(ByVal clave As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tcl As New SqlDataAdapter("SELECT p.cv_carrera,c.nombre,p.pertenece from info_carrera_profesor as p LEFT OUTER JOIN info_carreras as c on p.cv_carrera COLLATE Modern_Spanish_CS_AS =c.cv_carrera where p.cv_trabajador ='" + clave + "'", c)
        Dim tclt As New DataTable
        c.Open()
        tcl.Fill(tclt)
        c.Close()
        Return tclt
    End Function

End Class
