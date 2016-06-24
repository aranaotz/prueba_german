Imports carreraCiclo
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_dictamen_carrera_ciclo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ciclo As String = Request.QueryString("c")
        Dim carrera As String = Request.QueryString("ca")
        Dim turno As Integer = Request.QueryString("t")

        Dim dictamen_carrera_turno As Data.DataTable

        Dim objrep As New ReportDocument

        dictamen_carrera_turno = dicatamenFiltrado(ciclo, carrera, turno)

        objrep.Load(Context.Server.MapPath("../reportes_pi/cr_dictamen_carrera_turno.rpt"))

        objrep.Database.Tables(0).SetDataSource(dictamen_carrera_turno)

        crv_dictamen.ReportSource = objrep

        'Exportar a excel

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, Response, True, "Dictaminados_" & carrera + "_" & ciclo & "_" & turno & "_" & Date.Now)

    End Sub
End Class
