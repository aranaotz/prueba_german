Imports escolar
Imports secure_tools


Partial Class gradeassign
    Inherits System.Web.UI.Page

    Private Sub asistlistas_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gv_listas.DataSource = cargacursos(clavetrabajador(Session("gcu")))
            gv_listas.DataBind()
            mv_evaluacion.ActiveViewIndex = 0
        End If
    End Sub
    Protected Sub lb_icu_Click(sender As Object, e As EventArgs)
        Dim icu As String = sender.CommandArgument.ToString
        gv_alumnos.DataSource = cargaalumnos_icu(icu)
        gv_alumnos.DataBind()
        mv_evaluacion.ActiveViewIndex = 1
    End Sub
    Protected Sub lb_temp_Click(sender As Object, e As EventArgs) Handles lb_temp.Click

        Dim i As Integer

        For i = 0 To gv_alumnos.Rows.Count - 1

            Dim matricula As String = CType(gv_alumnos.Rows(i).FindControl("hf_matricula"), HiddenField).Value
            Dim calificacion As String = CType(gv_alumnos.Rows(i).FindControl("tbx_calificacion"), TextBox).Text
            Dim tipo As String = CType(gv_alumnos.Rows(i).FindControl("ddl_tipo"), DropDownList).SelectedItem.ToString


        Next

    End Sub

End Class
