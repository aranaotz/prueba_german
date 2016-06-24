<%@ Page Title="Calificación de Exámenes Finales - SADIN CGI" Language="VB" MasterPageFile="profworking.master" AutoEventWireup="false" CodeFile="finalev.aspx.vb" Inherits="finalev" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="general.css" rel="stylesheet" type="text/css" />
<link href="calendar.css" rel="stylesheet" type="text/css" />
<cc1:ToolkitScriptManager ID="sm_parcialtest" runat="server"></cc1:ToolkitScriptManager>
    <div style="padding: 10px; font-family: 'Segoe UI', 'Helvetica Neue', 'Lucida Grande', Arial, Helvetica, Verdana, sans-serif; font-size: 1em; color: #333333;">
        <table style="width:100%; text-align: center;" 
            cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table style="width:100%; text-align: justify;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding: 5px; width: 100%;">
                                La calificación que usted guarde es DEFINITIVA y NO podrá modificarla.<br />
                                </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td colspan="3" style="padding: 5px;">
                <table class="titulo_medio">
                    <tr>
                        <td style="padding: 0px 5px 0px 5px;">
                            <asp:DropDownList ID="ddl_cursos" runat="server" CssClass="droptransparent"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Imagebutton ID="cmd_mostrar" runat="server" Text="Mostrar Fechas" ImageUrl="img/arrowlogin_.png"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
            </tr>
            <tr>
                <td style="padding: 0px; text-align: center;">
                  <asp:UpdatePanel ID="up_reporte" runat="server"><ContentTemplate>
                    <asp:MultiView ID="mv_cursos" runat="server">
                        <asp:View ID="v_cursos" runat="server">
                            <div style="padding: 10px 5px 10px 5px">
                                <table style="width:100%;">
                                    <tr>
                                        <td style="text-align: left">
                                            <table>
                                                <tr>
                                                    <td style="padding: 5px 10px 5px 10px;">
                                                        Elija una fecha de clase en la cual aplicará su exámen de
                                                        <asp:Label ID="lbl_materia" runat="server"></asp:Label>
                                                        <br />
                                                        Si no aparecen fechas disponibles, asegurese que el día que 
                                                        aplicará el examen tenga reportada asistencia.</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="dl_fechas" runat="server" HorizontalAlign="Center" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5" ShowFooter="False" ShowHeader="False" CellPadding="2">
                                                <ItemStyle Height="60px" HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" Wrap="True" />
                                                <ItemTemplate>
                                                    <table class="menu_selection">
                                                        <tr>
                                                            <td style="padding: 2px 5px 2px 5px">
                                                                <asp:LinkButton ID="lb_fechas" runat="server" CssClass="boton_texto" 
                                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dd/MM/yyyy}") %>' 
                                                                    OnClick="docommand" style="text-decoration:none; color:#FFFFFF;" 
                                                                    TabIndex='<%# DataBinder.Eval(Container.DataItem,"estado") %>' 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dddd dd, MMMM yyyy}") %>' 
                                                                    ValidationGroup='<%# DataBinder.Eval(Container.DataItem,"dayclass") %>'></asp:LinkButton>
                                                                
                                                                <cc1:ConfirmButtonExtender ID="lb_fechas_cbe" runat="server" 
                                                                    ConfirmText="Está a punto de seleccionar esta fecha para aplicar el examen parcial para este curso, esta fecha NO PODRÁ SER CAMBIADA. Después de seleccionar una fecha, vuelva a hacer click sobre la fecha para introducir las calificaciones. ¿Desea continuar?" 
                                                                    Enabled="True" TargetControlID="lb_fechas">
                                                                </cc1:ConfirmButtonExtender>
                                                                
                                                            </td>
                                                            <td style="padding-right: 4px; padding-left: 4px">
                                                                <asp:Image ID="im_st" runat="server" style="width: 42px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           
                                            </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="v_alumnos" runat="server">
                            <div>
                                <table style="margin: auto; text-align: center;">
                                    <tr>
                                        <td style="text-align: left">
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 5px; padding-left: 5px;">
                                                        Introduzca las calificaciones para el curso
                                                        <asp:Label ID="lbl_materiar" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hf_fecha" runat="server" />
                                                        <asp:HiddenField ID="hf_icu" runat="server" />
                                                        <asp:HiddenField ID="hf_msg" runat="server" />
                                                        <cc1:ModalPopupExtender ID="hf_msg_mpe" runat="server" 
                                                            BackgroundCssClass="modalBackground_gris" CancelControlID="ib_closewin" 
                                                            DynamicServicePath="" Enabled="True" PopupControlID="p_msg" 
                                                            TargetControlID="hf_msg">
                                                        </cc1:ModalPopupExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="margin: auto; padding-top: 10px; text-align: center;">
                                            <asp:GridView ID="gv_alumnos" runat="server" AutoGenerateColumns="False" foreColor="Black" GridLines="none" HorizontalAlign="Center">
                                                <alternatingRowStyle BackColor="#fcf9f9" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hf_matr" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"matr") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Alumno" DataField="fname" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Evaluación"><ItemTemplate>
                                                    <asp:TextBox ID="tbx_pex" runat="server" CssClass="tbxlogin" MaxLength="3" Width="50px" ReadOnly='<%# DataBinder.Eval(Container.DataItem,"enable") %>' Text='<%# DataBinder.Eval(Container.DataItem,"calif") %>'></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="tbx_pex_ftbe" runat="server" Enabled="True" 
                                                            TargetControlID="tbx_pex" ValidChars="1234567890.">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="cause" HeaderText="Tipo" />
                                                </Columns>
                                                <HeaderStyle Height="25px" CssClass="percent"/>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:Panel ID="p_msg" runat="server" style="display:none;">
                                        <table style="width: 300px">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="text-align: right; padding-right: 5px; padding-bottom: 5px;">
                                                    <asp:ImageButton ID="ib_closewin" runat="server" 
                                                        ImageUrl="img/close-alt_small.png" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" 
                                                        style="border: 1px solid #FF3300; background-color: #FFFFFF;">
                                                        <tr>
                                                            <td style="padding: 5px; background-color: #FF3300; color: #FFFFFF; font-weight: bold; font-family: verdana; font-size: 7.5pt;">
                                                                Mensaje de Examenes Parciales</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="color: #000066; padding: 5px">
                                                                <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                            </td>
                                    </tr>
                                </table>
                                <table style="margin: auto; border-width: 1px; border-color: #66CCFF; width: 100%; background-color: #EAEAFF; border-top-style: solid; border-bottom-style: solid; text-align: center;" 
                                    cellpadding="0" cellspacing="0"><tr><td style="padding: 5px; text-align: center">
                                            <asp:Button ID="cmd_definitivo" runat="server" CssClass="botones_minis" 
                                                Text="Guardar Calificaciones" />
                                        </td></tr></table>
                            </div>
                    </asp:View>
                    </asp:MultiView>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmd_mostrar" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>
                     <cc1:UpdatePanelAnimationExtender ID="up_reporte_aex" runat="server" 
                        Enabled="True" TargetControlID="up_reporte">
                        <Animations>
                             <OnUpdating>
                                   <Parallel duration="0.5" fps="30">
                                   <FadeOut AnimationTarget="up_reporte" minimumOpacity="0" ForceLayoutInIE="true"/>
                                   </Parallel>
                            </OnUpdating>
                            <OnUpdated>
                                 <Parallel duration="0.5" fps="30">
                                   <FadeIn Animationtarget="up_reporte" minimumOpacity="0" ForceLayoutInIE="true"/>
                                   </Parallel>
                              </OnUpdated>
                    </Animations>
                    </cc1:UpdatePanelAnimationExtender>
                  </td>
            </tr>
        </table>
    </div> 
</asp:Content>
