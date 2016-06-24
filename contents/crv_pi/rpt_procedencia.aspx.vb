Imports reportes_querys
Imports carreraCiclo
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_procedencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim ciclo As String = Request.QueryString("c")


        Dim procedencia_rpt As Data.DataTable


        Dim objrep As New ReportDocument

        procedencia_rpt = procedencia(ciclo)


        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_procedencia.rpt"))

        objrep.Database.Tables(0).SetDataSource(procedencia_rpt)


        crv_procedencia.ReportSource = objrep

        'Exportar a pdf

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Escuelas de procedencia" + ciclo + "_" + Date.Now)

    End Sub
End Class
