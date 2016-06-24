Imports System.Data
Imports System.Data.SqlClient

Partial Class htool
    Inherits System.Web.UI.Page

    Private Function gc(ByVal idu As String) As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim aingcomm As New SqlCommand("SELECT c_user FROM users WHERE id_usr='" + idu + "'", sqlconn)
        sqlconn.Open()
        gc = aingcomm.ExecuteScalar()
        sqlconn.Close()
    End Function

    Private Function getactualcycle() As String
        Dim v As New SqlConnection(Application("str"))
        Dim cycle As New SqlCommand("SELECT ciclo FROM general_ciclos WHERE active=1", v)
        v.Open()
        getactualcycle = cycle.ExecuteScalar
        v.Close()
    End Function

    Private Sub carga_horario_maestro(ByVal maestro As String, ByVal ciclo As String)
        Dim sqlc As New SqlConnection(Application("str"))
        Dim chh As New SqlCommand("SELECT full_alias FROM sched_horas WHERE active=1 ORDER BY id_hora", sqlc)
        Dim chhda As New SqlDataAdapter(chh)
        Dim chhdt As New DataTable
        sqlc.Open()
        chhda.Fill(chhdt)
        sqlc.Close()
        gv_schedgrupo.DataSource = chhdt
        gv_schedgrupo.DataBind()
        Dim gvro As Integer
        For gvro = 0 To gv_schedgrupo.Rows.Count - 1
            Dim gvco As Integer
            For gvco = 1 To gv_schedgrupo.Columns.Count - 1
                Dim cell As TableCell = CType(gv_schedgrupo.Rows(gvro).Cells(gvco), TableCell)
                Dim chor As New SqlCommand("SELECT materia,grupo,alias FROM sched_cons WHERE id_day='" + gvco.ToString + "' AND " + _
                                           "c_user='" + maestro + "' AND id_hora='" + (gvro + 1).ToString + "' AND occup=1 AND ciclo='" + ciclo + "'", sqlc)
                Dim chorda As New SqlDataAdapter(chor)
                Dim chordt As New DataTable
                sqlc.Open()
                chorda.Fill(chordt)
                sqlc.Close()
                Select Case chordt.Rows.Count
                    Case 0
                        cell.BackColor = Drawing.Color.Gray
                    Case 1
                        Dim _lbl_materia As Label = CType(gv_schedgrupo.Rows(gvro).Cells(gvco).FindControl("lbl_" & gvco.ToString & "1"), Label)
                        Dim _lbl_maestro As Label = CType(gv_schedgrupo.Rows(gvro).Cells(gvco).FindControl("lbl_" & gvco.ToString & "2"), Label)
                        Dim _lbl_aula As Label = CType(gv_schedgrupo.Rows(gvro).Cells(gvco).FindControl("lbl_" & gvco.ToString & "3"), Label)
                        _lbl_materia.Text = chordt.Rows(0).Item(0).ToString
                        _lbl_maestro.Text = chordt.Rows(0).Item(1).ToString
                        _lbl_aula.Text = chordt.Rows(0).Item(2).ToString
                        cell.BackColor = Drawing.Color.White
                    Case Else
                        cell.BackColor = Drawing.Color.Red
                End Select
            Next
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        carga_horario_maestro(gc(Session("usrcgi200Xstr")), getactualcycle)
    End Sub
End Class
