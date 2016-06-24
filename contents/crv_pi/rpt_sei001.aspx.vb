Imports synpin_code
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_sei001
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ustring As String = Request.QueryString("u")

        Dim sei001 As Data.DataTable

        Dim objrep As New ReportDocument

        sei001 = datosreportei001(ustring)

        objrep.Load(Context.Server.MapPath("../reportes_pi/sei001.rpt"))

        objrep.Database.Tables(0).SetDataSource(sei001)

        crv_sei001.ReportSource = objrep


        'Exportar a PDF

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "sei001_" & ustring)


    End Sub
End Class
