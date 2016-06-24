Imports System.Data
Imports System.Data.SqlClient
Imports turntable_code
Imports menumount
Imports loginsecure
Imports secure_tools

Partial Class logins
    Inherits System.Web.UI.MasterPage

    Private Function existestr() As Boolean
        Try
            If (Session("lvu")) <> "" And Not IsNothing(Session("lvu")) Then
                'If Request.QueryString("tkn") <> Nothing Then
                existestr = True
            Else
                existestr = False
            End If
        Catch ex As Exception
            existestr = False
        End Try
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        nocache()
        backbutton()
        If existestr() = True Then
            If IsNothing(Session("gcu")) Then
                Response.Redirect("~/glogin.aspx")
            Else
                If Not IsPostBack Then
                    mounting_menu(Session("gcu"))
                    Dim dtcampos As DataTable = campos_de_tabla(Session("gcu"))
                    lbl_nombre.Text = gname(Session("gcu"), gettable(Session("gcu")), dtcampos.Rows(0).Item(2).ToString, dtcampos.Rows(0).Item(1).ToString)
                    img_usuario.ImageUrl = menufoto(Session("gcu"))
                End If
            End If
        Else
            Response.Redirect("../glogin.aspx")
        End If
        If Not IsNothing(Session("itembound")) Then
            Dim acc As AjaxControlToolkit.Accordion = CType(gv_topmenu.Rows(Session("itembound")).FindControl("acc_menu"), AjaxControlToolkit.Accordion)
            acc.SelectedIndex = 0
        End If
    End Sub

    Private Sub mounting_menu(ByVal usuario As String)
        Select Case isusertype(usuario)
            Case 1
                gv_topmenu.DataSource = topmenu("alumno")
                gv_topmenu.DataBind()
            Case 3
                gv_topmenu.DataSource = topmenu("instructor")
                gv_topmenu.DataBind()
            Case Else
                gv_topmenu.DataSource = topmenu(usuario)
                gv_topmenu.DataBind()
        End Select
    End Sub



    Protected Sub gv_topmenu_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_topmenu.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cabezalitem As String = CType(CType(e.Row.FindControl("acc_menu"), AjaxControlToolkit.Accordion).Panes(0).FindControl("hf_cabezalnum"), HiddenField).Value
            Dim usuario As String = CType(CType(e.Row.FindControl("acc_menu"), AjaxControlToolkit.Accordion).Panes(0).FindControl("hf_usuario"), HiddenField).Value
            Dim gv_submenu As GridView = CType(CType(e.Row.FindControl("acc_menu"), AjaxControlToolkit.Accordion).Panes(0).FindControl("gv_submenu"), GridView)
            gv_submenu.DataSource = submenu(cabezalitem, e.Row.RowIndex.ToString, usuario)
            gv_submenu.DataBind()
        End If
    End Sub


    'Protected Sub gv_menu_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_menu.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    'Dim gv_submenu As GridView = e.Row.FindControl("gv_submenu")
    '        gv_submenu.DataSource = submenu(menu((getlvu(Session("lvu")))).Rows(e.Row.RowIndex).Item(0).ToString, (getlvu(Session("lvu"))))
    '        gv_submenu.DataBind()
    '    End If
    'End Sub

    Protected Sub lb_submenu_Click(sender As Object, e As EventArgs)
        Session("itembound") = sender.commandname.ToString
        Response.Redirect(sender.commandArgument.ToString)
    End Sub

    ' Protected Sub ib_csession_Click(sender As Object, e As ImageClickEventArgs) Handles ib_csession.Click
    '     Session.Clear()
    ' End Sub

    Protected Sub lb_closesession_Click(sender As Object, e As EventArgs) Handles lb_closesession.Click
        Session.Clear()
        'Response.Redirect("https://docs.google.com/forms/d/1RDUt5fvxCkm0UCJi2V_e5-NutChlZH82wKgV3L8mDXY/viewform")
        Response.Redirect("~/glogin.aspx")
    End Sub

    Protected Sub lb_updpass_Click(sender As Object, e As EventArgs)
        Response.Redirect("..\logins\distpacher.aspx")
    End Sub
End Class

