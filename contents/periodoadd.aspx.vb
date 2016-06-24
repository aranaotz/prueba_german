Imports carreraCiclo
Imports synpin_code
Imports secure_tools

Partial Class contents_periodoadd
    Inherits System.Web.UI.Page
    Protected Sub gv_periodos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gv_periodos.PageIndexChanging
        gv_periodos.PageIndex = e.NewPageIndex
        'gv_periodos.DataSource = carga_periodos()
        'gv_periodos.DataBind()
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Periodos - SIAAA UTJ " + versiones()
        If Not IsPostBack Then
            gv_periodos.DataSource = llenaCiclo()
            gv_periodos.DataBind()
            mv_periodoadd.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        llena_periodo_pi(securetext(txtCiclo.Text), securetext(txtInicio.Text), securetext(txtFin.Text))
        'llena_periodo(securetext(txtCiclo.Text), securetext(txtInicio.Text), securetext(txtFin.Text))
        txtCiclo.Text = ""
        txtInicio.Text = ""
        txtFin.Text = ""
        gv_periodos.DataSource = llenaCiclo()
        gv_periodos.DataBind()
        'gv_periodos.DataSource = carga_periodos()
        'gv_periodos.DataBind()
    End Sub

    'Protected Sub contents_periodoadd_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        gv_periodos.DataSource = llenaCiclo()
    '        gv_periodos.DataBind()
    '        mv_periodoadd.ActiveViewIndex = 0
    '    End If
    'End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        lbl_ciclo.Text = sender.commandArgument.ToString
        lbl_ciclo2.Text = sender.commandArgument.ToString
        dv_ciclos.DataSource = detalleCiclo(sender.commandArgument.ToString)
        dv_ciclos.DataBind()
        mv_periodoadd.ActiveViewIndex = 1
    End Sub



    'Protected Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
    '    Dim inicio, fin, entrevista, examen, docini, docfin, ciclo As String
    '    Dim activo As Boolean
    '    inicio = CType(dv_ciclos.Rows(1).FindControl("tbx_inicio"), TextBox).Text
    '    fin = CType(dv_ciclos.Rows(2).FindControl("tbx_fin"), TextBox).Text
    '    entrevista = CType(dv_ciclos.Rows(3).FindControl("tbx_entrevista"), TextBox).Text
    '    examen = CType(dv_ciclos.Rows(4).FindControl("tbx_examen"), TextBox).Text
    '    docini = CType(dv_ciclos.Rows(5).FindControl("tbx_docinicio"), TextBox).Text
    '    docfin = CType(dv_ciclos.Rows(6).FindControl("tbx_docfin"), TextBox).Text
    '    activo = CType(dv_ciclos.Rows(7).FindControl("cbx_activo"), CheckBox).Checked
    '    ciclo = CType(dv_ciclos.Rows(0).FindControl("lbl_ciclo"), Label).Text
    '    actualizaCiclo(inicio, fin, entrevista, examen, docini, docfin, activo, ciclo)
    '    dv_ciclos.DataSource = detalleCiclo(ciclo)
    '    dv_ciclos.DataBind()
    'End Sub

    'Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    '    gv_periodos.DataSource = llenaCiclo()
    '    gv_periodos.DataBind()
    '    mv_periodoadd.ActiveViewIndex = 0
    'End Sub


    'Protected Sub gv_noActivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gv_noActivo.SelectedIndexChanged
    '    Dim nivel As String = String.Empty
    '    Dim nombre As String = String.Empty
    '    Dim turno As String = String.Empty
    '    Dim clave As String = String.Empty
    '    Dim ciclo As String
    '    ciclo = CType(dv_ciclos.Rows(0).FindControl("lbl_ciclo"), Label).Text
    '    nivel = Me.gv_noActivo.SelectedRow.Cells(0).Text
    '    clave = Me.gv_noActivo.SelectedRow.Cells(1).Text
    '    nombre = Me.gv_noActivo.SelectedRow.Cells(2).Text
    '    turno = Me.gv_noActivo.SelectedRow.Cells(3).Text
    '    MsgBox(ciclo)
    '    MsgBox(nivel)
    '    MsgBox(clave)
    '    MsgBox(nombre)
    '    MsgBox(turno)
    'End Sub

    
    'Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
    '    Dim nivel As String = gv_noActivo.Rows(e.ToString).Cells(0).Text
    '    Dim clave As String = gv_noActivo.Rows(e.ToString).Cells(1).Text
    '    Dim nombre As String = gv_noActivo.Rows(e.ToString).Cells(2).Text
    '    Dim turno As String = gv_noActivo.Rows(e.ToString).Cells(3).Text
    'End Sub

    Protected Sub gv_noActivo_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        'Dim ciclo = CType(dv_ciclos.Rows(0).FindControl("lbl_ciclo2"), Label).Text
        Dim ciclo As String = lbl_ciclo.Text
        Dim nivel As String = gv_noActivo.Rows(CInt(e.CommandArgument)).Cells(1).Text
        Dim clave As String = gv_noActivo.Rows(CInt(e.CommandArgument)).Cells(2).Text
        Dim nombre As String = gv_noActivo.Rows(CInt(e.CommandArgument)).Cells(3).Text
        Dim turno As String = gv_noActivo.Rows(CInt(e.CommandArgument)).Cells(4).Text
        Dim idturno As String = CType(gv_noActivo.Rows(CInt(e.CommandArgument)).FindControl("idturno"), HiddenField).Value
        'MsgBox(ciclo)
        'MsgBox(nivel)
        'MsgBox(clave)
        'MsgBox(nombre)
        'MsgBox(turno)

        insertaCarrera(clave, turno, ciclo, idturno)
        gv_activo.DataSource = carreraActiva(ciclo)
        gv_activo.DataBind()
        gv_noActivo.DataSource = carreraNoActiva(ciclo)
        gv_noActivo.DataBind()
    End Sub

    

    Protected Sub btn_elimina_Click(sender As Object, e As ImageClickEventArgs)
        Dim ciclo = CType(dv_ciclos.Rows(0).FindControl("lbl_ciclo"), Label).Text
        eliminaCarrera(sender.commandargument.ToString)
        gv_activo.DataSource = carreraActiva(ciclo)
        gv_activo.DataBind()
        gv_noActivo.DataSource = carreraNoActiva(ciclo)
        gv_noActivo.DataBind()
    End Sub


    Public Function IsWeekend(ByVal vntDate As Object) As Boolean
        Dim bResult As Boolean
        If IsDate(vntDate) Then
            If (WeekDay(vntDate) Mod 6 = 1) Then bResult = True Else bResult = False
        Else
            Err.Raise(13, "Error")
        End If
        IsWeekend = bResult
    End Function

    Protected Sub lb_guardar_Click(sender As Object, e As EventArgs) Handles lb_guardar.Click

        Dim inicio, fin, entrevista, examen, docini, docfin, docsxdia As String
        Dim activo As Boolean
        inicio = securetext(CType(dv_ciclos.Rows(0).FindControl("tbx_inicio"), TextBox).Text)
        fin = securetext(CType(dv_ciclos.Rows(1).FindControl("tbx_fin"), TextBox).Text)
        entrevista = securetext(CType(dv_ciclos.Rows(2).FindControl("tbx_entrevista"), TextBox).Text)
        examen = securetext(CType(dv_ciclos.Rows(3).FindControl("tbx_examen"), TextBox).Text)
        docini = securetext(CType(dv_ciclos.Rows(4).FindControl("tbx_docinicio"), TextBox).Text)
        docfin = securetext(CType(dv_ciclos.Rows(5).FindControl("tbx_docfin"), TextBox).Text)
        docsxdia = securetext(CType(dv_ciclos.Rows(6).FindControl("tbx_docsxdia"), TextBox).Text)
        activo = CType(dv_ciclos.Rows(7).FindControl("cbx_activo"), CheckBox).Checked
        If activo = True Then
            desactiva_ciclos()
        End If

        elimina_ciclo_diasno(lbl_ciclo.Text)

        Dim nextday As Date = CDate(inicio)
        Do While (nextday <= entrevista)
            If nextday.DayOfWeek <> DayOfWeek.Saturday Then
                If nextday.DayOfWeek <> DayOfWeek.Sunday Then
                    'INSERCION DE LA FECHA NEXTDAY
                    insertaDias(lbl_ciclo.Text, Format(nextday, "yyyy/MM/dd"))
                End If
            End If
            nextday = nextday.AddDays(1)
        Loop




        'ciclo = CType(dv_ciclos.Rows(0).FindControl("lbl_ciclo"), Label).Text
        actualizaCiclo(inicio, fin, entrevista, examen, docini, docfin, activo, lbl_ciclo.Text, docsxdia)
        'actualizaCiclo_general(inicio, fin, activo, lbl_ciclo.Text)
        borra_llena_info_dias_no(lbl_ciclo.Text)
        'llena_info_dias_no(inicio, entrevista, lbl_ciclo.Text)
        llena_info_dias_no(docini, docfin, lbl_ciclo.Text)
        dv_ciclos.DataSource = detalleCiclo(lbl_ciclo.Text)
        dv_ciclos.DataBind()


    End Sub
    Protected Sub lb_oacademica_Click(sender As Object, e As EventArgs) Handles lb_oacademica.Click
        Dim ciclo As String = lbl_ciclo.Text
        lbl_c.Text = ciclo
        mv_periodoadd.ActiveViewIndex = 2
        gv_activo.DataSource = carreraActiva(ciclo)
        gv_activo.DataBind()
        gv_noActivo.DataSource = carreraNoActiva(ciclo)
        gv_noActivo.DataBind()
        'mv_periodoadd.ActiveViewIndex = 3
    End Sub
    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        gv_periodos.DataSource = llenaCiclo()
        gv_periodos.DataBind()
        mv_periodoadd.ActiveViewIndex = 0
    End Sub
    Protected Sub ib_recarga_Click(sender As Object, e As ImageClickEventArgs) Handles ib_recarga.Click
        gv_periodos.DataSource = llenaCiclo()
        gv_periodos.DataBind()
        mv_periodoadd.ActiveViewIndex = 0
    End Sub

    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras.Click
        mv_periodoadd.ActiveViewIndex = 1
    End Sub

    Protected Sub ib_regresar__Click(sender As Object, e As ImageClickEventArgs)
        mv_periodoadd.ActiveViewIndex = 0
    End Sub

    
End Class
