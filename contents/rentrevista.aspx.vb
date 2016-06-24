Imports carreraCiclo
Imports reportes_querys
Imports exporttoexcel
Imports System.IO
Imports System.IO.TextWriter

Partial Class contents_rentrevista
    Inherits System.Web.UI.Page

    

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Alumnos no entrevistados - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rentrevista.ActiveViewIndex = 0

        End If
    End Sub
    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)

        hf_ciclo.Value = sender.commandArgument.ToString
        lb_exportar.CommandArgument = sender.commandArgument.ToString
        gv_noentrevista.DataSource = noEntrevista(sender.commandArgument.ToString)
        gv_noentrevista.DataBind()

        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If

        mv_rentrevista.ActiveViewIndex = 1



    End Sub


    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        gv_ciclos.DataSource = llenaCiclo()
        gv_ciclos.DataBind()
        mv_rentrevista.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs) Handles lb_exportar.Click
        'exportwf(noEntrevista(sender.commandArgument.ToString), "NoEntrevistados_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))

        'crystal reports
        Dim ciclo As String = hf_ciclo.Value

        Response.Redirect("~/contents/crv_pi/rpt_sin_entrevista.aspx?c=" + ciclo)





    End Sub
End Class
