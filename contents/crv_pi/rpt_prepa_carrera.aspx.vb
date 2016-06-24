Imports reportes_querys
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_prepa_carrera
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ciclo As String = Request.QueryString("c")
        Dim carrera As String = Request.QueryString("ca")

        Dim prepa_carrera As Data.DataTable

        Dim objrep As New ReportDocument

        prepa_carrera = bachillerCarrera(ciclo, carrera)

        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_exani_carrera.rpt"))

        objrep.Database.Tables(0).SetDataSource(prepa_carrera)

        crv_prepa_carrera.ReportSource = objrep

        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Promedio_prepa_" & ciclo + "_" + carrera + "_" + Date.Now)

    End Sub
End Class
