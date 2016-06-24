Imports reportes_querys
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_razones_inscripcion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ciclo As String = Request.QueryString("c")


        Dim razones As Data.DataTable

        Dim objrep As New ReportDocument

        razones = razonInsc(ciclo)

        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_razones_inscripcion.rpt"))

        objrep.Database.Tables(0).SetDataSource(razones)

        crv_razones.ReportSource = objrep

        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Razones_inscripcion_" & ciclo + "_" + Date.Now)

    End Sub
End Class
