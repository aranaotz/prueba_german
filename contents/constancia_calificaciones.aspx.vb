Imports escolar
Imports se_docs
Partial Class contents_constancia_calificaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mv_contastancia_calificaciones.ActiveViewIndex = 0
        End If
    End Sub
    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
        Dim matricula As String = sender.commandArgument.ToString

        Response.Redirect("~/contents/crv_se/rpt_constancia_calificaciones.aspx?ma=" + matricula)
    End Sub
    Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
        gv_resultados.DataSource = busqueda_alkardex(secure_tools.securetext(tbx_busqueda.Text))
        gv_resultados.DataBind()
    End Sub
End Class
