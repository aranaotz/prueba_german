Imports secure_tools
Partial Class pwdgen
    Inherits System.Web.UI.Page

    Protected Sub cmd_cambio_Click(sender As Object, e As EventArgs) Handles cmd_cambio.Click
        If existestr() = True Then
            If esseguro(Request.QueryString("tkn")) = True Then
                pwdch(tbx_contran.Text, matricula_pr(Request.QueryString("tkn")))
                updthecha(Request.QueryString("tkn"))
                Response.Redirect("../glogin.aspx")
            Else
                Response.Redirect("../glogin.aspx")
            End If
        Else
            Response.Redirect("../glogin.aspx")
        End If

    End Sub

    Private Function existestr() As Boolean
        If (Request.QueryString("tkn")) <> "" And Not IsNothing(Request.QueryString("tkn")) Then
            'If Request.QueryString("tkn") <> Nothing Then
            existestr = True
        Else
            existestr = False
        End If
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        nocache()
        backbutton()
        If existestr() = True Then
            If esseguro(Request.QueryString("tkn")) = True Then
            Else
                Response.Redirect("../glogin.aspx")
            End If
        Else
            Response.Redirect("../glogin.aspx")
        End If
    End Sub
End Class
