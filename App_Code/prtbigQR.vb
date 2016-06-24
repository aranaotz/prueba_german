Imports System.Web.HttpContext
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports ASPPDFLib
Imports System.IO
Imports Microsoft.VisualBasic

Public Class prtbigQR
    Public Shared Sub printqr(mes As String, ByVal nombre As String, ByVal tam As String, ByVal textoqr As String, ByVal bw As String, ByVal cent As String)
        Dim objPdf As IPdfManager = New PdfManager
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(Current.Server.MapPath("\cgiapp\formatos\blankpage.pdf"), Missing.Value)
        objDoc.Title = "IMPRESION DE CODIGOS QR GRANDE"
        objDoc.Creator = "@ialvaroh"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        Dim center As String = (objPage.Width - CDbl(cent)) / 2
        objPage.Canvas.DrawBarcode2D(textoqr, "Type=3; Version=" & tam & "; X=" & center & "; Y=60; BarWidth=" & bw)


        'ASEGURAMOS EL PATH Y GUARDAMOS EL DOCUMENTO
        Dim pathdir As String = Current.Server.MapPath("\cgiapp\formatos\qrcodes\" & mes & "\")
        If Directory.Exists(pathdir) Then
            Dim path As String = Current.Server.MapPath("\cgiapp\formatos\qrcodes\" & mes & "\" & nombre & ".pdf")
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If (file.Exists) Then
                file.Delete()
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\qrcodes\" & mes & "\" & nombre & ".pdf"), False)
            Else
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\qrcodes\" & mes & "\" & nombre & ".pdf"), False)
            End If
        Else
            Directory.CreateDirectory(pathdir)
            Dim path As String = Current.Server.MapPath("\cgiapp\formatos\qrcodes\" & mes & "\" & nombre & ".pdf")
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If (file.Exists) Then
                file.Delete()
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\qrcodes\" & mes & "\" & nombre & ".pdf"), False)
            Else
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\qrcodes\" & mes & "\" & nombre & ".pdf"), False)
            End If
        End If
    End Sub
End Class
