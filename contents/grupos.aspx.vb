Imports cvgroups
Partial Class contents_grupos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            gv_listado.DataSource = listadoCarreras()
            gv_listado.DataBind()
            mv_grupos.ActiveViewIndex = 0
        End If

    End Sub

    Protected Sub lb_clave_Click(sender As Object, e As EventArgs)

        mv_grupos.ActiveViewIndex = 1
        lbl_carrera.Text = sender.commandArgument.ToString
        gv_grupos.DataSource = grupoCarrera(lbl_carrera.Text)
        gv_grupos.DataBind()


    End Sub

    Protected Sub lb_id_grupo_Click(sender As Object, e As EventArgs)


        mv_grupos.ActiveViewIndex = 2
        lbl_grupo.Text = sender.commandArgument.ToString
        gv_alumnos.DataSource = alumnosGrupo(lbl_grupo.Text)
        gv_alumnos.DataBind()
        lbl_tutor.Text = tutorGrupo(lbl_grupo.Text)

    End Sub
    Protected Sub lb_matricula_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub ib_regreso_Click(sender As Object, e As ImageClickEventArgs)
        mv_grupos.ActiveViewIndex = 1
    End Sub
    Protected Sub lb_Volver_Click(sender As Object, e As EventArgs)
        mv_grupos.ActiveViewIndex = 0
    End Sub
    Protected Sub lb_nuevo_Click(sender As Object, e As EventArgs) Handles lb_nuevo.Click
        lbl_carr.Text = lbl_carrera.Text
        mv_grupos.ActiveViewIndex = 3
    End Sub
    Protected Sub ib_back__Click(sender As Object, e As ImageClickEventArgs)
        mv_grupos.ActiveViewIndex = 1
    End Sub
    Protected Sub lb_continuar_Click(sender As Object, e As EventArgs)



        Dim numero As Integer = ddl_grupos.SelectedValue
        Dim letra As String = Asc("A")
        Try

            For index As Integer = 1 To numero
                Dim id As String = maxId() + 1

                Dim carrera As String = selectCarrera(lbl_carr.Text)

                'MsgBox(letra)
                'MsgBox(Chr(letra))

                insertaGrupo(id, ddl_turno.SelectedValue, carrera, Chr(letra))
                letra = letra + 1
            Next
            mv_grupos.ActiveViewIndex = 4

        Catch ex As Exception



        End Try




    End Sub
    Protected Sub ib_regresar__Click(sender As Object, e As ImageClickEventArgs)
        mv_grupos.ActiveViewIndex = 3
        ddl_grupos.SelectedValue = 0
        ddl_turno.SelectedValue = 0
    End Sub
    Protected Sub lb_regresar__Click(sender As Object, e As EventArgs)
        mv_grupos.ActiveViewIndex = 0
    End Sub
End Class
