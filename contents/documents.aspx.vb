Imports synpin_code
Imports print_docs
Imports downdocument
Imports dtciclos
Imports secure_tools
Imports carreraCiclo
Imports System.Data

Partial Class documents
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Recepción de documentos - SIAAA UTJ " + versiones()

        If Not IsPostBack Then
            mv_general.ActiveViewIndex = 3
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            llena_carrera()


            'evitar doble clic



        End If
    End Sub

    Private Sub llena_carrera()
        ddl_carreras.DataSource = tabla_carreras(Application("str"), "TSU")
        ddl_carreras.DataValueField = "cv_carrera"
        ddl_carreras.DataTextField = "carrera"
        ddl_carreras.DataBind()
    End Sub

    Private Sub llena_turno(ByVal carrera As String, ByVal carrerav As String)
        ddl_turno.DataSource = tabla_turnos(Application("str"), carrera)
        ddl_turno.DataValueField = "id_turno"
        ddl_turno.DataTextField = "turno"
        ddl_turno.DataBind()
    End Sub



    Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
        gv_resultados.DataSource = tabla_resultados_busqueda(securetext(tbx_busqueda.Text), hf_ciclo.Value)
        gv_resultados.DataBind()


    End Sub

    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
        cacoensulu(tabla_consulta_llenado(sender.CommandArgument.ToString, hf_ciclo.Value))
        llenadocs(ustring_pingreso(sender.CommandArgument.ToString))
        lb_guardar.CommandArgument = sender.CommandArgument.ToString
        lb_imprimircr.CommandArgument = ustring_pingreso(sender.CommandArgument.ToString)
        mv_general.ActiveViewIndex = 1

        txtFolio.Attributes.Add("onclick", "this.select()")
    End Sub


    Private Sub llenadocs(ByVal ustring As String)
        nuevos_docs(ustring)
        gv_documentos.DataSource = tabla_documentos(ustring)
        gv_documentos.DataBind()
    End Sub
    Private Sub cacoensulu(ByVal dt As DataTable)
        ddl_carreras.SelectedIndex = ddl_carreras.Items.IndexOf(ddl_carreras.Items.FindByValue(dt.Rows(0).Item(3).ToString)) 'Carrera
        llena_turno(dt.Rows(0).Item(3).ToString, dt.Rows(0).Item(3).ToString) 'turno
        ddl_turno.SelectedIndex = ddl_turno.Items.IndexOf(ddl_turno.Items.FindByValue(dt.Rows(0).Item(4).ToString))
        txtFolio.Text = dt.Rows(0).Item(86).ToString 'folio
        tbx_1.Text = dt.Rows(0).Item(5).ToString 'nombre
        tbx_2.Text = dt.Rows(0).Item(6).ToString 'apellido paterno
        tbx_3.Text = dt.Rows(0).Item(7).ToString 'apellido materno
        tbx_16.Text = dt.Rows(0).Item(20).ToString 'telefono fijo
        tbx_17.Text = dt.Rows(0).Item(21).ToString 'telefono movil
        tbx_18.Text = dt.Rows(0).Item(22).ToString 'otro telefono
        tbx_19.Text = dt.Rows(0).Item(23).ToString 'email
        tbx_20.Text = dt.Rows(0).Item(24).ToString 'curp

        tbx_23.Text = dt.Rows(0).Item(27).ToString 'bachillerato de procedencia
        ddl_24.SelectedIndex = ddl_24.Items.IndexOf(ddl_24.Items.FindByText(dt.Rows(0).Item(28).ToString)) 'ingreso año
        ddl_25.SelectedIndex = ddl_25.Items.IndexOf(ddl_25.Items.FindByValue(dt.Rows(0).Item(29).ToString)) 'ingreso mes
        ddl_26.SelectedIndex = ddl_26.Items.IndexOf(ddl_26.Items.FindByText(dt.Rows(0).Item(30).ToString)) 'egreso año
        ddl_27.SelectedIndex = ddl_27.Items.IndexOf(ddl_27.Items.FindByValue(dt.Rows(0).Item(31).ToString)) 'egreso mes
        tbx_28.Text = dt.Rows(0).Item(32).ToString 'promedio
        img_user.ImageUrl = dt.Rows(0).Item(85).ToString 'ruta de imagen

    End Sub


    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        mv_general.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_guardar_Click(sender As Object, e As EventArgs) Handles lb_guardar.Click
        Try
            For t = 0 To gv_documentos.Rows.Count - 1
                Dim entregado As Boolean = CType(gv_documentos.Rows(t).FindControl("cbx_entregado"), CheckBox).Checked
                Dim comentario As TextBox = CType(gv_documentos.Rows(t).FindControl("tbx_comentario"), TextBox)
                Dim id As String = CType(gv_documentos.Rows(t).FindControl("hf_id"), HiddenField).Value
                guardardocumentos(id, entregado.ToString, comentario.Text)
            Next
            update_pingreso(sender.CommandArgument.ToString, securetext(tbx_23.Text), secureddl(ddl_24), secureddl(ddl_25), secureddl(ddl_26), secureddl(ddl_27), securetext(tbx_28.Text))
            guardar_ceneval(ustring_pingreso(sender.CommandArgument.ToString), securetext(txtFolio.Text), ustring_pingreso(sender.CommandArgument.ToString).Substring(0, 5))
            llenadocs(ustring_pingreso(sender.CommandArgument.ToString))
            actualizaPingreso(sender.commandArgument.ToString)
            mv_general.ActiveViewIndex = 2
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub lb_imprimircr_Click(sender As Object, e As EventArgs) Handles lb_imprimircr.Click
        'sei005(sender.CommandArgument.ToString)
        'Try
        '    descarga("SE-I005", sender.CommandArgument.ToString, ".pdf")
        'Catch ex As Exception

        'End Try

        'Crystal reports
        Dim ustring As String = sender.CommandArgument.ToString

        Response.Redirect("~/contents/crv_pi/rpt_sei005.aspx?u=" + ustring)

    End Sub
    Protected Sub ib_regresar__Click(sender As Object, e As ImageClickEventArgs)
        mv_general.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_regresar__Click(sender As Object, e As EventArgs)
        mv_general.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        mv_general.ActiveViewIndex = 0
        hf_ciclo.Value = sender.commandArgument.ToString
    End Sub
    Protected Sub ib_regresar_Click(sender As Object, e As ImageClickEventArgs)
        mv_general.ActiveViewIndex = 3
    End Sub
End Class