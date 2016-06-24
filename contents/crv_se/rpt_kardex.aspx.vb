Imports se_docs
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared

Partial Class contents_rpt_kardex
    Inherits System.Web.UI.Page





    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim matricula As String = Request.QueryString("ma")

        Dim kardex As Data.DataTable
        Dim datosAlumno As Data.DataTable
        Dim director As Data.DataTable


        Dim foto As String = imgKardex(matricula)
        Dim ruta As String = "http://189.208.134.87/siaaa/" + foto.Substring(0, foto.Length).Replace("\", "/")



        Dim firma As String = firmaDirector(1)
        Dim firmapath As String = "http://189.208.134.87/siaaa/" + firma.Substring(0, firma.Length).Replace("\", "/")




        Dim objrep As New CrystalDecisions.CrystalReports.Engine.ReportDocument


        kardex = crvKardex(matricula)
        datosAlumno = crvDatosAlumno(matricula)
        director = datosDirector(1)



        objrep.Load(Context.Server.MapPath("../reportes_se/cr_kardex.rpt"))




        objrep.Database.Tables(0).SetDataSource(kardex)
        objrep.Database.Tables(1).SetDataSource(datosAlumno)
        objrep.Database.Tables(2).SetDataSource(director)


        objrep.SetParameterValue("picturePath", ruta)
        objrep.SetParameterValue("firmaPath", firmapath)


        Dim widthfoto As Integer = 1000
        Dim heightfoto As Integer = 1200


        objrep.ReportDefinition.Sections("Section1").ReportObjects("foto").Width = widthfoto
        objrep.ReportDefinition.Sections("Section1").ReportObjects("foto").Height = heightfoto


        Dim widthfirma As Integer = 2000
        Dim heightfirma As Integer = 1500


        objrep.ReportDefinition.Sections("Section4").ReportObjects("firma").Width = widthfirma
        objrep.ReportDefinition.Sections("Section4").ReportObjects("firma").Height = heightfirma



        crv_kardex.ReportSource = objrep

        'Exportar a PDF

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Kardex_" & matricula)
        'objrep.ExportToHttpResponse(ExportFormatType.Excel, Response, True, "Kardex_" & matricula)













    End Sub





End Class
