Imports se_docs
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_rpt_constancia_calificaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim matricula As String = Request.QueryString("ma")
        Dim turnoAlumno As String = tAlumno(matricula)

        Dim kardex As Data.DataTable
        Dim constancia As Data.DataTable
        Dim director As Data.DataTable
        Dim ciclo As Data.DataTable
        Dim turno As Data.DataTable


        Dim firma As String = firmaDirector(1)
        Dim firmapath As String = "http://189.208.134.87/siaaa/" + firma.Substring(0, firma.Length).Replace("\", "/")


        Dim objrep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        kardex = crvKardex(matricula)
        constancia = datosConstancia(matricula)
        director = datosDirector(1)
        ciclo = cicloActivo()
        turno = horaTurno(turnoAlumno)

        objrep.Load(Context.Server.MapPath("../reportes_se/cr_constancia_calificaciones.rpt"))

        objrep.Database.Tables(0).SetDataSource(kardex)
        objrep.Database.Tables(1).SetDataSource(constancia)
        objrep.Database.Tables(2).SetDataSource(director)
        objrep.Database.Tables(3).SetDataSource(ciclo)
        objrep.Database.Tables(4).SetDataSource(turno)

        objrep.SetParameterValue("firmaPath", firmapath)



        Dim widthfirma As Integer = 2000
        Dim heightfirma As Integer = 1500


        objrep.ReportDefinition.Sections("Section4").ReportObjects("firma").Width = widthfirma
        objrep.ReportDefinition.Sections("Section4").ReportObjects("firma").Height = heightfirma


        crv_constancia_calificaciones.ReportSource = objrep


        'Exportar a PDF

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Constancia_calificaciones_" & matricula)











    End Sub
End Class
