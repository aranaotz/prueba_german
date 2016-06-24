Imports synpin_code
Imports print_docs
Imports downdocument
Imports dtciclos
Imports secure_tools
Imports menumount
Imports carreraCiclo
Imports System.IO
Imports System.Data

Partial Class contents_career_interview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Entrevista - SIAAA UTJ " + versiones()
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        nocache()
        backbutton()
        If Not IsPostBack Then
            mv_general.ActiveViewIndex = 4
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            llena_carrera()
            llena_escuelas()
            llena_pais()
            llena_etnias()
            llena_motivoBeca()
            llena_apoyo()
            llena_cronicas()
            llena_deportivas()
            'up_carreras.Update()
            Dim dtcampos As DataTable = campos_de_tabla(Session("gcu"))
            hf_nombre.Value = gname(Session("gcu"), gettable(Session("gcu")), dtcampos.Rows(0).Item(2).ToString, dtcampos.Rows(0).Item(1).ToString) '*****se va a necesitar cuando se cambie la master...***********************************************
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
        ' up_calendario.Update()
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

    'Protected Sub cal_48_SelectionChanged(sender As Object, e As EventArgs) Handles cal_48.SelectionChanged
    '    rbl_49.DataSource = horas_noagenda(cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day, pi_cicloregistro, ddl_carreras.SelectedValue.ToString)
    '    rbl_49.DataTextField = "hora"
    '    rbl_49.DataValueField = "hora"
    '    rbl_49.DataBind()
    '    up_calendario.Update()
    'End Sub

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

    'Protected Sub cal_day_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles cal_48.DayRender
    '    Try
    '        Dim siguiente_fecha As Date

    '        Dim local_dias_noagenda As DataTable = dias_noagenda("CITA_ENTREVISTA_CONTROL_ESCOLAR", ddl_carreras.SelectedValue.ToString, pi_cicloregistro)
    '        If local_dias_noagenda.Rows.Count > 0 Then
    '            Dim fd As Integer
    '            For fd = 0 To local_dias_noagenda.Rows.Count - 1
    '                siguiente_fecha = CType(local_dias_noagenda.Rows(fd).Item(0).ToString, Date)
    '                If siguiente_fecha = e.Day.Date Then
    '                    e.Cell.CssClass = local_dias_noagenda.Rows(fd).Item(2).ToString
    '                    e.Day.IsSelectable = local_dias_noagenda.Rows(fd).Item(1).ToString
    '                    Exit For
    '                Else
    '                    e.Cell.CssClass = "dia_deshabilitado"
    '                    e.Day.IsSelectable = False
    '                    e.Cell.ToolTip = "Este día no puede agendar."
    '                End If
    '            Next
    '        Else
    '            e.Cell.CssClass = "dia_deshabilitado"
    '            e.Day.IsSelectable = False
    '            e.Cell.ToolTip = "Este día no puede agendar."
    '        End If
    '    Catch ex As Exception
    '        e.Cell.CssClass = "dia_deshabilitado"
    '        e.Day.IsSelectable = False
    '        e.Cell.ToolTip = "Este día no puede agendar."
    '    End Try
    '    'up_calendario.Update()
    'End Sub

    Private Sub registerpostbacklinkbutton(ByVal buton As LinkButton)
        Dim ScriptManager As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        ScriptManager.RegisterPostBackControl(buton)
    End Sub

    Protected Sub cmd_save_Click(sender As Object, e As EventArgs) Handles cmd_save.Click

        For cat1 = 0 To gv_cat1.Rows.Count - 1
            Dim id As String = CType(gv_cat1.Rows(cat1).FindControl("hf_id"), HiddenField).Value
            Dim seleccionado As Boolean = CType(gv_cat1.Rows(cat1).FindControl("cbx_seleccionado"), CheckBox).Checked
            upEntrevista(id, seleccionado)
        Next

        For cat2 = 0 To gv_cat2.Rows.Count - 1
            Dim id As String = CType(gv_cat2.Rows(cat2).FindControl("hf_id"), HiddenField).Value
            Dim seleccionado As Boolean = CType(gv_cat2.Rows(cat2).FindControl("cbx_seleccionado"), CheckBox).Checked
            upEntrevista(id, seleccionado)
        Next

        For cat3 = 0 To gv_cat3.Rows.Count - 1
            Dim id As String = CType(gv_cat3.Rows(cat3).FindControl("hf_id"), HiddenField).Value
            Dim seleccionado As Boolean = CType(gv_cat3.Rows(cat3).FindControl("cbx_seleccionado"), CheckBox).Checked
            upEntrevista(id, seleccionado)
        Next

        upObservaciones(securetext(tbx_observaciones.Text), hf_nombre.Value, ustring_pingreso(id.Value))
        'upPingresoEntrevista(ustring_pingreso(id.Value))
        mv_general.ActiveViewIndex = 3
        cmd_save.Enabled = False
    End Sub




    'Private Function dia_hora_cita() As String
    '    Return cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day & " " & rbl_49.SelectedValue.ToString
    'End Function

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
        gv_resultados.DataSource = tabla_resultados_busqueda(securetext(tbx_busqueda.Text), actualcycle(Application("str")))
        gv_resultados.DataBind()


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
        'cal_48.SelectedDate = Format(CDate(dt.Rows(0).Item(77).ToString), "yyyy-MM-dd")
        'cal_48.VisibleDate = Format(CDate(dt.Rows(0).Item(77).ToString), "yyyy-MM-dd")
        'rbl_49.DataSource = horas_noagendaLoad(cal_48.SelectedDate.Year & "-" & cal_48.SelectedDate.Month & "-" & cal_48.SelectedDate.Day, pi_cicloregistro, ddl_carreras.SelectedValue.ToString, dt.Rows(0).Item(0).ToString)
        'rbl_49.DataTextField = "hora"
        'rbl_49.DataValueField = "hora"
        'rbl_49.DataBind()
        'rbl_49.SelectedIndex = rbl_49.Items.IndexOf(rbl_49.Items.FindByValue(dt.Rows(0).Item(78).ToString))
        ID.Value = dt.Rows(0).Item(0).ToString 'id
        hf_ciclo.Value = dt.Rows(0).Item(87).ToString 'ciclo
        img_user.ImageUrl = dt.Rows(0).Item(85).ToString 'imagen
        IIf(dt.Rows(0).Item(88).ToString = 1, lbl_msg.Visible = True, lbl_msg.Visible = False)
        IIf(dt.Rows(0).Item(88).ToString = 1, lbl_msg.Text = "*El aspirante ya cuenta con una cita para entregar documentos el " & dt.Rows(0).Item(87).ToString & ", si continúa se reemplazará por una nueva.", lbl_msg.Text = "")
        'up_calendario.Update()
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

    'Protected Sub lb_ficha_Click(sender As Object, e As EventArgs) Handles lb_ficha.Click
    '    del_citadocumentos(ustring_pingreso(ID.Value))
    '    ins_docsxdia(hf_ciclo.Value, dia_de_cita(hf_ciclo.Value), ustring_pingreso(ID.Value))
    '    sei003(ustring_pingreso(ID.Value), dia_de_cita(hf_ciclo.Value), fecha_d_examen(hf_ciclo.Value))
    '    Try
    '        descarga("se-i003", ustring_pingreso(ID.Value), ".pdf")
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Protected Sub lb_carta_Click(sender As Object, e As EventArgs) Handles lb_carta.Click
    '    sei004(sender.CommandArgument.ToString)
    '    Try
    '        descarga("SE-I004", sender.CommandArgument.ToString, ".pdf")
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub observaciones(ByVal dt As DataTable)
        tbx_observaciones.Text = dt.Rows(0).Item(0).ToString
        'tbx_entrevisto.Text = dt.Rows(0).Item(1).ToString
    End Sub

    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)
        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            'current.RegisterPostBackControl(lb_ficha)
            current.RegisterPostBackControl(cmd_save)
            'current.RegisterPostBackControl(lb_carta)
        End If
        Try
            cacoensulu(tabla_consulta_llenado(sender.CommandArgument.ToString, hf_ciclo.Value.ToString))
            insertaEntrevista(ustring_pingreso(id.Value))
            observaciones(muestraObservaciones(ustring_pingreso(id.Value)))
            muestraObservaciones(ustring_pingreso(id.Value))
            'dl_medios.DataSource = muestraMediosUstring(ustring_pingreso(id.Value))
            'dl_medios.DataBind()
            'dl_razon.DataSource = muestraRazonesUstring(ustring_pingreso(id.Value))
            'dl_razon.DataBind()
            'MsgBox(ustring_pingreso(id.Value))
            gv_cat1.DataSource = muestraCat1(ustring_pingreso(id.Value))
            gv_cat1.DataBind()
            gv_cat2.DataSource = muestraCat2(ustring_pingreso(id.Value))
            gv_cat2.DataBind()
            gv_cat3.DataSource = muestraCat3(ustring_pingreso(id.Value))
            gv_cat3.DataBind()
            lbl_entrevisto.Text = entrevistador(ustring_pingreso(id.Value))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'lb_carta.CommandArgument = ustring_pingreso(sender.CommandArgument.ToString)
        mv_general.ActiveViewIndex = 2
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

  

    Protected Sub lb_siguiente_Click(sender As Object, e As EventArgs) Handles lb_siguiente.Click
        mv_general.ActiveViewIndex = 1

    End Sub

    Protected Sub im_back_Click(sender As Object, e As ImageClickEventArgs) Handles im_back.Click
        mv_general.ActiveViewIndex = 0
    End Sub

    Protected Sub ib_vuelve_Click(sender As Object, e As ImageClickEventArgs)
        mv_general.ActiveViewIndex = 2
    End Sub

    Protected Sub lb_listado_Click(sender As Object, e As EventArgs)
        mv_general.ActiveViewIndex = 0
    End Sub
    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        mv_general.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        mv_general.ActiveViewIndex = 0
        hf_ciclo.Value = sender.commandArgument.ToString
    End Sub
    Protected Sub ib_regresar_Click(sender As Object, e As ImageClickEventArgs)
        mv_general.ActiveViewIndex = 4
        gv_resultados.DataSource = Nothing
        gv_resultados.DataBind()
        tbx_busqueda.Text = ""
    End Sub
End Class
