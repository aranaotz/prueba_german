Imports se_docs
Imports synpin_code
Imports secure_tools

Partial Class contents_se_update_docs
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Actualización de Aranceles- SIAAA UTJ " + versiones()

        If Not IsPostBack Then
            mv_se_docs.ActiveViewIndex = 0
            gv_docs.DataSource = infoDocs()
            gv_docs.DataBind()
        End If



    End Sub


    Protected Sub lb_doc_Click(sender As Object, e As EventArgs)
        mod_update.Show()
        lbl_seleccionado.Text = descDoc(sender.CommandArgument.ToString)
        txt_importe.Text = precioDoc(sender.CommandArgument.ToString)
        txt_importe.Focus()
        txt_importe.Attributes.Add("onfocus", "this.select()")

    End Sub
    Protected Sub lb_nuevo_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        actualizaArancel(securetext(txt_importe.Text), lbl_seleccionado.Text)
        mv_se_docs.ActiveViewIndex = 0
        gv_docs.DataSource = infoDocs()
        gv_docs.DataBind()

    End Sub
End Class
