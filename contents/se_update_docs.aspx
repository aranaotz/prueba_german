<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="se_update_docs.aspx.vb" Inherits="contents_se_update_docs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">

    <asp:UpdatePanel runat="server" ID="upse_docs">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_se_docs">
                <asp:View runat="server" ID="v_cero">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_recarga" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nuevo" Text="Agregar Arancel" CssClass="boton_texto_dentro" OnClick="lb_nuevo_Click" /></td>
                    </tr></table></div>
                    <table style="width:100%;">
                        <tr><td class="titulocategoria" style="text-align:center;padding-top:30px">Información de Aranceles Servicios Escolares</td></tr>
                        <tr><td class="titulocelda" style="text-align:center;padding-top:30px">Da clic sobre la descripción del documento para modificar su importe</td></tr>
                        <tr><td style="padding-top:30px">
                            <asp:GridView runat="server" ID="gv_docs" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border:solid 1px #ccc" CellPadding="5" CellSpacing="5" HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Descripción">
                                        <ItemTemplate>
                                            <div style="text-align:left">
                                                <asp:LinkButton runat="server" ID="lb_doc" Text='<%# Bind("DESCRIPCION") %>' CssClass="texto_boton_gv" OnClick="lb_doc_Click" CommandArgument='<%# Bind("DESCRIPCION") %>'></asp:LinkButton>
                                                   
                                                
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PRECIO" HeaderText="Importe" SortExpression="PRECIO" />
                                </Columns>
                            </asp:GridView>
                            </td></tr>                  
                    </table>
                   <asp:HiddenField runat="server" ID="hf_update" />
                      <ajax:ModalPopupExtender ID="mod_update" runat="server" PopupControlID="p_update" CancelControlID="ib_close" BackgroundCssClass="modalBackground_gris" 
                                                    TargetControlID="hf_update"></ajax:ModalPopupExtender>
                    <asp:Panel runat="server" ID="p_update" style="display:block;">
                            
                               <table style="width: 100%;"><tr><td style="text-align: right; padding: 7px;"><asp:ImageButton ID="ib_close" runat="server" ImageUrl="~/img/close_coe.png" /></td></tr><tr><td>
                                 <table style="background:#FFF; width:100%; border-radius: 5px;">
                                     <tr><td colspan="2" class="titulocategoria" style="text-align: center; white-space: nowrap; padding: 10px 15px 5px 15px;">Editar Arancel</td></tr>
                                     <tr><td colspan="2" style="text-align: center; padding: 0px 10px 10px 10px;">Para cambiar el precio modifique en el cuadro correspondiente <br />y presione Guardar</td></tr>
                                     <tr>
                                        <td style="text-align: center;" class="titulocategoria"><asp:Label runat="server" ID="lbl_seleccionado"></asp:Label></td>
                                     </tr>
                                     <tr>
                                        <td style="text-align: center;" class="titulocategoria"><asp:TextBox runat="server" ID="txt_importe" CssClass="tbxreg" Width="110px"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txt_importe" ErrorMessage="Debes introducir un precio!" Display="None" ControlToValidate="txt_importe"
                                                 SetFocusOnError="true" ValidationGroup="docs"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_txt_importe" TargetControlID="rfv_txt_importe" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True" ></ajax:ValidatorCalloutExtender>
                                        </td>
                                     </tr>
                     
                                     <tr>
                                        <td colspan="2" style="text-align: center; "><asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="botones" Font-Size="XX-Large" ValidationGroup="docs" OnClick="btn_guardar_Click"/></td></tr>

                                 </table></td>
                                 </tr>
                                </table>

                        </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

