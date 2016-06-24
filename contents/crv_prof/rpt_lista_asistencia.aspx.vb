Imports escolar
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_prof_rpt_lista_asistencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim icu As String = Request.QueryString("icu")
        Dim p As String = Request.QueryString("p")
        Dim inicio As String = Request.QueryString("ini")
        Dim fin As String = Request.QueryString("f")

        Dim listas_curso As Data.DataTable
        Dim info_lista_asistencia_materias As Data.DataTable


        Dim objrep As New ReportDocument
        listas_curso = lista_icus(icu)
        info_lista_asistencia_materias = info_icu(icu)




        objrep.Load(Context.Server.MapPath("../reportes_prof/cr_lista_asistencia.rpt"))

        objrep.Database.Tables(0).SetDataSource(listas_curso)
        objrep.Database.Tables(1).SetDataSource(info_lista_asistencia_materias)

        objrep.SetParameterValue("periodo", p)



        crv_asistencia.ReportSource = objrep

        'Exportar a pdf

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Lista_asistencia_" & icu + "_" + Date.Now)



    End Sub
End Class
