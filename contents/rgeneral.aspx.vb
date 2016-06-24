Imports carreraCiclo
Imports reportes_querys
Imports exporttoexcel
Partial Class contents_rgeneral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rgeneral.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)

        lb_exportar.CommandArgument = sender.commandArgument.ToString

        gv_general.DataSource = general(sender.commandArgument.ToString)
        gv_general.DataBind()

        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If

        mv_rgeneral.ActiveViewIndex = 1

    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        gv_ciclos.DataSource = llenaCiclo()
        gv_ciclos.DataBind()
        mv_rgeneral.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs) Handles lb_exportar.Click
        exportwf(general(sender.commandArgument.ToString), "ReporteGeneral_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))
    End Sub
End Class
