<%@ Page Title="Mensajes personalizados Synrate" Language="VB" MasterPageFile="profworking.master" AutoEventWireup="false" CodeFile="mensajes.aspx.vb" Inherits="mensajes" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="general.css" rel="stylesheet" type="text/css" />
<link href="calendar.css" rel="stylesheet" type="text/css" />
    <div style="padding: 10px 30px 30px 30px; font-family: 'Segoe UI', Arial, Helvetica, sans-serif;">
    <asp:ToolkitScriptManager ID="sm_1" runat="server"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="up_msgs" runat="server"><ContentTemplate>
        <table align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3" class="titulo_medio">
                    Su bandeja de mensajes Importantes...</td>
            </tr>
            <tr>
                <td colspan="3" style="padding: 10px; vertical-align: middle; text-align: center; font-size: 12pt; font-weight: bold;">
                    <asp:Label ID="lbl_nombre" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding: 10px">
                    Atienda los siguientes mensajes generados por la institución. Si ya ha leido alguno y no desea verlos mas, haga click en esconder.</td>
            </tr>
            <tr>
                <td colspan="3" class="background_blanco">
                    <asp:GridView ID="gv_mensajes" runat="server" AutoGenerateColumns="False" 
                        HorizontalAlign="Center" GridLines="None" Width="95%">
                        <Columns>
                            <asp:BoundField HeaderText="Emisor" DataField="emisor" />
                            <asp:BoundField HeaderText="Asunto" DataField="titulo" />
                            <asp:BoundField HeaderText="Nivel" DataField="importancia" />
                            <asp:TemplateField><ItemTemplate>
                            <asp:ImagebUtton ID="cmd_ok" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' Text="Mostrar mensaje" CommandName='<%# DataBinder.Eval(Container.DataItem,"idm") %>' OnClick="viewm" ImageUrl="~/synprof/img/play.png" />
                            </ItemTemplate></asp:TemplateField>
                        </Columns>
                        <HeaderStyle ForeColor="White" Height="30px" />
                       </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                <asp:HiddenField ID="hf_mensaje" runat="server" />
                     <asp:ModalPopupExtender ID="hf_mensaje_mpe" runat="server" 
                        CancelControlID="ib_close" DynamicServicePath="" Enabled="True" 
                        PopupControlID="p_msg" TargetControlID="hf_mensaje" 
                        BackgroundCssClass="modalBackground_gris">
                    </asp:ModalPopupExtender>
                     <asp:Panel ID="p_msg" runat="server" style="display:table;">
                                    <table style="min-width: 80%; max-width: 100%">
                                        <tr>
                                            <td style="padding-bottom: 7px; padding-left: 7px; padding-right: 7px; text-align: right;">
                                                <asp:ImageButton ID="ib_close" runat="server" ImageUrl="img/close-alt.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table class="background_blanco_1" 
                                                    align="center">
                                                    <tr>
                                                        <td style="padding: 7px; text-align: center; color: #000000; font-size: 2em;">
                                                            Mensaje</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 10px; color: #333333; text-align: center;">
                                                            <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 10px 5px 10px 5px; color: #CC0000; font-weight: bold; text-align: right;">
                                                            <asp:LinkButton ID="cmd_hide" runat="server" Text="Marcar como Leído" CssClass="boton_texto" />
                                                            <%'<asp:Button ID="cmd_hide" runat="server" Text="Esconder mensaje" /> %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel></td>
                <td>
                    &nbsp;</td>
            </tr>
        </table></ContentTemplate></asp:UpdatePanel>
    </div>
</asp:Content>

