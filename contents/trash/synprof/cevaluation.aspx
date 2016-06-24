<%@ Page Title="Reporte de Evaluacion Continua - SADIN 2010" Language="VB" MasterPageFile="profworking.master" AutoEventWireup="false" CodeFile="cevaluation.aspx.vb" Inherits="cevaluation" uiCulture="es-MX" Culture="es-MX" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="prof.css" rel="stylesheet" type="text/css" />
<link href="calendar.css" rel="stylesheet" type="text/css" />
    <div style="padding: 0px; font-family: 'Segoe UI','Helvetica Neue', 'Lucida Grande', Arial, Helvetica, Verdana, sans-serif; font-size: 1em; color: #333333">
    <cc1:ToolkitScriptManager ID="sm_cevaluation" runat="server" 
            EnableScriptGlobalization="True"></cc1:ToolkitScriptManager>
    <table style="width:100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">
                <table style="width:100%;">
                    <tr>
                        <td style="padding: 10px;">
                            La EVALUACIÓN CONTÍNUA se reporta el último día de la semana con un grupo.<br /> 
                            Para que un reporte sea tomado en cuenta, éste debe tener estado ENVIADO DEFINITIVO.
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
            <td style="padding: 5px; text-align: center">
                    <asp:UpdateProgress ID="up_evalc" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <iframe frameborder="0" src="about:blank" class="esperando_iframe"></iframe>
                        <div class="esperando">Espere un momento...</div>
                    </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
        </tr>
        <tr>
            <td colspan="3">
            <asp:UpdatePanel ID="up_cursos" runat="server"><ContentTemplate>
                <asp:MultiView ID="mv_cursos" runat="server">
                    <asp:View ID="v_cursos" runat="server">
                       
                        <table style="width:100%;">
                            <tr>
                                <td style="padding: 3px">
                                    <asp:HiddenField ID="hf_icu" runat="server" />
                                    <asp:HiddenField ID="hf_msg" runat="server" />
                                    <table>
                                        <tr><td style="padding-left: 5px; padding-right: 5px">
                                                Fechas de reporte para
                                                <asp:Label ID="lbl_materia" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hf_detalle" runat="server" />
                                    <cc1:ModalPopupExtender ID="hf_detalle_mpe" runat="server" 
                                        BackgroundCssClass="modalBackground_gris" CancelControlID="ib_cwin" 
                                        DynamicServicePath="" Enabled="True" PopupControlID="p_detalle" 
                                        TargetControlID="hf_detalle"></cc1:ModalPopupExtender>
                                    <cc1:ModalPopupExtender ID="hf_msg_mpe" runat="server" DynamicServicePath="" 
                                        Enabled="True" TargetControlID="hf_msg" CancelControlID="ib_closewin" PopupControlID="p_msg" BackgroundCssClass="modalBackground_gris"></cc1:ModalPopupExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DataList ID="dl_fechas" runat="server" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" CellSpacing="5" ShowFooter="False" ShowHeader="False" CellPadding="2">
                                        <ItemStyle Height="120px" HorizontalAlign="Center" VerticalAlign="Middle" Width="33%" Wrap="True" />
                                        <ItemTemplate>
                                            <table class="menu_selection">
                                                <tr>
                                                    <td style="padding: 2px 3px 2px 3px; text-align: center">
                                                        <img src="img/calendario.png" alt="Fecha de Reporte" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="img_st" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imageurl") %>' style="width: 42px"/>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ib_definitivo" runat="server" Enabled="false" Visible="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dd/MM/yyyy}") %>' CommandName="senddef" ImageUrl="~/img/fastf.png" OnClick="docommand" TabIndex='<%# DataBinder.Eval(Container.DataItem,"estado") %>' ToolTip="Enviar definitivo esta fecha" />
                                                    </td></tr>
                                                <tr>
                                                    <td colspan="3" style="padding: 2px 4px 2px 4px">
                                                        <asp:LinkButton ID="lb_fechas" runat="server" CssClass="boton_texto" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dd/MM/yyyy}") %>' CommandName="reportar" OnClick="docommand" style="text-decoration:none" TabIndex='<%# DataBinder.Eval(Container.DataItem,"estado") %>' Text='<%# DataBinder.Eval(Container.DataItem,"fecha", "{0: dddd dd, MMMM yyyy}") %>'></asp:LinkButton>
                                                        <br />
                                                        <asp:LinkButton ID="lb_status" runat="server" CssClass="boton_texto" style="text-decoration:none" Text='<%# DataBinder.Eval(Container.DataItem,"string") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"estado") %>' CommandName="detalle" ToolTip="Informacion del Estatus del reporte."  OnClick="docommand"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Panel ID="p_msg" runat="server" style="display:none;">
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="text-align: right; padding-right: 5px; padding-bottom: 5px;">
                                                    <asp:ImageButton ID="ib_closewin" runat="server" 
                                                        ImageUrl="~/img/closewin.png" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" 
                                                        
                                                        style="border: 1px solid #FF3300; background-color: #FFFFFF; width: 300px;">
                                                        <tr>
                                                            <td style="padding: 5px; background-color: #FF3300; color: #FFFFFF; font-weight: bold; font-family: verdana; font-size: 7.5pt;">
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
                                    <asp:Panel ID="p_detalle" runat="server" style="display:none;">
                                        <table>
                                            <tr>
                                                <td style="padding: 5px; text-align: right">
                                                    <asp:ImageButton ID="ib_cwin" runat="server" ImageUrl="~/img/noyetb.png" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" 
                                                        
                                                        style="border: 1px solid #006699; width: 350px; background-color: #FFFFFF;">
                                                        <tr>
                                                            <td colspan="2" 
                                                                
                                                                style="padding: 5px 3px 5px 3px; background-color: #006699; color: #FFFFFF;">
                                                                :: INFORMACION SOBRE EL STATUS DEL REPORTE ::</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 4px">
                                                                <img alt="" src="http://187.174.139.68/cgiapp/img/statusredn.png" />
                                                            </td>
                                                            <td style="padding: 4px; text-align: justify; color: #000099">
                                                                Indica que el reporte no ha sido guardado. 
                                                                Pasada la fecha limite de entrega, este status causa una disminución en su 
                                                                evaluación docente.</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 4px">
                                                                <img alt="" src="http://187.174.139.68/cgiapp/img/statusyeln.png" />
                                                            </td>
                                                            <td style="padding: 4px; text-align: justify; color: #000099">
                                                                Indica que el reporte ya fue guardado de forma temporal, pero aun no en 
                                                                definitiva. Si no lo guarda como definitivo antes de la fecha limite, causará 
                                                                una disminución en su evaluación docente. Las calificaciones guardadas con éste estatus
                                                                no contarán para el promedio del alumno.</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 4px">
                                                                <img alt="" 
                                                                    src="http://187.174.139.68/cgiapp/img/statusgren.png" />
                                                            </td>
                                                            <td style="padding: 4px; text-align: justify; color: #000099">
                                                                Indica que el reporte ya fue enviado de forma definitiva.
                                                                Se recomienda que haga definitivo un reporte despues de 1 día en temporal, esto
                                                                para evitar correcciones de calificación en Dirección Académica.</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                       
                    </asp:View>
                     <asp:View ID="v_alumnos" runat="server">
                         <table style="width:100%; ">
                             <tr>
                                 <td style="padding-bottom: 2px; padding-top: 2px; text-align: left">
                                     <asp:HiddenField ID="hf_msgcal" runat="server" />
                                     <cc1:ModalPopupExtender ID="hf_msgcal_mpe" runat="server" DynamicServicePath="" 
                                         Enabled="True" TargetControlID="hf_msgcal" CancelControlID="ib_closewincal" PopupControlID="p_msgcal" BackgroundCssClass="modalBackground_gris"></cc1:ModalPopupExtender>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <table>
                                         <tr>
                                             <td style="text-align: right"></td>
                                             <td class="celgray-right">
                                                 <asp:Label ID="lbl_materiar" runat="server"></asp:Label>
                                             </td>
                                             <td></td>
                                         </tr>
                                         <tr>
                                             <td style="text-align: right">
                                                 <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/calendario.png" 
                                                     ToolTip="Cambiar fecha de reporte" CausesValidation="False" style="width: 24px" /></td>
                                             <td class="celgray-right">
                                                 <asp:Label ID="lbl_fecha" runat="server"></asp:Label>
                                                 <asp:HiddenField ID="hf_fecha" runat="server" />
                                             </td>
                                             <td style="padding-right: 10px; padding-left: 10px">
                                                 
                                             </td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <table>
                                         <tr>
                                             <td class="percent">
                                                 40%</td>
                                             <td style="padding: 2px; text-align: left;">
                                                 <asp:HiddenField ID="hf_i1" runat="server" />
                                                 <asp:Label ID="lbl_item1" runat="server"></asp:Label>
                                             </td>
                                             <td>
                                                 <asp:TextBox ID="tbx_i1" runat="server" CssClass="tbxlogin" Width="400px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="rfv_i1" runat="server" 
                                                     ControlToValidate="tbx_i1" Display="None" 
                                                     ErrorMessage="Debe especificar que es lo que está evaluando en este rubro." 
                                                     SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                 <cc1:ValidatorCalloutExtender ID="rfv_i1_vcoe" runat="server" Enabled="True" 
                                                     TargetControlID="rfv_i1"></cc1:ValidatorCalloutExtender>
                                             </td>
                                         </tr>
                                         <tr>
                                              <td class="percent">
                                                 30%</td>
                                             <td style="padding: 2px; text-align: left;">
                                                 <asp:HiddenField ID="hf_i2" runat="server" />
                                                 <asp:Label ID="lbl_item2" runat="server"></asp:Label>
                                             </td>
                                             <td>
                                                 <asp:TextBox ID="tbx_i2" runat="server" CssClass="tbxlogin" Width="400px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="rfv_i2" runat="server" 
                                                     ControlToValidate="tbx_i2" Display="None" 
                                                     ErrorMessage="Debe especificar que es lo que está evaluando en este rubro." 
                                                     SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                 <cc1:ValidatorCalloutExtender ID="rfv_i2_ValidatorCalloutExtender" 
                                                     runat="server" Enabled="True" TargetControlID="rfv_i2"></cc1:ValidatorCalloutExtender>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="percent">
                                                 30%</td>
                                             <td style="padding: 2px; text-align: left;">
                                                 <asp:HiddenField ID="hf_i3" runat="server" />
                                                 <asp:Label ID="lbl_item3" runat="server"></asp:Label>
                                             </td>
                                             <td>
                                                 <asp:TextBox ID="tbx_i3" runat="server" CssClass="tbxlogin" Width="400px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="rfv_i3" runat="server" 
                                                     ControlToValidate="tbx_i3" Display="None" 
                                                     ErrorMessage="Debe especificar que es lo que está evaluando en este rubro." 
                                                     SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                 <cc1:ValidatorCalloutExtender ID="rfv_i3_ValidatorCalloutExtender" 
                                                     runat="server" Enabled="True" TargetControlID="rfv_i3"></cc1:ValidatorCalloutExtender>
                                             </td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td style="padding-top: 10px;">
                                     <asp:GridView ID="gv_alumnos" runat="server" AutoGenerateColumns="False" foreColor="Black" GridLines="none">
                                         <AlternatingRowStyle BackColor="#fcf9f9" />
                                         <Columns>
                                             <asp:TemplateField><ItemTemplate><asp:HiddenField ID="hf_matr" runat="server" 
                                                         Value='<%# DataBinder.Eval(Container.DataItem,"matr") %>' /></ItemTemplate></asp:TemplateField>
                                             <asp:BoundField DataField="fname" HeaderText="Alumno" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                                             <asp:TemplateField><ItemTemplate><table cellpadding="0" cellspacing="0"><tr><td style="padding: 1px 5px 1px 5px"><asp:Label ID="lbl_gi1" runat="server"></asp:Label><asp:HiddenField ID="hf_gi1" runat="server" /></td><td style="padding: 0px 1px 0px 1px"><asp:TextBox ID="tbx_gi1" runat="server" MaxLength="3" ValidationGroup="calif" 
                                                                     Width="40px" Text='<%# DataBinder.Eval(Container.DataItem,"it1") %>' CssClass="tbxlogin"></asp:TextBox><cc1:FilteredTextBoxExtender ID="tbx_gi1_fe" runat="server" Enabled="True" 
                                                                     TargetControlID="tbx_gi1" ValidChars="1234567890."></cc1:FilteredTextBoxExtender></td></tr></table></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                             <asp:TemplateField><ItemTemplate><table cellpadding="0" cellspacing="0"><tr><td style="padding: 0px 1px 0px 1px"><asp:Label ID="lbl_gi2" runat="server"></asp:Label><asp:HiddenField ID="hf_gi2" runat="server" /></td><td style="padding: 0px 1px 0px 1px"><asp:TextBox ID="tbx_gi2" runat="server" MaxLength="3" ValidationGroup="calif" 
                                                                     Width="40px" Text='<%# DataBinder.Eval(Container.DataItem,"it2") %>' CssClass="tbxlogin"></asp:TextBox><cc1:FilteredTextBoxExtender ID="tbx_gi2_fe" runat="server" Enabled="True" 
                                                                     TargetControlID="tbx_gi2" ValidChars="1234567890."></cc1:FilteredTextBoxExtender></td></td></tr></table></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                             <asp:TemplateField><ItemTemplate><table cellpadding="0" cellspacing="0"><tr><td style="padding: 0px 1px 0px 1px"><asp:Label ID="lbl_gi3" runat="server"></asp:Label><asp:HiddenField ID="hf_gi3" runat="server" /></td><td style="padding: 0px 1px 0px 1px"><asp:TextBox ID="tbx_gi3" runat="server" MaxLength="3" ValidationGroup="calif" 
                                                                     Width="40px" Text='<%# DataBinder.Eval(Container.DataItem,"it3") %>' CssClass="tbxlogin"></asp:TextBox><cc1:FilteredTextBoxExtender ID="tbx_gi3_fe" runat="server" Enabled="True" 
                                                                     TargetControlID="tbx_gi3" ValidChars="1234567890."></cc1:FilteredTextBoxExtender></td></tr></table></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                         </Columns>
                                         <HeaderStyle Height="25px" CssClass="percent"/>
                                         
                                     </asp:GridView>
                                 </td>
                             </tr>
                             <tr>
                                 <td style="text-align: center">
                                      <asp:Panel ID="p_msgcal" runat="server" style="display:none;">
                                        <table>
                                            <tr>
                                                <td style="text-align: right; padding-right: 5px; padding-bottom: 5px;">
                                                    <asp:ImageButton ID="ib_closewincal" runat="server" 
                                                        ImageUrl="~/img/noyetb.png" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" 
                                                        style="border: 1px solid #FF3300; background-color: #FFFFFF;">
                                                        <tr>
                                                            <td style="padding: 5px; background-color: #FF3300; color: #FFFFFF; font-weight: bold; font-size: 9pt;">
                                                                Operación NO permitida</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="color: #000066; padding: 5px">
                                                                SADIN no puede guardar este reporte debido a un<br />
                                                                error en las calificaciones que ud. proporcionó.<br />
                                                                Revise que TODOS los registros tengan una calificación<br />
                                                                y que ésta sea en base 10</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                     </td>
                             </tr>
                             <tr>
                                 <td style="padding: 5px; text-align: center; background-color: #E8E8E8; border: 1px solid #999999">
                                     <asp:Button ID="cmd_temporal" runat="server" 
                                         Text="Guardar como Temporal" />
                                     <asp:Button ID="cmd_definitivo" runat="server" 
                                         Text="Guardar como Definitivo" />
                                 </td>
                             </tr>
                         </table>
                        </asp:View>
                        <asp:View ID="v_error" runat="server">
                            <table style="width:100%; text-align: center;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td style="padding-top: 10px">
                                        <asp:Image ID="Image7" runat="server" ImageUrl="~/img/error.png" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td style="padding: 5px">
                                        Un error en las calificaciones que ha introducido<br />
                                        impiden que el reporte sea enviado correctamente.<br />
                                        <br />
                                        <strong>Revise que TODOS los cuadros esten correctamente<br /> llenados. La 
                                        calificacion en en BASE 10.</strong></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="cmd_regresar" runat="server" 
                                            Text="Regresar al Reporte" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:View>
                </asp:MultiView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cmd_mostrar" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>
                <cc1:UpdatePanelAnimationExtender ID="up_cursos_aex" runat="server" 
                  Enabled="True" TargetControlID="up_cursos">
                        <Animations>
                             <OnUpdating>
                                   <Parallel duration="0.5" fps="30">
                                   <FadeOut AnimationTarget="up_cursos" minimumOpacity="0" ForceLayoutInIE="true"/>
                                   </Parallel>
                            </OnUpdating>
                            <OnUpdated>
                                 <Parallel duration="0.5" fps="30">
                                   <FadeIn Animationtarget="up_cursos" minimumOpacity="0" ForceLayoutInIE="true"/>
                                   </Parallel>
                              </OnUpdated>
                    </Animations>
                   </cc1:UpdatePanelAnimationExtender>
            </td>
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
</div>


</asp:Content>

