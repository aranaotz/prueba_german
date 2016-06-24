Imports System.Data
Imports usuario_alumno
Partial Class contents_studentdt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            mv_studentdt.ActiveViewIndex = 1
        End If

    End Sub
    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
        Try
            cacoensulu(llena_detalle(sender.commandArgument.ToString))
            mv_studentdt.ActiveViewIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
        gv_resultados.DataSource = resultados_busqueda(tbx_busqueda.Text)
        gv_resultados.DataBind()

    End Sub


    Private Sub cacoensulu(ByVal dt As DataTable)
        tbx_matricula.Text = dt.Rows(0).Item(1).ToString
        tbx_nombres.Text = dt.Rows(0).Item(2).ToString
        tbx_primero.Text = dt.Rows(0).Item(3).ToString
        tbx_segundo.Text = dt.Rows(0).Item(4).ToString



        tbx_carrera.Text = dt.Rows(0).Item(5).ToString
        tbx_nivel.Text = dt.Rows(0).Item(6).ToString
        tbx_plan.Text = dt.Rows(0).Item(7).ToString
        tbx_turno.Text = dt.Rows(0).Item(8).ToString
        tbx_grado.Text = dt.Rows(0).Item(9).ToString
        tbx_grupo.Text = dt.Rows(0).Item(10).ToString
        tbx_status.Text = dt.Rows(0).Item(11).ToString
        tbx_curp.Text = dt.Rows(0).Item(12).ToString
        tbx_rfc.Text = dt.Rows(0).Item(13).ToString
        tbx_nss.Text = dt.Rows(0).Item(14).ToString
        tbx_email.Text = dt.Rows(0).Item(15).ToString
        tbx_fijo.Text = dt.Rows(0).Item(16).ToString
        tbx_movil.Text = dt.Rows(0).Item(17).ToString
        tbx_domicilio.Text = dt.Rows(0).Item(18).ToString
        tbx_ext.Text = dt.Rows(0).Item(19).ToString
        tbx_int.Text = dt.Rows(0).Item(20).ToString
        tbx_cp.Text = dt.Rows(0).Item(21).ToString
    End Sub


    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_studentdt.ActiveViewIndex = 1
    End Sub
    Protected Sub lb_generar_Click(sender As Object, e As EventArgs)
        Dim cad1 As String = tbx_nombres.Text
        Dim substring1 As String = Microsoft.VisualBasic.Left(cad1, 2)
        Dim cad2 As String = tbx_primero.Text
        Dim substring2 As String = Microsoft.VisualBasic.Left(cad2, 2)
        Dim numero As New Random

        MsgBox(substring1 + substring2 + System.Convert.ToString(numero.Next(1000, 9999)))
    End Sub
End Class
