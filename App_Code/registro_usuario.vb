Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data


Public Class registro_usuario

    Shared Function tablapaises(ByVal c As SqlConnection) As DataTable
        Dim tp As New SqlDataAdapter("SELECT id_pais, pais FROM cow order by pais", c)
        Dim tpt As New DataTable
        c.Open()
        tp.Fill(tpt)
        c.Close()
        tablapaises = tpt
    End Function

End Class
