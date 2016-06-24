Imports carreraCiclo
Partial Class contents_rsinfolio
    Inherits System.Web.UI.Page

   
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "No importados - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rsinfolio.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)

    End Sub
End Class
