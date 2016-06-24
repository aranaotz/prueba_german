<%@ Page Title="Recuperación de Contraseña - UTSyn 2015" Language="VB" MasterPageFile="masters/synwol.master" AutoEventWireup="false" CodeFile="sendquery.aspx.vb" Inherits="sendquery" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <div class="centrado"><table style="width: 100%;"><tr><td style="text-align:center;" class="titulocategoria">Recuperación de contraseña SIAAA</td></tr>
        <tr><td class="medio_titulo">Escribe tu matrícula de estudiante en la caja de texto.<br />
            <span class="auto-style1">Si es un trabajador académico o administrativo escriba su nombre de usuario.</span><br /> <strong>En caso de que la matrícula o el usuario se encuentren en la base de datos, SIAAA hara envío de un correo (a la dirección registrada en SIAAA) con instrucciones para recuperar la contraseña de forma segura.</strong></td></tr>
        <tr><td style="padding: 20px;">
            <asp:UpdatePanel ID="up_recover" runat="server" UpdateMode="Conditional"><ContentTemplate>
            <asp:Timer ID="t_action" runat="server" Interval="5000" OnTick="t_action_Tick"></asp:Timer>
            <asp:MultiView ID="mv_recovery" runat="server">
            <asp:View ID="v_query" runat="server">
                <table style="width: 100%"><tr><td><asp:TextBox ID="tbx_recover" runat="server" CssClass="wmlogin" ValidationGroup="recover"></asp:TextBox></td></tr>
                    <tr><td style="padding: 10px;">
                        <table class="centrado"><tr><td>
                        <asp:Button ID="cmd_recover" runat="server" Text="Enviar" ValidationGroup="recover" CssClass="botones" style="font-size: 100%;" />
                        </td><td style="padding-left: 20px;">
                            <asp:Button ID="cmd_cancelar" runat="server" Text="Cancelar" CausesValidation="false" />
                             </td></tr></table>
                        </td></tr></table>

                    <asp:RequiredFieldValidator ID="rfv_tbx_recover" runat="server" ErrorMessage="Escribe tu matricula o nombre de usuario." 
                        Display="None" ControlToValidate="tbx_recover" SetFocusOnError="True" ValidationGroup="recover"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_recover" runat="server" TargetControlID="rfv_tbx_recover" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    <%-- <asp:RegularExpressionValidator ID="rev_tbx_recover" runat="server" Display="None" ErrorMessage="La matricula solo debe contener números." 
                        ControlToValidate="tbx_recover" ValidationGroup="recover" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_rev_tbx_recover" runat="server" TargetControlID="rev_tbx_recover" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>
            </asp:View>
            <asp:View ID="v_ok" runat="server">
                <div style="padding: 20px;"><p><img alt="Error" src="../img/ok_green.png" /></p><p>Se ha enviado al correo registrado de la matricula escrita (si existe).<br />Buscalo en bandeja de entrada o en no deseados, algunos clientes suelen catalogar asi este tipo de correo.<br />Sigue las indicaciónes que te enviamos en el correo.</p></div>
            </asp:View>
                </asp:MultiView></ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="t_action" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel></td></tr>
         </table></div>
</asp:Content>

