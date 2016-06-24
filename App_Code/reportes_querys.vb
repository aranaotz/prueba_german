Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web

Public Class reportes_querys
    Public Shared Function carrera_ciclo(ByVal carrera As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT ustring 'NO. REGISTRO',fecha 'FECHA',paterno 'PATERNO',materno 'MATERNO',nombres 'NOMBRES',telefonom 'TEL. MOVIL',email 'EMAIL' from pingreso " + _
                                     "where carrera='" + carrera + "' and ciclo='" + ciclo + "' order by id ", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'REPORTE DE ASPIRANTES QUE NO ACUDIERON A ENTREVISTA

    Public Shared Function noEntrevista(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT        dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno + ' ' + dbo.pingreso.amaterno AS APELLIDOS, dbo.pingreso.carrera AS CARRERA , SUBSTRING(dbo.basic_turnos.turno, 1, 1) AS TURNO," +
                                     "CONVERT(varchar(11),dbo.pingreso.cita_fecha,103)  AS ENTREVISTA," +
                                    "dbo.pingreso.cita_hora AS HORA, dbo.pingreso.telfijo AS TELCASA, dbo.pingreso.telmovil AS CEL, dbo.pingreso.email AS EMAIL " +
                                    "FROM            dbo.pingreso INNER JOIN dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno " +
                                    "WHERE pingreso.ciclo='" + ciclo + "' AND pingreso.entrevista_foto=0 ORDER BY ENTREVISTA ASC ", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'REPORTE DE SEGUIMIENTO
    Public Shared Function seguimiento(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("select prerreg.carrera AS CARRERA, prerreg.PRERREGISTRADOS, ISNULL(premat.PREMAT, 0) AS PREMAT, ISNULL(prevesp.PREVESP, 0) AS PREVESP," + _
                                    "ISNULL(entrev.ENTREVISTADOS, 0) AS ENTREVISTADOS, ISNULL(entmat.ENTMAT, 0) AS ENTMAT,ISNULL(entvesp.ENTVESP, 0) AS ENTVESP," + _
                                    "ISNULL(entreg.ENTREGADOS, 0) AS ENTREGADOS, ISNULL(entregmat.ENTREGMAT, 0) AS ENTREGMAT, ISNULL(entregvesp.ENTREGVESP, 0) AS ENTREGVESP," + _
                                    "ISNULL(exa.EXAMEN, 0) AS EXAMEN,ISNULL(examat.EXAMAT, 0) AS EXAMAT,ISNULL(exavesp.EXAVESP, 0) AS EXAVESP," + _
                                    "ISNULL(ind.INDUCCION, 0) AS INDUCCION, ISNULL(indmat.INDMAT, 0) AS INDMAT, ISNULL(indvesp.INDVESP, 0) AS INDVESP," + _
                                    "ISNULL(dic.DICTAMINADOS, 0) AS DICTAMINADOS, ISNULL(dicmat.DICMAT, 0) AS DICMAT,ISNULL(dicvesp.DICVESP, 0) AS DICVESP " + _
                                    "from (select carrera, count(*) as PRERREGISTRADOS from pingreso where ciclo='" + ciclo + "' GROUP BY carrera) as prerreg " + _
                                    "LEFT JOIN (select carrera, count(*) as PREMAT from pingreso where ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) as premat " + _
                                    "on prerreg.carrera=premat.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as PREVESP from pingreso where ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) as prevesp " + _
                                    "on prerreg.carrera=prevesp.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREVISTADOS from pingreso where entrevista_foto = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS entrev " + _
                                    "on prerreg.carrera= entrev.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTMAT from pingreso where entrevista_foto = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS entmat " + _
                                    "on prerreg.carrera= entmat.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTVESP from pingreso where entrevista_foto = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS entvesp " + _
                                    "on prerreg.carrera= entvesp.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREGADOS from pingreso where documentos = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS entreg " + _
                                    "on prerreg.carrera=entreg.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREGMAT from pingreso where documentos = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS entregmat " + _
                                    "on prerreg.carrera=entregmat.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREGVESP from pingreso where documentos = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS entregvesp " + _
                                    "on prerreg.carrera=entregvesp.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as EXAMEN from pingreso where con_examen = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS exa " + _
                                    "on prerreg.carrera=exa.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as EXAMAT from pingreso where con_examen = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS examat " + _
                                    "on prerreg.carrera=examat.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as EXAVESP from pingreso where con_examen = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS exavesp " + _
                                    "on prerreg.carrera=exavesp.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as INDUCCION from pingreso where curso_induccion = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS ind " + _
                                    "on prerreg.carrera=ind.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as INDMAT from pingreso where curso_induccion = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS indmat " + _
                                    "on prerreg.carrera=indmat.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as INDVESP from pingreso where curso_induccion = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS indvesp " + _
                                    "on prerreg.carrera=indvesp.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as DICTAMINADOS from pingreso where dictaminados = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS dic " + _
                                    "on prerreg.carrera=dic.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as DICMAT from pingreso where dictaminados = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS dicmat " + _
                                    "on prerreg.carrera=dicmat.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as DICVESP from pingreso where dictaminados = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS dicvesp " + _
                                    "on prerreg.carrera=dicvesp.carrera " + _
                                    "UNION ALL " + _
                                    "select 'TOTALES' AS CARRERA, SUM(CONVERT(int,prerreg.PRERREGISTRADOS)) AS PRERREGISTRADOS, " + _
                                    "SUM(CONVERT(int,ISNULL(premat.PREMAT, 0))) AS PREMAT, " + _
                                    "SUM(CONVERT(int,ISNULL(prevesp.PREVESP, 0))) AS PREVESP, " + _
                                    "SUM(CONVERT(int,ISNULL(entrev.ENTREVISTADOS, 0))) AS ENTREVISTADOS, " + _
                                    "SUM(CONVERT(int, ISNULL(entmat.ENTMAT, 0))) AS ENTMAT, " + _
                                    "SUM(CONVERT(int,ISNULL(entvesp.ENTVESP, 0))) AS ENTVESP, " + _
                                    "SUM(CONVERT(int,ISNULL(entreg.ENTREGADOS, 0))) AS ENTREGADOS, " + _
                                    "SUM(CONVERT(int, ISNULL(entregmat.ENTREGMAT, 0))) AS ENTREGMAT, " + _
                                    "SUM(CONVERT(int,ISNULL(entregvesp.ENTREGVESP, 0))) AS ENTREGVESP, " + _
                                    "SUM(CONVERT(int,ISNULL(exa.EXAMEN, 0))) AS EXAMEN, " + _
                                    "SUM(CONVERT(int,ISNULL(examat.EXAMAT, 0))) AS EXAMAT, " + _
                                    "SUM(CONVERT(int,ISNULL(exavesp.EXAVESP, 0))) AS EXAVESP, " + _
                                    "SUM(CONVERT(int,ISNULL(ind.INDUCCION, 0))) AS INDUCCION,  " + _
                                    "SUM(CONVERT(int,ISNULL(indmat.INDMAT, 0))) AS INDMAT, " + _
                                    "SUM(CONVERT(int,ISNULL(indvesp.INDVESP, 0))) AS INDVESP, " + _
                                    "SUM(CONVERT(int,ISNULL(dic.DICTAMINADOS, 0))) AS DICTAMINADOS, " + _
                                    "SUM(CONVERT(int,ISNULL(dicmat.DICMAT, 0))) AS DICMAT, " + _
                                    "SUM(CONVERT(int,ISNULL(dicvesp.DICVESP, 0))) AS DICVESP " + _
                                    "from (select carrera, count(*) as PRERREGISTRADOS from pingreso where ciclo='" + ciclo + "' GROUP BY carrera) AS prerreg " + _
                                    "LEFT JOIN (select carrera, count(*) as PREMAT from pingreso where ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) as premat " + _
                                    "on prerreg.carrera=premat.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as PREVESP from pingreso where ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) as prevesp " + _
                                    "on prerreg.carrera=prevesp.carrera  " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREVISTADOS from pingreso where entrevista_foto = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS entrev  " + _
                                    "on prerreg.carrera= entrev.carrera  " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTMAT from pingreso where entrevista_foto = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS entmat  " + _
                                    "on prerreg.carrera= entmat.carrera  " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTVESP from pingreso where entrevista_foto = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS entvesp  " + _
                                    "on prerreg.carrera= entvesp.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREGADOS from pingreso where documentos = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS entreg  " + _
                                    "on prerreg.carrera=entreg.carrera " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREGMAT from pingreso where documentos = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS entregmat  " + _
                                    "on prerreg.carrera=entregmat.carrera   " + _
                                    "LEFT JOIN (select carrera, count(*) as ENTREGVESP from pingreso where documentos = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS entregvesp  " + _
                                    "on prerreg.carrera=entregvesp.carrera  " + _
                                    "LEFT JOIN(select carrera, count(*) as EXAMEN from pingreso where con_examen = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS exa  " + _
                                    "on prerreg.carrera=exa.carrera  " + _
                                    "LEFT JOIN(select carrera, count(*) as EXAMAT from pingreso where con_examen = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS examat " + _
                                    "on prerreg.carrera=examat.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as EXAVESP from pingreso where con_examen = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS exavesp " + _
                                    "on prerreg.carrera=exavesp.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as INDUCCION from pingreso where curso_induccion = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS ind  " + _
                                    "on prerreg.carrera=ind.carrera  " + _
                                    "LEFT JOIN(select carrera, count(*) as INDMAT from pingreso where curso_induccion = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS indmat " + _
                                    "on prerreg.carrera=indmat.carrera  " + _
                                    "LEFT JOIN(select carrera, count(*) as INDVESP from pingreso where curso_induccion = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS indvesp " + _
                                    "on prerreg.carrera=indvesp.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as DICTAMINADOS from pingreso where curso_induccion = 1 and ciclo='" + ciclo + "' GROUP BY carrera) AS dic  " + _
                                    "on prerreg.carrera=dic.carrera " + _
                                    "LEFT JOIN(select carrera, count(*) as DICMAT from pingreso where dictaminados = 1 and ciclo='" + ciclo + "' and turno=1 GROUP BY carrera) AS dicmat  " + _
                                    "on prerreg.carrera=dicmat.carrera  " + _
                                    "LEFT JOIN(select carrera, count(*) as DICVESP from pingreso where dictaminados = 1 and ciclo='" + ciclo + "' and turno=2 GROUP BY carrera) AS dicvesp  " + _
                                    "on prerreg.carrera=dicvesp.carrera  ", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'DETALLE SEGUIMIENTO
    Public Shared Function detalleSeguimiento(ByVal carrera As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT    dbo.pingreso.ustring AS FOLIO, dbo.pingreso.nombres NOMBRE , dbo.pingreso.apaterno AS APATERNO , dbo.pingreso.amaterno AS AMATERNO," +
                                    "dbo.pingreso.carrera AS CARRERA , SUBSTRING(dbo.basic_turnos.turno, 1, 1) AS TURNO," +
                                    "CASE WHEN entrevista_foto=1 THEN 'SI' ELSE 'NO' END AS ENTREVISTA, CASE WHEN documentos=1 THEN 'SI' ELSE 'NO' END AS DOCUMENTOS," +
                                    "CASE WHEN con_examen=1 THEN 'SI' ELSE 'NO' END AS EXAMEN, CASE WHEN curso_induccion=1 THEN 'SI' ELSE 'NO' END AS INDUCCION," +
                                    "CASE WHEN dictaminados=1 THEN 'SI' ELSE 'NO' END AS DICTAMINADO " +
                                    "FROM            dbo.pingreso INNER JOIN dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno " +
                                    "WHERE carrera='" + carrera + "' AND ciclo='" + ciclo + "'", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'REPORTE DE PROMEDIO DE BACHILLERATO
    'promedio + exani general
    Public Shared Function promedioAll(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno AS PATERNO, dbo.pingreso.amaterno AS MATERNO," +
                                     "dbo.pingreso.carrera AS CARRERA, dbo.basic_turnos.turno AS TURNO,dbo.pingreso.promedio AS BACHILLERATO," +
                                     "dbo.pingreso_result_ceneval.icne AS PTS, dbo.pingreso_result_ceneval.c_examen AS EXAMEN," +
                                     "(dbo.pingreso.promedio + dbo.pingreso_result_ceneval.c_examen) / 2 AS SUMA FROM dbo.pingreso INNER JOIN " +
                                     "dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno INNER JOIN dbo.pingreso_ceneval ON " +
                                     "dbo.pingreso.ustring = dbo.pingreso_ceneval.ustring INNER JOIN dbo.pingreso_result_ceneval ON " +
                                     "dbo.pingreso_ceneval.folio = dbo.pingreso_result_ceneval.folio WHERE (dbo.pingreso.ciclo = '" + ciclo + "') ORDER BY SUMA DESC", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'promedio + exani por carrera
    Public Shared Function promedioCarrera(ByVal ciclo As String, ByVal carrera As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno AS PATERNO, dbo.pingreso.amaterno AS MATERNO," +
                                     "dbo.pingreso.carrera AS CARRERA, dbo.basic_turnos.turno AS TURNO,dbo.pingreso.promedio AS BACHILLERATO," +
                                     "dbo.pingreso_result_ceneval.icne AS PTS, dbo.pingreso_result_ceneval.c_examen AS EXAMEN," +
                                     "(dbo.pingreso.promedio + dbo.pingreso_result_ceneval.c_examen) AS SUMA FROM dbo.pingreso INNER JOIN " +
                                     "dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno INNER JOIN dbo.pingreso_ceneval ON " +
                                     "dbo.pingreso.ustring = dbo.pingreso_ceneval.ustring INNER JOIN dbo.pingreso_result_ceneval ON " +
                                     "dbo.pingreso_ceneval.folio = dbo.pingreso_result_ceneval.folio WHERE (dbo.pingreso.ciclo = '" + ciclo + "') " +
                                     " AND (dbo.pingreso.carrera='" + carrera + "') ORDER BY SUMA DESC", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'promedio de bachillerato general
    Public Shared Function bachillerAll(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT  dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno AS PATERNO, dbo.pingreso.amaterno AS MATERNO, dbo.pingreso.carrera AS CARRERA, dbo.basic_turnos.turno AS TURNO," + _
                                     "dbo.pingreso.promedio BACHILLERATO FROM  dbo.pingreso INNER JOIN dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno " + _
                                     "WHERE        (dbo.pingreso.ciclo = '" + ciclo + "') ORDER BY BACHILLERATO DESC", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'promedio de bachillerato por carrera
    Public Shared Function bachillerCarrera(ByVal ciclo As String, ByVal carrera As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT  dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno AS PATERNO, dbo.pingreso.amaterno AS MATERNO, dbo.pingreso.carrera AS CARRERA, dbo.basic_turnos.turno AS TURNO," + _
                                     "dbo.pingreso.promedio BACHILLERATO FROM  dbo.pingreso INNER JOIN dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno " + _
                                     "WHERE        (dbo.pingreso.ciclo = '" + ciclo + "') AND (dbo.pingreso.carrera = '" + carrera + "') ORDER BY BACHILLERATO DESC", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'REPORTE DE ASPIRANTES QUE NO ENTREGARON CERTIFICADO
    Public Shared Function nocertificado(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT        dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno AS APATERNO , dbo.pingreso.amaterno AS AMATERNO, dbo.pingreso.carrera AS CARRERA , SUBSTRING(dbo.basic_turnos.turno, 1, 1) AS TURNO" +
                                     " ,pingreso.telfijo AS FIJO, pingreso.telmovil AS MOVIL,pingreso.otel AS OTRO,pingreso.email AS EMAIL " +
                                    " FROM dbo.pingreso INNER JOIN dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno" +
                                    " WHERE pingreso.ciclo='" + ciclo + "' AND pingreso.documentos=0 ORDER BY pingreso.carrera, pingreso.turno, pingreso.apaterno,pingreso.amaterno ASC", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'REPORTE DE ASPIRANTES GENERAL
    Public Shared Function general(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("SELECT    dbo.pingreso.ustring AS FOLIO, dbo.pingreso.nombres + ' ' + dbo.pingreso.apaterno + ' ' + dbo.pingreso.amaterno AS NOMBRE," + _
                                    "dbo.pingreso.carrera AS CARRERA , SUBSTRING(dbo.basic_turnos.turno, 1, 1) AS TURNO," + _
                                    "CASE WHEN entrevista_foto=1 THEN 'SI' ELSE 'NO' END AS ENTREVISTA, CASE WHEN documentos=1 THEN 'SI' ELSE 'NO' END AS DOCUMENTOS," + _
                                    "CASE WHEN con_examen=1 THEN 'SI' ELSE 'NO' END AS EXAMEN, CASE WHEN curso_induccion=1 THEN 'SI' ELSE 'NO' END AS INDUCCION," + _
                                    "CASE WHEN dictaminados=1 THEN 'SI' ELSE 'NO' END AS DICTAMINADO " + _
                                    "FROM            dbo.pingreso INNER JOIN dbo.basic_turnos ON dbo.pingreso.turno = dbo.basic_turnos.id_turno " + _
                                    "WHERE ciclo='" + ciclo + "'", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'REPORTE DE ESTADISTICA DE ESCUELAS DE PROCEDENCIA
    Public Shared Function procedencia(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("select  replace(SUBSTRING(prerreg.bachillerato,1,CHARINDEX(',', prerreg.bachillerato ,0)),',','') as BACHILLERATO, ISNULL(bachimat.BACHIMAT, 0) AS BACHIMAT, " +
                                    "ISNULL(bachivesp.BACHIVESP, 0) AS BACHIVESP,prerreg.TOTAL as TOTAL " +
                                    "from (select bachillerato, count(*) as BACHIMAT from pingreso where ciclo='" + ciclo + "' and turno=1 GROUP BY bachillerato) as bachimat  " +
                                    "LEFT JOIN(select bachillerato, count(*) as BACHIVESP from pingreso where ciclo='" + ciclo + "' and turno=2 GROUP BY bachillerato) as bachivesp " +
                                    "on bachimat.bachillerato=bachivesp.bachillerato  " +
                                    "LEFT JOIN ( select bachillerato, count(*) as TOTAL from pingreso where ciclo='" + ciclo + "' GROUP BY bachillerato) as prerreg " +
                                    "on bachimat.bachillerato=prerreg.bachillerato " +
                                    "UNION ALL " +
                                    "select 'TOTALES' as BACHILLERATO,  " +
                                    "SUM(CONVERT(int,ISNULL(bachimat.BACHIMAT, 0))) AS BACHIMAT, " +
                                    "SUM(CONVERT(int,ISNULL(bachivesp.BACHIVESP, 0))) AS BACHIVESP, " +
                                    "SUM(CONVERT(int,prerreg.TOTAL)) AS TOTAL " +
                                    "from (select bachillerato, count(*) as BACHIMAT from pingreso where ciclo='" + ciclo + "' and turno=1 GROUP BY bachillerato) as bachimat  " +
                                    "LEFT JOIN(select bachillerato, count(*) as BACHIVESP from pingreso where ciclo='" + ciclo + "' and turno=2 GROUP BY bachillerato) as bachivesp " +
                                    "on bachimat.bachillerato=bachivesp.bachillerato  " +
                                    "LEFT JOIN ( select bachillerato, count(*) as TOTAL from pingreso where ciclo='" + ciclo + "' GROUP BY bachillerato) as prerreg " +
                                    "on bachimat.bachillerato=prerreg.bachillerato", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'DETALLE DE BACHILLERATO
    Public Shared Function detalleBachi(ByVal nombre As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cc As New SqlDataAdapter("select programa,nombre_ct,estado,municipio,localidad,domicilio,telefono " + _
                                    "from info_prepas where nombre_ct='" + nombre + "'", c)
        Dim cct As New DataTable
        c.Open()
        cc.Fill(cct)
        c.Close()
        Return cct
    End Function

    'MEDIOS DE DIFUSION
    Public Shared Function mediosDif(ByVal ciclo As String) As DataTable
        Dim conn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim medio As New SqlDataAdapter("select medio, ISNULL(cntmat.cuentamat, 0) as cuentamat, ISNULL(cntvesp.cuentavesp, 0) as cuentavesp, IsNULL(cnt.cuenta,0) as cuenta " + _
                                        "from basic_medios as bm  " + _
                                        "Left Join " + _
                                        "(select id_razon,count(*) as cuentamat from pingreso_medios where ciclo='" + ciclo + "' and id_turno=1 group by id_razon) as cntmat " + _
                                        "on bm.id_medio=cntmat.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon,count(*) as cuentavesp from pingreso_medios where ciclo='" + ciclo + "' and id_turno=2 group by id_razon) as cntvesp " + _
                                        "on bm.id_medio=cntvesp.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon,count(*) as cuenta from pingreso_medios where ciclo='" + ciclo + "' group by id_razon) as cnt " + _
                                        "on bm.id_medio=cnt.id_razon " + _
                                        "union ALL " + _
                                        "select 'TOTALES' as medio,  " + _
                                        "SUM(CONVERT(int, ISNULL(cntmat.cuentamat, 0))) as cuentamat, " + _
                                        "SUM(CONVERT(int, ISNULL(cntvesp.cuentavesp, 0))) as cuentavesp, " + _
                                        "SUM(CONVERT(int, ISNULL(cnt.cuenta, 0))) as cuenta " + _
                                        "from basic_medios as bm  " + _
                                        "Left Join " + _
                                        "(select id_razon,count(*) as cuentamat from pingreso_medios where ciclo='" + ciclo + "' and id_turno=1 group by id_razon) as cntmat " + _
                                        "on bm.id_medio=cntmat.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon,count(*) as cuentavesp from pingreso_medios where ciclo='" + ciclo + "' and id_turno=2 group by id_razon) as cntvesp " + _
                                        "on bm.id_medio=cntvesp.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon,count(*) as cuenta from pingreso_medios where ciclo='" + ciclo + "' group by id_razon) as cnt " + _
                                        "on bm.id_medio=cnt.id_razon", conn)
        Dim mediot As New DataTable
        conn.Open()
        medio.Fill(mediot)
        conn.Close()
        Return mediot
    End Function

    'MEDIOS DE DIFUSION
    Public Shared Function razonInsc(ByVal ciclo As String) As DataTable
        Dim conn As New SqlConnection(HttpContext.Current.Application("str"))
        Dim medio As New SqlDataAdapter("select descripcion,ISNULL(rmat.razmat, 0) as razmat, ISNULL(rvesp.razvesp, 0) as razvesp, ISNULL(razon.raztot, 0) as raztot " + _
                                        "from basic_motivo_inscripcion as bm " + _
                                        "Left Join " + _
                                        "(select id_razon, count(*) as razmat from pingreso_razones where ciclo='" + ciclo + "' and id_turno=1 GROUP BY id_razon) as rmat " + _
                                        "on bm.id_motivo_inscripcion=rmat.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon, count(*) as razvesp from pingreso_razones where ciclo='" + ciclo + "' and id_turno=2 GROUP BY id_razon) as rvesp " + _
                                        "on bm.id_motivo_inscripcion=rvesp.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon, count(*) as raztot from pingreso_razones where ciclo='" + ciclo + "' GROUP BY id_razon) as razon " + _
                                        "on bm.id_motivo_inscripcion=razon.id_razon " + _
                                        "union ALL " + _
                                        "select 'TOTALES' as descripcion, " + _
                                        "SUM(CONVERT(int,ISNULL(rmat.razmat, 0))) as razmat, " + _
                                        "SUM(CONVERT(int,ISNULL(rvesp.razvesp, 0))) as razvesp, " + _
                                        "SUM(CONVERT(int,ISNULL(razon.raztot, 0))) as raztot " + _
                                        "from basic_motivo_inscripcion as bm " + _
                                        "Left Join " + _
                                        "(select id_razon, count(*) as razmat from pingreso_razones where ciclo='" + ciclo + "' and id_turno=1 GROUP BY id_razon) as rmat " + _
                                        "on bm.id_motivo_inscripcion=rmat.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon, count(*) as razvesp from pingreso_razones where ciclo='" + ciclo + "' and id_turno=2 GROUP BY id_razon) as rvesp " + _
                                        "on bm.id_motivo_inscripcion=rvesp.id_razon " + _
                                        "Left Join " + _
                                        "(select id_razon, count(*) as raztot from pingreso_razones where ciclo='" + ciclo + "' GROUP BY id_razon) as razon  " + _
                                        "on bm.id_motivo_inscripcion=razon.id_razon", conn)
        Dim mediot As New DataTable
        conn.Open()
        medio.Fill(mediot)
        conn.Close()
        Return mediot
    End Function
End Class
