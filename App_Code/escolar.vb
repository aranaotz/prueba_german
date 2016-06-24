Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web
Imports System

Public Class escolar
    Shared Function guserdata(ByVal matricula As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gud As New SqlDataAdapter("select matricula,nombre_completo,ic.nombre,ISNULL(ui.imageminipath,'..\docstock\usrdocs\minimages\defaultimg.jpg') AS imageminipath from user_alumnos as ua left join info_carreras as ic on ua.carrera=ic.id_carrera " +
                                      "left join user_images as ui on ua.matricula=ui.userid where ua.matricula='" + matricula + "'", c)
        Dim gudt As New DataTable
        c.Open()
        gud.Fill(gudt)
        c.Close()
        Return gudt
    End Function

    Shared Function cargacursos(ByVal usuario As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gud As New SqlDataAdapter("select cp.icu,cr.cve_materia,im.materia from current_proficu as cp left join current_icurel as cr on cp.icu=cr.icu " +
                                      "left join info_materias as im on im.cve_materia=cr.cve_materia where c_user='" + usuario + "'", c)
        Dim gudt As New DataTable
        c.Open()
        gud.Fill(gudt)
        c.Close()
        Return gudt
    End Function

    Shared Function cargaalumnos_icu(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cai As New SqlDataAdapter("Select ai.icu,ai.matricula,UPPER(ua.apellido_pat + ' ' + ua.apellido_mat + ' ' + ua.nombre) as fullname, '' as evcont,'' as evrem FROM current_alicu as ai " +
                                      "left join user_alumnos as ua on ai.matricula=ua.matricula where ai.icu='" + icu + "' order by apellido_pat,apellido_mat,nombre", c)
        Dim cait As New DataTable
        c.Open()
        cai.Fill(cait)
        c.Close()
        Return cait
    End Function




    '  Shared Function retrieve_data(ByVal busqueda As String, ByVal paranada As String) As DataTable
    '  Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '  Dim cg As New SqlDataAdapter("select ustring as codigo_unico, paterno + ' ' + materno + ' ' + nombres as nombre_completo, paterno as apellido_paterno, " + _
    '                                   "materno as apellido_materno, nombres as nombre, info_carreras.nivel as programa, '../qrcodes/default.png' as qrcode, " + _
    '                                   "info_carreras.nombre as carrera, pingreso.carrera as clavec, pingreso.direccion as domicilio, ISNULL(concatestados.d_asenta, 'Sin registro') as colonia, " + _
    '                                   "'No registrada' as especialidad, ISNULL(concatestados.d_mnpio, 'Sin registro') as municipio,ISNULL(concatestados.d_estado, 'Sin registro') as estado, " + _
    '                                  "ISNULL(concatestados.d_cp, 'Sin registro') as c_postal, curp,tdsangre as factor_rh, telefono, '0000000000' as celular, sexo, " + _
    '                                  "'../photo/default_image.jpg' as foto, email as correo, '0' as enablecheck, fecha, ISNULL(info_sedes.sede,'Sin registro') as sede, " + _
    '                                  "CASE WHEN ciclo IS NULL THEN 'Sin registro' ELSE 'Programado para el ciclo ' + ciclo END as ingreso, ciclo, fdn, basic_edocivil.edocivil as civil , " + _
    '                                  "'Sin registro' as nss, padecimientos, mptutor, ptelefono from pingreso left join info_carreras on " + _
    '                                  "pingreso.carrera=info_carreras.cv_carrera left join (select d_asenta,d_mnpio,d_estado,d_cp, " + _
    '                                  "id_asenta_cpcons + c_mnpio + c_estado as concatenacion from basic_estados) as concatestados on " + _
    '                                  "pingreso.colonia + municipio +  estado=concatestados.concatenacion  COLLATE Modern_Spanish_CS_AS left join info_sedes ON " + _
    '                                  "pingreso.sede=info_sedes.id_sede left join basic_edocivil on pingreso.civil=basic_edocivil.id_edocivil where " + _
    '                                  "ustring='" + busqueda + "'", c)
    ' Dim cgt As New DataTable
    '     c.Open()
    '     cg.Fill(cgt)
    '     c.Close()
    '     retrieve_data = cgt
    ' End Function

    '    Shared Function busqueda_alumno(ByVal alumno As String) As DataTable
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim ba As New SqlDataAdapter("select paterno + ' ' + materno + ' ' + nombres as nombre_completo, ustring as codigo_unico " + _
    '                                     "FROM pingreso where paterno + ' ' + materno + ' ' + nombres + ustring like '%" + alumno + "%' and alumno='0' order by nombre_completo", c)
    '        Dim bat As New DataTable
    '        c.Open()
    '        ba.Fill(bat)
    '        c.Close()
    '        busqueda_alumno = bat
    '    End Function
    '
    '    Shared Function valoresddl(ByVal registro As String) As DataTable
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim vdd As New SqlDataAdapter("SELECT ISNULL(sexo,1) sexo,ISNULL(tdsangre,1) tdsangre FROM pingreso WHERE ustring='" + registro + "'", c)
    '        Dim vddt As New DataTable
    '        c.Open()
    '        vdd.Fill(vddt)
    '        c.Close()
    '        valoresddl = vddt
    '    End Function
    '
    '    Shared Function matricula(ByVal ciclo As String, ByVal carrera As String) As String
    '        Dim utzmg As String = "51"
    '        Dim ingreso As String = ciclo.Substring(2, 2)
    '        Dim mesingreso As String
    '        Select Case (ciclo.ToString.Substring(4, 1))
    '            Case "S"
    '                mesingreso = "1"
    '            Case "E"
    '                mesingreso = "2"
    '            Case Else
    '                mesingreso = "3"
    '        End Select
    '        Dim areac As String
    '        Select Case carrera
    '            Case "TIC"
    '                areac = "1"
    '            Case "MT"
    '                areac = "2"
    '            Case "ER"
    '                areac = "3"
    '            Case "PM"
    '                areac = "4"
    '            Case "DNM"
    '                areac = "5"
    '            Case Else
    '                areac = "6"
    '        End Select
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim cai As New SqlCommand("SELECT dbo.autoincremento('" + ciclo + "')", c)
    '        c.Open()
    '        Dim ai As String = cai.ExecuteScalar.ToString
    '        c.Close()
    '        Dim autoi As String = Right("0000" & ai.ToString, 4)
    '        matricula = utzmg & ingreso & mesingreso & areac & autoi
    '    End Function
    '
    '    Shared Function tabla_documentos(ByVal registro As String) As DataTable
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim td As New SqlDataAdapter("SELECT info_documentos.iddoc,info_documentos.documento,entregado from info_documentos " + _
    '                                     "left join user_documentos on info_documentos.iddoc=user_documentos.iddoc where user_documentos.registro='" + registro + "'", c)
    '        Dim tdd As New DataTable
    '        c.Open()
    '        td.Fill(tdd)
    '        c.Close()
    '        tabla_documentos = tdd
    '    End Function
    '
    '    Shared Function tabla_prepas() As DataTable
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim tp As New SqlDataAdapter("SELECT DISTINCT nombre_ct FROM info_prepas ORDER BY nombre_ct", c)
    '        Dim tpt As New DataTable
    '        c.Open()
    '        tp.Fill(tpt)
    '        c.Close()
    '        tabla_prepas = tpt
    '    End Function
    '
    '    Shared Function fecha(ByVal fecha_cal As String) As String
    '        fecha = Right(fecha_cal, 4) & "-" & fecha_cal.Substring(3, 2) & "-" & Left(fecha_cal, 2)
    '    End Function
    '
    '    Shared Function rw_civil(ByVal texto As String) As String
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '    Dim rcl As New SqlCommand("SELECT ISNULL(id_edocivil, 5) AS num FROM basic_edocivil WHERE (edocivil = '" + texto + "')", c)
    '        c.Open()
    '        rw_civil = rcl.ExecuteScalar.ToString
    '        c.Close()
    '    End Function
    '
    '    Shared Function tabla_lnacimiento() As DataTable
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim tln As New SqlDataAdapter("SELECT DISTINCT d_ciudad + ', ' + d_estado AS l_nacimiento FROM basic_estados WHERE " + _
    '                                     "(d_ciudad + ', ' + d_estado IS NOT NULL) ORDER BY l_nacimiento", c)
    '        Dim tlnd As New DataTable
    '        c.Open()
    '        tln.Fill(tlnd)
    '        c.Close()
    '        tabla_lnacimiento = tlnd
    '    End Function
    '
    '    Shared Function dateprint(ByVal datec As String) As String
    '        Dim anio As String = Left(datec, 4)
    '        Dim mes As String = datec.Substring(5, 2)
    '        Dim dia As String = Right(datec, 2)
    '    Dim mesname As String
    '        Select Case mes
    '            Case "01"
    '                mesname = "Enero"
    '            Case "02"
    '                mesname = "Febrero"
    '            Case "03"
    '                mesname = "Marzo"
    '            Case "04"
    '                mesname = "Abril"
    '            Case "05"
    '                mesname = "Mayo"
    '            Case "06"
    '                mesname = "Junio"
    '            Case "07"
    '                mesname = "Julio"
    '            Case "08"
    '                mesname = "Agosto"
    '            Case "09"
    '                mesname = "Septiembre"
    '            Case "10"
    '                mesname = "Octubre"
    '            Case "11"
    '                mesname = "Noviembre"
    '            Case Else
    '                mesname = "Diciembre"
    '        End Select
    '        dateprint = dia & " de " & mesname & " de " & anio
    '    End Function
    '
    '    Shared Function datos_prepa(ByVal prepa As String) As DataTable
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim dp As New SqlDataAdapter("SELECT TOP (1) domicilio, colonia, municipio, estado FROM info_prepas WHERE (nombre_ct = '" + prepa + "')", c)
    '        Dim dpt As New DataTable
    '        c.Open()
    '        dp.Fill(dpt)
    '        c.Close()
    '        Dim dataprepa(4) As String
    '        datos_prepa = dpt
    '    End Function
    '
    '    Shared Function tampho(ByVal documento As String) As String
    '        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '        Dim tm As New SqlCommand("SELECT tres FROM coordenadas WHERE description='size' AND documento='" + documento + "'", c)
    '        c.Open()
    '        tampho = tm.ExecuteScalar.ToString
    '        c.Close()
    '    End Function
    '
    '    Shared Function verificador(ByVal matricula As String) As String
    '        '---------------------------------
    '        'DESARROLLADA POR ALEJANDRO VELASCO
    '        '---------------------------------
    '        Dim valores() As String = {1, 2, 1, 2, 1, 2, 1, 2, 1, 2}
    '        Dim cad(10) As String
    '        Dim dig(2) As String
    '        Dim aux As Integer
    '        Dim sumaf As Integer
    '        Try
    '            Dim i, x As Integer
    '            For i = 0 To 9
    '                cad(i) = Mid(matricula, i + 1, 1) * valores(i)
    '   Next
    '            For i = 0 To 9
    '                If cad(i).Length > 1 Then
    '                    aux = 0
    '                    For x = 0 To 1
    '                        dig(x) = Mid(cad(i), x + 1, 1)
    '                        aux += dig(x)
    '                    Next
    '                    cad(i) = aux
    '                End If
    '                sumaf += cad(i)
    '            Next
    '            sumaf = sumaf Mod 10
    '            If sumaf <> 0 Then
    '                sumaf = 10 - sumaf
    '            End If
    '            matricula = matricula & sumaf
    '            verificador = matricula
    '        Catch ex As Exception
    '            verificador = matricula & "E"
    '        End Try
    '    End Function





    '------------------------------------------- FUNCIONES PARA LISTA DE ASISTENCIA----------------------------------------------------------------------------
    Shared Function info_icu(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim consulta As New SqlDataAdapter("SELECT o.icu,rel.cve_materia,c.cv_carrera,c.nivel,o.materia,rel.ciclo,o.profesor,t.turno, o.ini, o.fin, o.L, o.M,o .I, o.J, o.V,o.S," +
                                            "o.edif, o.aula, fecha_inicio, fecha_fin from current_oferta as o LEFT OUTER JOIN current_icurel as rel on  o.icu=rel.icu " +
                                            "Left OUTER JOIN info_materias as m on rel.cve_materia= m.cve_materia LEFT OUTER JOIN info_carreras as c on m.carrera= c.id_carrera " +
                                            "LEFT OUTER JOIN basic_turnos as t on o.turno=t.id_turno where o.icu='" + icu + "'", c)
        Dim tabla As New DataTable
        c.Open()
        consulta.Fill(tabla)
        c.Close()
        Return tabla
    End Function


    'llena el ddl meses
    Shared Function info_icu_meses(ByVal inicio As String, ByVal fin As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim consulta As New SqlDataAdapter("set LANGUAGE 'Español'    " +
                                           "SELECT DISTINCT datepart(month,fecha)fechita,DATENAME(MONTH, fecha)fechas from info_diasno where fecha BETWEEN '" + inicio + "' and '" + fin + "' order by fechita", c)
        Dim tabla As New DataTable
        c.Open()
        consulta.Fill(tabla)
        c.Close()
        Return tabla
    End Function

    'parametro mes para reporte
    Shared Function mes(ByVal inicio As String, ByVal fin As String, ByVal m As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim consulta As New SqlDataAdapter("set LANGUAGE 'Español' SELECT DISTINCT datepart(month,fecha)fechita,upper(DATENAME(MONTH, fecha))fechas " +
                                            "from info_diasno where fecha BETWEEN '" + inicio + "' and '" + fin + "' and mes='" + m + "'", c)
        Dim tabla As New DataTable
        c.Open()
        consulta.Fill(tabla)
        c.Close()
        Return tabla
    End Function

    'Listado de alumnos
    Shared Function lista_icus(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim consulta As New SqlDataAdapter("SELECT rank() OVER(ORDER BY ua.apellido_pat,ua.apellido_mat,ua.nombre ) as R ,ca.matricula,ca.ciclo,ca.icu,upper(ua.apellido_pat + ' ' +ua.apellido_mat+' '+ua.nombre) as nombre " +
                                            "FROM current_alicu As ca LEFT OUTER JOIN user_alumnos As ua On ca.matricula=ua.matricula          " +
                                            "WHERE ca.icu='" + icu + "' ORDER BY ua.apellido_pat, ua.apellido_mat asc", c)
        Dim tabla As New DataTable
        c.Open()
        consulta.Fill(tabla)
        c.Close()
        Return tabla
    End Function





    Public Shared Function inserta_evalunidades(ByVal icu As String, ByVal ustring As String, ByVal cal As String, ByVal matricula As String, ByVal unidad As String,
                                                ByVal faltas As String, ByVal asistencias As String, ByVal porcentaje As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into eval_unidades(icu,ustring,cal,matricula,id_unidad,faltas,asistencias,porcentaje_asis) values " +
                                          "('" + icu + "','" + ustring + "','" + cal + "','" + matricula + "','" + unidad + "','" + faltas + "','" + asistencias + "','" + porcentaje + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    Public Shared Function inserta_asisticu(ByVal icu As String, ByVal ciclo As String, ByVal id_unidad As String, ByVal total As String, ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into current_asist_icu(icu,ciclo,id_unidad,total_asistencias,ustring) values " +
                                          "('" + icu + "','" + ciclo + "','" + id_unidad + "','" + total + "','" + ustring + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    Shared Function periodoAsistencia(ByVal periodo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim consulta As New SqlDataAdapter("select '" + periodo + "'", c)
        Dim tabla As New DataTable
        c.Open()
        consulta.Fill(tabla)
        c.Close()
        Return tabla
    End Function

    '--------------------------------------------

    'Valida que ya este evaluada la unidad  por medio del ustring
    Public Shared Function validaUnidad(ByVal user As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case WHEN count(*)>0 THEN '1' else '0' END as duplicado from secure_logins where codigo='" + user + "'", c)
        c.Open()
        validaUnidad = valida.ExecuteScalar.ToString
        c.Close()
    End Function




    '------------------------------------------- FIN DE FUCIONES PARA LISTA DE ASISTENCIA----------------------------------------------------------------------------

    Shared Function materiabyicu(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mbi As New SqlDataAdapter("Select cp.icu, im.materia From current_proficu As cp " +
                                           "LEFT OUTER Join current_icurel As cr On cp.icu = cr.icu " +
                                           "LEFT OUTER Join info_materias As im On im.cve_materia = cr.cve_materia Where (cp.icu = '" + icu + "')", c)
        Dim mbit As New DataTable
        c.Open()
        mbi.Fill(mbit)
        c.Close()
        Return mbit
    End Function

End Class
