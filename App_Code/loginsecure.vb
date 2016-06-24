Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Web
Imports System

Public Class loginsecure

    Shared TripleDes As New TripleDESCryptoServiceProvider

    Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Shared Function EncryptData(
    ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Shared Function DecryptData(
    ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

    Shared Sub storescure(ByVal matricula As String, ByVal securechain As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ss As New SqlCommand("UPDATE secure_logins SET securech='" + securechain + "' WHERE codigo='" + cleanchain(matricula) + "'", c)
        c.Open()
        ss.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub storelastdate(ByVal id As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim sld As New SqlCommand("UPDATE secure_logins SET ultimoacceso=getdate() WHERE id='" + id + "'", c)
        c.Open()
        sld.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function xist(ByVal matricula As String, ByVal pwd As String, ByVal securechain As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim xs As New SqlCommand("SELECT CASE WHEN count(*)>0 THEN 1 ELSE 0 END xsist FROM secure_logins WHERE codigo='" + cleanchain(matricula) + "' " + _
                                    "and pwd='" + cleanchain(pwd) + "' AND securech='" + securechain + "'", c)
        c.Open()
        xist = xs.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function nombre(ByVal cod As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim nc As New SqlCommand("SELECT nombresp FROM users WHERE c_user='" + cod + "'", c)
        c.Open()
        nombre = nc.ExecuteScalar
        c.Close()
    End Function

    Shared Function cleanchain(ByVal cadena As String) As String
        cleanchain = cadena.ToString.Replace(" ", "").Replace("%", "").Replace("'", "").Replace("[", "").Replace(".", "")
    End Function

    Shared Function gid(ByVal matricula As String, ByVal pwd As String, ByVal securechain As String) As String
        'gid es el id del registro encontrado
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dg As New SqlCommand("SELECT id FROM secure_logins WHERE codigo='" + cleanchain(matricula) + "' " + _
                                    "and pwd='" + cleanchain(pwd) + "' AND securech='" + securechain + "'", c)
        c.Open()
        gid = dg.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function datos_capauno(ByVal id As String) As DataTable
        'datos_capauno contiene el nombre de la tabla de busqueda de nombres y la ruta destino de la pagina de inicio de sesion
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dcu As New SqlDataAdapter("SELECT tabla,usertype FROM secure_logins WHERE id='" + id + "'", c)
        Dim dcut As New DataTable
        c.Open()
        dcu.Fill(dcut)
        c.Close()
        storelastdate(id)
        Return dcut
    End Function

    Shared Function datos_capados(ByVal capa1 As DataTable) As String()
        'capados tiene los campos de nombre, apellidos y nombre completo
        Dim dcs(7) As String
        dcs(0) = capa1.Rows(0).Item(0).ToString 'NOMBRE DE TABLA
        dcs(1) = capa1.Rows(0).Item(1).ToString 'TIPO DE USUARIO
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dcd As New SqlDataAdapter("SELECT camporeferencia,fullnamecampo,nombrecampo,apellidopcampo,apellidomcampo FROM secure_tables " + _
                                      "WHERE ntable='" + dcs(0) + "'", c)
        Dim dcdt As New DataTable
        c.Open()
        dcd.Fill(dcdt)
        c.Close()
        Select Case dcdt.Rows.Count
            Case Is > 0
                dcs(2) = dcdt.Rows(0).Item(0).ToString 'CAMPOREFERENCIA
                dcs(3) = dcdt.Rows(0).Item(1).ToString 'FULLNAMECAMPO
                dcs(4) = dcdt.Rows(0).Item(2).ToString 'NOMBRECAMPO
                dcs(5) = dcdt.Rows(0).Item(3).ToString 'APELLIDOPCAMPO
                dcs(6) = dcdt.Rows(0).Item(4).ToString 'APELLIDOMCAMPO
            Case Else
                dcs(2) = "No_data"
                dcs(3) = "No_data"
                dcs(4) = "No_data"
                dcs(5) = "No_data"
                dcs(6) = "No_data"
        End Select
        Return dcs
    End Function

    Shared Function getlvu(ByVal chain As String) As String
        Return chain.Substring(5, 4)
    End Function

    Shared Function datoscapa3(ByVal capa2 As String(), ByVal matricula As String) As String()
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dct As New SqlDataAdapter("SELECT " + capa2(3) + "," + capa2(4) + "," + capa2(5) + "," + capa2(6) + " FROM " + capa2(0) + " " + _
                                      "WHERE " + capa2(2) + "='" + matricula + "'", c)
        Dim dctt As New DataTable
        c.Open()
        dct.Fill(dctt)
        c.Close()
        Select Case dctt.Rows.Count
            Case Is > 0
                capa2(3) = dctt.Rows(0).Item(0).ToString
                capa2(4) = dctt.Rows(0).Item(1).ToString
                capa2(5) = dctt.Rows(0).Item(2).ToString
                capa2(6) = dctt.Rows(0).Item(3).ToString
            Case Else
                capa2(3) = "Sin datos"
                capa2(4) = "Sin datos"
                capa2(5) = "Sin datos"
                capa2(6) = "Sin datos"
        End Select
        Return capa2
    End Function

End Class
