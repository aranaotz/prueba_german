<%@ Page Title="Evaluacion de Asistencia - SADIN CGI 2010" Language="VB" MasterPageFile="profworking.master" AutoEventWireup="false" CodeFile="asevaluation.aspx.vb" Inherits="asevaluation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="prof.css" rel="stylesheet" type="text/css" />
    <div style="padding: 10px; font-family: 'Segoe UI', 'Helvetica Neue', 'Lucida Grande', Arial, Helvetica, Verdana, sans-serif; color: #333333;">
    <cc1:ToolkitScriptManager ID="sm_asistencias" runat="server"></cc1:ToolkitScriptManager>
        <table style="width: 100%; text-align: center;" cellpadding="0" cellspacing="0"><tr>
                <td><table style="width: 100%; text-align: justify;">
                        <tr><td style="padding: 5px">
                                La Asistencia se califica Diariamente. 3 retardos equivalen a una falta en le mismo periodo de evaluación.
                                <br />Para que un reporte sea tomado en cuenta, éste debe tener estado ENVIADO DEFINITIVO
                                </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 5px;">
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
                <td style="padding: 5px; text-align: center">
                    <asp:UpdateProgress ID="up_asistencias" runat="server" DisplayAfter="100">
                   <ProgressTemplate>
                        <iframe frameborder="0" src="about:blank" class="esperando_iframe"></iframe>
                        <div class="esperando">Espere un momento...</div>
                    </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
            <tr>
                <td>
                <div>
                <asp:UpdatePanel ID="up_reporte" runat="server"><ContentTemplate>
                    <asp:MultiView ID="mv_cursos" runat="server">
                        <asp:View ID="v_cursos" runat="server">
                            <div style="padding: 10px 5px 10px 5px">
                                <table style="width:100%;">
                                    <tr>
                                        <td style="text-align: left">
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 10px; padding-left: 10px">
                                                        Fechas de reporte de para 
                                                        <asp:Label ID="lbl_materia" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="hf_msg" runat="server" />
                                    <cc1:ModalPopupExtender ID="hf_msg_mpe" runat="server" DynamicServicePath="" 
                                        Enabled="True" TargetControlID="hf_msg" CancelControlID="ib_closewin" PopupControlID="p_msg" BackgroundCssClass="modalBackground_gris"></cc1:ModalPopupExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="dl_fechas" runat="server" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" CellSpacing="5" ShowFooter="False" ShowHeader="False" CellPadding="2">
                                                <ItemStyle Height="60px" HorizontalAlign="Center" VerticalAlign="Middle" Width="33%" Wrap="True" />
                                                <ItemTemplate>
                                                    <table class="menu_selection">
                                                        <tr>
                                                            <td style="padding: 2px 3px 2px 3px; text-align: right">
                                                              <img src="img/calendario.png" alt="Fecha de Reporte" />
                                                            </td>
                                                            <td style="padding: 2px 5px 2px 5px; text-align: left">
                                                                <asp:Image ID="im_st" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imageurl") %>' style="width: 42px" />
                                                                <asp:ImageButton ID="ib_send" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dd/MM/yyyy}") %>' CommandName="senddef" Enabled="false" ImageUrl="~/img/fastf.png" OnClick="docommand" TabIndex='<%# DataBinder.Eval(Container.DataItem, "estado")%>' ToolTip="Enviar definitivo esta fecha" Visible="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding: 2px 3px 2px 3px; text-align: center">
                                                                <asp:LinkButton ID="lb_fechas" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dd/MM/yyyy}") %>' CommandName="reportar" CssClass="boton_texto" OnClick="docommand" style="text-decoration:none" TabIndex='<%# DataBinder.Eval(Container.DataItem,"estado") %>' Text='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dddd dd, MMMM yyyy}") %>' ValidationGroup='<%# DataBinder.Eval(Container.DataItem,"dayclass") %>'></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
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
                                                        ImageUrl="~/img/noyetb.png" />
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
                                                            <td style="padding: 5px; background-color: #FF3300; color: #FFFFFF; font-weight: bold; font-family:"Helvetica Neue", "Lucida Grande", "Segoe UI", Arial, Helvetica, Verdana, sans-serif; font-size: 9pt;">
                                                                Operación NO permitida</td>
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
                            </div>
                        </asp:View>
                        <asp:View ID="v_alumnos" runat="server">
                            <div>
                                <table style="text-align: center;">
                                    <tr>
                                        <td style="text-align: left">
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 5px; padding-left: 5px">
                                                        Alumnos del curso
                                                        <asp:Label ID="lbl_materiar" runat="server"></asp:Label>
                                                        &nbsp;el dia
                                                        <asp:Label ID="lbl_fecha" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hf_fecha" runat="server" />
                                                        <asp:HiddenField ID="hf_icu" runat="server" />
                                                        .</td>
                                                        <td>
                                                            <asp:ImageButton ID="ib_otrafecha" runat="server" CausesValidation="False" 
                                                                ImageUrl="img/calendario.png" 
                                                                ToolTip="Cambiar fecha de reporte sin guardar cambios." style="width: 24px" />
                                                        </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px">
                                            <asp:GridView ID="gv_alumnos" runat="server" AutoGenerateColumns="False" foreColor="Black" GridLines="none">
                                                <AlternatingRowStyle BackColor="#fcf9f9" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hf_matr" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"matr") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Alumno" DataField="fname" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Evaluación">
                                                        <ItemTemplate>
                                                            <asp:DataList ID="dl_eval" runat="server" RepeatDirection="Horizontal">
                                                                <ItemTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lbl_hora" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"alias") %>' TabIndex='<%# DataBinder.Eval(Container.DataItem,"dh") %>'></asp:Label>
                                                                            </td>
                                                                            <td style="padding-right: 5px; padding-left: 5px">
                                                                                <asp:DropDownList ID="ddl_eval" runat="server" CssClass="dropdown">
                                                                                    <asp:ListItem Value="A">Asistencia</asp:ListItem>
                                                                                    <asp:ListItem Value="R">Retardo</asp:ListItem>
                                                                                    <asp:ListItem Value="F">Falta</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle Height="25px" CssClass="percent"/>
                                                <AlternatingRowStyle BackColor="#EAEAEA" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <table style="border-width: 1px; border-color: #66CCFF; width: 100%; background-color: #EAEAFF; border-top-style: solid; border-bottom-style: solid;" 
                                    cellpadding="0" cellspacing="0"><tr><td style="padding: 5px; text-align: right">
                                        <asp:Button ID="cmd_temporal" runat="server" CssClass="botones_minis" 
                                            Text="Guardar Temporal" />
                                        </td><td style="padding: 5px; text-align: left">
                                            <asp:Button ID="cmd_definitivo" runat="server" CssClass="botones_minis" 
                                                Text="Guardar Definitivo" />
                                        </td></tr></table>
                            </div>
                    </asp:View>
                    </asp:MultiView>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmd_mostrar" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel></div>
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
<link href="general.css" rel="stylesheet" type="text/css" />

</asp:Content>

