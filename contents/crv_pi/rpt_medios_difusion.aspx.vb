Imports reportes_querys
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_medios_difusion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ciclo As String = Request.QueryString("c")


        Dim medios As Data.DataTable

        Dim objrep As New ReportDocument

        medios = mediosDif(ciclo)

        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_medios_difusion.rpt"))

        objrep.Database.Tables(0).SetDataSource(medios)

        crv_medios.ReportSource = objrep

        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Medios_difusion_" & ciclo + "_" + Date.Now)

    End Sub
End Class
