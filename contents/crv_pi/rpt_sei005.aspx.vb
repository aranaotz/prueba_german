Imports synpin_code
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_sei005
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ustring As String = Request.QueryString("u")

        Dim sei005 As Data.DataTable

        Dim objrep As New ReportDocument

        sei005 = datosreportei005(ustring)

        objrep.Load(Context.Server.MapPath("../reportes_pi/sei005.rpt"))

        objrep.Database.Tables(0).SetDataSource(sei005)

        crv_sei005.ReportSource = objrep


        'Exportar a PDF

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "sei005_" & ustring)

    End Sub
End Class
