Imports reportes_querys
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_sin_entrevista
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ciclo As String = Request.QueryString("c")

        Dim sin_entrevista As Data.DataTable

        Dim objrep As New ReportDocument

        sin_entrevista = noEntrevista(ciclo)


        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_sin_entrevista.rpt"))

        objrep.Database.Tables(0).SetDataSource(sin_entrevista)

        crv_sin_entrevista.ReportSource = objrep


        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Sin_entrevista_" & ciclo + "_" + Date.Now)


    End Sub
End Class
