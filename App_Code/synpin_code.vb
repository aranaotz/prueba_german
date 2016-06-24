Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports secure_tools
Imports dtciclos
Imports System.Web.UI.WebControls
Imports System.Web
Imports System

Public Class synpin_code
    Shared Function tabla_carreras(ByVal conn As String, nivel As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tc As New SqlDataAdapter("SELECT cv_carrera,nombre as carrera FROM info_carreras WHERE nivel='" + nivel + "' AND activo=1 ORDER BY nivel,nombre", c)
        Dim tct As New DataTable
        c.Open()
        tc.Fill(tct)
        c.Close()
        tabla_carreras = tct
    End Function

    Shared Function tabla_carreras_actuales(ByVal conn As String, nivel As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tca As New SqlDataAdapter("select DISTINCT ic.cv_carrera,ic.nombre,ic.nivel from info_turnoscarrera itc inner join info_carreras as ic on itc.cve_carrera " +
                                     "COLLATE Modern_Spanish_CI_AS=ic.cv_carrera WHERE ic.nivel='" + nivel + "' AND itc.ciclo='" + ciclo + "'order by ic.nivel, ic.nombre", c)
        Dim tcat As New DataTable
        c.Open()
        tca.Fill(tcat)
        c.Close()
        tabla_carreras_actuales = tcat
    End Function

    'Shared Sub guardar(ByVal con As String, ByVal cunica As String, ByVal apodo As String, ByVal carrera As String, ByVal enterado As String,
    '                   ByVal nombres As String, ByVal paterno As String, ByVal materno As String,
    '                   ByVal sexo As String, ByVal nacionalidad As String, ByVal fdn As String,
    '                   ByVal direccion As String,
    '                   ByVal mptutor As String, ByVal civil As String, ByVal curp As String,
    '                   ByVal telefono As String, ByVal estudiosa As String, ByVal escuelap As String,
    '                   ByVal tdsangre As String, ByVal padecimientos As String)
    'Dim sc As New SqlConnection(con)
    'Dim g As New SqlCommand("INSERT INTO pingreso (ustring,fecha,apodo,carrera,enterado,nombres,paterno,materno,sexo,nacionalidad,fdn,direccion, " + _
    '                        "mptutor,civil,curp,telefono,estudiosa,escuelap,tdsangre,padecimientos) VALUES ('" + cunica + "',getdate(),'" + apodo + "','" + carrera + "'," + _
    '                        "'" + enterado + "','" + nombres + "','" + paterno + "','" + materno + "','" + sexo + "','" + nacionalidad + "','" + fdn + "','" + direccion + "'," + _
    '                        "'" + mptutor + "','" + civil + "','" + curp + "','" + telefono + "','" + estudiosa + "','" + escuelap + "','" + tdsangre + "','" + padecimientos + "'", sc)
    '    sc.Open()
    '    g.ExecuteNonQuery()
    '    sc.Close()
    'End Sub

    Shared Function ustring(ByVal ids As String) As String
        ustring = ids & Format(Now, "yyyyddMM")
    End Function

    Shared Function tabla_sexo(ByVal conn As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim ts As New SqlDataAdapter("SELECT idsexo,sexo FROM basic_sexo", c)
        Dim tst As New DataTable
        c.Open()
        ts.Fill(tst)
        c.Close()
        tabla_sexo = tst
    End Function

    Shared Function tabla_estados(ByVal conn As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim te As New SqlDataAdapter("SELECT DISTINCT d_estado, c_estado FROM basic_estados ORDER BY d_estado", c)
        Dim tet As New DataTable
        c.Open()
        te.Fill(tet)
        c.Close()
        tabla_estados = tet
    End Function

    Shared Function tabla_municipios(ByVal conn As String, ByVal c_estado As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tm As New SqlDataAdapter("SELECT DISTINCT d_mnpio, c_mnpio FROM basic_estados WHERE (c_estado = '" + c_estado + "') AND " +
                                     "(d_mnpio IS NOT NULL)ORDER BY d_mnpio", c)
        Dim tmt As New DataTable
        c.Open()
        tm.Fill(tmt)
        c.Close()
        tabla_municipios = tmt
    End Function

    Shared Function tabla_ciudades(ByVal conn As String, ByVal c_estado As String, ByVal c_mpio As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tcd As New SqlDataAdapter("SELECT DISTINCT d_asenta, id_asenta_cpcons FROM basic_estados WHERE " +
                                     "(c_estado = '" + c_estado + "') AND (c_mnpio = '" + c_mpio + "') AND (d_asenta IS NOT NULL) ORDER BY d_asenta", c)
        Dim tcdt As New DataTable
        c.Open()
        tcd.Fill(tcdt)
        c.Close()
        tabla_ciudades = tcdt
    End Function

    Shared Function tabla_turnos(ByVal conn As String, ByVal carrera As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tt As New SqlDataAdapter("SELECT id_turno,turno from info_turnoscarrera WHERE cve_carrera='" + carrera + "' and ciclo='" + pi_cicloregistro() + "' order by id_turno", c)
        Dim ttt As New DataTable
        c.Open()
        tt.Fill(ttt)
        c.Close()
        tabla_turnos = ttt
    End Function

    Shared Function tabla_edocivil(ByVal conn As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tec As New SqlDataAdapter("SELECT id_edocivil, edocivil from basic_edocivil order by id_edocivil", c)
        Dim tect As New DataTable
        c.Open()
        tec.Fill(tect)
        c.Close()
        tabla_edocivil = tect
    End Function

    Shared Function tabla_prepas_municipios(ByVal conn As String, ByVal estado As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tpm As New SqlDataAdapter("SELECT DISTINCT municipio FROM info_prepas WHERE estado='" + estado + "' ORDER BY municipio", c)
        Dim tpmt As New DataTable
        c.Open()
        tpm.Fill(tpmt)
        c.Close()
        tabla_prepas_municipios = tpmt
    End Function


    'valida CURP
    Public Shared Function validaCurp(ByVal curp As String, ByVal ciclo As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case WHEN count(*)>0 THEN '1' else '0' END as duplicado from pingreso where curp='" + curp + "' and ciclo='" + ciclo + "'", c)
        c.Open()
        validaCurp = valida.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function tabla_prepas_escuela(ByVal conn As String, ByVal municipio As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tpe As New SqlDataAdapter("SELECT DISTINCT nombre_ct FROM info_prepas WHERE municipio='" + municipio + "' ORDER BY nombre_ct", c)
        Dim tpet As New DataTable
        c.Open()
        tpe.Fill(tpet)
        c.Close()
        tabla_prepas_escuela = tpet
    End Function

    Shared Function tabla_prepa_escuela(ByVal conn As String, ByVal escuela As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tpe As New SqlDataAdapter("SELECT DISTINCT id,nombre_ct FROM info_prepas WHERE nombre_ct like '%" + escuela + "%' ORDER BY nombre_ct", c)
        Dim tpet As New DataTable
        c.Open()
        tpe.Fill(tpet)
        c.Close()
        tabla_prepa_escuela = tpet
    End Function

    Shared Sub chkchain(ByVal mvmom As MultiView, ByVal mvgnac As MultiView, ByVal mvmpio As MultiView, ByVal mvcol As MultiView, ByVal mv_pmunicipio As MultiView, ByVal mv_pescuela As MultiView, ByVal mv_padecimientos As MultiView, ByVal chain() As Integer)
        mvmom.ActiveViewIndex = chain(0)
        mvgnac.ActiveViewIndex = chain(1)
        mvmpio.ActiveViewIndex = chain(2)
        mvcol.ActiveViewIndex = chain(3)
        mv_pmunicipio.ActiveViewIndex = chain(4)
        mv_pescuela.ActiveViewIndex = chain(5)
        mv_padecimientos.ActiveViewIndex = chain(6)
    End Sub

    Shared Function tabla_sangre(ByVal cn As String) As DataTable
        Dim c As New SqlConnection(cn)
        Dim ts As New SqlDataAdapter("SELECT idtipos,tipoyfactor from basic_sangres ORDER BY idtipos", c)
        Dim tst As New DataTable
        c.Open()
        ts.Fill(tst)
        c.Close()
        tabla_sangre = tst
    End Function

    Shared Sub salvapi(carrera As String, turno As String, nombres As String, apaterno As String, amaterno As String, sexo As String, tdsangre As String, ecivil As String, fnanio As String,
                       fnmes As String, fndia As String, lnacimiento As String, direccion As String, cp As String, colonia As String, ciudad As String, estado As String, telfijo As String,
                       telmovil As String, otel As String, email As String, curp As String, peso As String, estatura As String, bachillerato As String, binganio As String, bingmes As String,
                       beganio As String, begmes As String, promedio As String, tescuela As String, tbachillerato As String, m2bachillerato As String, extraordinarios As String, certificado As String,
                       materiasgusto As String, materiasnogusto As String, especialidad As String, diabetico As String, hipertenso As String, cardiaco As String, cronico As String, psico As String,
                       hijos As String, fuerazmg As String, trabaja As String, bempleo As String, outramites As String, motivos As String, enteraste As String, cita As String, cuantosextras As String,
                       materiasextras As String, motivoextras As String, certificadoxqno As String, tipocronica As String, cronicatratamiento As String, psicotipo As String, psicotiempo As String,
                       cuantoshijos As String, hijosedades As String, domiciliofueraut As String, empresalab As String, funcionesempresa As String, horarioempresa As String, giroempresa As String,
                       rolasturno As String, horariolaboral As String, unitramite As String, uniperiodo As String, unidespues As String, uniespecialidad As String, unicarrera As String,
                       bachillerrev As String, ustring As String, cita_fecha As String, cita_hora As String, ciclo As String, nacionalidad As String, idpais As String, pais As String,
                       etnia As String, id_grupoetnico As String, grupoetnico As String, beca As String, razonbeca As String, txtrazonbeca As String, txtotrabeca As String, apoyo As String,
                       apoyos As String, txtapoyos As String, otroapoyo As String, cronicas As String, idcronicas As String, txtcronicas As String, tratamiento As String, txttratamiento As String, deporte As String,
                       iddeporte As String, txtdeporte As String, otrodeporte As String)
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Select Case cuentaustring(ustring)
            Case True
            Case Else
                Dim svp As New SqlCommand("INSERT INTO pingreso (ustring, fecha, carrera, turno, nombres, apaterno, amaterno, sexo, tdsangre, ecivil, fnac, lnacimiento, direccion, cp, colonia, ciudad, estado, telfijo, " +
                                          "telmovil, otel, email, curp, peso, estatura, bachillerato, binganio, bingmes, beganio, begmes, promedio, tescuela, tbachillerato, m2bachillerato, " +
                                          "extraordinarios, certificado, materiasgusto, materiasnogusto, especialidad, diabetico, hipertenso, cardiaco, cronico, psico, hijos, fuerazmg, trabaja, " +
                                          "bempleo, outramites, motivos, enteraste, cita, cuantosextras, materiasextras, motivoextras, certificadoxqno, tipocronica, cronicatratamiento, psicotipo, " +
                                          "psicotiempo, cuantoshijos, hijosedades, domiciliofueraut, empresalab, funcionesmepresa, horarioempresa, giroempresa, rolasturno, horariolaboral, " +
                                          "unitramite, uniperiodo, unidespues, uniespecialidad, unicarrera, bachillerrev, cita_fecha, cita_hora, ciclo,nacionalidad,id_pais,pais,etnia,id_grupoetnico, " +
                                          "grupo_etnico, becado, id_motivobeca, motivo_beca, otro_motivo, apoyo_beca, id_apoyo, apoyo, otro_apoyo, cronicas, id_cronicas, otra_cronica, id_tratamiento, tratamiento, " +
                                          "deportiva, id_deportiva, text_deportiva, otra_deportiva) " +
                                          "VALUES ('" + ustring + "',getdate(),'" + carrera + "','" + turno + "','" + nombres + "','" + apaterno + "','" + amaterno + "','" + sexo + "','" + tdsangre + "','" + ecivil + "', " +
                                          "'" + fnanio & "-" & fnmes & "-" & fndia + "','" + lnacimiento + "','" + direccion + "','" + cp + "','" + colonia + "','" + ciudad + "','" + estado + "', " +
                                          "'" + telfijo + "','" + telmovil + "','" + otel + "','" + email + "','" + curp + "','" + peso + "','" + estatura + "','" + bachillerato + "','" + binganio + "', " +
                                          "'" + bingmes + "','" + beganio + "','" + begmes + "','" + promedio + "','" + tescuela + "','" + tbachillerato + "','" + m2bachillerato + "','" + extraordinarios + "', " +
                                          "'" + certificado + "','" + materiasgusto + "','" + materiasnogusto + "','" + especialidad + "','" + diabetico + "','" + hipertenso + "','" + cardiaco + "', " +
                                          "'" + cronico + "','" + psico + "','" + hijos + "','" + fuerazmg + "','" + trabaja + "','" + bempleo + "','" + outramites + "','" + motivos + "','" + enteraste + "', " +
                                          "'" + cita + "','" + cuantosextras + "','" + materiasextras + "','" + motivoextras + "','" + certificadoxqno + "','" + tipocronica + "','" + cronicatratamiento + "', " +
                                          "'" + psicotipo + "','" + psicotiempo + "','" + cuantoshijos + "','" + hijosedades + "','" + domiciliofueraut + "','" + empresalab + "','" + funcionesempresa + "', " +
                                          "'" + horarioempresa + "','" + giroempresa + "','" + rolasturno + "','" + horariolaboral + "','" + unitramite + "','" + uniperiodo + "','" + unidespues + "', " +
                                          "'" + uniespecialidad + "','" + unicarrera + "','" + bachillerrev + "','" + cita_fecha + "','" + cita_hora + "','" + ciclo + "','" + nacionalidad + "','" + idpais + "','" + pais + "'," +
                                          "'" + etnia + "','" + id_grupoetnico + "','" + grupoetnico + "','" + beca + "','" + razonbeca + "','" + txtrazonbeca + "','" + txtotrabeca + "', " +
                                          "'" + apoyo + "','" + apoyos + "','" + txtapoyos + "','" + otroapoyo + "','" + cronicas + "','" + idcronicas + "','" + txtcronicas + "','" + tratamiento + "','" + txttratamiento + "', " +
                                          "'" + deporte + "','" + iddeporte + "','" + txtdeporte + "','" + otrodeporte + "')", cn)

                cn.Open()
                svp.ExecuteNonQuery()
                cn.Close()
        End Select
    End Sub

    Shared Function cuentaustring(ByVal ustring As String) As Boolean
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cu As New SqlCommand("SELECT CASE when count(*)>0 then '1' else '0' END as veces FROM pingreso WHERE ustring='" + ustring + "'", cn)
        cn.Open()
        cuentaustring = cu.ExecuteScalar.ToString
        cn.Close()
    End Function

    Shared Function parametros(ByVal ustring As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cu As New SqlDataAdapter("SELECT pingreso.nombres + ' ' + pingreso.paterno + ' ' + pingreso.materno AS fname,convert(varchar, pingreso.fdn, 103) as fdn, 'MÉXICO' AS pais, edos.d_estado, pingreso.direccion,mpio.d_mnpio, colo.d_asenta, " +
                                     "pingreso.email, pingreso.telefono, basic_edocivil.edocivil, pingreso.mptutor, pingreso.ptelefono, pingreso.estudiosa, " +
                                     "carrera.nombre, pingreso.ciclo, pingreso.ustring,carrera.nombre FROM pingreso inner JOIN basic_edocivil ON pingreso.civil = basic_edocivil.id_edocivil " +
                                     "INNER JOIN basic_sexo ON pingreso.sexo = basic_sexo.idsexo left JOIN (select distinct d_estado,c_estado from basic_estados) AS edos on pingreso.estado=edos.c_estado COLLATE Modern_Spanish_CI_AS " +
                                     "left outer join (SELECT distinct c_estado,d_mnpio,c_mnpio FROM basic_estados) as mpio on pingreso.municipio=mpio.c_mnpio COLLATE Modern_Spanish_CI_AS " +
                                     "AND pingreso.estado=mpio.c_estado COLLATE Modern_Spanish_CI_AS left join (SELECT distinct c_estado,c_mnpio,d_asenta,id_asenta_cpcons from basic_estados) as colo on pingreso.colonia=colo.id_asenta_cpcons COLLATE Modern_Spanish_CI_AS " +
                                     "AND pingreso.estado=colo.c_estado COLLATE Modern_Spanish_CI_AS and pingreso.municipio=colo.c_mnpio COLLATE Modern_Spanish_CI_AS " +
                                     "left join (select cv_carrera,nombre from info_carreras) as carrera on pingreso.carrera=carrera.cv_carrera " +
                                     "where ustring='" + ustring + "'", cn)
        Dim cut As New DataTable
        cn.Open()
        cu.Fill(cut)
        cn.Close()
        parametros = cut
    End Function

    Shared Function datosreportei001(ByVal ustring As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cu As New SqlDataAdapter("SELECT left(pingreso.nombres + ' ' + pingreso.apaterno + ' ' + pingreso.amaterno,34) AS fname, CONVERT(varchar, pingreso.fnac, 103) AS fdn, left(pingreso.lnacimiento,43) AS pais, " +
                                     "pingreso.estado, pingreso.direccion, pingreso.ciudad, pingreso.cp, lower(left(pingreso.email,29)) as email, pingreso.telfijo, bec.edocivil, bt.turno, " +
                                     "Left(pingreso.bachillerato, 53) + '...' AS estudiosa, LEFT(ic.nombre, 43) AS nombre, pingreso.ciclo, pingreso.ustring, bs.sexo, lower(left(pingreso.enteraste,55)) AS entersaste, " +
                                     "CONVERT(varchar, DATEPART(day,pingreso.cita_fecha)) + '/' + CONVERT(varchar, DATEPART(month, pingreso.cita_fecha)) + '/' + CONVERT(varchar, DATEPART(year, pingreso.cita_fecha)) AS cita_fecha, " +
                                     "pingreso.cita_hora, left(pingreso.nombres + ' ' + pingreso.apaterno + ' ' + pingreso.amaterno,34) AS fname2, GETDATE() AS fecha, '' AS nss, pingreso.telmovil " +
                                     "FROM pingreso INNER JOIN basic_edocivil AS bec ON pingreso.ecivil = bec.id_edocivil INNER JOIN basic_turnos AS bt ON pingreso.turno = bt.id_turno INNER JOIN " +
                                     "info_carreras AS ic ON pingreso.carrera = ic.cv_carrera COLLATE Modern_Spanish_CS_AS INNER JOIN basic_sexo AS bs ON pingreso.sexo = bs.idsexo " +
                                     "WHERE (pingreso.ustring = '" + ustring + "')", cn)
        Dim cut As New DataTable
        cn.Open()
        cu.Fill(cut)
        cn.Close()
        datosreportei001 = cut
    End Function

    Shared Function datosreportei003(ByVal ustring As String, ByVal dia_d_cita As String, ByVal fecha_examen As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cu As New SqlDataAdapter("select ciclo,ustring,info_carreras.nombre,basic_turnos.turno, " +
                                     "pingreso.apaterno + ' ' + pingreso.amaterno + ' ' + pingreso.nombres as fullname, telfijo,telmovil,email,ciclo,ustring, " +
                                     "info_carreras.nombre,basic_turnos.turno,pingreso.apaterno + ' ' + pingreso.amaterno + ' ' + pingreso.nombres as fullname, " +
                                     "telfijo,telmovil,email,'" + Format(CDate(dia_d_cita), "dddd dd MMMM yyyy") + "' as dia, pingreso.bachillerato, " +
                                     "'9:30 a 16:00 hrs' as hora,'" + Format(CDate(fecha_examen), "dddd dd MMMM yyyy") + "' as dia_examen, '8:30 hrs' as hora_examen from pingreso inner join info_carreras on " +
                                     "pingreso.carrera=info_carreras.cv_carrera COLLATE Modern_Spanish_CI_AS inner join basic_turnos on " +
                                     "pingreso.turno=basic_turnos.id_turno where ustring='" + ustring + "'", cn)
        Dim cut As New DataTable
        cn.Open()
        cu.Fill(cut)
        cn.Close()
        datosreportei003 = cut
    End Function

    Shared Function coordenadas(ByVal ndoc As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cod As New SqlDataAdapter("SELECT item, fuente, interlin, uno, dos, tres, cuatro, unoy, dosy, tresy, cuatroy " +
                                     "FROM coordenadas WHERE documento='" + ndoc + "' order by id asc", cn)
        Dim codt As New DataTable
        cn.Open()
        cod.Fill(codt)
        cn.Close()
        coordenadas = codt
    End Function

    Shared Function idsol(ByVal idciclo As String, ByVal carrera As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim pre_idsol As String = ""
        Dim okidsol As Boolean = 0
        Dim ndc As String = IIf(Right(idciclo, 1) = "A", "A", IIf(Right(idciclo, 1) = "B", "B", "C"))
        Dim idc As New SqlCommand("SELECT TOP(1) id FROM pingreso WHERE ciclo='" + idciclo + "' and carrera='" + carrera + "' ORDER BY id DESC", c)
        Dim eidc As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN '0' ELSE '1' END as cnt FROM pingreso WHERE ustring='" + pre_idsol + "'", c)
        Dim cnt As Integer = 1
        Try
            Do
                c.Open()
                pre_idsol = (idciclo.ToString.Substring(0, 5) & Left(carrera, 3) & Right("0000" & Str((CDbl(idc.ExecuteScalar.ToString) + cnt) * 1), 4)).ToString.Replace(" ", "")
                okidsol = eidc.ExecuteScalar.ToString
                c.Close()
                cnt = cnt + 1
            Loop While okidsol = 1
        Catch ex As Exception
            pre_idsol = (idciclo.ToString.Substring(0, 5) & Left(carrera, 3) & Right("0000" & Str((1) * 1), 4)).
            ToString.Replace(" ", "")
        End Try
        Return pre_idsol
    End Function

    Shared Function tabla_sedes(ByVal cn As String) As DataTable
        Dim c As New SqlConnection(cn)
        Dim ts As New SqlDataAdapter("select id_sede,sede from info_sedes order by sede", c)
        Dim tst As New DataTable
        c.Open()
        ts.Fill(tst)
        c.Close()
        tabla_sedes = tst
    End Function

    Shared Function tabla_carrerasysedes(ByVal conn As String, nivel As String, ByVal sede As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tcys As New SqlDataAdapter("select cv_carrera,nombre from info_carreras where nivel='" + nivel + "'", c)
        Dim tcyst As New DataTable
        c.Open()
        tcys.Fill(tcyst)
        c.Close()
        tabla_carrerasysedes = tcyst
    End Function

    Shared Function getemail(ByVal ustring As String) As String
        Dim v As New SqlConnection(HttpContext.Current.Application("str"))
        Dim k As New SqlCommand("SELECT pingreso.email from pingreso WHERE ustring='" + ustring + "'", v)
        v.Open()
        getemail = k.ExecuteScalar
        v.Close()
    End Function

    Shared Function senderemail(ByVal identificador As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim se As New SqlDataAdapter("SELECT correo_pi,password_pi FROM info_setupcorreos WHERE id='" + identificador + "'", c)
        Dim setb As New DataTable
        c.Open()
        se.Fill(setb)
        c.Close()
        senderemail = setb
    End Function

    Shared Sub send_mail(ByVal toemail As String, ByVal adjunto As String, ByVal emailsender As String, ByVal emailsenderp As String)
        Dim fromEmail As MailAddress = New MailAddress(emailsender, "UTJ - Sistema de Pre-registro SIAAA")
        Dim body As String = "<p style=""font-family: 'Segoe UI', Arial, Verdana; font-size: 1.4em; color: #ff3300;"">Gracias por pre-registrarte en la Universidad Tecnológica de Jalisco</p><p style=""font-family: 'Segoe UI', Arial, Verdana; font-size: 1.1em; color: #333333;"">Adjunto encontrarás tu comprobante de pre-registro, imprímelo, leelo y sigue las instrucciones para completar tu registro.</p>"
        Dim subject As String = "Envío de tu comprobante de pre-registro"

        Try
            'CORREO ENVIADO VIA GMAIL
            Dim emm As New MailMessage()
            emm.To.Add(toemail)
            emm.From = fromEmail
            emm.Subject = subject
            emm.Body = body
            emm.IsBodyHtml = True
            'emm.Attachments.Add(New Attachment(HttpContext.Current.Server.MapPath("~\docstock\cce-i001\") & "this.txt"))
            emm.Attachments.Add(New Attachment(HttpContext.Current.Server.MapPath("~\docstock\cce-i001\") & adjunto))
            Dim client As New SmtpClient("smtp.gmail.com")
            client.Credentials = New System.Net.NetworkCredential(emailsender, emailsenderp)
            client.Port = 587
            client.EnableSsl = True
            client.Send(emm)

        Catch ex As Exception
            'HttpContext.Current.Response.Write(ex.ToString)
        End Try
    End Sub

    Shared Function dias_noagenda(ByVal tarea As String, ByVal carrera As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dn As New SqlDataAdapter("SELECT distinct fecha,habilitado,css FROM info_diasno WHERE ciclo='" + ciclo + "' and cve_carrera='" + carrera + "' and tarea='" + tarea + "' order by fecha", c)
        Dim dnt As New DataTable
        c.Open()
        dn.Fill(dnt)
        c.Close()
        Return dnt
    End Function


    Shared Function horas_noagenda(ByVal dia As String, ciclo As String, ByVal carrera As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim hn As New SqlDataAdapter("SELECT DISTINCT idn.hora, pin.cita_hora FROM info_diasno AS idn LEFT OUTER JOIN pingreso AS pin " +
                                     "ON pin.cita_fecha = idn.fecha AND pin.cita_hora = idn.hora AND (pin.carrera=idn.cve_carrera) WHERE (idn.habilitado = 1) AND (idn.ciclo = '" + ciclo + "') " +
                                     "AND (idn.fecha = '" + dia + "') AND (pin.cita_hora IS NULL) AND (idn.cve_carrera = '" + carrera + "') ORDER BY idn.hora", c)
        Dim hnt As New DataTable
        c.Open()
        hn.Fill(hnt)
        c.Close()
        Return hnt
    End Function
    Shared Function horas_noagendaLoad(ByVal dia As String, ciclo As String, ByVal carrera As String, ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim hn As New SqlDataAdapter("SELECT DISTINCT idn.hora, pin.cita_hora FROM info_diasno AS idn LEFT OUTER JOIN pingreso AS pin " +
                                     "ON pin.cita_fecha = idn.fecha AND pin.cita_hora = idn.hora WHERE (idn.habilitado = 1) AND (idn.ciclo = '" + ciclo + "') " +
                                     "AND (idn.fecha = '" + dia + "') AND (pin.cita_hora IS NULL) AND (idn.cve_carrera = '" + carrera + "') OR pin.id='" + id + "' ORDER BY idn.hora", c)
        Dim hnt As New DataTable
        c.Open()
        hn.Fill(hnt)
        c.Close()
        Return hnt
    End Function

    Shared Function turno(ByVal idturno As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tu As New SqlCommand("SELECT turno from basic_turnos where id_turno='" + idturno + "'", c)
        c.Open()
        turno = tu.ExecuteScalar()
        c.Close()
    End Function

    Shared Function muestra_lugares(ByVal cadena As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ml As New SqlDataAdapter("SELECT id, d_asenta + ', ' + d_codigo + ', ' + d_mnpio + ', ' + d_estado + '.' AS fullpoblacion FROM basic_estados " +
                                     "WHERE (d_asenta + d_mnpio + d_codigo + d_ciudad LIKE '%" + cadena + "%') ORDER BY d_asenta", c)
        Dim mlt As New DataTable
        c.Open()
        ml.Fill(mlt)
        c.Close()
        muestra_lugares = mlt
    End Function

    Shared Function muestra_ciudades(ByVal cadena As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mc As New SqlDataAdapter("SELECT DISTINCT d_mnpio + ', ' + d_estado + '.' AS fullpoblacion FROM basic_estados WHERE " +
                                     "(d_mnpio + d_codigo + d_ciudad LIKE '%" + cadena + "%') ORDER BY d_mnpio + ', ' + d_estado + '.'", c)
        Dim mlt As New DataTable
        c.Open()
        mc.Fill(mlt)
        c.Close()
        muestra_ciudades = mlt
    End Function

    Shared Function dame_lugar(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ml As New SqlCommand("SELECT d_asenta + ', ' + d_codigo + ', ' + d_mnpio + ', ' + d_estado + '.' AS fullpoblacion FROM basic_estados " +
                                     "WHERE (id='" + id + "')", c)
        c.Open()
        dame_lugar = ml.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function colonia_ciudad_estado(ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cce As New SqlDataAdapter("SELECT d_asenta, d_ciudad, d_estado FROM basic_estados WHERE (id='" + id + "')", c)
        Dim ccet As New DataTable
        c.Open()
        cce.Fill(ccet)
        c.Close()
        colonia_ciudad_estado = ccet
    End Function

    Shared Function fullescuelas(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim fes As New SqlCommand("SELECT DISTINCT nombre_ct + ', ' + municipio + ', ' + estado as fullescuelas FROM info_prepas WHERE id='" + id + "'", c)
        c.Open()
        fullescuelas = fes.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function nombremes(ByVal numeromes As String) As String
        Select Case numeromes
            Case 1
                nombremes = "enero"
            Case 2
                nombremes = "febrero"
            Case 3
                nombremes = "marzo"
            Case 4
                nombremes = "abril"
            Case 5
                nombremes = "mayo"
            Case 6
                nombremes = "junio"
            Case 7
                nombremes = "julio"
            Case 8
                nombremes = "agosto"
            Case 9
                nombremes = "septiembre"
            Case 10
                nombremes = "octubre"
            Case 11
                nombremes = "noviembre"
            Case Else
                nombremes = "diciembre"
        End Select
    End Function

    Shared Function tabla_escuelas() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim te As New SqlDataAdapter("SELECT id, escuela FROM info_universidades ORDER BY escuela", c)
        Dim tet As New DataTable
        c.Open()
        te.Fill(tet)
        c.Close()
        tabla_escuelas = tet
    End Function

    Shared Function tabla_resultados_busqueda(ByVal abuscar As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim trb As New SqlDataAdapter("select apaterno + ' ' + amaterno + ' ' + nombres + ' - ' + ustring + ' (' + convert(varchar,fecha,113) + ')' as item,id,ustring from pingreso " +
                                      "where UPPER(ustring + ' ' + apaterno + ' ' + amaterno + ' ' + nombres) like UPPER('%" + abuscar + "%') and ciclo='" + ciclo + "' order by apaterno, amaterno, nombres", c)
        Dim trbt As New DataTable
        c.Open()
        trb.Fill(trbt)
        c.Close()
        Return trbt
    End Function

    Shared Function tabla_consulta_llenado(ByVal id As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tcl As New SqlDataAdapter("SELECT pingreso.id, pingreso.ustring, fecha, carrera, turno, nombres, apaterno, amaterno, sexo, tdsangre, ecivil, " +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar, DATEPART(year, fnac)), 4) AS anio, " +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar, DATEPART(month, fnac)), 2) AS mes, " +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar, DATEPART(day, fnac)), 2) AS dia, lnacimiento, direccion, cp, " +
                                      "colonia, ciudad, estado, telfijo, telmovil, otel, email, curp, peso, estatura, bachillerato, binganio," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,bingmes), 2) bingmes, beganio," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,begmes), 2) begmes, " +
                                      "promedio,RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,tescuela), 2) tescuela," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,tbachillerato), 2) tbachillerato, " +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,m2bachillerato), 2) m2bachillerato, extraordinarios, certificado, materiasgusto, materiasnogusto," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,especialidad), 2) especialidad, " +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,diabetico), 2) diabetico," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,hipertenso), 2) hipertenso," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,cardiaco), 2) cardiaco, cronico, psico," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,hijos), 2) hijos," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,fuerazmg), 2) fuerazmg," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,trabaja), 2) trabaja," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,bempleo), 2) bempleo," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,outramites), 2) outramites, motivos, enteraste, cita," +
                                      "cuantosextras, materiasextras, motivoextras, certificadoxqno, tipocronica," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,cronicatratamiento), 2) cronicatratamiento, psicotipo," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,psicotiempo), 2) psicotiempo, RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,cuantoshijos), 2) cuantoshijos, " +
                                      "hijosedades,RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,domiciliofueraut), 2) domiciliofueraut, empresalab, funcionesmepresa, horarioempresa, giroempresa," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,rolasturno), 2) rolasturno,RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,horariolaboral), 2) horariolaboral, " +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,unitramite), 1) unitramite, " +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,uniperiodo), 2) uniperiodo," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,unidespues), 2) unidespues," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,uniespecialidad), 2) uniespecialidad," +
                                      "unicarrera, RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,bachillerrev), 2) bachillerrev, cita_fecha, cita_hora, entrevista_foto, documentos, con_examen, " +
                                      "curso_induccion, dictaminados, pingreso.ciclo, ISNULL(ui.imagepath,'..\docstock\usrdocs\images\defaultimg.jpg') as imagepath, " +
                                      "CASE WHEN pc.folio='' THEN 'NO CAPTURADO' ELSE ISNULL(pc.folio,'Escriba uno nuevo') END as folio,pingreso.ciclo," +
                                      "CASE WHEN pd.citadia IS NULL THEN '0' else '1' end existecita,pd.citadia, nacionalidad,id_pais,etnia,id_grupoetnico, becado,id_motivobeca,otro_motivo," +
                                      "apoyo_beca,id_apoyo,otro_apoyo,cronicas,id_cronicas,otra_cronica,id_tratamiento, tratamiento," +
                                      "RIGHT(CONVERT(varchar, '0000') + CONVERT(varchar,deportiva), 2) deportiva,id_deportiva,otra_deportiva " +
                                      "FROM pingreso " +
                                      "LEFT JOIN user_images as ui ON pingreso.ustring=ui.userid " +
                                      "LEFT JOIN pingreso_ceneval as pc ON pingreso.ustring=pc.ustring " +
                                      "LEFT JOIN pingreso_citadocumentos as pd ON pingreso.ustring=pd.ustring " +
                                      "where pingreso.id='" + id + "' and pingreso.ciclo='" + ciclo + "'", c)
        'LA FOTO ES LA 85
        Dim tclt As New DataTable
        c.Open()
        tcl.Fill(tclt)
        c.Close()
        Return tclt
    End Function

    'FUNCION PARA ACTUALIZAR LA TABLA PINGRESO

    Public Shared Sub actualizaPingreso(ByVal folio As String, ByVal carrera As String, ByVal turno As String, ByVal nombres As String, ByVal apaterno As String, ByVal amaterno As String, ByVal sexo As String, ByVal tdsangre As String, ByVal ecivil As String, ByVal fnanio As String,
                       ByVal fnmes As String, ByVal fndia As String, ByVal lnacimiento As String, ByVal direccion As String, ByVal cp As String, ByVal colonia As String, ByVal ciudad As String, ByVal estado As String, ByVal telfijo As String,
                       ByVal telmovil As String, ByVal otel As String, ByVal email As String, ByVal curp As String, ByVal peso As String, ByVal estatura As String, ByVal bachillerato As String, ByVal binganio As String, ByVal bingmes As String,
                       ByVal beganio As String, ByVal begmes As String, ByVal promedio As String, ByVal tescuela As String, ByVal tbachillerato As String, ByVal m2bachillerato As String, ByVal extraordinarios As String, ByVal certificado As String,
                       ByVal materiasgusto As String, ByVal materiasnogusto As String, ByVal especialidad As String, ByVal diabetico As String, ByVal hipertenso As String, ByVal cardiaco As String, ByVal cronico As String, ByVal psico As String,
                       ByVal hijos As String, ByVal fuerazmg As String, ByVal trabaja As String, ByVal bempleo As String, ByVal outramites As String, ByVal motivos As String, ByVal enteraste As String, ByVal cita As String, ByVal cuantosextras As String,
                       ByVal materiasextras As String, ByVal motivoextras As String, ByVal certificadoxqno As String, ByVal tipocronica As String, ByVal cronicatratamiento As String, ByVal psicotipo As String, ByVal psicotiempo As String,
                       ByVal cuantoshijos As String, ByVal hijosedades As String, ByVal domiciliofueraut As String, ByVal empresalab As String, ByVal funcionesempresa As String, ByVal horarioempresa As String, ByVal giroempresa As String,
                       ByVal rolasturno As String, ByVal horariolaboral As String, ByVal unitramite As String, ByVal uniperiodo As String, ByVal unidespues As String, ByVal uniespecialidad As String, ByVal unicarrera As String,
                       ByVal bachillerrev As String, ByVal ustring As String, ByVal cita_fecha As String, ByVal cita_hora As String, ByVal ciclo As String, ByVal id As String, nacionalidad As String, idpais As String, pais As String,
                       etnia As String, id_grupoetnico As String, grupoetnico As String, beca As String, razonbeca As String, txtrazonbeca As String, txtotrabeca As String, apoyo As String,
                       apoyos As String, txtapoyos As String, otroapoyo As String, cronicas As String, idcronicas As String, txtcronicas As String, tratamiento As String, txttratamiento As String, deporte As String,
                       iddeporte As String, txtdeporte As String, otrodeporte As String)


        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlCommand("UPDATE pingreso set ustring='" + folio + "' , carrera='" + carrera + "', turno='" + turno + "', nombres='" + nombres + "', apaterno='" + apaterno + "', amaterno='" + amaterno + "', sexo='" + sexo + "', tdsangre='" + tdsangre + "', ecivil='" + ecivil + "', fnac='" + fnanio & "-" & fnmes & "-" & fndia + "'," +
                                        "lnacimiento='" + lnacimiento + "', direccion='" + direccion + "', cp='" + cp + "', colonia='" + colonia + "', ciudad='" + ciudad + "', estado='" + estado + "', telfijo='" + telfijo + "', " +
                                          "telmovil='" + telmovil + "', otel='" + otel + "', email='" + email + "', curp='" + curp + "', peso='" + peso + "', estatura='" + estatura + "', bachillerato='" + bachillerato + "', binganio='" + binganio + "'," +
                                          "bingmes='" + bingmes + "', beganio='" + beganio + "', begmes='" + begmes + "', promedio='" + promedio + "', tescuela='" + tescuela + "', tbachillerato='" + tbachillerato + "', m2bachillerato='" + m2bachillerato + "', " +
                                          "extraordinarios='" + extraordinarios + "', certificado='" + certificado + "', materiasgusto='" + materiasgusto + "', materiasnogusto='" + materiasnogusto + "', especialidad='" + especialidad + "', diabetico='" + diabetico + "'," +
                                          "hipertenso='" + hipertenso + "', cardiaco='" + cardiaco + "', cronico='" + cronico + "', psico='" + psico + "', hijos='" + hijos + "', fuerazmg='" + fuerazmg + "', trabaja='" + trabaja + "', " +
                                          "bempleo='" + bempleo + "', outramites='" + outramites + "', motivos='" + motivos + "', enteraste='" + enteraste + "', cita='" + cita + "', cuantosextras='" + cuantosextras + "', materiasextras='" + materiasextras + "', motivoextras='" + motivoextras + "'," +
                                          "certificadoxqno='" + certificadoxqno + "', tipocronica='" + tipocronica + "', cronicatratamiento='" + cronicatratamiento + "', psicotipo='" + psicotipo + "', " +
                                          "psicotiempo='" + psicotiempo + "', cuantoshijos='" + cuantoshijos + "', hijosedades='" + hijosedades + "', domiciliofueraut='" + domiciliofueraut + "', empresalab='" + empresalab + "'," +
                                          "funcionesmepresa='" + funcionesempresa + "', horarioempresa='" + horarioempresa + "', giroempresa='" + giroempresa + "', rolasturno='" + rolasturno + "', horariolaboral='" + horariolaboral + "', " +
                                          "unitramite='" + unitramite + "', uniperiodo='" + uniperiodo + "', unidespues='" + unidespues + "', uniespecialidad='" + uniespecialidad + "', unicarrera='" + unicarrera + "', bachillerrev='" + bachillerrev + "', cita_fecha='" + cita_fecha + "', cita_hora='" + cita_hora + "', ciclo='" + ciclo + "', " +
                                          "nacionalidad='" + nacionalidad + "', id_pais='" + idpais + "', pais='" + pais + "',etnia='" + etnia + "', id_grupoetnico='" + id_grupoetnico + "',grupo_etnico='" + grupoetnico + "',becado='" + beca + "', id_motivobeca='" + razonbeca + "', motivo_beca='" + txtrazonbeca + "', " +
                                          "otro_motivo='" + txtotrabeca + "', apoyo_beca='" + apoyo + "',id_apoyo='" + apoyos + "', apoyo='" + txtapoyos + "',otro_apoyo='" + otroapoyo + "', cronicas='" + cronicas + "',id_cronicas ='" + idcronicas + "',otra_cronica='" + txtcronicas + "', " +
                                          "id_tratamiento='" + tratamiento + "',tratamiento='" + txttratamiento + "',deportiva='" + deporte + "',id_deportiva='" + iddeporte + "',text_deportiva='" + txtdeporte + "', otra_deportiva='" + otrodeporte + "'" +
                                          " WHERE id='" + id + "'", c)
        c.Open()
        actualiza.ExecuteNonQuery()
        c.Close()

    End Sub

    'eliminar registro

    Shared Sub eliminaRegistro(ByVal id As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dp As New SqlCommand("DELETE FROM pingreso  WHERE id='" + id + "'", c)
        c.Open()
        dp.ExecuteNonQuery()
        c.Close()
    End Sub


    Public Shared Sub actualiza_foto(ByVal userid As String, ByVal path As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim af As New SqlCommand("SELECT CASE WHEN count(*)>0 then '1' else '0' END existe FROM user_images WHERE userid='" + userid + "'", c)
        Dim existe As Boolean = False
        c.Open()
        existe = af.ExecuteScalar.ToString
        c.Close()
        If existe = True Then
            Dim afoto As New SqlCommand("UPDATE user_images SET imagepath='" + path + "', imageminipath='" + path.Replace("images", "minimages") + "' WHERE userid='" + userid + "'", c)
            c.Open()
            afoto.ExecuteNonQuery()
            c.Close()
        Else
            Dim ifoto As New SqlCommand("INSERT INTO user_images (imagepath, userid) VALUES ('" + path + "','" + userid + "')", c)
            c.Open()
            ifoto.ExecuteNonQuery()
            c.Close()
        End If
    End Sub

    Public Shared Function tabla_documentos(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tdoc As New SqlDataAdapter("select ud.id,ind.documento,entregado,ud.comentario from pingreso_documentos as ud left join info_documentos as ind on ud.iddoc=ind.iddoc " +
                                      "where ud.registro='" + ustring + "' order by ind.id", c)
        Dim tdoct As New DataTable
        c.Open()
        tdoc.Fill(tdoct)
        c.Close()
        Return tdoct
    End Function

    Shared Function ustring_pingreso(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim up As New SqlCommand("SELECT ustring FROM pingreso where id='" + id + "'", c)
        c.Open()
        ustring_pingreso = up.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Sub guardardocumentos(ByVal id As String, ByVal entregado As String, ByVal comentario As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gd As New SqlCommand("update pingreso_documentos set entregado='" + entregado + "', comentario='" + comentario + "', udate=getdate() where id='" + id + "'", c)
        c.Open()
        gd.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub nuevos_docs(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim xst As Boolean = False
        Dim xct As Boolean = False
        Dim boolnd As New SqlCommand("select case when count(*)>0 then '1' else '0' end existe from pingreso_documentos where registro='" + ustring + "'", c)
        Dim boolce As New SqlCommand("select case when count(*)>0 then '1' else '0' end existe from pingreso_ceneval where ustring='" + ustring + "'", c)
        c.Open()
        xst = boolnd.ExecuteScalar.ToString
        xct = boolce.ExecuteScalar.ToString
        c.Close()
        Select Case xst
            Case False
                Dim idocs As New SqlCommand("insert into pingreso_documentos (iddoc,entregado,registro) select iddoc,'0' as entregado, '" + ustring + "' as registro from info_documentos", c)
                c.Open()
                idocs.ExecuteNonQuery()
                c.Close()
        End Select
        Select Case xct
            Case False
                Dim idcen As New SqlCommand("insert into pingreso_ceneval (ustring) VALUES('" + ustring + "')", c)
                c.Open()
                idcen.ExecuteNonQuery()
                c.Close()
        End Select
    End Sub

    '--------------funciones para entrevista de primer ingreso-----------

    'inserta todos los campos en la tabla pingreso_entrevista y pingreso_observaciones_entrevista
    Shared Sub insertaEntrevista(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim xst As Boolean = False
        Dim xct As Boolean = False
        Dim boolseleccionado As New SqlCommand("Select case when count(*)>0 then '1' else '0' end existe from pingreso_entrevista where ustring='" + ustring + "' and id_categoria='1'", c)
        Dim boolobservaciones As New SqlCommand("Select case when count(*)>0 then '1' else '0' end existe from pingreso_observaciones_entrevista where ustring='" + ustring + "'", c)
        c.Open()
        xst = boolseleccionado.ExecuteScalar.ToString
        xct = boolobservaciones.ExecuteScalar.ToString
        c.Close()
        Select Case xst
            Case False
                Dim seleccionados As New SqlCommand("insert into pingreso_entrevista(id_pregunta,id_categoria,seleccionado,ustring) select id_pregunta, id_categoria, '0' as seleccionado,'" + ustring + "' as ustring from basic_pi_entrevista", c)
                c.Open()
                seleccionados.ExecuteNonQuery()
                c.Close()
        End Select
        Select Case xct
            Case False
                Dim idcen As New SqlCommand("insert into pingreso_observaciones_entrevista (ustring) VALUES('" + ustring + "')", c)
                c.Open()
                idcen.ExecuteNonQuery()
                c.Close()
        End Select
    End Sub
    '---categoria 1------
    'llena grid
    Public Shared Function muestraCat1(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cat1 As New SqlDataAdapter("select ud.id, bent.descripcion,ud.seleccionado from pingreso_entrevista as ud LEFT JOIN " +
                                        "basic_pi_entrevista as bent on ud.id_pregunta=bent.id_pregunta " +
                                        "where ud.ustring='" + ustring + "' and bent.id_categoria='1'", c)
        Dim cat1t As New DataTable
        c.Open()
        cat1.Fill(cat1t)
        c.Close()
        Return cat1t
    End Function


    '---categoria 2------
    'llena grid
    Public Shared Function muestraCat2(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cat1 As New SqlDataAdapter("select ud.id, bent.descripcion,ud.seleccionado from pingreso_entrevista as ud LEFT JOIN " +
                                        "basic_pi_entrevista as bent on ud.id_pregunta=bent.id_pregunta " +
                                        "where ud.ustring='" + ustring + "' and bent.id_categoria='2'", c)
        Dim cat1t As New DataTable
        c.Open()
        cat1.Fill(cat1t)
        c.Close()
        Return cat1t
    End Function

    '---categoria 3------
    'llena grid
    Public Shared Function muestraCat3(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cat1 As New SqlDataAdapter("select ud.id, bent.descripcion,ud.seleccionado from pingreso_entrevista as ud LEFT JOIN " +
                                        "basic_pi_entrevista as bent on ud.id_pregunta=bent.id_pregunta " +
                                        "where ud.ustring='" + ustring + "' and bent.id_categoria='3'", c)
        Dim cat1t As New DataTable
        c.Open()
        cat1.Fill(cat1t)
        c.Close()
        Return cat1t
    End Function

    'Muestra observaciones y entrevistador


    Public Shared Function muestraObservaciones(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cat1 As New SqlDataAdapter("select observaciones, entrevistador from pingreso_observaciones_entrevista where ustring='" + ustring + "'", c)
        Dim cat1t As New DataTable
        c.Open()
        cat1.Fill(cat1t)
        c.Close()
        Return cat1t
    End Function

    ''Actualiza datos
    Shared Sub upEntrevista(ByVal id As String, ByVal seleccionado As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gd As New SqlCommand("update pingreso_entrevista set seleccionado='" + seleccionado + "', udate=getdate() where id='" + id + "'", c)
        c.Open()
        gd.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub upObservaciones(ByVal observaciones As String, ByVal entrevistador As String, ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gd As New SqlCommand("update pingreso_observaciones_entrevista set observaciones='" + observaciones + "', entrevistador='" + entrevistador + "' , udate=getdate() where ustring='" + ustring + "'", c)
        c.Open()
        gd.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub upPingresoEntrevista(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim entrevista As New SqlCommand("update pingreso set entrevista_foto='1', entrevista_carrera='1' where ustring='" + ustring + "'", c)
        c.Open()
        entrevista.ExecuteNonQuery()
        c.Close()
    End Sub

    'Revisa al entrevistador
    Shared Function entrevistador(ByVal ustring As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cuf As New SqlCommand("select entrevistador from pingreso_observaciones_entrevista where ustring='" + ustring + "'", c)
        c.Open()
        entrevistador = cuf.ExecuteScalar.ToString()
        c.Close()
    End Function

    '---------------------------------------------------------------------------------------

    Shared Sub guardar_ceneval(ByVal ustring As String, ByVal cenevaltext As String, ByVal ciclo As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gc As New SqlCommand("update pingreso_ceneval set folio='" + cenevaltext + "', captura=getdate(), udate=getdate(), ciclo='" + ciclo + "' where ustring='" + ustring + "'", c)
        c.Open()
        gc.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function datosreportei004(ByVal ustring As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dt004 As New SqlDataAdapter("SET LANGUAGE Español select pi.ustring as folioderegistro, " +
                                     "pi.ciclo + ' (' + convert(varchar,bpi.startdate,106) + ' al ' + convert(varchar,bpi.enddate,106) + ')' as periodo, " +
                                     "pi.apaterno + ' ' + pi.amaterno + ' ' + pi.nombres as nombre_completo,ic.nombre as carrera,UPPER(bt.turno) as turno, convert(varchar,getdate(),106) as fecha, " +
                                     "pi.apaterno + ' ' + pi.amaterno + ' ' + pi.nombres as nc2 from pingreso as pi inner join basic_pi_ciclos as bpi on pi.ciclo=bpi.ciclo " +
                                     "inner join info_carreras as ic on ic.cv_carrera Collate Modern_Spanish_CS_AS=pi.carrera " +
                                     "inner join basic_turnos as bt on bt.id_turno=pi.turno where ustring='" + ustring + "'", cn)
        Dim dt004t As New DataTable
        cn.Open()
        dt004.Fill(dt004t)
        cn.Close()
        datosreportei004 = dt004t
    End Function

    Shared Function datosreportei005(ByVal ustring As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dt004 As New SqlDataAdapter("SET LANGUAGE Español select " +
                                     "pi.ciclo + ' (' + convert(varchar,bpi.startdate,106) + ' al ' + convert(varchar,bpi.enddate,106) + ')' as periodo, " +
                                     "pi.apaterno + ' ' + pi.amaterno + ' ' + pi.nombres as nombre_completo,ic.nombre as carrera,UPPER(bt.turno) as turno, convert(varchar,getdate(),106) as fecha, " +
                                     "pi.apaterno + ' ' + pi.amaterno + ' ' + pi.nombres as nc2 from pingreso as pi inner join basic_pi_ciclos as bpi on pi.ciclo=bpi.ciclo " +
                                     "inner join info_carreras as ic on ic.cv_carrera Collate Modern_Spanish_CS_AS=pi.carrera " +
                                     "inner join basic_turnos as bt on bt.id_turno=pi.turno where ustring='" + ustring + "'", cn)
        Dim dt005t As New DataTable
        cn.Open()
        dt004.Fill(dt005t)
        cn.Close()
        datosreportei005 = dt005t
    End Function

    Shared Function datosreportei006(ByVal ustring As String) As DataTable
        Dim cn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dt006 As New SqlDataAdapter("SET LANGUAGE Español select " +
                                     "pi.ciclo + ' (' + convert(varchar,bpi.startdate,106) + ' al ' + convert(varchar,bpi.enddate,106) + ')' as periodo, " +
                                     "pi.apaterno + ' ' + pi.amaterno + ' ' + pi.nombres as nombre_completo,ic.nombre as carrera,UPPER(bt.turno) as turno, convert(varchar,getdate(),106) as fecha, " +
                                     "pi.apaterno + ' ' + pi.amaterno + ' ' + pi.nombres as nc2 from pingreso as pi inner join basic_pi_ciclos as bpi on pi.ciclo=bpi.ciclo " +
                                     "inner join info_carreras as ic on ic.cv_carrera Collate Modern_Spanish_CS_AS=pi.carrera " +
                                     "inner join basic_turnos as bt on bt.id_turno=pi.turno where ustring='" + ustring + "'", cn)
        Dim dt006t As New DataTable
        cn.Open()
        dt006.Fill(dt006t)
        cn.Close()
        datosreportei006 = dt006t
    End Function


    Shared Sub update_pingreso(ByVal id As String, ByVal bachillerato As String, ByVal aingreso As String, ByVal mingreso As String, ByVal aegreso As String, ByVal megreso As String, ByVal promedio As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim upi As New SqlCommand("update pingreso set bachillerato='" + bachillerato + "', binganio='" + aingreso + "', bingmes='" + mingreso + "', beganio='" + aegreso + "', begmes='" + megreso + "', " +
                                  "promedio='" + promedio + "' where id='" + id + "'", c)
        c.Open()
        upi.ExecuteNonQuery()
        c.Close()
    End Sub

    'Codigo para activar documentos y examen en pingreso(documents.aspx)
    Shared Sub actualizaPingreso(ByVal id As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim upi As New SqlCommand("update pingreso set documentos='1', con_examen='1', entrevista_foto='1' where id='" + id + "'", c)
        c.Open()
        upi.ExecuteNonQuery()
        c.Close()
    End Sub


    Shared Function existe_citadocs(ByVal ustring As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim exc As New SqlCommand("select case when count(*)>0 then '1' else '0' end from pingreso_citadocumentos where ustring='" + ustring + "'", c)
        c.Open()
        existe_citadocs = exc.ExecuteScalar.ToString()
        c.Close()
    End Function

    Shared Function cupoendia(ByVal dia As String, ByVal docsxdia As String, ByVal ciclo As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cnd As New SqlCommand("select case when count(*)<=" + docsxdia + " then '1' else '0' end from pingreso_citadocumentos where citadia='" + dia + "' and ciclo='" + ciclo + "'", c)
        c.Open()
        cupoendia = cnd.ExecuteScalar.ToString()
        c.Close()
    End Function

    Shared Function docsxdia(ByVal ciclo As String) As Integer
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        'Dim dxd As New SqlCommand("C'" + ciclo + "'", c)
        Dim dxd As New SqlCommand("select docsxdia from basic_pi_ciclos where ciclo='" + ciclo + "'", c)
        c.Open()
        docsxdia = dxd.ExecuteScalar.ToString()
        c.Close()
    End Function

    Shared Sub updt_docsxdia(ByVal ciclo As String, ByVal docsxdia As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim newdocsxdia As String = (CInt(docsxdia) + 1).ToString
        Dim dxd As New SqlCommand("update basic_pi_ciclos set docsxdia='" + newdocsxdia + "' where ciclo='" + ciclo + "'", c)
        c.Open()
        docsxdia = dxd.ExecuteScalar.ToString()
        c.Close()
    End Sub

    Shared Function dia_de_cita(ByVal ciclo As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ddc As New SqlDataAdapter("select fecha from info_diasno where ciclo='" + ciclo + "' and tarea='CITA_DOCUMENTOS_CONTROL_ESCOLAR' order by id", c)
        Dim ddct As New DataTable
        c.Open()
        ddc.Fill(ddct)
        c.Close()
        If ddct.Rows.Count > 0 Then
            Dim z As Integer
            For z = 0 To ddct.Rows.Count - 1
                Dim fecha As String = Format(ddct.Rows(z).Item(0), "yyyy-MM-dd")
                If cupoendia(fecha, docsxdia(ciclo), ciclo) = True Then
                    Return fecha
                    Exit For
                End If
            Next
            updt_docsxdia(ciclo, docsxdia(ciclo))
            dia_de_cita(ciclo)
        End If
    End Function

    Shared Sub ins_docsxdia(ByVal ciclo As String, ByVal dia As String, ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim idxd As New SqlCommand("INSERT INTO pingreso_citadocumentos (ustring, citadia,ciclo) VALUES ('" + ustring + "','" + dia + "','" + ciclo + "')", c)
        c.Open()
        idxd.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub del_citadocumentos(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dct As New SqlCommand("DELETE FROM pingreso_citadocumentos WHERE ustring='" + ustring + "'", c)
        c.Open()
        dct.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub llena_info_dias_no(ByVal fecha_inicio As String, ByVal fecha_final As String, ByVal ciclo As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim startdate As Date = Format(CDate(fecha_inicio), "dd/MM/yyyy")
        Dim enddate As Date = Format(CDate(fecha_final), "dd/MM/yyyy")
        Dim nextdate As Date = startdate
        Do While nextdate <= enddate
            If nextdate.DayOfWeek <> DayOfWeek.Saturday And nextdate.DayOfWeek <> DayOfWeek.Sunday Then
                Dim llidn As New SqlCommand("INSERT INTO info_diasno (ciclo,mes,dia,fecha,hora,habilitado,tarea,css,cve_carrera) " +
                                        "VALUES ('" + ciclo + "','" + nextdate.Month.ToString + "','" + nextdate.Day.ToString + "','" + Format(nextdate, "yyyy-MM-dd") + "', " +
                                        "'00:00','1','CITA_DOCUMENTOS_CONTROL_ESCOLAR','dia_normal','NA')", c)
                c.Open()
                llidn.ExecuteNonQuery()
                c.Close()
            End If
            nextdate = nextdate.AddDays(1)
        Loop
    End Sub

    Shared Sub borra_llena_info_dias_no(ByVal ciclo As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim bllidn As New SqlCommand("delete from info_diasno where ciclo='" + ciclo + "' and tarea='CITA_DOCUMENTOS_CONTROL_ESCOLAR'", c)
        c.Open()
        bllidn.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function fecha_d_examen(ByVal ciclo As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim fde As New SqlCommand("select fecha_examen from basic_pi_ciclos where ciclo='" + ciclo + "'", c)
        c.Open()
        fecha_d_examen = fde.ExecuteScalar.ToString()
        c.Close()
    End Function

    Shared Sub desactiva_ciclos()
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dc As New SqlCommand("update general_ciclos set active=0", c)
        Dim dc0 As New SqlCommand("update basic_pi_ciclos set active=0", c)
        c.Open()
        dc.ExecuteNonQuery()
        dc0.ExecuteNonQuery()
        c.Close()
    End Sub


    'Llena ddl_paises
    Shared Function llenaPais() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tc As New SqlDataAdapter("Select id, pais from basic_paises order by pais asc", c)
        Dim tct As New DataTable
        c.Open()
        tc.Fill(tct)
        c.Close()
        llenaPais = tct
    End Function

    'Llena ddl_etnias
    Shared Function llenaEtnia() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tc As New SqlDataAdapter("SELECT id,grupo FROM dbo.basic_etnias ORDER BY grupo ASC", c)
        Dim tct As New DataTable
        c.Open()
        tc.Fill(tct)
        c.Close()
        llenaEtnia = tct
    End Function

    'Llena ddl_cronicas
    Shared Function llenaCronica() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tc As New SqlDataAdapter("SELECT id,tipo FROM dbo.basic_cronicas ORDER BY tipo ASC", c)
        Dim tct As New DataTable
        c.Open()
        tc.Fill(tct)
        c.Close()
        llenaCronica = tct
    End Function

    'Llena ddl_beca
    Shared Function llenaBecaBachi() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tc As New SqlDataAdapter("SELECT id,motivo FROM dbo.basic_beca_bachillerato", c)
        Dim tct As New DataTable
        c.Open()
        tc.Fill(tct)
        c.Close()
        llenaBecaBachi = tct
    End Function

    'Llena ddl_beca
    Shared Function llenaApoyoBecaPi() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tc As New SqlDataAdapter("SELECT id,motivo FROM dbo.basic_apoyo_beca_pi", c)
        Dim tct As New DataTable
        c.Open()
        tc.Fill(tct)
        c.Close()
        llenaApoyoBecaPi = tct
    End Function

    'Llena ddl_deporte
    Shared Function llenaTalleres() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tc As New SqlDataAdapter("SELECT id,taller FROM dbo.basic_talleres", c)
        Dim tct As New DataTable
        c.Open()
        tc.Fill(tct)
        c.Close()
        llenaTalleres = tct
    End Function


    'llena grid razones de inscripcion
    Public Shared Function muestraRazones() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim motivos As New SqlDataAdapter("Select id, descripcion from basic_motivo_inscripcion", c)
        Dim motivost As New DataTable
        c.Open()
        motivos.Fill(motivost)
        c.Close()
        Return motivost
    End Function

    'llena el grid de razones por ustring   
    Public Shared Function muestraRazonesUstring(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim motivos As New SqlDataAdapter("SELECT id_motivo_inscripcion,descripcion, CASE WHEN ISNULL(pr.id_razon, 0)=0 THEN 0 ELSE 1 END seleccionado from basic_motivo_inscripcion as bm " +
                                            "LEFT JOIN (select id_razon from pingreso_razones where ustring='" + ustring + "') as pr on bm.id_motivo_inscripcion = pr.id_razon", c)
        Dim motivost As New DataTable
        c.Open()
        motivos.Fill(motivost)
        c.Close()
        Return motivost
    End Function

    'elimina el grid razones para volverlo a llenar
    Public Shared Sub eliminaRazonesUstring(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim motivos As New SqlCommand("delete from pingreso_razones where ustring='" + ustring + "'", c)
        c.Open()
        motivos.ExecuteNonQuery()
        c.Close()
    End Sub

    'llena grid  de medios
    Public Shared Function muestraMedios() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim medios As New SqlDataAdapter("Select id_medio, medio from basic_medios", c)
        Dim mediost As New DataTable
        c.Open()
        medios.Fill(mediost)
        c.Close()
        Return mediost
    End Function

    'llena grid medios segun el ustring
    Public Shared Function muestraMediosUstring(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim medios As New SqlDataAdapter("select id_medio,medio,CASE WHEN ISNULL(pm.id_razon,0)=0 THEN 0 ELSE 1 END seleccionado from basic_medios as bm " +
                                          "left join (select id_razon from pingreso_medios where ustring='" + ustring + "') as pm on bm.id_medio=pm.id_razon ", c)
        Dim mediost As New DataTable
        c.Open()
        medios.Fill(mediost)
        c.Close()
        Return mediost
    End Function



    'elimina el grid medios para volverlo a llenar
    Public Shared Sub eliminaMediosUstring(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim motivos As New SqlCommand("delete from pingreso_medios where ustring='" + ustring + "'", c)
        c.Open()
        motivos.ExecuteNonQuery()
        c.Close()
    End Sub

    'VERSIONES


    Shared Function versiones() As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim version As New SqlCommand("select version from versiones where activa='1'", c)
        c.Open()
        versiones = version.ExecuteScalar.ToString()
        c.Close()
    End Function

    'Shared Sub salvaseleccionados(ByVal id_catalog As String, ByVal idd As String, ByVal tabla As String)
    '    Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '    Dim savesel As New SqlCommand("insert into " + tabla + " (id_razon,ustring,seleccionado) VALUES('" + id_catalog + "','" + idd + "','1')", c)
    '    c.Open()
    '    savesel.ExecuteNonQuery()
    '    c.Close()
    'End Sub
    'MISMA CONSULTA, SOLO AGREGO CICLO
    Shared Sub salvaseleccionados(ByVal id_catalog As String, ByVal idd As String, ByVal tabla As String, ByVal ciclo As String, ByVal turno As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim savesel As New SqlCommand("insert into " + tabla + " (id_razon,ustring,seleccionado,ciclo,id_turno) VALUES('" + id_catalog + "','" + idd + "','1','" + ciclo + "','" + turno + "')", c)
        c.Open()
        savesel.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function get_carrera_by_id_pingreso(ByVal id As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gcbip As New SqlCommand("select carrera from pingreso where id='" + id + "'", c)
        c.Open()
        get_carrera_by_id_pingreso = gcbip.ExecuteScalar.ToString
        c.Close()
    End Function
End Class