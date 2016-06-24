Imports carreraCiclo
Imports reportes_querys
Imports exporttoexcel
Partial Class contents_rrazones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Estadistica motivos de inscripcion - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rrazones.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        lbl_ciclo.Text = sender.commandArgument.ToString
        lb_exportar.CommandArgument.ToString()
        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If
        mv_rrazones.ActiveViewIndex = 1
        gv_razones.DataSource = razonInsc(lbl_ciclo.Text)
        gv_razones.DataBind()

    End Sub


    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_rrazones.ActiveViewIndex = 0

    End Sub

    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs)
        'exportwf(razonInsc(lbl_ciclo.Text), "Razones_Inscripcion_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))

        'crystal reports
        Response.Redirect("~/contents/crv_pi/rpt_razones_inscripcion.aspx?c=" + lbl_ciclo.Text)


    End Sub
End Class
