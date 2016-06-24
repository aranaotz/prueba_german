<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="validacurp.aspx.vb" Inherits="contents_validacurp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">

     <asp:UpdatePanel runat="server" ID="up_curp">

         <ContentTemplate>

             <asp:MultiView runat="server" ID="mv_general">

                 <asp:View runat="server" ID="v_cero">

                     <div style="text-align:center; padding-top:300px">

                         <table style="width:100%">
                             <tr><td class="titulocategoria" style="text-align:center"><bold>Atención</bold></td></tr>
                             <tr><td class="tituloceldaNegrita" style="text-align:center">Antes de comenzar con tu Registro introduce tu CURP, por favor</td></tr>
                             <tr><td class="tituloceldaNegrita" style="text-align:center"><asp:TextBox runat="server" ID="tbx_curp" CssClass="tbxreg_min" Width="250px"></asp:TextBox>
                                 
                                 </td></tr>
                             <tr><td class="tituloceldaNegrita" style="text-align:center"><asp:Button runat="server" ID="cmd_continuar" Text="Continuar" CssClass="botones" Font-Size="Medium" ValidationGroup="curp" /></td></tr>
                         </table>
                          
                     </div>
                             <asp:RequiredFieldValidator ID="rfv_tbx_curp" runat="server" ErrorMessage="¡Debes de proporcionarnos la CURP para tu registro!." 
                            Display="None" ControlToValidate="tbx_curp" SetFocusOnError="True" ValidationGroup="curp"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_curp" runat="server" TargetControlID="rfv_tbx_curp" CloseImageUrl="../img/close_coe.png" 
                                CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="rev_tbx_curp" runat="server" Display="None" ErrorMessage="No parece una CURP válida :(, captura en mayúsculas." 
                                ControlToValidate="tbx_curp" ValidationGroup="curp" SetFocusOnError="true" ValidationExpression="^[A-Z]{1}[AEIOUX]{1}[A-Z]{2}((\d{2}((0[13578]|1[02])(0[1-9]|[12][0-9]|3[01])|(0[13-9]|1[0-2])(0[1-9]|[12][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8])))|([02468][048]|[13579][26])0229)[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]$"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_curp_2" runat="server" TargetControlID="rev_tbx_curp" CloseImageUrl="../img/close_coe.png" 
                                CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                            </asp:View>
                
                  <asp:View ID="v_error" runat="server">
                        <%--<div>Error al dar de alta porque ya existe el usuario.</div>--%>
                        <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Intentar de nuevo" CssClass="boton_texto_dentro"/></td>
                                    </tr></table></div>
                                <div class="centrado" style="text-align:center;">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="img_error" ImageUrl="~/img/alert.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:( ups!</div>
                                    <div class="titulocelda" style="text-align:center">¡Ya existe un registro con ese CURP!<br /> Si deseas realizar una nueva inscripción o cambiar de aspiración por favor ponte en contacto al siguiente teléfono: (33) 3030-0900 Opción 2</div>
                                </div>
                    </asp:View>
             </asp:MultiView>

         </ContentTemplate>

     </asp:UpdatePanel>

</asp:Content>

