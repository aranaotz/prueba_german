Imports nuevousuario
Imports secure_tools
Imports user_access
Imports System.Data
Imports System.Data.SqlClient
Partial Class contents_userupkeep
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Mtto. de Usuarios - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            Page.Form.Attributes.Add("enctype", "multipart/form-data")
            nocache()
            backbutton()
            carga_ddl()
            'carga_menues()

            mv_upkeep.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
        gv_resultados.DataSource = tabla_resultados_busqueda(securetext(tbx_busqueda.Text))
        gv_resultados.DataBind()
    End Sub

    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
        cacoensulu(tabla_consulta_llenado(sender.CommandArgument.ToString))
        carga_menues(gubi_user_users(sender.CommandArgument.ToString))

        lbl_user.Text = gnm_user_users(sender.CommandArgument.ToString)
        lbl_clave.Text = gubi_user_users(sender.CommandArgument.ToString)
        lb_guardar.CommandArgument = gubi_user_users(sender.CommandArgument.ToString)
        lb_cambiar.CommandArgument = gubi_user_users(sender.CommandArgument.ToString)
        'lb_contra.CommandArgument = sender.CommandArgument.ToString
        'Page.Form.Attributes.Add("enctype", "multipart/form-data")
        gv_carreras.DataSource = llenaCarreraAsignada(claveTrab(lbl_clave.Text))
        gv_carreras.DataBind()
        mv_upkeep.ActiveViewIndex = 1
    End Sub

    Private Sub cacoensulu(ByVal dt As DataTable)
        txtNombre.Text = dt.Rows(0).Item(0).ToString
        txtApellidop.Text = dt.Rows(0).Item(1).ToString
        txtApellidom.Text = dt.Rows(0).Item(2).ToString
        txtCPersonal.Text = dt.Rows(0).Item(3).ToString
        ddl_cargo.SelectedIndex = ddl_cargo.Items.IndexOf(ddl_cargo.Items.FindByText(dt.Rows(0).Item(4).ToString))
        txtClave.Text = dt.Rows(0).Item(5).ToString
        txtCInsti.Text = dt.Rows(0).Item(6).ToString
        txtExtension.Text = dt.Rows(0).Item(7).ToString
        img_user.ImageUrl = dt.Rows(0).Item(10).ToString
        hf_imageurl.value = dt.Rows(0).Item(10).ToString
    End Sub

    Public Sub carga_ddl()
        With ddl_cargo
            .DataSource = cargaPuesto()
            .DataValueField = "id"
            .DataTextField = "cargo"
            .DataBind()
        End With
    End Sub
    Private Sub carga_menues(ByVal usuario As String)
        gv_menutop.DataSource = topmenu_lleno(usuario)
        gv_menutop.DataBind()
    End Sub

    Protected Sub gv_menutop_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_menutop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cabezalitem As String = CType(CType(e.Row.FindControl("acc_menuch"), AjaxControlToolkit.Accordion).Panes(0).FindControl("hf_cabezalnum"), HiddenField).Value
            Dim usuario As String = CType(e.Row.FindControl("hf_usuario"), HiddenField).Value
            Dim gv_menusub As GridView = CType(CType(e.Row.FindControl("acc_menuch"), AjaxControlToolkit.Accordion).Panes(0).FindControl("gv_menusub"), GridView)
            gv_menusub.DataSource = submenu_lleno(cabezalitem, usuario)
            gv_menusub.DataBind()
        End If
    End Sub

    Private Sub Privilegios(ByVal usuario As String)
        Dim ittop As Integer = 0
        For ittop = 0 To gv_menutop.Rows.Count - 1
            Dim subgv As GridView = CType(CType(gv_menutop.Rows(ittop).FindControl("acc_menuch"), AjaxControlToolkit.Accordion).Panes(0).FindControl("gv_menusub"), GridView)
            Dim itsub As Integer = 0
            For itsub = 0 To subgv.Rows.Count - 1
                Dim cbx As CheckBox = CType(subgv.Rows(itsub).FindControl("cbx_select"), CheckBox)
                If cbx.Checked = True Then
                    newPriv(usuario, CType(subgv.Rows(itsub).FindControl("hf_idpage"), HiddenField).Value, ittop.ToString & itsub.ToString)
                End If
            Next
        Next
    End Sub

    Protected Sub lb_guardar_Click(sender As Object, e As EventArgs) Handles lb_guardar.Click
        actualizaUser(securetext(txtNombre.Text), securetext(txtApellidop.Text), securetext(txtApellidom.Text), securetext(txtCPersonal.Text), securetext(ddl_cargo.SelectedValue.ToString),
                      securetext(txtClave.Text), securetext(txtCInsti.Text), securetext(txtExtension.Text),
                      IIf(uploadfile(fu_photo, sender.CommandArgument.ToString), "..\docstock\admindocs\images\" & securetext(sender.CommandArgument.ToString) & Right(fu_photo.FileName.ToString, 4),
                        hf_imageurl.Value), sender.CommandArgument.ToString)
        mv_upkeep.ActiveViewIndex = 3
    End Sub

    Protected Sub lb_contra_Click(sender As Object, e As EventArgs) Handles lb_contra.Click
        mv_upkeep.ActiveViewIndex = 2
    End Sub

    Protected Sub lb_cambiar_Click(sender As Object, e As EventArgs) Handles lb_cambiar.Click

        If txtNueva.Text <> "" Then
            If txtRepetir.Text <> "" Then
                actualizaLogin(txtRepetir.Text, sender.CommandArgument.ToString)
            End If
        End If
        delPriv(gubi_user_users_(sender.CommandArgument.ToString))
        Privilegios(gubi_user_users_(sender.CommandArgument.ToString))
        eliminaCarrera(securetext(txtClave.Text))
        carreras(securetext(txtClave.Text))
        mv_upkeep.ActiveViewIndex = 3

    End Sub

    Private Sub carreras(ByVal clave As String)


        For Each row As GridViewRow In gv_carreras.Rows
            Dim check As CheckBox = TryCast(row.FindControl("cbx_pertenece"), CheckBox)
            Dim clave_carrera As HiddenField = TryCast(row.FindControl("hf_clave"), HiddenField)
            If check.Checked Then
                carreraProf(clave, clave_carrera.Value)
            Else
                carreraProfDes(clave, clave_carrera.Value)
            End If
        Next


    End Sub
    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs) Handles lb_regresar.Click
        mv_upkeep.ActiveViewIndex = 0
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click

        mv_upkeep.ActiveViewIndex = 0

        gv_resultados.DataSource = tabla_resultados_busqueda(tbx_busqueda.Text)
        gv_resultados.DataBind()
    End Sub

    Protected Sub ib_atras_Click1(sender As Object, e As ImageClickEventArgs) Handles ib_atras.Click
        mv_upkeep.ActiveViewIndex = 1
    End Sub

    Protected Sub ib_vuelve_Click(sender As Object, e As ImageClickEventArgs) Handles ib_vuelve.Click
        mv_upkeep.ActiveViewIndex = 0

        gv_resultados.DataSource = tabla_resultados_busqueda(tbx_busqueda.Text)
        gv_resultados.DataBind()
    End Sub


    Protected Sub btn_continuar_Click(sender As Object, e As EventArgs) Handles btn_continuar.Click
        eliminaUser(lbl_user.Text)
        eliminaLogin(lbl_clave.Text)
        eliminaAcceso(lbl_clave.Text)
        mv_upkeep.ActiveViewIndex = 4

    End Sub

    Protected Sub lb_busqueda_Click(sender As Object, e As EventArgs)
        mv_upkeep.ActiveViewIndex = 0

        gv_resultados.DataSource = tabla_resultados_busqueda(tbx_busqueda.Text)
        gv_resultados.DataBind()
    End Sub
End Class
