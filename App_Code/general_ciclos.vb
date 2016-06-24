Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web

Public Class general_ciclos

    'valida que el ciclo no exista
    Public Shared Function validaCiclo(ByVal ciclo As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case when count(*)>0 then '1' else '0' end as duplicado from general_ciclos where ciclo='" + ciclo + "'", c)
        c.Open()
        validaCiclo = valida.ExecuteScalar.ToString
        c.Close()

    End Function



    'Inserta en tabla general_ciclos
    Shared Function llena_cicloGeneral(ByVal ciclo As String, ByVal inicio As String, ByVal fin As String, ByVal active As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("INSERT INTO general_ciclos (ciclo, startdate, finaldate,active) VALUES ('" + ciclo + "','" + inicio + "','" + fin + "', '" + active + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    'llena el grid view de los ciclos

    Public Shared Function detalleGeneral() As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ciclo As New SqlDataAdapter("set LANGUAGE 'Español'select ciclo,CONVERT(varchar(11),startdate,111) as inicio,CONVERT(varchar(11),finaldate,111) as fin, fechas,active " +
                                        "from general_ciclos order by ciclo desc", c)
        Dim ciclot As New DataTable
        c.Open()
        ciclo.Fill(ciclot)
        c.Close()
        Return ciclot

    End Function

    'inserta ciclo en la tabla info_general_ciclos

    Shared Function insertaDetalleCiclo(ByVal ciclo As String, ByVal inicio As String, ByVal fin As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("INSERT INTO info_general_ciclos (ciclo,inicio_clases,fin_ciclo) VALUES ('" + ciclo + "','" + inicio + "','" + fin + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    'Selecciona segun el ciclo 
    Public Shared Function detalleCiclo(ByVal ciclo As String) As DataTable

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim detalle As New SqlDataAdapter("set LANGUAGE 'Español'  " +
                                        "select ciclo, CAST(DAY(inicio_clases) AS VARCHAR) + ' de ' + datename(MONTH, inicio_clases) + ' de ' + CAST(YEAR(inicio_clases) AS VARCHAR), " +
                                        "CAST(DAY(inicio_evaluacion_continua) As VARCHAR) + ' de ' + datename(MONTH, inicio_evaluacion_continua) + ' de ' + CAST(YEAR(inicio_evaluacion_continua) AS VARCHAR)," +
                                        "CAST(DAY(fin_evaluacion_continua) AS VARCHAR) + ' de ' + datename(MONTH, fin_evaluacion_continua) + ' de ' + CAST(YEAR(fin_evaluacion_continua) AS VARCHAR),  " +
                                        "CAST(DAY(inicio_aprobacion_estadia) AS VARCHAR) + ' de ' + datename(MONTH, inicio_aprobacion_estadia) + ' de ' + CAST(YEAR(inicio_aprobacion_estadia) AS VARCHAR), " +
                                        "CAST(DAY(fin_aprobacion_estadia) AS VARCHAR) + ' de ' + datename(MONTH, fin_aprobacion_estadia) + ' de ' + CAST(YEAR(fin_aprobacion_estadia) AS VARCHAR),  " +
                                        "CAST(DAY(fin_cursos) AS VARCHAR) + ' de ' + datename(MONTH, fin_cursos) + ' de ' + CAST(YEAR(fin_cursos) AS VARCHAR),   " +
                                        "CAST(DAY(inicio_evaluacion_remedial) AS VARCHAR) + ' de ' + datename(MONTH, inicio_evaluacion_remedial) + ' de ' + CAST(YEAR(inicio_evaluacion_remedial) AS VARCHAR), " +
                                        "CAST(DAY(fin_evaluacion_remedial) AS VARCHAR) + ' de ' + datename(MONTH, fin_evaluacion_remedial) + ' de ' + CAST(YEAR(fin_evaluacion_remedial) AS VARCHAR), " +
                                        "CAST(DAY(inicio_registro_evaluacion_remedial) AS VARCHAR) + ' de ' + datename(MONTH, inicio_registro_evaluacion_remedial) + ' de ' + CAST(YEAR(inicio_registro_evaluacion_remedial) AS VARCHAR),  " +
                                        "CAST(DAY(fin_registro_evaluacion_remedial) AS VARCHAR) + ' de ' + datename(MONTH, fin_registro_evaluacion_remedial) + ' de ' + CAST(YEAR(fin_registro_evaluacion_remedial) AS VARCHAR)," +
                                        "CAST(DAY(fin_ciclo) AS VARCHAR) + ' de ' + datename(MONTH, fin_ciclo) + ' de ' + CAST(YEAR(fin_ciclo) AS VARCHAR), " +
                                        "CAST(DAY(no_laborable) AS VARCHAR) + ' de ' + datename(MONTH, no_laborable) + ' de ' + CAST(YEAR(no_laborable) AS VARCHAR), no_laborable_otros," +
                                        "CAST(DAY(inicio_vacaciones) AS VARCHAR) + ' de ' + datename(MONTH, inicio_vacaciones) + ' de ' + CAST(YEAR(inicio_vacaciones) AS VARCHAR),  " +
                                        "CAST(DAY(fin_vacaciones) AS VARCHAR) + ' de ' + datename(MONTH, fin_vacaciones) + ' de ' + CAST(YEAR(fin_vacaciones) AS VARCHAR)  " +
                                        "from info_general_ciclos where ciclo='" + ciclo + "'", c)
        Dim ciclot As New DataTable
        c.Open()
        detalle.Fill(ciclot)
        c.Close()
        Return ciclot

    End Function



    'Actualiza info_general_ciclos
    Public Shared Function actualizaGeneralCiclos(ByVal ini_clases As String, ByVal ini_ev_continua As String, ByVal fin_ev_continua As String, ByVal ini_ap_estadia As String,
                                                  ByVal fin_ap_estadia As String, ByVal fin_cursos As String, ByVal ini_ev_remedial As String, ByVal fin_ev_remedial As String,
                                                  ByVal ini_reg_ev_remedial As String, ByVal fin_reg_ev_remedial As String, ByVal fin_ciclo As String,
                                                  ByVal nl As String, ByVal nl_o As String, ByVal ini_vacaciones As String, ByVal fin_vacaciones As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim oferta As New SqlDataAdapter("UPDATE info_general_ciclos set inicio_clases='" + ini_clases + "', inicio_evaluacion_continua='" + ini_ev_continua + "', " +
                                         "fin_evaluacion_continua='" + fin_ev_continua + "', inicio_aprobacion_estadia='" + ini_ap_estadia + "', fin_aprobacion_estadia='" + fin_ap_estadia + "'," +
                                         "fin_cursos='" + fin_cursos + "', inicio_evaluacion_remedial='" + ini_ev_remedial + "',fin_evaluacion_remedial='" + fin_ev_remedial + "' ," +
                                         "inicio_registro_evaluacion_remedial='" + ini_reg_ev_remedial + "',fin_registro_evaluacion_remedial='" + fin_reg_ev_remedial + "', fin_ciclo='" + fin_ciclo + "'," +
                                         "no_laborable='" + nl + "',no_laborable_otros='" + nl_o + "'," +
                                         "inicio_vacaciones='" + ini_vacaciones + "',fin_vacaciones='" + fin_vacaciones + "' WHERE ciclo='" + ciclo + "'", c)

        Dim ofertat As New DataTable
        c.Open()
        oferta.Fill(ofertat)
        c.Close()
        Return ofertat
    End Function

End Class
