Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports ASPPDFLib

Partial Class evalquery
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llena_materias(gc)
            mv_consulta.ActiveViewIndex = 0
        End If
    End Sub

    Public Function getactualcycle() As String
        Dim v As New SqlConnection(Application("str"))
        Dim cycle As New SqlCommand("SELECT ciclo FROM general_ciclos WHERE active=1", v)
        v.Open()
        getactualcycle = cycle.ExecuteScalar
        v.Close()
    End Function

    Private Sub llena_materias(ByVal prof As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim lmc As New SqlCommand("SELECT icu,materia + ' (' + grupo + ')' as mtr FROM future_inf_icu WHERE ciclo='" + getactualcycle() + "' AND prof='" + prof + "'", sc)
        Dim lmda As New SqlDataAdapter(lmc)
        Dim lmdt As New DataTable
        sc.Open()
        lmda.Fill(lmdt)
        sc.Close()
        dl_materias.DataSource = lmdt
        dl_materias.DataBind()
    End Sub

    Private Function gc() As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim aingcomm As New SqlCommand("SELECT c_user FROM users WHERE id_usr='" + Session("usrcgi200Xstr") + "'", sqlconn)
        sqlconn.Open()
        gc = aingcomm.ExecuteScalar()
        sqlconn.Close()
    End Function

    Protected Sub docommand(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case sender.commandname
            Case "mostrar"
                lbl_etiqueta.Text = sender.text
                'filldata_gv(sender.commandArgument)
                new_filldata_dl(sender.CommandArgument, getactualcycle)
                mv_consulta.ActiveViewIndex = 1
        End Select
    End Sub

    Protected Sub dofunction(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case sender.CommandName
            Case "faltas"
                showassitence(sender.CommandArgument, sender.attributes("valmatr"), sender.TabIndex, getactualcycle)
                hf_faltas_mpe.Show()
            Case "evc"
                showevc(sender.CommandArgument, sender.attributes("valmatr"), sender.TabIndex, getactualcycle)
                hf_evc_mpe.Show()
            Case "examen"
                Dim isd As Integer
                For isd = 0 To dl_reportes.Items.Count - 1
                    Dim but As Button = CType(dl_reportes.Items(isd).FindControl("cmd_print"), Button)
                    Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
                    If current IsNot Nothing Then
                        current.RegisterPostBackControl(but)
                    End If
                Next
        End Select
    End Sub

    Private Function dls(ByVal fh As Boolean) As Integer
        Select Case fh
            Case True
                dls = 1
            Case Else
                dls = 2
        End Select
    End Function

    Private Sub new_filldata_dl(ByVal icu As String, ByVal ciclo As String)
        Dim c As New SqlConnection(Application("str"))
        Dim cda_f As New SqlDataAdapter("SELECT fechas.nmes, fechas.mes, fechas.inicio, fechas.final, fechas.ide, fechas.ids, fechas.iden, fechas.icu, fechas.ciclo, dbo.future_inf_icu.tipo, fechas.finalex FROM (SELECT DISTINCT id_mes AS nmes, mes, MIN(fstart) AS inicio, " + _
                                        "MAX(fend) AS final, MAX(id_examen) AS ide, MAX(id_semana) AS ids, MAX(id_entrega) AS iden,  MAX(CONVERT(int, fi)) AS finalex, '" + icu + "' AS icu, '" + ciclo + "' AS ciclo FROM dbo.future_eval_dates WHERE (ciclo = '" + ciclo + "') GROUP BY id_mes, mes) AS fechas " + _
                                        "INNER JOIN dbo.future_inf_icu ON fechas.ciclo = dbo.future_inf_icu.ciclo AND fechas.icu = dbo.future_inf_icu.icu WHERE (fechas.inicio < (SELECT MAX(fecha) AS maxr FROM dbo.eval_asreportes_future WHERE (icu = '" + icu + "') AND " + _
                                        "(estado = 2) AND (ciclo = '" + ciclo + "'))) ORDER BY fechas.nmes", c)
        Dim ta As New DataTable
        c.Open()
        cda_f.Fill(ta)
        c.Close()
        dl_reportes.DataSource = ta
        dl_reportes.DataBind()
    End Sub

    Protected Sub dl_reportes_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dl_reportes.ItemDataBound
        Dim gv As GridView
        Dim nmes As String = CType(e.Item.FindControl("hf_nmes"), HiddenField).Value.ToString
        Dim ide As String = CType(e.Item.FindControl("hf_ide"), HiddenField).Value.ToString
        Dim icu As String = CType(e.Item.FindControl("hf_icu"), HiddenField).Value.ToString
        Dim tipo As String = CType(e.Item.FindControl("hf_tipo"), HiddenField).Value.ToString
        Dim finalex As String = CType(e.Item.FindControl("hf_finalex"), HiddenField).Value.ToString
        Dim fdi As String = Format(CDate(CType(e.Item.FindControl("hf_fdi"), HiddenField).Value.ToString), "yyyy-MM-dd")
        Dim fdf As String = Format(CDate(CType(e.Item.FindControl("hf_fdf"), HiddenField).Value.ToString), "yyyy-MM-dd")
        Dim cmdp As Button = CType(e.Item.FindControl("cmd_print"), Button)

        Select Case finalex
            Case "0"
                Dim mv As MultiView = CType(e.Item.FindControl("mv_cal"), MultiView)
                gv = CType(e.Item.FindControl("evaluacion"), GridView)
                consulta_x_icu(gv, getactualcycle, icu, fdi, fdf, ide, nmes, tipo)
                mv.ActiveViewIndex = 0
            Case Else
                Dim mv As MultiView = CType(e.Item.FindControl("mv_cal"), MultiView)
                gv = CType(e.Item.FindControl("gv_examen"), GridView)
                filldata_gv(icu, nmes, gv, cmdp, ide)
                mv.ActiveViewIndex = 1
        End Select
    End Sub

    Private Sub consulta_x_icu(ByVal dlsi As GridView, ciclo As String, icu As String, fstart As String, fend As String, ide As String, nmes As String, tipo As String)
        'Private Sub consulta_x_icu(ByVal icu As String, inicio As Date, final As Date, idexamen As String, idsemana As String)
        Dim c As New SqlConnection(Application("str"))
        Dim sc As String
        Select Case tipo
            Case "P"
                sc = "SELECT source1.alumno,fname,osep, CONVERT(Numeric(18,1),(AVG([1])*.4 + AVG([2])*.3 + AVG([3])*.3))  as evc,ISNULL(extra_points.point,0) as ep,ISNULL(extra_points.id,0) as infoep, '" + nmes + "' as nmes, '" + icu + "' as icu, " + _
                                      "ISNULL(extra_points.ustring,0) as infoepu, CASE WHEN (CONVERT(Numeric(18,1),(AVG([1])*.4 + AVG([2])*.3 + AVG([3])*.3)) + ISNULL(extra_points.point,0))>=10 THEN 10 ELSE (CONVERT(Numeric(18,1),(AVG([1])*.4 + AVG([2])*.3 + AVG([3])*.3)) + ISNULL(extra_points.point,0)) END as evcpe, " + _
                                      "expar.calif,expar.id as idep,case when (expar.calif IS NULL) THEN 0 ELSE 1 END as califen,asistencetable.asistencias,asistencetable.faltas,(CASE WHEN asistencetable.faltas=0 THEN 0 ELSE 1 END) asistenceenable,convert(varchar,asistencetable.faltas) + ' (' + convert(varchar,asistencetable.asistencias) + ')' textasistence, erh.icu, " + _
                                      "CASE WHEN (CASE WHEN erh.icu IS NULL THEN 1 ELSE 0 END)=1 THEN CONVERT(Numeric(18,1),(CASE WHEN (CONVERT(Numeric(18,1),(AVG([1])*.4 + AVG([2])*.3 + AVG([3])*.3)) + ISNULL(extra_points.point,0))>=10 THEN 10 ELSE (CONVERT(Numeric(18,1),(AVG([1])*.4 + AVG([2])*.3 + AVG([3])*.3)) + ISNULL(extra_points.point,0)) END*0.6 + calif*0.4)) ELSE erh.fcal END as final " + _
                                      "FROM (SELECT * FROM (SELECT ustring, alumno, eval_id, eval_cal,'" + ciclo + "' as cicloa FROM eval_cal_future) AS tbl PIVOT (AVG(eval_cal) FOR eval_id IN ([1], [2], [3])) AS pvt WHERE (ustring IN (SELECT ustring FROM eval_reportes_future WHERE (ciclo = '" + ciclo + "') AND (icu = '" + icu + "') AND " + _
                                      "(fecha BETWEEN '" + fstart + "' AND '" + fend + "') AND (estado = 2)))) AS source1 INNER JOIN alumnos ON alumnos.matr=source1.alumno and alumnos.status='AC' and alumnos.ciclo='" + ciclo + "' LEFT OUTER JOIN extra_points ON extra_points.alumno=source1.alumno and extra_points.icu='" + icu + "' and extra_points.id_examen='" + nmes + "' and extra_points.ciclo='" + ciclo + "' " + _
                                      "LEFT OUTER JOIN (SELECT dbo.eval_pexcal_future.alumno as alumnoep, dbo.eval_pexcal_future.calif, dbo.eval_pexcal_future.id FROM dbo.eval_parex_future INNER JOIN dbo.eval_pexcal_future ON dbo.eval_parex_future.ciclo = dbo.eval_pexcal_future.ciclo AND " + _
                                      "dbo.eval_parex_future.ustring = dbo.eval_pexcal_future.ustring AND dbo.eval_parex_future.id_examen = dbo.eval_pexcal_future.id_examen WHERE (dbo.eval_parex_future.id_examen = '" + ide + "') AND (dbo.eval_parex_future.ciclo = '" + ciclo + "') AND (dbo.eval_parex_future.icu = '" + icu + "')) as expar ON " + _
                                      "source1.alumno = expar.alumnoep LEFT OUTER JOIN (select alumno,(sum(A) + sum(J)) asistencias,(sum(F)+(sum(R)/3)) faltas  FROM (SELECT * from (select ustring, alumno, eval_cal,id_hora FROM eval_ast_future) atbl PIVOT (Count(id_hora) FOR eval_cal IN ([A],[F],[R],[J])) apvt " + _
                                      "WHERE (ustring IN (SELECT ustring FROM eval_asreportes_future WHERE (ciclo = '" + ciclo + "') AND (icu = '" + icu + "') AND (fecha BETWEEN '" + fstart + "' AND '" + fend + "') AND (estado = 2)))) matable GROUP BY alumno) asistencetable ON source1.alumno=asistencetable.alumno " + _
                                      "LEFT OUTER JOIN (select alumno,icu,fcal from eval_reportes_hide WHERE icu='" + icu + "' AND ciclo='" + ciclo + "' AND id_mes='" + nmes + "') as erh ON erh.alumno=source1.alumno " + _
                                      "GROUP BY source1.alumno,fname,extra_points.point,extra_points.id,extra_points.ustring,expar.calif,expar.id,asistencetable.asistencias,asistencetable.faltas,erh.icu,erh.fcal,osep ORDER BY osep"
            Case "T"
                sc = "SELECT source1.alumno,fname,osep,CONVERT(Numeric(18,1),(AVG([4])*.4 + AVG([5])*.3 + AVG([6])*.3))  as evc,ISNULL(extra_points.point,0) as ep,ISNULL(extra_points.id,0) as infoep, '" + nmes + "' as nmes, '" + icu + "' as icu, " + _
                                      "ISNULL(extra_points.ustring,0) as infoepu, CASE WHEN (CONVERT(Numeric(18,1),(AVG([4])*.4 + AVG([5])*.3 + AVG([6])*.3)) + ISNULL(extra_points.point,0))>=10 THEN 10 ELSE (CONVERT(Numeric(18,1),(AVG([4])*.4 + AVG([5])*.3 + AVG([6])*.3)) + ISNULL(extra_points.point,0)) END as evcpe, " + _
                                      "expar.calif,expar.id as idep,case when (expar.calif IS NULL) THEN 0 ELSE 1 END as califen,asistencetable.asistencias,asistencetable.faltas,(CASE WHEN asistencetable.faltas=0 THEN 0 ELSE 1 END) asistenceenable,convert(varchar,asistencetable.faltas) + ' (' + convert(varchar,asistencetable.asistencias) + ')' textasistence, erh.icu," + _
                                      "CASE WHEN (CASE WHEN erh.icu IS NULL THEN 1 ELSE 0 END)=1 THEN CONVERT(Numeric(18,1),(CASE WHEN (CONVERT(Numeric(18,1),(AVG([4])*.4 + AVG([5])*.3 + AVG([6])*.3)) + ISNULL(extra_points.point,0))>=10 THEN 10 ELSE (CONVERT(Numeric(18,1),(AVG([4])*.4 + AVG([5])*.3 + AVG([6])*.3)) + ISNULL(extra_points.point,0)) END*0.6 + calif*0.4)) ELSE erh.fcal END as final " + _
                                      "FROM (SELECT * FROM (SELECT ustring, alumno, eval_id, eval_cal,'" + ciclo + "' as cicloa FROM eval_cal_future) AS tbl PIVOT (AVG(eval_cal) FOR eval_id IN ([4], [5], [6])) AS pvt WHERE (ustring IN (SELECT ustring FROM eval_reportes_future WHERE (ciclo = '" + ciclo + "') AND (icu = '" + icu + "') AND " + _
                                      "(fecha BETWEEN '" + fstart + "' AND '" + fend + "') AND (estado = 2)))) AS source1 INNER JOIN alumnos ON alumnos.matr=source1.alumno and alumnos.status='AC' and alumnos.ciclo='" + ciclo + "' LEFT OUTER JOIN extra_points ON extra_points.alumno=source1.alumno and extra_points.icu='" + icu + "' and extra_points.id_examen='" + nmes + "' and extra_points.ciclo='" + ciclo + "' " + _
                                      "LEFT OUTER JOIN (SELECT dbo.eval_pexcal_future.alumno as alumnoep, dbo.eval_pexcal_future.calif, dbo.eval_pexcal_future.id FROM dbo.eval_parex_future INNER JOIN dbo.eval_pexcal_future ON dbo.eval_parex_future.ciclo = dbo.eval_pexcal_future.ciclo AND " + _
                                      "dbo.eval_parex_future.ustring = dbo.eval_pexcal_future.ustring AND dbo.eval_parex_future.id_examen = dbo.eval_pexcal_future.id_examen WHERE (dbo.eval_parex_future.id_examen = '" + ide + "') AND (dbo.eval_parex_future.ciclo = '" + ciclo + "') AND (dbo.eval_parex_future.icu = '" + icu + "')) as expar ON " + _
                                      "source1.alumno = expar.alumnoep LEFT OUTER JOIN (select alumno,(sum(A) + sum(J)) asistencias,(sum(F)+(sum(R)/3)) faltas  FROM (SELECT * from (select ustring, alumno, eval_cal,id_hora FROM eval_ast_future) atbl PIVOT (Count(id_hora) FOR eval_cal IN ([A],[F],[R],[J])) apvt " + _
                                      "WHERE (ustring IN (SELECT ustring FROM eval_asreportes_future WHERE (ciclo = '" + ciclo + "') AND (icu = '" + icu + "') AND (fecha BETWEEN '" + fstart + "' AND '" + fend + "') AND (estado = 2)))) matable GROUP BY alumno) asistencetable ON source1.alumno=asistencetable.alumno " + _
                                      "LEFT OUTER JOIN (select alumno,icu,fcal from eval_reportes_hide WHERE icu='" + icu + "' AND ciclo='" + ciclo + "' AND id_mes='" + nmes + "') as erh ON erh.alumno=source1.alumno " + _
                                      "GROUP BY source1.alumno,fname,extra_points.point,extra_points.id,extra_points.ustring,expar.calif,expar.id,asistencetable.asistencias,asistencetable.faltas,erh.icu,erh.fcal,osep ORDER BY osep"

        End Select
        Dim dt As New DataTable
        Dim cda As New SqlDataAdapter(sc, c)
        c.Open()
        cda.Fill(dt)
        c.Close()
        dlsi.DataSource = dt
        dlsi.DataBind()

    End Sub

    Private Sub filldata_gv(ByVal icu As String, ByVal idmes As String, ByVal gv As GridView, ByVal cmdp As Button, ByVal ide As String)
        Dim sc As New SqlConnection(Application("str"))
        'Dim fdgc As New SqlCommand("SELECT DISTINCT id_mes,mes,fi FROM future_eval_dates WHERE (ciclo='" + getactualcycle + "') AND (fstart < (SELECT MAX(fecha) AS fecha FROM eval_asreportes_future WHERE (icu = '" + icu + "') AND (estado = '2')))", sc)
        'Dim fdgda As New SqlDataAdapter(fdgc)
        'Dim fdgdt As New DataTable
        'sc.Open()
        'fdgda.Fill(fdgdt)
        'sc.Close()
        'fi refiere al examen final, si es verdadero, el sistema solo muestra la calificacion final en el reporte del mes.
        'dl_reportes.DataSource = fdgdt
        'dl_reportes.DataBind()
        'Dim itm As Integer
        'For itm = 0 To dl_reportes.Items.Count - 1
        'Dim fi As String = fdgdt.Rows(itm).Item(2).ToString
        'Dim mview As MultiView = CType(dl_reportes.Items(itm).FindControl("mv_cal"), MultiView)
        'Dim type As Boolean = CType(dl_reportes.Items(itm).FindControl("hf_type"), HiddenField).Value
        'Dim dlsi As GridView = CType(dl_reportes.Items(itm).FindControl("gv_examen"), GridView)
        'Dim idmes As String = CType(dl_reportes.Items(itm).FindControl("lbl_mes"), Label).TabIndex.ToString
        'Dim dli As GridView = CType(dl_reportes.Items(itm).FindControl("evaluacion"), GridView)
        'Dim cmdp As Button = CType(dl_reportes.Items(itm).FindControl("cmd_print"), Button)
        'cmdp.CommandArgument = icu
        'Dim fecha As Label = CType(dl_reportes.Items(itm).FindControl("lbl_fecha"), Label)
        'Dim gp As New SqlCommand("SELECT fend FROM future_eval_dates WHERE ciclo='" + getactualcycle + "' AND id_mes='" + idmes + "' AND imprime=1", sc)
        'Dim ta As New SqlDataAdapter(gp)
        'sc.Open()
        'Select Case Now
        '   Case Is >= gp.ExecuteScalar
        'cmdp.Enabled = True
        '    Case Else
        'cmdp.Enabled = False
        'fecha.Text = "IMPRESION A PARTIR DE " & Format(gp.ExecuteScalar, "MMMM dd yyyy").ToUpper
        ' End Select
        'sc.Close()
        'Select Case dls(Type)
        '   Case 1


        load_eval(idmes, icu, gv, ide)
        Dim gvsi As Integer
        For gvsi = 0 To gv.Rows.Count - 1
            Dim matr As String = CType(gv.Rows(gvsi).FindControl("hf_matr"), HiddenField).Value
            Dim lbexm As LinkButton = CType(gv.Rows(gvsi).FindControl("lb_examen"), LinkButton)
            Dim lblpnts As Label = CType(gv.Rows(gvsi).FindControl("lbl_pextra"), Label)
            With lbexm
                .Text = getexamen(icu, matr, idmes)
                .CommandArgument = icu
                .Attributes.Add("valmatr", matr)
                .TabIndex = idmes
            End With
            Try
                gv.Rows(gvsi).Cells(2).Text = Math.Round(rounding_from2_to_1(Math.Round(CDbl(new_get123(matr, icu, gvsi) / 3), 2)), 1)
                gv.Rows(gvsi).Cells(5).Text = Math.Round(rounding_from2_to_1(Math.Round((CDbl(new_get123(matr, icu, gvsi)) + IIf((CDbl(lbexm.Text) + CDbl(lblpnts.Text)) > 10, 10, (CDbl(lbexm.Text) + CDbl(lblpnts.Text)))) / 4, 2)), 1)
            Catch ex As Exception
                'ANTERIOR CON MENOR FUNCIONALIDAD - - - - ->gv.Rows(gvsi).Cells(2).Text = Math.Round(CDbl(get123(matr, icu)), 1)
                gv.Rows(gvsi).Cells(2).Text = Math.Round(CDbl(get123(matr, icu)), 1)
            End Try
        Next

        '######################################################################################################################
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        '-----AGREGA FUNCIONALIDAD AL BOTON DE IMPRIMIR------------------------------------------------------------------------------------------------------------------------------

        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(cmdp)
        End If

        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        '######################################################################################################################

        'mview.ActiveViewIndex = 1
        '    Case Else
        'new_filldata_gv(dli)
        'load_eval(idmes, icu, dli)
        'Dim gvsi As Integer
        'For gvsi = 0 To dli.Rows.Count - 1
        'Dim matr As String = CType(dli.Rows(gvsi).FindControl("hf_matr"), HiddenField).Value
        ' Dim lbfaltas As LinkButton = CType(dli.Rows(gvsi).FindControl("lb_faltas"), LinkButton)
        ' Dim lbevc As LinkButton = CType(dli.Rows(gvsi).FindControl("lb_evc"), LinkButton)
        ' Dim lbexm As LinkButton = CType(dli.Rows(gvsi).FindControl("lb_examen"), LinkButton)
        ' Dim lbpe As LinkButton = CType(dli.Rows(gvsi).FindControl("lb_pe"), LinkButton)
        ' Dim lbpeec As Label = CType(dli.Rows(gvsi).FindControl("lb_peec"), Label)
        ' With lbfaltas
        '.Text = getfaltas(icu, matr, idmes)
        '.CommandArgument = icu
        '.Attributes.Add("valmatr", matr)
        '   .TabIndex = idmes
        'End With
        ' With lbevc
        ' .Text = getevc2(icu, matr, idmes)
        ' .CommandArgument = icu
        ' .Attributes.Add("valmatr", matr)
        ' .TabIndex = idmes
        ' End With
        '' With lbexm
        ' .Text = getexamen(icu, matr, idmes)
        ' .CommandArgument = icu
        ' .Attributes.Add("valmatr", matr)
        '.TabIndex = idmes
        'End With
        '-------------------------------------------------------------------------
        'Nueva adicion de Puntos extras
        'With lbpe
        ' .Text = getpuntosextras(icu, matr, idmes)
        '.CommandArgument = icu
        ' .Attributes.Add("valmatr", matr)
        ' .TabIndex = idmes
        '' End With
        ' With lbpeec
        '.Text = IIf(CDbl(lbevc.Text) + CDbl(lbpe.Text) > 10, Math.Round(10, 1), Math.Round((CDbl(lbevc.Text) + CDbl(lbpe.Text)), 1))
        ' .CommandArgument = icu
        '.Attributes.Add("valmatr", matr)
        'TabIndex = idmes
        '  End With
        '-------------------------------------------------------------------------
        '---dli.Rows(gvsi).Cells(7).Text = Math.Round((CDbl(lbevc.Text) * 0.6) + (CDbl(lbexm.Text) * 0.4), 1)
        'dli.Rows(gvsi).Cells(7).Text = Math.Round((CDbl(lbpeec.Text) * 0.6) + (CDbl(lbexm.Text) * 0.4), 1)
        'Next
        'mview.ActiveViewIndex = 0
        'End Select
        ' Next
    End Sub

    Private Function getpuntosextras(ByVal icu As String, ByVal matr As String, ByVal id_mes As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gtep As New SqlCommand("SELECT COUNT(*) as punto FROM extra_points WHERE (id_examen = '" + id_mes + "') AND (icu = '" + icu + "') AND (alumno = '" + matr + "') " + _
                                    "AND (ciclo = '" + getactualcycle() + "')", sc)
        sc.Open()
        getpuntosextras = gtep.ExecuteScalar.ToString
        sc.Close()
        Session("matr2find") = matr
    End Function

    Private Function new_get123(ByVal matr As String, ByVal icu As String, indexs As Integer) As String
        'Dim gvtprint As GridView = CType(dl_reportes.Items(3).FindControl("gv_examen"), GridView)
        'Dim matrindx As Integer
        Dim cal As Double = 0.0
        'For matrindx = 0 To gvtprint.Rows.Count - 1
        'Dim nm As String = gvtprint.Rows(matrindx).Cells(1).Text.ToString.Replace("&#209;", "Ñ")
        'Dim nmat As String = CType(gvtprint.Rows(matrindx).FindControl("hf_matr"), HiddenField).Value
        Dim rww As Integer
        'Dim cal As Double = 0.0
        For rww = 0 To dl_reportes.Items.Count - 1
            Dim gvrww As GridView = CType(dl_reportes.Items(rww).FindControl("evaluacion"), GridView)
            Dim pm As String = gvrww.Rows(indexs).Cells(7).Text
            cal = cal + CDbl(pm)
        Next
        'Dim pmo As String = CType(gvtprint.Rows(matrindx).FindControl("lb_examen"), LinkButton).Text
        'Dim pmf As String = text(Math.Round((cal + CDbl(pmo)) / 4, 1), icu, matr)
        'Next
        new_get123 = cal
    End Function

    Private Function rounding_from2_to_1(ByVal n2r As Double) As Double
        Dim dm As Integer = n2r - Math.Floor(n2r)
        Select Case dm.ToString.Length
            Case Is > 1
                Select Case Right(dm.ToString, 1) = 5
                    Case True
                        rounding_from2_to_1 = n2r + 0.01
                    Case Else
                        rounding_from2_to_1 = n2r
                End Select
            Case Else
                rounding_from2_to_1 = n2r
        End Select
    End Function


    Private Function get123(ByVal matr As String, ByVal icu As String) As String
        Dim v As New SqlConnection(Application("str"))
        Dim vp As New SqlCommand("SELECT Promedio FROM eval_promedios WHERE matr ='" + matr + "' AND ciclo='" + getactualcycle() + "' AND icu='" + icu + "'", v)
        v.Open()
        get123 = vp.ExecuteScalar
        v.Close()
    End Function

    Private Sub load_eval(ByVal nmes As String, ByVal icu As String, ByVal dli As GridView, ByVal ide As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim lev As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        Dim lev2 As New SqlCommand("SELECT alumnos.matr,alumnos.fname,alumnos.osep,ISNULL(eval_directpoint.points,'0') pnts, ISNULL(eval_directpoint.justification,'N/A') justify, " + _
                                   "ISNULL(eval_nofinal_future.cause, 'ORDINARIO') AS commn, CASE WHEN eval_nofinal_future.cause IS NULL THEN '1' ELSE '0' END AS ennb " + _
                                   "FROM alumnos LEFT JOIN eval_directpoint " + _
                                   "ON alumnos.matr=eval_directpoint.alumno AND alumnos.ciclo=eval_directpoint.ciclo AND eval_directpoint.icu='" + icu + "' " + _
                                   "AND eval_directpoint.id_examen='" + ide + "' LEFT OUTER JOIN eval_nofinal_future ON alumnos.matr = eval_nofinal_future.matr " + _
                                   "AND alumnos.ciclo = eval_nofinal_future.ciclo AND eval_nofinal_future.icu = '" + icu + "' WHERE " + _
                                   "alumnos.ciclo='" + getactualcycle() + "' AND alumnos.grupo='" + lev.ExecuteScalar + "' AND alumnos.status='AC' ORDER BY osep", sc)
        Dim lev2da As New SqlDataAdapter(lev2)
        Dim lev2dt As New DataTable
        lev2da.Fill(lev2dt)
        sc.Close()
        dli.DataSource = lev2dt
        dli.DataBind()
    End Sub

    Protected Sub ib_cambiarcurso_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ib_cambiarcurso.Click
        mv_consulta.ActiveViewIndex = 0
    End Sub

    Private Sub showassitence(ByVal icu As String, ByVal matr As String, ByVal id_mes As String, ciclo As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim sha As New SqlCommand("SELECT dbo.eval_ast_future.alumno, dbo.eval_ast_future.eval_cal, dbo.sched_horas.alias, dbo.eval_ast_future.id, dbo.eval_asreportes_future.fecha FROM dbo.eval_ast_future INNER JOIN dbo.sched_horas ON dbo.eval_ast_future.id_hora = " + _
                                  "dbo.sched_horas.id_hora INNER JOIN dbo.eval_asreportes_future ON dbo.eval_ast_future.ustring = dbo.eval_asreportes_future.ustring WHERE (dbo.eval_ast_future.alumno = '" + matr + "') AND (dbo.eval_ast_future.ustring IN (SELECT ustring FROM " + _
                                  "dbo.eval_asreportes_future AS eval_asreportes_future_1 WHERE (fecha BETWEEN (SELECT MIN(fstart) AS Expr1 FROM dbo.future_eval_dates WHERE (ciclo = '" + ciclo + "') AND (id_mes = '" + id_mes + "')) AND (SELECT MAX(fend) AS Expr1 FROM dbo.future_eval_dates " + _
                                  "AS future_eval_dates_1 WHERE (ciclo = '" + ciclo + "') AND (id_mes = '" + id_mes + "'))) AND (icu = '" + icu + "') AND (estado = '2'))) AND (dbo.eval_ast_future.eval_cal = 'F' OR dbo.eval_ast_future.eval_cal = 'R') ORDER BY dbo.eval_asreportes_future.fecha", sc)
        Dim shda As New SqlDataAdapter(sha)
        Dim shdt As New DataTable
        sc.Open()
        shda.Fill(shdt)
        sc.Close()
        gv_faltas.DataSource = shdt
        gv_faltas.DataBind()
        Dim isd As Integer
        For isd = 0 To dl_reportes.Items.Count - 1
            Dim but As Button = CType(dl_reportes.Items(isd).FindControl("cmd_print"), Button)
            Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
            If current IsNot Nothing Then
                current.RegisterPostBackControl(but)
            End If
        Next
    End Sub

    Private Sub showevc(ByVal icu As String, ByVal matr As String, ByVal id_mes As String, ByVal ciclo As String)
        Dim sc As New SqlConnection(Application("str"))
        '  Dim sha As New SqlCommand("SELECT TOP (100) PERCENT dbo.eval_reportes_future.fecha, dbo.evalue_kind.forma, dbo.eval_description_future.description, dbo.eval_cal_future.eval_cal, " + _
        '                     "dbo.evalue_kind.xcent, dbo.eval_cal_future.id FROM dbo.eval_cal_future INNER JOIN dbo.eval_reportes_future ON dbo.eval_cal_future.ustring = dbo.eval_reportes_future.ustring INNER JOIN " + _
        '                          "dbo.alumnos ON dbo.eval_cal_future.alumno = dbo.alumnos.matr INNER JOIN dbo.eval_description_future ON dbo.eval_reportes_future.ustring = dbo.eval_description_future.ustring AND " + _
        '                           "dbo.eval_cal_future.eval_id = dbo.eval_description_future.eval_id INNER JOIN dbo.evalue_kind ON dbo.eval_cal_future.eval_id = dbo.evalue_kind.id_forma " + _
        '                          "WHERE (dbo.eval_reportes_future.icu = '" + icu + "') AND (dbo.eval_cal_future.alumno = '" + matr + "') AND (dbo.alumnos.ciclo = '" + getactualcycle + "') AND (dbo.eval_reportes_future.semana IN " + _
        '                          "(SELECT id_entrega FROM dbo.future_eval_dates WHERE (id_mes = '" + id_mes + "'))) ORDER BY dbo.eval_reportes_future.fecha, dbo.evalue_kind.forma", sc)
        Dim sha As New SqlCommand("SELECT dbo.eval_cal_future.eval_cal, dbo.eval_reportes_future.fecha, dbo.eval_description_future.description, dbo.evalue_kind.forma, dbo.evalue_kind.xcent, dbo.eval_cal_future.id, " + _
                                  "CONVERT(Numeric(18, 1), dbo.eval_cal_future.eval_cal * dbo.evalue_kind.xcent / 100) AS puntos FROM dbo.eval_reportes_future INNER JOIN dbo.eval_cal_future ON dbo.eval_reportes_future.ustring = dbo.eval_cal_future.ustring LEFT OUTER JOIN " + _
                                  "dbo.eval_description_future ON dbo.eval_cal_future.ustring = dbo.eval_description_future.ustring AND dbo.eval_cal_future.eval_id = dbo.eval_description_future.eval_id INNER JOIN dbo.evalue_kind ON dbo.eval_description_future.eval_id = " + _
                                  "dbo.evalue_kind.id_forma WHERE (dbo.eval_reportes_future.fecha BETWEEN (SELECT MIN(fstart) AS inicio FROM dbo.future_eval_dates WHERE (ciclo = '" + ciclo + "') AND (id_mes = '" + id_mes + "')) AND (SELECT MAX(fend) AS corte FROM dbo.future_eval_dates " + _
                                  "AS future_eval_dates_1 WHERE (ciclo = '" + ciclo + "') AND (id_mes = '" + id_mes + "'))) AND (dbo.eval_reportes_future.icu = '" + icu + "') AND (dbo.eval_reportes_future.estado = '2') AND (dbo.eval_cal_future.alumno = '" + matr + "') ORDER BY dbo.eval_reportes_future.fecha, dbo.evalue_kind.id_forma", sc)
        Dim shda As New SqlDataAdapter(sha)
        Dim shdt As New DataTable
        sc.Open()
        shda.Fill(shdt)
        sc.Close()
        gv_evc.DataSource = shdt
        gv_evc.DataBind()
        Dim isd As Integer
        For isd = 0 To dl_reportes.Items.Count - 1
            Dim but As Button = CType(dl_reportes.Items(isd).FindControl("cmd_print"), Button)
            Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
            If current IsNot Nothing Then
                current.RegisterPostBackControl(but)
            End If
        Next
    End Sub

    Private Function getfaltas(ByVal icu As String, ByVal matr As String, ByVal id_mes As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gfc As New SqlCommand("SELECT COUNT(0) AS faltas FROM eval_ast_future INNER JOIN eval_asreportes_future ON " + _
                                   "eval_ast_future.ustring = eval_asreportes_future.ustring WHERE (eval_ast_future.alumno = '" + matr + "') AND " + _
                                   "(eval_ast_future.eval_cal = 'F') AND (eval_asreportes_future.icu = '" + icu + "') AND (eval_asreportes_future.estado = 2) AND " + _
                                   "(dbo.eval_asreportes_future.semana IN (SELECT id_entrega FROM dbo.future_eval_dates WHERE (id_mes = '" + id_mes + "') AND (ciclo='" + getactualcycle() + "')))", sc)
        Dim grc As New SqlCommand("SELECT COUNT(0) AS faltas FROM eval_ast_future INNER JOIN eval_asreportes_future ON " + _
                                  "eval_ast_future.ustring = eval_asreportes_future.ustring WHERE (eval_ast_future.alumno = '" + matr + "') AND " + _
                                  "(eval_ast_future.eval_cal = 'R') AND (eval_asreportes_future.icu = '" + icu + "') AND (eval_asreportes_future.estado = 2)AND " + _
                                  "(dbo.eval_asreportes_future.semana IN (SELECT id_entrega FROM dbo.future_eval_dates WHERE (id_mes = '" + id_mes + "') AND (ciclo='" + getactualcycle() + "')))", sc)
        Dim gac As New SqlCommand("SELECT COUNT(0) AS faltas FROM eval_ast_future INNER JOIN eval_asreportes_future ON " + _
                                  "eval_ast_future.ustring = eval_asreportes_future.ustring WHERE (eval_ast_future.alumno = '" + matr + "') AND " + _
                                  "(eval_asreportes_future.icu = '" + icu + "') AND (eval_asreportes_future.estado = 2)AND " + _
                                  "(dbo.eval_asreportes_future.semana IN (SELECT id_entrega FROM dbo.future_eval_dates WHERE (id_mes = '" + id_mes + "') AND (ciclo='" + getactualcycle() + "')))", sc)
        sc.Open()
        Dim fa As String = gfc.ExecuteScalar
        Dim re As String = grc.ExecuteScalar
        Dim tto As String = gac.ExecuteScalar
        sc.Close()
        Session("matr2find") = matr
        getfaltas = (CInt(fa) + Math.Truncate(re / 3)) & " (" & tto & ")"
    End Function

    Private Function getevc(ByVal icu As String, ByVal matr As String, ByVal id_mes As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gtevc As New SqlCommand("SELECT CONVERT(Numeric(18, 1), (AVG(dbo.retrieve_evcont_future.it1) * 0.4 + AVG(dbo.retrieve_evcont_future.it2) * 0.3) + " + _
                                   "AVG(dbo.retrieve_evcont_future.it3) * 0.3) AS Evc FROM dbo.retrieve_evcont_future INNER JOIN dbo.eval_reportes_future ON " + _
                                   "dbo.retrieve_evcont_future.ustring = dbo.eval_reportes_future.ustring WHERE (dbo.eval_reportes_future.icu = '" + icu + "') AND " + _
                                   "(dbo.retrieve_evcont_future.matr = '" + matr + "') AND (dbo.eval_reportes_future.semana IN (SELECT id_entrega FROM dbo.future_eval_dates " + _
                                   "WHERE (id_mes = '" + id_mes + "') AND (ciclo='" + getactualcycle() + "'))) GROUP BY dbo.eval_reportes_future.estado,dbo.eval_reportes_future.ciclo HAVING (dbo.eval_reportes_future.estado = 2) AND (dbo.eval_reportes_future.ciclo = '" + getactualcycle() + "')", sc)
        sc.Open()
        Try
            getevc = gtevc.ExecuteScalar.ToString
        Catch ex As Exception
            getevc = "0"
        End Try
        sc.Close()
        Session("matr2find") = matr
    End Function

    Private Function getevc2(ByVal icu As String, ByVal matr As String, ByVal id_mes As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gtevc As New SqlCommand("SELECT CONVERT(Numeric(18, 1), 0.4*(AVG(dbo.retrieve_evcont_future.it1) + (0.75*(AVG(dbo.retrieve_evcont_future.it2) + " + _
                                   "AVG(dbo.retrieve_evcont_future.it3))))) AS Evc FROM dbo.retrieve_evcont_future INNER JOIN dbo.eval_reportes_future ON " + _
                                   "dbo.retrieve_evcont_future.ustring = dbo.eval_reportes_future.ustring WHERE (dbo.eval_reportes_future.icu = '" + icu + "') AND " + _
                                   "(dbo.retrieve_evcont_future.matr = '" + matr + "') AND (dbo.eval_reportes_future.semana IN (SELECT id_entrega FROM dbo.future_eval_dates " + _
                                   "WHERE (id_mes = '" + id_mes + "') AND (ciclo='" + getactualcycle() + "'))) GROUP BY dbo.eval_reportes_future.estado,dbo.eval_reportes_future.ciclo HAVING (dbo.eval_reportes_future.estado = 2) AND (dbo.eval_reportes_future.ciclo = '" + getactualcycle() + "')", sc)
        sc.Open()
        Try
            getevc2 = gtevc.ExecuteScalar.ToString
        Catch ex As Exception
            getevc2 = "0"
        End Try
        sc.Close()
        Session("matr2find") = matr
    End Function

    Private Function getexamen(ByVal icu As String, ByVal matr As String, ByVal id_mes As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gtevc As New SqlCommand("SELECT dbo.eval_pexcal_future.calif FROM dbo.eval_parex_future INNER JOIN dbo.eval_pexcal_future ON " + _
                                    "dbo.eval_parex_future.ustring = dbo.eval_pexcal_future.ustring WHERE (dbo.eval_parex_future.id_semana IN (SELECT id_entrega " + _
                                    "FROM dbo.future_eval_dates WHERE (id_mes = '" + id_mes + "') AND (ciclo='" + getactualcycle() + "'))) AND (dbo.eval_parex_future.icu = '" + icu + "') AND (dbo.eval_pexcal_future.alumno = '" + matr + "') " + _
                                    "AND (dbo.eval_parex_future.ciclo = '" + getactualcycle() + "') AND (dbo.eval_parex_future.reportado = 1)", sc)
        sc.Open()
        Try
            getexamen = gtevc.ExecuteScalar.ToString
        Catch ex As Exception
            getexamen = "0"
        End Try
        sc.Close()
        Session("matr2find") = matr
    End Function

    Private Sub carga_icus(ByVal grupos As String, ByVal idmes As String, ByVal dli As GridView, ByVal matr As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim gic As New SqlCommand("SELECT icu,materia FROM future_inf_icu WHERE grupo='" + grupos + "' AND ciclo=''" + getactualcycle() + "' ORDER BY materia", sc)
        Dim gida As New SqlDataAdapter(gic)
        Dim gidt As New DataTable
        sc.Open()
        gida.Fill(gidt)
        sc.Close()
        dli.DataSource = gidt
        dli.DataBind()
        Dim nicu As Integer
        For nicu = 0 To dli.Rows.Count - 1
            Dim idicu As String = dli.Rows(nicu).Cells(0).Text
            Dim lblfaltas As LinkButton = CType(dli.Rows(nicu).FindControl("lb_faltas"), LinkButton)
            Dim lblevc As LinkButton = CType(dli.Rows(nicu).FindControl("lb_evc"), LinkButton)
            Dim lbexamen As LinkButton = CType(dli.Rows(nicu).FindControl("lb_examen"), LinkButton)
            With lblfaltas
                .Text = getfaltas(idicu, matr, idmes)
                .CommandArgument = idicu
                .Attributes.Add("valmatr", matr)
                .TabIndex = idmes
            End With
            With lblevc
                .Text = getevc2(idicu, matr, idmes)
                .CommandArgument = idicu
                .Attributes.Add("valmatr", matr)
                .TabIndex = idmes
            End With
            With lbexamen
                .Text = getexamen(idicu, matr, idmes)
                .CommandArgument = idicu
                .Attributes.Add("valmatr", matr)
                .TabIndex = idmes
            End With
            dli.Rows(nicu).Cells(5).Text = Math.Round((CDbl(lblevc.Text) * 0.6) + (CDbl(lbexamen.Text) * 0.4), 1)
        Next
    End Sub

    Protected Sub cmd_print_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gen_pdf(sender.CommandArgument, sender.CommandName, sender.TabIndex)
    End Sub

    Private Sub gen_pdf(ByVal icu As String, ByVal mes As String, ByVal dlindex As String)
        Dim actualmv As MultiView = CType(dl_reportes.Items(dlindex).FindControl("mv_cal"), MultiView)
        Dim sc As New SqlConnection(Application("str"))
        Select Case actualmv.ActiveViewIndex
            Case 0
                Dim objPdf As IPdfManager = New PdfManager()
                objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
                Dim objDoc As IPdfDocument = objPdf.OpenDocument(Server.MapPath("\cgiapp\formatos\mensual.pdf"), Missing.Value)
                objDoc.Title = "Formato de Entrega de Calificacion " & getactualcycle()
                objDoc.Creator = "Direccion Académica CGI"
                Dim objPage As IPdfPage = objDoc.Pages(1)
                Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
                Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")
                'objPage.Canvas.DrawBarcode("" + matr + "", "x=76,y=473,width=50,height=10,type=17")

                'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE

                Dim gec As New SqlCommand("SELECT materia,nombre,grupo,titular,nombre2 FROM future_inf_icu WHERE icu='" + icu + "' and ciclo='" + getactualcycle() + "'", sc)
                Dim geda As New SqlDataAdapter(gec)
                Dim gedt As New DataTable
                sc.Open()
                geda.Fill(gedt)
                sc.Close()

                Dim xbar As Integer
                Dim ybar As Integer

                'TEXTO DEL ENCABEZADO DE REPORTE
                xbar = 100
                ybar = 697
                Dim textcur As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(0).ToString, textcur, objFont)
                xbar = 100
                ybar = 683
                Dim textmaestro As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(1).ToString, textmaestro, objFont)
                xbar = 100
                ybar = 669
                Dim textgrupo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(2).ToString, textgrupo, objFont)
                xbar = 195
                ybar = 669
                Dim texticu As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(icu, texticu, objFont)
                xbar = 343
                ybar = 669
                Dim textciclo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(getactualcycle, textciclo, objFont)
                xbar = 478
                ybar = 669
                Dim textmes As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(mes, textmes, objFont)

                Dim gvtprint As GridView = CType(dl_reportes.Items(dlindex).FindControl("evaluacion"), GridView)
                Dim matrindx As Integer

                xbar = 47
                Dim x2bar As Integer = 320
                Dim x3bar As Integer = 385
                Dim x4bar As Integer = 435

                ybar = 614
                For matrindx = 0 To gvtprint.Rows.Count - 1
                    Dim nm As String = gvtprint.Rows(matrindx).Cells(1).Text.ToString.Replace("&#209;", "Ñ") 'NOMBRE DEL ALUMNO
                    Dim ev As String = CType(gvtprint.Rows(matrindx).FindControl("lb_peec"), Label).Text 'EVCONTINUA YA CON PTS
                    Dim ex As String = CType(gvtprint.Rows(matrindx).FindControl("lbl_examen"), Label).Text 'EXAMEN PARCIAL
                    Dim pm As String = gvtprint.Rows(matrindx).Cells(7).Text




                    Dim nmt As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                    objPage.Canvas.DrawText(nm, nmt, objFont)
                    Dim evt As String = "x=" & x2bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                    objPage.Canvas.DrawText(ev, evt, objFont)
                    Dim ext As String = "x=" & x3bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                    objPage.Canvas.DrawText(ex, ext, objFont)
                    Dim pmt As String = "x=" & x4bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                    objPage.Canvas.DrawText(pm, pmt, objFont)

                    Dim separator = objDoc.OpenImage(Server.MapPath("\cgiapp\img\reportesep.gif"))
                    objPage.Canvas.DrawImage(separator, "x=170, y=" & ybar - 13)
                    ybar = ybar - 14
                Next

                xbar = 45
                Dim fy As String = "x=" & xbar & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                Dim fm As String = "x=" & xbar & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                Dim dp As String = "x=" & xbar & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                Select Case gedt.Rows(0).Item(3).ToString
                    Case "0"
                        Dim fy2 As String = "x=" & xbar + 210 & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                        Dim fm2 As String = "x=" & xbar + 210 & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                        Dim dp2 As String = "x=" & xbar + 210 & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                        objPage.Canvas.DrawText(gedt.Rows(0).Item(4).ToString & "  (TITULAR)", fm2, objFont)
                        objPage.Canvas.DrawText("________________________", fy2, objFont)
                        'objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp2, objFont)


                        objPage.Canvas.DrawText(gedt.Rows(0).Item(1).ToString & "  (SUPLENTE)", fm, objFont)
                        objPage.Canvas.DrawText("________________________", fy, objFont)
                        objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp, objFont)
                    Case Else
                        objPage.Canvas.DrawText(gedt.Rows(0).Item(1).ToString & "  (TITULAR)", fm, objFont)
                        objPage.Canvas.DrawText("________________________", fy, objFont)
                        objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp, objFont)
                End Select
                Dim nrep As String = icu & "-" & mes & getactualcycle()

                objPage.Canvas.DrawBarcode(nrep, "x=210; y=" & ybar - 92 & ",width=150,height=8,alignment=center,type=17")

                Dim path As String = Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf")
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                If (file.Exists) Then
                    file.Delete()
                    Dim Filename = objDoc.Save(Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf"), False)
                Else
                    Dim Filename = objDoc.Save(Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf"), False)
                End If
                getdoc(nrep)
            Case Else

                '###############################################
                '###############################################
                'CUANDO ES FINAL
                '###############################################
                '###############################################


                '------------------------------------------------>
                '------------------------------------------------<
                'SE ELIMINA LA CALIFICACION ANTES GUARDADA EN UNA IMPRESION ANTERIOR, ESTO EVITA LA TAREA DE QUITAR DUPLICADOS
                '------------------------------------------------<
                Dim base_del As New SqlCommand("DELETE from finales WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
                sc.Open()
                base_del.ExecuteNonQuery()
                sc.Close()
                '------------------------------------------------<
                'FIN DE BORRADO
                '------------------------------------------------<
                '------------------------------------------------>

                Dim objPdf As IPdfManager = New PdfManager()
                objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
                Dim objDoc As IPdfDocument = objPdf.OpenDocument(Server.MapPath("\cgiapp\formatos\acta_final.pdf"), Missing.Value)
                objDoc.Title = "ACTA DE INTEGRACION FINAL."
                objDoc.Creator = "Direccion Académica CGI"
                Dim objPage As IPdfPage = objDoc.Pages(1)
                Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
                Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

                'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE

                Dim gec As New SqlCommand("SELECT materia,nombre,grupo,titular,nombre2 FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
                Dim geda As New SqlDataAdapter(gec)
                Dim gedt As New DataTable
                sc.Open()
                geda.Fill(gedt)
                sc.Close()

                Dim xbar As Integer
                Dim ybar As Integer

                'TEXTO DEL ENCABEZADO DE REPORTE
                xbar = 100
                ybar = 697
                Dim textcur As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(0).ToString, textcur, objFont)
                xbar = 100
                ybar = 683
                Dim textmaestro As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(IIf(gedt.Rows(0).Item(3).ToString = "0", gedt.Rows(0).Item(4).ToString, gedt.Rows(0).Item(1).ToString), textmaestro, objFont)
                xbar = 100
                ybar = 669
                Dim textgrupo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(2).ToString, textgrupo, objFont)
                xbar = 195
                ybar = 669
                Dim texticu As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(icu, texticu, objFont)
                xbar = 343
                ybar = 669
                Dim textciclo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(getactualcycle, textciclo, objFont)
                xbar = 478
                ybar = 669
                Dim textmes As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(mes, textmes, objFont)

                Dim gvtprint As GridView = CType(dl_reportes.Items(dlindex).FindControl("gv_examen"), GridView)
                Dim matrindx As Integer
                xbar = 47

                Dim x2bar As Integer = 320
                Dim x3bar As Integer = 385
                Dim x4bar As Integer = 435

                ybar = 595
                For matrindx = 0 To gvtprint.Rows.Count - 1
                    Dim nm As String = gvtprint.Rows(matrindx).Cells(1).Text.ToString.Replace("&#209;", "Ñ")
                    Dim nmat As String = CType(gvtprint.Rows(matrindx).FindControl("hf_matr"), HiddenField).Value
                    Dim rww As Integer
                    Dim cal As Double = 0.0
                    Dim xbar2 As Integer = 240
                    For rww = 0 To dl_reportes.Items.Count - 2
                        Dim gvrww As GridView = CType(dl_reportes.Items(rww).FindControl("evaluacion"), GridView)
                        Dim pm As String = gvrww.Rows(matrindx).Cells(7).Text
                        Dim evp As String = "x=" & xbar2 & "; y=" & ybar & "; width=495; alignment=left; size=10"
                        objPage.Canvas.DrawText(pm, evp, objFont)
                        xbar2 = xbar2 + 55
                        cal = cal + CDbl(pm)
                    Next
                    Dim pmov As String = "x=415; y=" & ybar & "; width=495; alignment=left; size=10"
                    Dim pmfv As String = "x=470; y=" & ybar & "; width=495; alignment=left; size=10"
                    Dim pmo As String = CType(gvtprint.Rows(matrindx).FindControl("lb_examen"), LinkButton).Text
                    Dim pexmo As String = CType(gvtprint.Rows(matrindx).FindControl("lbl_pextra"), Label).Text

                    'Dim pmf As String = text(Math.Round(rounding_from2_to_1(Math.Round((cal + CDbl(pmo)) / 4, 2)), 1), icu, nmat)
                    Dim pmf As String = Str(Math.Round(rounding_from2_to_1(Math.Round((cal + IIf((CDbl(pmo) + CDbl(pexmo)) > 10, 10, (CDbl(pmo) + CDbl(pexmo)))) / 4, 2)), 1))

                    '------------------------------------------------>
                    '------------------------------------------------<
                    'GUARDAMOS LA CALIFICACION FINAL EN LA BASE DE DATOS PARA QUE EN UN FUTURO SEA MAS FACIL SACARLA
                    '------------------------------------------------<
                    Dim incommand As New SqlCommand("INSERT INTO finales (curso,icu,alumno,grupo,calificacion,ciclo) VALUES " + _
                                                    "('" + gedt.Rows(0).Item(0).ToString + "','" + icu + "','" + nm + "','" + gedt.Rows(0).Item(2).ToString + "','" + pmf + "','" + getactualcycle() + "')", sc)
                    sc.Open()
                    incommand.ExecuteNonQuery()
                    sc.Close()
                    '------------------------------------------------<
                    'FIN DE GUARDADO
                    '------------------------------------------------<
                    '------------------------------------------------>


                    objPage.Canvas.DrawText(pmo, pmov, objFont)
                    objPage.Canvas.DrawText(pmf, pmfv, objFont)
                    Dim nmt As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
                    objPage.Canvas.DrawText(nm, nmt, objFont)

                    Dim pmt As String = "x=" & x4bar & "; y=" & ybar & "; width=495; alignment=left; size=10"

                    Dim separator = objDoc.OpenImage(Server.MapPath("\cgiapp\img\reportesep.gif"))
                    objPage.Canvas.DrawImage(separator, "x=170, y=" & ybar - 13)
                    ybar = ybar - 14
                Next
                xbar = 45
                Select Case gedt.Rows(0).Item(3).ToString
                    Case "0"
                        Dim fy2 As String = "x=" & xbar + 210 & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                        Dim fm2 As String = "x=" & xbar + 210 & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                        Dim dp2 As String = "x=" & xbar + 210 & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                        objPage.Canvas.DrawText(gedt.Rows(0).Item(1).ToString & "  (ADJUNTO)", fm2, objFont)
                        objPage.Canvas.DrawText("________________________", fy2, objFont)
                        'objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp2, objFont)

                        Dim fy As String = "x=" & xbar & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                        Dim fm As String = "x=" & xbar & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                        Dim dp As String = "x=" & xbar & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                        objPage.Canvas.DrawText(gedt.Rows(0).Item(4).ToString & "  (TITULAR)", fm, objFont)
                        objPage.Canvas.DrawText("________________________", fy, objFont)
                        objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp, objFont)
                        'objPage.Canvas.DrawText("10 de Diciembre de 2011", dp, objFont)
                    Case Else
                        Dim fy As String = "x=" & xbar & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                        Dim fm As String = "x=" & xbar & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                        Dim dp As String = "x=" & xbar & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                        objPage.Canvas.DrawText(gedt.Rows(0).Item(1).ToString & "  (TITULAR)", fm, objFont)
                        objPage.Canvas.DrawText("________________________", fy, objFont)
                        objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp, objFont)
                        'objPage.Canvas.DrawText("10 de Diciembre de 2011", dp, objFont)
                End Select

                Dim nrep As String = icu & "-" & mes & getactualcycle()

                objPage.Canvas.DrawBarcode(nrep, "x=210; y=" & ybar - 92 & ",width=150,height=8,alignment=center,type=17")

                Dim path As String = Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf")
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                If (file.Exists) Then
                    file.Delete()
                    Dim Filename = objDoc.Save(Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf"), False)
                Else
                    Dim Filename = objDoc.Save(Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf"), False)
                End If
                getdoc(nrep)
        End Select
    End Sub

    Private Sub acta_final(ByVal icu As String, ByVal mes As String, ByVal dlindex As Integer)
        Dim sc As New SqlConnection(Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(Server.MapPath("\cgiapp\formatos\acta_final.pdf"), Missing.Value)
        objDoc.Title = "ACTA DE INTEGRACION FINAL."
        objDoc.Creator = "Direccion Académica CGI"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE

        Dim gec As New SqlCommand("SELECT materia,nombre,grupo,titular,nombre2 FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        Dim geda As New SqlDataAdapter(gec)
        Dim gedt As New DataTable
        sc.Open()
        geda.Fill(gedt)
        sc.Close()

        Dim xbar As Integer
        Dim ybar As Integer

        'TEXTO DEL ENCABEZADO DE REPORTE
        xbar = 100
        ybar = 697
        Dim textcur As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(gedt.Rows(0).Item(0).ToString, textcur, objFont)
        xbar = 100
        ybar = 683
        Dim textmaestro As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(IIf(gedt.Rows(0).Item(3).ToString = "0", gedt.Rows(0).Item(4).ToString, gedt.Rows(0).Item(1).ToString), textmaestro, objFont)
        xbar = 100
        ybar = 669
        Dim textgrupo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(gedt.Rows(0).Item(2).ToString, textgrupo, objFont)
        xbar = 195
        ybar = 669
        Dim texticu As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(icu, texticu, objFont)
        xbar = 343
        ybar = 669
        Dim textciclo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(getactualcycle, textciclo, objFont)
        xbar = 478
        ybar = 669
        Dim textmes As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(mes, textmes, objFont)

        Dim gvtprint As GridView = CType(dl_reportes.Items(dlindex).FindControl("gv_examen"), GridView)
        Dim matrindx As Integer
        xbar = 47

        Dim x2bar As Integer = 320
        Dim x3bar As Integer = 385
        Dim x4bar As Integer = 435

        ybar = 595
        For matrindx = 0 To gvtprint.Rows.Count - 1
            Dim nm As String = gvtprint.Rows(matrindx).Cells(1).Text.ToString.Replace("&#209;", "Ñ")
            Dim nmat As String = CType(gvtprint.Rows(matrindx).FindControl("hf_matr"), HiddenField).Value
            Dim rww As Integer
            Dim cal As Double = 0.0
            Dim xbar2 As Integer = 240
            For rww = 0 To dl_reportes.Items.Count - 2
                Dim gvrww As GridView = CType(dl_reportes.Items(rww).FindControl("evaluacion"), GridView)
                Dim pm As String = gvrww.Rows(matrindx).Cells(7).Text
                Dim evp As String = "x=" & xbar2 & "; y=" & ybar & "; width=495; alignment=left; size=10"
                objPage.Canvas.DrawText(pm, evp, objFont)
                xbar2 = xbar2 + 55
                cal = cal + CDbl(pm)
            Next
            Dim pmov As String = "x=415; y=" & ybar & "; width=495; alignment=left; size=10"
            Dim pmfv As String = "x=470; y=" & ybar & "; width=495; alignment=left; size=10"
            Dim pmo As String = CType(gvtprint.Rows(matrindx).FindControl("lb_examen"), LinkButton).Text
            Dim pexmo As String = CType(gvtprint.Rows(matrindx).FindControl("lbl_pextra"), Label).Text

            'Dim pmf As String = text(Math.Round(rounding_from2_to_1(Math.Round((cal + CDbl(pmo)) / 4, 2)), 1), icu, nmat)
            Dim pmf As String = Str(Math.Round(rounding_from2_to_1(Math.Round((cal + IIf((CDbl(pmo) + CDbl(pexmo)) > 10, 10, (CDbl(pmo) + CDbl(pexmo)))) / 4, 2)), 1))

            '------------------------------------------------>
            '------------------------------------------------<
            'GUARDAMOS LA CALIFICACION FINAL EN LA BASE DE DATOS PARA QUE EN UN FUTURO SEA MAS FACIL SACARLA
            '------------------------------------------------<
            Dim incommand As New SqlCommand("INSERT INTO finales (curso,icu,alumno,grupo,calificacion,ciclo) VALUES " + _
                                            "('" + gedt.Rows(0).Item(0).ToString + "','" + icu + "','" + nm + "','" + gedt.Rows(0).Item(2).ToString + "','" + pmf + "','" + getactualcycle() + "')", sc)
            sc.Open()
            incommand.ExecuteNonQuery()
            sc.Close()
            '------------------------------------------------<
            'FIN DE GUARDADO
            '------------------------------------------------<
            '------------------------------------------------>


            objPage.Canvas.DrawText(pmo, pmov, objFont)
            objPage.Canvas.DrawText(pmf, pmfv, objFont)
            Dim nmt As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(nm, nmt, objFont)

            Dim pmt As String = "x=" & x4bar & "; y=" & ybar & "; width=495; alignment=left; size=10"

            Dim separator = objDoc.OpenImage(Server.MapPath("\cgiapp\img\reportesep.gif"))
            objPage.Canvas.DrawImage(separator, "x=170, y=" & ybar - 13)
            ybar = ybar - 14
        Next
        xbar = 45
        Select Case gedt.Rows(0).Item(3).ToString
            Case "0"
                Dim fy2 As String = "x=" & xbar + 210 & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                Dim fm2 As String = "x=" & xbar + 210 & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                Dim dp2 As String = "x=" & xbar + 210 & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(1).ToString & "  (ADJUNTO)", fm2, objFont)
                objPage.Canvas.DrawText("________________________", fy2, objFont)
                'objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp2, objFont)

                Dim fy As String = "x=" & xbar & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                Dim fm As String = "x=" & xbar & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                Dim dp As String = "x=" & xbar & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(4).ToString & "  (TITULAR)", fm, objFont)
                objPage.Canvas.DrawText("________________________", fy, objFont)
                objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp, objFont)
                'objPage.Canvas.DrawText("10 de Diciembre de 2011", dp, objFont)
            Case Else
                Dim fy As String = "x=" & xbar & "; y=" & ybar - 38 & "; width=495; alignment=center; size=10"
                Dim fm As String = "x=" & xbar & "; y=" & ybar - 50 & "; width=495; alignment=center; size=10"
                Dim dp As String = "x=" & xbar & "; y=" & ybar - 62 & "; width=495; alignment=center; size=10"
                objPage.Canvas.DrawText(gedt.Rows(0).Item(1).ToString & "  (TITULAR)", fm, objFont)
                objPage.Canvas.DrawText("________________________", fy, objFont)
                objPage.Canvas.DrawText(Format(Now, "dddd, dd MMMM yyyy"), dp, objFont)
                'objPage.Canvas.DrawText("10 de Diciembre de 2011", dp, objFont)
        End Select

        Dim nrep As String = icu & "-" & mes & getactualcycle()

        objPage.Canvas.DrawBarcode(nrep, "x=210; y=" & ybar - 92 & ",width=150,height=8,alignment=center,type=17")

        Dim path As String = Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(Server.MapPath("\cgiapp\formatos\calificaciones\" & nrep & ".pdf"), False)
        End If
        getdoc(nrep)
    End Sub

    Private Function text(ByVal qty As Double, ByVal icu As String, ByVal matr As String) As String
        If qty < 6.0 Then
            Dim c As New SqlConnection(Application("str"))
            Dim ct As New SqlDataAdapter("SELECT extra FROM eval_extraordinarios WHERE alumno='" + matr + "' and icu='" + icu + "' and ciclo='" + getactualcycle() + "'", c)
            Dim ctt As New DataTable
            c.Open()
            ct.Fill(ctt)
            c.Close()
            Select Case ctt.Rows.Count
                Case Is <> 0
                    text = ctt.Rows(0).Item(0).ToString & " (EXTRAORD)"
                Case Else
                    text = qty & " (EXTRAORD)"
            End Select
        Else
            Dim c As New SqlConnection(Application("str"))
            Dim ct As New SqlDataAdapter("SELECT extra FROM eval_extraordinarios WHERE alumno='" + matr + "' and icu='" + icu + "' and ciclo='" + getactualcycle() + "'", c)
            Dim ctt As New DataTable
            c.Open()
            ct.Fill(ctt)
            c.Close()
            Select Case ctt.Rows.Count
                Case Is <> 0
                    text = ctt.Rows(0).Item(0).ToString & " (EXTRAORD)"
                Case Else
                    text = qty.ToString
            End Select
        End If
    End Function

    Private Sub getdoc(ByVal nrep As String)
        Response.Redirect("~/dwndoc.aspx?file=" & nrep & "&type=calificaciones" & "&ext=.pdf")
    End Sub

    Private Sub elimina_sihay(ByVal icu As String, ByVal ide As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim esh As New SqlCommand("DELETE FROM eval_directpoint WHERE icu='" + icu + "' AND id_examen='" + ide + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        esh.ExecuteNonQuery()
        sc.Close()
    End Sub

End Class
