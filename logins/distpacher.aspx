<%@ Page Title="" Language="VB" MasterPageFile="~/logins/logins.master" AutoEventWireup="false" CodeFile="distpacher.aspx.vb" Inherits="dispatcher" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_distpacher">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_distpacher">
                <asp:View runat="server" ID="v_cero">
                    <div style="padding-bottom: 150px;">
       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_recarga" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar cambios" CssClass="boton_texto_dentro"/></td>
           <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_cambiar" Text="Cambiar contraseña" CssClass="boton_texto_dentro" OnClick="lb_cambiar_Click"/></td>
                                   </tr></table></div>
    <table class="centrado"><tr><td>
       <div class="titulocategoria" style="text-align: center;">Datos de usuario<asp:HiddenField ID="hf_imageurl" runat="server" /></div></td></tr><tr><td>
       <div class="tituloceldaNegrita" style="text-align: center; padding: 20px 0px 10px 0px;">Información Personal</div></td></tr><tr><td>
       <div style="text-align: center;">
           <table class="centrado">
           <tr><td>Nombre(s)</td><td>Apellido Paterno</td><td>Apellido Materno</td></tr>
           <tr><td><asp:TextBox runat="server" ID="txtNombre" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td>
               <td><asp:TextBox runat="server" ID="txtApellidop" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td>
               <td><asp:TextBox runat="server" ID="txtApellidom" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td>
               </tr><tr><td colspan="3">Correo electrónico personal</td></tr>
               <tr><td colspan="3"><asp:TextBox runat="server" ID="txtCPersonal" CssClass="tbxreg"></asp:TextBox></td></tr>    
           </table>
       </div></td></tr><tr><td>
       <div class="tituloceldaNegrita" style="text-align: center; padding: 20px 0px 10px 0px;">Información Institucional</div></td></tr><tr><td>
       <div style="text-align: center;"><table class="centrado">
           <tr><td>Cargo<asp:hiddenfield id="hf_cargo" runat="server" /></td><td>Clave Trabajador</td></tr>
           <tr><td><asp:TextBox runat="server" ID="txtCargo" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td>
               <td><asp:TextBox runat="server" ID="txtClave" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td></tr>
           <tr><td>Correo Institucional</td><td>Extensión</td></tr>
           <tr><td><asp:TextBox runat="server" ID="txtCInsti" CssClass="tbxreg"></asp:TextBox></td>
               <td style="width:20%"><asp:TextBox runat="server" ID="txtExtension" CssClass="tbxreg"></asp:TextBox></td></tr>
           </table>
       </div></td></tr>
    </table>
     </div>
                </asp:View>
                <asp:View runat="server" ID="v_uno">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_atras_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_save" Text="Guardar cambios" CssClass="boton_texto_dentro" OnClick="lb_save_Click" ValidationGroup="vg_distpacher"/></td>
                           </tr></table></div>
                    <asp:Label runat="server" ID="lbl_user" Visible="false"></asp:Label>
                    <div>
                        <div style="text-align:center" class="titulocategoria">CAMBIAR CONTRASEÑA DE CUENTA</div>
                        <div style="text-align:center; padding-top:20px" class="titulocelda">
                           Contraseña anterior <br />    
                           <asp:TextBox runat="server" ID="tbx_oldpass" CssClass="tbxreg_min" Width="250px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfv_old" ErrorMessage="El identificador es indispensable" Display="None"
                                             ControlToValidate="tbx_oldpass" SetFocusOnError="true" ValidationGroup="vg_distpacher" ></asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender runat="server" ID="vcoe_old" TargetControlID="rfv_old" CloseImageUrl="~/img/close_coe.png"
                                                         CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></asp:ValidatorCalloutExtender>
                                        
                                            
                  
                        </div>
                        <div style="text-align:center; padding-top:20px" class="titulocelda">
                           Nueva contraseña  <br />    
                           <asp:TextBox runat="server" ID="tbx_nueva" CssClass="tbxreg_min" Width="250px" TextMode="Password"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txt_cpass_filtro" runat="server" TargetControlID="tbx_nueva" FilterMode="InvalidChars" 
                                                    InvalidChars="!&quot;#$%&amp;/()='¿?¡+*~][}{-:,;.<> &nbsp;`çÇ``^¨"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="text-align:center; padding-top:20px" class="titulocelda">
                           Repetir contraseña  <br />   
                           <asp:TextBox runat="server" ID="tbx_repetir" CssClass="tbxreg_min" Width="250px" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="cv_repetir" runat="server" ErrorMessage="Las claves ingresadas son distintas" ControlToValidate="tbx_repetir" ControlToCompare="tbx_nueva"
                                            Operator="Equal" ValidationGroup="vg_distpacher" Display="None" SetFocusOnError="true"></asp:CompareValidator>
                                        <asp:ValidatorCalloutExtender runat="server" ID="vcoe_password" TargetControlID="cv_repetir" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></asp:ValidatorCalloutExtender>
                            <asp:HiddenField ID="hf_popupok" runat="server" />
                             <asp:ModalPopupExtender ID="hf_popupok_mpe" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_popupok" PopupControlID="p_registrok" BackgroundCssClass="modalBackground_gris" CancelControlID="lb_closeok">
                                </asp:ModalPopupExtender>
                            <asp:Panel ID="p_registrok" runat="server" style="display: none" DefaultButton="cmd_ok">
                            <table><tr><td>
                               <table class="popupmsg" style="width: 100%"><tr><td></td><td style="width: 100%; padding: 10px 0px 5px 0px;"><img alt="Correcto" src="../img/alert.png"/></td>
                               <td>
                                  
                               </td></tr>
                                   <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="lb_closeok" runat="server"></asp:LinkButton>
                                           La contraseña es incorrecta!. Corrija e intente de nuevo </td><td>&nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%;">
                                           <asp:Button ID="cmd_ok" runat="server" CausesValidation="False" CssClass="botones" style="font-size: 100%;" Text="OK" />
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel>
                        </div>
                    </div>
                </asp:View>

  <asp:View runat="server" ID="v_dos">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_vuelve" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_vuelve_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Regresar" CssClass="boton_texto_dentro" OnClick="lb_regresar_Click" /></td>
                                   
                                    </tr></table></div>           

                                   
                                <div>
                                    <div style="padding-top:150px; text-align:center;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">Los datos se han registrado correctamente en el sistema!
                                        </div>
                                </div>
               
                </asp:View>
                <asp:View runat="server" ID="v_tres">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_refresh" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                       
                       
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_cambia_contra" Text="Cambiar contraseña" CssClass="boton_texto_dentro" OnClick="lb_cambia_contra_Click"/></td>
                                               </tr></table></div>
                    <div style="padding-top:20px;text-align:center;" class="titulocategoria">Datos del alumno</div>
                    <div style="padding-top:20px;text-align:center;" class="titulocelda">*Nota: si tu información está incompleta o necesitas actualizar algun dato, te sugerimos presentarte con tu tutor o bien en la Dirección de Servicios Escolares,
                        <br />
                        donde podremos ayudarte a actualizarlos</div>
                    <div style="padding-top:20px;text-align:center;">
                        <table class="centrado" style="width:80%">
                            <tr>
                               <td class="titulocelda"style="width:25%">Matricula</td>
                                <td class="titulocelda"style="width:25%">Nombres</td>
                                <td class="titulocelda"style="width:20%">Primer Apellido</td>
                                <td class="titulocelda"style="width:20%">Segundo Apellido</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:20%"><asp:TextBox runat="server" ID="tbx_matricula" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_nombres" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_primero" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_segundo" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            </table>
                        <table class="centrado" style="width:80%">
                            <tr>
                               <td class="titulocelda"style="width:40%">Carrera</td>
                                <td class="titulocelda"style="width:5%">Nivel</td>
                                
                                <td class="titulocelda"style="width:15%">Turno</td>
                                <td class="titulocelda"style="width:5%">Grado</td>
                                <td class="titulocelda"style="width:5%">Grupo</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:40%"><asp:TextBox runat="server" ID="tbx_carrera" CssClass="tbxreg" Enabled="False" ReadOnly="True" ></asp:TextBox></td>
                                <td class="titulocelda" style="width:5%"><asp:TextBox runat="server" ID="tbx_nivel" CssClass="tbxreg" Enabled="False" ReadOnly="True" ></asp:TextBox></td>
                               
                                <td class="titulocelda"style="width:15%"><asp:TextBox runat="server" ID="tbx_turno" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_grado" CssClass="tbxreg" Enabled="False" ReadOnly="True" ></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_grupo" CssClass="tbxreg" Enabled="False" ReadOnly="True" ></asp:TextBox></td>
                            </tr>
                        </table>
                         <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:30%">Estatus de Alumno</td>
                                <td class="titulocelda"style="width:25%">CURP</td>
                                <td class="titulocelda"style="width:20%">RFC</td>
                                <td class="titulocelda"style="width:25%">NSS</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:30%"><asp:TextBox runat="server" ID="tbx_status" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_curp" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_rfc" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_nss" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                            </tr>
                            </table>
                         <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:50%">Correo Electrónico</td>
                                <td class="titulocelda"style="width:25%">Telefono Fijo</td>
                                <td class="titulocelda"style="width:25%">Telefono Móvil</td>                               
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:50%"><asp:TextBox runat="server" ID="tbx_email" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_fijo" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_movil" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>                              
                            </tr>
                            </table>
                          <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:50%">Domicilio</td>
                                <td class="titulocelda"style="width:5%">Num. ext.</td>
                                <td class="titulocelda"style="width:5%">Num. int</td>
                                <td class="titulocelda"style="width:10%">CP</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:50%"><asp:TextBox runat="server" ID="tbx_domicilio" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_ext" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_int" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                                <td class="titulocelda"style="width:10%"><asp:TextBox runat="server" ID="tbx_cp" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                            </tr>
                            </table>
                        
                    </div>
                    
                    
                </asp:View>
                 <asp:View runat="server" ID="v_cuatro">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_atras_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_gcambios" Text="Guardar cambios" CssClass="boton_texto_dentro" OnClick="lb_gcambios_Click" ValidationGroup="vg_distpacher_alumno"/></td>
                           </tr></table></div>
                    <asp:HiddenField runat="server" ID="hf_alumno" />
                    <div>
                        <div style="text-align:center" class="titulocategoria">CAMBIAR CONTRASEÑA DE CUENTA</div>
                        <div style="text-align:center; padding-top:20px" class="titulocelda">
                           Contraseña anterior <br />    
                           <asp:TextBox runat="server" ID="tbx_c_anterior" CssClass="tbxreg_min" Width="250px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_c_anterior" ErrorMessage="El identificador es indispensable" Display="None"
                                             ControlToValidate="tbx_c_anterior" SetFocusOnError="true" ValidationGroup="vg_distpacher_alumno" ></asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_c_anterior" TargetControlID="rfv_tbx_c_anterior" CloseImageUrl="~/img/close_coe.png"
                                                         CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></asp:ValidatorCalloutExtender>
                                        
                                            
                  
                        </div>
                        <div style="text-align:center; padding-top:20px" class="titulocelda">
                           Nueva contraseña  <br />    
                           <asp:TextBox runat="server" ID="tbx_n_contra" CssClass="tbxreg_min" Width="250px" TextMode="Password"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fte_tbx_n_contra" runat="server" TargetControlID="tbx_n_contra" FilterMode="InvalidChars" 
                                                    InvalidChars="!&quot;#$%&amp;/()='¿?¡+*~][}{-:,;.<> &nbsp;`çÇ``^¨"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="text-align:center; padding-top:20px" class="titulocelda">
                           Repetir contraseña  <br />   
                           <asp:TextBox runat="server" ID="tbx_r_contra" CssClass="tbxreg_min" Width="250px" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="cv_tbx_r_contra" runat="server" ErrorMessage="Las claves ingresadas son distintas" ControlToValidate="tbx_r_contra" ControlToCompare="tbx_n_contra"
                                            Operator="Equal" ValidationGroup="vg_distpacher_alumno" Display="None" SetFocusOnError="true"></asp:CompareValidator>
                                        <asp:ValidatorCalloutExtender runat="server" ID="vcoe_cv_tbx_r_contra" TargetControlID="cv_tbx_r_contra" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></asp:ValidatorCalloutExtender>
                            <asp:HiddenField ID="hf_popupok1" runat="server" />
                             <asp:ModalPopupExtender ID="hf_popupok_mpe1" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_popupok1" PopupControlID="p_registrok1" BackgroundCssClass="modalBackground_gris" CancelControlID="lb_closeok1">
                                </asp:ModalPopupExtender>
                            <asp:Panel ID="p_registrok1" runat="server" style="display: none" DefaultButton="cmd_ok1">
                            <table><tr><td>
                               <table class="popupmsg" style="width: 100%"><tr><td></td><td style="width: 100%; padding: 10px 0px 5px 0px;"><img alt="Correcto" src="../img/alert.png"/></td>
                               <td>
                                  
                               </td></tr>
                                   <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="lb_closeok1" runat="server"></asp:LinkButton>
                                           La contraseña es incorrecta!. Corrija e intente de nuevo </td><td>&nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%;">
                                           <asp:Button ID="cmd_ok1" runat="server" CausesValidation="False" CssClass="botones" style="font-size: 100%;" Text="OK" />
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>

    </asp:UpdatePanel>
     
</asp:Content>

