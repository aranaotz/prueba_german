Imports nuevousuario
Imports secure_tools


Imports System.Data
Partial Class newusers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Alta de usuarios - SIAAA UTJ " + synpin_code.versiones()
        If Not IsPostBack Then
            Page.Form.Attributes.Add("enctype", "multipart/form-data")
            nocache()
            backbutton()
            carga_ddl()
            carga_menues()
            gv_carreras.DataSource = Nothing
            gv_carreras.DataBind()
            mv_altausuario.ActiveViewIndex = 0


        End If
    End Sub

    Protected Sub lb_guardar_Click(sender As Object, e As EventArgs) Handles lb_guardar.Click
        If validaLogin(securetext(txtUser.Text)) = False Then
            newUser(securetext(txtNombre.Text), securetext(txtPaterno.Text), securetext(txtMaterno.Text), ddl_puesto.SelectedValue.ToString, securetext(txtClave.Text), securetext(txtUser.Text),
                    IIf(uploadfile(fu_photo, txtUser.Text), "..\docstock\admindocs\images\" & securetext(txtUser.Text) & Right(fu_photo.FileName.ToString, 4),
                        "..\docstock\admindocs\images\defaultimg.jpg"))
            newLogin(securetext(txtUser.Text), securetext(txtPass.Text))
            Privilegios(securetext(txtUser.Text))
            carreras(securetext(txtClave.Text))
            mv_altausuario.ActiveViewIndex = 2
        Else
            mv_altausuario.ActiveViewIndex = 1
        End If
    End Sub

    Public Sub carga_ddl()
        Dim ddlp As New ListItem("Selecciona un puesto...", "0")
        With ddl_puesto
            .DataSource = cargaPuesto()
            .DataValueField = "id"
            .DataTextField = "cargo"
            .DataBind()
            .Items.Insert(0, ddlp)
        End With

    End Sub

    Private Sub carga_menues()
        gv_menutop.DataSource = topmenu()
        gv_menutop.DataBind()
    End Sub

    Protected Sub gv_menutop_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_menutop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cabezalitem As String = CType(CType(e.Row.FindControl("acc_menuch"), AjaxControlToolkit.Accordion).Panes(0).FindControl("hf_cabezalnum"), HiddenField).Value
            Dim gv_menusub As GridView = CType(CType(e.Row.FindControl("acc_menuch"), AjaxControlToolkit.Accordion).Panes(0).FindControl("gv_menusub"), GridView)
            gv_menusub.DataSource = submenu(cabezalitem)
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


    Protected Sub ib_regresar__Click(sender As Object, e As ImageClickEventArgs) Handles ib_regresar_.Click
        mv_altausuario.ActiveViewIndex = 0
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        ddl_puesto.SelectedIndex = 0
        txtUser.Text = ""
        txtPass.Text = ""
        txtCPass.Text = ""
        txtClave.Text = ""
        txtNombre.Focus()
    End Sub

    Protected Sub lb_regresar__Click(sender As Object, e As EventArgs) Handles lb_regresar_.Click
        mv_altausuario.ActiveViewIndex = 0
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        ddl_puesto.SelectedIndex = 0
        txtUser.Text = ""
        txtPass.Text = ""
        txtCPass.Text = ""
        txtClave.Text = ""
        txtNombre.Focus()
    End Sub

    Protected Sub lb_regresar_Click(sender As Object, e As ImageClickEventArgs) Handles lb_regresar.Click
        mv_altausuario.ActiveViewIndex = 0
        txtUser.Text = ""
        txtPass.Text = ""
        txtCPass.Text = ""
        txtClave.Text = ""
        txtUser.Focus()
    End Sub
    Protected Sub ib_regresar_Click(sender As Object, e As EventArgs) Handles ib_regresar.Click
        mv_altausuario.ActiveViewIndex = 0
        txtUser.Text = ""
        txtPass.Text = ""
        txtCPass.Text = ""
        txtClave.Text = ""
        txtUser.Focus()
    End Sub
    Protected Sub ddl_puesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_puesto.SelectedIndexChanged
        Dim value As Integer = ddl_puesto.SelectedValue.ToString
        Select Case value
            Case 5, 7, 8, 9, 10, 28
                lbl_asig.Text = "Asignación de carreras"
                gv_carreras.DataSource = llenaCarrera()
                gv_carreras.DataBind()

            Case Else
                gv_carreras.DataSource = Nothing
                gv_carreras.DataBind()
                lbl_asig.Text = ""

        End Select
    End Sub
End Class
