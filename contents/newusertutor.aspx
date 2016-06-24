<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="newusertutor.aspx.vb" Inherits="newusertutor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <div style="padding-bottom: 150px;">
       
        <asp:UpdatePanel runat="server" ID="up_newusers">
            <ContentTemplate>
                
                <asp:MultiView ID="mv_altausuario" runat="server" >
                    <asp:View ID="v_alta" runat="server">
                         <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/reload.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Crear nuevo usuario" CssClass="boton_texto_dentro" ValidationGroup="vg_user"/></td>
                                    </tr></table></div>
                            <div class="centrado">
                                <table class="centrado"><tr><td>
                                <div class="titulocategoria" style="text-align:center;">Registro de nuevo usuario</div></td></tr>
                                    <tr>
                                        <td>
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
                                                                    <asp:FileUpload ID="fu_photo" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr><td>
                                <div class="tituloceldaNegrita" style="text-align:center; padding: 20px 0px 10px 0px">Información Personal</div></td></tr><tr><td>
                                <div style="text-align:center;">
                                    <table class="centrado">
                                       <tr><td>Nombre(s)</td><td>Apellido Paterno</td><td>Apellido Materno</td></tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox runat="server" ID="txtNombre" CssClass="tbxreg"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ErrorMessage="El nombre es indispensable"
                                                Display="None" ControlToValidate="txtNombre" SetFocusOnError="True" ValidationGroup="vg_user" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_nombre" runat="server" TargetControlID="rfv_nombre" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                           </td>
                                           <td>
                                               <asp:TextBox runat="server" ID="txtPaterno" CssClass="tbxreg"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="rfv_paterno" runat="server" ErrorMessage="El apellido paterno es indispensable"
                                                Display="None" ControlToValidate="txtPaterno" SetFocusOnError="True" ValidationGroup="vg_user" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_paterno" runat="server" TargetControlID="rfv_paterno" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                           </td>
                                           <td>
                                               <asp:TextBox runat="server" ID="txtMaterno" CssClass="tbxreg"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="rfv_materno" runat="server" ErrorMessage="El apellido materno es indispensable"
                                                Display="None" ControlToValidate="txtMaterno" SetFocusOnError="True" ValidationGroup="vg_user" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_materno" runat="server" TargetControlID="rfv_materno" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                           </td>
                                       </tr>
                                       <tr><td colspan="2">Puesto</td><td>Clave trabajador</td></tr>
                                       <tr>
                                           <td colspan="2">
                                               <asp:DropDownList runat="server" ID="ddl_puesto" CssClass="tbxreg"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_ddl_puesto" runat="server" ErrorMessage="Es necesario elegir un puesto" 
                                                Display="None" ControlToValidate="ddl_puesto" SetFocusOnError="True" ValidationGroup="vg_user" InitialValue="0"></asp:RequiredFieldValidator>
                                               <ajax:ValidatorCalloutExtender ID="vcoe_rfv_puesto" runat="server" TargetControlID="rfv_ddl_puesto" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                           </td>
                                           <td>
                                               <asp:TextBox runat="server" ID="txtClave" CssClass="tbxreg"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="rfv_clave" runat="server" ErrorMessage="Este identificador es indispensable"
                                                Display="None" ControlToValidate="txtClave" SetFocusOnError="True" ValidationGroup="vg_user" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_clave" runat="server" TargetControlID="rfv_clave" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                           </td>
                                       </tr>
                                   </table>
                                 </div></td></tr><tr><td>
                    
                                <div class="tituloceldaNegrita" style="text-align:center; padding: 20px 0px 10px 0px">Información de la cuenta</div></td></tr><tr><td>
                                <div style="text-align:center;">
                                    <table style="text-align:center; width:100%;">
                                        <tr><td>Usuario</td><td>Contraseña</td><td>Confirmar contraseña</td></tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtUser" CssClass="tbxreg_min"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_user" runat="server" ErrorMessage="Debes introducir un nombre de usuario"
                                                Display="None" ControlToValidate="txtUser" SetFocusOnError="True" ValidationGroup="vg_user" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_user" runat="server" TargetControlID="rfv_user" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                <ajax:FilteredTextBoxExtender ID="txtUser_flitro" runat="server" TargetControlID="txtUser" FilterMode="InvalidChars" 
                                                    InvalidChars="!&quot;#$%&amp;/()='¿?¡+*~][}{-:,;."></ajax:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPass" CssClass="tbxreg_min" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_pass" runat="server" ErrorMessage="Debes introducir una contraseña"
                                                Display="None" ControlToValidate="txtPass" SetFocusOnError="True" ValidationGroup="vg_user" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_pass" runat="server" TargetControlID="rfv_pass" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>

                                                <ajax:FilteredTextBoxExtender ID="txt_pass_filtro" runat="server" TargetControlID="txtPass" FilterMode="InvalidChars" 
                                                    InvalidChars="!&quot;#$%&amp;/()='¿?¡+*~][}{-:,;.<> &nbsp;`çÇ``^¨"></ajax:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtCPass" CssClass="tbxreg_min" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_cpass" runat="server" ErrorMessage="Debes introducir una contraseña"
                                                Display="None" ControlToValidate="txtCPass" SetFocusOnError="True" ValidationGroup="vg_user" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_cpass" runat="server" TargetControlID="rfv_cpass" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>

                                                <asp:CompareValidator ID="cv_cpass" runat="server" ErrorMessage=":\ No parece que ambas contraseñas sean iguales..."
                                                Display="None" ControlToValidate="txtCPass" SetFocusOnError="True" ValidationGroup="vg_user" ControlToCompare="txtPass" ></asp:CompareValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_cv_pass" runat="server" TargetControlID="cv_cpass" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>

                                                <ajax:FilteredTextBoxExtender ID="txt_cpass_filtro" runat="server" TargetControlID="txtCPass" FilterMode="InvalidChars" 
                                                    InvalidChars="!&quot;#$%&amp;/()='¿?¡+*~][}{-:,;.<> &nbsp;`çÇ``^¨"></ajax:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                    </table>
                                 </div></td></tr><tr><td>
                                 <div class="tituloceldaNegrita" style="text-align:center; padding: 20px 0px 10px 0px">Asignación de Privilegios</div>
                                    </td></tr>
                                    <tr>
                                        <td class="centrado">
                                            <asp:GridView ID="gv_menutop" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="false" ShowHeader="false" Width="200px" HorizontalAlign="Center">
                                                <Columns>
                                                    <asp:Templatefield>
                                                        <ItemTemplate>
                                                            <div class='<%# DataBinder.Eval(Container.DataItem, "css")%>'>
                                                                <asp:Label ID="lbl_topmenu" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "nombre")%>'></asp:Label>
                                                                <asp:HiddenField ID="hf_cabezalnum" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "cabezal_num")%>' />
                                                            </div>
                                                            <ajax:Accordion ID="acc_menuch" runat="server" CssClass="accordion" FadeTransitions="true" FramesPerSecond="40" HeaderCssClass="accordeon_menu_cabezal" HeaderSelectedCssClass="accordeon_menu_cabezal_seleccionado" RequireOpenedPane="false" SelectedIndex="-1" SuppressHeaderPostbacks="true" TransitionDuration="250">
                                                                <Panes>
                                                                    <ajax:AccordionPane ID="ap_menuch" runat="server">
                                                                        <Header>
                                                                            <div id="indicator"></div>
                                                                        </Header>
                                                                        <Content>
                                                                            <asp:GridView ID="gv_menusub" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="false" ShowHeader="false" Width="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <table style="width: 100%; margin: 0 auto; background: rgba(0,0,0,0.3); border-radius: 5px;"">
                                                                                                <tr>
                                                                                                    <td class='<%# DataBinder.Eval(Container.DataItem, "css")%>'>
                                                                                                        <table style="text-align:left;"><tr><td style="padding-left: 10px;">
                                                                                                            <asp:CheckBox ID="cbx_select" runat="server" />
                                                                                                            <asp:HiddenField ID="hf_idpage" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id_page")%>' />
                                                                                                        </td><td>
                                                                                                        <asp:Label ID="lbl_submenu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ruta")%>' 
                                                                                                            CssClass="boton_texto_menu" Text='<%# DataBinder.Eval(Container.DataItem, "nombre")%>' 
                                                                                                            Tooltip='<%# DataBinder.Eval(Container.DataItem, "extenso")%>'>
                                                                                                        </asp:Label></td></tr></table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </Content>
                                                                    </ajax:AccordionPane>
                                                                </Panes>
                                                            </ajax:Accordion>
                                                        </ItemTemplate>
                                                    </asp:Templatefield>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
            
                    </asp:View>
                    <asp:View ID="v_error" runat="server">
                        <%--<div>Error al dar de alta porque ya existe el usuario.</div>--%>
                        <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Intentar de nuevo" CssClass="boton_texto_dentro"/></td>
                                    </tr></table></div>
                                <div class="centrado" style="text-align:center;">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="img_error" ImageUrl="~/img/alert.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:( ups!</div>
                                    <div class="titulocelda" style="text-align:center">¡Ya existe un registro con ese nombre de usuario!<br /> Regrese e intente de nuevo con otro nombre de usuario</div>
                                </div>
                    </asp:View>

                 <asp:View runat="server" ID="v_exito">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar_" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                  
                                  
                                    <td style="font-size: 1.5em;">
                                        <asp:LinkButton ID="lb_regresar_" runat="server" CssClass="boton_texto_dentro" Text="Crear otro usuario de SIAAA" />
                         </td>
                                    </tr></table></div>           

                                   
                                <div style="text-align: center" class="centrado">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">El usuario se ha registrado correctamente en el sistema!
                                        <br />Si no se asignaron privilegios al usuario puede hacerlo en el mantenimiento a usuarios.</div>
                                </div>
               
                 </asp:View>
        </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"--%> 
      
        

    </div>
</asp:Content>

