Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web
Imports System

Public Class turntable_code

    Private Function codigo(conexion As String, idu As String) As String 'antes gc
        Dim cn As New SqlConnection(conexion)
        Dim cc As New SqlCommand("SELECT c_user FROM users WHERE id_usr='" + idu + "'", cn)
        cn.Open()
        codigo = cc.ExecuteScalar()
        cn.Close()
    End Function

    Shared Function tabla_menu(conexion As String, icu As String, usuario As String, fecha As String, idprop As String) As DataTable
        Dim cn As New SqlConnection(conexion)
        Dim cc As New SqlDataAdapter("SELECT imgurl,command,descrip,tooltip FROM menus WHERE enable4=1 and idprop='" + idprop + "' ORDER BY orden", cn)
        Dim dt As New DataTable
        cn.Open()
        cc.Fill(dt)
        cn.Close()
        tabla_menu = dt
    End Function

    Shared Function tabla_unidades(ByVal conexion As String, ByVal icu As String) As DataTable
        Dim cn As New SqlConnection(conexion)
        Dim tu As New SqlDataAdapter("SELECT future_inf_icu.icu, future_inf_icu.ciclo, future_inf_icu.mat, unidades_tem.cve_unidad, " + _
                                     "unidades_tem.unidad, unidades_tem.horas, CASE WHEN eval_reportes_future.estado IS NULL THEN 1 ELSE 0 END AS estado, " + _
                                     "eval_reportes_estados.string, eval_reportes_estados.imageurl, estilos.estilo FROM future_inf_icu INNER JOIN " + _
                                     "unidades_tem ON future_inf_icu.mat = unidades_tem.cve_materia LEFT OUTER JOIN eval_reportes_future " + _
                                     "ON eval_reportes_future.icu = future_inf_icu.icu AND CONVERT(varchar, unidades_tem.cve_unidad) = eval_reportes_future.mat " + _
                                     "INNER JOIN eval_reportes_estados ON eval_reportes_estados.id_estado = CASE WHEN eval_reportes_future.estado IS NULL THEN 0 ELSE 1 END " + _
                                     "INNER JOIN estilos ON estilos.id_estilo = CASE WHEN eval_reportes_future.estado IS NULL THEN 0 ELSE 1 END " + _
                                     "WHERE (future_inf_icu.ciclo = '2013B') AND (future_inf_icu.icu = '" + icu + "') ORDER BY future_inf_icu.nombre", cn)
        Dim dtt As New DataTable
        cn.Open()
        tu.Fill(dtt)
        cn.Close()
        tabla_unidades = dtt
    End Function

    Shared Function cursos(ByVal usr As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cu As New SqlDataAdapter("SELECT info_materiaunica.materia + '  (ICU: ' + current_proficu.icu + ')' materia ,current_proficu.icu FROM info_materiaunica INNER JOIN current_icurel ON current_icurel.cve_materia = " + _
                                     "info_materiaunica.cve_materia INNER JOIN current_proficu ON current_icurel.icu = current_proficu.icu WHERE " + _
                                     "(current_proficu.c_user = '" + usr + "')", c)
        Dim cut As New DataTable
        c.Open()
        cu.Fill(cut)
        c.Close()
        cursos = cut
    End Function

    Shared Function alumnos(ByVal icu As String, ByVal cve_unica As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ca As New SqlDataAdapter("SELECT '" + icu + "' as icu, '" + cve_unica + "' as utematica, current_alicu.matricula, user_alumnos.nombre_completo FROM current_alicu INNER JOIN user_alumnos ON " + _
                                     "user_alumnos.matricula = current_alicu.matricula WHERE (current_alicu.icu = '" + icu + "') ORDER BY user_alumnos.nombre_completo", c)
        Dim cat As New DataTable
        c.Open()
        ca.Fill(cat)
        c.Close()
        alumnos = cat
    End Function

    Shared Function cal_options(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cop As New SqlDataAdapter("SELECT DISTINCT info_defincal.letra, info_defincal.letra_unica, info_defincal.orden_vista FROM current_icurel " + _
                                      "INNER JOIN info_materiaunica ON current_icurel.cve_materia = info_materiaunica.cve_materia " + _
                                      "INNER JOIN info_defincal ON info_materiaunica.typeval = info_defincal.tipo_materia " + _
                                      "WHERE (current_icurel.icu = '" + icu + "') ORDER BY info_defincal.orden_vista", c)
        Dim copt As New DataTable
        c.Open()
        cop.Fill(copt)
        c.Close()
        cal_options = copt
    End Function

    Shared Function tematicas(ByVal icu As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tm As New SqlDataAdapter("SELECT info_tematicas.cve_unica, info_tematicas.nombre_ut FROM current_icurel INNER JOIN info_tematicas ON " + _
                                     "current_icurel.cve_materia = info_tematicas.cve_materia WHERE (current_icurel.icu = '" + icu + "') AND " + _
                                     "(current_icurel.ciclo = '" + ciclo + "')", c)
        Dim tmt As New DataTable
        c.Open()
        tm.Fill(tmt)
        c.Close()
        tematicas = tmt
    End Function

    Shared Sub guardar(ByVal icu As String, ByVal ustring As String, ByVal calificacion As String, ByVal tipo_cal As String, ByVal matricula As String, ByVal utematica As String, ByVal usuario As String, ByVal tipoentrada As String, ByVal ciclo As String, ByVal stant As Boolean)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gd As New SqlCommand("INSERT INTO eval_unidades (icu,ustring,cal,tipocal,matricula,id_unidad,usuario) VALUES ('" + icu + "','" + ustring + "', " + _
                         "'" + calificacion + "','" + tipo_cal + "','" + matricula + "','" + utematica + "','" + usuario + "')", c)
        c.Open()
        gd.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub actualiza(ByVal icu As String, ByVal ustring As String, ByVal calificacion As String, ByVal tipo_cal As String, ByVal matricula As String, ByVal utematica As String, ByVal usuario As String, ByVal tipoentrada As String, ByVal ciclo As String, ByVal stant As Boolean)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Select Case stant
            Case True
                Dim di As New SqlCommand("DELETE from eval_unidades WHERE icu='" + icu + "' AND id_unidad='" + utematica + "'", c)
                Dim ut As New SqlCommand("UPDATE eval_unidadesrp SET ustring='" + ustring + "', estado='" + tipoentrada + "' WHERE icu='" + icu + "' AND id_unidad='" + utematica + "' " + _
                                         "AND ciclo='" + ciclo + "'", c)
                c.Open()
                di.ExecuteNonQuery()
                ut.ExecuteNonQuery()
                c.Close()
            Case Else
                Dim ut As New SqlCommand("UPDATE eval_unidadesrp SET ustring='" + ustring + "', estado='" + tipoentrada + "' WHERE icu='" + icu + "' AND id_unidad='" + utematica + "' " + _
                                         "AND ciclo='" + ciclo + "'", c)
                c.Open()
                ut.ExecuteNonQuery()
                c.Close()
        End Select
    End Sub

    Shared Function mustring(ByVal ciclo As String, ByVal icu As String) As String
        Dim p0 As String = Format(Now, "ddMMyyhhmm")
        Dim p1 As String = Str(CDbl(p0) * CDbl(Now.DayOfYear)) & Now.Second
        Dim pf As String = icu & p1 & ciclo
        mustring = pf
    End Function

    Shared Function estado_reporte(ByVal ciclo As String, ByVal icu As String, ByVal id_unidad As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim er As New SqlCommand("SELECT estado FROM eval_unidadesrp WHERE icu='" + icu + "' AND id_unidad='" + id_unidad + "' AND ciclo='" + ciclo + "'", c)
        c.Open()
        Try
            estado_reporte = er.ExecuteScalar.ToString
        Catch ex As Exception
            estado_reporte = 0
        End Try
        c.Close()
    End Function

    Shared Function gustring(ByVal ciclo As String, ByVal icu As String, ByVal id_unidad As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim er As New SqlCommand("SELECT ustring FROM eval_unidadesrp WHERE icu='" + icu + "' AND id_unidad='" + id_unidad + "' AND ciclo='" + ciclo + "'", c)
        c.Open()
        Try
            gustring = er.ExecuteScalar.ToString
        Catch ex As Exception
            gustring = 0
        End Try
        c.Close()
    End Function

    Shared Function truepost(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tp As New SqlDataAdapter("SELECT     principal.matricula, principal.nombre_completo, principal.final, principal.status, " + _
                                     " CASE WHEN principal.status = 'REPROBADO' THEN 'NA' ELSE info_redefincal.letra END AS letra, " + _
                                     "user_alumnos_1.carrera, CASE WHEN principal.status = 'REPROBADO' THEN 'NO ACREDITADO' ELSE info_redefincal.defletra END AS defletra " + _
                                     "FROM         (SELECT     eval_unidades.matricula, " + _
                                     "UPPER(user_alumnos.nombre_completo) AS nombre_completo, CONVERT(NUMERIC(18, 2), ROUND(AVG(info_defincal.valor), 1)) " + _
                                     " AS final, CASE WHEN nas.cal IS NULL THEN 'APROBADO' ELSE 'REPROBADO' END AS status, info_defincal.tipo_materia " + _
                                     " FROM          eval_unidades INNER JOIN  eval_unidadesrp ON eval_unidades.ustring = eval_unidadesrp.ustring INNER JOIN " + _
                                     " info_defincal ON eval_unidades.cal = info_defincal.letra_unica INNER JOIN " + _
                                     "  user_alumnos ON eval_unidades.matricula = user_alumnos.matricula LEFT OUTER JOIN " + _
                                     "(SELECT     eval_unidades_1.matricula, eval_unidades_1.cal  FROM          eval_unidades AS eval_unidades_1 INNER JOIN " + _
                                     " eval_unidadesrp AS eval_unidadesrp_1 ON eval_unidades_1.ustring = eval_unidadesrp_1.ustring " + _
                                     " WHERE      (eval_unidadesrp_1.icu = '" + icu + "') AND (eval_unidades_1.cal IN ('AU4', 'NA1', 'NA2'))) AS nas ON  " + _
                                     " eval_unidades.matricula = nas.matricula WHERE      (eval_unidadesrp.icu = '" + icu + "') GROUP BY eval_unidades.matricula, " + _
                                     "nas.cal, user_alumnos.nombre_completo, info_defincal.tipo_materia) AS principal INNER JOIN  info_redefincal ON " + _
                                     "principal.final = info_redefincal.cal AND principal.tipo_materia = info_redefincal.tipomateria INNER JOIN " + _
                                     " user_alumnos AS user_alumnos_1 ON principal.matricula = user_alumnos_1.matricula " + _
                                     "ORDER BY principal.nombre_completo", c)
        Dim tpd As New DataTable
        c.Open()
        tp.Fill(tpd)
        truepost = tpd
        c.Close()
    End Function

    Shared Function lista_asistencia(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim la As New SqlDataAdapter("select rank() OVER (ORDER BY ua.nombre_completo) as lista, ca.matricula,UPPER(ua.nombre_completo) AS nombre_completo from " + _
                                     "current_alicu as ca inner join user_alumnos as ua on ca.matricula=ua.matricula where ca.icu='" + icu + "' order by lista", c)
        Dim ladt As New DataTable
        c.Open()
        la.Fill(ladt)
        lista_asistencia = ladt
        c.Close()
    End Function



    Shared Function cabezaldata(ByVal icu As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cd As New SqlDataAdapter("SELECT TOP (1) current_proficu.id, current_proficu.c_user, current_proficu.icu, current_proficu.ciclo, " + _
                                 "UPPER(users.nombresp) AS nombre_completo, info_materiaunica.materia," + _
                                 "info_materias.cuatrimestre, info_carreras.nombre FROM         current_proficu INNER JOIN " + _
                                 "users ON users.c_user = current_proficu.c_user INNER JOIN " + _
                                 "current_icurel ON current_proficu.icu = current_icurel.icu INNER JOIN info_materiaunica ON current_icurel.cve_materia = " + _
                                 "info_materiaunica.cve_materia INNER JOIN info_materias ON info_materiaunica.cve_materia = info_materias.cve_materia " + _
                                 "INNER JOIN info_carreras ON info_materias.carrera COLLATE Modern_Spanish_CI_AS = info_carreras.cv_carrera " + _
                                 "WHERE     (current_proficu.icu = '" + icu + "')", c)
        Dim cdt As New DataTable
        c.Open()
        cd.Fill(cdt)
        c.Close()
        cabezaldata = cdt
    End Function

    Shared Function enableprint4complet(ByVal icu As String, ByVal ciclo As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ep As New SqlCommand("SELECT case when count(*)>0 then '0' else '1' end as qty FROM eval_unidadesrp where icu='" + icu + "' and estado in " + _
                                 "(select id_restado from basic_repestados where enkardex=0)", c)
        c.Open()
        enableprint4complet = ep.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function ciclo_actual() As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ca As New SqlCommand("SELECT TOP(1) ciclo FROM current_ciclo WHERE active=1 ORDER BY ciclo desc", c)
        c.Open()
        ciclo_actual = ca.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function nombre_ut(ByVal ut As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim nut As New SqlCommand("SELECT top(1) nombre_ut FROM info_tematicas WHERE (cve_unica = '" + ut + "')", c)
        c.Open()
        nombre_ut = nut.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function truepost_ut(ByVal icu As String, ByVal ut As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tp As New SqlDataAdapter("SELECT     principal.matricula, principal.nombre_completo, principal.final, principal.status, " + _
                                     " CASE WHEN principal.status = 'REPROBADO' THEN 'NA' ELSE info_redefincal.letra END AS letra, " + _
                                     "user_alumnos_1.carrera, CASE WHEN principal.status = 'REPROBADO' THEN 'NO ACREDITADO' ELSE info_redefincal.defletra END AS defletra " + _
                                     "FROM         (SELECT     eval_unidades.matricula, " + _
                                     "UPPER(user_alumnos.nombre_completo) AS nombre_completo, CONVERT(NUMERIC(18, 2), ROUND(AVG(info_defincal.valor), 1)) " + _
                                     " AS final, CASE WHEN nas.cal IS NULL THEN 'APROBADO' ELSE 'REPROBADO' END AS status, info_defincal.tipo_materia " + _
                                     " FROM          eval_unidades INNER JOIN  eval_unidadesrp ON eval_unidades.ustring = eval_unidadesrp.ustring INNER JOIN " + _
                                     " info_defincal ON eval_unidades.cal = info_defincal.letra_unica INNER JOIN " + _
                                     "  user_alumnos ON eval_unidades.matricula = user_alumnos.matricula LEFT OUTER JOIN " + _
                                     "(SELECT     eval_unidades_1.matricula, eval_unidades_1.cal  FROM          eval_unidades AS eval_unidades_1 INNER JOIN " + _
                                     " eval_unidadesrp AS eval_unidadesrp_1 ON eval_unidades_1.ustring = eval_unidadesrp_1.ustring " + _
                                     " WHERE      (eval_unidadesrp_1.icu = '" + icu + "') AND (eval_unidadesrp_1.id_unidad = '" + ut + "') AND (eval_unidades_1.cal IN ('AU4', 'NA1', 'NA2'))) AS nas ON  " + _
                                     " eval_unidades.matricula = nas.matricula WHERE (eval_unidadesrp.icu = '" + icu + "') AND (eval_unidadesrp.id_unidad = '" + ut + "') GROUP BY eval_unidades.matricula, " + _
                                     "nas.cal, user_alumnos.nombre_completo, info_defincal.tipo_materia) AS principal INNER JOIN  info_redefincal ON " + _
                                     "principal.final = info_redefincal.cal AND principal.tipo_materia = info_redefincal.tipomateria INNER JOIN " + _
                                     " user_alumnos AS user_alumnos_1 ON principal.matricula = user_alumnos_1.matricula " + _
                                     "ORDER BY principal.nombre_completo", c)
        Dim tpd As New DataTable
        c.Open()
        tp.Fill(tpd)
        truepost_ut = tpd
        c.Close()
    End Function
End Class
