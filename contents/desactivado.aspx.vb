Imports carreraCiclo
Partial Class contents_desactivado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbl_desactivado.Text = desactivado()

    End Sub
End Class
