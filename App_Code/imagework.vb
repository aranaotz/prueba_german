Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Web.UI.WebControls
Imports ImageResizer
Imports System.Data
Imports System.Data.SqlClient

Public Class imagework
    Shared Sub SaveImageFile(ByVal sourceImagePath As String, ByVal saveImagePath As String, ByVal maxImageWidth As Integer)
        Dim sourceImage As Bitmap = New Bitmap(sourceImagePath)
        SaveImageFile(sourceImage, saveImagePath, maxImageWidth)
    End Sub


    Shared Sub SaveImageFile(ByVal clientFile As FileUpload, ByVal saveImagePath As String, ByVal maxImageWidth As Integer)
        Dim sourceImage As Bitmap = New Bitmap(clientFile.PostedFile.InputStream)
        SaveImageFile(sourceImage, saveImagePath, maxImageWidth)
    End Sub

    Shared Sub SaveImageFile(ByVal sourceImage As Bitmap, ByVal saveImagePath As String, ByVal maxImageWidth As Integer)
        'Resize if source image width is greater than the max:
        If (sourceImage.Width > maxImageWidth) Then
            Dim newImageHeight As Integer = CInt(sourceImage.Height) * (CDbl(maxImageWidth) / CDbl(sourceImage.Width))
            Dim resizedImage As Bitmap = New Bitmap(maxImageWidth, newImageHeight)
            Dim gr As Graphics = Graphics.FromImage(resizedImage)
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic
            gr.DrawImage(sourceImage, 0, 0, maxImageWidth, newImageHeight)
            'Save the resized image:
            resizedImage.Save(saveImagePath, FileExtensionToImageFormat(saveImagePath))
        Else
            'Save the source image (no resizing necessary):
            sourceImage.Save(saveImagePath, FileExtensionToImageFormat(saveImagePath))
        End If
    End Sub


    Shared Function FileExtensionToImageFormat(ByVal filePath As String) As ImageFormat
        Dim ext As String = Path.GetExtension(filePath).ToLower()
        Dim result As ImageFormat = ImageFormat.Jpeg
        Select Case ext
            Case ".gif"
                result = ImageFormat.Gif
            Case ".png"
                result = ImageFormat.Png
        End Select
        Return result
    End Function

    Shared Sub photocut(ByVal cual As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim photoset As New SqlDataAdapter("select uno,unoy,dos,dosy,tres,tresy from coordenadas where documento='photocut' and item='se-i003'", c)
        Dim pdt As New DataTable
        c.Open()
        photoset.Fill(pdt)
        c.Close()
        Dim original As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\usrdocs\images\" & cual & ".jpg")
        Dim newImage As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\usrdocs\minimages\" & cual & ".jpg")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(newImage)
        If (file.Exists) Then
            file.Delete()
        End If
        Dim w As String = Str(CInt(pdt.Rows(0).Item(0).ToString))
        Dim h As String = Str(CInt(pdt.Rows(0).Item(1).ToString))
        Dim a As String = Str(CInt(pdt.Rows(0).Item(2).ToString))
        Dim b As String = Str(CInt(pdt.Rows(0).Item(3).ToString))
        Dim c1 As String = Str(CInt(pdt.Rows(0).Item(4).ToString))
        Dim d As String = Str(CInt(pdt.Rows(0).Item(5).ToString))
        ImageBuilder.Current.Build(original, newImage, New ResizeSettings("width=" & w & "&height=" & h & "&crop=(" & a & "," & b & "," & c1 & "," & d & ")&s.grayscale=true"))
        'ImageBuilder.Current.Build(original, newImage, New ResizeSettings(CInt(w), CInt(h), FitMode.Stretch, "jpg"))
    End Sub

End Class