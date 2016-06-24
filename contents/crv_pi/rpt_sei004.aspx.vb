Imports synpin_code
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_sei004
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ustring As String = Request.QueryString("u")

        Dim sei004 As Data.DataTable

        Dim objrep As New ReportDocument

        sei004 = datosreportei004(ustring)

        objrep.Load(Context.Server.MapPath("../reportes_pi/sei004.rpt"))

        objrep.Database.Tables(0).SetDataSource(sei004)

        crv_sei004.ReportSource = objrep


        'Exportar a PDF

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "sei004_" & ustring)




    End Sub
End Class
