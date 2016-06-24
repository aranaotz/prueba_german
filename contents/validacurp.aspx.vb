Imports synpin_code
Imports dtciclos
Partial Class contents_validacurp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mv_general.ActiveViewIndex = 0
        End If
    End Sub
    Protected Sub cmd_continuar_Click(sender As Object, e As EventArgs) Handles cmd_continuar.Click

        If validaCurp(tbx_curp.Text, pi_cicloregistro) = True Then
            mv_general.ActiveViewIndex = 1

        Else
            Response.Redirect("http://siaaa.utj.edu.mx/siaaa/contents/regpin.aspx?cu=" & tbx_curp.Text)
            'Response.Redirect("http://localhost:1611/contents/regpin.aspx?cu=" & tbx_curp.Text)
        End If

    End Sub
    Protected Sub ib_regresar_Click(sender As Object, e As ImageClickEventArgs) Handles ib_regresar.Click
        mv_general.ActiveViewIndex = 0
        tbx_curp.Text = ""
    End Sub
    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs) Handles lb_regresar.Click
        mv_general.ActiveViewIndex = 0
        tbx_curp.Text = ""
    End Sub
End Class
