Imports System.Data
Imports System.Data.SqlClient

Partial Class cevaluation
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
            lbl_materia.Text = ddl_cursos.SelectedItem.ToString
            hf_icu.Value = ddl_cursos.SelectedValue.ToString
            llena_fechas(ddl_cursos.SelectedValue.ToString)
        End If
        mv_cursos.ActiveViewIndex = 0
    End Sub

    Private Sub llena_fechas(ByVal icu As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim lfc As New SqlCommand("SELECT dbo.eval_reportes_future.fecha, dbo.eval_reportes_estados.string, dbo.eval_reportes_future.estado, dbo.eval_reportes_estados.imageurl " + _
                                  "FROM dbo.eval_reportes_future INNER JOIN dbo.eval_reportes_estados ON dbo.eval_reportes_future.estado = dbo.eval_reportes_estados.id_estado WHERE " + _
                                  "(dbo.eval_reportes_future.icu = '" + icu + "') AND (dbo.eval_reportes_future.ciclo='" + getactualcycle() + "')", sc)
        Dim lfda As New SqlDataAdapter(lfc)
        Dim lfdt As New DataTable
        sc.Open()
        lfda.Fill(lfdt)
        sc.Close()
        dl_fechas.DataSource = lfdt
        dl_fechas.DataBind()
    End Sub

    Protected Sub docommand(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case sender.commandname
            Case "reportar"
                Select Case CDate(sender.commandargument)
                    Case Is > Now
                        lbl_msg.Text = "Está intentando calificar una fecha posterior a la actual. Esto no se permite en SADIN por motivos de confiabilidad en la información."
                        hf_msg_mpe.Show()
                    Case Else
                        Select Case sender.tabindex
                            Case 1
                                lbl_materiar.Text = lbl_materia.Text
                                lbl_fecha.Text = Format(CDate(sender.commandargument), "dddd dd MMMM yyyy").ToUpper
                                hf_fecha.Value = sender.commandargument
                                Dim cdn As String = obtener_tipos(hf_icu.Value)
                                retrieve_data(getstring(hf_icu.Value, Format(CDate(sender.commandargument), "MM/dd/yyyy")))
                                cmd_temporal.Enabled = True
                                cmd_definitivo.Enabled = True
                                mv_cursos.ActiveViewIndex = 1
                            Case 2
                                lbl_materiar.Text = lbl_materia.Text
                                lbl_fecha.Text = Format(CDate(sender.commandargument), "dddd dd MMMM yyyy").ToUpper
                                hf_fecha.Value = sender.commandargument
                                Dim cdn As String = obtener_tipos(hf_icu.Value)
                                retrieve_data(getstring(hf_icu.Value, Format(CDate(sender.commandargument), "MM/dd/yyyy")))
                                cmd_temporal.Enabled = False
                                cmd_definitivo.Enabled = False
                                mv_cursos.ActiveViewIndex = 1
                                'bloquear
                            Case Else
                                lbl_materiar.Text = lbl_materia.Text
                                lbl_fecha.Text = Format(CDate(sender.commandargument), "dddd dd MMMM yyyy").ToUpper
                                hf_fecha.Value = sender.commandargument
                                tbx_i1.Text = ""
                                tbx_i2.Text = ""
                                tbx_i3.Text = ""
                                obtener_tipos(hf_icu.Value)
                                carga_alumnos(hf_icu.Value)
                                cmd_temporal.Enabled = True
                                cmd_definitivo.Enabled = True
                                mv_cursos.ActiveViewIndex = 1
                        End Select
                End Select
            Case "detalle"
                hf_detalle_mpe.Show()
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

    Private Sub definitivo_fast(ByVal icu As String, ByVal fecha As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim dfc As New SqlCommand("UPDATE eval_reportes_future SET estado='2', upddate='" + Format(Now, "MM/dd/yyyy") + "' " + _
                                          "WHERE icu='" + icu + "' AND fecha='" + Format(CDate(fecha), "MM/dd/yyyy") + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        dfc.ExecuteNonQuery()
        sc.Close()
        llena_fechas(icu)
    End Sub

    Private Function getstring(ByVal icu As String, ByVal fecha As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim gtsc As New SqlCommand("SELECT ustring FROM eval_reportes_future WHERE icu='" + icu + "' AND fecha='" + fecha + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        getstring = gtsc.ExecuteScalar
        sc.Close()
    End Function

    Private Function damegrupo(ByVal icu As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim dmgc As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        damegrupo = dmgc.ExecuteScalar
        sc.Close()
    End Function

    Private Sub carga_alumnos(ByVal icu As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim cac As New SqlCommand("SELECT grupo FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        Dim cac2 As New SqlCommand("SELECT matr,fname,'' as it1,'' as it2,'' as it3 FROM alumnos WHERE ciclo='" + getactualcycle() + "' AND grupo='" + cac.ExecuteScalar + "' AND status='AC' ORDER BY osep", sc)
        Dim cac2da As New SqlDataAdapter(cac2)
        Dim cac2dt As New DataTable
        cac2da.Fill(cac2dt)
        sc.Close()
        gv_alumnos.DataSource = cac2dt
        gv_alumnos.DataBind()
        Dim cak As Integer
        For cak = 0 To gv_alumnos.Rows.Count - 1
            Dim h1 As HiddenField = CType(gv_alumnos.Rows(cak).FindControl("hf_gi1"), HiddenField)
            Dim h2 As HiddenField = CType(gv_alumnos.Rows(cak).FindControl("hf_gi2"), HiddenField)
            Dim h3 As HiddenField = CType(gv_alumnos.Rows(cak).FindControl("hf_gi3"), HiddenField)
            gv_alumnos.HeaderRow.Cells(2).Text = lbl_item1.Text
            gv_alumnos.HeaderRow.Cells(3).Text = lbl_item2.Text
            gv_alumnos.HeaderRow.Cells(4).Text = lbl_item3.Text
            h1.Value = hf_i1.Value
            h2.Value = hf_i2.Value
            h3.Value = hf_i3.Value
        Next
    End Sub

    Private Function obtener_tipos(ByVal icu As String) As String
        Dim sc As New SqlConnection(Application("str"))
        Dim btc As New SqlCommand("SELECT tipo FROM future_inf_icu WHERE icu='" + icu + "' AND ciclo='" + getactualcycle() + "'", sc)
        sc.Open()
        Dim btc2 As New SqlCommand("SELECT id_forma,forma FROM evalue_kind WHERE tipo='" + btc.ExecuteScalar + "' ORDER BY id_forma", sc)
        Dim btc2da As New SqlDataAdapter(btc2)
        Dim btc2dt As New DataTable
        btc2da.Fill(btc2dt)
        sc.Close()
        lbl_item1.Text = btc2dt.Rows(0).Item(1).ToString
        lbl_item2.Text = btc2dt.Rows(1).Item(1).ToString
        lbl_item3.Text = btc2dt.Rows(2).Item(1).ToString
        hf_i1.Value = btc2dt.Rows(0).Item(0).ToString
        hf_i2.Value = btc2dt.Rows(1).Item(0).ToString
        hf_i3.Value = btc2dt.Rows(2).Item(0).ToString
        'se hizo function porque necesitaba el string de tipos para la carga de calificaciones en
        'los reportes temporales y definitivos.
        obtener_tipos = btc2dt.Rows(0).Item(0).ToString & btc2dt.Rows(1).Item(0).ToString & btc2dt.Rows(2).Item(0).ToString
    End Function

    Protected Sub cmd_temporal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_temporal.Click
        Select Case checkcal()
            Case 1
                hf_msgcal_mpe.Show()
            Case Else
                insert_cal(hf_icu.Value, "1")
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
            Dim key As Integer
            For key = 1 To 3
                Dim m As String = CType(gv_alumnos.Rows(ck).FindControl("hf_matr"), HiddenField).Value
                Dim t As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_gi" & key.ToString), TextBox)
                Dim h As HiddenField = CType(gv_alumnos.Rows(ck).FindControl("hf_gi" & key.ToString), HiddenField)
                Dim icc As New SqlCommand("INSERT INTO eval_cal_future (ustring,alumno,eval_id,eval_cal,tipo,grupo) VALUES ('" + identificator + "'," + _
                                      "'" + m + "','" + h.Value + "','" + t.Text + "','" + typ + "','" + g + "')", sc)
                Dim icc2 As New SqlCommand("UPDATE eval_reportes_future SET ustring='" + identificator + "', estado='" + typ + "' ,upddate='" + Format(Now, "MM/dd/yyyy") + "' " + _
                                           "WHERE icu='" + icu + "' AND fecha='" + Format(CDate(hf_fecha.Value), "MM/dd/yyyy") + "'", sc)
                sc.Open()
                icc.ExecuteNonQuery()
                icc2.ExecuteNonQuery()
                sc.Close()
            Next
        Next
        Dim ky As Integer
        For ky = 1 To 3
            Dim d As String = CType(mv_cursos.FindControl("tbx_i" & ky.ToString), TextBox).Text
            Dim hf As String = CType(mv_cursos.FindControl("hf_i" & ky.ToString), HiddenField).Value
            Dim icc3 As New SqlCommand("INSERT INTO eval_description_future (ustring,eval_id,description) VALUES ('" + identificator + "','" + hf + "','" + d + "')", sc)
            sc.Open()
            icc3.ExecuteNonQuery()
            sc.Close()
        Next
    End Sub

    Private Sub insert_plain(ByVal icu As String, ByVal ustring As String, ByVal matr As Integer, ByVal sessiondate As Date, ByVal sesionid As Integer, ByVal ciclo As String, ByVal rn As Integer)
        Dim calmax As String = CType(gv_alumnos.Rows(rn).FindControl("tbx_gi1"), TextBox).Text
        Dim calmida As String = CType(gv_alumnos.Rows(rn).FindControl("tbx_gi2"), TextBox).Text
        Dim calmidb As String = CType(gv_alumnos.Rows(rn).FindControl("tbx_gi3"), TextBox).Text
        Dim v As New SqlConnection(Application("str"))
        Dim z As New SqlCommand("INSERT INTO eval_cal_plain (ciclo,icu,matr,ustring,sessiondate,sessionevalid,evalmax,evalmida,evalmidb) VALUES " + _
                                "('" + getactualcycle() + "','" + icu + "','" + matr.ToString + "','" + ustring + "','" + sessiondate + "','" + sesionid + "','" + calmax + "','" + calmida + "','" + calmidb + "')", v)
        v.Open()
        z.ExecuteNonQuery()
        v.Close()
    End Sub

    Private Function genstr() As String
        genstr = hf_icu.Value & Now.Minute.ToString & Now.Millisecond & Now.DayOfYear & Now.Day & Now.Month & Now.Year
    End Function

    Private Function checkcal() As Integer
        Dim ck As Integer
        For ck = 0 To gv_alumnos.Rows.Count - 1
            Dim t1 As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_gi1"), TextBox)
            Dim t2 As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_gi2"), TextBox)
            Dim t3 As TextBox = CType(gv_alumnos.Rows(ck).FindControl("tbx_gi3"), TextBox)
            If t1.Text = "" Then
                checkcal = 1
                Exit For
            ElseIf CDbl(t1.Text) > 10 Then
                checkcal = 1
                Exit For
            Else
                checkcal = 0
            End If

            If t2.Text = "" Then
                checkcal = 1
                Exit For
            ElseIf CDbl(t2.Text) > 10 Then
                checkcal = 1
                Exit For
            Else
                checkcal = 0
            End If

            If t3.Text = "" Then
                checkcal = 1
                Exit For
            ElseIf CDbl(t3.Text) > 10 Then
                checkcal = 1
                Exit For
            Else
                checkcal = 0
            End If
        Next
    End Function

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        mv_cursos.ActiveViewIndex = 0
    End Sub

    Protected Sub cmd_regresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_regresar.Click
        mv_cursos.ActiveViewIndex = 1
    End Sub

    Protected Sub cmd_definitivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_definitivo.Click
        Select Case checkcal()
            Case 1
                hf_msgcal_mpe.Show()
            Case Else
                insert_cal(hf_icu.Value, "2")
                llena_fechas(hf_icu.Value)
                mv_cursos.ActiveViewIndex = 0
        End Select
    End Sub

    Private Sub retrieve_data(ByVal ustring As String)
        Dim sc As New SqlConnection(Application("str"))
        Dim rdc As New SqlCommand("SELECT matr,fname,it1,it2,it3 FROM retrieve_evcont_future WHERE ustring='" + ustring + "' ORDER BY fname", sc)
        Dim rdda As New SqlDataAdapter(rdc)
        Dim rddt As New DataTable
        sc.Open()
        rdda.Fill(rddt)
        sc.Close()
        gv_alumnos.DataSource = rddt
        gv_alumnos.DataBind()
        For cak = 0 To gv_alumnos.Rows.Count - 1
            Dim h1 As HiddenField = CType(gv_alumnos.Rows(cak).FindControl("hf_gi1"), HiddenField)
            Dim h2 As HiddenField = CType(gv_alumnos.Rows(cak).FindControl("hf_gi2"), HiddenField)
            Dim h3 As HiddenField = CType(gv_alumnos.Rows(cak).FindControl("hf_gi3"), HiddenField)
            gv_alumnos.HeaderRow.Cells(2).Text = lbl_item1.Text
            gv_alumnos.HeaderRow.Cells(3).Text = lbl_item2.Text
            gv_alumnos.HeaderRow.Cells(4).Text = lbl_item3.Text
            h1.Value = hf_i1.Value
            h2.Value = hf_i2.Value
            h3.Value = hf_i3.Value
        Next
        Dim rd_d As New SqlCommand("SELECT description FROM eval_description_future WHERE ustring='" + ustring + "' ORDER BY eval_id", sc)
        Dim rd_da As New SqlDataAdapter(rd_d)
        Dim rd_dt As New DataTable
        sc.Open()
        rd_da.Fill(rd_dt)
        sc.Close()
        Try
            tbx_i1.Text = rd_dt.Rows(0).Item(0).ToString
            tbx_i2.Text = rd_dt.Rows(1).Item(0).ToString
            tbx_i3.Text = rd_dt.Rows(2).Item(0).ToString
        Catch ex As Exception

        End Try
    End Sub
End Class
