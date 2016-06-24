Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class ordenesdp
    Shared Function tabla_mes(ByVal c As String, ByVal ciclo As String) As DataTable
        Dim con As New SqlConnection(c)
        Dim mesq As New SqlDataAdapter("select distinct id_mes, mes from future_eval_dates where ciclo='" + ciclo + "' order by id_mes", c)
        Dim mesqt As New DataTable
        con.Open()
        mesq.Fill(mesqt)
        con.Close()
        tabla_mes = mesqt
    End Function

    Shared Function insertar_orden(ByVal alumno As String, ByVal tipo As String, ByVal mesinicia As String, ByVal total As Double, ByVal totalstart As Double, ByVal gen As String, ByVal concepto As String, ByVal vencimiento As Date, ByVal c As SqlConnection, ByVal usuario As String, ByVal ciclo As String) As Boolean
        Select Case tipo
            Case 0
                Dim io As New SqlCommand("INSERT INTO adm_cobros (alumno, id_c, qty, mes, esunico, totalstart, gen, fgen, ctabase, cad, pagado, debe, usuario, aceptado, ciclo) VALUES " + _
                                         "('" + alumno + "','" + concepto + "','" + total + "','" + mesinicia + "','" + tipo + "','" + totalstart + "','" + gen + "', getdate(), '2002', '" + Format(vencimiento, "yyyy-MM-dd hh:mm") + "', '0', '" + totalstart + "', '" + usuario + "', '0', '" + ciclo + "')", c)
                c.Open()
                io.ExecuteNonQuery()
                c.Close()
            Case Else

        End Select



    End Function

    Shared Function siguiente_generacion(ByVal c As SqlConnection, ByVal usuario As String) As String
        Dim sg As New SqlCommand("insert into generaciones (fecha, usuario) OUTPUT inserted.generacion VALUES (getdate(), '" + usuario + "')", c)
        c.Open()
        siguiente_generacion = sg.ExecuteScalar()
        c.Close()
    End Function
End Class
