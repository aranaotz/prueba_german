<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        'ALVARO MAQUINA VIRTUAL
        'Application("str") = "Data Source=192.168.15.129,6420;Initial Catalog=siaaa;Persist Security Info=True;User ID=sa;Password=alvacelA031"
        'GERMAN LOCAL
        'Application("str") = "Data Source=localhost;Initial Catalog=siaaa;Persist Security Info=True;User ID=sa;Password=11001"
        'CONSULTA EN SERVIDOR DESDE FUERA
        Application("str") = "Data Source=189.208.134.87,6425;Initial Catalog=siaaa;Persist Security Info=True;User ID=sa;Password=5?z/48Nk"
        'CONSULTA EN BASE ESPEJO DEL SERVIDOR
        'Application("str") = "Data Source=189.208.134.87,6425;Initial Catalog=siaaa_m;Persist Security Info=True;User ID=sa;Password=5?z/48Nk"
        'GERMAN LOCAL RESPALDO
        'Application("str") = "Data Source=localhost;Initial Catalog=siaaa_abajo;Persist Security Info=True;User ID=sa;Password=11001"
        'APLICACION CORRIENDO YA EN SERVIDOR
        'Application("str") = "Data Source=localhost;Initial Catalog=siaaa;Persist Security Info=True;User ID=sa;Password=5?z/48Nk"

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        'Session.Clear()
        'Response.Redirect("~/glogin.aspx")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       </script>