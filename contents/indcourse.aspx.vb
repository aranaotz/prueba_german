Imports carreraCiclo
Imports downdocument
Imports exporttoexcel
Imports print_docs
Partial Class contents_indcourse
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_induccion.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        hf_ciclo.Value = sender.commandArgument.ToString
        gv_carreras.DataSource = carreras_propedeutico(sender.commandArgument.ToString)
        gv_carreras.DataBind()
        deshab_func_lista()
        mv_induccion.ActiveViewIndex = 1
    End Sub



    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs)
        gv_ciclos.DataSource = llenaCiclo()
        gv_ciclos.DataBind()
        mv_induccion.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_clave_Click(sender As Object, e As EventArgs)
        mv_induccion.ActiveViewIndex = 2
        lbl_carrera.Text = sender.commandArgument.ToString
        carga_ddl()
        deshab_func_lista()
        gv_listado.Visible = False
    End Sub
    Public Sub carga_ddl()

        Dim ddlp As New ListItem("SELECCIONA UN TURNO...", "0")
        With ddl_turnos
            .DataSource = cargaTurno()
            .DataValueField = "id_turno"
            .DataTextField = "turno"
            .DataBind()
            .Items.Insert(0, ddlp)
        End With

    End Sub

    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs)
        mv_induccion.ActiveViewIndex = 1
    End Sub

 
    Protected Sub lb_captura_Click(sender As Object, e As EventArgs) Handles lb_captura.Click
        gv_listado.DataSource = listado_propedeutico_xcarreras(lbl_carrera.Text, ddl_turnos.SelectedValue, hf_ciclo.Value)
        gv_listado.DataBind()
        If gv_listado.Rows.Count() > 0 Then
            hab_func_lista()
        Else
            deshab_func_lista()
        End If
        gv_listado.Visible = True
    End Sub

    
    '  Protected Sub gv_listado_RowCommand(sender As Object, e As GridViewCommandEventArgs)
    ' Dim rwindx As Integer = Convert.ToInt32(e.CommandArgument)
    ' Dim cbxl As CheckBoxList = CType(gv_listado.Rows(rwindx).FindControl("cbxl_select"), CheckBoxList)
    'Dim cnt As Integer = 0
    'Dim chkd As Integer = 0
    '    For cnt = 0 To cbxl.Items.Count - 1
    '        If cbxl.Items(cnt).Selected = True Then
    '            chkd = chkd + 1
    '        End If
    '    Next cnt
    '   If chkd >= 2 Then
    '      gv_listado.Rows(rwindx).BackColor = Drawing.Color.Black
    '    End If
    'End Sub


    Protected Sub cbx_dia1_CheckedChanged(sender As Object, e As EventArgs)
        Dim cbx1 As CheckBox = CType(gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).FindControl("cbx_dia1"), CheckBox)
        Dim cbx2 As CheckBox = CType(gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).FindControl("cbx_dia2"), CheckBox)
        Dim cbx3 As CheckBox = CType(gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).FindControl("cbx_dia3"), CheckBox)

        If cbx1.Checked = False And cbx2.Checked = False And cbx3.Checked = False Then
            If (CInt(sender.ValidationGroup.ToString) Mod 2) = 0 Then
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow"
            Else
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_alt"
            End If

        ElseIf cbx1.Checked = False And cbx2.Checked = False And cbx3.Checked = True Then
            If (CInt(sender.ValidationGroup.ToString) Mod 2) = 0 Then
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow"
            Else
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_alt"
            End If

        ElseIf cbx1.Checked = False And cbx2.Checked = True And cbx3.Checked = False Then
            If (CInt(sender.ValidationGroup.ToString) Mod 2) = 0 Then
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow"
            Else
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_alt"
            End If

        ElseIf cbx1.Checked = False And cbx2.Checked = True And cbx3.Checked = True Then
            gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_green"


        ElseIf cbx1.Checked = True And cbx2.Checked = False And cbx3.Checked = False Then
            If (CInt(sender.ValidationGroup.ToString) Mod 2) = 0 Then
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow"
            Else
                gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_alt"
            End If

        ElseIf cbx1.Checked = True And cbx2.Checked = False And cbx3.Checked = True Then
            gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_green"

        ElseIf cbx1.Checked = True And cbx2.Checked = True And cbx3.Checked = False Then
            gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_green"

        Else
            gv_listado.Rows(CInt(sender.ValidationGroup.ToString)).CssClass = "gvrow_green"

        End If
    End Sub

    Protected Sub gv_listado_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_listado.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cbx1 As CheckBox = e.Row.FindControl("cbx_dia1")
            Dim cbx2 As CheckBox = e.Row.FindControl("cbx_dia2")
            Dim cbx3 As CheckBox = e.Row.FindControl("cbx_dia3")
            cbx1.ValidationGroup = e.Row.RowIndex.ToString
            cbx2.ValidationGroup = e.Row.RowIndex.ToString
            cbx3.ValidationGroup = e.Row.RowIndex.ToString
            Dim css As String = CType(e.Row.FindControl("hf_css"), HiddenField).Value
            If css.ToString.Length > 1 Then
                e.Row.CssClass = css
            End If
        End If
    End Sub

    Private Sub deshab_func_lista()
        lb_guardar.Enabled = False
        lb_guardar.CssClass = "boton_texto_dentro_disabled"
        lb_lista.Enabled = False
        lb_lista.CssClass = "boton_texto_dentro_disabled"
    End Sub

    Private Sub hab_func_lista()
        lb_guardar.Enabled = True
        lb_guardar.CssClass = "boton_texto_dentro"
        lb_lista.Enabled = True
        lb_lista.CssClass = "boton_texto_dentro"
    End Sub

    Protected Sub lb_guardar_Click(sender As Object, e As EventArgs) Handles lb_guardar.Click
        Dim t As Integer
        For t = 0 To gv_listado.Rows.Count - 1
            Dim cbx1 As String = IIf(CType(gv_listado.Rows(t).FindControl("cbx_dia1"), CheckBox).Checked, "1", "0")
            Dim cbx2 As String = IIf(CType(gv_listado.Rows(t).FindControl("cbx_dia2"), CheckBox).Checked, "1", "0")
            Dim cbx3 As String = IIf(CType(gv_listado.Rows(t).FindControl("cbx_dia3"), CheckBox).Checked, "1", "0")
            Dim ustring As String = CType(gv_listado.Rows(t).FindControl("hf_ustring"), HiddenField).Value
            Dim carrera As String = CType(gv_listado.Rows(t).FindControl("hf_carrera"), HiddenField).Value
            Dim turno As String = CType(gv_listado.Rows(t).FindControl("hf_turno"), HiddenField).Value
            Dim ins_or_upd As String = CType(gv_listado.Rows(t).FindControl("hf_insorupd"), HiddenField).Value
            If ins_or_upd = 0 Then
                insertar_pingreso_cinduccion(ustring, carrera, turno, cbx1, cbx2, cbx3, or_de_3(cbx1, cbx2, cbx3))
            Else
                actualizar_pingreso_cinduccion(ustring, carrera, turno, cbx1, cbx2, cbx3, or_de_3(cbx1, cbx2, cbx3))
            End If
        Next
        mv_induccion.ActiveViewIndex = 3
    End Sub
    Protected Sub lb_regresar1_Click(sender As Object, e As EventArgs) Handles lb_regresar1.Click
        mv_induccion.ActiveViewIndex = 2
    End Sub
    Protected Sub lb_regresar2_Click(sender As Object, e As EventArgs) Handles lb_regresar2.Click
        mv_induccion.ActiveViewIndex = 1
    End Sub
    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        mv_induccion.ActiveViewIndex = 2
    End Sub
    Protected Sub lb_lista_Click(sender As Object, e As EventArgs) Handles lb_lista.Click
        'sei006(lbl_carrera.Text, ddl_turnos.SelectedValue.ToString, hf_ciclo.Value, ddl_turnos.SelectedItem.Text)
        'descarga("se-i006", lbl_carrera.Text & "-" & ddl_turnos.SelectedValue.ToString & "-" & hf_ciclo.Value, ".pdf")

        'crystal reports
        Response.Redirect("~/contents/crv_pi/rpt_induccion.aspx?ca=" + lbl_carrera.Text + "&tn=" + ddl_turnos.SelectedValue.ToString + "&c=" + hf_ciclo.Value + "&tl=" + ddl_turnos.SelectedItem.Text)
    End Sub

    Protected Sub ddl_turnos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_turnos.SelectedIndexChanged
        gv_listado.DataSource = listado_propedeutico_xcarreras(lbl_carrera.Text, ddl_turnos.SelectedValue, hf_ciclo.Value)
        gv_listado.DataBind()
        If gv_listado.Rows.Count() > 0 Then
            hab_func_lista()
        Else
            deshab_func_lista()
        End If
        gv_listado.Visible = True
        Dim ScriptManager As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        ScriptManager.RegisterPostBackControl(lb_lista)
    End Sub
End Class
