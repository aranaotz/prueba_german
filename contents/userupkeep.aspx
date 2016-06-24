<%@ Page Title="" Language="VB" MasterPageFile="~/logins/logins.master" AutoEventWireup="false" CodeFile="userupkeep.aspx.vb" Inherits="contents_userupkeep" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_upkeep">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_upkeep">
                <asp:View runat="server" ID="v_busqueda">
                   <table class="centrado"><tr><td class="titulocategoria" style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">Mantenimiento de usuarios
                                               </td></tr><tr><td>
                    <table class="centrado"><tr><td style="padding: 0 10px 0 0">Usuario</td><td>
                    <asp:TextBox ID="tbx_busqueda" runat="server" CssClass="tbxreg" MaxLength="100" Width="400px"></asp:TextBox></td>
                    <td><asp:Button ID="cmd_buscar" runat="server" Text="Buscar usuario(s)" CssClass="botones" style="font-size: 100%;" CausesValidation="True"/></td></tr></table></td></tr>
                    <tr><td style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3" >
                        <asp:GridView ID="gv_resultados" runat="server" AutoGenerateColumns="false" EmptyDataText="No se han encontrado coincidencias :(" GridLines="None" ShowHeader="False" HorizontalAlign="center">
                            <Columns>
                                <asp:TemplateField><ItemTemplate><div id="gv_result" style="text-align:left;"><table><tr><td><asp:LinkButton ID="lb_gvresultado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' CssClass="boton_texto_resultados" OnClick="lb_gvresultado_Click"></asp:LinkButton></td></tr></table></div></ItemTemplate></asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </td></tr>
                </table>
                    
                </asp:View>
                <asp:View runat="server" ID="v_datos">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar usuario" CssClass="boton_texto_dentro" ValidationGroup="nupkeep"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_contra" Text="Cambiar datos de acceso" CssClass="boton_texto_dentro" /></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_elimina" Text="Elimina Usuario" CssClass="boton_texto_dentro" /></td>
                    </tr></table></div>
                    <table class="centrado"><tr><td>
                     <div>
      
                           <div class="titulocategoria" style="text-align:center;">Datos de usuario </div>
                           <div>
                               <table>
                                   <tr>
                                       <td>
                                           <asp:Image ID="img_user" runat="server" ImageUrl="../img/egg.png" style="width: 150px;" />
                                       </td>
                                       <td style="vertical-align: bottom; text-align: left;">
                                           <table>
                                               <tr>
                                                   <td>Para actualizar la fotografía del usuario elija una imagen de su computadora.</td>
                                               </tr>
                                               <tr>
                                                   <td>
                                                       <asp:HiddenField ID="hf_imageurl" runat="server" />
                                                       <asp:FileUpload ID="fu_photo" runat="server" />
                                                   </td>
                                               </tr>
                                           </table>
                                       </td>
                                   </tr>
                               </table>
                           </div>
                           <div class="tituloceldaNegrita" style="text-align:center; padding: 20px 0px 10px 0px;">Información Personal</div>
                           <div style="text-align:center;"><table class="centrado">
                               <tr><td>Nombre(s)</td><td>Apellido Paterno</td><td>Apellido Materno</td></tr>
                               <tr><td><asp:TextBox runat="server" ID="txtNombre" CssClass="tbxreg"></asp:TextBox></td>
                                   <td><asp:TextBox runat="server" ID="txtApellidop" CssClass="tbxreg"></asp:TextBox></td>
                                   <td><asp:TextBox runat="server" ID="txtApellidom" CssClass="tbxreg"></asp:TextBox></td>
                               </tr>
                               <tr><td colspan="3">Correo electronico personal</td></tr>
                               <tr><td colspan="3"><asp:TextBox runat="server" ID="txtCPersonal" CssClass="tbxreg"></asp:TextBox></td></tr>    
                               </table>
                           </div>

                           <div class="tituloceldaNegrita" style="text-align:center; padding: 20px 0px 10px 0px;">Información Institucional</div>
                           <div style="text-align:center;"><table class="centrado">
                               <tr><td>Cargo</td><td>Calve Trabajador</td></tr>
                               <tr><td><asp:DropDownList runat="server" ID="ddl_cargo" CssClass="tbxreg"></asp:DropDownList></td>
                                   <td><asp:TextBox runat="server" ID="txtClave" CssClass="tbxreg"></asp:TextBox>
                                       <asp:RequiredFieldValidator runat="server" ID="rfv_clave" ErrorMessage="El identificador clave es indispensable" Display="None"
                                             ControlToValidate="txtClave" SetFocusOnError="true" ValidationGroup="nupkeep" ></asp:RequiredFieldValidator>
                                         <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_clave" TargetControlID="rfv_clave" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                   </td></tr>
                                   <tr><td>Correo Institucional</td><td>Extensión</td></tr>
                               <tr><td><asp:TextBox runat="server" ID="txtCInsti" CssClass="tbxreg"></asp:TextBox></td>
                                   <td><asp:TextBox runat="server" ID="txtExtension" CssClass="tbxreg"></asp:TextBox></td></tr>
                               </table>
                           </div>
                     </div></td></tr></table>
                    <ajax:ModalPopupExtender ID="mod_advertencia" runat="server" PopupControlID="p_advertencia" CancelControlID="ib_close" BackgroundCssClass="modalBackground_gris" 
                                 TargetControlID="lb_elimina"></ajax:ModalPopupExtender>
                            <asp:Panel ID="p_advertencia" runat="server" style="display:none; width:100%; padding-left:60%;" >
                                    <table style="width: 40%;"><tr><td style="text-align: right; padding: 7px;"><asp:ImageButton ID="ib_close" runat="server" ImageUrl="~/img/close_coe.png" /></td></tr><tr><td>
                                         <table style="background:#FFF; width:100%; border-radius: 5px;">
  
                                             <tr>
                                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;">
                                                    <asp:Image ID="img_advertencia" runat="server" ImageUrl="~/img/alert.png" ImageAlign="AbsMiddle" />
                                                </td>
                                            </tr>
                                               <tr>
                                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;">
                                                    <asp:Label ID="lbl_advertencia" runat="server" Text="El registro se eliminara permanentemente!" style="text-align:center"></asp:Label>
                                                </td>
                                            </tr>
                                         <tr>
                                             <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;"><pre><asp:Button ID="btn_continuar" runat="server" Text="Continuar" CssClass="botones" Font-Size="Large" OnClick="btn_continuar_Click" />     <asp:Button ID="cmd_cancelar" runat="server" Text="Cancelar" CssClass="botones" Font-Size="Large" /></pre></td>

                                         </tr>

                                         </table></td>
                                         </tr>
                                        </table>
                               </asp:Panel>
                </asp:View>
                <asp:View runat="server" ID="v_password">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_cambiar" Text="Guardar cambios" CssClass="boton_texto_dentro"  ValidationGroup="vg_password"/></td>
                    </tr></table></div>
                    <table class="centrado"><tr><td>
                    <div class="titulocategoria" style="text-align:center; padding: 20px 0px 10px 0px;">Información de la cuenta</div></td></tr><tr><td>
                    
                    <div class="tituloceldaNegrita" style="text-align:center; padding:10px;">Cambiar datos de acceso para el usuario: <br /><strong><asp:Label runat="server" ID="lbl_user"></asp:Label></strong> </div></td></tr><tr><td>
                           <div style="text-align:center;"><table class="centrado">
                               <asp:Label runat="server" ID="lbl_clave" Visible="false"></asp:Label>
                                 <tr><td>Nueva contraseña</td><td>Repetir contraseña</td></tr>
                               <tr><td><asp:TextBox runat="server" ID="txtNueva" CssClass="tbxreg_min" TextMode="Password"></asp:TextBox></td>
                                   <td><asp:TextBox runat="server" ID="txtRepetir" CssClass="tbxreg_min" TextMode="Password"></asp:TextBox>
                                       <asp:CompareValidator ID="cv_repetir" runat="server" ErrorMessage="Las claves ingresadas son distintas" ControlToValidate="txtRepetir" ControlToCompare="txtNueva"
                                            Operator="Equal" ValidationGroup="vg_password" Display="None" SetFocusOnError="true"></asp:CompareValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_password" TargetControlID="cv_repetir" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>

                                       
                                   </td>
                                    
                               </tr>
                                         </table></div></td></tr>

                        <tr><td><div class="tituloceldaNegrita" style="text-align:center; padding: 20px 0px 10px 0px">Asignación de carreras</div></td></tr>
                                    <tr><td class="centrado">
                                        <asp:GridView runat="server" ID="gv_carreras" RowStyle-CssClass="gvrow" AutoGenerateColumns="false" GridLines="None"
                                             HorizontalAlign="Left" CellPadding="5" CellSpacing="0" HeaderStyle-CssClass="gvheader">
                                            <AlternatingRowStyle CssClass="gvrow_alt" />
                                            <Columns>
                                                <asp:BoundField DataField="cv_carrera" HeaderText="Clave" SortExpression="clave" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Carrera" SortExpression="nombre" />
                                                <asp:TemplateField HeaderText="Pertenece">
                                                    <ItemTemplate>
                                                        <div  style="text-align:center">
                                                            <asp:CheckBox runat="server" ID="cbx_pertenece" Checked='<%# DataBinder.Eval(Container.DataItem, "pertenece") %>'  />
                                                            <asp:HiddenField runat="server" ID="hf_clave" Value='<%# DataBinder.Eval(Container.DataItem, "cv_carrera") %>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        </td></tr>
                    <tr>
                        <td class="tituloceldaNegrita" style="text-align:center; padding: 10px;">Privilegios</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>

                            <asp:GridView ID="gv_menutop" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="false" ShowHeader="false" Width="200px" HorizontalAlign="Center">
                                                <Columns>
                                                    
                                                    <asp:Templatefield><ItemTemplate><div class='<%# DataBinder.Eval(Container.DataItem, "css")%>'><asp:Label ID="lbl_topmenu" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "nombre")%>'></asp:Label><asp:HiddenField ID="hf_cabezalnum" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "cabezal_num")%>' /><asp:HiddenField ID="hf_usuario" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "usuario")%>'/></div><ajax:Accordion ID="acc_menuch" runat="server" CssClass="accordion" FadeTransitions="true" FramesPerSecond="40" HeaderCssClass="accordeon_menu_cabezal" HeaderSelectedCssClass="accordeon_menu_cabezal_seleccionado" RequireOpenedPane="false" SelectedIndex="-1" SuppressHeaderPostbacks="true" TransitionDuration="250"><Panes><ajax:AccordionPane ID="ap_menuch" runat="server"><Header><div id="indicator"></div></Header><Content><asp:GridView ID="gv_menusub" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="false" ShowHeader="false" Width="100%"><Columns><asp:TemplateField><ItemTemplate><table style="width: 100%; margin: 0 auto; background: rgba(0,0,0,0.3); border-radius: 5px;""><tr><td class='<%# DataBinder.Eval(Container.DataItem, "css")%>'><table style="text-align:left;"><tr><td style="padding-left: 10px;"><asp:CheckBox ID="cbx_select" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "assign")%>'/><asp:HiddenField ID="hf_idpage" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id_page")%>' /></td><td><asp:Label ID="lbl_submenu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ruta")%>' 
                                                                                                            CssClass="boton_texto_menu" Text='<%# DataBinder.Eval(Container.DataItem, "nombre")%>' 
                                                                                                            Tooltip='<%# DataBinder.Eval(Container.DataItem, "extenso")%>'>
                                                                                                        </asp:Label></td></tr></table></td></tr></table></ItemTemplate></asp:TemplateField></Columns></asp:GridView></Content></ajax:AccordionPane></Panes></ajax:Accordion></ItemTemplate></asp:Templatefield>
                                                </Columns>
                                            </asp:GridView>

                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </asp:View>

                <asp:View runat="server" ID="v_exito">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_vuelve" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Regresar a la busqueda" CssClass="boton_texto_dentro" /></td>
                                   
                                    </tr></table></div>           

                                   
                                <div>
                                    <div style="padding-top:150px; text-align:center;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">Los datos se han registrado correctamente en el sistema!
                                        </div>
                                </div>
               
                </asp:View>
                <asp:View runat="server" ID="v_elimina_ok">
                    <div class="topbar"><table class="centrado"><tr><td><asp:ImageButton ID="ib_regresa" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_busqueda" Text="Volver a la busqueda" CssClass="boton_texto_dentro" OnClick="lb_busqueda_Click" /></td>
                                    
                                    </tr></table></div>           

                                   
                                <div>
                                    <div style="padding-top:150px; text-align:center"><asp:Image runat="server"  ID="Image1" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">El usuario se ha eliminado correctamente del sistema!
                                        </div>
                                </div>
               
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lb_guardar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

