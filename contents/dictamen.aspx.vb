Imports carreraCiclo
Imports importfromexcel
Imports exporttoexcel
Imports synpin_code
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common
Imports dtciclos


Partial Class contents_dictamen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Dictamen - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            carga_campos_importacion()
            mv_dictamen.ActiveViewIndex = 0
        End If
    End Sub

    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)
        mv_dictamen.ActiveViewIndex = 1
        lbl_ciclo.Text = sender.commandArgument.ToString

        'If validaCiclo(lbl_ciclo.Text) Then
        'lb_importar.Visible = False
        'lbl_mensaje.Visible = False
        gv_carreras.DataSource = carreras_dictaminados(lbl_ciclo.Text)
        gv_carreras.DataBind()
        'Else
        'lb_importar.Visible = True
        'lbl_mensaje.Visible = True
        'End If
    End Sub

    Protected Sub lb_clave_Click(sender As Object, e As EventArgs)
        'mv_dictamen.ActiveViewIndex = 2
        lbl_carrera.Text = sender.commandArgument.ToString

        carga_ddl()
        mod_dictamen.Show()
    End Sub
    Public Sub carga_ddl()

        Dim ddlp As New ListItem("SELECCIONA TURNO...", "0")
        With ddl_turnos
            .DataSource = cargaTurnoActivo(lbl_ciclo.Text, lbl_carrera.Text)
            .DataValueField = "id_turno"
            .DataTextField = "turno"
            .DataBind()
            .Items.Insert(0, ddlp)
        End With

    End Sub

    Protected Sub cbx_activo_CheckedChanged(sender As Object, e As EventArgs)

        Dim cbx As CheckBox = DirectCast(sender, CheckBox)
        Dim objFila As GridViewRow = DirectCast(cbx.Parent.Parent, GridViewRow)
        Dim folio As HiddenField = DirectCast(objFila.FindControl("hf_folio"), HiddenField)

        Dim valor As Boolean = cbx.Checked

        If valor Then
            habilitaDictaminados(folio.Value)
        Else
            deshabilitaDictaminados(folio.Value)
        End If

    End Sub

    Protected Sub cbx_manual_CheckedChanged(sender As Object, e As EventArgs)
        Dim cbx As CheckBox = DirectCast(sender, CheckBox)
        Dim objFila As GridViewRow = DirectCast(cbx.Parent.Parent, GridViewRow)
        Dim ustring As HiddenField = DirectCast(objFila.FindControl("hf_ustring"), HiddenField)

        Dim valor As Boolean = cbx.Checked

        If valor Then
            actualizaDictamenManual(ustring.Value, lbl_ciclo.Text)
        Else
            deshabilitaDictamenManual(ustring.Value)
        End If

    End Sub

    Protected Sub lb_lista_Click(sender As Object, e As EventArgs)
        gv_listado.DataSource = dicatamen(lbl_carrera.Text, lbl_ciclo.Text)
        gv_listado.DataBind()
    End Sub


    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs)
        mv_dictamen.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_importar_Click(sender As Object, e As EventArgs) Handles lb_importar.Click
        mv_dictamen.ActiveViewIndex = 3
        lb_subir.Visible = False
    End Sub

    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs)
        mv_dictamen.ActiveViewIndex = 1
    End Sub

    Protected Sub lb_inicio_Click(sender As Object, e As EventArgs)
        mv_dictamen.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_atras_Click(sender As Object, e As EventArgs)
        mv_dictamen.ActiveViewIndex = 0
    End Sub



    Protected Sub cmd_importar_Click(sender As Object, e As EventArgs) Handles cmd_importar.Click
        uploadfile(fu_ceneval)
        lb_subir.Visible = True
        cmd_importar.Enabled = False
    End Sub
    Private Sub uploadfile(ByVal enviador As FileUpload)
        If enviador.HasFile = True Then
            Dim archivo As FileInfo = New FileInfo(enviador.FileName)
            Dim ext As String = archivo.Extension.ToString
            Session("extractname") = extractname(ext)
            Session("extension") = ext
            Dim nombre_archivo As String = Session("extractname")
            enviador.SaveAs(Server.MapPath("~\basedocs\imports\ceneval\") & nombre_archivo)
            t_import.Enabled = True

            'llena_gv(nombre_archivo, ext)
        End If
    End Sub

    Protected Sub llena_gv(ByVal nda As String, ByVal ext As String)
        gv_ceneval.DataSource = import_togv(Server.MapPath("~\basedocs\imports\ceneval\") & nda, ext, "Yes")
        gv_ceneval.DataBind()
    End Sub

    Protected Sub t_import_Tick(sender As Object, e As EventArgs) Handles t_import.Tick
        t_import.Enabled = False
        llena_gv(Session("extractname"), Session("extension"))
    End Sub


    Protected Sub lb_subir_Click(sender As Object, e As EventArgs) Handles lb_subir.Click
        'Dim dtclean As New DataTable
        'gv_ceneval.DataSource = dtclean
        'gv_ceneval.DataBind()
        cmd_importar.Enabled = True

        'Try

        Dim c As New SqlConnection(Application("str"))
        ''decimal
        'Dim r As New Globalization.CultureInfo("es-ES")
        'r.NumberFormat.CurrencyDecimalSeparator = "."
        'r.NumberFormat.NumberDecimalSeparator = "."
        'System.Threading.Thread.CurrentThread.CurrentCulture = r
        Dim calificacion As String = "0.0"


        Dim k As Integer
        For k = 0 To gv_ceneval.Rows.Count - 1
            Dim folio As String = gv_ceneval.Rows(k).Cells(CInt(ddl_folio.SelectedItem.Text) - 1).Text
            'Dim fecha As Date = gv_ceneval.Rows(k).Cells(2).Text
            Dim icne As String = gv_ceneval.Rows(k).Cells(CInt(ddl_calificacion.SelectedItem.Text) - 1).Text

            calificacion = (Math.Round((icne * 10 / 1300), 1, MidpointRounding.AwayFromZero)).ToString

            eliminaResultCeneval(folio)
            insertaResultCeneval(folio, icne, calificacion)
            Try
                acualizaPingresoCeneval(selectUstring(folio), calificacion)
                acualizaCeneval(icne, folio, calificacion)
            Catch ex As Exception

            End Try

        Next

        'mv_dictamen.ActiveViewIndex = 4
        'Catch ex As Exception

        mv_dictamen.ActiveViewIndex = 4
        'End Try

    End Sub




    Protected Sub ib_atras_Click1(sender As Object, e As ImageClickEventArgs)
        mv_dictamen.ActiveViewIndex = 1
    End Sub

    Protected Sub ib_regresar__Click(sender As Object, e As ImageClickEventArgs)
        mv_dictamen.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_regresar__Click(sender As Object, e As EventArgs)
        mv_dictamen.ActiveViewIndex = 0
    End Sub

    Protected Sub ddl_turnos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_turnos.SelectedIndexChanged

        If ddl_turnos.SelectedIndex = 0 Then
            gv_listado.DataSource = dicatamen(lbl_carrera.Text, lbl_ciclo.Text)
            gv_listado.DataBind()
        Else

            gv_listado.DataSource = dicatamenFiltrado(lbl_carrera.Text, lbl_ciclo.Text, ddl_turnos.SelectedValue)
            gv_listado.DataBind()


        End If


    End Sub

    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs)
        If ddl_turnos.SelectedIndex = 0 Then
            Response.Redirect("~/contents/crv_pi/rpt_dictamen_carrera.aspx?c=" + lbl_ciclo.Text + "&ca=" + lbl_carrera.Text)
            'exportwf(dicatamen(lbl_carrera.Text, lbl_ciclo.Text), "Dictaminados_" & lbl_carrera.Text & "_General" & "_" & Format(Now, "yyyy.MM.dd_hh.ss"))
        ElseIf ddl_turnos.SelectedIndex = 1 Then
            Response.Redirect("~/contents/crv_pi/rpt_dictamen_carrera.aspx?c=" + lbl_ciclo.Text + "&ca=" + lbl_carrera.Text & "&t=" + ddl_turnos.SelectedValue)
            'exportwf(dicatamenFiltrado(lbl_carrera.Text, lbl_ciclo.Text, ddl_turnos.SelectedValue), "Dictaminados_" & lbl_carrera.Text & "_" & ddl_turnos.SelectedItem.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.ss"))
        Else
            Response.Redirect("~/contents/crv_pi/rpt_dictamen_carrera.aspx?c=" + lbl_ciclo.Text + "&ca=" + lbl_carrera.Text & "&t=" + ddl_turnos.SelectedValue)
            'exportwf(dicatamenFiltrado(lbl_carrera.Text, lbl_ciclo.Text, ddl_turnos.SelectedValue), "Dictaminados_" & lbl_carrera.Text & "_" & ddl_turnos.SelectedItem.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.ss"))
        End If
    End Sub

    Protected Sub lb_manual_Click(sender As Object, e As EventArgs)
        mv_dictamen.ActiveViewIndex = 5
    End Sub

    Protected Sub cmd_buscar_Click(sender As Object, e As EventArgs) Handles cmd_buscar.Click
        gv_resultados.DataSource = tabla_resultados_busqueda(tbx_busqueda.Text, actualcycle(Application("str")))
        gv_resultados.DataBind()
    End Sub

    Protected Sub ib_atras__Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras_.Click
        mv_dictamen.ActiveViewIndex = 1
    End Sub

    Protected Sub lb_inicio__Click(sender As Object, e As EventArgs)
        mv_dictamen.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_gvresultado_Click(sender As Object, e As EventArgs)

        gv_dmanual.DataSource = dictamenManual(sender.commandArgument.ToString)
        gv_dmanual.DataBind()
        mv_dictamen.ActiveViewIndex = 6
    End Sub

   
    Protected Sub ib_regresar_Click(sender As Object, e As ImageClickEventArgs)
        mv_dictamen.ActiveViewIndex = 1
    End Sub

    'PROCEDE CON LA DICTAMINACION DE ALUMNOS AL OPRIMIR EL BOTON DEL CUADRO BLANCO
    Protected Sub btn_continuar_Click(sender As Object, e As EventArgs)
        mv_dictamen.ActiveViewIndex = 2
        activaDicataminar(tbx_cuantos.Text, lbl_carrera.Text, ddl_turnos.SelectedValue, lbl_ciclo.Text)
        gv_listado.DataSource = dicatamenFiltrado(lbl_carrera.Text, lbl_ciclo.Text, ddl_turnos.SelectedValue)
        gv_listado.DataBind()
        tbx_cuantos.Text = ""
    End Sub

    Private Sub carga_campos_importacion()
        Dim kt As Integer
        For kt = 1 To 200
            ddl_folio.Items.Add(kt.ToString)
            ddl_calificacion.Items.Add(kt.ToString)
        Next
    End Sub
End Class
