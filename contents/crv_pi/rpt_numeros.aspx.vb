Imports reportes_querys
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_numeros
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ciclo As String = Request.QueryString("c")


        Dim numeros As Data.DataTable

        Dim objrep As New ReportDocument

        numeros = seguimiento(ciclo)

        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_numeros.rpt"))

        objrep.Database.Tables(0).SetDataSource(numeros)

        crv_numeros.ReportSource = objrep

        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Seguimiento" & ciclo + "_" + Date.Now)

    End Sub
End Class
