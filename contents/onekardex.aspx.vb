Imports escolar
Imports se_docs
Partial Class onekardex
    Inherits System.Web.UI.Page

    Private Sub onekardex_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fv_datos.DataSource = guserdata("2106100194")
            fv_datos.DataBind()
        End If
    End Sub

    Private Sub fv_datos_DataBound(sender As Object, e As EventArgs) Handles fv_datos.DataBound
        Dim matricula As String = CType(sender.FindControl("lbl_matricula"), Label).Text
        fkardex(matricula)
    End Sub

    Private Sub fkardex(ByVal matricula As String)
        dl_kardex.DataSource = cicloskardex(matricula)
        dl_kardex.DataBind()
    End Sub

    Protected Sub dl_kardex_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dl_kardex.ItemDataBound
        Dim matricula As String = CType(e.Item.FindControl("hf_matricula"), HiddenField).Value
        Dim cicloa As String = CType(e.Item.FindControl("lbl_ciclo"), Label).Text
        Dim gvciclo As GridView = CType(e.Item.FindControl("gv_calificaciones"), GridView)
        With gvciclo
            .DataSource = kardex_estudiante_kardex(matricula, cicloa)
            .DataBind()
            .EmptyDataText = "No se han encontrado registros en éste ciclo"
        End With
    End Sub


End Class