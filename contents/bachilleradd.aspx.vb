Imports bachilleratoquery
Imports secure_tools


Partial Class contents_bachilleradd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Nuevo Bachillerato - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            mv_bachilleradd.ActiveViewIndex = 0
            carga_ddl()
            ddl_municipio.Enabled = False

        End If
    End Sub

    Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
        gv_resultados.DataSource = tabla_resultados_busqueda(securetext(tbx_busqueda.Text))
        gv_resultados.DataBind()
    End Sub
    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
        gv_detalle_bachi.DataSource = llenaBachillerato(sender.commandArgument.ToString)
        gv_detalle_bachi.DataBind()
        lb_eliminar.CommandArgument = sender.commandArgument.ToString
        mv_bachilleradd.ActiveViewIndex = 1
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_bachilleradd.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_back_Click(sender As Object, e As EventArgs)
        mv_bachilleradd.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_nueva_Click(sender As Object, e As EventArgs)
        mv_bachilleradd.ActiveViewIndex = 2

    End Sub

    Protected Sub ib_regresa_Click(sender As Object, e As ImageClickEventArgs)
        mv_bachilleradd.ActiveViewIndex = 0
    End Sub

    Protected Sub Linkbutton1_Click(sender As Object, e As EventArgs)
        mv_bachilleradd.ActiveViewIndex = 0
    End Sub

   

    Public Sub carga_ddl()
        Dim ddle As New ListItem("SELECCIONA ESTADO...", "0")
        With ddl_estado
            .DataSource = cargaEstado()
            .DataValueField = "id"
            .DataTextField = "nombre"
            .DataBind()
            .Items.Insert(0, ddle)
        End With

        

    End Sub



  
    Protected Sub ddl_estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_estado.SelectedIndexChanged

        If ddl_estado.SelectedIndex = 0 Then
            ddl_municipio.Enabled = False
            ddl_municipio.SelectedIndex = 0
        Else
            ddl_municipio.Enabled = True
            Dim ddlm As New ListItem("SELECCIONA UN MUNICIPIO...", "0")
            With ddl_municipio
                .DataSource = cargaMunicipio(ddl_estado.SelectedIndex.ToString)
                .DataValueField = "id"
                .DataTextField = "nombre"
                .DataBind()
                .Items.Insert(0, ddlm)
            End With
        End If

    End Sub

    Protected Sub lb_save_Click(sender As Object, e As EventArgs)
        If validaPrepa(securetext(tbx_nombre.Text)) = False Then
            insertaPrepa(securetext(tbx_nombre.Text), ddl_estado.SelectedValue.ToString, ddl_municipio.SelectedValue.ToString, securetext(tbx_localidad.Text), securetext(tbx_domicilio.Text),
                         securetext(tbx_cp.Text), securetext(tbx_telefono.Text))
            mv_bachilleradd.ActiveViewIndex = 4
        Else
            mv_bachilleradd.ActiveViewIndex = 3
        End If
    End Sub

    Protected Sub ib_regresar_Click(sender As Object, e As ImageClickEventArgs)
        mv_bachilleradd.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs)
        mv_bachilleradd.ActiveViewIndex = 2
    End Sub

    Protected Sub ib_regresar__Click(sender As Object, e As ImageClickEventArgs)
        mv_bachilleradd.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_regresar__Click(sender As Object, e As EventArgs)
        mv_bachilleradd.ActiveViewIndex = 2
    End Sub
    Protected Sub lb_eliminar_Click(sender As Object, e As EventArgs) Handles lb_eliminar.Click
        gv_resultados.DataSource = delete_bachillerato(sender.commandArgument.ToString)
        gv_resultados.DataBind()
        mv_bachilleradd.ActiveViewIndex = 0
    End Sub
End Class
