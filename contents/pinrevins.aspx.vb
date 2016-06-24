Imports synpin_code
Imports print_docs
Imports downdocument
Imports dtciclos
Imports secure_tools
Imports imagework
Imports carreraCiclo
Imports System.IO
Imports System.Data

Partial Class contents_pinrevins
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Revision de inscripcion - SIAAA UTJ " + versiones()
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        nocache()
        backbutton()
        If Not IsPostBack Then

            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()

            mv_general.ActiveViewIndex = 2
            llena_carrera()
            llena_escuelas()
            llena_pais()
            llena_etnias()
            llena_motivoBeca()
            llena_apoyo()
            llena_cronicas()
            llena_deportivas()
            hf_cs.Value = "31/12/3999"
            'up_carreras.Update()
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

    Private Sub llena_pais()
        ddl_paises.DataSource = llenaPais()
        ddl_paises.DataValueField = "id"
        ddl_paises.DataTextField = "pais"
        ddl_paises.DataBind()
        Dim listpais As New ListItem
        listpais.Text = "Selecciona..."
        listpais.Value = "0"
        ddl_paises.Items.Insert(0, listpais)

    End Sub

    Private Sub llena_etnias()
        ddl_grupo_etnico.DataSource = llenaEtnia()
        ddl_grupo_etnico.DataValueField = "id"
        ddl_grupo_etnico.DataTextField = "grupo"
        ddl_grupo_etnico.DataBind()
        Dim etnial As New ListItem
        etnial.Text = "Selecciona..."
        etnial.Value = "0"
        ddl_grupo_etnico.Items.Insert(0, etnial)
    End Sub

    Private Sub llena_motivoBeca()
        ddl_becas.DataSource = llenaBecaBachi()
        ddl_becas.DataValueField = "id"
        ddl_becas.DataTextField = "motivo"
        ddl_becas.DataBind()
        Dim becal As New ListItem
        becal.Text = "Selecciona..."
        becal.Value = "0"
        ddl_becas.Items.Insert(0, becal)
    End Sub

    Private Sub llena_apoyo()
        ddl_apoyos.DataSource = llenaApoyoBecaPi()
        ddl_apoyos.DataValueField = "id"
        ddl_apoyos.DataTextField = "motivo"
        ddl_apoyos.DataBind()
        Dim apoyol As New ListItem
        apoyol.Text = "Selecciona..."
        apoyol.Value = "0"
        ddl_apoyos.Items.Insert(0, apoyol)
    End Sub

    Private Sub llena_cronicas()
        ddl_cronicas.DataSource = llenaCronica()
        ddl_cronicas.DataValueField = "id"
        ddl_cronicas.DataTextField = "tipo"
        ddl_cronicas.DataBind()
        Dim cronicast As New ListItem
        cronicast.Text = "Selecciona..."
        cronicast.Value = "0"
        ddl_cronicas.Items.Insert(0, cronicast)
    End Sub

    Private Sub llena_deportivas()
        ddl_deportes.DataSource = llenaTalleres()
        ddl_deportes.DataValueField = "id"
        ddl_deportes.DataTextField = "taller"
        ddl_deportes.DataBind()
        Dim tallerl As New ListItem
        tallerl.Text = "Selecciona..."
        tallerl.Value = "0"
        ddl_deportes.Items.Insert(0, tallerl)
    End Sub


    Protected Sub gv_poblacion_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_poblacion.RowCommand
        tbx_10.Text = dame_lugar(e.CommandArgument)
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
        'up_carreras.Update()
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

    Protected Sub cmd_cancelarcronicos_Click(sender As Object, e As EventArgs) Handles cmd_cancelarcronicos.Click
        If ddl_cronicas.SelectedIndex = 0 Then
            ddl_39.SelectedIndex = 0
        End If
        ddl_39.SelectedIndex = 0
        hf_popupo_mpe.Hide()
    End Sub

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
        'Try
        ' Dim siguiente_fecha As Date
        '
        '        Dim local_dias_noagenda As DataTable = dias_noagenda("CITA_ENTREVISTA_CONTROL_ESCOLAR", ddl_carreras.SelectedValue.ToString, pi_cicloregistro)
        '        If local_dias_noagenda.Rows.Count > 0 Then
        '        Dim fd As Integer
        '        For fd = 0 To local_dias_noagenda.Rows.Count - 1
        '        siguiente_fecha = CType(local_dias_noagenda.Rows(fd).Item(0).ToString, Date)
        '        If siguiente_fecha = e.Day.Date Then
        '        e.Cell.CssClass = local_dias_noagenda.Rows(fd).Item(2).ToString
        '        e.Day.IsSelectable = local_dias_noagenda.Rows(fd).Item(1).ToString
        '        Exit For
        '        Else
        '        e.Cell.CssClass = "dia_deshabilitado"
        '        e.Day.IsSelectable = False
        '        e.Cell.ToolTip = "Este día no puede agendar."
        '        End If
        '        Next
        '        Else
        '        e.Cell.CssClass = "dia_deshabilitado"
        '        e.Day.IsSelectable = False
        '        e.Cell.ToolTip = "Este día no puede agendar."
        '        End If
        '        Catch ex As Exception
        '        e.Cell.CssClass = "dia_deshabilitado"
        '        e.Day.IsSelectable = False
        '           e.Cell.ToolTip = "Este día no puede agendar."
        '        End Try
        ''''up_calendario.Update()
    End Sub

    Private Sub registerpostbacklinkbutton(ByVal buton As LinkButton)
        Dim ScriptManager As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        ScriptManager.RegisterPostBackControl(buton)
    End Sub

    Private Function mismacarrera(ByVal actual As String, ByVal guardada As String) As Boolean
        If actual = guardada Then
            mismacarrera = True
        Else
            mismacarrera = False
        End If
    End Function

    Protected Sub cmd_save_Click(sender As Object, e As EventArgs) Handles cmd_save.Click
        If mismacarrera(secureddl(ddl_carreras), get_carrera_by_id_pingreso(id.Value)) Then
            'Dim uanterior As String = ustring_pingreso(id.Value)
            'Dim unuevo As String = ustring("111")
        End If
        Session("idd") = ustring_pingreso(id.Value)
        'Dim idturno As String = CType(gv_noActivo.Rows(CInt(e.CommandArgument)).FindControl("idturno"), HiddenField).Value

        If securetext(tbx_1.Text) = "TESTSET" Then
            'Session("idd") = "1"
            ' salvapi("ARH", "1", "RODRIGO FRANCISCO PABLO", "PEREZ FERNANDEZ", "ROBLE DE LA BOMBOYA", "1", "1", "1", "2015", "05", "20",
            '         "Delegación de La Secretaria de Comercio y Fomento Industrial", "JUAN PEDRO JOSE FERNANDEZ MELENDEZ 35 INTERIOR 3453",
            '         "44950", "COLONIA DE LOS CISNES VERDES", "VERACRUZ DE LA LLAVE", "MICHOACAN DE LA VERDURA", "1990778899", "381990778899",
            '         "381990778899", "elpocaspuasmequitas@colegioverdevalle.com", "BADD110313HCMLNS09", "110", "205",
            '         "ESCUELA INTERESTATAL DE LA MORONGA CUADRADA NO. 33", "2009", "09", "2013", "03", "98.6", "1", "1", "1", "1", "1",
            '         "PUES ES QUE LA NETA NO VALE LA PENA ESTUDIAR MATERIAS QUE NUNCA VAMOS A UTILIZAR EN LA VIDA",
            '         "EL PROFE DECIA QUE 2 MAS 2 NO ERAN CUATRO SI NO 5 Y NOS DEMOSTRO ALGO QUE JAMAS LE ENTENDI Y DEJO DE GUSTARME", "1", "1", "1", "1", "1",
            '         "1", "1", "1", "1", "1", "1", "La carrera cumple con los requisitos, Por que el horario me permite hacer otras actividades",
            '         "Espectaculares, Familiares y amigos", "2015-4-30 10:00", "1", "ESPAÑOL Y MATEMATICAS CULINARIAS", "POR FALTA DE APROVECHAMIENTO",
            '         "PUES ES QUE SE ME PERDIO Y NO ME LO QUISIERON DAR DE NUEVO", "ME DUELE LA CARA DE SER TAN GUAPO", "1", "ATENCION PERSONALIZADA CON MI AMIGA",
            '         "1", "1", "2,4,6,8,10", "1", "KODAK DEL PACIFICO ENTERTAINMENT SYSTEM", "ME HAGO BUEY COMO PEDRO", "DE LAS 8 HASTA LAS 9",
            '         "GIRA SOBRE SU EJE DE 360 GRADOS NORESTE", "1", "EN LA TARDE", "1", "1", "1", "1",
            '         "INGENIERIA BIOMEDICA Y ALIMENTOS TECNOLOGICOS", "1", Session("idd"), "2015-05-20", "10:00", pi_cicloregistro)
        Else

            If uploadfile(fu_photo, ustring_pingreso(id.Value)) = True Then
                actualiza_foto(ustring_pingreso(id.Value), "..\docstock\usrdocs\images\" & ustring_pingreso(id.Value) & Right(fu_photo.FileName.ToString, 4))
                photocut(ustring_pingreso(id.Value))
            End If

            eliminaMediosUstring(ustring_pingreso(id.Value))
            eliminaRazonesUstring(ustring_pingreso(id.Value))

            actualizaPingreso(Session("idd"), secureddl(ddl_carreras), secureddl(ddl_turno), securetext(tbx_1.Text), securetext(tbx_2.Text), securetext(tbx_3.Text), secureddl(ddl_4), secureddl(ddl_5), secureddl(ddl_6), secureddl(ddl_7), secureddl(ddl_8),
                secureddl(ddl_9), securetext(tbx_10.Text), securetext(tbx_11.Text), securetext(tbx_12.Text), securetext(tbx_13.Text), securetext(tbx_14.Text), securetext(tbx_15.Text), securetext(tbx_16.Text), securetext(tbx_17.Text), securetext(tbx_18.Text),
                securetext(tbx_19.Text), securetext(tbx_20.Text), securetext(tbx_21.Text), securetext(tbx_22.Text), securetext(tbx_23.Text), secureddl(ddl_24), secureddl(ddl_25), secureddl(ddl_26), secureddl(ddl_27), securetext(tbx_28.Text),
                secureddl(ddl_29), secureddl(ddl_30), secureddl(ddl_74), secureddl(ddl_32), secureddl(ddl_33), securetext(tbx_34.Text), securetext(tbx_35.Text), secureddl(ddl_31), "0", "0",
                "0", secureddl(ddl_39), secureddl(ddl_40), secureddl(ddl_41), secureddl(ddl_42), secureddl(ddl_43), secureddl(ddl_44), secureddl(ddl_45), "", "",
                dia_hora_cita, securetext(tbx_51.Text), securetext(tbx_52.Text), securetext(tbx_53.Text), securetext(tbx_54.Text), "", "0", securetext(tbx_57.Text),
                secureddl(ddl_58), secureddl(ddl_59), securetext(tbx_60.Text), secureddl(ddl_61), securetext(tbx_62.Text), securetext(tbx_63.Text), securetext(tbx_64.Text), securetext(tbx_65.Text),
                secureddl(ddl_66), secureddl(ddl_67), secureddl(ddl_68), secureddl(ddl_69), secureddl(ddl_70), secureddl(ddl_71), securetext(tbx_72.Text), secureddl(ddl_75), Session("idd"),
                cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day, rbl_49.SelectedValue.ToString, pi_cicloregistro, id.Value, secureddl(ddl_nacionalidad),
                secureddl(ddl_paises), securetext(ddl_paises.SelectedItem.Text), secureddl(ddl_etnias), secureddl(ddl_grupo_etnico), securetext(ddl_grupo_etnico.SelectedItem.Text),
                secureddl(ddl_beca), secureddl(ddl_becas), securetext(ddl_becas.SelectedItem.Text), securetext(tbx_becas.Text), secureddl(ddl_apoyo), secureddl(ddl_apoyos),
                securetext(ddl_apoyos.SelectedItem.Text), securetext(tbx_apoyo.Text), secureddl(ddl_39), secureddl(ddl_cronicas), securetext(tbx_otra.Text), secureddl(ddl_tratamiento), securetext(tbx_tratamiento.Text),
                secureddl(ddl_deporte), secureddl(ddl_deportes), securetext(ddl_deportes.SelectedItem.Text), securetext(txt_deportes.Text))


            upPingresoEntrevista(ustring_pingreso(id.Value))


            guardar_multiseleccion(dl_razon, "pingreso_razones", Session("idd"))
            guardar_multiseleccion(dl_medios, "pingreso_medios", Session("idd"))

            del_citadocumentos(ustring_pingreso(id.Value))
            If existe_citadocs(ustring_pingreso(id.Value)) = False Then
                ins_docsxdia(hf_ciclo.Value, dia_de_cita(hf_ciclo.Value), ustring_pingreso(id.Value))
            End If

            'ccei001(ustring_pingreso(id.Value))
            ''EL CORREO SE ENVÍA POR MEDIO DEL BOTON ENVIAR CORREO
            'Dim dttemp As DataTable = senderemail("1")
            'send_mail(getemail(ustring_pingreso(id.Value)), ustring_pingreso(id.Value) & ".pdf", dttemp.Rows(0).Item(0).ToString, dttemp.Rows(0).Item(1).ToString)

        End If
        cacoensulu(tabla_consulta_llenado(id.Value, hf_c.Value))
        registerpostbacklinkbutton(lb_ficha)
        registerpostbacklinkbutton(lb_carta)
        registerpostbacklinkbutton(lb_comprobante)
        registerpostbacklinkbutton(lb_sendmail)
        hf_popupok_mpe.Show()
        up_pinrevis.Update()
    End Sub

    Private Sub guardar_multiseleccion(ByVal dt As DataList, tabla As String, idd As String)
        Dim k As Integer = 0
        For k = 0 To dt.Items.Count - 1
            Dim cbx As Boolean = CType(dt.Items(k).FindControl("cbx_select"), CheckBox).Checked
            If cbx = True Then
                Dim id_catalog As String = CType(dt.Items(k).FindControl("hf_id"), HiddenField).Value
                salvaseleccionados(id_catalog, idd, tabla, pi_cicloregistro, ddl_turno.SelectedValue.ToString)
            End If
        Next
    End Sub


    Private Function dia_hora_cita() As String
        Return cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day & " " & rbl_49.SelectedValue.ToString
    End Function

    'Protected Sub cmd_cancelar_Click(sender As Object, e As EventArgs) Handles cmd_cancelar.Click
    '    'datosreportei001("2015B00000498")
    '    Response.Redirect("http://siaaa.utj.edu.mx/siaaa/")
    'End Sub

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

    Protected Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        mv_general.ActiveViewIndex = 0

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

    Protected Sub ib_closeok_Click(sender As Object, e As ImageClickEventArgs)
        Session.Clear()
        Response.Redirect("~\contents\regpin.aspx")
    End Sub

    Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
        gv_resultados.DataSource = tabla_resultados_busqueda(securetext(tbx_busqueda.Text), hf_c.Value)
        gv_resultados.DataBind()
        up_pinrevis.Update()
    End Sub



    Private Sub cacoensulu(ByVal dt As DataTable)
        ddl_carreras.SelectedIndex = ddl_carreras.Items.IndexOf(ddl_carreras.Items.FindByValue(dt.Rows(0).Item(3).ToString)) 'Carrera
        llena_turno(dt.Rows(0).Item(3).ToString, dt.Rows(0).Item(3).ToString) 'turno
        ddl_turno.SelectedIndex = ddl_turno.Items.IndexOf(ddl_turno.Items.FindByValue(dt.Rows(0).Item(4).ToString))
        tbx_1.Text = dt.Rows(0).Item(5).ToString 'nombre
        tbx_2.Text = dt.Rows(0).Item(6).ToString 'apellido paterno
        tbx_3.Text = dt.Rows(0).Item(7).ToString 'apellido materno
        ddl_4.SelectedIndex = ddl_4.Items.IndexOf(ddl_4.Items.FindByValue(dt.Rows(0).Item(8).ToString)) 'sexo
        ddl_5.SelectedIndex = ddl_5.Items.IndexOf(ddl_5.Items.FindByValue(dt.Rows(0).Item(9).ToString)) 'tipo de sangre
        ddl_6.SelectedIndex = ddl_6.Items.IndexOf(ddl_6.Items.FindByValue(dt.Rows(0).Item(10).ToString)) 'estado civil
        ddl_7.SelectedIndex = ddl_7.Items.IndexOf(ddl_7.Items.FindByText(dt.Rows(0).Item(11).ToString)) 'año nacimiento
        ddl_8.SelectedIndex = ddl_8.Items.IndexOf(ddl_8.Items.FindByValue(dt.Rows(0).Item(12).ToString)) 'mes nacimiento
        ddl_9.SelectedIndex = ddl_9.Items.IndexOf(ddl_9.Items.FindByText(dt.Rows(0).Item(13).ToString)) 'dia nacimiento
        tbx_10.Text = dt.Rows(0).Item(14).ToString 'lugar de nacimiento
        tbx_11.Text = dt.Rows(0).Item(15).ToString 'direccion actual
        tbx_12.Text = dt.Rows(0).Item(16).ToString 'codigo postal
        tbx_13.Text = dt.Rows(0).Item(17).ToString 'colonia
        tbx_14.Text = dt.Rows(0).Item(18).ToString 'ciudad
        tbx_15.Text = dt.Rows(0).Item(19).ToString 'estado
        tbx_16.Text = dt.Rows(0).Item(20).ToString 'telefono fijo
        tbx_17.Text = dt.Rows(0).Item(21).ToString 'telefono movil
        tbx_18.Text = dt.Rows(0).Item(22).ToString 'otro telefono
        tbx_19.Text = dt.Rows(0).Item(23).ToString 'email
        tbx_20.Text = dt.Rows(0).Item(24).ToString 'curp
        tbx_21.Text = dt.Rows(0).Item(25).ToString 'peso
        tbx_22.Text = dt.Rows(0).Item(26).ToString 'estatura
        tbx_23.Text = dt.Rows(0).Item(27).ToString 'bachillerato de procedencia
        ddl_24.SelectedIndex = ddl_24.Items.IndexOf(ddl_24.Items.FindByText(dt.Rows(0).Item(28).ToString)) 'ingreso año
        ddl_25.SelectedIndex = ddl_25.Items.IndexOf(ddl_25.Items.FindByValue(dt.Rows(0).Item(29).ToString)) 'ingreso mes
        ddl_26.SelectedIndex = ddl_26.Items.IndexOf(ddl_26.Items.FindByText(dt.Rows(0).Item(30).ToString)) 'egreso año
        ddl_27.SelectedIndex = ddl_27.Items.IndexOf(ddl_27.Items.FindByValue(dt.Rows(0).Item(31).ToString)) 'egreso mes
        tbx_28.Text = dt.Rows(0).Item(32).ToString 'promedio
        ddl_29.SelectedIndex = ddl_29.Items.IndexOf(ddl_29.Items.FindByValue(dt.Rows(0).Item(33).ToString)) 'tipo de escuela
        ddl_30.SelectedIndex = ddl_30.Items.IndexOf(ddl_30.Items.FindByValue(dt.Rows(0).Item(34).ToString)) 'tipo de bachillerato
        ddl_74.SelectedIndex = ddl_74.Items.IndexOf(ddl_74.Items.FindByValue(dt.Rows(0).Item(35).ToString)) 'Estudiaste el bachillerato en dos o mas inst.
        ddl_75.SelectedIndex = ddl_75.Items.IndexOf(ddl_75.Items.FindByValue(dt.Rows(0).Item(76).ToString)) 'Revalido materias
        ddl_32.SelectedIndex = ddl_32.Items.IndexOf(ddl_32.Items.FindByValue(dt.Rows(0).Item(36).ToString)) 'tuvo extras
        tbx_51.Text = dt.Rows(0).Item(54).ToString 'cuantos
        tbx_52.Text = dt.Rows(0).Item(55).ToString 'materia
        tbx_53.Text = dt.Rows(0).Item(56).ToString 'motivos
        ddl_33.SelectedIndex = ddl_33.Items.IndexOf(ddl_33.Items.FindByValue(dt.Rows(0).Item(37).ToString)) 'cuenta con certificado
        tbx_54.Text = dt.Rows(0).Item(57).ToString 'motivo por que el que no tiene certificado
        tbx_34.Text = dt.Rows(0).Item(38).ToString 'materias si gustaron
        tbx_35.Text = dt.Rows(0).Item(39).ToString 'materias no gustaron
        ddl_31.SelectedIndex = ddl_31.Items.IndexOf(ddl_31.Items.FindByValue(dt.Rows(0).Item(40).ToString)) 'especialidad
        'ddl_36.SelectedIndex = ddl_36.Items.IndexOf(ddl_36.Items.FindByValue(dt.Rows(0).Item(41).ToString)) 'diabetico
        'ddl_37.SelectedIndex = ddl_37.Items.IndexOf(ddl_37.Items.FindByValue(dt.Rows(0).Item(42).ToString)) 'hipertenso
        'ddl_38.SelectedIndex = ddl_38.Items.IndexOf(ddl_38.Items.FindByValue(dt.Rows(0).Item(43).ToString)) 'cardiaco
        'ddl_39.SelectedIndex = ddl_39.Items.IndexOf(ddl_39.Items.FindByValue(dt.Rows(0).Item(44).ToString)) 'padecimiento cronico
        'tbx_55.Text = dt.Rows(0).Item(58).ToString 'tipo de enfermedad
        'ddl_56.SelectedIndex = ddl_56.Items.IndexOf(ddl_56.Items.FindByValue(dt.Rows(0).Item(59).ToString)) 'recibes tratamiento
        ddl_40.SelectedIndex = ddl_40.Items.IndexOf(ddl_40.Items.FindByValue(dt.Rows(0).Item(45).ToString)) 'atencion psicologica
        tbx_57.Text = dt.Rows(0).Item(60).ToString 'tipo de atencion
        ddl_58.SelectedIndex = ddl_58.Items.IndexOf(ddl_58.Items.FindByValue(dt.Rows(0).Item(61).ToString)) 'hace cuanto tiempo
        ddl_41.SelectedIndex = ddl_41.Items.IndexOf(ddl_41.Items.FindByValue(dt.Rows(0).Item(46).ToString)) 'tiene hijos
        ddl_59.SelectedIndex = ddl_59.Items.IndexOf(ddl_59.Items.FindByValue(dt.Rows(0).Item(62).ToString)) 'cuantos hijos son
        tbx_60.Text = dt.Rows(0).Item(63).ToString 'edades
        ddl_42.SelectedIndex = ddl_42.Items.IndexOf(ddl_42.Items.FindByValue(dt.Rows(0).Item(47).ToString)) 'vive fuera de ZMG
        ddl_61.SelectedIndex = ddl_61.Items.IndexOf(ddl_61.Items.FindByValue(dt.Rows(0).Item(64).ToString)) 'tipo de domicilio
        ddl_43.SelectedIndex = ddl_43.Items.IndexOf(ddl_43.Items.FindByValue(dt.Rows(0).Item(48).ToString)) 'trabaja actualmente
        tbx_62.Text = dt.Rows(0).Item(65).ToString 'en que empresa laboras
        tbx_63.Text = dt.Rows(0).Item(66).ToString 'funciones en la empresa
        tbx_64.Text = dt.Rows(0).Item(67).ToString 'horario
        tbx_65.Text = dt.Rows(0).Item(68).ToString 'giro de la empresa
        ddl_66.SelectedIndex = ddl_66.Items.IndexOf(ddl_66.Items.FindByValue(dt.Rows(0).Item(69).ToString)) 'rolas turno
        ddl_67.SelectedIndex = ddl_67.Items.IndexOf(ddl_67.Items.FindByValue(dt.Rows(0).Item(70).ToString)) 'horario interfiere
        ddl_44.SelectedIndex = ddl_44.Items.IndexOf(ddl_44.Items.FindByValue(dt.Rows(0).Item(49).ToString)) 'busca empleo
        ddl_45.SelectedIndex = ddl_45.Items.IndexOf(ddl_45.Items.FindByValue(dt.Rows(0).Item(50).ToString)) 'tramites a otra universidad
        ddl_68.SelectedIndex = ddl_68.Items.IndexOf(ddl_68.Items.FindByValue(dt.Rows(0).Item(71).ToString)) 'en que universidad
        ddl_69.SelectedIndex = ddl_69.Items.IndexOf(ddl_69.Items.FindByValue(dt.Rows(0).Item(72).ToString)) 'en que periodo
        ddl_70.SelectedIndex = ddl_70.Items.IndexOf(ddl_70.Items.FindByValue(dt.Rows(0).Item(73).ToString)) 'despues del tramite
        ddl_71.SelectedIndex = ddl_71.Items.IndexOf(ddl_71.Items.FindByValue(dt.Rows(0).Item(74).ToString)) 'especialidad carrera
        tbx_72.Text = dt.Rows(0).Item(75).ToString 'carrera elegida
        'txtRazones.Text = dt.Rows(0).Item(51).ToString 'motivos de inscripcion
        'txtEnteraste.Text = dt.Rows(0).Item(52).ToString 'medios por los que te enteraste
        'txtCita.Text = dt.Rows(0).Item(53).ToString 'cita para entrevista
        tbx_fechavalid.Text = Format(CDate(dt.Rows(0).Item(77).ToString), "dd/MM/yyyy")
        cal_48.SelectedDate = Format(CDate(dt.Rows(0).Item(77).ToString), "yyyy-MM-dd")
        cal_48.VisibleDate = Format(CDate(dt.Rows(0).Item(77).ToString), "yyyy-MM-dd")
        rbl_49.DataSource = horas_noagendaLoad(cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day, pi_cicloregistro, ddl_carreras.SelectedValue.ToString, dt.Rows(0).Item(0).ToString)
        rbl_49.DataTextField = "hora"
        rbl_49.DataValueField = "hora"
        rbl_49.DataBind()
        rbl_49.SelectedIndex = rbl_49.Items.IndexOf(rbl_49.Items.FindByValue(dt.Rows(0).Item(78).ToString))
        id.Value = dt.Rows(0).Item(0).ToString 'id
        hf_ciclo.Value = dt.Rows(0).Item(87).ToString 'ciclo
        img_user.ImageUrl = dt.Rows(0).Item(85).ToString 'imagen

        If dt.Rows(0).Item(85).ToString = "..\docstock\usrdocs\images\defaultimg.jpg" Then
            lb_ficha.Enabled = False
        Else
            lb_ficha.Enabled = True

        End If
        IIf(dt.Rows(0).Item(88).ToString = 1, lbl_msg.Visible = True, lbl_msg.Visible = False)
        IIf(dt.Rows(0).Item(88).ToString = 1, lbl_msg.Text = "*El aspirante ya cuenta con una cita para entregar documentos el " & dt.Rows(0).Item(87).ToString & ", si continúa se reemplazará por una nueva.", lbl_msg.Text = "")
        up_calendario.Update()
        ddl_nacionalidad.SelectedIndex = ddl_nacionalidad.Items.IndexOf(ddl_nacionalidad.Items.FindByValue(dt.Rows(0).Item(90).ToString)) 'nacionalidad
        ddl_paises.SelectedIndex = ddl_paises.Items.IndexOf(ddl_paises.Items.FindByValue(dt.Rows(0).Item(91).ToString)) 'pais
        ddl_etnias.SelectedIndex = ddl_etnias.Items.IndexOf(ddl_etnias.Items.FindByValue(dt.Rows(0).Item(92).ToString)) 'etnia?
        ddl_grupo_etnico.SelectedIndex = ddl_grupo_etnico.Items.IndexOf(ddl_grupo_etnico.Items.FindByValue(dt.Rows(0).Item(93).ToString)) 'grupo etnico
        ddl_beca.SelectedIndex = ddl_beca.Items.IndexOf(ddl_beca.Items.FindByValue(dt.Rows(0).Item(94).ToString)) 'tiene beca?
        ddl_becas.SelectedIndex = ddl_becas.Items.IndexOf(ddl_becas.Items.FindByValue(dt.Rows(0).Item(95).ToString)) 'tiene beca?
        tbx_becas.Text = dt.Rows(0).Item(96).ToString 'otra razon
        ddl_apoyo.SelectedIndex = ddl_apoyo.Items.IndexOf(ddl_apoyo.Items.FindByValue(dt.Rows(0).Item(97).ToString)) 'necesitas beca?
        ddl_apoyos.SelectedIndex = ddl_apoyos.Items.IndexOf(ddl_apoyos.Items.FindByValue(dt.Rows(0).Item(98).ToString)) 'motivo?
        tbx_apoyo.Text = dt.Rows(0).Item(99).ToString 'otro motivo
        ddl_39.SelectedIndex = ddl_39.Items.IndexOf(ddl_39.Items.FindByValue(dt.Rows(0).Item(100).ToString)) 'padecimiento cronico
        ddl_cronicas.SelectedIndex = ddl_cronicas.Items.IndexOf(ddl_cronicas.Items.FindByValue(dt.Rows(0).Item(101).ToString)) 'tipo
        tbx_otra.Text = dt.Rows(0).Item(102).ToString 'otra enfermedad
        ddl_tratamiento.SelectedIndex = ddl_tratamiento.Items.IndexOf(ddl_tratamiento.Items.FindByValue(dt.Rows(0).Item(103).ToString)) 'recibe tratamiento
        tbx_tratamiento.Text = dt.Rows(0).Item(104).ToString 'tipo de tratamiento
        ddl_deporte.SelectedIndex = ddl_deporte.Items.IndexOf(ddl_deporte.Items.FindByValue(dt.Rows(0).Item(105).ToString)) 'practica actividad deportiva
        ddl_deportes.SelectedIndex = ddl_deportes.Items.IndexOf(ddl_deportes.Items.FindByValue(dt.Rows(0).Item(106).ToString)) 'que deporte practica
        txt_deportes.Text = dt.Rows(0).Item(107).ToString 'especificar cual
    End Sub






    Private Function uploadfile(ByVal enviador As FileUpload, ByVal registro As String) As Boolean
        If enviador.HasFile Then
            'Try
            If enviador.PostedFile.ContentType = "image/jpeg" Or enviador.PostedFile.ContentType = "image/png" Or enviador.PostedFile.ContentType = "image/gif" Or enviador.PostedFile.ContentType = "image/jpg" Then
                If enviador.PostedFile.ContentLength < 10096000 Then '***mide en kb el limite son 10 mb, pero se solicita que sea 1.5
                    Dim nombre_archivo As String = registro & Right(enviador.FileName, 4)
                    Dim path As String = Server.MapPath("..\docstock\usrdocs\images\") & nombre_archivo
                    Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
                    If (file.Exists) Then
                        file.Delete()
                    End If
                    enviador.SaveAs(path)
                    uploadfile = True
                Else
                    uploadfile = False
                End If
            Else
                uploadfile = False
            End If
        Else
            uploadfile = False
        End If
    End Function

    Protected Sub lb_ficha_Click(sender As Object, e As EventArgs) Handles lb_ficha.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''If img_user.ImageUrl Is Nothing Then
        '' mod_sin_foto.Show()
        '' Else
        ''lb_carta.Text = img_user.ImageUrl.ToString
        'del_citadocumentos(ustring_pingreso(id.Value))
        'ins_docsxdia(hf_ciclo.Value, dia_de_cita(hf_ciclo.Value), ustring_pingreso(id.Value))
        'sei003(ustring_pingreso(id.Value), dia_de_cita(hf_ciclo.Value), fecha_d_examen(hf_ciclo.Value))
        'Try
        '    descarga("se-i003", ustring_pingreso(id.Value), ".pdf")
        'Catch ex As Exception

        'End Try
        'End if
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Crystal reports
        Dim ustring As String = ustring_pingreso(id.Value)
        Dim dia_cita As String = dia_de_cita(hf_ciclo.Value)
        Dim fecha_examen As String = fecha_d_examen(hf_ciclo.Value)

        Response.Redirect("~/contents/crv_pi/rpt_sei003.aspx?u=" + ustring + "&c=" + dia_cita + "&f=" + fecha_examen)




    End Sub

    Protected Sub lb_carta_Click(sender As Object, e As EventArgs) Handles lb_carta.Click
        'sei004(sender.CommandArgument.ToString)
        'Try
        '    descarga("SE-I004", sender.CommandArgument.ToString, ".pdf")
        'Catch ex As Exception

        'End Try

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Crystal reports
        Dim ustring As String = ustring_pingreso(id.Value)

        Response.Redirect("~/contents/crv_pi/rpt_sei004.aspx?u=" + ustring)

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_ficha)
            current.RegisterPostBackControl(cmd_save)
            current.RegisterPostBackControl(lb_carta)
            current.RegisterPostBackControl(lb_comprobante)
            current.RegisterPostBackControl(lb_sendmail)
        End If
        Try
            cacoensulu(tabla_consulta_llenado(sender.CommandArgument.ToString, hf_c.Value))
            dl_medios.DataSource = muestraMediosUstring(ustring_pingreso(id.Value))
            dl_medios.DataBind()
            dl_razon.DataSource = muestraRazonesUstring(ustring_pingreso(id.Value))
            dl_razon.DataBind()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Dim upi As String = ustring_pingreso(sender.CommandArgument.ToString)
        lb_carta.CommandArgument = upi
        lb_comprobante.CommandArgument = upi
        lb_sendmail.CommandArgument = upi
        mv_general.ActiveViewIndex = 1
    End Sub

    Protected Sub lb_nacionalidad_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 12
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_etnia_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 13
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_dosbachi_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 11
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_extra_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 3
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_certi_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 4
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_becas_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 14
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_apoyo_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 15
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_cronicas_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 5
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_psico_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 6
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_hijos_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 7
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_zmgout_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 8
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_trabaja_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 9
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_otrauni_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 10
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub lb_deporte_Click(sender As Object, e As EventArgs)
        mv_msgs.ActiveViewIndex = 16
        hf_popupo_mpe.Show()
        p_test.Update()
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        mv_general.ActiveViewIndex = 0

    End Sub
    Protected Sub lb_comprobante_Click(sender As Object, e As EventArgs) Handles lb_comprobante.Click
        'Try
        '    descarga("cce-i001", sender.CommandArgument.ToString, ".pdf")
        'Catch ex As Exception
        '    'ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "diHola();", True)
        'End Try

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Crystal reports
        Dim ustring As String = ustring_pingreso(id.Value)

        Response.Redirect("~/contents/crv_pi/rpt_sei001.aspx?u=" + ustring)
    End Sub

    Protected Sub ib_delete_Click(sender As Object, e As ImageClickEventArgs)
        mod_elimina.Show()
        hf_id.Value = sender.CommandArgument.ToString
    End Sub
    Protected Sub btn_continuar_Click(sender As Object, e As EventArgs)
        eliminaRegistro(hf_id.Value)
        gv_resultados.DataSource = tabla_resultados_busqueda(tbx_busqueda.Text, hf_c.Value)
        gv_resultados.DataBind()
        mv_general.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_sendmail_Click(sender As Object, e As EventArgs) Handles lb_sendmail.Click
        Dim dttemp As DataTable = senderemail("1")
        send_mail(getemail(ustring_pingreso(id.Value)), ustring_pingreso(id.Value) & ".pdf", dttemp.Rows(0).Item(0).ToString, dttemp.Rows(0).Item(1).ToString)
    End Sub
    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)

        mv_general.ActiveViewIndex = 0
        hf_c.Value = sender.commandArgument.ToString

    End Sub
    Protected Sub ib_regresar_Click(sender As Object, e As ImageClickEventArgs)

        mv_general.ActiveViewIndex = 2
        gv_resultados.DataSource = Nothing
        gv_resultados.DataBind()
        tbx_busqueda.Text = ""

    End Sub
End Class