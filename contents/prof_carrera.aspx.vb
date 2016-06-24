Imports user_access
Imports menumount
Imports secure_tools
Partial Class contents_prof_carrera
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not IsPostBack Then

            carga_ddl()


            mv_prof_carrera.ActiveViewIndex = 0
        End If

    End Sub

    Public Sub carga_ddl()
        Dim ddlc As New ListItem("Selecciona...")


        With ddl_carreras
            .DataSource = cargaCarreras(claveTrab(Session("gcu")))
            .DataValueField = "id"
            .DataTextField = "cv_carrera"
            .DataBind()
            .Items.Insert(0, ddlc)

        End With
    End Sub


    Protected Sub ddl_carreras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_carreras.SelectedIndexChanged
        If ddl_carreras.SelectedIndex = 0 Then
            gv_prof.Visible = False
        Else
            gv_prof.Visible = True
            gv_prof.DataSource = cargaProf(ddl_carreras.SelectedItem.ToString)
            gv_prof.DataBind()
        End If
    End Sub
End Class
