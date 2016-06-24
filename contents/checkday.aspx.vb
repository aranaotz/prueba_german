Imports carreraCiclo
Imports secure_tools
Partial Class contents_checkday
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Calendario Entrevistas - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_checkday.ActiveViewIndex = 2
        End If
    End Sub

    Protected Sub lb_nuevo_Click(sender As Object, e As EventArgs)
        mv_checkday.ActiveViewIndex = 1
        habilitaLista(lbl_ciclo.Text, securetext(txtInicio.Text), securetext(txtFin.Text))
        gv_listado.DataSource = fechas(lbl_ciclo.Text, securetext(txtInicio.Text), securetext(txtFin.Text))
        gv_listado.DataBind()



    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        mv_checkday.ActiveViewIndex = 3
        lbl_ciclo.Text = sender.commandArgument.ToString
        lbl_ciclo1.Text = sender.commandArgument.ToString
        gv_lista.DataSource = diaActivo(lbl_ciclo.Text, securetext(txtInicio.Text), securetext(txtFin.Text))
        gv_lista.DataBind()
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras.Click
        mv_checkday.ActiveViewIndex = 2
        txtInicio.Text = ""
        txtFin.Text = ""
    End Sub

  

   

    'Protected Sub gv_listado_RowCommand(sender As Object, e As GridViewCommandEventArgs)
    '    Dim mes As String = gv_listado.Rows(CInt(e.CommandArgument)).Cells(3).Text
    '    Dim dia As String = gv_listado.Rows(CInt(e.CommandArgument)).Cells(4).Text

    '    'MsgBox("el mes " + mes + " el dia" + dia)
    '    deshabilita(lbl_ciclo.Text, mes, dia)

    '    gv_listado.DataSource = fechas(lbl_ciclo.Text, txtInicio.Text, txtFin.Text)
    '    gv_listado.DataBind()
    'End Sub

    
   

    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs)
        mv_checkday.ActiveViewIndex = 0
        txtInicio.Text = ""
        txtFin.Text = ""
    End Sub


    Protected Sub cbx_activo_CheckedChanged(sender As Object, e As EventArgs)
        Dim dd As CheckBox = DirectCast(sender, CheckBox)
        Dim objfila As GridViewRow = DirectCast(dd.Parent.Parent, GridViewRow)
        Dim mes As HiddenField = DirectCast(objfila.FindControl("hf_mes"), HiddenField)
        Dim dia As HiddenField = DirectCast(objfila.FindControl("hf_dia"), HiddenField)

        Dim valor As Boolean = dd.Checked

        If valor Then
            habilita(lbl_ciclo.Text, mes.Value, dia.Value)
        Else
            deshabilita(lbl_ciclo.Text, mes.Value, dia.Value)
        End If
    End Sub

    Protected Sub lb_lista_Click(sender As Object, e As EventArgs)
        mv_checkday.ActiveViewIndex = 3
        gv_lista.DataSource = diaActivo(lbl_ciclo.Text, securetext(txtInicio.Text), (txtFin.Text))
        gv_lista.DataBind()
    End Sub

    Protected Sub lb_agregar_Click(sender As Object, e As EventArgs)
        mv_checkday.ActiveViewIndex = 0
        txtInicio.Text = ""
        txtFin.Text = ""

    End Sub

    Protected Sub cbx_activar_CheckedChanged(sender As Object, e As EventArgs)
        Dim dd As CheckBox = DirectCast(sender, CheckBox)
        Dim objFila As GridViewRow = DirectCast(dd.Parent.Parent, GridViewRow)
        Dim mes As HiddenField = DirectCast(objFila.FindControl("hf_mes"), HiddenField)
        Dim dia As HiddenField = DirectCast(objFila.FindControl("hf_dia"), HiddenField)

        Dim valor As Boolean = dd.Checked

        If valor Then
            habilita(lbl_ciclo.Text, mes.Value, dia.Value)
        Else
            deshabilita(lbl_ciclo.Text, mes.Value, dia.Value)

        End If

    End Sub

    Protected Sub ib_regresa_Click(sender As Object, e As ImageClickEventArgs)
        mv_checkday.ActiveViewIndex = 2
    End Sub
End Class
