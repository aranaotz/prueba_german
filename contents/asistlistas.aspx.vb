Imports escolar
Imports secure_tools
Imports System.Data
Imports System.Data.SqlClient

Partial Class asistlistas
    Inherits System.Web.UI.Page

    Private Sub asistlistas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Title = "Asistencias " + synpin_code.versiones

        If Not IsPostBack Then
            gv_listas.DataSource = cargacursos(clavetrabajador(Session("gcu")))
            gv_listas.DataBind()
            mv_lista.ActiveViewIndex = 0
            lb_reportefinal.Visible = False

        End If
    End Sub
    Protected Sub lb_icu_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable = materiabyicu(sender.CommandArgument.ToString)
        lbl_icu.Text = dt.Rows(0).Item(0).ToString
        lbl_materia.Text = dt.Rows(0).Item(1).ToString
        mv_lista.ActiveViewIndex = 1
        cacoensulu(info_icu(lbl_icu.Text))





        ''''reporte final


    End Sub

    Private Sub cacoensulu(ByVal dt As DataTable)

        lbl_clave.Text = "  " + dt.Rows(0).Item(1).ToString
        lbl_curso.Text = "  " + dt.Rows(0).Item(2).ToString
        lbl_nivel.Text = "  " + dt.Rows(0).Item(3).ToString
        lbl_ciclo.Text = dt.Rows(0).Item(5).ToString
        lbl_profesor.Text = "  " + dt.Rows(0).Item(6).ToString
        lbl_turno.Text = "  " + dt.Rows(0).Item(7).ToString
        lbl_h_inicio.Text = "  " + dt.Rows(0).Item(8).ToString
        lbl_h_fin.Text = "  " + dt.Rows(0).Item(9).ToString
        lbl_dias.Text = "  " + dt.Rows(0).Item(10).ToString + " " + dt.Rows(0).Item(11).ToString + " " + dt.Rows(0).Item(12).ToString + " " + dt.Rows(0).Item(13).ToString + " " + dt.Rows(0).Item(14).ToString + " " + dt.Rows(0).Item(15).ToString

        lbl_aula.Text = "   " + dt.Rows(0).Item(16).ToString + " " + dt.Rows(0).Item(17).ToString
        lbl_f_inicio.Text = "  " + dt.Rows(0).Item(18).ToString
        lbl_f_fin.Text = "  " + dt.Rows(0).Item(19).ToString

    End Sub




    Protected Sub ddl_periodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_periodo.SelectedIndexChanged

        If ddl_periodo.SelectedIndex > 0 Then
            ddl_cantidad.SelectedValue = 0
            hf_popupok_mpe.Show()
            lbl_periodo.Text = ddl_periodo.SelectedItem.ToString

        End If



    End Sub
    Protected Sub cmd_ok_Click(sender As Object, e As EventArgs)

        mv_lista.ActiveViewIndex = 3
        lbl_mes.Text = ddl_periodo.SelectedItem.ToString
        gv_listado.DataSource = lista_icus(lbl_icu.Text)
        gv_listado.DataBind()

    End Sub

    Private Sub gv_listado_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_listado.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cantidad As Integer = ddl_cantidad.SelectedValue.ToString
            Dim i As Integer
            Dim faltas As DropDownList = CType(e.Row.FindControl("ddl_faltas"), DropDownList)
            For i = 1 To cantidad
                faltas.Items.Add(i.ToString)
            Next
            Dim item As New ListItem("Ninguna", 0)
            faltas.Items.Insert(0, item)
        End If

    End Sub
    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_lista.ActiveViewIndex = 0
        ddl_periodo.SelectedValue = 0
    End Sub

    Protected Sub ib_otro_mes_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ddl_faltas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim total As Integer = ddl_cantidad.SelectedValue.ToString
        Dim faltas As DropDownList = DirectCast(sender, DropDownList)
        Dim asistencia_alumno = total - faltas.SelectedValue




        If (faltas.SelectedValue > total) Then
            moe_hf_faltas.Show()
            lbl_asis.Text = total
            lbl_faltas.Text = faltas.SelectedValue
            faltas.SelectedValue = 0

        Else
            Dim porcentaje As Integer = (asistencia_alumno * 100) / total
            '********
            Dim idrow As String = faltas.ToolTip.ToString
            Dim tbx As TextBox = CType(gv_listado.Rows(idrow).FindControl("tbx_porcentaje"), TextBox)
            tbx.Text = porcentaje

        End If


    End Sub
    Protected Sub cmd_ok1_Click(sender As Object, e As EventArgs)
        moe_hf_faltas.Hide()

    End Sub
    Protected Sub ib_guarda_mes_Click(sender As Object, e As ImageClickEventArgs)


    End Sub
    Protected Sub ib_vuelve_Click(sender As Object, e As ImageClickEventArgs) Handles ib_vuelve.Click
        mv_lista.ActiveViewIndex = 1

        ddl_periodo.SelectedIndex = 0

        ddl_cantidad.SelectedValue = 0
    End Sub
    Protected Sub lb_regresar1_Click(sender As Object, e As EventArgs) Handles lb_regresar1.Click
        mv_lista.ActiveViewIndex = 0
        ddl_periodo.SelectedValue = 0
    End Sub
    Protected Sub lb_imprimir_Click(sender As Object, e As EventArgs)
        Dim icu As String = lbl_icu.Text


        Dim inicio As String = lbl_f_inicio.Text
        Dim fin As String = lbl_f_fin.Text

        Response.Redirect("~/contents/crv_prof/rpt_lista_asistencia.aspx?icu=" + icu + "&p=" + ddl_periodo.SelectedItem.ToString + "&ini=" + inicio + "&f=" + fin)
    End Sub
    Protected Sub lb_guardar_Click(sender As Object, e As EventArgs)

        Dim unidad As String = lbl_clave.Text + "-" + Trim(lbl_curso.Text) + ddl_periodo.SelectedValue.ToString
        Dim ustring_unidad As String = unidad & lbl_ciclo.Text


        inserta_asisticu(lbl_icu.Text, lbl_ciclo.Text, unidad, ddl_cantidad.SelectedValue.ToString, ustring_unidad)
        'Try

        Dim i As Integer

        For i = 0 To gv_listado.Rows.Count - 1

            Dim matricula As String = CType(gv_listado.Rows(i).FindControl("hf_matricula"), HiddenField).Value
            Dim faltas As String = CType(gv_listado.Rows(i).FindControl("ddl_faltas"), DropDownList).SelectedValue
            Dim porcentaje As String = CType(gv_listado.Rows(i).FindControl("tbx_porcentaje"), TextBox).Text
            Dim calificacion As String = CType(gv_listado.Rows(i).FindControl("tbx_continua"), TextBox).Text

            Dim asistencias As Integer = ddl_cantidad.SelectedItem.ToString - faltas



            Dim ustring As String = Trim(lbl_icu.Text) + matricula + "-" + Trim(lbl_ciclo.Text) + Trim(unidad)

            inserta_evalunidades(lbl_icu.Text, ustring, calificacion, matricula, unidad, faltas, asistencias, porcentaje)

        Next

        mv_lista.ActiveViewIndex = 2

        'Catch ex As Exception
        '    MsgBox("Hubo un error al guardar los datos, comunicate con el adminstrador")

        'End Try


    End Sub
    Protected Sub ib_back1_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back1.Click

        ddl_periodo.SelectedIndex = 0


        ddl_cantidad.SelectedValue = 0
        mv_lista.ActiveViewIndex = 1
    End Sub
    Protected Sub cmd_consular_Click(sender As Object, e As EventArgs)
        mv_lista.ActiveViewIndex = 4
        lbl_mes_.Text = ddl_periodo.SelectedItem.ToString
        Dim index As Integer = ddl_periodo.SelectedValue.ToString



    End Sub
    Protected Sub cmd_rev_Click(sender As Object, e As EventArgs)

        Dim index As Integer = ddl_periodo.SelectedIndex


        'Select Case index
        '    Case 1
        '        revp1(lbl_icu.Text)
        '    Case 2
        '        revp2(lbl_icu.Text)
        '    Case 3
        '        revp3(lbl_icu.Text)

        '    Case Else

        'End Select

        hf_popupok_mpe.Show()
        'lbl_m.Text = ddl_mes.SelectedItem.ToString
    End Sub
    Protected Sub lb_reportefinal_Click(sender As Object, e As EventArgs) Handles lb_reportefinal.Click


        ''''reporte final
        'Dim son5meses As Integer = m5_ya_evaluado(lbl_icu.Text)
        'Dim son4meses As Integer = m4_ya_evaluado(lbl_icu.Text)
        'If son5meses > 0 Then
        '    gv_reporte.DataSource = r_final_5m(lbl_icu.Text)
        '    gv_reporte.DataBind()
        '    mv_lista.ActiveViewIndex = 5
        '    lbl_icu_.Text = lbl_icu.Text
        '    lbl_curso_.Text = lbl_curso.Text
        'ElseIf son4meses > 0 Then
        '    gv_reporte.DataSource = r_final_4m(lbl_icu.Text)
        '    gv_reporte.DataBind()
        '    mv_lista.ActiveViewIndex = 5
        '    lbl_icu_.Text = lbl_icu.Text
        '    lbl_curso_.Text = lbl_curso.Text
        'End If

    End Sub
    Protected Sub lb_imprimereporte_Click(sender As Object, e As EventArgs) Handles lb_imprimereporte.Click


        '    ''''reporte final
        '    Dim son5meses As Integer = m5_ya_evaluado(lbl_icu.Text)
        '    Dim son4meses As Integer = m4_ya_evaluado(lbl_icu.Text)
        '    If son5meses > 0 Then
        '        'llamar al 5
        '        Response.Redirect("~/contents/crv_prof/rpt_asistencia_final5m.aspx?icu=" + lbl_icu.Text)
        '    ElseIf son4meses > 0 Then
        '        'llamar al 4
        '        Response.Redirect("~/contents/crv_prof/rpt_asistencia_final4m.aspx?icu=" + lbl_icu.Text)
        '    End If

    End Sub



End Class
