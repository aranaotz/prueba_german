Imports Microsoft.VisualBasic
Imports System.Web

Public Class downdocument
    Shared Sub descarga(ByVal tipo As String, ByVal nombre As String, ByVal extension As String)
        Dim path As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\" + tipo + "\" + nombre + extension)
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)

        If (file.Exists) Then

            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name)
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString())
            HttpContext.Current.Response.ContentType = "application/octet-stream"
            HttpContext.Current.Response.WriteFile(file.FullName)
            HttpContext.Current.Response.End()
        Else
            HttpContext.Current.Response.Redirect("../glogin.aspx")
        End If
    End Sub
End Class
