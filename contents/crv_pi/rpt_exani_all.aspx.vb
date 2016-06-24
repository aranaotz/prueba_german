Imports reportes_querys
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_exani_all
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ciclo As String = Request.QueryString("c")


        Dim exani As Data.DataTable

        Dim objrep As New ReportDocument

        exani = promedioAll(ciclo)

        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_exani_all.rpt"))

        objrep.Database.Tables(0).SetDataSource(exani)

        crv_exani_all.ReportSource = objrep

        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Promedio_exani_General" & ciclo + "_" + Date.Now)

    End Sub
End Class
