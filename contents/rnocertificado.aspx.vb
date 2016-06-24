Imports carreraCiclo
Imports reportes_querys
Imports exporttoexcel
Imports System.IO
Partial Class contents_rnocertificado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Alumnos sin certificado - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rnocertificado.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        gv_ciclos.DataSource = llenaCiclo()
        gv_ciclos.DataBind()
        mv_rnocertificado.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)

        lbl_ciclo.Text = sender.commandArgument.ToString
        lb_exportar.CommandArgument = sender.commandArgument.ToString
        gv_nocertificado.DataSource = nocertificado(sender.commandArgument.ToString)
        gv_nocertificado.DataBind()

        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If


        mv_rnocertificado.ActiveViewIndex = 1



    End Sub

    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs) Handles lb_exportar.Click
        'exportwf(nocertificado(sender.commandArgument.ToString), "SinCertificado_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))
        Dim ciclo As String = lbl_ciclo.Text

        Response.Redirect("~/contents/crv_pi/rpt_sin_certificado.aspx?c=" + ciclo)


    End Sub

   
End Class
