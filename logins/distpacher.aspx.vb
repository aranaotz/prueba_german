Imports nuevousuario
Imports secure_tools
Imports menumount
Imports synpin_code
Imports System.Data
Imports System.Data.SqlClient
Partial Class dispatcher
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Bienvenido - SIAAA UTJ " + versiones()
        If Not IsPostBack Then
            mv_distpacher.ActiveViewIndex = 0
            carga_deinicio()
        End If
    End Sub
    Private Sub cacoensulu(ByVal dt As DataTable)
        txtNombre.Text = dt.Rows(0).Item(0).ToString
        txtApellidop.Text = dt.Rows(0).Item(1).ToString
        txtApellidom.Text = dt.Rows(0).Item(2).ToString
        txtCPersonal.Text = dt.Rows(0).Item(3).ToString
        txtCargo.Text = dt.Rows(0).Item(4).ToString
        txtClave.Text = dt.Rows(0).Item(5).ToString
        txtCInsti.Text = dt.Rows(0).Item(6).ToString
        txtExtension.Text = dt.Rows(0).Item(7).ToString
        hf_cargo.value = dt.Rows(0).Item(9).ToString
        lb_guardar.CommandArgument = dt.Rows(0).Item(8).ToString
        lbl_user.Text = dt.Rows(0).Item(8).ToString
    End Sub
    Private Sub cacoensuluAlumno(ByVal dt As DataTable)
        tbx_matricula.Text = dt.Rows(0).Item(0).ToString
        tbx_nombres.Text = dt.Rows(0).Item(1).ToString
        tbx_primero.Text = dt.Rows(0).Item(2).ToString
        tbx_segundo.Text = dt.Rows(0).Item(3).ToString
        tbx_carrera.Text = dt.Rows(0).Item(4).ToString
        tbx_nivel.Text = dt.Rows(0).Item(5).ToString
        tbx_turno.Text = dt.Rows(0).Item(6).ToString
        tbx_grado.Text = dt.Rows(0).Item(7).ToString
        tbx_grupo.Text = dt.Rows(0).Item(8).ToString
        tbx_status.Text = dt.Rows(0).Item(9).ToString
        tbx_curp.Text = dt.Rows(0).Item(10).ToString
        tbx_rfc.Text = dt.Rows(0).Item(11).ToString
        tbx_nss.Text = dt.Rows(0).Item(12).ToString
        tbx_email.Text = dt.Rows(0).Item(13).ToString
        tbx_fijo.Text = dt.Rows(0).Item(14).ToString
        tbx_movil.Text = dt.Rows(0).Item(15).ToString
        tbx_domicilio.Text = dt.Rows(0).Item(16).ToString
        tbx_ext.Text = dt.Rows(0).Item(17).ToString
        tbx_int.Text = dt.Rows(0).Item(18).ToString
        tbx_cp.Text = dt.Rows(0).Item(19).ToString

    End Sub
    Protected Sub ib_recarga_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ib_recarga.Click
        carga_deinicio()
    End Sub

    '------CODIGO PARA LIMPIAR CONTROLES--------
    Public Sub CleanControl(controles As ControlCollection)
        For Each control As Control In controles
            If TypeOf control Is TextBox Then
                DirectCast(control, TextBox).Text = String.Empty
            ElseIf TypeOf control Is DropDownList Then
                DirectCast(control, DropDownList).ClearSelection()
            ElseIf TypeOf control Is RadioButtonList Then
                DirectCast(control, RadioButtonList).ClearSelection()
            ElseIf TypeOf control Is CheckBoxList Then
                DirectCast(control, CheckBoxList).ClearSelection()
            ElseIf TypeOf control Is RadioButton Then
                DirectCast(control, RadioButton).Checked = False
            ElseIf TypeOf control Is CheckBox Then
                DirectCast(control, CheckBox).Checked = False
            ElseIf control.HasControls() Then
                'Esta linea detécta un Control que contenga otros Controles
                'Así ningún control se quedará sin ser limpiado.
                CleanControl(control.Controls)
            End If
        Next
    End Sub

    '-------------------------------------------------------------------------------

    Private Sub carga_deinicio()
        Select Case isusertype(Session("gcu"))
            Case 1
                cacoensuluAlumno(llenaAlumno(Session("gcu")))
                hf_imageurl.Value = cargaurlfoto(Session("gcu"))
                mv_distpacher.ActiveViewIndex = 3
            Case 3
                cacoensulu(llenaUser(Session("gcu")))
            Case Else
                cacoensulu(llenaUser(Session("gcu")))
        End Select
    End Sub

    ' Private Sub carga_deinicio()
    ' If isusertype(Session("gcu")) = 0 Then
    '         cacoensulu(llenaUser(Session("gcu")))
    ' Else
    '         cacoensuluAlumno(llenaAlumno(Session("gcu")))
    '         hf_imageurl.Value = cargaurlfoto(Session("gcu"))
    '         mv_distpacher.ActiveViewIndex = 3
    ' End If

    'End Sub

    Protected Sub lb_guardar_Click(sender As Object, e As System.EventArgs) Handles lb_guardar.Click

        ''MsgBox(hf_cargo.Value)
        actualizaUser(txtNombre.Text, txtApellidop.Text, txtApellidom.Text, txtCPersonal.Text, hf_cargo.Value.ToString, txtClave.Text, txtCInsti.Text, txtExtension.Text, hf_imageurl.Value, sender.CommandArgument.ToString)
        mv_distpacher.ActiveViewIndex = 2
    End Sub

    Protected Sub lb_cambiar_Click(sender As Object, e As EventArgs)
        mv_distpacher.ActiveViewIndex = 1

    End Sub

    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs)
        mv_distpacher.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_save_Click(sender As Object, e As EventArgs)

        If validaPass(tbx_oldpass.Text) = True Then
            actualizaPass(tbx_nueva.Text, lbl_user.Text)
            mv_distpacher.ActiveViewIndex = 2
        Else
            hf_popupok_mpe.Show()
        End If
    End Sub

    Protected Sub ib_vuelve_Click(sender As Object, e As ImageClickEventArgs)
        mv_distpacher.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs)
        mv_distpacher.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_gcambios_Click(sender As Object, e As EventArgs)

        If validaPass(tbx_c_anterior.Text) Then
            actualizaPass(tbx_n_contra.Text, hf_alumno.Value)
            mv_distpacher.ActiveViewIndex = 2
        Else
            hf_popupok_mpe1.Show()
        End If
    End Sub
    Protected Sub lb_cambia_contra_Click(sender As Object, e As EventArgs)
        mv_distpacher.ActiveViewIndex = 4
        hf_alumno.Value = Session("gcu")

    End Sub
End Class
