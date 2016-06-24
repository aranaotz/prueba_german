Imports synpin_code
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_sei003
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ustring As String = Request.QueryString("u")
        Dim dia_cita As String = Request.QueryString("c")
        Dim fecha_examen As String = Request.QueryString("f")

        Dim sei003 As Data.DataTable

        Dim ruta As String = "http://189.208.134.87/siaaa/docstock/usrdocs/minimages/" & ustring & ".jpg"

        Dim objrep As New ReportDocument


        sei003 = datosreportei003(ustring, dia_cita, fecha_examen)

        objrep.Load(Context.Server.MapPath("../reportes_pi/sei003.rpt"))

        objrep.Database.Tables(0).SetDataSource(sei003)

        objrep.SetParameterValue("picturePath", ruta)

        Dim widthfoto As Integer = 1000
        Dim heightfoto As Integer = 1200


        objrep.ReportDefinition.Sections("Section1").ReportObjects("foto").Width = widthfoto
        objrep.ReportDefinition.Sections("Section1").ReportObjects("foto").Height = heightfoto

        crv_sei003.ReportSource = objrep


        'Exportar a PDF

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "sei003_" & ustring)








    End Sub
End Class
