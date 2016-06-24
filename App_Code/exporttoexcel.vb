Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Web
Imports System
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Public Class exporttoexcel

    Shared Sub export2e(ByVal dt As DataTable, ByVal fn As String)

        Dim acontext As HttpContext = HttpContext.Current
        acontext.Response.Clear()
        Dim col As Integer
        For col = 0 To dt.Columns.Count - 1
            acontext.Response.Write(dt.Columns(col).ColumnName + ",")
        Next
        acontext.Response.Write(Environment.NewLine)
        Dim rw, cl As Integer
        For rw = 0 To dt.Rows.Count - 1
            For cl = 0 To dt.Columns.Count - 1
                acontext.Response.Write(dt.Rows(rw).Item(cl).ToString.Replace(",", String.Empty) + ",")
            Next
            acontext.Response.Write(Environment.NewLine)
        Next
        acontext.Response.ContentType = "excel"
        acontext.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fn + ".xlsx")
        'acontext.Response.ContentType = "text/csv"
        'acontext.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fn + ".csv")
        acontext.Response.End()
    End Sub

    Shared Sub exportwf(ByVal dt As DataTable, ByVal fn As String)
        If (dt.Rows.Count > 0) Then
            Dim sb As StringBuilder = New StringBuilder()
            Dim sw As StringWriter = New StringWriter(sb)
            Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
            Dim pagina As Page = New Page()
            Dim form As HtmlForm = New HtmlForm()
            Dim dg As GridView = New GridView()
            dg.EnableViewState = False
            dg.DataSource = dt
            dg.DataBind()
            pagina.EnableEventValidation = False
            pagina.DesignerInitialize()
            pagina.Controls.Add(form)
            form.Controls.Add(dg)
            pagina.RenderControl(htw)
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" & fn & ".xls")
            HttpContext.Current.Response.Charset = "UTF-8"
            HttpContext.Current.Response.ContentEncoding = Encoding.Default
            HttpContext.Current.Response.Write(sb.ToString())
            HttpContext.Current.Response.End()
        End If
    End Sub


End Class
