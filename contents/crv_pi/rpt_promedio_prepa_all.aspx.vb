Imports reportes_querys
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_promedio_prepa_all
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ciclo As String = Request.QueryString("c")


        Dim prepa_carrera As Data.DataTable

        Dim objrep As New ReportDocument

        prepa_carrera = bachillerAll(ciclo)

        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_exani_carrera.rpt"))

        objrep.Database.Tables(0).SetDataSource(prepa_carrera)

        crv_prom_prepa_all.ReportSource = objrep

        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Promedio_prepa_" & ciclo + Date.Now)

    End Sub
End Class
