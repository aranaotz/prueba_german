Imports general_ciclos
Imports secure_tools
Imports System.Data
Partial Class contents_general_ciclos_ne
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            mv_general_ciclos.ActiveViewIndex = 0
            gv_ciclos.DataSource = detalleGeneral()
            gv_ciclos.DataBind()
        End If

    End Sub

    Protected Sub lb_nuevo_Click(sender As Object, e As EventArgs)
        mv_general_ciclos.ActiveViewIndex = 1



    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_general_ciclos.ActiveViewIndex = 0
    End Sub
    Protected Sub Guardar_Click(sender As Object, e As EventArgs)

        If validaCiclo(txtciclo.Text) = False Then

            llena_cicloGeneral(securetext(txtciclo.Text.ToUpper), securetext(txtInicio.Text), securetext(txtFin.Text), cbx_activo.Checked)
            insertaDetalleCiclo(securetext(txtciclo.Text.ToUpper), securetext(txtInicio.Text), securetext(txtFin.Text))
            mv_general_ciclos.ActiveViewIndex = 0
            gv_ciclos.DataSource = detalleGeneral()
            gv_ciclos.DataBind()
        End If

    End Sub



    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        hf_ciclo.Value = sender.commandArgument.ToString
        lbl_ciclo.Text = hf_ciclo.Value
        mv_general_ciclos.ActiveViewIndex = 2
        Dim estacion As String = lbl_ciclo.Text
        estacion = Microsoft.VisualBasic.Right(estacion, 1)
        If estacion.ToString = "A" Then
            lbl_inicio_vacaciones.Text = "Primavera"
            lbl_fin_vaciones.Text = "Primavera"
        End If
        If estacion.ToString = "B" Then
            lbl_inicio_vacaciones.Text = "Verano"
            lbl_fin_vaciones.Text = "Verano"
        End If
        If estacion.ToString = "C" Then
            lbl_inicio_vacaciones.Text = "Invierno"
            lbl_fin_vaciones.Text = "Invierno"
        End If

        cacoensulu(detalleCiclo(hf_ciclo.Value))




    End Sub

    Private Sub cacoensulu(ByVal dt As DataTable)
        tbx_inicio.Text = dt.Rows(0).Item(1).ToString
        tbx_inicio_continua.Text = dt.Rows(0).Item(2).ToString
        tbx_fin_continua.Text = dt.Rows(0).Item(3).ToString
        tbx_inicio_estadia.Text = dt.Rows(0).Item(4).ToString
        tbx_fin_estadia.Text = dt.Rows(0).Item(5).ToString
        tbx_fin_curso.Text = dt.Rows(0).Item(6).ToString
        tbx_inicio_remediales.Text = dt.Rows(0).Item(7).ToString
        tbx_fin_remediales.Text = dt.Rows(0).Item(8).ToString
        tbx_inicio_reg_remediales.Text = dt.Rows(0).Item(9).ToString
        tbx_fin_reg_remediales.Text = dt.Rows(0).Item(10).ToString
        tbx_fin.Text = dt.Rows(0).Item(11).ToString
        tbx_no_laborables.Text = dt.Rows(0).Item(12).ToString
        tbx_otro.Text = dt.Rows(0).Item(13).ToString
        tbx_inicio_vacaciones.Text = dt.Rows(0).Item(14).ToString
        tbx_fin_vacaciones.Text = dt.Rows(0).Item(15).ToString

    End Sub


    Protected Sub un_atras_Click(sender As Object, e As ImageClickEventArgs)
        mv_general_ciclos.ActiveViewIndex = 0
    End Sub



    Protected Sub lb_actualiza_Click(sender As Object, e As EventArgs)

        Dim inicio_ciclo As DateTime = securetext(Convert.ToDateTime(tbx_inicio.Text))
        Dim inicio_continua As DateTime = securetext(Convert.ToDateTime(tbx_inicio_continua.Text))
        Dim fin_continua As DateTime = securetext(Convert.ToDateTime(tbx_fin_continua.Text))
        Dim inicio_estadia As DateTime = securetext(Convert.ToDateTime(tbx_inicio_estadia.Text))
        Dim fin_estadia As DateTime = securetext(Convert.ToDateTime(tbx_fin_estadia.Text))
        Dim fin_curso As DateTime = securetext(Convert.ToDateTime(tbx_fin_curso.Text))
        Dim inicio_remediales As DateTime = securetext(Convert.ToDateTime(tbx_inicio_remediales.Text))
        Dim fin_remediales As DateTime = securetext(Convert.ToDateTime(tbx_fin_remediales.Text))
        Dim inicio_reg_remediales As DateTime = securetext(Convert.ToDateTime(tbx_inicio_reg_remediales.Text))
        Dim fin_reg_remediales As DateTime = securetext(Convert.ToDateTime(tbx_fin_reg_remediales.Text))
        Dim fin_ciclo As DateTime = securetext(Convert.ToDateTime(tbx_fin.Text))
        Dim nl As DateTime = securetext(Convert.ToDateTime(tbx_no_laborables.Text))


        Dim inicio_vacaciones As DateTime = securetext(Convert.ToDateTime(tbx_inicio_vacaciones.Text))
        Dim fin_vacaciones As DateTime = securetext(Convert.ToDateTime(tbx_fin_vacaciones.Text))



        actualizaGeneralCiclos(Format(inicio_ciclo, "yyyy/MM/dd"), Format(inicio_continua, "yyyy/MM/dd"), Format(fin_continua, "yyyy/MM/dd"), Format(inicio_estadia, "yyyy/MM/dd"),
                               Format(fin_estadia, "yyyy/MM/dd"), Format(fin_curso, "yyyy/MM/dd"), Format(inicio_remediales, "yyyy/MM/dd"), Format(fin_remediales, "yyyy/MM/dd"),
                               Format(inicio_reg_remediales, "yyyy/MM/dd"), Format(fin_reg_remediales, "yyyy/MM/dd"), Format(fin_ciclo, "yyyy/MM/dd"), Format(nl, "yyyy/MM/dd"),
                               securetext(tbx_otro.Text), Format(inicio_vacaciones, "yyyy/MM/dd"),
                               Format(fin_vacaciones, "yyyy/MM/dd"), hf_ciclo.Value)


        mv_general_ciclos.ActiveViewIndex = 3








    End Sub

    Protected Sub lb_regresar__Click(sender As Object, e As EventArgs)
        mv_general_ciclos.ActiveViewIndex = 0

    End Sub
    Protected Sub ib_regresar__Click(sender As Object, e As ImageClickEventArgs)
        mv_general_ciclos.ActiveViewIndex = 2

    End Sub
    Protected Sub lb_atras_Click(sender As Object, e As EventArgs)
        mv_general_ciclos.ActiveViewIndex = 0
    End Sub
End Class
