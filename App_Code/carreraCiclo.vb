Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web

Public Class carreraCiclo

    Shared Function carga_carrera(ByVal conn As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(conn)
        Dim tc As New SqlDataAdapter("SELECT sett_carrera.cv_carrera as CLAVE,sett_carrera.nombre as CARRERA, sett_turnos.turno as TURNO FROM sett_carrera LEFT JOIN sett_turnos ON sett_carrera.turno=sett_turnos.id_turno WHERE ciclo='" + ciclo + "' ORDER BY sett_carrera.nombre", c)
        Dim ctc As New DataTable 'ctc=carga tabla carreras
        c.Open()
        tc.Fill(ctc)
        c.Close()
        carga_carrera = ctc
    End Function

    Public Shared Function carga_turno() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim turno As New SqlDataAdapter("SELECT id_turno, turno FROM sett_turnos ORDER BY id_turno", c)
        Dim turnot As New DataTable
        c.Open()
        turno.Fill(turnot)
        c.Close()
        Return turnot
    End Function

    Public Shared Function carga_periodos() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim periodo As New SqlDataAdapter("SET LANGUAGE 'Español'" + _
                                          "SELECT ciclo AS CICLO,fechas AS FECHAS," + _
                                          "convert(varchar(12),startdate,113)  AS INICIO," + _
                                          "convert(varchar(12),finaldate,113) AS FIN,active AS ACTIVO FROM general_ciclos " + _
                                          "ORDER BY ciclo DESC", c)

        Dim periodot As New DataTable
        c.Open()
        periodo.Fill(periodot)
        c.Close()
        Return periodot
    End Function





    Public Shared Function carga_periodos_pi() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim periodo As New SqlDataAdapter("SET LANGUAGE 'Español'" + _
                                         "SELECT ciclo AS CICLO," + _
                                         "convert(varchar(12),startdate,113)  AS INICIO," + _
                                         "convert(varchar(12),enddate,113) AS FIN," + _
                                         "convert(varchar(12),entrevistas_fin,113),AS CIERRE/ENTREVISTAS" + _
                                         "convert(varchar(12),fecha_examen,113) AS EXAMEN," + _
                                         "active AS ACTIVO FROM basic_pi_ciclos " + _
                                         "ORDER BY ciclo DESC", c)
        Dim periodot As New DataTable
        c.Open()
        periodo.Fill(periodot)
        c.Close()
        Return periodot
    End Function


    'Public Shared Function carga_cv_carrera() As DataTable
    '    Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '    Dim cv_carrera As New SqlDataAdapter("SELECT id, cv_carrera FROM sett_carrera", c)
    '    Dim cv_carrerat As New DataTable
    '    c.Open()
    '    cv_carrera.Fill(cv_carrerat)
    '    c.Close()
    '    Return cv_carrerat
    'End Function

    Shared Function llena_carrera(ByVal cv_carrera As String, ByVal nombre As String, ByVal ciclo As String, ByVal turno As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlDataAdapter("INSERT INTO sett_carrera (cv_carrera, nombre, ciclo, turno) VALUES ('" + cv_carrera + "','" + nombre + "','" + ciclo + "','" + turno + "')", c)
        Dim insertat As New DataTable
        c.Open()
        inserta.Fill(insertat)
        c.Close()
        Return insertat
    End Function

    Public Shared Function llena_periodo(ByVal ciclo As String, ByVal inicio As String, ByVal fin As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim llenap As New SqlDataAdapter("INSERT INTO general_ciclos (ciclo, startdate, finaldate) VALUES ('" + ciclo + "','" + inicio + "','" + fin + "')", c)
        Dim llenapt As New DataTable
        c.Open()
        llenap.Fill(llenapt)
        c.Close()
        Return llenapt
    End Function
    Public Shared Function llena_periodo_pi(ByVal ciclo As String, ByVal inicio As String, ByVal fin As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim llenap As New SqlDataAdapter("INSERT INTO basic_pi_ciclos (ciclo, startdate, enddate) VALUES ('" + ciclo + "','" + inicio + "','" + fin + "')", c)
        Dim llenapt As New DataTable
        c.Open()
        llenap.Fill(llenapt)
        c.Close()
        Return llenapt
    End Function

    Public Shared Function cargaCarreras() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim carrera As New SqlDataAdapter("SELECT id_carrera,nombre from info_carreras", c)
        Dim carrerat As New DataTable
        c.Open()
        carrera.Fill(carrerat)
        c.Close()
        Return carrerat
    End Function

    Public Shared Function cargaTurno() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim turno As New SqlDataAdapter("SELECT id_turno,turno from basic_turnos", c)
        Dim turnot As New DataTable
        c.Open()
        turno.Fill(turnot)
        c.Close()
        Return turnot
    End Function

    'cargar turnos activos
    Public Shared Function cargaTurnoActivo(ByVal ciclo As String, ByVal carrera As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim turno As New SqlDataAdapter("SELECT id_turno,turno from info_turnoscarrera where activo=1 and ciclo='" + ciclo + "' and cve_carrera='" + carrera + "'", c)
        Dim turnot As New DataTable
        c.Open()
        turno.Fill(turnot)
        c.Close()
        Return turnot
    End Function

    'ACTUALIZA LA TABLA INFO_TURNOSCARRERA
    Public Shared Function actualizaOferta(ByVal id As String, ByVal turno As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim oferta As New SqlDataAdapter("UPDATE info_turnoscarrera set activo=1 WHERE id_carrera='" + id + "' AND turno= UPPER('" + turno + "')", c)
        Dim ofertat As New DataTable
        c.Open()
        oferta.Fill(ofertat)
        c.Close()
        Return ofertat
    End Function
    'una sola pagina
    Public Shared Function llenaCiclo() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ciclo As New SqlDataAdapter("SET LANGUAGE 'Español' SELECT ciclo as CICLO,((((datename(month,[startdate])+' - ')+datename(month,[enddate]))+'  ')+datename(year,[enddate])) as FECHAS, convert(VARCHAR(12), startdate,113) as INICIO,convert(VARCHAR(12), " +
                                        "enddate,113) AS FIN,active AS ACTIVO from basic_pi_ciclos ORDER BY ciclo desc", c)
        Dim ciclot As New DataTable
        c.Open()
        ciclo.Fill(ciclot)
        c.Close()
        Return ciclot
    End Function

    Public Shared Function detalleCiclo(ByVal ci As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ciclo As New SqlDataAdapter("SELECT ciclo, CONVERT(varchar(11), startdate, 111) AS startdate, " +
                            "CONVERT (varchar(11), enddate, 111) AS enddate," +
                            "CONVERT (varchar(11), entrevistas_fin,111) AS entrevistas_fin," +
                            "CONVERT (varchar(11), fecha_examen,111) AS fecha_examen," +
                            "CONVERT (varchar(11), documentos_inicio,111) AS documentos_inicio," +
                            "CONVERT (varchar(11), documentos_fin,111) AS documentos_fin, docsxdia," +
                            "active FROM basic_pi_ciclos " +
                            "WHERE (ciclo = '" + ci + "')", c)
        Dim ciclot As New DataTable
        c.Open()
        ciclo.Fill(ciclot)
        c.Close()
        Return ciclot
    End Function

    Public Shared Sub actualizaCiclo(ByVal inicio As String, ByVal fin As String, ByVal entrevista As String, ByVal examen As String, ByVal docini As String, ByVal docfin As String, ByVal activo As String, ByVal ci As String, ByVal docsxdia As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ciclo As New SqlCommand("UPDATE [basic_pi_ciclos] SET [startdate] = '" + inicio + "', [enddate] = '" + fin + "', [entrevistas_fin] = '" + entrevista + "',[documentos_inicio]='" + docini + "', [documentos_fin]='" + docfin + "', [fecha_examen] = '" + examen + "', [active] = '" + activo + "', [docsxdia] ='" + docsxdia + "' WHERE [ciclo] = '" + ci + "'", c)
        c.Open()
        ciclo.ExecuteNonQuery()
        c.Close()
    End Sub

    Public Shared Sub actualizaCiclo_general(ByVal inicio As String, ByVal fin As String, activo As String, ByVal ci As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actgen As New SqlCommand("UPDATE general_ciclos SET startdate = '" + inicio + "', finaldate = '" + fin + "', active = '" + activo + "' WHERE ciclo = '" + ci + "'", c)
        c.Open()
        actgen.ExecuteNonQuery()
        c.Close()
    End Sub

    Public Shared Function carreraActiva(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim activo As New SqlDataAdapter("SELECT dbo.info_turnoscarrera.id,      dbo.info_carreras.nivel, dbo.info_carreras.nombre, dbo.info_turnoscarrera.turno, dbo.info_turnoscarrera.ciclo" + _
                                            " FROM            dbo.info_carreras INNER JOIN" + _
                                             " dbo.info_turnoscarrera ON dbo.info_carreras.cv_carrera = dbo.info_turnoscarrera.cve_carrera COLLATE Modern_Spanish_CI_AS" + _
                                            " WHERE        (dbo.info_turnoscarrera.activo = 1)  AND (dbo.info_turnoscarrera.ciclo= '" + ciclo + "')" + _
                                            " ORDER BY dbo.info_carreras.nombre, dbo.info_turnoscarrera.turno", c)
        Dim activot As New DataTable
        c.Open()
        activo.Fill(activot)
        c.Close()
        Return activot
    End Function

    Public Shared Function carreraNoActiva(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim activo As New SqlDataAdapter("SELECT         dbo.info_carreras.nivel, dbo.info_carreras.cv_carrera, dbo.info_carreras.nombre, dbo.basic_turnos.turno, dbo.basic_turnos.id_turno" +
                                            " FROM            dbo.basic_turnos CROSS JOIN" +
                                            " dbo.info_carreras" +
                                            " WHERE dbo.info_carreras.activo=1 AND ((dbo.info_carreras.cv_carrera + dbo.basic_turnos.turno + '" + ciclo + "') NOT IN" +
                                            " (SELECT        cve_carrera COLLATE Modern_Spanish_CI_AS + turno + ciclo AS EXPR1" +
                                            " FROM            dbo.info_turnoscarrera))" +
                                            " ORDER BY dbo.info_carreras.nombre, dbo.basic_turnos.turno", c)
        Dim activot As New DataTable
        c.Open()
        activo.Fill(activot)
        c.Close()
        Return activot
    End Function


    Public Shared Sub insertaCarrera(ByVal clave As String, ByVal turno As String, ByVal ciclo As String, ByVal id As String)

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlCommand("insert into info_turnoscarrera(registro_carrera,cve_carrera,turno, ciclo, id_turno,activo ) values (substring ('" + turno + "',1,1)+'" + clave + "','" + clave + "','" + turno + "','" + ciclo + "','" + id + "',1)", c)

        c.Open()
        inserta.ExecuteNonQuery()
        c.Close()
    End Sub
    Public Shared Sub eliminaCarrera(ByVal id As String)

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlCommand("delete from info_turnoscarrera where id='" + id + "'", c)

        c.Open()
        inserta.ExecuteNonQuery()
        c.Close()
    End Sub

    'Insertar dias en info_dias no-------------------------

    Public Shared Sub insertaDias(ByVal ciclo As String, ByVal fecha As String)

        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim inserta As New SqlCommand("insert into info_diasno (ciclo,mes,dia,fecha,hora,habilitado,tarea,css,cve_carrera) " + _
                                      "select '" + ciclo + "' as ciclo,DATEPART(MONTH, CONVERT(date,'" + fecha + "')) as mes, DATEPART(DAY, CONVERT(date,'" + fecha + "')) as dia," + _
                                      "'" + fecha + "' as fecha, hora,'0' as habilitado,'CITA_ENTREVISTA_CONTROL_ESCOLAR' as tarea,'dia_normal' as css," + _
                                      "cv_carrera as carrera from info_horaentrevista CROSS JOIN info_carreras", c)

        c.Open()
        inserta.ExecuteNonQuery()
        c.Close()
    End Sub

    'Public Shared Function listaCarreras(ByVal ciclo As String) As DataTable
    '    Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    '    Dim turnos As New SqlDataAdapter("SELECT dbo.info_turnoscarrera.registro_carrera AS REGISTRO,  dbo.info_turnoscarrera.cve_carrera as CARRERA, dbo.info_carreras.nombre AS NOMBRE, dbo.info_turnoscarrera.turno AS TURNO " + _
    '                                     "FROM  dbo.info_carreras INNER JOIN dbo.info_turnoscarrera ON dbo.info_carreras.cv_carrera = dbo.info_turnoscarrera.cve_carrera COLLATE Modern_Spanish_CI_AS " + _
    '                                     "WHERE (dbo.info_turnoscarrera.activo = 1) AND (dbo.info_turnoscarrera.ciclo = '" + ciclo + "') ORDER BY dbo.info_carreras.nombre", c)
    '    Dim turnost As New DataTable
    '    c.Open()
    '    turnos.Fill(turnost)
    '    c.Close()
    '    Return turnost

    'End Function

    'Listado de cursos de induccion
    Public Shared Function listaTurnosCarrera(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim turnos As New SqlDataAdapter("SELECT  distinct   dbo.info_turnoscarrera.cve_carrera AS CARRERA, dbo.info_carreras.nombre AS NOMBRE " + _
                                         "FROM  dbo.info_carreras INNER JOIN dbo.info_turnoscarrera ON dbo.info_carreras.cv_carrera = dbo.info_turnoscarrera.cve_carrera COLLATE Modern_Spanish_CI_AS " + _
                                         "WHERE  (dbo.info_turnoscarrera.ciclo = '" + ciclo + "')", c)
        Dim turnost As New DataTable
        c.Open()
        turnos.Fill(turnost)
        c.Close()
        Return turnost

    End Function

    Public Shared Function listaTurnosCarrera() As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim turnos As New SqlDataAdapter("select id_turno, upper(turno) as turno from basic_turnos", c)
        Dim turnost As New DataTable
        c.Open()
        turnos.Fill(turnost)
        c.Close()
        Return turnost

    End Function

    'Listado por carrera 
    Public Shared Function listado(ByVal clave As String, ByVal turno As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("select ustring,nombres AS NOMBRE, apaterno AS PATERNO, amaterno AS MATERNO from pingreso where carrera='" + clave + "' and turno='" + turno + "'", c)
        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    Public Shared Function listado_propedeutico_xcarreras(ByVal clave As String, ByVal turno As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lpxc As New SqlDataAdapter("select rank() OVER (ORDER BY pi.apaterno, pi.amaterno,pi.nombres) R,pi.ustring,pi.nombres AS NOMBRE, pi.apaterno AS PATERNO, pi.amaterno AS MATERNO, pi.apaterno + ' ' + pi.amaterno + ' ' + pi.nombres as COMPLETO, " +
                                       "CASE WHEN ISNULL(pic.dia1,'0')='1' THEN 'PRESENTE' ELSE '' END PRNT_DIA1,CASE WHEN ISNULL(pic.dia2,'0')='1' THEN 'PRESENTE' ELSE '' END PRNT_DIA2, " +
                                       "CASE WHEN ISNULL(pic.dia3,'0')='1' THEN 'PRESENTE' ELSE '' END PRNT_DIA3, " +
                                       "CASE WHEN pic.ustring Is NULL then '0' ELSE '1' END AS ins_or_upd, pi.carrera, ISNULL(pic.dia1,0) as dia1, ISNULL(pic.dia2,0) as dia2, " +
                                       "ISNULL(pic.dia3,0) as dia3,pic.css, pi.turno from pingreso as pi LEFT JOIN pingreso_cinduccion as pic on pi.ustring=pic.ustring where pi.carrera='" + clave + "' " +
                                       "and pi.turno='" + turno + "' and pi.entrevista_foto=1 and pi.documentos=1 and pi.con_examen=1 AND pi.ciclo='" + ciclo + "' ORDER BY R", c)
        Dim lpxct As New DataTable
        c.Open()
        lpxc.Fill(lpxct)
        c.Close()
        Return lpxct
    End Function


    '-----------CODIGO PARA CHECKDAY-----------------------

    Public Shared Function fechas(ByVal ciclo As String, ByVal inicio As String, ByVal fin As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("SET LANGUAGE 'Español' " + _
                                        "select DISTINCT fecha as FECHA,CONVERT (varchar(11), fecha, 111) AS FECHACORTA,DATENAME(mm, fecha) as MES,mes as NUMMES,dia as DIA, DATENAME(dw, fecha) as NOMBREDIA, habilitado as ACTIVO " + _
                                        "from info_diasno where ciclo='" + ciclo + "' and fecha BETWEEN '" + inicio + "' and '" + fin + "'  ORDER BY  fecha asc", c)


        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    Public Shared Function diaActivo(ByVal ciclo As String, ByVal inicio As String, ByVal fin As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("SET LANGUAGE 'Español' " + _
                                        "select DISTINCT fecha as FECHA,CONVERT (varchar(11), fecha, 111) AS FECHACORTA,DATENAME(mm, fecha) as MES,mes as NUMMES,dia as DIA, DATENAME(dw, fecha) as NOMBREDIA, habilitado as ACTIVO " + _
                                        "from info_diasno where ciclo='" + ciclo + "' and habilitado='1' and tarea='CITA_ENTREVISTA_CONTROL_ESCOLAR'  ORDER BY  fecha asc", c)


        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    Public Shared Sub habilitaLista(ByVal ciclo As String, ByVal inicio As String, fin As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actgen As New SqlCommand("update info_diasno set habilitado='1', css='dia_normal', tarea='CITA_ENTREVISTA_CONTROL_ESCOLAR' where ciclo='" + ciclo + "' AND fecha BETWEEN '" + inicio + "' and '" + fin + "'", c)
        c.Open()
        actgen.ExecuteNonQuery()
        c.Close()
    End Sub

    Public Shared Sub habilita(ByVal ciclo As String, ByVal mes As String, ByVal dia As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actgen As New SqlCommand("update info_diasno set habilitado='1', css='dia_normal' where ciclo='" + ciclo + "' and mes='" + mes + "' and dia='" + dia + "' ", c)
        c.Open()
        actgen.ExecuteNonQuery()
        c.Close()
    End Sub
    Public Shared Sub deshabilita(ByVal ciclo As String, ByVal mes As String, ByVal dia As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actgen As New SqlCommand("update info_diasno set habilitado='0', css='' where ciclo='" + ciclo + "' and mes='" + mes + "' and dia='" + dia + "' ", c)
        c.Open()
        actgen.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub elimina_ciclo_diasno(ByVal ciclo As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ecd As New SqlCommand("delete from info_diasno where ciclo='" + ciclo + "' AND tarea='CITA_ENTREVISTA_CONTROL_ESCOLAR'", c)
        c.Open()
        ecd.ExecuteNonQuery()
        c.Close()
    End Sub

    'CODIGO PARA DICTAMEN

    'dicaminar a todos lo alumons que cumplan con los requisitos, sin el resultado del examen 
    Public Shared Sub activaDicataminar(ByVal numero As String, ByVal carrera As String, ByVal turno As String, ByVal ciclo As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        ' Dim actgen As New SqlCommand("SET ROWCOUNT " + numero + " UPDATE pingreso set dictaminados = 1 WHERE entrevista_foto = 1 AND documentos = 1 AND con_examen = 1 AND curso_induccion = 1 " +
        '                              "AND carrera='" + carrera + "' AND turno='" + turno + "' AND ciclo = '" + ciclo + "'", c)
        Dim actgen As New SqlCommand("update pingreso set dictaminados=1 where id in (select top(" + numero + ") id from pingreso WHERE entrevista_foto = 1 AND documentos = 1 AND con_examen = 1 " +
                                     "AND curso_induccion = 1 And carrera='" + carrera + "' AND turno='" + turno + "' AND ciclo = '" + ciclo + "' order by suma_calificacion desc)", c)
        c.Open()
        actgen.ExecuteNonQuery()
        c.Close()
    End Sub

    'habilita campo dictaminado seleccionado del gridview 
    Public Shared Sub habilitaDictaminados(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actgen As New SqlCommand("UPDATE pingreso set dictaminados=1 WHERE ustring='" + ustring + "'", c)
        c.Open()
        actgen.ExecuteNonQuery()
        c.Close()
    End Sub

    'habilita campo dictaminado seleccionado del gridview 
    Public Shared Sub deshabilitaDictaminados(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim actgen As New SqlCommand("UPDATE pingreso set dictaminados=0 WHERE ustring='" + ustring + "'", c)
        c.Open()
        actgen.ExecuteNonQuery()
        c.Close()
    End Sub

    'lista de aspirantes que cumplieron los requisitos
    Public Shared Function dicatamen(ByVal carrera As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("SELECT dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno AS PATERNO, dbo.pingreso.amaterno AS MATERNO,dbo.pingreso.carrera AS CARRERA, dbo.pingreso.ustring as FOLIO," + _
                                        "dbo.basic_turnos.turno AS TURNO,dbo.pingreso.turno AS ID, pingreso.promedio AS BACHILLERATO,pingreso_result_ceneval.c_examen AS EXANI,(dbo.pingreso.promedio +dbo.pingreso_result_ceneval.c_examen) / 2 AS SUMA, dbo.pingreso.dictaminados AS DICTAMINADO " + _
                                        "FROM dbo.basic_turnos INNER JOIN dbo.pingreso ON dbo.basic_turnos.id_turno = dbo.pingreso.turno " + _
                                        "INNER JOIN dbo.pingreso_ceneval ON dbo.pingreso.ustring = dbo.pingreso_ceneval.ustring " + _
                                        "INNER JOIN dbo.pingreso_result_ceneval ON dbo.pingreso_ceneval.folio = dbo.pingreso_result_ceneval.folio " + _
                                        "WHERE(dbo.pingreso.entrevista_foto = 1) AND (dbo.pingreso.documentos = 1) AND (dbo.pingreso.con_examen = 1) " + _
                                        "AND (dbo.pingreso.curso_induccion = 1) AND (dbo.pingreso.ciclo = '" + ciclo + "') AND (dbo.pingreso.carrera = '" + carrera + "') " + _
                                        "ORDER BY TURNO ASC,SUMA DESC", c)
        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    'lista de aspirantes que cumplieron todos los requisitos filtrado por turno 
    Public Shared Function dicatamenFiltrado(ByVal carrera As String, ByVal ciclo As String, ByVal turno As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("SELECT dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno AS PATERNO, dbo.pingreso.amaterno AS MATERNO,dbo.pingreso.carrera AS CARRERA, dbo.pingreso.ustring as FOLIO," +
                                        "dbo.basic_turnos.turno AS TURNO,dbo.pingreso.turno AS ID, pingreso.promedio AS BACHILLERATO,pingreso_result_ceneval.c_examen AS EXANI,dbo.pingreso.promedio + dbo.pingreso_result_ceneval.c_examen AS SUMA, dbo.pingreso.dictaminados AS DICTAMINADO " +
                                        "FROM dbo.basic_turnos INNER JOIN dbo.pingreso ON dbo.basic_turnos.id_turno = dbo.pingreso.turno " +
                                        "INNER JOIN dbo.pingreso_ceneval ON dbo.pingreso.ustring = dbo.pingreso_ceneval.ustring " +
                                        "INNER JOIN dbo.pingreso_result_ceneval ON dbo.pingreso_ceneval.folio = dbo.pingreso_result_ceneval.folio " +
                                        "WHERE(dbo.pingreso.entrevista_foto = 1) AND (dbo.pingreso.documentos = 1) AND (dbo.pingreso.con_examen = 1) " +
                                        "AND (dbo.pingreso.curso_induccion = 1) AND (dbo.pingreso.ciclo = '" + ciclo + "') AND (dbo.pingreso.carrera = '" + carrera + "') AND(dbo.pingreso.turno='" + turno + "') " +
                                        "ORDER BY SUMA DESC", c)
        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    'Lista para dictaminar aspirantes manualmente

    Public Shared Function dictamenManual(ByVal ustring As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("SELECT pi.ustring as USTRING, pi.nombres AS NOMBRES, pi.apaterno AS PATERNO, pi.amaterno AS MATERNO, pi.carrera AS CARRERA, bt.turno AS TURNO," + _
                                        "pi.dictaminados AS DICTAMINADO from pingreso as pi INNER JOIN basic_turnos as bt ON pi.turno=bt.id_turno" + _
                                        " WHERE pi.ustring='" + ustring + "'", c)
        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    'Actualizar el dictamen para dictaminar manualmente

    Public Shared Sub actualizaDictamenManual(ByVal ustring As String, ByVal ci As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ciclo As New SqlCommand("UPDATE pingreso set entrevista_foto=1,documentos=1,con_examen=1,curso_induccion=1,dictaminados=1,ciclo='" + ci + "' " + _
                                    "WHERE ustring='" + ustring + "'", c)
        c.Open()
        ciclo.ExecuteNonQuery()
        c.Close()
    End Sub

    Public Shared Sub deshabilitaDictamenManual(ByVal ustring As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ciclo As New SqlCommand("UPDATE pingreso set entrevista_foto=1,documentos=1,con_examen=1,curso_induccion=0,dictaminados=1 " + _
                                    "WHERE ustring='" + ustring + "'", c)
        c.Open()
        ciclo.ExecuteNonQuery()
        c.Close()
    End Sub
    'datos de la tabla de resultados de ceneval
    Public Shared Function dicatamen(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim lista As New SqlDataAdapter("Select * from pingreso_result_ceneval where ciclo='" + ciclo + "'", c)


        Dim listat As New DataTable
        c.Open()
        lista.Fill(listat)
        c.Close()
        Return listat
    End Function

    'Valida que la que el registro no exista informacion con el ciclo correspondiente
    Public Shared Function validaCiclo(ByVal ciclo As String) As Boolean
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim valida As New SqlCommand("select case WHEN count(*)>0 THEN '1' else '0' END as duplicado from pingreso_result_ceneval where ciclo='" + ciclo + "'", c)
        c.Open()
        validaCiclo = valida.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function carreras_ya_importadas(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cyi As New SqlDataAdapter("select distinct CARRERA,ic.nombre, '1' as enable, '10' as candidatos FROM (Select dbo.pingreso_result_ceneval.folio AS FOLIO, dbo.pingreso.ustring As CLAVE, dbo.pingreso.nombres AS NOMBRE, " +
        "dbo.pingreso.apaterno As PATERNO, dbo.pingreso.amaterno AS MATERNO, dbo.pingreso.carrera As CARRERA, dbo.pingreso.turno AS TURNO, dbo.pingreso.promedio As BACHILLERATO, " +
        "dbo.pingreso_result_ceneval.c_examen AS EXAMEN, ((dbo.pingreso.promedio + dbo.pingreso_result_ceneval.c_examen) / 2) AS SUMA FROM dbo.pingreso_ceneval INNER Join dbo.pingreso_result_ceneval " +
        "ON dbo.pingreso_ceneval.folio = dbo.pingreso_result_ceneval.folio INNER Join dbo.pingreso ON dbo.pingreso_ceneval.ustring = dbo.pingreso.ustring WHERE (dbo.pingreso.entrevista_foto = 1) " +
        "And (dbo.pingreso.documentos = 1) And (dbo.pingreso.con_examen = 1) And (dbo.pingreso.curso_induccion = 1) And (pingreso.ciclo='" + ciclo + "')) AS BASE LEFT JOIN info_carreras as ic on ic.cv_carrera COLLATE Modern_Spanish_CS_AS=CARRERA", c)
        Dim cyit As New DataTable
        c.Open()
        cyi.Fill(cyit)
        c.Close()
        Return cyit
    End Function

    'codigo para pagina desactivado.aspx


    Shared Function desactivado() As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim up As New SqlCommand("SET LANGUAGE 'Español' select (DATENAME(DD,startdate)+' de ' + DATENAME(MM,startdate)+ ' de ' + DATENAME(YEAR,startdate)) as fecha from basic_pi_ciclos where active=1", c)
        c.Open()
        desactivado = up.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function carreras_propedeutico(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cp As New SqlDataAdapter("SELECT  distinct   itc.cve_carrera AS CARRERA, ica.nombre AS NOMBRE, convert(varchar,ISNULL(ccnt.aspirantes,0)) + ' (' +  " +
            "convert(varchar,ISNULL(mattable.matutino,0)) + ' MAT - ' + convert(varchar,ISNULL(vesptable.vespertino,0)) + ' VESP)' as CANDIDATOS, " +
            "convert(varchar,CASE WHEN (ISNULL(ccnt.aspirantes,0))=0 THEN 0 ELSE 1 END) enable FROM  dbo.info_carreras as ica INNER JOIN dbo.info_turnoscarrera as itc " +
            "ON ica.cv_carrera = itc.cve_carrera COLLATE Modern_Spanish_CI_AS left join (select carrera,count(*) as aspirantes from pingreso where entrevista_foto=1 and " +
            "documentos=1 And con_examen=1 and dictaminados=0 And ciclo='" + ciclo + "' group by carrera) as ccnt on itc.cve_carrera=ccnt.carrera left join (select basic_turnos.turno,carrera,count(*) as matutino " +
            "from pingreso left join basic_turnos on pingreso.turno=basic_turnos.id_turno where entrevista_foto=1 And documentos=1 And con_examen=1 and pingreso.turno='1' and dictaminados=0 and ciclo='" + ciclo + "' " +
            "group by carrera,basic_turnos.turno) as mattable on itc.cve_carrera=mattable.carrera left join (select basic_turnos.turno,carrera,count(*) as vespertino from pingreso " +
            "left join basic_turnos on pingreso.turno=basic_turnos.id_turno where entrevista_foto=1 And documentos=1 And con_examen=1 and pingreso.turno='2' and dictaminados=0 and ciclo='" + ciclo + "' group by carrera," +
            "basic_turnos.turno) as vesptable on itc.cve_carrera=vesptable.carrera WHERE  (itc.ciclo = '" + ciclo + "')", c)
        Dim cpt As New DataTable
        c.Open()
        cp.Fill(cpt)
        c.Close()
        Return cpt
    End Function

    Shared Function carreras_dictaminados(ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cp As New SqlDataAdapter("SELECT  distinct   itc.cve_carrera AS CARRERA, ica.nombre AS NOMBRE, " +
            "convert(varchar,ISNULL(ccnt.aspirantes,0)) + ' (' +  convert(varchar,ISNULL(mattable.matutino,0)) + ' MAT - ' + convert(varchar,ISNULL(vesptable.vespertino,0)) + ' VESP)' as CANDIDATOS, " +
            "convert(varchar,CASE WHEN (ISNULL(ccnt.aspirantes,0))=0 THEN 0 ELSE 1 END) enable, " +
            "case when ISNULL(importados.CARRERA,'0')='0' THEN 'Sin importar' ELSE 'Importado' END as IMPORTADO " +
            "FROM  dbo.info_carreras as ica INNER JOIN dbo.info_turnoscarrera as itc ON ica.cv_carrera = itc.cve_carrera COLLATE Modern_Spanish_CI_AS " +
            "left join (select carrera,count(*) as aspirantes from pingreso where entrevista_foto=1 And documentos=1 And con_examen=1 And curso_induccion=1 And ciclo='" + ciclo + "' group by carrera) as ccnt  " +
            "on itc.cve_carrera=ccnt.carrera left join (select basic_turnos.turno,carrera,count(*) as matutino from pingreso left join basic_turnos on pingreso.turno=basic_turnos.id_turno " +
            "where entrevista_foto=1 And documentos=1 And con_examen=1 And pingreso.turno='1' and curso_induccion=1 and ciclo='" + ciclo + "' group by carrera,basic_turnos.turno) as mattable on itc.cve_carrera=mattable.carrera " +
            "left join (select basic_turnos.turno,carrera,count(*) as vespertino from pingreso left join basic_turnos on pingreso.turno=basic_turnos.id_turno  " +
            "where entrevista_foto=1 And documentos=1 And con_examen=1 And pingreso.turno='2' and curso_induccion=1 and ciclo='" + ciclo + "' group by carrera,basic_turnos.turno) as vesptable on itc.cve_carrera=vesptable.carrera " +
            "LEFT JOIN (select distinct CARRERA FROM (Select dbo.pingreso_result_ceneval.folio AS FOLIO, dbo.pingreso.ustring As CLAVE, " +
            "dbo.pingreso.nombres AS NOMBRE, dbo.pingreso.apaterno As PATERNO, dbo.pingreso.amaterno AS MATERNO, dbo.pingreso.carrera As CARRERA, dbo.pingreso.turno AS TURNO, " +
            "dbo.pingreso.promedio As BACHILLERATO, dbo.pingreso_result_ceneval.c_examen AS EXAMEN, ((dbo.pingreso.promedio + dbo.pingreso_result_ceneval.c_examen) / 2) AS SUMA " +
            "FROM dbo.pingreso_ceneval INNER Join dbo.pingreso_result_ceneval ON dbo.pingreso_ceneval.folio = dbo.pingreso_result_ceneval.folio " +
            "INNER Join dbo.pingreso ON dbo.pingreso_ceneval.ustring = dbo.pingreso.ustring " +
            "WHERE (dbo.pingreso.entrevista_foto = 1) And (dbo.pingreso.documentos = 1) And (dbo.pingreso.con_examen = 1) And (dbo.pingreso.curso_induccion = 1) And (pingreso.ciclo='" + ciclo + "')) AS BASE " +
            "LEFT JOIN info_carreras as ic on ic.cv_carrera COLLATE Modern_Spanish_CS_AS=CARRERA) as importados on itc.cve_carrera=importados.CARRERA " +
            "WHERE  (itc.ciclo = '" + ciclo + "')", c)
        Dim cpt As New DataTable
        c.Open()
        cp.Fill(cpt)
        c.Close()
        Return cpt
    End Function

    Shared Function or_de_3(ByVal i1 As String, ByVal i2 As String, ByVal i3 As String) As String
        If i1 = 0 And i2 = 0 And i3 = 1 Then
            or_de_3 = ""
        ElseIf i1 = 0 And i2 = 1 And i3 = 0 Then
            or_de_3 = ""
        ElseIf i1 = 0 And i2 = 1 And i3 = 1 Then
            or_de_3 = "gvrow_green"
        ElseIf i1 = 1 And i2 = 0 And i3 = 0 Then
            or_de_3 = ""
        ElseIf i1 = 1 And i2 = 0 And i3 = 1 Then
            or_de_3 = "gvrow_green"
        ElseIf i1 = 1 And i2 = 1 And i3 = 0 Then
            or_de_3 = "gvrow_green"
        ElseIf i1 = 1 And i2 = 1 And i3 = 1 Then
            or_de_3 = "gvrow_green"
        Else
            or_de_3 = ""
        End If
    End Function

    Shared Sub insertar_pingreso_cinduccion(ByVal ustring As String, ByVal carrera As String, ByVal turno As String, ByVal cbx1 As String, ByVal cbx2 As String, ByVal cbx3 As String, ByVal css As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ipc As New SqlCommand("insert into pingreso_cinduccion (ustring,carrera,turno,dia1,dia2,dia3,css) VALUES ('" + ustring + "','" + carrera + "','" + turno + "','" + cbx1 + "', " +
                                  "'" + cbx2 + "','" + cbx3 + "','" + css + "') ", c)
        Dim updpi As New SqlCommand("update pingreso set curso_induccion='" + IIf(css = "", "0", "1") + "' where ustring='" + ustring + "'", c)
        c.Open()
        ipc.ExecuteNonQuery()
        updpi.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Sub actualizar_pingreso_cinduccion(ByVal ustring As String, ByVal carrera As String, ByVal turno As String, ByVal cbx1 As String, ByVal cbx2 As String, ByVal cbx3 As String, ByVal css As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ipc As New SqlCommand("update pingreso_cinduccion set carrera='" + carrera + "', turno='" + turno + "',dia1='" + cbx1 + "',dia2='" + cbx2 + "',dia3='" + cbx3 + "',css='" + css + "' " +
                                  "where ustring='" + ustring + "'", c)
        Dim updpi As New SqlCommand("update pingreso set curso_induccion='" + IIf(css = "", "0", "1") + "' where ustring='" + ustring + "'", c)
        c.Open()
        ipc.ExecuteNonQuery()
        updpi.ExecuteNonQuery()
        c.Close()
    End Sub

    'Actualiza pingreso_ceneval cuando subes el archivo de exani

    Shared Sub acualizaCeneval(ByVal icne As String, ByVal folio As String, ByVal calificacion As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ci As New SqlCommand("UPDATE pingreso_ceneval set pts='" & icne & "',calificacion='" & calificacion & "' WHERE folio='" & folio & "'", c)
        c.Open()
        ci.ExecuteNonQuery()
        c.Close()
    End Sub

    'elimina en pingreso_result_ceneval para no insertar repetidos

    Shared Sub eliminaResultCeneval(ByVal folio As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ci As New SqlCommand("delete from pingreso_result_ceneval where folio='" & folio & "'", c)
        c.Open()
        ci.ExecuteNonQuery()
        c.Close()
    End Sub

    'inserta el resultado del exani en pingreso_result_ceneval
    Shared Sub insertaResultCeneval(ByVal folio As String, ByVal icne As String, ByVal calificacion As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ci As New SqlCommand("insert into pingreso_result_ceneval (folio,icne,c_examen) values ('" + folio + "','" + icne + "','" + calificacion + "')", c)
        c.Open()
        ci.ExecuteNonQuery()
        c.Close()
    End Sub

    'Selecciona el ustring a partir del folio
    Shared Function selectUstring(ByVal folio As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim cic As New SqlCommand("select case when count(*)>0 then 1 else 0 end ustring from pingreso_ceneval where folio='" + folio + "'", c)
        Dim boolval As String
        c.Open()
        boolval = cic.ExecuteScalar.ToString()
        c.Close()
        If boolval = True Then
            Dim ci As New SqlCommand("select ISNULL(ustring,'0') ustring from pingreso_ceneval where folio='" + folio + "'", c)
            c.Open()
            selectUstring = ci.ExecuteScalar.ToString()
            c.Close()
        Else
            selectUstring = "0"
        End If
    End Function


    'Actualiza calificacion de examen en pingreso
    Shared Sub acualizaPingresoCeneval(ByVal ustring As String, ByVal calificacion As String)
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ci As New SqlCommand("UPDATE pingreso set calificacion_examen='" + calificacion + "' where ustring='" + ustring + "'", c)
        c.Open()
        ci.ExecuteNonQuery()
        c.Close()
    End Sub

    Shared Function carrera_nivel(ByVal cv_carrera As String, ByVal turnotext As String, ByVal ciclo As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim ci As New SqlDataAdapter("select nombre,nivel,'" + turnotext + "' turno, '" + ciclo + "' ciclo from info_carreras where cv_carrera='" + cv_carrera + "'", c)
        Dim cit As New DataTable
        c.Open()
        ci.Fill(cit)
        c.Close()
        Return cit
    End Function
End Class
