Imports System.Data
Imports System.Data.SqlClient
Imports menumount
Imports usuario_alumno
Imports secure_tools

Partial Class synstu_synstu
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        nocache()
        backbutton()
        If IsNothing(Session("gcu")) Then
            Response.Redirect("~/glogin.aspx")
        Else
            mounting_menu()
        End If
    End Sub

    Private Sub mounting_menu()
        gv_menu.DataSource = menu("4")
        gv_menu.DataBind()
    End Sub

    ' Protected Sub gv_menu_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_menu.RowDataBound
    '     If e.Row.RowType = DataControlRowType.DataRow Then
    ' Dim gv_submenu As GridView = e.Row.FindControl("gv_submenu")
    '         gv_submenu.DataSource = submenu("3", "4")
    '         gv_submenu.DataBind()
    ' Dim img As Image = CType(e.Row.FindControl("img_alumno"), Image)
    '         img.ImageUrl = "~/photo/" & gcu(Session("gcu")) & ".jpg"
    '    End If
    ' End Sub

    Protected Sub lb_submenu_Click(sender As Object, e As EventArgs)
        Response.Redirect(sender.commandArgument.ToString)
    End Sub

    Protected Sub lb_closesession_Click(sender As Object, e As EventArgs) Handles lb_closesession.Click
        Session.Clear()
        'Response.Redirect("https://docs.google.com/forms/d/1RDUt5fvxCkm0UCJi2V_e5-NutChlZH82wKgV3L8mDXY/viewform")
        Response.Redirect("~/glogin.aspx")
    End Sub
End Class

