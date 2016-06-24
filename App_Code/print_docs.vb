Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Reflection
Imports ASPPDFLib
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports turntable_code
Imports synpin_code
Imports carreraCiclo


Public Class print_docs

    Shared Sub ccei002(ByVal nfile As String, ByVal slocation As String, ByVal location As String, ByVal mid As String, ByVal cs As String)
        Dim c As New SqlConnection(cs)
        Dim gtb As New SqlDataAdapter("SELECT codigo_unico, matricula, apellido_paterno, apellido_materno, nombre, sexo, f_nacimiento, edocivil, domicilio, " + _
                                      "colonia, municipio, estado, c_postal, l_nacimiento, curp, tipoyfactor, telefono, celular, correo, correo_inst, foto, " + _
                                      "n_tutor, ndomicilio, ocupacion, ntelefono, bachillerato, promedio FROM base_gendataal WHERE codigo_unico='" + mid + "'", c)

        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\utsyn\docsinventor\ccei002.pdf"), Missing.Value)
        objDoc.Title = "COMPROBANTE DE CAPTURA DE DATOS " & mid
        objDoc.Creator = mid
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\segoeui.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\segoeui.ttf")
        objPage.Canvas.DrawBarcode("" + mid + "", "x=510,y=735,width=80,height=7,type=17")

        Dim xvar As Integer
        Dim yvar As Double
        Dim inter As Double

        Dim dtsrc As New DataTable
        c.Open()
        gtb.Fill(dtsrc)
        c.Close()

        xvar = 230
        yvar = 647

        inter = 21.1

        Dim nmt As String = "x=" & xvar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(Format(Now, "dddd dd, MMMM yyyy"), nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(2).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(3).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(4).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(5).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(14).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(15).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(6).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(7).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter

        yvar = 427
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(8).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(9).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(10).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(12).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(16).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(17).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(18).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(19).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter

        yvar = 228
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(21).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(22).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(23).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(24).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter

        yvar = 115
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(25).ToString, nmt & "; y=" & yvar, objFont)
        yvar = yvar - inter
        objPage.Canvas.DrawText(dtsrc.Rows(0).Item(26).ToString, nmt & "; y=" & yvar, objFont)

        Dim path As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i002\" & mid & ".pdf")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i002\" & mid & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i002\" & mid & ".pdf"), False)
        End If
    End Sub

    Shared Function ccei004(ByVal icu As String, ByVal ciclo As String) As String
        Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\utsyn\docsinventor\CCEI004.pdf"), Missing.Value)
        objDoc.Title = "Acta de Integración Final de Calificaciones"
        objDoc.Creator = "Control Escolar UTZMG"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        'objPage.Canvas.DrawBarcode("" + matr + "", "x=76,y=473,width=50,height=10,type=17")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE
        Dim tc As DataTable = cabezaldata(icu)

        Dim xbar As Integer
        Dim ybar As Integer

        'TEXTO DEL ENCABEZADO DE REPORTE
        xbar = 90
        ybar = 673
        Dim textcur As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(5).ToString, textcur, objFont)
        'xbar = 100
        ybar = 656
        Dim textmaestro As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(4).ToString, textmaestro, objFont)
        'xbar = 100
        ybar = 639
        Dim textcarrera As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(7).ToString, textcarrera, objFont)
        xbar = 500
        ybar = 673
        Dim texticu As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(icu, texticu, objFont)
        'xbar = 343
        ybar = 656
        Dim textnivel As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(6).ToString, textnivel, objFont)
        'xbar = 478
        ybar = 639
        Dim textciclo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(3).ToString, textciclo, objFont)

        Dim gvtprint As DataTable = truepost(icu)
        Dim matrindx As Integer

        xbar = 26
        Dim x2bar As Integer = 90
        Dim x3bar As Integer = 407
        Dim x4bar As Integer = 350
        Dim x5bar As Integer = 465

        ybar = 605
        For matrindx = 0 To gvtprint.Rows.Count - 1
            Dim mt As String = gvtprint.Rows(matrindx).Item(0).ToString 'MATRICULA DEL ALUMNO
            Dim nm As String = gvtprint.Rows(matrindx).Item(1).ToString.Replace("&#209;", "Ñ") 'NOMBRE DEL ALUMNO
            Dim lt As String = gvtprint.Rows(matrindx).Item(4).ToString 'CALIFICACION LETRA
            Dim cr As String = gvtprint.Rows(matrindx).Item(5).ToString 'carrera
            Dim df As String = gvtprint.Rows(matrindx).Item(6).ToString 'definicion

            Dim nmt As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(mt, nmt, objFont)
            Dim evt As String = "x=" & x2bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(nm, evt, objFont)
            Dim ext As String = "x=" & x3bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(lt, ext, objFont)
            Dim ext1 As String = "x=" & x4bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(cr, ext1, objFont)
            Dim ext2 As String = "x=" & x5bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(df, ext2, objFont)


            'Dim separator = objDoc.OpenImage(Server.MapPath("\cgiapp\img\reportesep.gif"))
            'objPage.Canvas.DrawImage(separator, "x=170, y=" & ybar - 13)
            ybar = ybar - 12
        Next

        Dim nrep As String = icu & "-" & ciclo

        Dim path As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i004\" & nrep & ".pdf")

        'IMPRESION DE QR
        Dim pos_iurcb As String = "Type=3; X=415; Y=37; BarWidth=2"
        Dim pathqr As String = "http://200.52.200.111/" & "/utsyn/docstock/cce-i004/" & nrep & ".pdf"
        objPage.Canvas.DrawBarcode2D(pathqr, pos_iurcb)

        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i004\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i004\" & nrep & ".pdf"), False)
        End If
        ccei004 = nrep
    End Function

    Shared Function ccei007(ByVal icu As String, ByVal ciclo As String) As String
        Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\utsyn\docsinventor\CCEI007.pdf"), Missing.Value)
        objDoc.Title = "Lista de Asistencia"
        objDoc.Creator = "Control Escolar UTZMG"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")
        Dim coord As DataTable = coordenadas("cce-i007")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE
        Dim tc As DataTable = cabezaldata(icu)

        'TEXTO DEL ENCABEZADO DE REPORTE
        
        Dim textcur As String = "x=" & coord.Rows(0).Item(3).ToString & "; y=" & coord.Rows(0).Item(7).ToString & "; width=495; alignment=left; size=" & coord.Rows(0).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(5).ToString, textcur, objFont)
      
        Dim textmaestro As String = "x=" & coord.Rows(1).Item(3).ToString & "; y=" & coord.Rows(1).Item(7).ToString & "; width=495; alignment=left; size=" & coord.Rows(1).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(4).ToString, textmaestro, objFont)
        
        Dim textcarrera As String = "x=" & coord.Rows(2).Item(3).ToString & "; y=" & coord.Rows(2).Item(7).ToString & "; width=495; alignment=left; size=" & coord.Rows(2).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(7).ToString, textcarrera, objFont)
     
        Dim texticu As String = "x=" & coord.Rows(3).Item(3).ToString & "; y=" & coord.Rows(3).Item(7).ToString & "; width=495; alignment=left; size=" & coord.Rows(3).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(icu, texticu, objFont)
       
        Dim textnivel As String = "x=" & coord.Rows(4).Item(3).ToString & "; y=" & coord.Rows(4).Item(7).ToString & "; width=495; alignment=left; size=" & coord.Rows(4).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(6).ToString, textnivel, objFont)
        
        Dim textciclo As String = "x=" & coord.Rows(5).Item(3).ToString & "; y=" & coord.Rows(5).Item(7).ToString & "; width=495; alignment=left; size=" & coord.Rows(5).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(3).ToString, textciclo, objFont)

        Dim gvtprint As DataTable = lista_asistencia(icu)
        Dim matrindx As Integer
        Dim starty As String = coord.Rows(6).Item(7).ToString
        Dim startLine As String = coord.Rows(10).Item(7).ToString

        For matrindx = 0 To gvtprint.Rows.Count - 1
            Dim ls As String = gvtprint.Rows(matrindx).Item(0).ToString 'NUMERO DE LISTA
            Dim mt As String = gvtprint.Rows(matrindx).Item(1).ToString 'MATRICULA DEL ALUMNO
            Dim nm As String = gvtprint.Rows(matrindx).Item(2).ToString.Replace("&#209;", "Ñ") 'NOMBRE DEL ALUMNO

            Dim nmt As String = "x=" & coord.Rows(6).Item(3).ToString & "; y=" & starty & "; width=495; alignment=left; size=" & coord.Rows(6).Item(1).ToString
            objPage.Canvas.DrawText(ls, nmt, objFont)
            Dim evt As String = "x=" & coord.Rows(7).Item(3).ToString & "; y=" & starty & "; width=495; alignment=left; size=" & coord.Rows(7).Item(1).ToString
            objPage.Canvas.DrawText(mt, evt, objFont)
            Dim ext As String = "x=" & coord.Rows(8).Item(3).ToString & "; y=" & starty & "; width=495; alignment=left; size=" & coord.Rows(8).Item(1).ToString
            objPage.Canvas.DrawText(nm, ext, objFont)
            'objPage.Canvas.SetColor(coord.Rows(10).Item(5).ToString, coord.Rows(10).Item(6).ToString, coord.Rows(10).Item(9).ToString)
            'objPage.Canvas.DrawLine(coord.Rows(10).Item(3).ToString, startLine, coord.Rows(10).Item(4).ToString, startLine)
            'objPage.Canvas.RestoreState()
            starty = starty - CInt(coord.Rows(6).Item(2).ToString)
            'startLine = startLine - CInt(coord.Rows(10).Item(8).ToString)
        Next

        objPage.Canvas.SetColor(coord.Rows(10).Item(5).ToString, coord.Rows(10).Item(6).ToString, coord.Rows(10).Item(9).ToString)
        For matrindx = 0 To gvtprint.Rows.Count - 1
            objPage.Canvas.DrawLine(coord.Rows(10).Item(3).ToString, startLine, coord.Rows(10).Item(4).ToString, startLine)
            startLine = startLine - CInt(coord.Rows(10).Item(8).ToString)
        Next
        objPage.Canvas.RestoreState()

        Dim nrep As String = icu & "-" & ciclo

        Dim path As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i007\" & nrep & ".pdf")

        'IMPRESION DE QR
        Dim pos_iurcb As String = "Type=3; X=" & coord.Rows(9).Item(3).ToString & "; Y=" & coord.Rows(9).Item(7).ToString & "; BarWidth=2; "
        Dim pathqr As String = "http://200.52.200.111/" & "/utsyn/docstock/cce-i007/" & nrep & ".pdf"
        objPage.Canvas.SetColor(0, 0, 0)
        objPage.Canvas.DrawBarcode2D(pathqr, pos_iurcb)

        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i007\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i007\" & nrep & ".pdf"), False)
        End If
        ccei007 = nrep
    End Function

    Shared Sub ccei001(ByVal ustring As String)
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\siaaa\docsinventor\SEI001.pdf"), Missing.Value)
        objDoc.Title = "Comprobante de Registro UTJ"
        objDoc.Creator = "Aspirante"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        'ITERACIONES: SE OBTIENEN LOS PARAMETROS Y DATOS DE CADA UNO

        Dim tdfirst As DataTable = datosreportei001(ustring)
        Dim tdsec As DataTable = coordenadas("se-i001")
        Dim nv As Integer
        For nv = 0 To tdfirst.Columns.Count - 1

            Dim fontsize As String = tdsec.Rows(nv).Item(0).ToString
            Dim interlinea As String = tdsec.Rows(nv).Item(1).ToString
            Dim stil As String = 0

            Dim param_item As String = "x=" & tdsec.Rows(nv).Item(5).ToString & "; y=" & CStr(CDbl(tdsec.Rows(nv).Item(9).ToString) - CDbl(stil)) & "; width=495; alignment=left; size=" & fontsize & "; color=&H000000"
            objPage.Canvas.DrawText(tdfirst.Rows(0).Item(nv).ToString, param_item, objFont)
        Next

        Dim nrep As String = ustring
        Dim path As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\cce-i001\" & nrep & ".pdf")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Try
                'Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\cce-i001\" & nrep & ".pdf"), False)
                objDoc.Save(path, True)
            Catch ex As Exception

            End Try
        Else
            Try
                'Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\cce-i001\" & nrep & ".pdf"), False)
                objDoc.Save(path, True)
            Catch ex As Exception

            End Try

        End If
        file.Refresh()
    End Sub

    'se generan los dos documentos i005 e i006
    Shared Sub ccei005(ByVal nfile As String, ByVal parametros(,) As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\utsyn\docsinventor\ccei005i006.pdf"), Missing.Value)
        objDoc.Title = "COMPROBANTE DE REGISTRO"
        objDoc.Creator = nfile
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\segoeui.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\segoeui.ttf")
        objPage.Canvas.DrawBarcode(nfile, "x=460,y=685,width=100,height=5,type=17")
        Dim imageuser As IPdfImage = objDoc.OpenImage(HttpContext.Current.Server.MapPath("\utsyn\photo\mini\" & parametros(38, 0) & ".jpg"))
        Dim imageqr As IPdfImage = objDoc.OpenImage(HttpContext.Current.Server.MapPath("\utsyn\qrcodes\mini\" & parametros(38, 0) & ".jpg"))

        Dim tdsec As DataTable = coordenadas("cce-i005")
        Dim nv As Integer
        For nv = 0 To 54
            Dim fontsize As String = tdsec.Rows(nv).Item(0).ToString
            Dim interlinea As String = tdsec.Rows(nv).Item(1).ToString
            Dim stil As String = 0
            Dim param_item As String = "x=" & tdsec.Rows(nv).Item(5).ToString & "; y=" & CStr(CDbl(tdsec.Rows(nv).Item(9).ToString) - CDbl(stil)) & "; width=495; alignment=left; size=" & fontsize & "; color=&H000000"
            objPage.Canvas.DrawText(parametros(nv, 0), param_item, objFont)
        Next

        Dim tdter As DataTable = coordenadas("cce-i006")
        Dim page2a As IPdfPage = objDoc.Pages(2)
        page2a.Canvas.DrawBarcode(nfile, "x=475,y=731,width=100,height=5,type=17")
        For nv = 0 To 10
            Dim fontsize As String = tdter.Rows(nv).Item(0).ToString
            Dim interlinea As String = tdter.Rows(nv).Item(1).ToString
            Dim stil As String = 0
            Dim param_item As String = "x=" & tdter.Rows(nv).Item(5).ToString & "; y=" & CStr(CDbl(tdter.Rows(nv).Item(9).ToString) - CDbl(stil)) & "; width=495; alignment=left; size=" & fontsize & "; color=&H000000"
            page2a.Canvas.DrawText(IIf(parametros(nv, 1) = "1", "X", IIf(parametros(nv, 1) = "0", "", parametros(nv, 1))), param_item, objFont)
        Next

        Dim pag2a1 As IPdfPage = objDoc.Pages(3)
        pag2a1.Canvas.DrawBarcode(nfile, "x=475,y=731,width=100,height=5,type=17")
        For nv = 0 To 10
            Dim fontsize As String = tdter.Rows(nv).Item(0).ToString
            Dim interlinea As String = tdter.Rows(nv).Item(1).ToString
            Dim stil As String = 0
            Dim param_item As String = "x=" & tdter.Rows(nv).Item(5).ToString & "; y=" & CStr(CDbl(tdter.Rows(nv).Item(9).ToString) - CDbl(stil)) & "; width=495; alignment=left; size=" & fontsize & "; color=&H000000"
            pag2a1.Canvas.DrawText(IIf(parametros(nv, 1) = "1", "X", IIf(parametros(nv, 1) = "0", "", parametros(nv, 1))), param_item, objFont)
        Next

        Dim imageparam As New DataTable
        Dim ip As New SqlDataAdapter("SELECT description, tres, tresy FROM coordenadas WHERE (documento = 'imagei005') ORDER BY id", c)
        c.Open()
        ip.Fill(imageparam)
        c.Close()

        Dim parametrofoto As IPdfParam = objPdf.CreateParam
        Dim i As Integer
        For i = 0 To imageparam.Rows.Count - 1
            parametrofoto.Add(imageparam.Rows(i).Item(0).ToString & " = " & imageparam.Rows(i).Item(1).ToString)
        Next
        objPage.Canvas.DrawImage(imageuser, parametrofoto)

        Dim qrparam As New DataTable
        Dim qrp As New SqlDataAdapter("SELECT description, tres, tresy FROM coordenadas WHERE (documento = 'imagei006') ORDER BY id", c)
        c.Open()
        qrp.Fill(qrparam)
        c.Close()

        Dim parametroqr As IPdfParam = objPdf.CreateParam
        For i = 0 To imageparam.Rows.Count - 1
            parametroqr.Add(qrparam.Rows(i).Item(0).ToString & " = " & qrparam.Rows(i).Item(1).ToString)
        Next
        page2a.Canvas.DrawImage(imageqr, parametroqr)
        pag2a1.Canvas.DrawImage(imageqr, parametroqr)

        Dim path As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i005\" & nfile & ".pdf")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i005\" & nfile & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i005\" & nfile & ".pdf"), False)
        End If
    End Sub
    Shared Function ccei008(ByVal icu As String, ByVal ciclo As String) As String
        Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\utsyn\docsinventor\CCEI008.pdf"), Missing.Value)
        objDoc.Title = "Lista de Asistencia"
        objDoc.Creator = "Control Escolar UTZMG"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")
        Dim coord As DataTable = coordenadas("cce-i008")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE
        Dim tc As DataTable = cabezaldata(icu)

        'TEXTO DEL ENCABEZADO DE REPORTE

        Dim textcur As String = "x=" & coord.Rows(0).Item(3).ToString & "; y=" & coord.Rows(0).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(0).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(5).ToString, textcur, objFont)

        Dim textmaestro As String = "x=" & coord.Rows(1).Item(3).ToString & "; y=" & coord.Rows(1).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(1).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(4).ToString, textmaestro, objFont)

        Dim textcarrera As String = "x=" & coord.Rows(2).Item(3).ToString & "; y=" & coord.Rows(2).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(2).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(7).ToString, textcarrera, objFont)

        Dim texticu As String = "x=" & coord.Rows(3).Item(3).ToString & "; y=" & coord.Rows(3).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(3).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(icu, texticu, objFont)

        Dim textnivel As String = "x=" & coord.Rows(4).Item(3).ToString & "; y=" & coord.Rows(4).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(4).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(6).ToString, textnivel, objFont)

        Dim textciclo As String = "x=" & coord.Rows(5).Item(3).ToString & "; y=" & coord.Rows(5).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(5).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(3).ToString, textciclo, objFont)

        Dim nrep As String = icu & "-" & ciclo

        'IMPRESION DE QR
        Dim pos_iurcb As String = "Type=3; X=" & coord.Rows(9).Item(3).ToString & "; Y=" & coord.Rows(9).Item(7).ToString & "; BarWidth=2; "
        Dim pathqr As String = "http://189.192.132.229/" & "/utsyn/docstock/cce-i008/" & nrep & ".pdf"
        objPage.Canvas.SetColor(0, 0, 0)
        objPage.Canvas.DrawBarcode2D(pathqr, pos_iurcb)

        'IMPRESION DE LA FECHA
        Dim textfecha As String = "x=" & coord.Rows(11).Item(3).ToString & "; y=" & coord.Rows(11).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(11).Item(1).ToString & "; color=&H000000"
        objPage.Canvas.DrawText("Documento cce-i008 impreso el " & Format(Now, "dddd dd, MMMM, yyyy"), textfecha, objFont)

        'IMPRESION DE CUERPO
        Dim gvtprint As DataTable = lista_asistencia(icu)
        Dim matrindx As Integer
        Dim starty As String = coord.Rows(6).Item(7).ToString
        Dim startLine As String = coord.Rows(10).Item(7).ToString

        For matrindx = 0 To gvtprint.Rows.Count - 1
            Dim ls As String = gvtprint.Rows(matrindx).Item(0).ToString 'NUMERO DE LISTA
            Dim mt As String = gvtprint.Rows(matrindx).Item(1).ToString 'MATRICULA DEL ALUMNO
            Dim nm As String = gvtprint.Rows(matrindx).Item(2).ToString.Replace("&#209;", "Ñ") 'NOMBRE DEL ALUMNO

            Dim nmt As String = "x=" & coord.Rows(6).Item(3).ToString & "; y=" & starty & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(6).Item(1).ToString
            objPage.Canvas.DrawText(ls, nmt, objFont)
            Dim evt As String = "x=" & coord.Rows(7).Item(3).ToString & "; y=" & starty & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(7).Item(1).ToString
            objPage.Canvas.DrawText(mt, evt, objFont)
            Dim ext As String = "x=" & coord.Rows(8).Item(3).ToString & "; y=" & starty & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(8).Item(1).ToString
            objPage.Canvas.DrawText(nm, ext, objFont)
            'objPage.Canvas.SetColor(coord.Rows(10).Item(5).ToString, coord.Rows(10).Item(6).ToString, coord.Rows(10).Item(9).ToString)
            'objPage.Canvas.DrawLine(coord.Rows(10).Item(3).ToString, startLine, coord.Rows(10).Item(4).ToString, startLine)
            'objPage.Canvas.RestoreState()
            starty = starty - CInt(coord.Rows(6).Item(2).ToString)
            'startLine = startLine - CInt(coord.Rows(10).Item(8).ToString)
        Next

        objPage.Canvas.SetColor(coord.Rows(10).Item(5).ToString, coord.Rows(10).Item(6).ToString, coord.Rows(10).Item(9).ToString)
        For matrindx = 0 To gvtprint.Rows.Count - 1
            objPage.Canvas.DrawLine(coord.Rows(10).Item(3).ToString, startLine, coord.Rows(10).Item(4).ToString, startLine)
            startLine = startLine - CInt(coord.Rows(10).Item(8).ToString)
        Next
        objPage.Canvas.RestoreState()

        Dim path As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i008\" & nrep & ".pdf")

        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i008\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i008\" & nrep & ".pdf"), False)
        End If
        ccei008 = nrep
    End Function

    Shared Function ccei009(ByVal icu As String, ByVal ciclo As String, ByVal id_unidad As String) As String
        Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\utsyn\docsinventor\CCEI009.pdf"), Missing.Value)
        objDoc.Title = "Impresion parcial de calificaciones"
        objDoc.Creator = "Control Escolar UTZMG"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE
        Dim ut As String = nombre_ut(id_unidad)
        Dim tc As DataTable = cabezaldata(icu)

        Dim xbar As Integer
        Dim ybar As Integer

        'TEXTO DEL ENCABEZADO DE REPORTE
        xbar = 90
        ybar = 673
        Dim textcur As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10; color=&H000000"
        objPage.Canvas.DrawText(tc.Rows(0).Item(5).ToString, textcur, objFont)

        ybar = 656
        Dim textmaestro As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(4).ToString, textmaestro, objFont)

        ybar = 639
        Dim textcarrera As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(7).ToString, textcarrera, objFont)

        ybar = 622
        Dim textut As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10; color=&H000000"
        objPage.Canvas.DrawText(ut, textut, objFont)

        xbar = 500
        ybar = 673
        Dim texticu As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(icu, texticu, objFont)
        'xbar = 343
        ybar = 656
        Dim textnivel As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(6).ToString, textnivel, objFont)
        'xbar = 478
        ybar = 639
        Dim textciclo As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
        objPage.Canvas.DrawText(tc.Rows(0).Item(3).ToString, textciclo, objFont)

        Dim gvtprint As DataTable = truepost_ut(icu, id_unidad)
        Dim matrindx As Integer

        xbar = 26
        Dim x2bar As Integer = 90
        Dim x3bar As Integer = 407
        Dim x4bar As Integer = 350
        Dim x5bar As Integer = 465

        ybar = 588
        For matrindx = 0 To gvtprint.Rows.Count - 1
            Dim mt As String = gvtprint.Rows(matrindx).Item(0).ToString 'MATRICULA DEL ALUMNO
            Dim nm As String = gvtprint.Rows(matrindx).Item(1).ToString.Replace("&#209;", "Ñ") 'NOMBRE DEL ALUMNO
            Dim lt As String = gvtprint.Rows(matrindx).Item(4).ToString 'CALIFICACION LETRA
            Dim cr As String = gvtprint.Rows(matrindx).Item(5).ToString 'carrera
            Dim df As String = gvtprint.Rows(matrindx).Item(6).ToString 'definicion

            Dim nmt As String = "x=" & xbar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(mt, nmt, objFont)
            Dim evt As String = "x=" & x2bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(nm, evt, objFont)
            Dim ext As String = "x=" & x3bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(lt, ext, objFont)
            Dim ext1 As String = "x=" & x4bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(cr, ext1, objFont)
            Dim ext2 As String = "x=" & x5bar & "; y=" & ybar & "; width=495; alignment=left; size=10"
            objPage.Canvas.DrawText(df, ext2, objFont)

            ybar = ybar - 12
        Next

        Dim nrep As String = id_unidad & "_" & icu & "_" & ciclo

        Dim path As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i009\" & nrep & ".pdf")

        'IMPRESION DE QR
        Dim pos_iurcb As String = "Type=3; X=415; Y=54; BarWidth=2"
        Dim pathqr As String = "http://189.192.132.229/" & "/utsyn/docstock/cce-i009/" & nrep & ".pdf"
        objPage.Canvas.DrawBarcode2D(pathqr, pos_iurcb)

        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i009\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\cce-i009\" & nrep & ".pdf"), False)
        End If
        ccei009 = nrep
    End Function

    Shared Function fini001(ByVal matricula As String) As String
        Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\utsyn\docsinventor\FINI001.pdf"), Missing.Value)
        objDoc.Title = "Impresion de órden de pago"
        objDoc.Creator = "Finanzas UTZMG"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE
        Dim dt As New SqlDataAdapter("SELECT item, description, fuente, interlin, uno, unoy, documento, dos, dosy, tres, tresy FROM coordenadas " + _
                                     "WHERE (documento = 'fin-i001') order by id", sc)
        Dim dtt As New DataTable
        sc.Open()
        dt.Fill(dtt)
        sc.Close()

        Dim dy As New SqlDataAdapter("SELECT ua.cve_ref, ua.matricula, ua.nombre_completo, ia.nombre, 'total' AS total, 'inicio' AS tabla FROM " + _
                                     "user_alumnos AS ua LEFT OUTER JOIN info_carreras AS ia ON ua.carrera = ia.cv_carrera " + _
                                     "WHERE (ua.matricula = '" + matricula + "')", sc)
        Dim dyt As New DataTable
        sc.Open()
        dy.Fill(dyt)
        sc.Close()

        Dim x As Integer
        For x = 0 To 3
            Dim textcur As String = "x=" & dtt.Rows(x).Item(4).ToString & "; y=" & dtt.Rows(x).Item(5).ToString & "; width=" & dtt.Rows(x).Item(9).ToString & _
                "; alignment=" & dtt.Rows(x).Item(10).ToString & "; size=" & dtt.Rows(x).Item(2).ToString & ";color=&H000000"
            objPage.Canvas.DrawText(dyt.Rows(0).Item(x).ToString, textcur, objFont)
        Next

        'total de adeudo
        Dim ta As New SqlCommand("SELECT SUM(cantidad_original) AS total FROM (SELECT af.serie_concepto, cp.n_c, af.id_ciclo, af.fecha_limite, " + _
                                     "af.cantidad_original FROM account_freeway AS af LEFT OUTER JOIN account_conceptos_pagos AS cp " + _
                                     "ON af.id_concepto = cp.id_c WHERE (af.matricula = '" + matricula + "') AND (af.debe > 0)) AS primaria", sc)
        sc.Open()
        Dim tat As String = ta.ExecuteScalar.ToString
        sc.Close()

        Dim textcur1 As String = "x=" & dtt.Rows(4).Item(4).ToString & "; y=" & dtt.Rows(4).Item(5).ToString & "; width=" & dtt.Rows(4).Item(9).ToString & _
            "; alignment=" & dtt.Rows(4).Item(10).ToString & "; size=" & dtt.Rows(4).Item(2).ToString & "; color=&H000000"
        objPage.Canvas.DrawText("$ " & tat, textcur1, objFont)

        'CODIGO DE BARRAS
        Dim coderef As String = "x=" & dtt.Rows(7).Item(4).ToString & "; y=" & dtt.Rows(7).Item(5).ToString & _
            "; width=" & dtt.Rows(7).Item(8).ToString & "; height=" & dtt.Rows(7).Item(7).ToString & _
            "; alignment=center; size=" & dtt.Rows(4).Item(2).ToString & "; color=&H000000; type=17"
        objPage.Canvas.DrawBarcode(dyt.Rows(0).Item(0).ToString, coderef)

        'TABLA DE CONCEPTOS DE PAGO
        Dim tp As New SqlDataAdapter("SELECT af.serie_concepto, cp.n_c, af.id_ciclo, CONVERT(numeric(18, 2), af.debe) AS debe, CONVERT(varchar(10), af.fecha_limite, 103) AS limite FROM account_freeway AS af LEFT OUTER JOIN account_conceptos_pagos AS cp " + _
                                     "ON af.id_concepto = cp.id_c WHERE (af.matricula = '" + matricula + "') AND (af.debe>0) ORDER BY af.fecha_limite", sc)
        Dim tabla_conceptos As New DataTable
        sc.Open()
        tp.Fill(tabla_conceptos)
        sc.Close()

        'Dim multiplicador1 As Integer = (multiplicador) - 20
        Dim th As IPdfTable = objDoc.CreateTable("Width=" & dtt.Rows(5).Item(9).ToString & ";Height=0;rows=1;cols=5;border=0.1;" & _
                                                 "bordercolor=black;cellbordercolor=black;cellborder=0.1;cellpadding=1")
        th.Font = objFont
        Dim HeaderRow As IPdfRow = th.Rows(1)
        HeaderRow.Height = 14
        With HeaderRow
            .BgColor = &H0
            .Cells(1).AddText("CxC", "alignment=center; color=&HFFFFFF")
            .Cells(1).Width = 60
            .Cells(2).AddText("CONCEPTO", "alignment=center; color=&HFFFFFF")
            .Cells(2).Width = dtt.Rows(5).Item(7).ToString
            .Cells(3).AddText("CICLO", "alignment=center; color=&HFFFFFF")
            .Cells(3).Width = 30
            .Cells(4).AddText("MONTO", "alignment=center; color=&HFFFFFF")
            .Cells(4).Width = 60
            .Cells(5).AddText("FECHA", "alignment=center; color=&HFFFFFF")
            .Cells(5).Width = 60
        End With
        Dim col As Integer
        Dim rw As Integer
        For rw = 0 To tabla_conceptos.Rows.Count - 1
            Dim nextrow As IPdfRow = th.Rows.Add(dtt.Rows(5).Item(8).ToString)
            For col = 0 To 4
                Dim celda As IPdfCell = nextrow.Cells(col + 1)
                If col = 1 Then
                    celda.AddText(tabla_conceptos.Rows(rw).Item(col).ToString, "alignment=left" & _
                          "; expand=true; size=" & dtt.Rows(5).Item(2).ToString & "; color=&H000000", objFont)
                Else
                    celda.AddText(tabla_conceptos.Rows(rw).Item(col).ToString, "alignment=center" & _
                              "; expand=true; size=" & dtt.Rows(5).Item(2).ToString & "; color=&H000000", objFont)
                End If
            Next
        Next
        'multiplicador = (rw + 1)
        objPage.Canvas.DrawTable(th, "x=" & dtt.Rows(5).Item(4).ToString & ";y=" & dtt.Rows(5).Item(5).ToString & ";VAlignment=middle;alignment=center")

        Dim nrep As String = matricula

        Dim path As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\fin-i001\" & nrep & ".pdf")

        'IMPRESION DE QR
        Dim pos_iurcb As String = "Type=" & dtt.Rows(6).Item(8).ToString & "; X=" & dtt.Rows(6).Item(4).ToString & "; Y=" & dtt.Rows(6).Item(5).ToString & _
            "; BarWidth=" & dtt.Rows(6).Item(7).ToString & "; color=&H000000"
        Dim pathqr As String = "http://189.192.132.229/" & "/utsyn/docstock/fin-i001/" & nrep & ".pdf"
        objPage.Canvas.DrawBarcode2D(pathqr, pos_iurcb)

        Dim perpath As String = HttpContext.Current.Server.MapPath("\utsyn\docstock\utzmg_doctail\" & matricula & "\fin-i001\")
        If Not Directory.Exists(perpath) Then
            Directory.CreateDirectory(perpath)
        End If

        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\fin-i001\" & nrep & ".pdf"), False)
            file.CopyTo(HttpContext.Current.Server.MapPath("\utsyn\docstock\utzmg_doctail\" & matricula & "\fin-i001\" & nrep & _
                                                           Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & ".pdf"))
        Else
            objDoc.Save(HttpContext.Current.Server.MapPath("\utsyn\docstock\fin-i001\" & nrep & ".pdf"), False)
            file.CopyTo(HttpContext.Current.Server.MapPath("\utsyn\docstock\utzmg_doctail\" & matricula & "\fin-i001\" & nrep & _
                                                           Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & ".pdf"))
        End If
        fini001 = nrep
    End Function

    Shared Function sei003(ByVal ustring As String, ByVal dia_d_cita As String, ByVal fecha_examen As String) As String
        Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\siaaa\docsinventor\SEI003.pdf"), Missing.Value)
        objDoc.Title = "Comprobante del Proceso de Seleccion"
        objDoc.Creator = "Servicios Escolares UTJ"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")
        Dim imageuser As IPdfImage
        Try
            imageuser = objDoc.OpenImage(HttpContext.Current.Server.MapPath("\siaaa\docstock\usrdocs\minimages\" & ustring & ".jpg"))
        Catch ex As Exception
            imageuser = objDoc.OpenImage(HttpContext.Current.Server.MapPath("\siaaa\docstock\usrdocs\minimages\" & ustring & ".png"))
        End Try

        ' Dim imageqr As IPdfImage = objDoc.OpenImage(HttpContext.Current.Server.MapPath("\siaaa\qrcodes\mini\" & ustring & ".jpg"))

        'IMPRESION DE IMAGENES<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>
        Dim imageparam As New DataTable
        Dim ip As New SqlDataAdapter("SELECT description, tres, tresy FROM coordenadas WHERE (documento = 'image_sei003') ORDER BY id", sc)
        sc.Open()
        ip.Fill(imageparam)
        sc.Close()

        Dim qrparam As New DataTable
        Dim qrp As New SqlDataAdapter("SELECT description, tres, tresy FROM coordenadas WHERE (documento = 'image_sei003QR') ORDER BY id", sc)
        sc.Open()
        qrp.Fill(qrparam)
        sc.Close()

        Dim parametrofoto As IPdfParam = objPdf.CreateParam
        Dim i As Integer
        For i = 0 To imageparam.Rows.Count - 1
            parametrofoto.Add(imageparam.Rows(i).Item(0).ToString & " = " & imageparam.Rows(i).Item(1).ToString)
        Next
        objPage.Canvas.DrawImage(imageuser, parametrofoto)

        Dim parametroqr As IPdfParam = objPdf.CreateParam
        For i = 0 To qrparam.Rows.Count - 1
            parametroqr.Add(qrparam.Rows(i).Item(0).ToString & " = " & qrparam.Rows(i).Item(1).ToString)
        Next
        'objPage.Canvas.DrawImage(imageqr, parametroqr)
        '>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<


        'ITERACIONES: SE OBTIENEN LOS PARAMETROS Y DATOS DE CADA UNO

        Dim tdfirst As DataTable = datosreportei003(ustring, dia_d_cita, fecha_examen)
        Dim tdsec As DataTable = coordenadas("se-i003")
        Dim nv As Integer
        For nv = 0 To tdfirst.Columns.Count - 1

            Dim fontsize As String = tdsec.Rows(nv).Item(0).ToString
            Dim interlinea As String = tdsec.Rows(nv).Item(1).ToString
            Dim stil As String = 0

            Dim param_item As String = "x=" & tdsec.Rows(nv).Item(5).ToString & "; y=" & CStr(CDbl(tdsec.Rows(nv).Item(9).ToString) - CDbl(stil)) & "; width=495; alignment=left; size=" & fontsize & "; color=&H000000"
            objPage.Canvas.DrawText(tdfirst.Rows(0).Item(nv).ToString, param_item, objFont)
        Next

        Dim nrep As String = ustring
        Dim path As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i003\" & nrep & ".pdf")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i003\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i003\" & nrep & ".pdf"), False)
        End If
    End Function

    Shared Sub sei004(ByVal ustring As String)
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\siaaa\docsinventor\SEI004.pdf"), Missing.Value)
        objDoc.Title = "Carta Responsiva"
        objDoc.Creator = "Aspirante"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")
        Dim objFont_cgn As IPdfFont = objDoc.Fonts.LoadFromFile("C:\Windows\Fonts\GOTHIC.TTF")

        'DATOS A IMPRIMIR Y PARAMETROS DEL REPORTE (ALINEACIONES)

        Dim tdfirst As DataTable = datosreportei004(ustring)
        Dim tdsec As DataTable = coordenadas("se-i004")
        Dim nv As Integer
        For nv = 0 To tdfirst.Columns.Count - 1

            Dim fontsize As String = tdsec.Rows(nv).Item(1).ToString
            Dim interlinea As String = tdsec.Rows(nv).Item(2).ToString
            Dim alineamiento As String = tdsec.Rows(nv).Item(3).ToString
            Dim ancho As String = tdsec.Rows(nv).Item(4).ToString
            Dim stil As String = 0

            Dim param_item As String = "x=" & tdsec.Rows(nv).Item(5).ToString & "; y=" & CStr(CDbl(tdsec.Rows(nv).Item(9).ToString) - CDbl(stil)) _
                                       & "; width=" & tdsec.Rows(nv).Item(4).ToString & "; alignment=" & tdsec.Rows(nv).Item(3).ToString & "; size=" & fontsize
            objPage.Canvas.DrawText(tdfirst.Rows(0).Item(nv).ToString, param_item, objFont_cgn)
        Next

        Dim nrep As String = ustring
        Dim path As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i004\" & nrep & ".pdf")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(Path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i004\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i004\" & nrep & ".pdf"), False)
        End If
    End Sub
    '///-------------
    Shared Sub sei005(ByVal ustring As String)
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\siaaa\docsinventor\SEI005.pdf"), Missing.Value)
        objDoc.Title = "Carta de Adeudo de documentos"
        objDoc.Creator = "Aspirante"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")
        Dim objFont_cgn As IPdfFont = objDoc.Fonts.LoadFromFile("C:\Windows\Fonts\GOTHIC.TTF")

        'DATOS A IMPRIMIR Y PARAMETROS DEL REPORTE (ALINEACIONES)

        Dim tdfirst As DataTable = datosreportei005(ustring)
        Dim tdsec As DataTable = coordenadas("se-i005")
        Dim nv As Integer
        For nv = 0 To tdfirst.Columns.Count - 1

            Dim fontsize As String = tdsec.Rows(nv).Item(1).ToString
            Dim interlinea As String = tdsec.Rows(nv).Item(2).ToString
            Dim alineamiento As String = tdsec.Rows(nv).Item(3).ToString
            Dim ancho As String = tdsec.Rows(nv).Item(4).ToString
            Dim stil As String = 0

            Dim param_item As String = "x=" & tdsec.Rows(nv).Item(5).ToString & "; y=" & CStr(CDbl(tdsec.Rows(nv).Item(9).ToString) - CDbl(stil)) _
                                       & "; width=" & tdsec.Rows(nv).Item(4).ToString & "; alignment=" & tdsec.Rows(nv).Item(3).ToString & "; size=" & fontsize & "; color=&H000000"
            objPage.Canvas.DrawText(tdfirst.Rows(0).Item(nv).ToString, param_item, objFont_cgn)
        Next

        Dim nrep As String = ustring
        Dim path As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i005\" & nrep & ".pdf")
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i005\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i005\" & nrep & ".pdf"), False)
        End If
    End Sub

    Private Shared Function dtsrc(p1 As Integer) As Object
        Throw New System.NotImplementedException
    End Function


    'Shared Function sei005(ByVal carrera As String, ByVal turno As String, ByVal ciclo As String) As String
    '    Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
    '    Dim objPdf As IPdfManager = New PdfManager()
    '    objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
    '    Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\siaaa\docsinventor\SEI004.pdf"), Missing.Value)
    '    objDoc.Title = "Lista de Asistencias"
    '    objDoc.Creator = "Servicios Escolares UTJ"
    '    Dim objPage As IPdfPage = objDoc.Pages(1)
    '    Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
    '    Dim objFontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")

    '    Dim tc As DataTable

    'End Function

    Shared Function sei006(ByVal carrera As String, ByVal turno As String, ByVal ciclo As String, ByVal turnotext As String) As String
        Dim sc As New SqlConnection(HttpContext.Current.Application("str"))
        Dim objPdf As IPdfManager = New PdfManager()
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(HttpContext.Current.Server.MapPath("\siaaa\docsinventor\SEI006.pdf"), Missing.Value)
        objDoc.Title = "Lista de Asistencia a Curso Propedeutico"
        objDoc.Creator = "Servicios Escolares - Primer Ingreso - UTJ"
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("C:\Windows\Fonts\GOTHIC.TTF")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("C:\Windows\Fonts\GOTHIC.TTF")
        Dim coord As DataTable = coordenadas("se-i006")

        'NOMBRE DEL REPORTE DOCUMENTO
        Dim nrep As String = carrera & "-" & turno & "-" & ciclo

        'IMPRESION DE LA LISTA DE ASPIRANTES
        Dim gvtprint As DataTable = listado_propedeutico_xcarreras(carrera, turno, ciclo)
        Dim matrowcount As Integer = 0
        Dim matrindx As Integer = 0
        Dim maxhoja As Integer = 39

        Dim hojas As String = (Math.Floor((gvtprint.Rows.Count / maxhoja))).ToString
        Dim indhoja As String = (hojas + 1).ToString
        Dim nh As Integer

        'Dim objPage As IPdfPage = objDoc.Pages(1)

        For nh = 0 To hojas
            Dim objPage As IPdfPage = objDoc.Pages(nh + 1)
            Dim starty As String = coord.Rows(6).Item(7).ToString
            Dim startLine As String = coord.Rows(10).Item(7).ToString

            For matrindx = matrowcount To IIf((gvtprint.Rows.Count) > (nh + 1) * maxhoja, ((nh + 1) * maxhoja) - 1, gvtprint.Rows.Count - 1)
                Dim ls As String = gvtprint.Rows(matrindx).Item(0).ToString 'NUMERO DE LISTA
                Dim mt As String = gvtprint.Rows(matrindx).Item(1).ToString 'MATRICULA DEL ALUMNO
                Dim nm As String = gvtprint.Rows(matrindx).Item(5).ToString.Replace("&#209;", "Ñ") 'NOMBRE DEL ALUMNO

                Dim nmt As String = "x=" & coord.Rows(6).Item(3).ToString & "; y=" & starty & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(6).Item(1).ToString
                objPage.Canvas.DrawText(ls, nmt, objFont)
                Dim evt As String = "x=" & coord.Rows(7).Item(3).ToString & "; y=" & starty & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(7).Item(1).ToString
                objPage.Canvas.DrawText(mt, evt, objFont)
                Dim ext As String = "x=" & coord.Rows(8).Item(3).ToString & "; y=" & starty & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(8).Item(1).ToString
                objPage.Canvas.DrawText(nm, ext, objFont)

                starty = starty - CInt(coord.Rows(6).Item(2).ToString)

                objPage.Canvas.DrawLine(coord.Rows(10).Item(3).ToString, startLine, coord.Rows(10).Item(4).ToString, startLine)
                startLine = startLine - CInt(coord.Rows(10).Item(8).ToString)
                'objPage.Canvas.RestoreState()
            Next
            matrowcount = matrindx

            'IMPRESION DE LA FECHA
            Dim textfecha As String = "x=" & coord.Rows(11).Item(3).ToString & "; y=" & coord.Rows(11).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(11).Item(1).ToString & "; color=&H000000"
            objPage.Canvas.DrawText("Documento se-i006 impreso el " & Format(Now, "dddd dd, MMMM, yyyy"), textfecha, objFont)

            'IMPRESION DEL CABEZAL
            Dim partecabezal As DataTable = carrera_nivel(carrera, turnotext, ciclo)
            Dim parametrocarrera As String = "x=" & coord.Rows(1).Item(3).ToString & "; y=" & coord.Rows(1).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(1).Item(1).ToString & "; color=&H000000"
            Dim parametronivel As String = "x=" & coord.Rows(1).Item(4).ToString & "; y=" & coord.Rows(1).Item(8).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(1).Item(1).ToString & "; color=&H000000"
            Dim parametroturno As String = "x=" & coord.Rows(1).Item(5).ToString & "; y=" & coord.Rows(1).Item(9).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(1).Item(1).ToString & "; color=&H000000"
            Dim parametrociclo As String = "x=" & coord.Rows(1).Item(6).ToString & "; y=" & coord.Rows(1).Item(10).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(1).Item(1).ToString & "; color=&H000000"
            objPage.Canvas.DrawText(partecabezal.Rows(0).Item(0).ToString, parametrocarrera, objFont)
            objPage.Canvas.DrawText(partecabezal.Rows(0).Item(1).ToString, parametronivel, objFont)
            objPage.Canvas.DrawText(partecabezal.Rows(0).Item(2).ToString, parametroturno, objFont)
            objPage.Canvas.DrawText(partecabezal.Rows(0).Item(3).ToString, parametrociclo, objFont)

            'IMPRESION DEL PIE DE PAGINA
            Dim parametropie As String = "x=" & coord.Rows(2).Item(3).ToString & "; y=" & coord.Rows(2).Item(7).ToString & "; width=" & (612 - 2 - CDbl(coord.Rows(0).Item(3))).ToString & "; alignment=left; size=" & coord.Rows(1).Item(1).ToString & "; color=&H000000"
            objPage.Canvas.DrawText("Hoja " & nh + 1 & " de " & hojas + 1, parametropie, objFont)

            objPage.Canvas.SetColor(coord.Rows(10).Item(5).ToString, coord.Rows(10).Item(6).ToString, coord.Rows(10).Item(9).ToString)

        Next
        Dim delpage As Integer = 0
        For m = (nh + 1) To objDoc.Pages.Count - delpage
            objDoc.Pages.Remove(nh + 1)
            delpage = delpage + 1
        Next

        Dim path As String = HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i006\" & nrep & ".pdf")

        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then
            file.Delete()
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i006\" & nrep & ".pdf"), False)
        Else
            Dim Filename = objDoc.Save(HttpContext.Current.Server.MapPath("\siaaa\docstock\se-i006\" & nrep & ".pdf"), False)
        End If
        sei006 = nrep
    End Function

End Class

