Imports System.Web.HttpContext
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports ASPPDFLib
Imports System.IO
Imports Microsoft.VisualBasic

Public Class printas
    Public Shared Sub merge_docs(ByVal dta As DataTable, ByVal ciclo As String, ByVal mes As String)
        Dim basedoc As IPdfManager = New PdfManager
        Dim midoc As IPdfDocument = basedoc.OpenDocument(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & dta.Rows(0).Item(0).ToString & ".pdf"), Missing.Value)
        Dim dn As Integer
        For dn = 1 To dta.Rows.Count - 1
            Dim midoc_par As IPdfDocument = basedoc.OpenDocument(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & dta.Rows(dn).Item(0).ToString & ".pdf"), Missing.Value)
            'midoc.Pages.Add(midoc_par)
            midoc.AppendDocument(midoc_par)
        Next
        'ASEGURAMOS EL PATH Y GUARDAMOS EL DOCUMENTO
        Dim pathdir As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\")
        If Directory.Exists(pathdir) Then
            Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & "todas.pdf")
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If (file.Exists) Then
                file.Delete()
                Dim Filename = midoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & "todas.pdf"), False)
            Else
                Dim Filename = midoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & "todas.pdf"), False)
            End If
        Else
            Directory.CreateDirectory(pathdir)
            Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & "todas.pdf")
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If (file.Exists) Then
                file.Delete()
                Dim Filename = midoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & "todas.pdf"), False)
            Else
                Dim Filename = midoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & mes & "\" & "todas.pdf"), False)
            End If
        End If
    End Sub

    Public Shared Sub returns(cnx As String, ciclo As String, icu As String, mes As String, ByVal formato As String)
        Dim v As New SqlConnection(cnx)
        Dim objPdf As IPdfManager = New PdfManager
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        'Dim objDoc As IPdfDocument = objPdf.OpenDocument(Current.Server.MapPath("\cgiapp\formatos\lacgiciclos.pdf"), Missing.Value)
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(Current.Server.MapPath("\cgiapp\formatos\lacgiciclos_ta.pdf"), Missing.Value)
        objDoc.Title = "Formato de Reporte de Asistencias del ciclo " & ciclo
        objDoc.Creator = "Direccion Académica CGI"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE, LO GUARDAMOS EN OET (DATATABLE)
        Dim oe As New SqlDataAdapter("SELECT future_inf_icu.icu, future_inf_icu.materia, future_inf_icu.sep_eq, general_grados.grado, future_inf_icu.grupo, future_inf_icu.ciclo, future_inf_icu.nombre2, '" + mes + "' AS mes " + _
                                     "FROM future_inf_icu INNER JOIN general_grados ON LEFT(future_inf_icu.grupo, 1) = general_grados.idgrado WHERE (future_inf_icu.ciclo = '" + ciclo + "') AND (icu='" + icu + "')", v)
        Dim oet As New DataTable
        v.Open()
        oe.Fill(oet)
        v.Close()

        'DEFINIMOS LOS LUGARES DE IMPRESION DE LA HOJA DEPENDIENTO DEL FORMATO SELECCIONADO
        Dim smateria As String
        Dim sclavesej As String
        Dim sgrado As String
        Dim sgrupo As String
        Dim speriodo As String
        Dim sdocente As String
        Dim sdocente_adj As String
        Dim smes As String

        Select Case formato
            Case 0
                smateria = "x=31; y=415; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sclavesej = "x=31; y=761; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrado = "x=61; y=237; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrupo = "x=61; y=537; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                speriodo = "x=61; y=761; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sdocente = "x=91; y=410; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                smes = "x=117; y=410; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
            Case Else
                smateria = "x=11; y=420; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sclavesej = "x=11; y=750; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrado = "x=41; y=250; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrupo = "x=41; y=537; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                speriodo = "x=41; y=750; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sdocente = "x=71; y=420; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sdocente_adj = "x=71; y=557; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                smes = "x=97; y=420; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
        End Select



        'IMPRIMIMOS EL ENCABEZADO
        objPage.Canvas.DrawText(oet.Rows(0).Item(1).ToString, smateria, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(2).ToString, sclavesej, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(3).ToString, sgrado, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(4).ToString, sgrupo, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(5).ToString, speriodo, objFont)
        'objPage.Canvas.DrawText(oet.Rows(0).Item(6).ToString, sdocente, objFont)
        'objPage.Canvas.DrawText(oet.Rows(0).Item(6).ToString, sdocente_adj, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(7).ToString, smes, objFont)

        'OBTENEMOS LOS ALUMNOS Y GUARDAMOS EN OAT (DATATABLE)
        Dim oa As New SqlDataAdapter("SELECT fname FROM alumnos WHERE (grupo='" + oet.Rows(0).Item(4).ToString + "') AND (ciclo='" + ciclo + "') AND (status='AC') ORDER BY osep", v)
        Dim oat As New DataTable
        v.Open()
        oa.Fill(oat)
        v.Close()

        'HACEMOS EL CICLO DE IMPRESION DE LOS ALUMNOS
        Dim xincrement As Double

        Select Case formato
            Case 0
                xincrement = 161
            Case Else
                xincrement = 141
        End Select
        Dim al As Integer
        For al = 0 To oat.Rows.Count - 1
            objPage.Canvas.DrawText(oat.Rows(al).Item(0).ToString, "x=" & xincrement & "; y=130; width=300; alignment=left; size=8; Angle=90; Color=&H000000", objFont)
            xincrement = xincrement + 10.8
        Next


        'ASEGURAMOS EL PATH Y GUARDAMOS EL DOCUMENTO
        Dim pathdir As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\")
        If Directory.Exists(pathdir) Then
            Dim mesdir As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\")
            If Directory.Exists(mesdir) Then
                Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf")
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                If (file.Exists) Then
                    file.Delete()
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                Else
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                End If
            Else
                Directory.CreateDirectory(mesdir)
                Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf")
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                If (file.Exists) Then
                    file.Delete()
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                Else
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                End If
            End If
        Else
            Directory.CreateDirectory(pathdir)
            Dim mesdir As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\")
            If Directory.Exists(mesdir) Then
                Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf")
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                If (file.Exists) Then
                    file.Delete()
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                Else
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                End If
            Else
                Directory.CreateDirectory(mesdir)
                Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf")
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                If (file.Exists) Then
                    file.Delete()
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                Else
                    Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(7).ToString() & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
                End If
            End If
        End If
    End Sub

    Private Function gdoc(anterior As String, ciclo As String) As String
        Dim objPdf As IPdfManager = New PdfManager
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(Current.Server.MapPath("\cgiapp\formatos\" & anterior), Missing.Value)
        Dim objPage As IPdfPage = objDoc.Pages(1)
        objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\gnew.pdf"), False)
    End Function

    Public Shared Function doc(cnx As String, ciclo As String, icu As String, mes As String, ByVal formato As String) As String
        Dim v As New SqlConnection(cnx)
        Dim objPdf As IPdfManager = New PdfManager
        objPdf.RegKey = "IWeztcEDU3jtepIV1q3mqjVv1Jwk7dar6SkOH5nT5pFhXYK+/tWyaZh8WIY9Oq2sebodYEBbKfnj"
        Dim objDoc As IPdfDocument = objPdf.OpenDocument(Current.Server.MapPath("\cgiapp\formatos\lacgiciclos.pdf"), Missing.Value)
        objDoc.Title = "Formato de Reporte de Asistencias del ciclo " & ciclo
        objDoc.Creator = "Direccion Académica CGI"
        Dim objPage As IPdfPage = objDoc.Pages(1)
        Dim objFont As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibri.ttf")
        Dim objfontitalic As IPdfFont = objDoc.Fonts.LoadFromFile("c:\windows\fonts\calibrii.ttf")

        'OBTENEMOS EL TEXTO DEL ENCABEZADO DEL REPORTE, LO GUARDAMOS EN OET (DATATABLE)
        Dim oe As New SqlDataAdapter("SELECT future_inf_icu.icu, future_inf_icu.materia, future_inf_icu.sep_eq, general_grados.grado, future_inf_icu.grupo, future_inf_icu.ciclo, future_inf_icu.nombre2, '" + mes + "' AS mes " + _
                                     "FROM future_inf_icu INNER JOIN general_grados ON LEFT(future_inf_icu.grupo, 1) = general_grados.idgrado WHERE (future_inf_icu.ciclo = '" + ciclo + "') AND (icu='" + icu + "')", v)
        Dim oet As New DataTable
        v.Open()
        oe.Fill(oet)
        v.Close()

        'DEFINIMOS LOS LUGARES DE IMPRESION DE LA HOJA DEPENDIENTO DEL FORMATO SELECCIONADO
        Dim smateria As String
        Dim sclavesej As String
        Dim sgrado As String
        Dim sgrupo As String
        Dim speriodo As String
        Dim sdocente As String
        Dim smes As String

        Select Case formato
            Case 0
                smateria = "x=31; y=415; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sclavesej = "x=31; y=761; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrado = "x=61; y=237; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrupo = "x=61; y=537; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                speriodo = "x=61; y=761; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sdocente = "x=91; y=410; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                smes = "x=117; y=410; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
            Case Else
                smateria = "x=11; y=420; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sclavesej = "x=11; y=750; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrado = "x=41; y=250; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sgrupo = "x=41; y=537; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                speriodo = "x=41; y=750; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                sdocente = "x=71; y=420; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
                smes = "x=97; y=420; width=300; alignment=center; size=9; Angle=90; Color=&H000000"
        End Select



        'IMPRIMIMOS EL ENCABEZADO
        objPage.Canvas.DrawText(oet.Rows(0).Item(1).ToString, smateria, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(2).ToString, sclavesej, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(3).ToString, sgrado, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(4).ToString, sgrupo, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(5).ToString, speriodo, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(6).ToString, sdocente, objFont)
        objPage.Canvas.DrawText(oet.Rows(0).Item(7).ToString, smes, objFont)

        'OBTENEMOS LOS ALUMNOS Y GUARDAMOS EN OAT (DATATABLE)
        Dim oa As New SqlDataAdapter("SELECT fname FROM alumnos WHERE (grupo='" + oet.Rows(0).Item(4).ToString + "') AND (ciclo='" + ciclo + "') AND (status='AC') ORDER BY osep", v)
        Dim oat As New DataTable
        v.Open()
        oa.Fill(oat)
        v.Close()

        'HACEMOS EL CICLO DE IMPRESION DE LOS ALUMNOS
        Dim xincrement As Double

        Select Case formato
            Case 0
                xincrement = 161
            Case Else
                xincrement = 141
        End Select
        Dim al As Integer
        For al = 0 To oat.Rows.Count - 1
            objPage.Canvas.DrawText(oat.Rows(al).Item(0).ToString, "x=" & xincrement & "; y=130; width=300; alignment=left; size=8; Angle=90; Color=&H000000", objFont)
            xincrement = xincrement + 10.8
        Next


        'ASEGURAMOS EL PATH Y GUARDAMOS EL DOCUMENTO
        Dim pathdir As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\")
        If Directory.Exists(pathdir) Then
            Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(0).ToString & ".pdf")
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If (file.Exists) Then
                file.Delete()
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
            Else
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
            End If
        Else
            Directory.CreateDirectory(pathdir)
            Dim path As String = Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(0).ToString & ".pdf")
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If (file.Exists) Then
                file.Delete()
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
            Else
                Dim Filename = objDoc.Save(Current.Server.MapPath("\cgiapp\formatos\asistencias\" & ciclo & "\" & oet.Rows(0).Item(0).ToString & ".pdf"), False)
            End If
        End If
        doc = oet.Rows(0).Item(0).ToString & ".pdf"
    End Function
End Class
