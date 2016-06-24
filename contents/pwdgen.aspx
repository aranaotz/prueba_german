﻿<%@ Page Title="Recuperacion de Contraseña - UTJ 2015" Language="VB" MasterPageFile="masters/methods.master" AutoEventWireup="false" CodeFile="pwdgen.aspx.vb" Inherits="pwdgen" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <div><table style="width: 100%"><tr><td style="font-size: 2em; padding: 30px 10px 30px 10px;">Herramienta de restauración de contraseña de UTSyn</td></tr>
                <tr><td>Escribe la nueva contraseña en ambas cajas de texto. Pulsa Aplicar cambio para terminar.<br />Te enviaremos a que pruebes tu nueva contraseña.</td></tr>
                <tr><td style="padding: 15px;"><asp:Panel ID="p_pwd" runat="server" DefaultButton="cmd_cambio">
            <table style="margin: auto;">
                <tr><td>Nueva contraseña</td><td style="padding: 5px;"><asp:TextBox ID="tbx_contra" runat="server" ValidationGroup="contra" TextMode="Password" CssClass="wmlogin" MaxLength="20" Width="250px"></asp:TextBox>
                </td></tr>
                <tr><td>otra vez...</td><td style="padding: 5px;"><asp:TextBox ID="tbx_contran" runat="server" ValidationGroup="contra" TextMode="Password" CssClass="wmlogin" MaxLength="20" Width="250px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="rfv_tbx_contra" runat="server" ErrorMessage="¡Para cambiar contraseña es necesario escribir algo!." 
                        Display="None" ControlToValidate="tbx_contra" SetFocusOnError="True" ValidationGroup="contra"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_contra" runat="server" TargetControlID="rfv_tbx_contra" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="rev_tbx_contra" runat="server" Display="None" ErrorMessage="Por favor solo escribe carácteres alfanuméricos" 
                        ControlToValidate="tbx_contra" ValidationGroup="contra" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
                    <asp:ValidatorCalloutExtender ID="vco_rev_tbx_contra" runat="server" TargetControlID="rev_tbx_contra" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    <asp:CompareValidator ID="cv_tbx_contra_n" runat="server" ErrorMessage="¡Las contraseñas con no son idénticas!." 
                        ControlToCompare="tbx_contra" ControlToValidate="tbx_contran" ValidationGroup="contra" Display="None"></asp:CompareValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_cv_tbx_contra_n" runat="server" TargetControlID="cv_tbx_contra_n" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    </td></tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="padding: 30px;">
                        <asp:Button ID="cmd_cambio" runat="server" Text="Aplicar cambio" ValidationGroup="contra" />
                    </td>
                </tr>
                </table></asp:Panel></td></tr></table></div>
</asp:Content>
