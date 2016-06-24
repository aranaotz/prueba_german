Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web

Public Class dtciclos

    Public Shared Function pi_cicloregistro() As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim pc As New SqlCommand("SELECT ciclo FROM basic_pi_ciclos WHERE (active=1)", c)
        c.Open()
        pi_cicloregistro = pc.ExecuteScalar
        c.Close()
    End Function

    Public Shared Function pi_todosciclos() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim pit As New SqlDataAdapter("SELECT idciclo,ciclo FROM basic_pi_ciclos ORDER BY ciclo", c)
        Dim pitt As New DataTable
        c.Open()
        pit.Fill(pitt)
        c.Close()
        Return pitt
    End Function





    'IMPORTACIONES DE SADIN-----------------------------
    Public Shared Function actualcycle(ByVal cnx As String) As String
        Dim c As New SqlConnection(cnx)
        Dim ac As New SqlCommand("SELECT ciclo FROM basic_pi_ciclos WHERE (active=1)", c)
        c.Open()
        actualcycle = ac.ExecuteScalar
        c.Close()
    End Function


End Class
