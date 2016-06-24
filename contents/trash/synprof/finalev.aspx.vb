Imports System.Data
Imports System.Data.SqlClient

Partial Class finalev
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

            Select Case chkexist_row("4", ddl_cursos.SelectedValue.ToString)
                Case 0
                    generate_testrow(ddl_cursos.SelectedValue.ToString, "4")
            End Select

            lbl_materia.Text = ddl_cursos.SelectedItem.ToString
            lbl_materiar.Text = ddl_cursos.SelectedItem.ToString
            llena_fechas(ddl_cursos.SelectedValue.ToString)
            hf_icu.Value = ddl_cursos.SelectedValue.ToString
            mv_cursos.ActiveViewIndex = 0
        End If
    End Sub

    Private Sub generate_testrow(ByVal icu As String, id_examen As String)
        Dim c As New SqlConnection(Application("str"))
        Dim gtr As New SqlCommand("INSERT INTO eval_parex_future (id_examen,icu,id_semana,selected,reportado,ciclo) VALUES " + _
                                  "('4','" + icu + "','" + get_entrega(id_examen) + "','0','0','" + getactualcycle() + "')", c)
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

    Private Function chkexist_row(ByVal id_examen As String, ByVal icu As String) As Integer
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
                Dim rec As New SqlCommand("UPDATE eval_parex_future SET selected=1, fecha='" + Format(CDate(sender.commandargument), "MM/dd/yyyy") + "' WHERE icu='" + hf_icu.Value + "' AND id_examen=4 AND ciclo='" + getactualcycle + "'", sc)
                sc.Open()
                rec.ExecuteNonQuery()
                sc.Close()
                llena_fechas(hf_icu.Value)
            Case "view"
                carga_alumnos(hf_icu.Value)
                retrieve_data(sender.Attributes("ustring"))
                cmd_definitivo.Enabled = False
                mv_cursos.ActiveViewIndex = 1
            Case "calificar"
                hf_fecha.Value = sender.commandargument
                cmd_definitivo.Enabled = True
                carga_alumnos(hf_icu.Value)
                mv_cursos.ActiveViewIndex = 1
        End Select
    End Sub

    Private Sub carga_alumnos(ByVal icu As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim cac As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        Dim cac2 As New SqlCommand("SELECT alumnos.matr, alumnos.fname, ISNULL(eval_nofinal_future.cause, 'ORDINARIO') AS cause, " + _
                                   "CASE WHEN eval_nofinal_future.cause IS NULL THEN '0' ELSE '1' END AS enable, " + _
                                   "CASE WHEN eval_nofinal_future.cause IS NULL THEN NULL ELSE '5' END AS calif FROM alumnos LEFT OUTER JOIN " + _
                                   "eval_nofinal_future ON eval_nofinal_future.ciclo = alumnos.ciclo AND eval_nofinal_future.matr = alumnos.matr AND " + _
                                   "eval_nofinal_future.icu = '" + icu + "' WHERE (alumnos.ciclo = '" + getactualcycle() + "') AND (alumnos.grupo = '" + cac.ExecuteScalar.ToString + "') " + _
                                   "ORDER BY alumnos.osep", sc)
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
        '--INSERT INTO eval_parex_future
        '              (id_examen, icu, id_semana, selected, reportado, ciclo)
        'SELECT     '2' AS id_examen, icu, '8' AS id_semana, '0' AS selected, '0' AS reportado, '"+getactualcycle+"' AS ciclo
        'FROM         eval_parex_future AS eval_parex_future_1 where id_examen='3'
        'ORDER BY icu

        Dim sc As New SqlConnection(Application("str"))
        Dim chff As New SqlCommand("SELECT COUNT(*) FROM eval_parex_future WHERE icu='" + icu + "' AND selected=1 AND ciclo='" + getactualcycle() + "' AND id_examen=4", sc)
        sc.Open()
        Dim found As String = chff.ExecuteScalar
        sc.Close()
        Select Case found
            Case "1"
                Dim lfc As New SqlCommand("SELECT fecha,id_dia as dayclass,selected as estado,reportado,ustring FROM eval_parex_future WHERE icu='" + icu + "' AND id_examen='4' AND ciclo='" + getactualcycle() + "'", sc)
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
                Dim lfc As New SqlCommand("SELECT dbo.eval_asreportes_future.fecha, dbo.eval_reportes_estados.string, dbo.eval_asreportes_future.estado, dbo.eval_reportes_estados.imageurl,dbo.eval_asreportes_future.dayclass " + _
                                  "FROM dbo.eval_asreportes_future INNER JOIN dbo.eval_reportes_estados ON dbo.eval_asreportes_future.estado = dbo.eval_reportes_estados.id_estado WHERE (dbo.eval_asreportes_future.icu = '" + icu + "') " + _
                                  "AND (dbo.eval_asreportes_future.semana='" + getsemana(icu) + "')  AND (dbo.eval_asreportes_future.ciclo = '" + getactualcycle() + "') ORDER BY dbo.eval_asreportes_future.fecha", sc)
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

    Private Function getsemana(ByVal icu As String) As String
        Dim v As New SqlConnection(Application("str"))
        Dim gs As New SqlCommand("SELECT id_semana FROM eval_parex_future WHERE id_examen='4' and icu='" + icu + "' and ciclo='" + getactualcycle() + "'", v)
        v.Open()
        getsemana = gs.ExecuteScalar.ToString
        v.Close()
    End Function

    Private Function checkcal() As Integer
        Dim ck As Integer
        For ck = 0 To gv_alumnos.Rows.Count - 1
            Dim t1 As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_pex"), TextBox)
            If t1.Text = "" Then
                checkcal = 1
                Exit For
            ElseIf CDbl(t1.Text) > 10 Then
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
                lbl_msg.Text = "Verifique que todas las calificaciones estan correctamente escritas y que son en base 10."
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
            Dim icc As New SqlCommand("INSERT INTO eval_pexcal_future (ustring,alumno,calif,id_examen) VALUES ('" + identificator + "'," + _
                                  "'" + m + "','" + t.Text.ToString + "','4')", sc)
            Dim icc2 As New SqlCommand("UPDATE eval_parex_future SET ustring='" + identificator + "', reportado='1' ,id_dia='" + Format(Now, "MM/dd/yyyy") + "' " + _
                                       "WHERE icu='" + icu + "' AND fecha='" + Format(CDate(hf_fecha.Value), "MM/dd/yyyy") + "' AND ciclo='" + getactualcycle() + "'", sc)
            sc.Open()
            icc.ExecuteNonQuery()
            icc2.ExecuteNonQuery()
            sc.Close()
        Next
    End Sub

    Private Function genstr() As String
        genstr = hf_icu.Value & Now.Minute.ToString & Now.Millisecond & Now.DayOfYear & Now.Day & Now.Month & Now.Year
    End Function

    Private Function damegrupo(ByVal icu As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim dmgc As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        damegrupo = dmgc.ExecuteScalar
        sc.Close()
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
        Dim gtsc As New SqlCommand("SELECT ustring FROM eval_asreportes_future WHERE icu='" + icu + "' AND fecha='" + fecha + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        getstring = gtsc.ExecuteScalar
        sc.Close()
    End Function


End Class