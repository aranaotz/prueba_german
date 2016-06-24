Imports System.Data
Imports System.Data.SqlClient

Partial Class mensajes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            chkmsgs()
        End If
    End Sub


    Private Sub chkmsgs()
        Select Case hay_msgs(gc(Session("usrcgi200Xstr")))
            Case True
                get_msgs(gc(Session("usrcgi200Xstr")))
            Case Else
                go2page()
        End Select
    End Sub

    Private Sub go2page()
        Response.Redirect(Request.QueryString("redir") & "?aywystb=" & Request.QueryString("aywystb"))
        'If IsNothing(Request.QueryString("ein_neir")) Then
        'Response.Redirect("cevaluation.aspx" & "?aywystb=" & Request.QueryString("aywystb"))
        'Else
        'Response.Redirect("sadmin/queryst.aspx" & "?aywystb=" & Request.QueryString("aywystb") & "&uuro=" & Request.QueryString("uuro") & "&ein_neir=" & Request.QueryString("ein_neir"))
        'End If
    End Sub

    Private Function hay_msgs(ByVal cod As String) As Boolean
        Dim c As New SqlConnection(Application("str"))
        Dim cn As New SqlCommand("SELECT CASE WHEN COUNT(*)>0 THEN 1 ELSE 0 END hay FROM usr_msgs_single WHERE usr='" + cod + "' and active=1", c)
        c.Open()
        hay_msgs = cn.ExecuteScalar
        c.Close()
    End Function

    Private Sub get_msgs(ByVal cod As String)
        Dim c As New SqlConnection(Application("str"))
        Dim cc As New SqlDataAdapter("SELECT dbo.usr_msgs.id idm, dbo.usr_msgs.emisor, dbo.usr_msgs.titulo, dbo.usr_msgs.importancia, dbo.usr_msgs_single.id FROM dbo.usr_msgs INNER JOIN dbo.usr_msgs_single ON dbo.usr_msgs.id_msg = dbo.usr_msgs_single.id_msg " + _
                                    "WHERE (dbo.usr_msgs_single.usr = '" + cod + "')", c)
        Dim ct As New DataTable
        c.Open()
        cc.Fill(ct)
        c.Close()
        gv_mensajes.DataSource = ct
        gv_mensajes.DataBind()
    End Sub

    Private Function gc(ByVal idu As String) As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim aingcomm As New SqlCommand("SELECT c_user FROM users WHERE id_usr='" + idu + "'", sqlconn)
        sqlconn.Open()
        gc = aingcomm.ExecuteScalar()
        sqlconn.Close()
    End Function

    Private Sub redirect(ByVal sk As String)
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim namcomm As New SqlCommand("SELECT dbo.users.cat FROM dbo.users_strings INNER JOIN dbo.users ON dbo.users_strings.usr = " + _
                                      "dbo.users.c_user WHERE (dbo.users_strings.usr_string = '" + sk + "')", sqlconn)
        sqlconn.Open()
        Dim namda As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(namcomm)
        Dim namdt As DataTable = New System.Data.DataTable
        namda.Fill(namdt)
        sqlconn.Close()
        Response.Redirect(initpage(namdt.Rows(0).Item(0).ToString) & "?aywystb=" & sk)
    End Sub

    Private Function initpage(ByVal rg As String) As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim recomm As New SqlCommand("SELECT startp FROM adm_ucat WHERE id_cat = '" + rg + "'", sqlconn)
        sqlconn.Open()
        Dim reda As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(recomm)
        Dim redt As DataTable = New System.Data.DataTable
        reda.Fill(redt)
        sqlconn.Close()
        initpage = redt.Rows(0).Item(0).ToString
    End Function

    Protected Sub viewm(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim c As New SqlConnection(Application("str"))
        Dim t As New SqlCommand("SELECT cuerpo FROM usr_msgs WHERE id='" + sender.CommandName.ToString + "'", c)
        Dim y As New SqlCommand("UPDATE usr_msgs_single SET visto=getdate() WHERE id='" + sender.CommandArgument + "'", c)
        c.Open()
        lbl_mensaje.Text = t.ExecuteScalar.ToString
        y.ExecuteNonQuery()
        c.Close()
        cmd_hide.CommandArgument = sender.CommandArgument.ToString
        hf_mensaje_mpe.Show()
    End Sub

    Protected Sub cmd_hide_Click(sender As Object, e As System.EventArgs) Handles cmd_hide.Click
        Dim c As New SqlConnection(Application("str"))
        Dim y As New SqlCommand("UPDATE usr_msgs_single SET active=0, visto_active=getdate() WHERE id='" + sender.CommandArgument + "'", c)
        c.Open()
        y.ExecuteNonQuery()
        c.Close()
        chkmsgs()
    End Sub
End Class
