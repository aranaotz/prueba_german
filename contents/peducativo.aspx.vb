Imports programaeducativo
Imports secure_tools
Partial Class contents_peducativo
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Programas Educativos - SIAAA UTJ " + synpin_code.versiones

        If Not IsPostBack Then
            gv_listado.DataSource = listado()
            gv_listado.DataBind()
            mv_peducativo.ActiveViewIndex = 0

        End If

    End Sub


    Public Sub carga_ddl()

        Dim ddlp As New ListItem("Selecciona un nivel...", "0")
        With ddl_nivel
            .DataSource = cargaNivel()
            .DataValueField = "id"
            .DataTextField = "nivel"
            .DataBind()
            .Items.Insert(0, ddlp)
        End With

    End Sub

    Protected Sub lb_clave_Click(sender As Object, e As EventArgs)
        mv_peducativo.ActiveViewIndex = 4
        lbl_clave.Text = sender.commandArgument.ToString
        dv_editar.DataSource = detallePrograma(sender.commandArgument.ToString)
        dv_editar.DataBind()
    End Sub

    Protected Sub lb_nuevo_Click(sender As Object, e As EventArgs)
        mv_peducativo.ActiveViewIndex = 1
        carga_ddl()
        txtNombre.Text = ""
        txtClave.Focus()
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_peducativo.ActiveViewIndex = 0
        gv_listado.DataSource = listado()
        gv_listado.DataBind()
    End Sub

    Protected Sub lb_guardar_Click(sender As Object, e As EventArgs)
        If validaClave(securetext(txtClave.Text)) = False Then
            'Codigo para guardar
            insertar(securetext(txtClave.Text), ddl_nivel.SelectedItem.ToString, securetext(txtNombre.Text))
            'mandar llamar vista de exito
            mv_peducativo.ActiveViewIndex = 2
        Else
            'Vista de error
            mv_peducativo.ActiveViewIndex = 3
        End If
    End Sub

    Protected Sub lb_listado_Click(sender As Object, e As EventArgs)
        mv_peducativo.ActiveViewIndex = 0
        gv_listado.DataSource = listado()
        gv_listado.DataBind()
    End Sub

    Protected Sub lb_programa_Click(sender As Object, e As EventArgs)
        mv_peducativo.ActiveViewIndex = 1
        txtClave.Text = ""
        txtNombre.Text = ""
        txtClave.Focus()
    End Sub

    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs)
        mv_peducativo.ActiveViewIndex = 1
        txtClave.Text = ""
        txtClave.Focus()
    End Sub

    Protected Sub ib_regresar_Click(sender As Object, e As ImageClickEventArgs)
        mv_peducativo.ActiveViewIndex = 1
        txtClave.Text = ""
        txtClave.Focus()
    End Sub

    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs)
        mv_peducativo.ActiveViewIndex = 0
        gv_listado.DataSource = listado()
        gv_listado.DataBind()
    End Sub

    'Protected Sub lb_atras_Click(sender As Object, e As EventArgs)
    '    mv_peducativo.ActiveViewIndex = 0
    '    gv_listado.DataSource = listado()
    '    gv_listado.DataBind()
    'End Sub

    Protected Sub lb_guarda_Click(sender As Object, e As EventArgs)
        Dim nivel, clave, nombre As String
        nivel = securetext(CType(dv_editar.Rows(0).FindControl("txtEnivel"), TextBox).Text)
        clave = securetext(CType(dv_editar.Rows(1).FindControl("txtEclave"), TextBox).Text)
        nombre = securetext(CType(dv_editar.Rows(2).FindControl("txtEnombre"), TextBox).Text)
        actualizaPrograma(nivel, clave, nombre, lbl_clave.Text)
        mv_peducativo.ActiveViewIndex = 2
    End Sub



    Protected Sub cmd_cancelar_Click(sender As Object, e As EventArgs)
        mv_peducativo.ActiveViewIndex = 4
        lbl_clave.Text = sender.commandArgument.ToString
        dv_editar.DataSource = detallePrograma(sender.commandArgument.ToString)
        dv_editar.DataBind()
    End Sub

    Protected Sub btn_continuar_Click(sender As Object, e As EventArgs) Handles btn_continuar.Click
        eliminaPeriodo(lbl_clave.Text)
        mv_peducativo.ActiveViewIndex = 5
    End Sub

   
End Class
