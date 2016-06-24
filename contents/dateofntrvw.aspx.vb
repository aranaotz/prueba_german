Imports carreraCiclo
Partial Class contents_dateofntrvw
    Inherits System.Web.UI.Page


    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
      
        'lbl_ciclo.Text = sender.commandArgument.ToString
        'mv_dateofntvw.ActiveViewIndex = 1

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'gv_ciclos.DataSource = llenaCiclo()
            'gv_ciclos.DataBind()
            mv_dateofntvw.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub cbx_select_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class
