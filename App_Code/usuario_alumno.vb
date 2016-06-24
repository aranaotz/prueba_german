Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports MessagingToolkit.QRCode.Codec
Imports MessagingToolkit.QRCode.Codec.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Web

Public Class usuario_alumno

    Shared Function busqueda_alumno(ByVal alumno As String, cs As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim ba As New SqlDataAdapter("SELECT user_alumnos.nombre_completo, user_alumnos.matricula,user_alumnos.codigo_unico, CASE WHEN user_generales.sexo IS NULL " + _
                                     "THEN 'no capturado!' ELSE CASE WHEN user_generales.sexo = '1' THEN 'es él...' ELSE 'es ella...' END END AS sexo " + _
                                     "FROM user_alumnos LEFT OUTER JOIN user_generales ON user_alumnos.codigo_unico = user_generales.codigo_unico " + _
                                     "WHERE (user_alumnos.nombre_completo LIKE '%" + alumno + "%') ORDER BY user_alumnos.nombre_completo", c)
        Dim bat As New DataTable
        c.Open()
        ba.Fill(bat)
        c.Close()
        busqueda_alumno = bat
    End Function

    Shared Function retrieve_data(ByVal codigo_unico As String, ByVal cs As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim rd As New SqlDataAdapter("SELECT user_alumnos.id, user_alumnos.matricula, user_alumnos.cve_ref, user_alumnos.codigo_unico, user_alumnos.nombre_completo, " + _
                                     "user_alumnos.apellido_paterno, user_alumnos.apellido_materno, user_alumnos.nombre, user_alumnos.programa, '~/qrcodes/" + codigo_unico + ".jpg' qrcode, " + _
                                     "info_carreras.nombre AS carrera, info_especialidad.nombre AS especialidad, user_alumnos.ingreso, user_alumnos.status, " + _
                                     "user_generales.domicilio, user_generales.colonia, user_generales.municipio, user_generales.estado, " + _
                                     "user_generales.c_postal, user_generales.curp, user_generales.factor_rh, user_generales.telefono, user_generales.celular, " + _
                                     "user_generales.sexo, ISNULL(user_generales.foto, '~/syncesc/defaults/default_image.jpg') foto, user_generales.correo, CASE WHEN user_generales.foto IS NULL THEN 1 ELSE 0 END enablecheck FROM user_alumnos " + _
                                     "LEFT OUTER JOIN user_generales ON user_alumnos.codigo_unico = user_generales.codigo_unico " + _
                                     "LEFT OUTER JOIN info_carreras ON info_carreras.cv_carrera = user_alumnos.carrera LEFT OUTER JOIN info_especialidad ON " + _
                                     "info_especialidad.cv_esp = user_alumnos.especialidad WHERE (user_alumnos.codigo_unico = '" + codigo_unico + "')", c)
        Dim rdt As New DataTable
        c.Open()
        rd.Fill(rdt)
        c.Close()
        retrieve_data = rdt
    End Function

    Shared Function gvmat(ByVal codigo_unico As String) As String
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gm As New SqlCommand("SELECT matricula FROM user_alumnos WHERE (codigo_unico = '" + codigo_unico + "')", cn)
        cn.Open()
        gvmat = gm.ExecuteScalar.ToString
        cn.Close()
    End Function

    Shared Sub savedqr(ByVal con As String, ByVal codigo_unico As String)
        Dim c As New SqlConnection(con)
        Dim oc As New SqlDataAdapter("SELECT user_alumnos.apellido_paterno + ' ' + user_alumnos.apellido_materno + ' ' + user_alumnos.nombre + " + _
                                     "'   -CURP:' + user_generales.curp + '   -cu:' + CONVERT(varchar, user_alumnos.codigo_unico) + '   " + _
                                     "-REFERENCIA COMPLETA:6890' + CONVERT(varchar, user_alumnos.cve_ref) AS multiplet FROM user_alumnos INNER JOIN " + _
                                    "user_generales ON user_alumnos.codigo_unico = user_generales.codigo_unico WHERE user_alumnos.codigo_unico='" + codigo_unico + "'", c)
        Dim oct As New DataTable
        c.Open()
        oc.Fill(oct)
        c.Close()
        Dim codificador As New QRCodeEncoder
        Select Case oct.Rows.Count
            Case Is > 0
                Dim img As Bitmap = codificador.Encode(oct.Rows(0).Item(0).ToString)
                img.Save(HttpContext.Current.Server.MapPath("\utsyn\qrcodes\") & codigo_unico & ".jpg", ImageFormat.Jpeg)
            Case Else
        End Select
    End Sub

    Shared Sub savedqr_full(ByVal con As String, ByVal codigo_unico As String)
        Dim c As New SqlConnection(con)
        Dim oc As New SqlDataAdapter("SELECT user_alumnos.codigo_unico, user_alumnos.apellido_paterno + ' ' + user_alumnos.apellido_materno + ' " + _
                                     "' + user_alumnos.nombre + '   -CURP:' + user_generales.curp + '   -cu:' + CONVERT(varchar, " + _
                                     "user_alumnos.codigo_unico) + '   -REFERENCIA: ' + CONVERT(varchar, user_alumnos.cve_ref) + '   -CLAVE: 6890' " + _
                                     "AS multiplet, LEN(user_alumnos.nombre_completo) AS largo FROM user_alumnos INNER JOIN user_generales ON " + _
                                     "user_alumnos.codigo_unico = user_generales.codigo_unico WHERE     (user_generales.curp <> '') ORDER BY largo desc", c)
        Dim oct As New DataTable
        c.Open()
        oc.Fill(oct)
        c.Close()
        Select Case oct.Rows.Count
            Case Is > 0
                Dim codificador As New QRCodeEncoder
                Dim t As Integer
                For t = 0 To oct.Rows.Count - 1
                    Dim img As Bitmap = codificador.Encode(oct.Rows(t).Item(1).ToString)
                    img.Save(HttpContext.Current.Server.MapPath("\utsyn\qrcodes\") & oct.Rows(t).Item(0).ToString & ".jpg", ImageFormat.Jpeg)
                Next
            Case Else
        End Select
    End Sub

    Shared Sub perfilsave(ByVal dtmx(,) As String, ByVal matricula As String, ByVal codigo_unico As String, ByVal referencia As String, ByVal ndoc As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ins_alumnos As New SqlCommand("INSERT INTO user_alumnos (matricula, cve_ref, codigo_unico, nombre_completo, apellido_paterno, apellido_materno, nombre, programa, carrera, especialidad, ingreso, status) " + _
                                          "VALUES ('" + matricula + "','" + referencia + "', '" + codigo_unico + "', '" + dtmx(24, 0) + "', '" + dtmx(1, 0) + "', '" + dtmx(2, 0) + "', '" + dtmx(3, 0) + "', " + _
                                          "'" + dtmx(25, 0) + "', '" + dtmx(10, 0) + "', '" + dtmx(11, 0) + "', '" + dtmx(23, 0) + "', 'AC')", c)
        Dim ins_generales As New SqlCommand("INSERT INTO user_generales (codigo_unico, sexo, f_nacimiento, e_civil, domicilio, colonia, municipio, estado, " + _
                                            "c_postal, l_nacimiento, curp, factor_rh, telefono, celular, correo, correo_inst, trabaja, trabajadnd, foto) values ('" + codigo_unico + "', " + _
                                            "'" + dtmx(14, 0) + "', '" + dtmx(15, 0) + "', '" + dtmx(16, 0) + "', '" + dtmx(5, 0) + "', '" + dtmx(6, 0) + "'," + _
                                            "'" + dtmx(7, 0) + "', 'Estado', '00000', '00000', '" + dtmx(4, 0) + "', '" + dtmx(13, 0) + "', " + _
                                            "'" + dtmx(8, 0) + "', '" + dtmx(9, 0) + "', '" + dtmx(12, 0) + "', 'correo_inst', '" + dtmx(26, 0) + "', '" + dtmx(27, 0) + "', " + _
                                            "'~/photo/" + codigo_unico & Right(dtmx(0, 0), 4) + "')", c)
        Dim ins_familiares As New SqlCommand("INSERT INTO user_familiares (codigo_unico, n_tutor, domicilio, colonia, municipio, entidad_fed,c_postal, " + _
                                             "l_nacimiento, ocupacion, telefono) VALUES ('" + codigo_unico + "','" + dtmx(20, 0) + "','" + dtmx(29, 0) + "', " + _
                                             "'','','','','','" + dtmx(28, 0) + "','" + dtmx(21, 0) + "')", c)
        Dim ins_procedencia As New SqlCommand("INSERT INTO user_procedencia (codigo_unico, bachillerato, mesinicio, anoinicio, mesfinal, anofinal, promedio) " + _
                                              "VALUES ('" + codigo_unico + "','" + dtmx(30, 0) + "','" + dtmx(31, 0) + "','" + dtmx(32, 0) + "', " + _
                                              "'" + dtmx(33, 0) + "','" + dtmx(34, 0) + "','" + dtmx(35, 0) + "')", c)
        Dim u As Integer
        For u = 0 To ndoc - 1
            Dim ins_documentos As New SqlCommand("UPDATE user_documentos SET entregado='" + dtmx(u, 1) + "', " + _
                                                 "codigo_unico='" + codigo_unico + "' WHERE (iddoc='" + (u + 1).ToString + "') AND (registro='" + dtmx(36, 0) + "')", c)
            c.Open()
            ins_documentos.ExecuteNonQuery()
            c.Close()
        Next

        Dim up_pingreso As New SqlCommand("UPDATE pingreso set alumno='1', alumnodate=getdate() where (ustring='" + dtmx(36, 0) + "')", c)

        c.Open()
        ins_alumnos.ExecuteNonQuery()
        ins_generales.ExecuteNonQuery()
        ins_familiares.ExecuteNonQuery()
        ins_procedencia.ExecuteNonQuery()
        up_pingreso.ExecuteNonQuery()
        c.Close()





        'Dim ps1 As New SqlCommand("UPDATE user_alumnos set apellido_paterno='" + i2 + "', apellido_materno='" + i3 + "', nombre='" + i4 + "' WHERE codigo_unico='" + codigo_unico + "'", c)
        'c.Open()
        'ps1.ExecuteNonQuery()
        'c.Close()
        'If icg = True Then
        'Dim ps2 As New SqlCommand("UPDATE user_generales SET sexo='" + i16 + "', domicilio='" + i6 + "', curp='" + i5 + "', factor_rh='" + i14 + "', telefono='" + i9 + "', " + _
        '                          "celular='" + i10 + "', correo='" + i13 + "', foto='~/syncesc/photo/" + codigo_unico & Right(i1, 4) + "' WHERE codigo_unico='" + codigo_unico + "'", c)
        'c.Open()
        'ps2.ExecuteNonQuery()
        'c.Close()
        'Else
        'Dim ps2 As New SqlCommand("INSERT INTO user_generales (sexo,domicilio,curp,factor_rh,telefono,celular,correo,foto,codigo_unico) VALUES ('" + i16 + "','" + i6 + "', " + _
        '                          "'" + i5 + "','" + i14 + "','" + i9 + "','" + i10 + "','" + i13 + "','~/syncesc/photo/" + codigo_unico & Right(i1, 4) + "','" + codigo_unico + "')", c)
        'c.Open()
        '
        '        ps2.ExecuteNonQuery()
        '        c.Close()
        '        End If
    End Sub

    Shared Sub perfilsave_al(ByVal i2 As String, ByVal i3 As String, ByVal i4 As String, ByVal i5 As String, ByVal i6 As String, ByVal i7 As String, ByVal i8 As String, ByVal i9 As String, ByVal i10 As String, ByVal i11 As String, ByVal i12 As String, ByVal i13 As String, ByVal i14 As String, ByVal i16 As String, ByVal codigo_unico As String, ByVal cs As String, ByVal icf As Boolean, ByVal icg As Boolean, ByVal icp As Boolean, ByVal i17 As String, ByVal i18 As String, ByVal i19 As String, ByVal i20 As String, ByVal i21 As String, ByVal i22 As String, ByVal i23 As String, ByVal i24 As String, ByVal i25 As String, ByVal i26 As String, ByVal i27 As String)
        Dim c As New SqlConnection(cs)
        Dim ps1 As New SqlCommand("UPDATE user_alumnos set apellido_paterno='" + i2 + "', apellido_materno='" + i3 + "', nombre='" + i4 + "' WHERE codigo_unico='" + codigo_unico + "'", c)
        c.Open()
        ps1.ExecuteNonQuery()
        c.Close()
        If icg = True Then
            Dim ps2 As New SqlCommand("UPDATE user_generales SET sexo='" + i16 + "', domicilio='" + i6 + "', curp='" + i5 + "', factor_rh='" + i14 + "', telefono='" + i9 + "', " + _
                                      "celular='" + i10 + "', correo='" + i13 + "', c_postal='" + i17 + "', f_nacimiento='" + i18 + "', e_civil='" + i23 + "', l_nacimiento='" + i19 + "', " + _
                                      "correo_inst='" + i20 + "',colonia='" + i7 + "', municipio='" + i8 + "' WHERE codigo_unico='" + codigo_unico + "'", c)
            c.Open()
            ps2.ExecuteNonQuery()
            c.Close()
        Else
            Dim ps2 As New SqlCommand("INSERT INTO user_generales (sexo,domicilio,curp,factor_rh,telefono,celular,correo,codigo_unico,c_postal,f_nacimiento,e_civil," + _
                                      "l_nacimiento,correo_inst,colonia,municipio) VALUES ('" + i16 + "','" + i6 + "', " + _
                                      "'" + i5 + "','" + i14 + "','" + i9 + "','" + i10 + "','" + i13 + "','" + codigo_unico + "','" + i17 + "','" + i18 + "','" + i23 + "'," + _
                                      "'" + i19 + "','" + i20 + "','" + i7 + "','" + i8 + "')", c)
            c.Open()
            ps2.ExecuteNonQuery()
            c.Close()
        End If
        If icf = True Then
            Dim ps2 As New SqlCommand("UPDATE user_familiares SET n_tutor='" + i21 + "', ocupacion='" + i22 + "', telefono='" + i24 + "', domicilio='" + i27 + "' WHERE codigo_unico='" + codigo_unico + "'", c)
            c.Open()
            ps2.ExecuteNonQuery()
            c.Close()
        Else
            Dim ps2 As New SqlCommand("INSERT INTO user_familiares (n_tutor,ocupacion,telefono,codigo_unico,domicilio) VALUES ('" + i21 + "','" + i22 + "', " + _
                                      "'" + i24 + "','" + codigo_unico + "','" + i27 + "')", c)
            c.Open()
            ps2.ExecuteNonQuery()
            c.Close()
        End If
        If icp = True Then
            Dim ps2 As New SqlCommand("UPDATE user_procedencia SET bachillerato='" + i25 + "', promedio='" + i26 + "' WHERE codigo_unico='" + codigo_unico + "'", c)
            c.Open()
            ps2.ExecuteNonQuery()
            c.Close()
        Else
            Dim ps2 As New SqlCommand("INSERT INTO user_procedencia (bachillerato,promedio,codigo_unico) VALUES ('" + i25 + "','" + i26 + "','" + codigo_unico + "')", c)
            c.Open()
            ps2.ExecuteNonQuery()
            c.Close()
        End If
    End Sub

    Shared Function valoresddl(ByVal codigo_unico As String, ByVal cn As String) As DataTable
        Dim c As New SqlConnection(cn)
        Dim vdd As New SqlDataAdapter("SELECT ISNULL(sexo,1) sexo,ISNULL(factor_rh,1) factor_rh FROM user_generales WHERE codigo_unico='" + codigo_unico + "'", c)
        Dim vddt As New DataTable
        c.Open()
        vdd.Fill(vddt)
        c.Close()
        valoresddl = vddt
    End Function

    Shared Function existegenerales(ByVal codigo_unico As String, ByVal cn As String) As Boolean
        Dim c As New SqlConnection(cn)
        Dim eg As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN 1 ELSE 0 END xsist FROM user_generales WHERE codigo_unico='" + codigo_unico + "'", c)
        c.Open()
        existegenerales = eg.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function existefamiliares(ByVal codigo_unico As String, ByVal cn As String) As Boolean
        Dim c As New SqlConnection(cn)
        Dim ef As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN 1 ELSE 0 END xsist FROM user_familiares WHERE codigo_unico='" + codigo_unico + "'", c)
        c.Open()
        existefamiliares = ef.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function existeprocedencia(ByVal codigo_unico As String, ByVal cn As String) As Boolean
        Dim c As New SqlConnection(cn)
        Dim ep As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN 1 ELSE 0 END xsist FROM user_procedencia WHERE codigo_unico='" + codigo_unico + "'", c)
        c.Open()
        existeprocedencia = ep.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function ddlsexo(ByVal cs As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim ddls As New SqlDataAdapter("select idsexo, sexo from basic_sexo", c)
        Dim ddlst As New DataTable
        c.Open()
        ddls.Fill(ddlst)
        c.Close()
        ddlsexo = ddlst
    End Function

    Shared Function ddlsangre(ByVal cs As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim ddlsa As New SqlDataAdapter("select idtipos, tipoyfactor from basic_sangres order by idtipos", c)
        Dim ddlsat As New DataTable
        c.Open()
        ddlsa.Fill(ddlsat)
        c.Close()
        ddlsangre = ddlsat
    End Function

    Shared Function ddlcivil(ByVal cs As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim ddlc As New SqlDataAdapter("select id_edocivil, edocivil from basic_edocivil order by id_edocivil", c)
        Dim ddlct As New DataTable
        c.Open()
        ddlc.Fill(ddlct)
        c.Close()
        ddlcivil = ddlct
    End Function

    Shared Function llena_alumno(ByVal codigo_unico As String, ByVal cs As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim la As New SqlDataAdapter("SELECT codigo_unico, matricula, apellido_paterno, apellido_materno, nombre, sexo, f_nacimiento, " + _
                                     "edocivil, domicilio, colonia, municipio, estado, c_postal, l_nacimiento, curp, tipoyfactor, telefono, " + _
                                     "celular, correo, correo_inst, foto, n_tutor, ndomicilio, ocupacion, ntelefono, bachillerato, promedio " + _
                                     "FROM base_gendataal WHERE codigo_unico='" + codigo_unico + "'", c)
        Dim lat As New DataTable
        c.Open()
        la.Fill(lat)
        c.Close()
        llena_alumno = lat
    End Function

    Shared Function generales_kardex(ByVal matricula As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gk As New SqlDataAdapter("select bg.codigo_unico,bg.matricula,bg.apellido_paterno,bg.apellido_materno,bg.nombre,bg.foto,bg.carrera,bg.especialidad, " + _
                                 "ic.nombre as ncarrera,ie.nombre as nespecialidad, susp.fsuspension as status from base_gendataal as bg " + _
                                 "left outer join info_carreras as ic on bg.carrera=ic.cv_carrera " + _
                                 "left outer join info_especialidad as ie on bg.especialidad=ie.cv_esp " + _
                                 "left outer join (SELECT TOP (1) '" + matricula + "' as innerdata,fsuspension FROM " + _
                                 "(SELECT     isu.status COLLATE Modern_Spanish_CS_AS + ' (' + hsu.suspension + ')' AS fsuspension FROM historial_suspensiones " + _
                                 "AS hsu INNER JOIN info_suspensiones AS isu ON hsu.suspension COLLATE Modern_Spanish_CI_AS = isu.cve_status " + _
                                 "WHERE (GETDATE() BETWEEN hsu.starttime AND hsu.endtime) AND (hsu.matricula = '" + matricula + "') UNION " + _
                                 "SELECT 'AC (ACTIVO)' AS fsuspension) AS suspensiones) AS susp on bg.matricula=susp.innerdata where bg.matricula='" + matricula + "'", cn)
        Dim gkdt As New DataTable
        cn.Open()
        gk.Fill(gkdt)
        cn.Close()
        generales_kardex = gkdt
    End Function

    Shared Function kardex_estudiante(ByVal matricula As String, ByVal ciclo As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ke As New SqlDataAdapter("SELECT historial_evaldata.nombre_materia AS materia, historial_evaldata.calificacion, " + _
                                     "historial_evaldata.definicion_calificacion AS descripcion, info_tipocalificacion.cal AS tipocalificacion " + _
                                     "FROM historial_evaldata LEFT OUTER JOIN info_tipocalificacion ON historial_evaldata.tipocalificacion = " + _
                                     "info_tipocalificacion.idcal WHERE (historial_evaldata.matricula = '" + matricula + "') AND " + _
                                     "(historial_evaldata.ciclo = '" + ciclo + "') ORDER BY historial_evaldata.icu", cn)
        Dim ket As New DataTable
        cn.Open()
        ke.Fill(ket)
        cn.Close()
        Return ket
    End Function

    Shared Function ciclos(ByVal matricula As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT DISTINCT ciclo FROM historial_evaldata WHERE (matricula = '" + matricula + "')", cn)
        Dim cct As New DataTable
        cn.Open()
        cc.Fill(cct)
        cn.Close()
        Return cct
    End Function

    Shared Function gcu(ByVal matricula As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gc As New SqlCommand("SELECT codigo_unico FROM user_alumnos WHERE matricula='" + matricula + "'", c)
        c.Open()
        gcu = gc.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function matricula(ByVal codigo_unico As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gc As New SqlCommand("SELECT matricula FROM user_alumnos WHERE codigo_unico='" + codigo_unico + "'", c)
        c.Open()
        matricula = gc.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function currentst_materias(ByVal matricula As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim csm As New SqlDataAdapter("SELECT distinct info_tematicas.materia FROM eval_unidades INNER JOIN info_tematicas ON eval_unidades.id_unidad = " + _
                                     "info_tematicas.cve_unica INNER JOIN info_defincal ON eval_unidades.cal = info_defincal.letra_unica WHERE " + _
                                     "(eval_unidades.matricula = '" + matricula + "') ", cn)
        Dim csmt As New DataTable
        cn.Open()
        csm.Fill(csmt)
        cn.Close()
        Return csmt
    End Function

    Shared Function currentst_calificaciones(ByVal matricula As String, ByVal materia As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim csc As New SqlDataAdapter("SELECT info_tematicas.nombre_ut, info_defincal.letra, info_defincal.def_letra FROM eval_unidades INNER JOIN " +
                                      "info_tematicas ON eval_unidades.id_unidad = info_tematicas.cve_unica INNER JOIN info_defincal ON eval_unidades.cal " +
                                      "= info_defincal.letra_unica WHERE (eval_unidades.matricula = '" + matricula + "') and materia='" + materia + "'", cn)
        Dim csct As New DataTable
        cn.Open()
        csc.Fill(csct)
        cn.Close()
        Return csct
    End Function



    'BUSQUEDA DE ALUMNOS---GERMAN

    'listado de alumnos
    Shared Function resultados_busqueda(ByVal abuscar As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim rb As New SqlDataAdapter("select matricula +'-'+nombre_completo as item, id from user_alumnos where (matricula +'-'+nombre_completo)" +
                                    "LIKE ('%" + abuscar + "%') AND estatus='Regular' and activo=0 ORDER BY carrera", c)
        Dim rbt As New DataTable
        c.Open()
        rb.Fill(rbt)
        c.Close()
        Return rbt
    End Function

    'detalle del alumno

    Shared Function llena_detalle(ByVal id As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tcl As New SqlDataAdapter("select ua.id,ua.matricula,ua.nombre,ua.apellido_pat,ua.apellido_mat,ic.nombre as carrera,ic.nivel,ua.plan_estudio,ua.turno,ua.grado_actual, " +
                                      "ua.grupo_actual, ua.estatus, ua.curp, ua.rfc, ua.nss, ua.correo, ua.t_fijo, ua.t_movil, ua.calle, ua.numero_exterior, ua.numero_interior, ua.cp,ua.pass " +
                                      "From user_alumnos as ua   " +
                                       "Left outer join info_carreras as ic on ua.carrera=ic.id_carrera where ua.id='" + id + "'", c)
        Dim tclt As New DataTable
        c.Open()
        tcl.Fill(tclt)
        c.Close()
        Return tclt
    End Function

    'Genera contraseñas

    Public Shared Function actualizaContra(ByVal pass As String, ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim oferta As New SqlDataAdapter("UPDATE user_alumnos set pass='" + pass + "' WHERE id='" + id + "'", c)
        Dim ofertat As New DataTable
        c.Open()
        oferta.Fill(ofertat)
        c.Close()
        Return ofertat
    End Function






End Class
