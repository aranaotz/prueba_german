Imports reportes_querys
Imports carreraCiclo
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_pi_rpt_induccion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim carrera As String = Request.QueryString("ca")
        Dim turno_numero As String = Request.QueryString("tn")
        Dim ciclo As String = Request.QueryString("c")
        Dim turno_letra As String = Request.QueryString("tl")

        Dim listado As Data.DataTable
        Dim info_listado As Data.DataTable

        Dim objrep As New ReportDocument

        listado = listado_propedeutico_xcarreras(carrera, turno_numero, ciclo)
        info_listado = carrera_nivel(carrera, turno_letra, ciclo)

        objrep.Load(Context.Server.MapPath("../reportes_pi/sei006.rpt"))

        objrep.Database.Tables(0).SetDataSource(listado)
        objrep.Database.Tables(1).SetDataSource(info_listado)

        crv_induccion.ReportSource = objrep

        'Exportar a pdf

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Listado_" + ciclo + "_" + carrera + "_" + turno_letra + "_" + Date.Now)

    End Sub
End Class
