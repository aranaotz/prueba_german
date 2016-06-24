Imports nuevousuario
Imports carreraCiclo
Imports cvgroups
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
Imports CrystalDecisions.Web
Imports System.IO
Imports CrystalDecisions.Shared
Partial Class contents_crv_prof_rpt_tutoria_individual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim matricula As String = Request.QueryString("ma")
        Dim ciclo As String = Request.QueryString("c")
        Dim tutor As String = Request.QueryString("t")

        Dim info_datos_alumno As Data.DataTable
        Dim tutoria_tema As Data.DataTable
        Dim tutoria_meta As Data.DataTable
        Dim nombre_alumno As Data.DataTable
        Dim tutoria_diagnostico As Data.DataTable

        Dim objrep As New ReportDocument



        info_datos_alumno = llenaAlumnoCrystalRep(matricula)
        tutoria_tema = cargaTemas(matricula, ciclo)
        tutoria_meta = cargaMetas(matricula, ciclo)
        nombre_alumno = nombreAlumno(matricula)
        tutoria_diagnostico = diagnosticoAlumno(matricula, ciclo)

        objrep.Load(Context.Server.MapPath("../reportes_prof/cr_registro_tutoria.rpt"))

        objrep.Database.Tables(0).SetDataSource(info_datos_alumno)


        objrep.Subreports(2).Database.Tables(0).SetDataSource(tutoria_tema)
        objrep.Subreports(1).Database.Tables(0).SetDataSource(tutoria_meta)
        objrep.Subreports(1).Database.Tables(1).SetDataSource(nombre_alumno)
        objrep.Subreports(0).Database.Tables(0).SetDataSource(tutoria_diagnostico)

        objrep.Refresh()
        objrep.SetParameterValue("tutor", tutor)
        objrep.SetParameterValue("ciclo", ciclo)







        ''objrep.Subreports.Item("cr_tutoria_tema.rpt").Database.Tables(0).SetDataSource(tutoria_tema)
        'objrep.Subreports.Item(("../reportes_prof/cr_tutoria_tema.rpt")).Database.Tables(0).SetDataSource(tutoria_tema)
        'objrep.Subreports.Item(("../reportes_prof/cr_tutoria_tema.rpt")).SetParameterValue("ciclo", ciclo)


        ''objrep.Subreports.Item("cr_tutoria_meta.rpt").Database.Tables(0).SetDataSource(tutoria_meta)
        'objrep.Subreports.Item(Context.Server.MapPath("../reportes_prof/cr_tutoria_meta.rpt")).Database.Tables(0).SetDataSource(tutoria_meta)
        ''objrep.Subreports.Item("cr_tutoria_diagnostico.rpt").Database.Tables(0).SetDataSource(tutoria_diagnostico)
        'objrep.Subreports.Item(Context.Server.MapPath("../reportes_prof/cr_tutoria_diagnostico.rpt")).Database.Tables(0).SetDataSource(tutoria_diagnostico)


        crv_tutoria.ReportSource = objrep


        'Exportar a dpf

        Response.Buffer = False
        Response.Clear()  'ClearContent, ClearHeaders

        objrep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Reporte tutorìa_" & matricula + "_" + Date.Now)









    End Sub
End Class
