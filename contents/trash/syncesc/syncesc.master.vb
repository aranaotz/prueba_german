Imports System.Data
Imports System.Data.SqlClient
Imports menumount

Partial Class syncesc_syncesc
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'mounting_menu()
    End Sub

    Private Sub mounting_menu()
        gv_menu.DataSource = mount_cesc(Application("str"))
        gv_menu.DataBind()
    End Sub

    Protected Sub gv_menu_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_menu.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim gv_submenu As GridView = e.Row.FindControl("gv_submenu")
            gv_submenu.DataSource = mount_cesc_inside(Application("str"), mount_cesc(Application("str")).Rows(e.Row.RowIndex).Item(0).ToString)
            gv_submenu.DataBind()
        End If
    End Sub

    Protected Sub lb_submenu_Click(sender As Object, e As EventArgs)
        Response.Redirect(sender.commandArgument.ToString)
    End Sub
End Class

