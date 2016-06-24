Imports carreraCiclo
Imports reportes_querys
Imports exporttoexcel
Partial Class contents_rdifusion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Estadistica medios de difusion - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rdifusion.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        lbl_ciclo.Text = sender.commandArgument.ToString
        lb_exportar.CommandArgument.ToString()
        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If
        mv_rdifusion.ActiveViewIndex = 1
        gv_difusion.DataSource = mediosDif(lbl_ciclo.Text)
        gv_difusion.DataBind()

    End Sub

    
    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_rdifusion.ActiveViewIndex = 0

    End Sub


    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs) Handles lb_exportar.Click
        'exportwf(mediosDif(lbl_ciclo.Text), "Razones_Inscripcion_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))

        'Crystal reports
        Response.Redirect("~/contents/crv_pi/rpt_medios_difusion.aspx?c=" + lbl_ciclo.Text)
    End Sub
End Class
