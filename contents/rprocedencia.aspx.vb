Imports carreraCiclo
Imports reportes_querys
Imports exporttoexcel
Partial Class contents_rprocedencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Estadistica Escuelas de procedencia - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rprocedencia.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        lbl_ciclo.Text = sender.commandArgument.ToString

        lb_exportar.CommandArgument.ToString()
        gv_procedencia.DataSource = procedencia(sender.commandArgument.ToString)
        gv_procedencia.DataBind()
        lbl_ciclo1.Text = sender.commandArgument.ToString

        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If

        mv_rprocedencia.ActiveViewIndex = 1

    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        gv_ciclos.DataSource = llenaCiclo()
        gv_ciclos.DataBind()
        mv_rprocedencia.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_bachillerato_Click(sender As Object, e As EventArgs)
        lbl_bachillerato.Text = sender.commandArgument.ToString
        gv_detalle.DataSource = detalleBachi(lbl_bachillerato.Text)
        gv_detalle.DataBind()
        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)

        mv_rprocedencia.ActiveViewIndex = 2
    End Sub

    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs) Handles lb_exportar.Click

        Response.Redirect("~/contents/crv_pi/rpt_procedencia.aspx?c=" + lbl_ciclo.Text)
        'exportwf(procedencia(lbl_ciclo.Text), "Procedencia_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))
    End Sub



    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras.Click
        mv_rprocedencia.ActiveViewIndex = 1
    End Sub
End Class
