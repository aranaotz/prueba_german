<%@ Page Language="VB" AutoEventWireup="false" CodeFile="glogin.aspx.vb" Inherits="glogin" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="html">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="favicon.ico" />
    <link href="glogin.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:300' rel='stylesheet' type='text/css'/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido a SIAAA - Universidad Tecnológica de Jalisco</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="sm_login" runat="server"></asp:ToolkitScriptManager>
     <%'<div style="position: relative; top:50px; left: 50px; height: 70px;"><img src="img/lutj_.png" alt="Universidad Tecnologica de Jalisco" /></div> %>
     <%'<img src="img/lgm.png" alt="Universidad Tecnologica de Jalisco" /> %>
     <div class="divlogin" style="padding-bottom:250px;">
              
    
        <asp:UpdatePanel ID="up_login" runat="server"><ContentTemplate>
       
      <asp:Panel ID="p_login" runat="server" DefaultButton="ib_login">
        <table class="tablelogin"><tr><td class="sysratelogin" style="text-align: center;">Bienvenido <br />a SIAAA</td></tr><tr><td class="celllogin" style="padding-top: 2em;">
        <asp:TextBox ID="tbx_usuario" runat="server" CssClass="tbxlogin" TabIndex="1" ValidationGroup="login"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ErrorMessage="Ingresa correctamente tu usuario." Display="None" ControlToValidate="tbx_usuario" SetFocusOnError="True" ValidationGroup="login"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="vco_usuario" runat="server" TargetControlID="rfv_usuario" CloseImageUrl="img/close_coe.png" CssClass="customCalloutStyle" WarningIconImageUrl="img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
            <asp:FilteredTextBoxExtender ID="tbx_usuario_filtro" runat="server" TargetControlID="tbx_usuario" FilterMode="InvalidChars" InvalidChars="!&quot;#$%&amp;/()='¿?¡+*~][}{-:,;."></asp:FilteredTextBoxExtender>
        <asp:TextBoxWatermarkExtender ID="tbx_usuario_wme" runat="server" Enabled="True" TargetControlID="tbx_usuario" WatermarkText="Usuario" WatermarkCssClass="wmlogin">
        </asp:TextBoxWatermarkExtender>
            
            </td><td class="cellloginbutton" style="padding-top: 2em;" rowspan="2">
                <asp:ImageButton ID="ib_login" runat="server" ImageUrl="img/arrowlogin_.png" TabIndex="3" CausesValidation="true" ValidationGroup="login"/></td></tr><tr><td class="celllogin">
        <asp:TextBox ID="tbx_password" runat="server" TextMode="Password" CssClass="tbxlogin" TabIndex="2" ValidationGroup="login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="La contraseña no puede ir en blanco." Display="None" ControlToValidate="tbx_password" ValidationGroup="login"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vco_password" runat="server" TargetControlID="rfv_password" CssClass="customCalloutStyle" CloseImageUrl="img/close_coe.png" WarningIconImageUrl="img/alert_yel.png"></asp:ValidatorCalloutExtender>
                        <asp:FilteredTextBoxExtender ID="tbx_password_filtro" runat="server" TargetControlID="tbx_password" FilterMode="InvalidChars" InvalidChars="!&quot;#$%&amp;/()=?¡'¿¨*+}{][-:;"></asp:FilteredTextBoxExtender>
        </td></tr>
            <tr><td><asp:LinkButton ID="lb_lostp" runat="server" Text="¿Olvidaste tu clave? ¡Ingresa aquí para recuperarla!" CssClass="boton_discreto" Style="white-space:nowrap;"></asp:LinkButton></td></tr><tr>
                <td class="celllogin" colspan="2"><asp:Timer ID="t_error" runat="server" Interval="2000" Enabled="False"></asp:Timer>
                    <asp:Panel ID="p_error" runat="server">
                    <div style="padding: 10px;"><asp:Label ID="lbl_error" runat="server" CssClass="errorlbl"></asp:Label></div>
                    </asp:Panel>
                </td>
            </tr>
            <tr><td>

                <div class="div_aviso">
                     <span style="font-size: 1.3em; white-space: nowrap; display: table; border-collapse:collapse; margin: auto; color: #ffffff">¿Quieres estudiar en la UTJ?, haz click en</span><br /> 
                     <span style="font-size: 1.3em; white-space: nowrap; display: table; border-collapse:collapse; margin: auto; color: #ffffff"><asp:Linkbutton ID="lb_registro" runat="server" Text="Registro de aspirantes"
                           CssClass="boton_texto_ampliar" CausesValidation="false" PostBackUrl="~/synpin/pinreg.aspx" TabIndex="4"></asp:Linkbutton></span>
                         <asp:ModalPopupExtender ID="lb_registro_mpe" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="lb_registro" PopupControlID="p_mensaje" BackgroundCssClass="modalBackground_gris" CancelControlID="ib_close">
                         </asp:ModalPopupExtender>
                   
                         <asp:Panel ID="p_mensaje" runat="server" style="display: none;">
                          <table><tr><td style="text-align: right; padding: 5px;"><asp:ImageButton ID="ib_close" runat="server" ImageUrl="img/close_coe.png" /></td></tr><tr><td>
                              <table class="popupanel" style="text-align: left;"><tr>
                                  <td style="text-align: center;"><img src="img/logosolo_.png" width="30"/></td><td><a href="http://siaaa.utj.edu.mx/siaaa/basedocs/info/Manual_Registro_Aspitantes.pdf" class="linkbuttons" target="_blank">Procedimientos</a>
                              </td></tr>
                              <tr>
                                  <td style="text-align: center;"><img src="img/logosolo_.png" width="30"/></td><td><a href="http://siaaa.utj.edu.mx/siaaa/basedocs/info/Díptico_de_trámites_a_seguir.pdf" class="linkbuttons" target="_blank">Requisitos</a></td>
                              </tr>
                              <tr>
                                  <td style="text-align: center;"><img src="img/marker.png" width="15"/></td><td><a href="http://siaaa.utj.edu.mx/siaaa/contents/validacurp.aspx" class="linkbuttons" target="_blank">Registro de Solicitud</a></td>
                              </tr>
                                  <tr>
                                  <td style="text-align: center;"><img src="img/ceneval.png" width="30"/></td><td><a href="http://www.utj.edu.mx/finanzas/SERVICIOS%20ESCOLARES/Guia%20EXANI-II%20Sep%202015.pdf" class="linkbuttons" target="_blank">Guía de estudios CENEVAL</a></td>
                              </tr>
                              <tr>
                                  <td style="text-align: center;"><img src="img/ceneval.png" width="30"/></td><td><a href="http://registroenlinea.ceneval.edu.mx/RegistroLinea/indexCerrado.php" class="linkbuttons" target="_blank">Registro de CENEVAL</a></td></tr></table></td>
                              </tr>
                             </table>
                         </asp:Panel>
                   </div>

                </td></tr>
            </table></asp:Panel></ContentTemplate></asp:UpdatePanel></div>
        
        
        <%'<div class="piepage">Synrate v.2.1 - Universidad Tecnológica de la Zona Metropolitana de Guadalajara</div> %>
        <%'<asp:Panel ID="p_bottom" runat="server" style="background-color: #fcf9f9; width: 100%;"><table class="titulo_medio"><tr><td style="padding: 0px 10px 0px 0px;"><img src="img/utzmg_mini.png" alt="Universidad Tecnologica de la Zona Metropolitana de Guadalajara" width="60"/></td>
           '<td style="padding: 5px; vertical-align: top;"><img src="img/lgm.png" alt="Universidad Tecnologica de la Zona Metropolitana de Guadalajara" /></td></tr></table></asp:Panel>
        '<asp:AlwaysVisibleControlExtender ID="av_p_bottom" runat="server" TargetControlID="p_bottom" HorizontalSide="Center" VerticalSide="Bottom" VerticalOffset="0"></asp:AlwaysVisibleControlExtender>%>
        <asp:panel ID="p_foot" runat="server" style="background-color: #f9fcfc; width: 100%; text-align: center; top: 12px; left: 0px; position: absolute;" CssClass="bottombar_shadow">
     <div><table class="centrado"><tr><td><div style="position: relative; bottom:80px; right: 0px; height: 70px;"><img src="img/logosolo.png" alt="Universidad Tecnologica de Jalisco" width="370"/></div></td>
         <td>

             <div><ul><li style="display: inline-block;display: inline-block;list-style-type: none;padding-right: 20px;">
                 <a href="http://www.sep.gob.mx/" target="_blank"><img alt="logo" src="http://www.utj.edu.mx/images/imagen_institucional/partners/logo_sep.png" 
                     border="0"></a></li><li style="display: inline-block;display: inline-block;list-style-type: none;padding-right: 20px;">
                         <a href="http://www.jalisco.gob.mx/es/dependencias/secretaria-de-innovacion-ciencia-y-tecnologia" target="_blank">
                             <img alt="Inovacion" src="http://www.utj.edu.mx/images/imagen_institucional/partners/Inovacion.png" height="50" 
                                 width="152"></a></li><li style="display: inline-block;display: inline-block;list-style-type: none;padding-right: 20px;">
                                     <a href="http://www.jaltec.mx/" target="_blank"><img alt="logo jaltec 2013-75" 
                                         src="http://www.utj.edu.mx/images/banners/logo_jaltec_2013-75.png" height="50" width="65"></a></li>
                 <li style="display: inline-block;display: inline-block;list-style-type: none;padding-right: 20px;"><a href="http://www.abs-qe.com/es/" 
                     target="_blank"><img alt="logo" src="http://www.utj.edu.mx/images/imagen_institucional/partners/logo_eagle.png" border="0"></a></li>
                 <li style="display: inline-block;display: inline-block;list-style-type: none;padding-right: 20px;"><a href="http://www.anab.org/" 
                     target="_blank"><img alt="logo" src="http://www.utj.edu.mx/images/imagen_institucional/partners/logo_anab.png" border="0"></a></li>
                 <li style="display: inline-block;display: inline-block;list-style-type: none;padding-right: 20px;"><a href="http://www.abs-qe.com/es/" 
                     target="_blank"><img alt="logo" src="http://www.utj.edu.mx/images/imagen_institucional/partners/logo_abs.png" border="0"></a></li>
                 <li style="display: inline-block;display: inline-block;list-style-type: none;padding-right: 20px;">
                     <a href="http://www.inmujeres.gob.mx/index.php/modelo-de-equidad-de-genero" target="_blank"><img alt="logo" 
                         src="http://www.utj.edu.mx/images/imagen_institucional/partners/logo_shape.png"></a></li></ul></div><div class="clearbreak"></div>

         </td></tr></table></div></asp:panel>
        <asp:AlwaysVisibleControlExtender ID="p_foot_wme" runat="server" Enabled="True" HorizontalSide="Center" TargetControlID="p_foot" VerticalSide="Bottom">
        </asp:AlwaysVisibleControlExtender>
    </form>
</body>
</html>