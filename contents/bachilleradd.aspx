<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="bachilleradd.aspx.vb" Inherits="contents_bachilleradd" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_bachilleradd">
       <ContentTemplate>
           <asp:MultiView runat="server" ID="mv_bachilleradd">
               <asp:View runat="server" ID="v_cero">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_recarga" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nueva" Text="Agregar Bachillerato" CssClass="boton_texto_dentro" OnClick="lb_nueva_Click"/></td>
        </tr></table></div>
                    <table class="centrado"><tr><td class="titulocategoria" style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">Mantenimiento al catálogo de Bachilleratos</td></tr>
                        <tr><td style="padding-bottom: 20px; text-align:center;">Para ver los detalles o eliminar un bachillerato, haga click sobre el nombre.</td></tr><tr><td>
                    
                            <asp:Panel ID="p_busqueda" runat="server" DefaultButton="cmd_buscar"><table class="centrado"><tr><td style="padding: 0 10px 0 0">Bachillerato</td><td>
                    <asp:TextBox ID="tbx_busqueda" runat="server" CssClass="tbxreg" MaxLength="100" Width="400px"></asp:TextBox>
                        <asp:RequiredfieldValidator ID="rfv_bachilleratos" runat="server" ValidationGroup="bachillerato" ControlToValidate="tbx_busqueda" ErrorMessage="¿Que buscamos?" Display="None"></asp:RequiredfieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vcoe_tbx_busqueda" runat="server" TargetControlID="rfv_bachilleratos" CloseImageUrl="../img/close_coe.png" CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True" PopupPosition="BottomRight"></ajax:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="rev_busqueda" runat="server" ValidationGroup="bachillerato" ControlToValidate="tbx_busqueda" ErrorMessage="Por lo menos debes escribir 4 carácteres." Display="None" ValidationExpression="([a-zA-Z0-9\s]){4,}\w+"></asp:RegularExpressionValidator>
                        <ajax:ValidatorCalloutExtender ID="vcoe_rev_busqueda" runat="server" TargetControlID="rev_busqueda" CloseImageUrl="../img/close_coe.png" CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True" PopupPosition="BottomRight"></ajax:ValidatorCalloutExtender>
                   </td>
                    <td><asp:Button ID="cmd_buscar" runat="server" Text="Buscar bachillerato(s)" CssClass="botones" style="font-size: 100%;" CausesValidation="True" ValidationGroup="bachillerato"/></td></tr></table>
                            </asp:Panel>
                                                                                                                                                                  </td></tr>
                    <tr><td style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">
                        <asp:GridView ID="gv_resultados" runat="server" AutoGenerateColumns="false" EmptyDataText="No se han encontrado coincidencias :(" GridLines="None" ShowHeader="False" HorizontalAlign="center">
                            <Columns>
                                <asp:TemplateField><ItemTemplate>
                                    <div id="gv_result" style="text-align:left;"><table><tr><td><asp:LinkButton ID="lb_gvresultado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' CssClass="boton_texto_resultados" OnClick="lb_gvresultado_Click"></asp:LinkButton></td>
                                       <%-- <td style="padding: 7px 0px 0px 5px;"><asp:imageButton ID="ib_delete" runat="server" ImageUrl="../img/close_coer.png"/></td>--%></tr></table></div>
                                                   </ItemTemplate></asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </td></tr>
                </table>
               </asp:View>
               <asp:View runat="server" ID="v_uno">
                   <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em; margin-left: 80px;"><asp:Linkbutton runat="server" ID="lb_back" Text="Regresar" CssClass="boton_texto_dentro" OnClick="lb_back_Click"/></td>
                       <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                       <td style="font-size: 1.5em; margin-left: 80px;">
                           <asp:Linkbutton runat="server" ID="lb_eliminar" Text="Eliminar Bachillerato" CssClass="boton_texto_dentro" CausesValidation="false"/>
                           <ajax:ConfirmButtonExtender ID="cbe_eliminar" runat="server" ConfirmText="Se eliminará permanentemente el Bachillerato. ¿Desea continuar?" TargetControlID="lb_eliminar"></ajax:ConfirmButtonExtender>
                       </td>
        </tr></table></div>
                   <div>
                       <div class="titulocategoria" style="text-align:center">Información del Bachillerato</div>
                       <div style="padding-top:20px">
                           <asp:GridView ID="gv_detalle_bachi" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="5"  EmptyDataText=":( No hay datos por mostrar..">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:BoundField DataField="NOMBRE" HeaderText="Escuela"  SortExpression="NOMBRE" />
                                    <asp:BoundField DataField="ESTADO" HeaderText="Estado"  SortExpression="ESTADO" />
                                    <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio"  SortExpression="MUNICIPIO" />
                                    <asp:BoundField DataField="LOCALIDAD" HeaderText="Localidad" SortExpression="LOCALIDAD" />
                                    <asp:BoundField DataField="DOMICILIO" HeaderText="Domicilio" SortExpression="DOMICILIO" />
                                    <asp:BoundField DataField="CP" HeaderText="C.P." SortExpression="CP" />
                                    <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" SortExpression="TELEFONO" />
                                </Columns>
                                <HeaderStyle CssClass="gvheader" />
                                <RowStyle CssClass="gvrow" />
                            </asp:GridView>
                       </div>
                   </div>
               </asp:View>
               <asp:View runat="server" ID="v_dos">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresa" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresa_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_save" Text="Guardar" CssClass="boton_texto_dentro" OnClick="lb_save_Click" ValidationGroup="vg_bachilleradd"/></td>
        </tr></table></div>
                   <div class="titulocategoria" style="text-align:center">Nuevo bachillerato</div>

                   <div style="padding:20px 200px 0 200px; text-align:left">
                       <table style="width:100%;">
                           <tr>
                                <td>NOMBRE</td>

                           </tr>
                           <tr>
                                <td><asp:TextBox runat="server" ID="tbx_nombre" CssClass="tbxreg" ></asp:TextBox></td>
                               <asp:RequiredFieldValidator ID="rfv_tbx_nombre" runat="server" ErrorMessage="¡Escribe el nombre del bachillerato!." 
                                       Display="None" ControlToValidate="tbx_nombre" SetFocusOnError="True" ValidationGroup="vg_bachilleradd"></asp:RequiredFieldValidator>
                                   <ajax:ValidatorCalloutExtender ID="vcoe_tbx_nombre" runat="server" TargetControlID="rfv_tbx_nombre" CloseImageUrl="../img/close_coe.png" 
                                       CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                   <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbx_nombre"  ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789 &nbsp;-" />
                           </tr>

                       </table>
                   </div>
                     <div style="padding:20px 200px 0 200px; text-align:left">
                       <table style="width:100%;">
                           <tr><td style="width:50%;">ESTADO</td><td style="width:50%;">MUNICIPIO</td></tr>
                           <tr>
                               <td style="width:50%;"><asp:DropDownList runat="server" ID="ddl_estado" CssClass="tbxreg" AutoPostBack="true"></asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="rfv_ddl_estado" runat="server" ErrorMessage="¡Selecciona un estado!." 
                                    Display="None" ControlToValidate="ddl_estado" SetFocusOnError="True" ValidationGroup="vg_bachilleradd" InitialValue="0"></asp:RequiredFieldValidator>
                                 <ajax:ValidatorCalloutExtender ID="vcoe_rfv_ddl_estado" runat="server" TargetControlID="rfv_ddl_estado" CloseImageUrl="../img/close_coe.png" 
                                     CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                               </td>
                               <td style="width:50%;"><asp:DropDownList runat="server" ID="ddl_municipio" CssClass="tbxreg"></asp:DropDownList></td>
                               <asp:RequiredFieldValidator ID="rfv_ddl_municipios" runat="server" ErrorMessage="¡Selecciona un municipio!." 
                                     Display="None" ControlToValidate="ddl_municipio" SetFocusOnError="True" ValidationGroup="vg_bachilleradd" InitialValue="0"></asp:RequiredFieldValidator>
                                 <ajax:ValidatorCalloutExtender ID="vcoe_ddl_municipio" runat="server" TargetControlID="rfv_ddl_municipios" CloseImageUrl="../img/close_coe.png" 
                                     CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                           </tr>
                       </table>
                   </div>
                    <div style="padding:20px 200px 0 200px; text-align:left">
                       <table style="width:100%;">
                           <tr>
                                <td>LOCALIDAD</td>

                           </tr>
                           <tr>
                                <td><asp:TextBox runat="server" ID="tbx_localidad" CssClass="tbxreg" ></asp:TextBox></td>
                               <asp:RequiredFieldValidator ID="rfv_tbx_localidad" runat="server" ErrorMessage="¡Escribe el nombre de la localidad!." 
                                       Display="None" ControlToValidate="tbx_localidad" SetFocusOnError="True" ValidationGroup="vg_bachilleradd"></asp:RequiredFieldValidator>
                                   <ajax:ValidatorCalloutExtender ID="vcoe_tbx_localidad" runat="server" TargetControlID="rfv_tbx_nombre" CloseImageUrl="../img/close_coe.png" 
                                       CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                   <ajax:FilteredTextBoxExtender ID="ftbe_tbx_localidad" runat="server" TargetControlID="tbx_localidad"  ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz1234567890" />
                           </tr>

                       </table>
                   </div>
                   <div style="padding:20px 200px 0 200px; text-align:left">
                       <table style="width:100%;">
                           <tr><td style="width:75%;">DOMICILIO</td><td>CP</td><td>TELEFONO</td></tr>
                           <tr>
                               <td style="width:75%;"><asp:TextBox runat="server" ID="tbx_domicilio" CssClass="tbxreg" ></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="rfv_tbx_domicilio" runat="server" ErrorMessage="¡Escribe el domicilio!." 
                                       Display="None" ControlToValidate="tbx_domicilio" SetFocusOnError="True" ValidationGroup="vg_bachilleradd"></asp:RequiredFieldValidator>
                                   <ajax:ValidatorCalloutExtender ID="vcoe_tbx_domicilio" runat="server" TargetControlID="rfv_tbx_domicilio" CloseImageUrl="../img/close_coe.png" 
                                       CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                   <ajax:FilteredTextBoxExtender ID="ftbe_tbx_domicilio" runat="server" TargetControlID="tbx_domicilio"  ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz1234567890" />
                               </td>
                               <td><asp:TextBox runat="server" ID="tbx_cp" CssClass="tbxreg" AutoCompleteType="HomeZipCode" MaxLength="5" ></asp:TextBox>
                                    
                                   <asp:RequiredFieldValidator ID="rfv_tbx_cp" runat="server" ErrorMessage="¡Escribe tu Código Postal!." 
                                       Display="None" ControlToValidate="tbx_cp" SetFocusOnError="True" ValidationGroup="vg_bachilleradd"></asp:RequiredFieldValidator>
                                   <ajax:ValidatorCalloutExtender ID="vcoe_rfv_tbx_cp" runat="server" TargetControlID="rfv_tbx_cp" CloseImageUrl="../img/close_coe.png" 
                                       CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                   <ajax:FilteredTextBoxExtender ID="ftbe_rfv_tbx_cp" runat="server" TargetControlID="tbx_cp" FilterType="Numbers"/>
                                   
                               </td>
                               <td><asp:TextBox runat="server" ID="tbx_telefono" CssClass="tbxreg" ></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_telefono" ErrorMessage="¡Escribe un número teleónico!" Display="None"
                                        ControlToValidate="tbx_telefono" SetFocusOnError="true" ValidationGroup="vg_bachilleradd"></asp:RequiredFieldValidator>
                                   <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_tbx_telefono" TargetControlID="rfv_tbx_telefono" CloseImageUrl="../img/close_coe.png" 
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                   <ajax:FilteredTextBoxExtender runat="server" ID="ftbe_tbx_telefono" TargetControlID="tbx_telefono" ValidChars="0123456789"></ajax:FilteredTextBoxExtender>
                               </td>
                           </tr>
                       </table>
                   </div>
               </asp:View>
               <asp:View ID="v_tres" runat="server">
                        <%--<div>Error al dar de alta porque ya existe el usuario.</div>--%>
                        <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Intentar de nuevo" CssClass="boton_texto_dentro" OnClick="lb_regresar_Click"/></td>
                                    </tr></table></div>
                                <div class="centrado" style="text-align:center;">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="img_error" ImageUrl="~/img/alert.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:( ups!</div>
                                    <div class="titulocelda" style="text-align:center">¡Ya existe un registro con ese nombre de bachillerato!<br /> Regrese e intente de nuevo con otro nombre </div>
                                </div>
                    </asp:View>
                <asp:View runat="server" ID="v_cuatro">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar__Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                  
                                  
                                    <td style="font-size: 1.5em;">
                                        <asp:LinkButton ID="lb_regresar_" runat="server" CssClass="boton_texto_dentro" Text="Agrega otro bachillerato" OnClick="lb_regresar__Click" />
                         </td>
                                    </tr></table></div>           

                                   
                                <div style="text-align: center" class="centrado">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">El bachillerato se ha registrado correctamente en el sistema!
                                        </div>
                                </div>
               
                 </asp:View>
           </asp:MultiView>
       </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>

