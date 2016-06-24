Imports synpin_code
Imports print_docs
Imports downdocument
Imports dtciclos
Imports secure_tools
Imports System.Data


Partial Class regpin_
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Formulario de Primer Ingreso - SIAAA UTJ " + versiones()
        'mv_msgs.ActiveViewIndex = 0
        nocache()
        backbutton()
        If Not IsPostBack Then
            llena_carrera()
            llena_escuelas()
            llena_pais()
            llena_etnia()
            llena_beca_bachi()
            llena_apoyo_beca_pi()
            llena_cronicas()
            llena_talleres()
            up_carreras.Update()
            dl_razon.DataSource = muestraRazones()
            dl_razon.DataBind()
            dl_medios.DataSource = muestraMedios()
            dl_medios.DataBind()
            hf_cs.Value = "31/12/3999"
            tbx_20.Text = Request.QueryString("cu")
        End If
    End Sub

    Private Sub llena_carrera()
        ddl_carreras.DataSource = tabla_carreras_actuales(Application("str"), "TSU", actualcycle(Application("str")))
        ddl_carreras.DataValueField = "cv_carrera"
        ddl_carreras.DataTextField = "nombre"
        ddl_carreras.DataBind()
        Dim lit As New ListItem
        lit.Text = "Elije la carrera de tu preferencia..."
        lit.Value = "0"
        ddl_carreras.Items.Insert(0, lit)
        Dim lit2 As New ListItem
        lit2.Text = "Selecciona una carrera..."
        lit2.Value = "0"
        ddl_turno.Items.Insert(0, lit2)

    End Sub

    Private Sub llena_pais()
        Dim pais As New ListItem("Selecciona un país...", 0)
        With ddl_paises
            .DataSource = llenaPais()
            .DataValueField = "id"
            .DataTextField = "pais"
            .DataBind()
            .Items.Insert(0, pais)
        End With

    End Sub

    Private Sub llena_etnia()
        Dim etnia As New ListItem("SELECCIONA UN GRUPO ETNICO...", 0)
        With ddl_grupo_etnico
            .DataSource = llenaEtnia()
            .DataValueField = "id"
            .DataTextField = "grupo"
            .DataBind()
            .Items.Insert(0, etnia)
        End With


    End Sub



    Private Sub llena_cronicas()
        Dim cronica As New ListItem("SELECCIONA UNA ENFERMEDAD...", 0)
        With ddl_cronicas
            .DataSource = llenaCronica()
            .DataValueField = "id"
            .DataTextField = "tipo"
            .DataBind()
            .Items.Insert(0, cronica)
        End With
    End Sub


    Private Sub llena_beca_bachi()
        Dim beca As New ListItem("SELECCIONA UNA OPCION...", 0)
        With ddl_becas
            .DataSource = llenaBecaBachi()
            .DataValueField = "id"
            .DataTextField = "motivo"
            .DataBind()
            .Items.Insert(0, beca)
        End With
    End Sub


    Private Sub llena_apoyo_beca_pi()
        Dim beca As New ListItem("SELECCIONA UNA OPCION...", 0)
        With ddl_apoyos
            .DataSource = llenaApoyoBecaPi()
            .DataValueField = "id"
            .DataTextField = "motivo"
            .DataBind()
            .Items.Insert(0, beca)
        End With
    End Sub

    Private Sub llena_talleres()
        Dim taller As New ListItem("SELECCIONA UNA OPCION...", 0)
        With ddl_deportes
            .DataSource = llenaTalleres()
            .DataValueField = "id"
            .DataTextField = "taller"
            .DataBind()
            .Items.Insert(0, taller)
        End With
    End Sub


    Private Sub llena_escuelas()
        ddl_68.DataSource = tabla_escuelas()
        ddl_68.DataValueField = "id"
        ddl_68.DataTextField = "escuela"
        ddl_68.DataBind()
        Dim lit3 As New ListItem
        lit3.Text = "Selecciona..."
        lit3.Value = "0"
        ddl_68.Items.Insert(0, lit3)

    End Sub



    Private Sub llena_turno(ByVal carrera As String, ByVal carrerav As String)
        ddl_turno.Items.Clear()
        If carrerav = "0" Then
            Dim dtclean As New DataTable
            ddl_turno.DataSource = dtclean
            ddl_turno.DataValueField = "id_turno"
            ddl_turno.DataTextField = "turno"
            ddl_turno.DataBind()
            Dim lit As New ListItem
            lit.Text = "Selecciona una carrera..."
            lit.Value = "0"
            ddl_turno.Items.Insert(0, lit)

            rbl_49.Items.Clear()
            'rbl_49.DataSource = dtclean
            'rbl_49.DataValueField = "id_turno"
            'rbl_49.DataTextField = "turno"
            'rbl_49.DataBind()

        Else
            ddl_turno.DataSource = tabla_turnos(Application("str"), carrera)
            ddl_turno.DataValueField = "id_turno"
            ddl_turno.DataTextField = "turno"
            ddl_turno.DataBind()
            Dim lit As New ListItem
            lit.Text = "Elije el turno..."
            lit.Value = "0"
            ddl_turno.Items.Insert(0, lit)
        End If
    End Sub

    Protected Sub gv_poblacion_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_poblacion.RowCommand
        'tbx_10.Text = dame_lugar(e.CommandArgument)
        tbx_10.Text = e.CommandArgument.ToString
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub gv_cps_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim dt As DataTable = colonia_ciudad_estado(e.CommandArgument.ToString)
        If dt.Rows.Count = 0 Then
            tbx_13.Text = ""
            tbx_14.Text = ""
            tbx_15.Text = ""
        Else
            tbx_13.Text = dt.Rows(0).Item(0).ToString
            tbx_14.Text = dt.Rows(0).Item(1).ToString
            tbx_15.Text = dt.Rows(0).Item(2).ToString
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_buscar_poblacion_Click(sender As Object, e As EventArgs) Handles cmd_buscar_poblacion.Click
        gv_poblacion.DataSource = muestra_ciudades(tbx_50.Text)
        gv_poblacion.DataBind()
    End Sub

    Protected Sub cmd_bln_Click(sender As Object, e As EventArgs) Handles cmd_bln.Click
        tbx_50.Text = ""
        Dim dblank As New DataTable
        gv_poblacion.DataSource = dblank
        gv_poblacion.DataBind()
        mv_msgs.ActiveViewIndex = 0
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub ib_bcp_Click(sender As Object, e As ImageClickEventArgs) Handles ib_bcp.Click
        gv_cps.DataSource = muestra_lugares(tbx_12.Text)
        gv_cps.DataBind()
        mv_msgs.ActiveViewIndex = 1
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub ib_close_Click(sender As Object, e As ImageClickEventArgs) Handles ib_close.Click
        hf_popupo_mpe.Hide()
        p_test.Update()
    End Sub

    Protected Sub ddl_carreras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_carreras.SelectedIndexChanged
        If ddl_carreras.SelectedIndex <> 0 Then
            llena_turno(ddl_carreras.SelectedValue.ToString, "1")
        Else
            llena_turno(ddl_carreras.SelectedValue.ToString, "0")
        End If
        up_carreras.Update()
        up_calendario.Update()
    End Sub

    Protected Sub cmd_buscar_escuela_Click(sender As Object, e As EventArgs) Handles cmd_buscar_escuela.Click
        gv_escuela.DataSource = tabla_prepa_escuela(Application("str"), tbx_bescuela.Text)
        gv_escuela.DataBind()
    End Sub

    Protected Sub gv_escuela_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        tbx_23.Text = fullescuelas(e.CommandArgument.ToString)
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_besc_Click(sender As Object, e As EventArgs) Handles cmd_besc.Click
        tbx_bescuela.Text = ""
        Dim dblank As New DataTable
        gv_escuela.DataSource = dblank
        gv_escuela.DataBind()
        mv_msgs.ActiveViewIndex = 2
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub ddl_32_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_32.SelectedIndexChanged
        If ddl_32.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 3
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub ddl_33_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_33.SelectedIndexChanged
        If ddl_33.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 4
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cmd_cancelarextra_Click(sender As Object, e As EventArgs) Handles cmd_cancelarextra.Click
        If tbx_51.Text = "" Or tbx_52.Text = "" Or tbx_53.Text = "" Then
            ddl_32.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_cancelarcert_Click(sender As Object, e As EventArgs) Handles cmd_cancelarcert.Click
        If tbx_54.Text = "" Then
            ddl_33.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub ddl_39_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_39.SelectedIndexChanged
        If ddl_39.SelectedValue = 2 Then

            tbx_otra.Visible = False
            lbl_otra.Visible = False
            tbx_tratamiento.Visible = False
            lbl_tratamiento.Visible = False
            mv_msgs.ActiveViewIndex = 5
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub ddl_40_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_40.SelectedIndexChanged
        If ddl_40.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 6
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cmd_extraordinarios_Click(sender As Object, e As EventArgs) Handles cmd_extraordinarios.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_certificado_Click(sender As Object, e As EventArgs) Handles cmd_certificado.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_cronicos_Click(sender As Object, e As EventArgs) Handles cmd_cronicos.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_psicologicos_Click(sender As Object, e As EventArgs) Handles cmd_psicologicos.Click
        hf_popupo_mpe.Hide()
    End Sub

    'Protected Sub cmd_cancelarcronicos_Click(sender As Object, e As EventArgs) Handles cmd_cancelarcronicos.Click
    ' If ddl_cronicas.SelectedIndex = 0 Or ddl_56.SelectedIndex = 0 Then
    '         ddl_39.SelectedIndex = 0
    ' End If
    '     hf_popupo_mpe.Hide()
    'End Sub

    Protected Sub cmd_cancelarpsicologicos_Click(sender As Object, e As EventArgs) Handles cmd_cancelarpsicologicos.Click
        If tbx_57.Text = "" Or ddl_58.SelectedIndex = 0 Then
            ddl_40.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub ddl_41_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_41.SelectedIndexChanged
        If ddl_41.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 7
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub ddl_42_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_42.SelectedIndexChanged
        If ddl_42.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 8
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cmd_cancelarcasa_Click(sender As Object, e As EventArgs) Handles cmd_cancelarcasa.Click
        If ddl_61.SelectedIndex = 0 Then
            ddl_42.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_cancelarhijos_Click(sender As Object, e As EventArgs) Handles cmd_cancelarhijos.Click
        If tbx_60.Text = "" Or ddl_59.SelectedIndex = 0 Then
            ddl_41.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_hijos_Click(sender As Object, e As EventArgs) Handles cmd_hijos.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_casa_Click(sender As Object, e As EventArgs) Handles cmd_casa.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_trabajo_Click(sender As Object, e As EventArgs) Handles cmd_trabajo.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_cancelartrabajo_Click(sender As Object, e As EventArgs) Handles cmd_cancelartrabajo.Click
        If tbx_62.Text = "" Or tbx_63.Text = "" Or tbx_64.Text = "" Or tbx_65.Text = "" Or ddl_66.SelectedIndex = 0 Or ddl_67.SelectedIndex = 0 Then
            ddl_43.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub ddl_43_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_43.SelectedIndexChanged
        If ddl_43.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 9
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cmd_registro_Click(sender As Object, e As EventArgs) Handles cmd_registro.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_cancelaregistro_Click(sender As Object, e As EventArgs) Handles cmd_cancelaregistro.Click
        If ddl_68.SelectedIndex = 0 Or ddl_69.SelectedIndex = 0 Or ddl_70.SelectedIndex = 0 Or ddl_71.SelectedIndex = 0 Or tbx_72.Text = "" Then
            ddl_45.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cal_48_SelectionChanged(sender As Object, e As EventArgs) Handles cal_48.SelectionChanged
        hf_cs.Value = cal_48.SelectedDate.ToString
        tbx_fechavalid.Text = cal_48.SelectedDate
        rbl_49.DataSource = horas_noagenda(cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day, pi_cicloregistro, ddl_carreras.SelectedValue.ToString)
        rbl_49.DataTextField = "hora"
        rbl_49.DataValueField = "hora"
        rbl_49.DataBind()
        rbl_49.SelectedIndex = 0
        up_calendario.Update()
    End Sub

    'Protected Sub CheckIfCheckBoxListIsCheckedServer(ByVal source As Object, ByVal args As ServerValidateEventArgs) Handles cv_cbx_47.ServerValidate
    '    If cbx_47.SelectedIndex = -1 Then
    '        args.IsValid = False
    '    Else
    '        args.IsValid = True
    '    End If
    'End Sub

    'Protected Sub CheckIfCheckBoxListIsCheckedServer2(ByVal source As Object, ByVal args As ServerValidateEventArgs) Handles cv_cbx_73.ServerValidate
    '    If cbx_73.SelectedIndex = -1 Then
    '        args.IsValid = False
    '    Else
    '        args.IsValid = True
    '    End If
    'End Sub

    Protected Sub ddl_45_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_45.SelectedIndexChanged
        If ddl_45.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 10
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cal_day_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles cal_48.DayRender
        Try
            Dim siguiente_fecha As Date
            'Dim local_dias_noagenda As DataTable = dias_noagenda("CITA_ENTREVISTA_CONTROL_ESCOLAR", ddl_carreras.SelectedValue.ToString, ddl_ciclo.SelectedValue.ToString)
            Dim local_dias_noagenda As DataTable = dias_noagenda("CITA_ENTREVISTA_CONTROL_ESCOLAR", ddl_carreras.SelectedValue.ToString, pi_cicloregistro)
            If local_dias_noagenda.Rows.Count > 0 Then
                Dim fd As Integer
                For fd = 0 To local_dias_noagenda.Rows.Count - 1
                    siguiente_fecha = CType(local_dias_noagenda.Rows(fd).Item(0).ToString, Date)
                    If siguiente_fecha = e.Day.Date Then
                        If e.Day.Date >= Now.Date Then
                            If e.Day.Date = Now.Date And Now.Hour > 16 Then
                                e.Cell.CssClass = "dia_deshabilitado"
                                e.Day.IsSelectable = False
                                e.Cell.ToolTip = "Este día no puede agendar."
                            Else
                                e.Cell.CssClass = local_dias_noagenda.Rows(fd).Item(2).ToString
                                e.Day.IsSelectable = local_dias_noagenda.Rows(fd).Item(1).ToString
                                Exit For
                            End If
                        Else
                            e.Cell.CssClass = "dia_deshabilitado"
                            e.Day.IsSelectable = False
                            e.Cell.ToolTip = "Este día no puede agendar."
                        End If
                    Else
                        e.Cell.CssClass = "dia_deshabilitado"
                        e.Day.IsSelectable = False
                        e.Cell.ToolTip = "Este día no puede agendar."
                    End If
                Next
            Else
                e.Cell.CssClass = "dia_deshabilitado"
                e.Day.IsSelectable = False
                e.Cell.ToolTip = "Este día no puede agendar."
            End If
        Catch ex As Exception
            e.Cell.CssClass = "dia_deshabilitado"
            e.Day.IsSelectable = False
            e.Cell.ToolTip = "Este día no puede agendar."
        End Try
        cal_48.VisibleDate = Now
        'up_calendario.Update()
    End Sub

    Protected Sub cmd_save_Click(sender As Object, e As EventArgs) Handles cmd_save.Click
        Session("idd") = idsol(pi_cicloregistro, ddl_carreras.SelectedValue.ToString)
        If securetext(tbx_1.Text) = "TESTSET" Then
            Session("idd") = "1"
            salvapi("ARH", "1", "RODRIGO FRANCISCO PABLO", "PEREZ FERNANDEZ", "ROBLE DE LA BOMBOYA", "1", "1", "1", "2015", "05", "20",
                    "Delegación de La Secretaria de Comercio y Fomento Industrial", "JUAN PEDRO JOSE FERNANDEZ MELENDEZ 35 INTERIOR 3453",
                    "44950", "COLONIA DE LOS CISNES VERDES", "VERACRUZ DE LA LLAVE", "MICHOACAN DE LA VERDURA", "1990778899", "381990778899",
                    "381990778899", "elpocaspulgasmequitas@colegioverdevalle.com", "BADD110313HCMLNS09", "110", "205",
                    "ESCUELA INTERESTATAL DE LA MORONGA CUADRADA NO. 33", "2009", "09", "2013", "03", "98.6", "1", "1", "1", "1", "1",
                    "PUES ES QUE LA NETA NO VALE LA PENA ESTUDIAR MATERIAS QUE NUNCA VAMOS A UTILIZAR EN LA VIDA",
                    "EL PROFE DECIA QUE 2 MAS 2 NO ERAN CUATRO SI NO 5 Y NOS DEMOSTRO ALGO QUE JAMAS LE ENTENDI Y DEJO DE GUSTARME", "1", "1", "1", "1", "1",
                    "1", "1", "1", "1", "1", "1", "La carrera cumple con los requisitos, Por que el horario me permite hacer otras actividades",
                    "Espectaculares, Familiares y amigos", "2015-4-30 10:00", "1", "ESPAÑOL Y MATEMATICAS CULINARIAS", "POR FALTA DE APROVECHAMIENTO",
                    "PUES ES QUE SE ME PERDIO Y NO ME LO QUISIERON DAR DE NUEVO", "ME DUELE LA CARA DE SER TAN GUAPO", "1", "ATENCION PERSONALIZADA CON MI AMIGA",
                    "1", "1", "2,4,6,8,10", "1", "KODAK DEL PACIFICO ENTERTAINMENT SYSTEM", "ME HAGO BUEY COMO PEDRO", "DE LAS 8 HASTA LAS 9",
                    "GIRA SOBRE SU EJE DE 360 GRADOS NORESTE", "1", "EN LA TARDE", "1", "1", "1", "1",
                    "INGENIERIA BIOMEDICA Y ALIMENTOS TECNOLOGICOS", "1", Session("idd"), "2015-05-20", "10:00", pi_cicloregistro, "1", "1", "1", "1", "1", "1",
                    "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1")
        Else
            salvapi(secureddl(ddl_carreras), secureddl(ddl_turno), securetext(tbx_1.Text), securetext(tbx_2.Text), securetext(tbx_3.Text), secureddl(ddl_4), secureddl(ddl_5), secureddl(ddl_6), secureddl(ddl_7), secureddl(ddl_8),
                secureddl(ddl_9), securetext(tbx_10.Text), securetext(tbx_11.Text), securetext(tbx_12.Text), securetext(tbx_13.Text), securetext(tbx_14.Text), securetext(tbx_15.Text), securetext(tbx_16.Text), securetext(tbx_17.Text), securetext(tbx_18.Text),
                securetext(tbx_19.Text), securetext(tbx_20.Text), securetext(tbx_21.Text), securetext(tbx_22.Text), securetext(tbx_23.Text), secureddl(ddl_24), secureddl(ddl_25), secureddl(ddl_26), secureddl(ddl_27), securetext(tbx_28.Text),
                secureddl(ddl_29), secureddl(ddl_30), secureddl(ddl_74), secureddl(ddl_32), secureddl(ddl_33), securetext(tbx_34.Text), securetext(tbx_35.Text), secureddl(ddl_31), "0", "0",
                "0", secureddl(ddl_39), secureddl(ddl_40), secureddl(ddl_41), secureddl(ddl_42), secureddl(ddl_43), secureddl(ddl_44), secureddl(ddl_45), "", "",
                dia_hora_cita, securetext(tbx_51.Text), securetext(tbx_52.Text), securetext(tbx_53.Text), securetext(tbx_54.Text), "", "0", securetext(tbx_57.Text),
                secureddl(ddl_58), secureddl(ddl_59), securetext(tbx_60.Text), secureddl(ddl_61), securetext(tbx_62.Text), securetext(tbx_63.Text), securetext(tbx_64.Text), securetext(tbx_65.Text),
                secureddl(ddl_66), secureddl(ddl_67), secureddl(ddl_68), secureddl(ddl_69), secureddl(ddl_70), secureddl(ddl_71), securetext(tbx_72.Text), secureddl(ddl_75), Session("idd"),
                cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day, rbl_49.SelectedValue.ToString, pi_cicloregistro, secureddl(ddl_nacionalidad),
                secureddl(ddl_paises), securetext(ddl_paises.SelectedItem.Text), secureddl(ddl_etnias), secureddl(ddl_grupo_etnico), securetext(ddl_grupo_etnico.SelectedItem.Text),
                secureddl(ddl_beca), secureddl(ddl_becas), securetext(ddl_becas.SelectedItem.Text), securetext(tbx_becas.Text), secureddl(ddl_apoyo), secureddl(ddl_apoyos),
                securetext(ddl_apoyos.SelectedItem.Text), securetext(tbx_apoyo.Text), secureddl(ddl_39), secureddl(ddl_cronicas), securetext(tbx_otra.Text), secureddl(ddl_tratamiento), securetext(tbx_tratamiento.Text),
                secureddl(ddl_deporte), secureddl(ddl_deportes), securetext(ddl_deportes.SelectedItem.Text), securetext(txt_deportes.Text))

        End If
        guardar_multiseleccion(dl_razon, "pingreso_razones", Session("idd"))
        guardar_multiseleccion(dl_medios, "pingreso_medios", Session("idd"))
        lbl_ndreg.Text = Session("idd")
        lbl_fyhe.Text = cal_48.SelectedDate.Day & " de " & nombremes(cal_48.SelectedDate.Month) & " de " & cal_48.SelectedDate.Year & " a las " & rbl_49.SelectedItem.Text & " hrs."
        Try
            Dim dttemp As DataTable = senderemail("1")
            ccei001(Session("idd"))
            send_mail(getemail(Session("idd")), Session("idd") & ".pdf", dttemp.Rows(0).Item(0).ToString, dttemp.Rows(0).Item(1).ToString)
        Catch ex As Exception
            lbl_ndreg.Text = ex.ToString
        End Try
        hf_popupok_mpe.Show()
        cmd_save.Enabled = False
    End Sub

    Private Sub guardar_multiseleccion(ByVal dt As DataList, tabla As String, idd As String)
        Dim k As Integer = 0
        For k = 0 To dt.Items.Count - 1
            Dim cbx As Boolean = CType(dt.Items(k).FindControl("cbx_select"), CheckBox).Checked
            If cbx = True Then
                Dim id_catalog As String = CType(dt.Items(k).FindControl("hf_id"), HiddenField).Value
                'salvaseleccionados(id_catalog, idd, tabla)
                'solo se agrega ciclo y turno
                salvaseleccionados(id_catalog, idd, tabla, pi_cicloregistro, ddl_turno.SelectedValue.ToString)
            End If
        Next
    End Sub

    Private Function dia_hora_cita() As String
        Return cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day & " " & rbl_49.SelectedValue.ToString
    End Function

    Protected Sub cmd_cancelar_Click(sender As Object, e As EventArgs) Handles cmd_cancelar.Click
        'datosreportei001("2015B00000498")
        Response.Redirect("http://siaaa.utj.edu.mx/siaaa/")
    End Sub

    'Private Function motivo_de_inscripcion() As String
    '    motivo_de_inscripcion = ""
    '    Dim cbxl As CheckBoxList = cbx_47
    '    For i = 0 To cbxl.Items.Count - 1
    '        If cbxl.Items(i).Selected = True Then
    '            If motivo_de_inscripcion = "" Then
    '                motivo_de_inscripcion = cbxl.Items(i).Text
    '            Else
    '                motivo_de_inscripcion = motivo_de_inscripcion & ", " & cbxl.Items(i).Text
    '            End If
    '        End If
    '    Next
    'End Function

    'Private Function enterado() As String
    '    enterado = ""
    '    Dim cbxl As CheckBoxList = cbx_73
    '    For i = 0 To cbxl.Items.Count - 1
    '        If cbxl.Items(i).Selected = True Then
    '            If enterado = "" Then
    '                enterado = cbxl.Items(i).Text
    '            Else
    '                enterado = enterado & ", " & cbxl.Items(i).Text
    '            End If
    '        End If
    '    Next
    'End Function

    Protected Sub cmd_descarga_Click(sender As Object, e As EventArgs) Handles cmd_descarga.Click
        'Try
        '    descarga("cce-i001", Session("idd"), ".pdf")
        'Catch ex As Exception

        'End Try

        'Crystal reports
        Dim ustring As String = Session("idd")

        Response.Redirect("~/contents/crv_pi/rpt_sei001.aspx?u=" + ustring)
    End Sub

    Protected Sub ddl_74_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_74.SelectedIndexChanged
        If ddl_74.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 11
            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cmd_cancelarbachillerato_Click(sender As Object, e As EventArgs) Handles cmd_cancelarbachillerato.Click
        If ddl_75.SelectedIndex = 0 Then
            ddl_74.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_bachillerato_Click(sender As Object, e As EventArgs) Handles cmd_bachillerato.Click
        hf_popupo_mpe.Hide()
    End Sub

    'Protected Sub ib_closeok_Click(sender As Object, e As ImageClickEventArgs)
    '   Session.Clear()
    'Response.Redirect("~\contents\regpin.aspx")
    'End Sub

    Protected Sub ddl_nacionalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_nacionalidad.SelectedIndexChanged
        If ddl_nacionalidad.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 12

            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cmd_cancelarpais_Click(sender As Object, e As EventArgs) Handles cmd_cancelarpais.Click
        If ddl_paises.SelectedIndex = 0 Then
            ddl_nacionalidad.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_aceptar_Click(sender As Object, e As EventArgs) Handles cmd_aceptar.Click
        hf_popupo_mpe.Hide()
    End Sub




    Protected Sub ddl_etnias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_etnias.SelectedIndexChanged
        If ddl_etnias.SelectedValue = 2 Then
            mv_msgs.ActiveViewIndex = 13

            hf_popupo_mpe.Show()
            p_test.Update()
        End If
    End Sub

    Protected Sub cmd_aceptaretnia_Click(sender As Object, e As EventArgs) Handles cmd_aceptaretnia.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_cancelaretnia_Click(sender As Object, e As EventArgs) Handles cmd_cancelaretnia.Click
        If ddl_grupo_etnico.SelectedIndex = 0 Then
            ddl_etnias.SelectedIndex = 0
        End If
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub ddl_cronicas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cronicas.SelectedIndexChanged
        If ddl_cronicas.SelectedIndex = 4 Then
            tbx_otra.Visible = True
            lbl_otra.Visible = True
            tbx_otra.Focus()
        End If
    End Sub

    Protected Sub ddl_tratamiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_tratamiento.SelectedIndexChanged
        If ddl_tratamiento.SelectedIndex = 2 Then
            tbx_tratamiento.Visible = True
            lbl_tratamiento.Visible = True
            tbx_tratamiento.Focus()
        End If
    End Sub

    Protected Sub cmd_cancelarcronicos_Click(sender As Object, e As EventArgs) Handles cmd_cancelarcronicos.Click
        If ddl_cronicas.SelectedIndex = 0 Then
            ddl_39.SelectedIndex = 0
        End If
        ddl_39.SelectedIndex = 0
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub ddl_beca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_beca.SelectedIndexChanged
        If ddl_beca.SelectedIndex = 2 Then
            mv_msgs.ActiveViewIndex = 14

            hf_popupo_mpe.Show()
            p_test.Update()
            tbx_becas.Visible = False
            lbl_beca.Visible = False
        End If
    End Sub

    Protected Sub ddl_becas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_becas.SelectedIndexChanged
        If ddl_becas.SelectedIndex = 7 Then
            tbx_becas.Visible = True
            lbl_beca.Visible = True
            tbx_becas.Focus()
        End If
    End Sub

    Protected Sub cmd_cancelarbeca_Click(sender As Object, e As EventArgs) Handles cmd_cancelarbeca.Click
        If ddl_becas.SelectedIndex = 0 Then
            ddl_beca.SelectedIndex = 0
        End If
        ddl_beca.SelectedIndex = 0
        hf_popupo_mpe.Hide()

    End Sub

    Protected Sub ddl_apoyo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_apoyo.SelectedIndexChanged
        If ddl_apoyo.SelectedIndex = 2 Then
            mv_msgs.ActiveViewIndex = 15

            hf_popupo_mpe.Show()
            p_test.Update()
            tbx_apoyo.Visible = False
            lbl_apoyo.Visible = False
        End If
    End Sub

    Protected Sub ddl_apoyos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_apoyos.SelectedIndexChanged
        If ddl_apoyos.SelectedIndex = 4 Then
            tbx_apoyo.Visible = True
            lbl_apoyo.Visible = True
            tbx_apoyo.Focus()
        End If
    End Sub

    Protected Sub cmd_cancelarapoyo_Click(sender As Object, e As EventArgs) Handles cmd_cancelarapoyo.Click
        If ddl_apoyos.SelectedIndex = 0 Then
            ddl_apoyo.SelectedIndex = 0
        End If
        ddl_apoyo.SelectedIndex = 0
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub ddl_deporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_deporte.SelectedIndexChanged
        If ddl_deporte.SelectedIndex = 2 Then
            mv_msgs.ActiveViewIndex = 16
            llena_talleres()
            hf_popupo_mpe.Show()
            p_test.Update()
            lbl_deportes.Visible = False
            txt_deportes.Visible = False
        End If
    End Sub

    Protected Sub ddl_deportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_deportes.SelectedIndexChanged
        If ddl_deportes.SelectedIndex = 11 Then
            lbl_deportes.Visible = True
            txt_deportes.Visible = True
            txt_deportes.Focus()

        End If
    End Sub

    Protected Sub cmd_cancelardeporte_Click(sender As Object, e As EventArgs) Handles cmd_cancelardeporte.Click
        If ddl_deportes.SelectedIndex = 0 Then
            ddl_deporte.SelectedIndex = 0
        End If
        ddl_deporte.SelectedIndex = 0
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_becas_Click(sender As Object, e As EventArgs) Handles cmd_becas.Click
        hf_popupo_mpe.Hide()
    End Sub
    Protected Sub cmd_apoyo_Click(sender As Object, e As EventArgs) Handles cmd_apoyo.Click
        hf_popupo_mpe.Hide()
    End Sub

    Protected Sub cmd_deportes_Click(sender As Object, e As EventArgs) Handles cmd_deportes.Click
        hf_popupo_mpe.Hide()
    End Sub

End Class