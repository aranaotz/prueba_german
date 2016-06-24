Imports System.Data
Imports nuevousuario
Imports carreraCiclo
Imports cvgroups
Imports secure_tools
Imports menumount
Partial Class contents_accion_tutoriado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim claveTrab As String = selectClavetrab(Session("gcu"))

            gv_grupos.DataSource = llenaGruposTutor(claveTrab)
            gv_grupos.DataBind()
            mv_accion.ActiveViewIndex = 0
        End If

    End Sub

    Protected Sub lb_grupo_Click(sender As Object, e As EventArgs)
        mv_accion.ActiveViewIndex = 1
        gv_alumnos.DataSource = cargaAlumnos(sender.commandArgument.ToString)
        gv_alumnos.DataBind()
        hf_ciclo.Value = (cicloGrupo(sender.commandArgument.ToString))




    End Sub


    Protected Sub lb_matricula_Click(sender As Object, e As EventArgs)
        hf_matricula.Value = sender.commandArgument.ToString
        mv_accion.ActiveViewIndex = 2
        cacoensuluAlumno(llenaAlumno(hf_matricula.Value))
        Dim rutaphoto = photoAlumno(hf_matricula.Value)
        img_alumno.ImageUrl = "http://189.208.134.87/siaaa/" + rutaphoto.Substring(0, rutaphoto.Length).Replace("\", "/")



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
        tbx_nacimiento.Text = dt.Rows(0).Item(20).ToString

    End Sub
    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        mv_accion.ActiveViewIndex = 1
    End Sub
    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras.Click
        mv_accion.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_guarda_alumno_Click(sender As Object, e As EventArgs) Handles lb_guarda_alumno.Click

        'Try

        actualizaAlumno(securetext(tbx_curp.Text), securetext(tbx_rfc.Text), securetext(tbx_nss.Text), securetext(tbx_email.Text), securetext(tbx_fijo.Text), securetext(tbx_movil.Text),
                            securetext(tbx_domicilio.Text), securetext(tbx_ext.Text), securetext(tbx_int.Text), securetext(tbx_cp.Text), securetext(tbx_padre.Text),
                            securetext(tbx_contacto1.Text), securetext(tbx_contacto2.Text), hf_matricula.Value)
            mv_accion.ActiveViewIndex = 3

        'Catch ex As Exception

        '    MsgBox("Error al guardar los datos, comunicate con el administrador del sistema")

        'End Try
    End Sub
    Protected Sub ib_vuelve_Click(sender As Object, e As ImageClickEventArgs) Handles ib_vuelve.Click
        mv_accion.ActiveViewIndex = 2
    End Sub
    Protected Sub lb_regresar_Click(sender As Object, e As EventArgs) Handles lb_regresar.Click
        mv_accion.ActiveViewIndex = 0
    End Sub

    Public Sub carga_ddl()

        Dim ddlm As New ListItem("SELECCIONA...")
        With ddl_materias
            .DataSource = cargaMaterias(hf_matricula.Value)
            .DataTextField = "materia"
            .DataValueField = "icu"
            .DataBind()
            .Items.Insert(0, ddlm)
        End With
    End Sub
    Protected Sub lb_justificacion_Click(sender As Object, e As EventArgs) Handles lb_justificacion.Click

        mv_accion.ActiveViewIndex = 4
        carga_ddl()


    End Sub
    Protected Sub ib_atras__Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras_.Click
        mv_accion.ActiveViewIndex = 2
    End Sub
    Protected Sub lb_accion_Click(sender As Object, e As EventArgs) Handles lb_accion.Click
        mv_accion.ActiveViewIndex = 5
        lbl_alumno.Text = tbx_nombres.Text & " " & tbx_primero.Text & " " & tbx_segundo.Text
        gv_temas.DataSource = cargaTemas(securetext(tbx_matricula.Text), hf_ciclo.Value)
        gv_temas.DataBind()
        gv_metas.DataSource = cargaMetas(securetext(tbx_matricula.Text), hf_ciclo.Value)
        gv_metas.DataBind()
        Label2.Text = lbl_alumno.Text


    End Sub
    Protected Sub ib_atras_2_Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras_2.Click
        mv_accion.ActiveViewIndex = 2
        tbx_temas.Text = ""
    End Sub
    Protected Sub cmd_guardar_Click(sender As Object, e As EventArgs) Handles cmd_guardar.Click

        If cmd_guardar.Text = "Guardar" Then
            insertaTemas(securetext(tbx_matricula.Text), securetext(tbx_temas.Text), hf_ciclo.Value)
            tbx_temas.Visible = False
            cmd_guardar.Visible = False
            cmd_canalizar.Visible = False
        Else
            actualizaTema(securetext(tbx_temas.Text), hf_id.Value)

            cmd_guardar.Text = "Guardar"
            cmd_canalizar.Text = "Canalizar"
            tbx_temas.Visible = False
            cmd_guardar.Visible = False
            cmd_canalizar.Visible = False
        End If




        gv_temas.DataSource = cargaTemas(securetext(tbx_matricula.Text), hf_ciclo.Value)
        gv_temas.DataBind()
        tbx_temas.Text = ""

    End Sub
    Protected Sub lb_descripion_Click(sender As Object, e As EventArgs)

        hf_id.Value = sender.commandArgument.ToString
        tbx_temas.Text = temaSeleccionado(hf_id.Value)
        cmd_guardar.Text = "Actualizar"
        tbx_temas.Focus()
        tbx_temas.Attributes.Add("onfocus", "this.select()")
        cmd_canalizar.Text = "Cancelar"
        tbx_temas.Visible = True
        cmd_guardar.Visible = True
        cmd_canalizar.Visible = True


    End Sub
    Protected Sub cmd_canalizar_Click(sender As Object, e As EventArgs) Handles cmd_canalizar.Click

        If cmd_canalizar.Text = "Cancelar" Then
            tbx_temas.Text = ""
            cmd_guardar.Text = "Guardar"
            cmd_canalizar.Text = "Canalizar"
            tbx_temas.Visible = False
            cmd_guardar.Visible = False
            cmd_canalizar.Visible = False
        Else
            moe_hf_canalizar.Show()
            tbx_temas.Visible = False
            cmd_guardar.Visible = False
            cmd_canalizar.Visible = False

        End If


    End Sub
    Protected Sub cmd_ok1_Click(sender As Object, e As EventArgs)

        insertaTemasCanalizado(securetext(tbx_matricula.Text), securetext(tbx_temas.Text), hf_ciclo.Value)
        gv_temas.DataSource = cargaTemas(securetext(tbx_matricula.Text), hf_ciclo.Value)
        gv_temas.DataBind()
        tbx_temas.Text = ""

    End Sub
    Protected Sub cmd_guarda_meta_Click(sender As Object, e As EventArgs) Handles cmd_guarda_meta.Click

        mpe_hf_metas.Show()

        lbl_matricula.Text = tbx_matricula.Text
        tbx_contra.Focus()
        tbx_contra.Text = ""



    End Sub
    Protected Sub cmd_ok_Click(sender As Object, e As EventArgs)

        If validaContraseña(lbl_matricula.Text, securetext_min(tbx_contra.Text)) Then

            insertaMetas(securetext(tbx_matricula.Text), securetext(tbx_metas.Text), hf_ciclo.Value)
            tbx_metas.Text = ""
            tbx_metas.Visible = False
            cmd_guarda_meta.Visible = False

        Else
            mpe_hf_contra.Show()

        End If
        gv_metas.DataSource = cargaMetas(securetext(tbx_matricula.Text), hf_ciclo.Value)
        gv_metas.DataBind()




    End Sub
    Protected Sub lb_metas_Click(sender As Object, e As EventArgs) Handles lb_metas.Click
        mv_accion.ActiveViewIndex = 6
        Label1.Text = lbl_alumno.Text
        tbx_metas.Text = ""
        tbx_metas.Visible = False
        cmd_guarda_meta.Visible = False
    End Sub
    Protected Sub lb_temas_Click(sender As Object, e As EventArgs) Handles lb_temas.Click
        mv_accion.ActiveViewIndex = 7
        tbx_temas.Text = ""
        tbx_temas.Visible = False
        cmd_guardar.Visible = False
        cmd_canalizar.Visible = False
    End Sub
    Protected Sub ib_accion_Click(sender As Object, e As ImageClickEventArgs)
        mv_accion.ActiveViewIndex = 5
    End Sub
    Protected Sub lb_giagnostico_Click(sender As Object, e As EventArgs) Handles lb_giagnostico.Click
        lbl_msgs.Text = ""
        lb_guarda.Text = "Guardar diagnostico"
        mv_accion.ActiveViewIndex = 8
        Label3.Text = lbl_alumno.Text
        tbx_diagnostico.Enabled = True

        gv_temas_diagnostico.DataSource = cargaTemas(securetext(tbx_matricula.Text), hf_ciclo.Value)
        gv_temas_diagnostico.DataBind()
        gv_metas_diagnostico.DataSource = cargaMetas(securetext(tbx_matricula.Text), hf_ciclo.Value)
        gv_metas_diagnostico.DataBind()

        lbl_fecha.Text = "(AUN NO SE GUARDA EL DIAGNOSTICO)"
        tbx_diagnostico.Text = ""

        If validaDiagnostico(tbx_matricula.Text) Then
            cargaDiagnostico(diagnosticoAlumno(tbx_matricula.Text, hf_ciclo.Value))
            tbx_diagnostico.Enabled = False
            lbl_msgs.Text = "*Si deseas modificar el contenido del diagnostico, presiona 'Guardar diagnostico'"

        End If


    End Sub
    Protected Sub lb_nuevotema_Click(sender As Object, e As EventArgs)

        tbx_temas.Visible = True
        cmd_guardar.Visible = True
        cmd_canalizar.Visible = True

    End Sub
    Protected Sub lb_nuevameta_Click(sender As Object, e As EventArgs)
        tbx_metas.Text = ""
        tbx_metas.Visible = True
        cmd_guarda_meta.Visible = True
    End Sub


    Protected Sub lb_guarda_Click(sender As Object, e As EventArgs)

        If lb_guarda.Text = "Guardar diagnostico" Then

            'Try
            If validaDiagnostico(tbx_matricula.Text) Then
                    mpe_hf_diagnostico.Show()

                Else
                    insertaDiagnostico(securetext(tbx_matricula.Text), securetext(tbx_diagnostico.Text), hf_ciclo.Value)
                    mv_accion.ActiveViewIndex = 3

                End If
            '
            ' Catch ex As Exception

            'End Try

        Else
            actualizaDiagnostico(securetext(tbx_diagnostico.Text), tbx_matricula.Text)
            mv_accion.ActiveViewIndex = 3

        End If





    End Sub

    Private Sub cargaDiagnostico(ByVal dt As DataTable)
        tbx_diagnostico.Text = dt.Rows(0).Item(0).ToString
        lbl_fecha.Text = dt.Rows(0).Item(1).ToString

    End Sub

    Protected Sub cmd_modificar_Click(sender As Object, e As EventArgs)
        tbx_diagnostico.Enabled = True
        tbx_diagnostico.Focus()
        tbx_diagnostico.Attributes.Add("onfocus", "this.select()")
        lb_guarda.Text = "Actualizar diagnostico"
    End Sub
    Protected Sub lb_imprime_tutorias_Click(sender As Object, e As EventArgs) Handles lb_imprime_tutorias.Click

        Dim dtcampos As DataTable = campos_de_tabla(Session("gcu"))
        Dim tutor As String = gname(Session("gcu"), gettable(Session("gcu")), dtcampos.Rows(0).Item(2).ToString, dtcampos.Rows(0).Item(1).ToString)

        Response.Redirect("~/contents/crv_prof/rpt_tutoria_individual.aspx?ma=" + tbx_matricula.Text + "&c=" + hf_ciclo.Value + "&t=" + tutor)




    End Sub
End Class
