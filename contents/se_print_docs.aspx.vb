Imports synpin_code
Imports se_docs
Partial Class contents_se_print_docs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Impresión de documentos SE - SIAAA UTJ " + versiones()
        If Not IsPostBack Then
            mv_se_print_docs.ActiveViewIndex = 0
            gv_docs.DataSource = infoDocs()
            gv_docs.DataBind()
        End If

    End Sub

    Protected Sub lb_doc_Click(sender As Object, e As EventArgs)

    End Sub
End Class
