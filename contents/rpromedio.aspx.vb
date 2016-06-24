Imports carreraCiclo
Imports reportes_querys
'Imports programaeducativo
Imports System.IO
Imports System.IO.TextWriter
Imports exporttoexcel
Partial Class contents_rpromedio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Calificacion EXANI - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rpromedio.ActiveViewIndex = 0
        End If
    End Sub

    'Protected Sub ib_backClick(sender As Object, e As ImageClickEventArgs)

    '    mv_rpromedio.ActiveViewIndex = 1
    'End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        lbl_ciclo.Text = sender.commandArgument.ToString

        mv_rpromedio.ActiveViewIndex = 2
        gv_listado.DataSource = carreras_ya_importadas(lbl_ciclo.Text)
        gv_listado.DataBind()
    End Sub

    ' Protected Sub cmd_excel_Click(sender As Object, e As EventArgs) Handles cmd_excel.Click
    ''borrar el contenido del buffer
    '    Response.ClearContent()
    ''establecer el nombre de archivo predeterminado
    '    Response.AppendHeader("content-disposition", "attachment; filename=promedio_bachillerato.xls")
    '    Response.ContentType = "application/excel"
    '    'Imports System.IO
    '    'Imports System.IO.TextWriter
    '    'Crear una instancia de StringWriter para escribir información en una cadena
    '    Dim stringWriter As New StringWriter
    '    'Crear una instancia de la clase  HtmlTextWriter para escribir marcando caracteres y texto a
    '    'un output stream  
    '    Dim htmlTextWriter As New HtmlTextWriter(StringWriter)
    '        gv_promedio.RenderControl(htmlTextWriter)
    '   Response.Write(stringWriter.ToString())
    '        Response.End()
    '    End Sub
    '    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
    'MyBase.VerifyRenderingInServerForm(control)
    'End Sub

    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs) Handles lb_exportar.Click
        'exportwf(promedioCarrera(lbl_ciclo.Text, sender.commandArgument.ToString), "Promedios_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))
        Dim ciclo As String = lbl_ciclo.Text
        Dim carrera As String = lbl_carrera.Text

        Response.Redirect("~/contents/crv_pi/rpt_exani_carrera.aspx?c=" + ciclo + "&ca=" + carrera)

    End Sub

    Protected Sub lb_clave_Click(sender As Object, e As EventArgs)
        lbl_carrera.Text = sender.commandArgument.ToString
        lb_exportar.CommandArgument = sender.commandArgument.ToString
        gv_promedio.DataSource = promedioCarrera(lbl_ciclo.Text, sender.commandArgument.ToString)
        gv_promedio.DataBind()
        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If
        mv_rpromedio.ActiveViewIndex = 1
    End Sub

    Protected Sub ib_atras__Click(sender As Object, e As ImageClickEventArgs)
        gv_ciclos.DataSource = llenaCiclo()
        gv_ciclos.DataBind()
        mv_rpromedio.ActiveViewIndex = 0

    End Sub

    Protected Sub lb_all_Click(sender As Object, e As EventArgs) Handles lb_all.Click
        gv_promedioAll.DataSource = promedioAll(lbl_ciclo.Text)
        gv_promedioAll.DataBind()
        mv_rpromedio.ActiveViewIndex = 3
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        mv_rpromedio.ActiveViewIndex = 2
    End Sub

    Protected Sub lb_export_Click(sender As Object, e As EventArgs) Handles lb_export.Click
        'exportwf(promedioAll(lbl_ciclo.Text), "Promedios_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))

        Dim ciclo As String = lbl_ciclo.Text


        Response.Redirect("~/contents/crv_pi/rpt_exani_all.aspx?c=" + ciclo)

    End Sub
End Class
