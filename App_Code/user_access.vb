Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web

Public Class user_access


    'Carga el ddl con las carreras a las que pertenece el director de carrera
    Shared Function cargaCarreras(ByVal clave As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim acceso As New SqlDataAdapter("SELECT id,cv_carrera from info_carrera_profesor where pertenece=1 and cv_trabajador='" + clave + "'", c)
        Dim accesot As New DataTable
        c.Open()
        acceso.Fill(accesot)
        c.Close()
        Return accesot

    End Function



    Shared Function claveTrab(ByVal nombre As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cuf As New SqlCommand("select clavetrab from user_users where usuario='" + nombre + "'", c)
        c.Open()
        claveTrab = cuf.ExecuteScalar.ToString()
        c.Close()
    End Function

    'carga el grid con los profesores que pertenecen a alguna categoria
    Shared Function cargaProf(ByVal carrera As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim prof As New SqlDataAdapter("select u.clavetrab, u.apellidopat,u.apellidomat,u.nombres,c.cargo " +
                                        "from info_carrera_profesor as p " +
                                        "LEFT JOIN user_users as u on p.cv_trabajador= u.clavetrab " +
                                        "LEFT OUTER JOIN info_cargosutj as c on u.idpuesto=c.id   " +
                                        "where  p.pertenece=1 and p.cv_carrera='" + carrera + "' and c.id <> 5", c)
        Dim proft As New DataTable
        c.Open()
        prof.Fill(proft)
        c.Close()
        Return proft
    End Function

End Class
