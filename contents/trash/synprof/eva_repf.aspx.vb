Imports System.Data
Imports System.Data.SqlClient

Partial Class eva_repf
    Inherits System.Web.UI.Page

    Private Function gc() As String
        Dim sqlconn As New SqlConnection(Application("str"))
        Dim aingcomm As New SqlCommand("SELECT c_user FROM users WHERE id_usr='" + Session("usrcgi200Xstr") + "'", sqlconn)
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

    Private Sub fill_rep(ByVal type As Boolean, ByVal prof As String, ByVal caso As String)
        Select Case caso
            Case "1"
                Select Case type
                    Case True
                        Dim sc As New SqlConnection(Application("str"))
                        Dim frc As New SqlCommand("SELECT dbo.materias.materia, dbo.sched_dias.dias, dbo.eval_asreportes_future.estado, dbo.eval_asreportes_future.fecha, dbo.eval_asreportes_future.ciclo,dbo.eval_asreportes_future.grupo " + _
                                                  "FROM dbo.eval_asreportes_future INNER JOIN dbo.materias ON dbo.eval_asreportes_future.mat = dbo.materias.clavem INNER JOIN " + _
                                                  "dbo.sched_dias ON dbo.eval_asreportes_future.dayclass = dbo.sched_dias.id_day WHERE (dbo.eval_asreportes_future.prof = '" + prof + "') AND " + _
                                                  "(dbo.eval_asreportes_future.estado <> 2) AND (dbo.eval_asreportes_future.ciclo = '" + getactualcycle() + "') ORDER BY  dbo.materias.materia,dbo.eval_asreportes_future.fecha", sc)
                        Dim fra As New SqlDataAdapter(frc)
                        Dim frt As New DataTable
                        sc.Open()
                        fra.Fill(frt)
                        sc.Close()
                        gv_reporte.DataSource = frt
                        gv_reporte.DataBind()
                    Case False
                        Dim sc As New SqlConnection(Application("str"))
                        Dim frc As New SqlCommand("SELECT dbo.materias.materia, dbo.sched_dias.dias, dbo.eval_asreportes_future.estado, dbo.eval_asreportes_future.fecha, dbo.eval_asreportes_future.ciclo,dbo.eval_asreportes_future.grupo " + _
                                                  "FROM dbo.eval_asreportes_future INNER JOIN dbo.materias ON dbo.eval_asreportes_future.mat = dbo.materias.clavem INNER JOIN " + _
                                                  "dbo.sched_dias ON dbo.eval_asreportes_future.dayclass = dbo.sched_dias.id_day WHERE (dbo.eval_asreportes_future.prof = '" + prof + "') AND (dbo.eval_asreportes_future.ciclo = '" + getactualcycle() + "')" + _
                                                  " ORDER BY  dbo.materias.materia,dbo.eval_asreportes_future.fecha", sc)
                        Dim fra As New SqlDataAdapter(frc)
                        Dim frt As New DataTable
                        sc.Open()
                        fra.Fill(frt)
                        sc.Close()
                        gv_reporte.DataSource = frt
                        gv_reporte.DataBind()
                End Select
            Case Else
                Select Case type
                    Case True
                        Dim sc As New SqlConnection(Application("str"))
                        Dim frc As New SqlCommand("SELECT TOP (100) PERCENT dbo.materias.materia, dbo.sched_dias.dias, dbo.eval_reportes_future.estado, " + _
                                                  "dbo.eval_reportes_future.fecha, dbo.eval_reportes_future.ciclo,dbo.eval_reportes_future.grupo FROM dbo.eval_reportes_future INNER JOIN dbo.materias ON dbo.eval_reportes_future.mat = " + _
                                                  "dbo.materias.clavem INNER JOIN dbo.sched_dias ON dbo.eval_reportes_future.dayclass = dbo.sched_dias.id_day WHERE " + _
                                                  "(dbo.eval_reportes_future.estado <> 2) AND (dbo.eval_reportes_future.prof =  '" + prof + "') AND (dbo.eval_reportes_future.ciclo = '" + getactualcycle() + "') ORDER BY dbo.materias.materia, " + _
                                                  "dbo.eval_reportes_future.fecha", sc)
                        Dim fra As New SqlDataAdapter(frc)
                        Dim frt As New DataTable
                        sc.Open()
                        fra.Fill(frt)
                        sc.Close()
                        gv_reporte.DataSource = frt
                        gv_reporte.DataBind()
                    Case False
                        Dim sc As New SqlConnection(Application("str"))
                        Dim frc As New SqlCommand("SELECT TOP (100) PERCENT dbo.materias.materia, dbo.sched_dias.dias, dbo.eval_reportes_future.estado, " + _
                                                   "dbo.eval_reportes_future.fecha, dbo.eval_reportes_future.ciclo,dbo.eval_reportes_future.grupo FROM dbo.eval_reportes_future INNER JOIN dbo.materias ON dbo.eval_reportes_future.mat = " + _
                                                   "dbo.materias.clavem INNER JOIN dbo.sched_dias ON dbo.eval_reportes_future.dayclass = dbo.sched_dias.id_day WHERE " + _
                                                   "(dbo.eval_reportes_future.prof =  '" + prof + "') AND (dbo.eval_reportes_future.ciclo = '" + getactualcycle() + "') ORDER BY dbo.materias.materia, " + _
                                                   "dbo.eval_reportes_future.fecha", sc)
                        Dim fra As New SqlDataAdapter(frc)
                        Dim frt As New DataTable
                        sc.Open()
                        fra.Fill(frt)
                        sc.Close()
                        gv_reporte.DataSource = frt
                        gv_reporte.DataBind()
                End Select
        End Select
    End Sub

    Protected Sub cmd_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_mostrar.Click
        fill_rep(cbx_hide.Checked, gc, rbl_options.SelectedValue.ToString)
    End Sub
End Class
