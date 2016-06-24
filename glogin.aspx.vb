Imports System.Data
Imports System.Data.SqlClient
Imports loginsecure

Partial Class glogin
    Inherits System.Web.UI.Page


    Private Function savechain(ByVal usuario As String, ByVal password As String) As String
        Dim mascarita As New loginsecure(password)
        savechain = mascarita.EncryptData(usuario)
    End Function

    Private Function login_chafa(ByVal matricula As String, ByVal pwd As String) As Boolean
        Try
            Dim c As New SqlConnection(Application("str"))
            Dim lc As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN 1 ELSE 0 END xsist FROM secure_logins WHERE codigo='" + matricula + "' and pwd='" + pwd + "'", c)
            c.Open()
            login_chafa = lc.ExecuteScalar.ToString
            c.Close()
        Catch ex As Exception
            login_chafa = 0
        End Try
    End Function

    Private Sub pasanopasa(ByVal correcto As Boolean)
        If correcto = True Then
            Try
                Session("gcu") = gcu(tbx_usuario.Text)
                If Session("gcu").ToString.Length > 7 Then
                    Response.Redirect("~/synstu/kardexev.aspx")
                Else
                    Response.Redirect("~/synprof/indata.aspx")
                End If
            Catch ex As Exception
                lbl_error.Text = "Error: Usuario no encontrado."
                t_error.Enabled = True
            End Try
        Else
            lbl_error.Text = "Usuario o Contraseña Inválidos"
            t_error.Enabled = True
        End If
    End Sub

    Private Function gcu(ByVal matricula As String) As String
        'Dim c As New SqlConnection(Application("str"))
        'Dim gc As New SqlCommand("SELECT codigo_unico FROM user_alumnos WHERE matricula='" + matricula + "'", c)
        'Dim gc As New SqlCommand("SELECT codigo_unico FROM user_alumnos WHERE matricula='" + matricula + "'", c)
        'c.Open()
        'gcu = gc.ExecuteScalar.ToString
        'c.Close()
        gcu = matricula
    End Function

    Private Function getusr(ByVal nick As String) As String
        Dim v As New SqlConnection(Application("str"))
        Dim gu As New SqlCommand("SELECT usr FROM users_outdoor WHERE nick='" + nick + "'", v)
        v.Open()
        getusr = gu.ExecuteScalar()
        v.Close()
    End Function

    Private Function get_code(ByVal id_user As String) As String
        Dim o As New SqlConnection(Application("str"))
        Dim igc As New SqlCommand("SELECT c_user FROM users WHERE id_usr = '" + id_user + "'", o)
        o.Open()
        get_code = igc.ExecuteScalar
        o.Close()
    End Function

    Private Function ue(ByVal u As String, ByVal p As String) As Boolean
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim uecomm As New SqlCommand("SELECT count(*) FROM users WHERE id_usr = '" + u.Replace("'", "") + "' AND pwd='" + p.Replace("'", "") + "' AND active=1", sqlconn)
        sqlconn.Open()
        Select Case uecomm.ExecuteScalar
            Case 1
                ue = True
            Case Else
                ue = False
        End Select
        sqlconn.Close()
    End Function

    Private Function uea(ByVal u As String, ByVal p As String) As Boolean
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim uecomm As New SqlCommand("SELECT count(usr) FROM users_outdoor WHERE usr = '" + u + "' AND pwd='" + p + "'", sqlconn)
        sqlconn.Open()
        Select Case uecomm.ExecuteScalar
            Case 1
                uea = True
            Case Else
                uea = False
        End Select
        sqlconn.Close()
    End Function

    Private Function uean(ByVal u As String, ByVal p As String) As Boolean
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim uecomm As New SqlCommand("SELECT count(usr) FROM users_outdoor WHERE nick = '" + u + "' AND pwd='" + p + "'", sqlconn)
        sqlconn.Open()
        Select Case uecomm.ExecuteScalar
            Case 1
                uean = True
            Case Else
                uean = False
        End Select
        sqlconn.Close()
    End Function


    'ESTE PASO NO HAY OPCION DE FALLO
    'SOLO VERIFICAR QUE EL ERROR NO SEA POR ESTE METODO
    Private Function setkey(ByVal n As String, ByVal key As String) As Boolean
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim inscomm As New SqlCommand("UPDATE users_strings SET usr_string='" + key + "',last_view='" + DateString + "' WHERE usr = '" + n + "'", sqlconn)
        sqlconn.Open()
        Try
            inscomm.ExecuteNonQuery()
            setkey = True
        Catch ex As Exception
            setkey = False
        End Try
        sqlconn.Close()
    End Function

    Private Function setkeya(ByVal n As String, ByVal key As String) As Boolean
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim inscomm As New SqlCommand("UPDATE users_outdoor SET opb='" + key + "',lastlogin='" + Format(Now, "MM/dd/yyyy hh:mm:ss") + "' WHERE usr = '" + n + "'", sqlconn)
        sqlconn.Open()
        Try
            inscomm.ExecuteNonQuery()
            setkeya = True
        Catch ex As Exception
            setkeya = False
        End Try
        sqlconn.Close()
    End Function

    Private Function setkeyan(ByVal n As String, ByVal key As String) As Boolean
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim inscomm As New SqlCommand("UPDATE users_outdoor SET opb='" + key + "',lastlogin='" + Format(Now, "MM/dd/yyyy hh:mm:ss") + "' WHERE nick = '" + n + "'", sqlconn)
        sqlconn.Open()
        Try
            inscomm.ExecuteNonQuery()
            setkeyan = True
        Catch ex As Exception
            setkeyan = False
        End Try
        sqlconn.Close()
    End Function

    Private Function genstring(ByVal n As String, ByVal r As String) As String
        genstring = Session("sid") & n & r.Length.ToString

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
        Session("idqw") = sk
        'Response.Redirect(initpage(namdt.Rows(0).Item(0).ToString, "usuario") & "&aywystb=" & sk)
        Response.Redirect(initpage(namdt.Rows(0).Item(0).ToString, "usuario") & "&aywystb=" & sk)
    End Sub

    Private Sub redirecta(ByVal sk As String)
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim namcomm As New SqlCommand("SELECT ipages FROM users_outdoor WHERE opb = '" + sk + "'", sqlconn)
        sqlconn.Open()
        Dim namda As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(namcomm)
        Dim namdt As DataTable = New System.Data.DataTable
        namda.Fill(namdt)
        sqlconn.Close()
        Response.Redirect(initpage(namdt.Rows(0).Item(0).ToString, "alumno") & "?aywystb=" & sk)
    End Sub

    Private Function initpage(ByVal rg As String, ByVal usertype As String) As String
        Dim sqlconn As New SqlConnection(Application("str"))
        'Dim recomm As New SqlCommand("SELECT 'mensajes.aspx' as startp FROM adm_ucat WHERE id_cat = '" + rg + "'", sqlconn)
        Dim recommq As New SqlDataAdapter("SELECT startp FROM adm_ucat WHERE id_cat = '" + rg + "'", sqlconn)
        sqlconn.Open()
        'Dim reda As SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(recomm)
        'Dim redt As DataTable = New System.Data.DataTable
        Dim redtq As New DataTable
        'reda.Fill(redt)
        recommq.Fill(redtq)
        sqlconn.Close()
        Select Case usertype
            Case "alumno"
                initpage = redtq.Rows(0).Item(0).ToString
            Case Else
                initpage = "synprof/mensajes.aspx" & "?redir=" & redtq.Rows(0).Item(0).ToString
        End Select

    End Function
    Private Function gs(ByVal w As String) As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim gscomm As New SqlCommand("SELECT opb FROM loginkeys WHERE id_user= = '" + w + "'", sqlconn)
        sqlconn.Open()
        gs = gscomm.ExecuteScalar
        sqlconn.Close()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'mount_mnews()
            'mount_anews()
            'lbl_datetime.Text = Format(Now, "dddd dd") & " de " & Format(Now, "MMMM, yyyy")
            'carga_menu_root()
            'mount_news()
            'mv_menu.ActiveViewIndex = 0
            'fill_sitios()
            p_error.CssClass = "Panel_normal"
            tbx_usuario.Focus()
        End If
    End Sub

    Protected Sub domenu(ByVal sender As Object, ByVal e As System.EventArgs)
        'mv_menu.ActiveViewIndex = sender.CommandName
    End Sub

    Private Sub carga_menu_root()
        Dim v As New SqlConnection(Application("str"))
        Dim cmr As New SqlDataAdapter("SELECT menu,description,value FROM menu_root ORDER BY id_menu", v)
        Dim cmt As New DataTable
        v.Open()
        cmr.Fill(cmt)
        v.Close()
        'gv_menu.DataSource = cmt
        'gv_menu.DataBind()
    End Sub

    'Protected Sub lb_lostpassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_lostpassword.Click
    '   Response.Redirect("lpassword.aspx?usr2find=" & tbx_usuario.Text)
    'End Sub

    Protected Sub atsion(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case sender.attributes("type").ToString
            Case "1"
                Response.Redirect("dwndoc.aspx?file=" & sender.CommandName & "&type=afiles&ext=" & sender.CommandArgument)
            Case "0"
                Response.Redirect("newscgi.aspx?item=" & sender.CommandName & "")
        End Select
    End Sub

    Private Sub fill_sitios()
        Dim v As New SqlConnection(Application("str"))
        Dim c As New SqlDataAdapter("SELECT text,img,link FROM login_sitios ORDER BY id", v)
        Dim dt As New DataTable
        v.Open()
        c.Fill(dt)
        v.Close()
        'dl_sites.DataSource = dt
        'dl_sites.DataBind()
    End Sub

    Private Function checkstatus(ByVal usr As String) As String
        Dim v As New SqlConnection(Application("str"))
        Dim t As New SqlCommand("SELECT reference FROM users_outdoor WHERE usr='" + usr + "'", v)
        v.Open()
        Dim stat As String = t.ExecuteScalar
        Dim u As New SqlCommand("SELECT status FROM alumnos WHERE matr='" + stat + "' AND ciclo='" + getactualcycle() + "'", v)
        Dim stats As String = u.ExecuteScalar
        v.Close()
        checkstatus = stats
    End Function

    Private Function getactualcycle() As String
        Dim v As New SqlConnection(Application("str"))
        Dim cycle As New SqlCommand("SELECT ciclo FROM general_ciclos WHERE active=1", v)
        v.Open()
        getactualcycle = cycle.ExecuteScalar
        v.Close()
    End Function

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    'buscar(tbx_string.Text, ddl_campos.SelectedItem.Text)
    'End Sub

    Private Sub buscar(ByVal str As String, ByVal campo As String)
        Dim C As New SqlConnection(Application("str"))
        Dim ct As New SqlDataAdapter("SELECT * from biblio WHERE " + campo + " LIKE '%" + str + "%'", C)
        Dim ctt As New DataTable
        C.Open()
        ct.Fill(ctt)
        C.Close()
        'gv1.DataSource = ctt
        'gv1.DataBind()
        'lbl_resultados.Text = "Mostrando " & ctt.Rows.Count & " resultado(s)."
    End Sub

    Protected Sub t_error_Tick(sender As Object, e As EventArgs) Handles t_error.Tick
        lbl_error.Text = "Corríja e Intente de nuevo"
        t_error.Enabled = False
    End Sub

    Protected Sub ib_login_Click(sender As Object, e As ImageClickEventArgs) Handles ib_login.Click
        Session("utsynuser") = EncryptData(cleanchain(tbx_usuario.Text) & cleanchain(tbx_password.Text))
        storescure(tbx_usuario.Text, Session("utsynuser"))
        Select Case xist(tbx_usuario.Text, tbx_password.Text, Session("utsynuser"))
            Case True
                Session("gcu") = gcu(tbx_usuario.Text)
                Session("lvu") = Left(Session.SessionID.ToString, 7) & datoscapa3(datos_capados(datos_capauno(gid(tbx_usuario.Text, tbx_password.Text, Session("utsynuser")))), tbx_usuario.Text)(1) & Right(Session.SessionID.ToString, 7)
                Response.Redirect("~/logins/distpacher.aspx?lvu=" & Session("lvu"))
                'Response.Redirect("~/" & datoscapa3(datos_capados(datos_capauno(gid(tbx_usuario.Text, tbx_password.Text, Session("utsynuser")))), tbx_usuario.Text)(1))
            Case Else
                lbl_error.Text = "Usuario o Contraseña Inválidos"
                p_error.CssClass = "Panel_error"
                t_error.Enabled = True
        End Select
    End Sub

    Protected Sub lb_lostp_Click(sender As Object, e As EventArgs) Handles lb_lostp.Click
        Response.Redirect("~/contents/sendquery.aspx")
    End Sub
End Class
