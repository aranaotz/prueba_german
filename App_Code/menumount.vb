Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Public Class menumount

    Shared Function mount_cesc(ByVal cs As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim mc As New SqlDataAdapter("SELECT id_menu, menu_text, menu_popup, css, enable FROM menus_syncesc_mom WHERE visible=1", c)
        Dim mct As New DataTable
        c.Open()
        mc.Fill(mct)
        c.Close()
        mount_cesc = mct
    End Function

    Shared Function mount_cesc_inside(ByVal cs As String, ByVal id_menu As String) As DataTable
        Dim c As New SqlConnection(cs)
        Dim mci As New SqlDataAdapter("SELECT id_submenu, submenu_text, submenu_popup, submenu_command, css, enable FROM menus_syncesc_daug WHERE visible=1 AND id_menu='" + id_menu + "'", c)
        Dim mcit As New DataTable
        c.Open()
        mci.Fill(mcit)
        c.Close()
        mount_cesc_inside = mcit
    End Function

    'Shared Function submenu(ByVal id_menu As String, ByVal id_dpto As String) As DataTable
    ' Dim c As New SqlConnection(HttpContext.Current.Application("str"))
    ' Dim mci As New SqlDataAdapter("SELECT id_submenu, submenu_text, submenu_popup, submenu_command, css, enable FROM menus_subapp WHERE visible=1 AND id_menu='" + id_menu + "' AND prtnc='" + id_dpto + "'", c)
    ' Dim mcit As New DataTable
    '     c.Open()
    '     mci.Fill(mcit)
    '     c.Close()
    '     submenu = mcit
    ' End Function

    Shared Function menu(ByVal id_dpto As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mc As New SqlDataAdapter("SELECT id_menu, menu_text, menu_popup, css, enable FROM menus_app WHERE visible=1 AND prtnc='" + id_dpto + "'", c)
        Dim mct As New DataTable
        c.Open()
        mc.Fill(mct)
        c.Close()
        menu = mct
    End Function

    Shared Function tablamenu(ByVal user As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tm As New SqlDataAdapter("select ip.id_page,ip.nombre, ip.image, ip.css, ip.enable, ip.extenso, ip.ruta from user_access as ua inner join info_userpriv as ip " + _
                                     "on ua.id_page=ip.id_page where ua.usuario='" + user + "' and ip.active=1 order by ua.orden", c)
        Dim tmt As New DataTable
        c.Open()
        tm.Fill(tmt)
        c.Close()
        Return tmt
    End Function

    Shared Function gname(ByVal usuario As String, ByVal tabla As String, ByVal camponombre As String, ByVal camporeferencia As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        'Dim gn As New SqlCommand("select nombre_completo from " + tabla + " where usuario='" + usuario + "'", c)
        Dim gn As New SqlCommand("select " + camponombre + " from " + tabla + " where " + camporeferencia + "='" + usuario + "'", c)
        c.Open()
        gname = gn.ExecuteScalar.ToString
        c.Close()
    End Function

    Shared Function topmenu(ByVal usuario As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim tm As New SqlDataAdapter("select nombre,cabezal_num,css,enable,active,extenso,'" + usuario + "' as usuario from info_userpriv as iup inner join " + _
                                     "(select distinct pertenece from info_userpriv as ip inner join user_access as ua on ip.id_page=ua.id_page where ua.usuario='" + usuario + "') as priv " + _
                                     "on iup.id_page=priv.pertenece where cabezal='1' order by cabezal_orden", c)
        Dim tmt As New DataTable
        c.Open()
        tm.Fill(tmt)
        c.Close()
        Return tmt
    End Function

    Shared Function submenu(ByVal cabezalitem As String, ByVal itembound As String, ByVal usuario As String) As DataTable
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim sm As New SqlDataAdapter("select nombre,ruta,css,enable,active,extenso,'" + itembound + "' as itembound, '" + usuario + "' as usuario from info_userpriv " +
                                     "inner join (select id_page from user_access where usuario='" + usuario + "') as acs on acs.id_page=info_userpriv.id_page " +
                                     "where cabezal='0' and pertenece='" + cabezalitem + "' order by submenu_orden", c)
        Dim smt As New DataTable
        c.Open()
        sm.Fill(smt)
        c.Close()
        Return smt
    End Function

    Shared Function menufoto(ByVal usuario As String) As String
        Dim c As New SqlConnection(HttpContext.Current.Application("str"))
        Dim mf As New SqlCommand("select photo from user_users where usuario='" + usuario + "'", c)
        Try
            c.Open()
            menufoto = mf.ExecuteScalar.ToString
            c.Close()
        Catch ex As Exception
            menufoto = "..\docstock\admindocs\images\defaultimg.jpg"
        End Try
    End Function

End Class
