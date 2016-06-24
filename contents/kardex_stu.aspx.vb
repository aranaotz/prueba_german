Imports escolar
Imports se_docs
Partial Class kardex_stu
    Inherits System.Web.UI.Page

    Private Sub kardex_stu_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llena_datos(Session("gcu"))
            fkardex(Session("gcu"))
            mv_kardex.ActiveViewIndex = 1
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


    'Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
    '    fv_datos.DataSource = guserdata(sender.CommandArgument.ToString)
    '    fv_datos.DataBind()
    '    mv_kardex.ActiveViewIndex = 1
    '    hf_mat.Value = sender.commandArgument.ToString
    'End Sub

    Private Sub llena_datos(ByVal matricula As String)
        fv_datos.DataSource = guserdata(matricula)
        fv_datos.DataBind()
        hf_mat.Value = matricula
    End Sub
    'Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
    '    gv_resultados.DataSource = busqueda_alkardex(secure_tools.securetext(tbx_busqueda.Text))
    '    gv_resultados.DataBind()
    'End Sub
    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        'mv_kardex.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_importar_Click(sender As Object, e As EventArgs) Handles lb_importar.Click

        'Dim matricula As String = hf_mat.Value

        'Response.Redirect("~/contents/crv_se/rpt_kardex.aspx?ma=" + matricula)

    End Sub
End Class