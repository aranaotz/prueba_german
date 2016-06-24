Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail

Imports Microsoft.VisualBasic
Imports System.Web
Imports System
Imports System.Web.UI.WebControls

Public Class secure_tools

    Shared Function securetext(ByVal cadena As String) As String
        securetext = cadena.Replace("'", "").Replace(";", "").Replace("--", "-").ToUpper
    End Function

    Shared Function securetext_min(ByVal cadena As String) As String
        securetext_min = cadena.Replace("'", "").Replace(";", "").Replace("--", "-")
    End Function

    Shared Function secureddl(ByVal ddl As DropDownList) As String
        secureddl = ddl.SelectedValue.ToString.Replace("'", "").Replace(";", "").Replace("--", "-").ToUpper
    End Function

    Private Function vpa(ByVal cn As SqlConnection, ByVal un As String, ByVal op As String) As Boolean
        Dim vpatf As New SqlCommand("SELECT CASE WHEN count(*) =1 THEN '1' ELSE '0' END as cnt FROM users WHERE (id_usr='" + un + "') AND (pwd='" + op + "')", cn)
        cn.Open()
        vpa = vpatf.ExecuteScalar.ToString
        cn.Close()
    End Function

    Shared Sub pwdch(ByVal un As String, ByVal np As String)
        Dim con As New SqlConnection(HttpContext.Current.Application("str"))
        Dim c As New SqlCommand("UPDATE secure_logins SET pwd='" + un + "' WHERE codigo='" + np + "'", con)
        con.Open()
        c.ExecuteNonQuery()
        con.Close()
    End Sub

    Shared Sub nocache()
        HttpContext.Current.Response.Expires = 0
        HttpContext.Current.Response.CacheControl = "Private"
        HttpContext.Current.Response.AddHeader("PRAGMA", "NO-CACHE")
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        HttpContext.Current.Response.AppendHeader("Cache-Control", "no-store")
        HttpContext.Current.Response.AppendHeader("Expires", "-1")
    End Sub

    Shared Sub backbutton()
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(False)
        HttpContext.Current.Response.Cache.SetNoStore()
    End Sub

    Shared Function escorrecto(ByVal m As String, ByVal p As String) As Boolean
        Dim con As New SqlConnection(HttpContext.Current.Application("str"))
        Dim c As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN '1' ELSE '0' END esta FROM secure_logins WHERE codigo='" + m + "' AND pwd='" + p + "'", con)
        con.Open()
        escorrecto = c.ExecuteScalar.ToString
        con.Close()
    End Function

    Shared Function matricula_pr(ByVal qs As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mpr As New SqlCommand("SELECT matricula FROM secure_tokens WHERE token='" + qs + "'", c)
        c.Open()
        matricula_pr = mpr.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function esseguro(ByVal rqs As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ss As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN '1' ELSE '0' END esta FROM secure_tokens WHERE token='" + rqs + "' " + _
                                 "AND (getdate() between startdate AND enddate) AND (hecha=0)", c)
        c.Open()
        esseguro = ss.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Sub updthecha(ByVal token As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim updt As New SqlCommand("UPDATE secure_tokens SET hecha=1 WHERE token='" + token + "'", c)
        c.Open()
        updt.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function table2search(ByVal matricula As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim t2s As New SqlCommand("SELECT tabla FROM secure_logins WHERE (codigo = '" + matricula + "')", c)
        c.Open()
        table2search = t2s.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function cu(ByVal matricula As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cuc As New SqlCommand("SELECT codigo_unico FROM user_alumnos WHERE (matricula = '" + matricula + "')", c)
        c.Open()
        cu = cuc.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function mailalumno(ByVal cu As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ma As New SqlCommand("SELECT correo FROM user_generales WHERE (codigo_unico = '" + cu + "')", c)
        c.Open()
        mailalumno = ma.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function getemail_alumno(ByVal matricula As String) As String
        Dim v As New SqlConnection(HttpContext.Current.Application("str"))
        Select Case table2search(matricula)
            Case "user_alumnos"
                getemail_alumno = mailalumno(cu(matricula))
            Case Else
                getemail_alumno = "hola"
                'PROXIMAMANETE
        End Select
    End Function

    Shared Function getemail_recovery(ByVal matricula As String) As String
        Dim v As New SqlConnection(HttpContext.Current.Application("str"))
        Select Case table2search(matricula)
            Case "user_alumnos"
                getemail_recovery = mailalumno(cu(matricula))
            Case Else
                getemail_recovery = "hola"
                'PROXIMAMANETE
        End Select
    End Function


    Shared Function senderemail_recovery(ByVal identificador As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim se As New SqlDataAdapter("SELECT correo_pi,password_pi FROM info_setupcorreos WHERE id='" + identificador + "'", c)
        Dim setb As New DataTable
        c.Open()
        se.Fill(setb)
        c.Close()
        senderemail_recovery = setb
    End Function



    Shared Sub sendmail(ByVal toemail As String, ByVal emailsender As String, ByVal emailsenderp As String, ByVal chain As String)
        Dim fromEmail As MailAddress = New MailAddress(emailsender, "UTZMG - Sistema de seguridad UTSyn")
        Dim body As String = "<p style=""font-family: 'Segoe UI', Arial, Verdana; font-size: 1.4em; color: #ff3300;"">" & _
            "Tú o alguien que conoce tu matricula de la UTZMG ha solicitado instrucciones para cambiar la contraseña de tu cuenta." & _
            "</p><p style=""font-family: 'Segoe UI', Arial, Verdana; font-size: 1.1em; color: #333333;"">Si no fuiste tú, sólo elimina éste correo, " & _
            "en caso contrario, haz click en la siguiente liga para ir a la pagina de cambio de contraseña.</p><p>Si tu cliente de correo no permite " & _
            "hacer click en los links, copia la liga y pégala en tu navegador.</p><p><a href=""" & _
            "http://189.192.132.229/utsyn/synmethods/pwdgen.aspx?tkn=" & chain & """>http://189.192.132.229/utsyn/synmethods/pwdgen.aspx?tkn=" & chain & "</a></p>"
        Dim subject As String = "Instrucciones para restablecimiento de contraseña UTSyn"

        Try
            'CORREO ENVIADO VIA GMAIL
            Dim emm As New MailMessage()
            emm.To.Add(toemail)
            emm.From = fromEmail
            emm.Subject = subject
            emm.Body = body
            emm.IsBodyHtml = True
            Dim client As New SmtpClient("smtp.gmail.com")
            client.Credentials = New System.Net.NetworkCredential(emailsender, emailsenderp)
            client.Port = 587
            client.EnableSsl = True
            client.Send(emm)

        Catch ex As Exception
            'HttpContext.Current.Response.Write(ex.ToString)
        End Try
    End Sub

    Shared Function campos_de_tabla(ByVal usuario As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cdt As New SqlDataAdapter("Select ntable,camporeferencia,fullnamecampo,nombrecampo,apellidopcampo,apellidomcampo from secure_tables inner join " +
                                      "(select tabla from secure_logins where codigo='" + usuario + "') as campos on secure_tables.ntable=campos.tabla", c)
        Dim cdtt As New DataTable
        c.Open()
        cdt.Fill(cdtt)
        c.Close()
        Return cdtt
    End Function

    Shared Function gubi_user_users(ByVal id As String) As String
        'OBTIENE EL USERNAME DE LA TABLA user_users A PARTIR DEL ID DE LA TABLA
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gubi As New SqlCommand("SELECT usuario from user_users where id='" + id + "'", c)
        c.Open()
        gubi_user_users = gubi.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function gubi_user_users_(ByVal user As String) As String
        'OBTIENE EL USERNAME DE LA TABLA user_users A PARTIR DEL username DE LA TABLA
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gubi As New SqlCommand("SELECT usuario from user_users where usuario='" + user + "'", c)
        c.Open()
        gubi_user_users_ = gubi.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function gnm_user_users(ByVal id As String) As String
        'OBTIENE EL NOMBRE COMPLETO DE LA TABLA user_users A PARTIR DEL ID DE LA TABLA
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gnm As New SqlCommand("SELECT nombre_completo from user_users where id='" + id + "'", c)
        c.Open()
        gnm_user_users = gnm.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function activepage() As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim acp As New SqlCommand("select case when count(*)>0 then 1 else 0 end as xst from basic_pi_ciclos where getdate() between startdate and enddate", c)
        c.Open()
        activepage = acp.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function isusertype(ByVal usuario As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim iut As New SqlCommand("select ISNULL(usertype,0) as usertype FROM secure_logins WHERE codigo='" + usuario + "'", c)
        c.Open()
        isusertype = iut.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function gettable(ByVal usuario As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim gttb As New SqlCommand("select tabla FROM secure_logins WHERE codigo='" + usuario + "'", c)
        c.Open()
        gettable = gttb.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function clavetrabajador(ByVal usuario As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ctb As New SqlCommand("Select clavetrab from user_users where usuario='" + usuario + "'", c)
        c.Open()
        clavetrabajador = ctb.ExecuteScalar.ToString
        c.Close()
    End Function


End Class
