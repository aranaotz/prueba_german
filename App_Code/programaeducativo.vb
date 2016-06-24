Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Public Class programaeducativo

    'listado para llenar el grid con las carreras
    Public Shared Function listado() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("select cv_carrera AS CLAVE, nombre AS NOMBRE, nivel AS NIVEL, CASE WHEN activo=1 THEN 'SI' ELSE 'NO' END activo, fecha_creacion autorizado from info_carreras WHERE activo=1 order by activo desc,nivel,nombre", c)
        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat

    End Function

    'Valida que la clave no exista
    Public Shared Function validaClave(ByVal clave As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case WHEN count(*)>0 THEN '1' else '0' END as duplicado from info_carreras where cv_carrera='" + clave + "'", c)
        c.Open()
        validaClave = valida.ExecuteScalar.ToString
        c.Close()
    End Function

    'Inserta en la tabla info_carreras despues de validar
    Public Shared Function insertar(ByVal clave As String, ByVal nivel As String, ByVal nombre As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into info_carreras (cv_carrera, nivel,nombre) values (UPPER('" + clave + "'),'" + nivel + "',UPPER('" + nombre + "'))", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    'Vista editar
    Public Shared Function detallePrograma(ByVal cv As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim clave As New SqlDataAdapter("select nivel, cv_carrera, nombre from info_carreras where cv_carrera ='" + cv + "' ", c)
        Dim clavet As New DataTable
        c.Open()
        clave.Fill(clavet)
        c.Close()
        Return clavet
    End Function

    'Actualiza periodo educativo
    Public Shared Function actualizaPrograma(ByVal nivel As String, ByVal clave As String, ByVal nombre As String, ByVal cv As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actualiza As New SqlDataAdapter("UPDATE [info_carreras] SET [nivel] = '" + nivel + "', [cv_carrera] = '" + clave + "', [nombre] = '" + nombre + "' " + _
                                            " where cv_carrera='" + cv + "'", c)
        Dim actualizat As New DataTable
        c.Open()
        actualiza.Fill(actualizat)
        c.Close()
        Return actualizat
    End Function

    'Eliminar programa educativos
    Public Shared Sub eliminaPeriodo(ByVal clave As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim elimina As New SqlCommand("delete from info_carreras where cv_carrera='" + clave + "'", c)

        c.Open()
        elimina.ExecuteNonQuery()
        c.Close()
    End Sub


    'Carga el nivel del programa educativo TSU O ING
    Public Shared Function cargaNivel() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select id, nivel from basic_niveles order by id asc", c)

        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat
    End Function



End Class
