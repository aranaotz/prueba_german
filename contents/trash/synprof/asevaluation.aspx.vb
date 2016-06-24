Imports System.Data
Imports System.Data.SqlClient

Partial Class asevaluation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fill_courses(gc)
        End If
    End Sub

    Private Function gc() As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim aingcomm As New SqlCommand("SELECT c_user FROM users WHERE id_usr='" + Session("usrcgi200Xstr") + "'", sqlconn)
        sqlconn.Open()
        gc = aingcomm.ExecuteScalar()
        sqlconn.Close()
    End Function

    Private Function getactualcycle() As String

        Dim v As New SqlConnection(Application("str"))
        Dim cycle As New SqlCommand("SELECT ciclo FROM general_ciclos WHERE active=1", v)
        v.Open()
        getactualcycle = cycle.ExecuteScalar
        v.Close()
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

    Private Sub llena_fechas(ByVal icu As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim lfc As New SqlCommand("SELECT dbo.eval_asreportes_future.fecha, dbo.eval_reportes_estados.string, dbo.eval_asreportes_future.estado, dbo.eval_reportes_estados.imageurl,dbo.eval_asreportes_future.dayclass " + _
                                  "FROM dbo.eval_asreportes_future INNER JOIN dbo.eval_reportes_estados ON dbo.eval_asreportes_future.estado = dbo.eval_reportes_estados.id_estado WHERE (dbo.eval_asreportes_future.icu = '" + icu + "') " + _
                                  "AND (dbo.eval_asreportes_future.ciclo='" + getactualcycle() + "') ORDER BY dbo.eval_asreportes_future.fecha", sc)
        Dim lfda As New SqlDataAdapter(lfc)
        Dim lfdt As New DataTable
        sc.Open()
        lfda.Fill(lfdt)
        sc.Close()
        dl_fechas.DataSource = lfdt
        dl_fechas.DataBind()
    End Sub

    Protected Sub cmd_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_mostrar.Click
        If ddl_cursos.SelectedIndex <> 0 Then
            lbl_materia.Text = ddl_cursos.SelectedItem.ToString
            llena_fechas(ddl_cursos.SelectedValue.ToString)
            hf_icu.Value = ddl_cursos.SelectedValue.ToString
            mv_cursos.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub docommand(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case sender.commandname
            Case "reportar"
                Select Case CDate(sender.commandargument)
                    'ooooooooooooooMMMMMMMMMMOOOOOOOOOOOOOOOOOOOOOOOOO
                    Case Is > Now

                        lbl_msg.Text = "Está intentando calificar una fecha posterior a la actual. Esto no se permite en SADIN por motivos de confiabilidad en la información."
                        'lbl_msg.Text = "El sistema e encuentra en cierre de Cuatrimestre. Acuda a direccion Académica para cualquier alcaracion."
                        hf_msg_mpe.Show()
                    Case Else
                        Select Case sender.tabindex
                            Case 1
                                lbl_materiar.Text = lbl_materia.Text
                                lbl_fecha.Text = Format(CDate(sender.commandargument), "dddd dd MMMM yyyy").ToUpper
                                hf_fecha.Value = sender.commandargument
                                carga_alumnos(hf_icu.Value, sender.validationgroup)

                                retrieve_data(getstring(hf_icu.Value, Format(CDate(sender.commandargument), "MM/dd/yyyy")))
                                cmd_temporal.Enabled = True
                                cmd_definitivo.Enabled = True
                                mv_cursos.ActiveViewIndex = 1
                            Case 2
                                lbl_materiar.Text = lbl_materia.Text
                                lbl_fecha.Text = Format(CDate(sender.commandargument), "dddd dd MMMM yyyy").ToUpper
                                hf_fecha.Value = sender.commandargument
                                carga_alumnos(hf_icu.Value, sender.validationgroup)

                                retrieve_data(getstring(hf_icu.Value, Format(CDate(sender.commandargument), "MM/dd/yyyy")))
                                cmd_temporal.Enabled = False
                                cmd_definitivo.Enabled = False
                                mv_cursos.ActiveViewIndex = 1
                                'bloquear
                            Case Else
                                lbl_materiar.Text = lbl_materia.Text
                                lbl_fecha.Text = Format(CDate(sender.commandargument), "dddd dd MMMM yyyy").ToUpper
                                hf_fecha.Value = sender.commandargument
                                'tbx_i1.Text = ""
                                'tbx_i2.Text = ""
                                'tbx_i3.Text = ""
                                'obtener_tipos(hf_icu.Value)
                                carga_alumnos(hf_icu.Value, sender.validationgroup)
                                cmd_temporal.Enabled = True
                                cmd_definitivo.Enabled = True
                                mv_cursos.ActiveViewIndex = 1
                        End Select
                End Select
            Case "senddef"
                Select Case sender.TabIndex
                    Case "1"
                        definitivo_fast(hf_icu.Value, sender.CommandArgument)
                    Case "2"
                        lbl_msg.Text = "No puede enviar un reporte cuando su estado es DEFINITIVO."
                        hf_msg_mpe.Show()
                    Case Else
                        lbl_msg.Text = "Para que ésta función se ejecute, el reporte debe tener estado TEMPORAL."
                        hf_msg_mpe.Show()
                End Select
        End Select
    End Sub

    Private Sub carga_alumnos(ByVal icu As String, ByVal dy As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim cac As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        Dim cac2 As New SqlCommand("SELECT matr,fname FROM alumnos WHERE ciclo='" + getactualcycle() + "' AND grupo='" + cac.ExecuteScalar + "' AND status='AC' ORDER BY osep", sc)
        Dim cac2da As New SqlDataAdapter(cac2)
        Dim cac2dt As New DataTable
        cac2da.Fill(cac2dt)
        sc.Close()
        gv_alumnos.DataSource = cac2dt
        gv_alumnos.DataBind()
        Dim cac3 As New SqlCommand("SELECT dbo.sched_horas.alias,dbo.sched_trademark.dh FROM dbo.sched_trademark INNER JOIN dbo.sched_horas " + _
                                   "ON dbo.sched_trademark.dh = dbo.sched_horas.id_hora WHERE (dbo.sched_trademark.icu = '" + icu + "') AND " + _
                                   "(dbo.sched_trademark.dayclass = '" + dy + "') AND (dbo.sched_trademark.assig <> '0') AND (dbo.sched_trademark.ciclo = '" + getactualcycle() + "')", sc)
        Dim cac3da As New SqlDataAdapter(cac3)
        Dim cac3dt As New DataTable
        sc.Open()
        cac3da.Fill(cac3dt)
        sc.Close()
        Dim cak As Integer
        For cak = 0 To gv_alumnos.Rows.Count - 1
            Dim dl_eval As DataList = CType(gv_alumnos.Rows(cak).FindControl("dl_eval"), DataList)
            dl_eval.DataSource = cac3dt
            dl_eval.DataBind()
        Next
    End Sub

    Protected Sub cmd_temporal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_temporal.Click
        insert_cal(hf_icu.Value, "1")
        llena_fechas(hf_icu.Value)
        mv_cursos.ActiveViewIndex = 0
    End Sub

    Protected Sub cmd_definitivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_definitivo.Click
        insert_cal(hf_icu.Value, "2")
        llena_fechas(hf_icu.Value)
        mv_cursos.ActiveViewIndex = 0
    End Sub

    Private Sub definitivo_fast(ByVal icu As String, ByVal fecha As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim dfc As New SqlCommand("UPDATE eval_asreportes_future SET estado='2', upddate='" + Format(Now, "MM/dd/yyyy") + "' " + _
                                          "WHERE icu='" + icu + "' AND fecha='" + Format(CDate(fecha), "MM/dd/yyyy") + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        dfc.ExecuteNonQuery()
        sc.Close()
        llena_fechas(icu)
    End Sub

    Private Sub insert_cal(ByVal icu As String, ByVal typ As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim identificator As String = genstr()
        Dim g As String = damegrupo(hf_icu.Value)
        Dim ck As Integer
        For ck = 0 To gv_alumnos.Rows.Count - 1
            Dim dl_eval As DataList = CType(gv_alumnos.Rows(ck).FindControl("dl_eval"), DataList)
            Dim key As Integer
            For key = 0 To dl_eval.Items.Count - 1
                Dim m As String = CType(gv_alumnos.Rows(ck).FindControl("hf_matr"), HiddenField).Value
                Dim t As DropDownList = CType(dl_eval.Items(key).FindControl("ddl_eval"), DropDownList)
                Dim h As Label = CType(dl_eval.Items(key).FindControl("lbl_hora"), Label)
                Dim icc As New SqlCommand("INSERT INTO eval_ast_future (ustring,alumno,id_hora,eval_cal,tipo,grupo,dateday) VALUES ('" + identificator + "'," + _
                                      "'" + m + "','" + h.TabIndex.ToString + "','" + t.SelectedValue.ToString + "','" + typ + "','" + g + "','" + Format(CDate(hf_fecha.Value), "MM/dd/yyyy") + "')", sc)
                Dim icc2 As New SqlCommand("UPDATE eval_asreportes_future SET ustring='" + identificator + "', estado='" + typ + "' ,upddate='" + Format(Now, "MM/dd/yyyy") + "' " + _
                                           "WHERE icu='" + icu + "' AND fecha='" + Format(CDate(hf_fecha.Value), "MM/dd/yyyy") + "' AND ciclo='" + getactualcycle() + "'", sc)
                sc.Open()
                icc.ExecuteNonQuery()
                icc2.ExecuteNonQuery()
                sc.Close()
            Next
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
            Dim dlev As DataList = CType(gv_alumnos.Rows(rditer).FindControl("dl_eval"), DataList)
            Dim rdi As Integer
            For rdi = 0 To dlev.Items.Count - 1
                Dim idh As String = CType(dlev.Items(rdi).FindControl("lbl_hora"), Label).TabIndex.ToString
                Dim ddl As DropDownList = CType(dlev.Items(rdi).FindControl("ddl_eval"), DropDownList)
                Dim rdc As New SqlCommand("SELECT eval_cal FROM eval_ast_future WHERE ustring='" + ustring + "' AND alumno='" + matr + "' AND id_hora='" + idh + "'", sc)
                sc.Open()
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(rdc.ExecuteScalar))
                sc.Close()
            Next
        Next
    End Sub

    Private Function getstring(ByVal icu As String, ByVal fecha As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gtsc As New SqlCommand("SELECT ustring FROM eval_asreportes_future WHERE icu='" + icu + "' AND fecha='" + fecha + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        getstring = gtsc.ExecuteScalar
        sc.Close()
    End Function

    Protected Sub ib_otrafecha_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ib_otrafecha.Click
        mv_cursos.ActiveViewIndex = 0
    End Sub
End Class
