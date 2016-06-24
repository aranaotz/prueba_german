Imports System.Data
Imports System.Data.SqlClient

Partial Class parcialtest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fill_courses(gc)
        End If
    End Sub

    Private Function getactualcycle() As String
        Dim v As New SqlConnection(Application("str"))
        Dim cycle As New SqlCommand("SELECT ciclo FROM general_ciclos WHERE active=1", v)
        v.Open()
        getactualcycle = cycle.ExecuteScalar
        v.Close()
    End Function

    Private Function gc() As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim aingcomm As New SqlCommand("SELECT c_user FROM users WHERE id_usr='" + Session("usrcgi200Xstr") + "'", sqlconn)
        sqlconn.Open()
        gc = aingcomm.ExecuteScalar()
        sqlconn.Close()
    End Function

    Private Sub fill_courses(ByVal usr As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim fcc As New SqlCommand("SELECT materia + ' (' + grupo + ')' as text,icu FROM future_inf_icu WHERE prof='" + usr + "' AND ciclo='" + getactualcycle() + "' ORDER BY icu", sc)
        Dim fcda As New SqlDataAdapter(fcc)
        Dim fcdt As New DataTable
        sc.Open()
        fcda.Fill(fcdt)
        sc.Close()
        ddl_cursos.DataSource = fcdt
        ddl_cursos.DataTextField = "text"
        ddl_cursos.DataValueField = "icu"
        ddl_cursos.DataBind()
        Dim selectnull As New ListItem
        selectnull.Text = " :: Seleccione un curso ::"
        selectnull.Value = "0"
        ddl_cursos.Items.Insert(0, selectnull)
    End Sub

    Protected Sub cmd_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_mostrar.Click
        If ddl_cursos.SelectedIndex <> 0 Then
            hf_smes_mpe.Show()
        End If
    End Sub

    Protected Sub cmd_exs_Click(sender As Object, e As System.EventArgs) Handles cmd_exs.Click
        Select Case chkexist_row(ddl_examen.SelectedValue.ToString, ddl_cursos.SelectedValue.ToString)
            Case False
                generate_testrow(ddl_cursos.SelectedValue.ToString, ddl_examen.SelectedValue.ToString)
        End Select
        lbl_materia.Text = ddl_cursos.SelectedItem.ToString
        lbl_materiar.Text = ddl_cursos.SelectedItem.ToString
        lbl_id_examen.Text = ddl_examen.SelectedItem.Text
        llena_fechas(ddl_cursos.SelectedValue.ToString)
        hf_icu.Value = ddl_cursos.SelectedValue.ToString
        mv_cursos.ActiveViewIndex = 0
    End Sub

    Private Sub generate_testrow(ByVal icu As String, id_examen As String)
        Dim c As New SqlConnection(Application("str"))
        Dim gtr As New SqlCommand("INSERT INTO eval_parex_future (id_examen,icu,id_semana,selected,reportado,ciclo) VALUES " + _
                                  "('" + id_examen + "','" + icu + "','" + get_semana() + "','0','0','" + getactualcycle() + "')", c)
        c.Open()
        gtr.ExecuteNonQuery()
        c.Close()
    End Sub

    Private Function get_entrega(ByVal id_examen As String) As String
        Dim c As New SqlConnection(Application("str"))
        Dim ge As New SqlCommand("SELECT id_entrega FROM future_eval_dates WHERE ciclo='" + getactualcycle() + "' and id_examen='" + id_examen + "'", c)
        c.Open()
        get_entrega = ge.ExecuteScalar.ToString
        c.Close()
    End Function

    Private Function chkexist_row(ByVal id_examen As String, ByVal icu As String) As Boolean
        Dim c As New SqlConnection(Application("str"))
        Dim chr As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN '1' ELSE '0' END boool FROM eval_parex_future WHERE (ciclo='" + getactualcycle() + "') and (id_examen='" + id_examen + "') and (icu='" + icu + "')", c)
        c.Open()
        chkexist_row = chr.ExecuteScalar.ToString
        c.Close()
    End Function

    Protected Sub docommand(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case sender.commandname
            Case "reportar"
                Dim sc As New SqlConnection(Application("str"))
                'ID_EXAMEN
                Dim rec As New SqlCommand("UPDATE eval_parex_future SET selected=1, fecha='" + Format(CDate(sender.commandargument), "MM/dd/yyyy") + "' WHERE icu='" + hf_icu.Value + "' AND id_examen='" + ddl_examen.selectedvalue.tostring + "' AND ciclo='" + getactualcycle() + "'", sc)
                sc.Open()
                rec.ExecuteNonQuery()
                sc.Close()
                llena_fechas(hf_icu.Value)
            Case "view"
                'carga_alumnos(hf_icu.Value)
                'retrieve_data(sender.Attributes("ustring"))
                gv_alumnos.DataSource = retrieve_data_v2(sender.Attributes("ustring"), getactualcycle)
                gv_alumnos.DataBind()
                lbl_pr.Text = Str(extra_point_count(sender.Attributes("ustring")))
                cmd_definitivo.Enabled = False
                mv_cursos.ActiveViewIndex = 1
            Case "calificar"
                hf_fecha.Value = sender.commandargument
                cmd_definitivo.Enabled = True
                borra_puntos_extras_no_guardados()
                lbl_pr.Text = Str(extra_point_count(sender.Attributes("ustring")))
                carga_alumnos(hf_icu.Value)
                mv_cursos.ActiveViewIndex = 1
        End Select
    End Sub

    Private Sub borra_puntos_extras_no_guardados()
        Dim c As New SqlConnection(Application("str"))
        Dim cpeng As New SqlCommand("DELETE FROM extra_points WHERE icu='" + hf_icu.Value + "' AND id_examen='" + ddl_examen.SelectedValue.ToString + "' AND ciclo='" + getactualcycle() + "'", c)
        c.Open()
        cpeng.ExecuteNonQuery()
        c.Close()
    End Sub

    Private Function esactual() As Boolean
        Dim c As New SqlConnection(Application("str"))
        'Dim ga As New SqlCommand("SELECT 
    End Function

    Private Sub carga_alumnos(ByVal icu As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim cac As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "' and ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        Dim cac2 As New SqlCommand("SELECT matr,fname,'" + IIf(ddl_examen.SelectedValue = 4, "0", "1") + "' AS enablee, '0' as checked, '' as justify, " + _
                                   "'' as calif, '1' as justenabled, '1' as calenabled FROM alumnos WHERE ciclo='" + getactualcycle() + "' AND grupo='" + cac.ExecuteScalar + "' AND status='AC' " + _
                                   "ORDER BY osep", sc)
        Dim cac2da As New SqlDataAdapter(cac2)
        Dim cac2dt As New DataTable
        cac2da.Fill(cac2dt)
        sc.Close()
        gv_alumnos.DataSource = cac2dt
        gv_alumnos.DataBind()
    End Sub

    Private Sub llena_fechas(ByVal icu As String)
        'PARA UN NUEVO EXAMEN
        '1. CAMBIAR ID_EXAMEN en cada consulta de abajo
        '2. CAMBIAR SEMANA (en la tabla de fechas es id_entrega)
        '3. EN DOCOMMAND CAMBIAR ID_EXAMEN
        '4. EN INSERT_CAL CAMBIAR ID_EXAMEN
        '5. INSERTAR EN EVAL_PAREX_FUTURE
        'INSERT INTO eval_parex_future
        '             (id_examen, icu, id_semana, selected, reportado, ciclo)
        'SELECT     '3' AS id_examen, icu, '12' AS id_semana, '0' AS selected, '0' AS reportado, '2010B' AS ciclo
        'FROM         eval_parex_future AS eval_parex_future_1'
        'WHERE     (ciclo = '2010B') AND (id_examen = '2')
        'ORDER BY icu

        Dim sc As New SqlConnection(Application("str"))
        'ID_EXAMEN
        Dim chff As New SqlCommand("SELECT COUNT(*) FROM eval_parex_future WHERE icu='" + icu + "' AND selected=1 AND ciclo='" + getactualcycle() + "' AND id_examen='" + ddl_examen.selectedvalue.tostring + "'", sc)
        sc.Open()
        Dim found As String = chff.ExecuteScalar
        sc.Close()
        Select Case found
            Case "1"
                'ID_EXAMEN
                Dim lfc As New SqlCommand("SELECT fecha,id_dia as dayclass,selected as estado,reportado,ustring FROM eval_parex_future WHERE icu='" + icu + "' AND id_examen='" + ddl_examen.selectedvalue.tostring + "' AND ciclo='" + getactualcycle() + "'", sc)
                Dim lfda As New SqlDataAdapter(lfc)
                Dim lfdt As New DataTable
                sc.Open()
                lfda.Fill(lfdt)
                sc.Close()
                dl_fechas.DataSource = lfdt
                dl_fechas.DataBind()
                Dim item As LinkButton = CType(dl_fechas.Items(0).FindControl("lb_fechas"), LinkButton)
                Dim photo As Image = CType(dl_fechas.Items(0).FindControl("im_st"), Image)
                Dim itemcbe As AjaxControlToolkit.ConfirmButtonExtender = CType(dl_fechas.Items(0).FindControl("lb_fechas_cbe"), AjaxControlToolkit.ConfirmButtonExtender)
                itemcbe.Enabled = False
                item.Attributes.Add("icu", icu)
                item.Attributes.Add("reportado", lfdt.Rows(0).Item(3).ToString)
                item.Attributes.Add("ustring", lfdt.Rows(0).Item(4).ToString)
                Select Case lfdt.Rows(0).Item(3).ToString
                    Case Is <> "False"
                        item.CommandName = "view"
                        photo.ImageUrl = "img/statusgren.png"
                    Case Else
                        item.CommandName = "calificar"
                        photo.ImageUrl = "img/temporal.png"
                End Select
            Case Else
                Dim lfc As New SqlCommand("SELECT dbo.eval_asreportes_future.fecha, dbo.eval_reportes_estados.string, dbo.eval_asreportes_future.estado, dbo.eval_reportes_estados.imageurl,dbo.eval_asreportes_future.dayclass, " + _
                                  "dbo.eval_asreportes_future.ciclo FROM dbo.eval_asreportes_future INNER JOIN dbo.eval_reportes_estados ON dbo.eval_asreportes_future.estado = dbo.eval_reportes_estados.id_estado WHERE (dbo.eval_asreportes_future.icu = '" + icu + "') " + _
                                  "AND (dbo.eval_asreportes_future.semana='" + get_semana() + "') AND (dbo.eval_asreportes_future.ciclo = '" + getactualcycle() + "') ORDER BY dbo.eval_asreportes_future.fecha", sc)
                Dim lfda As New SqlDataAdapter(lfc)
                Dim lfdt As New DataTable
                sc.Open()
                lfda.Fill(lfdt)
                sc.Close()
                dl_fechas.DataSource = lfdt
                dl_fechas.DataBind()
                Dim irw As Integer
                For irw = 0 To dl_fechas.Items.Count - 1
                    Dim item As LinkButton = CType(dl_fechas.Items(irw).FindControl("lb_fechas"), LinkButton)
                    Dim photo As Image = CType(dl_fechas.Items(irw).FindControl("im_st"), Image)
                    Dim itemcbe As AjaxControlToolkit.ConfirmButtonExtender = CType(dl_fechas.Items(irw).FindControl("lb_fechas_cbe"), AjaxControlToolkit.ConfirmButtonExtender)
                    itemcbe.Enabled = True
                    photo.ImageUrl = "~/img/what.gif"
                    item.CommandName = "reportar"
                Next
        End Select
    End Sub

    Private Function get_semana() As String
        Dim c As New SqlConnection(Application("str"))
        Dim gs As New SqlCommand("SELECT id_entrega FROM future_eval_dates WHERE ciclo='" + getactualcycle() + "' AND id_examen='" + ddl_examen.selectedvalue.tostring + "'", c)
        c.Open()
        get_semana = gs.ExecuteScalar.ToString
        c.Close()
    End Function

    Private Function checkcal() As Integer
        Dim ck As Integer
        For ck = 0 To gv_alumnos.Rows.Count - 1
            Dim t1 As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_pex"), TextBox)
            Dim t2 As CheckBox = CType(gv_alumnos.Rows(ck).FindControl("cbx_extrap"), CheckBox)
            Dim t3 As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_extrap"), TextBox)
            If t1.Text = "" Then
                checkcal = 1
                Exit For
            ElseIf CDbl(t1.Text) > 10 Then
                checkcal = 1
                Exit For
            ElseIf t2.Checked And t3.Text = "" Then
                checkcal = 1
                Exit For
            Else
                checkcal = 0
            End If
        Next
    End Function

    Protected Sub cmd_definitivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_definitivo.Click
        Select Case checkcal()
            Case 1
                lbl_msg.Text = "Verifique que todas las calificaciones estan correctamente escritas y que son en base 10. Si asignó puntos extra verifique que contegan su justificación."
                hf_msg_mpe.Show()
            Case Else
                insert_cal(hf_icu.Value, "2")
                llena_fechas(hf_icu.Value)
                mv_cursos.ActiveViewIndex = 0
        End Select
    End Sub

    Private Sub insert_cal(ByVal icu As String, ByVal typ As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim identificator As String = genstr()
        Dim g As String = damegrupo(hf_icu.Value)
        Dim ck As Integer
        For ck = 0 To gv_alumnos.Rows.Count - 1
            Dim m As String = CType(gv_alumnos.Rows(ck).FindControl("hf_matr"), HiddenField).Value
            Dim t As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_pex"), TextBox)

            'ID_EXAMEN
            Dim icc As New SqlCommand("INSERT INTO eval_pexcal_future (ustring,alumno,calif,id_examen,ciclo) VALUES ('" + identificator + "'," + _
                                  "'" + m + "','" + t.Text.ToString + "','" + ddl_examen.selectedvalue.tostring + "','" + getactualcycle() + "')", sc)

            Dim icc2 As New SqlCommand("UPDATE eval_parex_future SET ustring='" + identificator + "', reportado='1' ,id_dia='" + Format(Now, "MM/dd/yyyy") + "' " + _
                                       "WHERE icu='" + icu + "' AND fecha='" + Format(CDate(hf_fecha.Value), "MM/dd/yyyy") + "' AND id_examen='" + ddl_examen.selectedvalue.tostring + "'", sc)
            sc.Open()
            icc.ExecuteNonQuery()
            icc2.ExecuteNonQuery()
            Dim t2 As CheckBox = CType(gv_alumnos.Rows(ck).FindControl("cbx_extrap"), CheckBox)
            If t2.Checked = True Then
                Dim t3 As String = CType(gv_alumnos.Rows(ck).FindControl("tbx_extrap"), TextBox).Text
                Dim icc0 As New SqlCommand("INSERT INTO extra_points (alumno,point,justification,icu,id_examen,ciclo,ustring) VALUES ('" + m + "','1','" + t3 + "', " + _
                                  "'" + hf_icu.Value + "','" + get_mes() + "','" + getactualcycle() + "','" + identificator + "')", sc)
                icc0.ExecuteNonQuery()
            End If
            sc.Close()
        Next
    End Sub

    Private Function get_mes() As String
        Dim c As New SqlConnection(Application("str"))
        Dim gm As New SqlCommand("SELECT id_mes FROM future_eval_dates WHERE ciclo='" + getactualcycle() + "' AND id_examen='" + ddl_examen.selectedvalue.tostring + "'", c)
        c.Open()
        get_mes = gm.ExecuteScalar.ToString
        c.Close()
    End Function

    Protected Sub cbx_extrap_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim k As Integer = lbl_pr.Text
        Select Case k
            Case Is <= 0
                Select Case sender.checked
                    Case True
                        sender.checked = False
                    Case Else
                        k = k + 1
                End Select
            Case Else
                Select Case sender.checked
                    Case True
                        k = k - 1
                    Case Else
                        k = k + 1
                End Select
        End Select
        lbl_pr.Text = k
    End Sub

    'Private Sub activate_enable()
    '    Select Case CInt(lbl_pr.Text)
    '        Case Is <= 0
    '
    'enable_cbx()
    '        End Select
    '    End Sub
    '
    'Private Sub enable_cbx()
    ' Dim cz As Integer
    '     For cz = 0 To gv_alumnos.Rows.Count - 1
    ' Dim cx As CheckBox = CType(gv_alumnos.Rows(cz).FindControl("cbx_extrap"), CheckBox)
    '         Select Case cx.Checked
    '             Case False = cx.Enabled = False
    '         End Select
    '     Next
    ' End Sub

    'Protected Sub restpoint(ByVal sender As Object, ByVal e As System.EventArgs)
    'Dim k As Integer = lbl_pr.Text
    '   Select Case sender.checked
    '      Case True
    '         k = k - 1
    '    Case Else
    '       k = k + 1
    'End Select
    '  lbl_pr.Text = k
    'End Sub

    Private Function genstr() As String
        genstr = hf_icu.Value & Now.Minute.ToString & Now.Millisecond & Now.DayOfYear & Now.Day & Now.Month & Now.Year
    End Function

    Private Function damegrupo(ByVal icu As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim dmgc As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "'", sc)
        sc.Open()
        damegrupo = dmgc.ExecuteScalar
        sc.Close()
    End Function

    Private Function retrieve_data_v2(ByVal ustring As String, ByVal ciclo As String) As DataTable
        Dim s As New SqlConnection(Application("str"))
        Dim rtv2 As New SqlDataAdapter("SELECT alumnos.matr, alumnos.fname, eval_pexcal_future.calif, ISNULL(extra_points.point, '0') AS checked, '0' as enablee, " + _
                                       "ISNULL(extra_points.justification, '-') AS justify, '0' as justenabled, '0' as calenabled FROM alumnos INNER JOIN eval_pexcal_future ON alumnos.matr = " + _
                                       "eval_pexcal_future.alumno LEFT OUTER JOIN extra_points ON alumnos.matr = extra_points.alumno AND " + _
                                       "eval_pexcal_future.ustring = extra_points.ustring WHERE (alumnos.ciclo = '" + ciclo + "') AND (alumnos.status = 'AC') AND " + _
                                       "(eval_pexcal_future.ustring = '" + ustring + "') ORDER BY eval_pexcal_future.id", s)
        Dim rtv2dt As New DataTable
        s.Open()
        rtv2.Fill(rtv2dt)
        s.Close()
        retrieve_data_v2 = rtv2dt
    End Function

    Private Function extra_point_count(ByVal ustring As String) As Integer
        Dim s As New SqlConnection(Application("str"))
        Dim epc As New SqlCommand("SELECT count(*) veces from extra_points where ustring='" + ustring + "'", s)
        s.Open()
        extra_point_count = 5 - epc.ExecuteScalar
        s.Close()
    End Function

    Private Sub retrieve_data(ByVal ustring As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim rditer As Integer
        For rditer = 0 To gv_alumnos.Rows.Count - 1
            Dim matr As String = CType(gv_alumnos.Rows(rditer).FindControl("hf_matr"), HiddenField).Value
            Dim textcal As TextBox = CType(gv_alumnos.Rows(rditer).FindControl("tbx_pex"), TextBox)
            Dim rdc As New SqlCommand("SELECT calif FROM eval_pexcal_future WHERE ustring='" + ustring + "' AND alumno='" + matr + "'", sc)
            sc.Open()
            textcal.Text = rdc.ExecuteScalar
            sc.Close()
        Next
    End Sub

    Private Function getstring(ByVal icu As String, ByVal fecha As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gtsc As New SqlCommand("SELECT ustring FROM eval_asreportes_future WHERE icu='" + icu + "' AND fecha='" + fecha + "'", sc)
        sc.Open()
        getstring = gtsc.ExecuteScalar
        sc.Close()
    End Function


End Class
