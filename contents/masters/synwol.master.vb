Imports secure_tools
Partial Class synwol
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If activepage() = False Then
            Response.Redirect("desactivado.aspx")
        End If
    End Sub
End Class

