Imports escolar
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_prof_rpt_asistencia_final5m
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim icu As String = Request.QueryString("icu")

        Dim info_lista_asistencias As Data.DataTable
        Dim r_asistencias As Data.DataTable
        Dim r_final As Data.DataTable

        Dim objrep As New ReportDocument

        'info_lista_asistencias = info_icu(icu)
        'r_asistencias = datos4m(icu)
        'r_final = r_final_4m(icu)

        objrep.Load(Context.Server.MapPath("../reportes_prof/cr_asistencias_final5m.rpt"))


        objrep.Database.Tables(0).SetDataSource(info_lista_asistencias)
        objrep.Database.Tables(1).SetDataSource(r_asistencias)
        objrep.Database.Tables(2).SetDataSource(r_final)

        crv_m5.ReportSource = objrep

        'Exportar a dpf

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Reporte finalm5_" & icu + "_" + Date.Now)


    End Sub
End Class
