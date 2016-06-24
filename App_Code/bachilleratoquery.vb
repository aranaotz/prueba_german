Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports secure_tools

Public Class bachilleratoquery

    Shared Function tabla_resultados_busqueda(ByVal abuscar As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim trb As New SqlDataAdapter("select nombre_ct as item,id from info_prepas " +
                                      "where UPPER(nombre_ct) like UPPER('%" + securetext(abuscar) + "%') order by nombre_ct ASC", c)
        Dim trbt As New DataTable
        c.Open()
        trb.Fill(trbt)
        c.Close()
        Return trbt
    End Function

    'Lista de bachilleratos
    Shared Function llenaBachillerato(ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim trb As New SqlDataAdapter("select nombre_ct AS NOMBRE,estado AS ESTADO,municipio AS MUNICIPIO,localidad AS LOCALIDAD,domicilio AS DOMICILIO," + _
                                      "colonia AS CP,telefono AS TELEFONO from info_prepas where id='" + id + "'", c)
        Dim trbt As New DataTable
        c.Open()
        trb.Fill(trbt)
        c.Close()
        Return trbt
    End Function

    'Carga ddl estado
    Public Shared Function cargaEstado() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select id, nombre from estados", c)

        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat
    End Function

    'carga ddl municipio
    Public Shared Function cargaMunicipio(ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carga As New SqlDataAdapter("select id, nombre from municipios where estado_id='" + id + "'", c)

        Dim cargat As New DataTable
        c.Open()
        carga.Fill(cargat)
        c.Close()
        Return cargat
    End Function

    'Valida que la que el registro no exista en la tabla info_prepas
    Public Shared Function validaPrepa(ByVal nombre As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case WHEN count(*)>0 THEN '1' else '0' END as duplicado from info_prepas where nombre_ct='" + securetext(nombre) + "'", c)
        c.Open()
        validaPrepa = valida.ExecuteScalar.ToString
        c.Close()
    End Function

    'Inserta en la tabla 
    Public Shared Function insertaPrepa(ByVal nombre As String, ByVal estado As String, ByVal municipio As String, ByVal localidad As String, ByVal domicilio As String, ByVal colonia As String, ByVal telefono As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("insert into info_prepas (nombre_ct,estado,municipio,localidad,domicilio,colonia,telefono) VALUES " +
                                          "('" + securetext(nombre) + "','" + securetext(estado) + "','" + securetext(municipio) + "','" + securetext(localidad) + "', " +
                                          "'" + securetext(domicilio) + "','" + securetext(colonia) + "', '" + securetext(telefono) + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    Public Shared Function delete_bachillerato(ByVal id As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim dba As New SqlCommand("delete from info_prepas where id='" + id + "'", c)
        c.Open()
        dba.ExecuteNonQuery()
        c.Close()
        Dim newdt As New DataTable
        Return newdt
    End Function
End Class
