Imports carreraCiclo
Imports reportes_querys
Imports exporttoexcel

Partial Class contents_rseguimiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Header.Title = "Seguimiento de aspirantes - SIAAA UTJ " + synpin_code.versiones
        If Not IsPostBack Then
            gv_ciclos.DataSource = llenaCiclo()
            gv_ciclos.DataBind()
            mv_rseguimento.ActiveViewIndex = 0
        End If
    End Sub


    Protected Sub lb_ciclo_Click(sender As Object, e As EventArgs)

        lbl_ciclo.Text = sender.commandArgument.ToString
        lbl_ciclo1.Text = sender.commandArgument.ToString
        lb_exportar.CommandArgument = sender.commandArgument.ToString
        gv_seguimiento.DataSource = seguimiento(sender.commandArgument.ToString)
        gv_seguimiento.DataBind()

        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportar)
        End If

        mv_rseguimento.ActiveViewIndex = 1

       
    End Sub

    Protected Sub ib_back_Click(sender As Object, e As ImageClickEventArgs) Handles ib_back.Click
        gv_ciclos.DataSource = llenaCiclo()
        gv_ciclos.DataBind()
        mv_rseguimento.ActiveViewIndex = 0
    End Sub

    Protected Sub lb_carrera_Click(sender As Object, e As EventArgs)
        lbl_carrera.Text = sender.commandArgument.ToString
        lbl_c.Text = lbl_ciclo.Text
        gv_detalle.DataSource = detalleSeguimiento(lbl_carrera.Text, lbl_c.Text)
        gv_detalle.DataBind()
        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
        If current IsNot Nothing Then
            current.RegisterPostBackControl(lb_exportaDetalle)
        End If
        mv_rseguimento.ActiveViewIndex = 2
        hf_ciclo.Value = lbl_ciclo1.Text
    End Sub


    Protected Sub lb_exportar_Click(sender As Object, e As EventArgs) Handles lb_exportar.Click
        'exportwf(seguimiento(sender.commandArgument.ToString), "Seguimiento_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))

        'Crystal reports
        Dim ciclo As String = lbl_ciclo1.Text


        Response.Redirect("~/contents/crv_pi/rpt_numeros.aspx?c=" + ciclo)
    End Sub

    Protected Sub lb_exportaDetalle_Click(sender As Object, e As EventArgs) Handles lb_exportaDetalle.Click
        'exportwf(detalleSeguimiento(lbl_carrera.Text, lbl_ciclo.Text), "SeguimientoCarrera_" & sender.commandArgument.ToString & "_" & Format(Now, "yyyy.MM.dd_hh.mm.ss"))

        'Crystal reports
        Dim ciclo As String = hf_ciclo.Value
        Dim carrera As String = lbl_carrera.Text

        Response.Redirect("~/contents/crv_pi/rpt_numeros_carrera.aspx?c=" + ciclo + "&ca=" + carrera)

    End Sub

    Protected Sub ib_atras_Click(sender As Object, e As ImageClickEventArgs) Handles ib_atras.Click
        mv_rseguimento.ActiveViewIndex = 1
    End Sub

  
End Class
