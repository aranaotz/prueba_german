<%@ Page Title="" Language="VB" MasterPageFile="~/logins/logins.master" AutoEventWireup="false" CodeFile="peducativo.aspx.vb" Inherits="contents_peducativo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_peducativo">
        <ContentTemplate>
            
            <asp:MultiView runat="server" ID="mv_peducativo">
                <asp:View runat="server" ID="v_listado">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_recarga" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nuevo" Text="Nuevo programa educativo" CssClass="boton_texto_dentro" OnClick="lb_nuevo_Click" /></td>
            </tr></table></div>
                    <table class="centrado" style="text-align:center;"><tr><td>
                    <div>
                        <div class="titulocategoria" style="text-align:center">Mantenimiento a programas educativos</div>
                        
                        <div class="titulocelda" style="text-align:center; padding: 20px;">Haga click en la clave de un programa para editarlo o eliminarlo.</div>
                        <div>
                            <asp:GridView runat="server" ID="gv_listado" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="center"
                                style="border:solid 1px #ccc" CellSpacing="0" CellPadding="10" HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Clave">
                                        <ItemTemplate>
                                            <div>   
                                                <asp:LinkButton runat="server" ID="lb_clave" Text='<%# Bind("CLAVE")%>' CssClass="texto_boton_gv" OnClick="lb_clave_Click" CommandArgument='<%# Bind("CLAVE")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NIVEL" HeaderText="Nivel" SortExpression="NIVEL" />
                                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Left"/>
                                    <asp:BoundField DataField="activo" HeaderText="Activo" SortExpression="ACTIVO" ItemStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="autorizado" HeaderText="Autorizado" SortExpression="AUTORIZADO" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:MMMM dd, yyyy}"/>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div><table><tr><td>
                </asp:View>
                <asp:View runat="server" ID="v_nuevoPrograma">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar cambios" CssClass="boton_texto_dentro" OnClick="lb_guardar_Click" ValidationGroup="neducativo"/></td>
              </tr></table></div>
                    <table class="centrado" style="text-align:center;"><tr><td>
                        <div>
                        <div class="titulocategoria" style="text-align:center;">Nuevo programa educativo</div>
                            <div class="titulocelda" style="text-align:center; padding: 20px;">Selecciona y llena los campos para el nuevo programa de estudio.<br />Éste es independiente de los ciclos. Para guardarlo haz click en guardar cambios.</div>
                        <div style="text-align:center;">
                            <div>
                                <table class="centrado">
                                    <tr>
                                        <td>Clave</td><td>Nivel</td>
                                    </tr>
                                     <tr>
                                        <td><asp:TextBox ID="txtClave" runat="server" CssClass="tbxreg"></asp:TextBox></td>
                                         <asp:RequiredFieldValidator runat="server" ID="rfv_clave" ErrorMessage="El identificador clave es indispensable" Display="None"
                                             ControlToValidate="txtClave" SetFocusOnError="true" ValidationGroup="neducativo" ></asp:RequiredFieldValidator>
                                         <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_clave" TargetControlID="rfv_clave" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                         <td><asp:DropDownList runat="server" ID="ddl_nivel" CssClass="tbxreg"></asp:DropDownList>
                                             <asp:TextBox ID="txtNivel" runat="server" CssClass="tbxreg" Text="TSU" Visible="false"></asp:TextBox></td>
                                          
                                    </tr>
                                    <%--<tr><td><asp:DropDownList runat="server" ID="ddl_nivel" CssClass="tbxreg"></asp:DropDownList></td></tr>--%>
                                </table>
                            </div>
                            <div>
                                <table class="centrado" style="width:100%; text-align:center;">
                                    <tr>
                                        <td>Nombre</td>
                                    </tr>
                                     <tr>
                                        <td><asp:TextBox ID="txtNombre" runat="server" CssClass="tbxreg"></asp:TextBox></td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_nombre" ErrorMessage="El identificador nombre es indispensable" Display="None"
                                             ControlToValidate="txtNivel" SetFocusOnError="true" ValidationGroup="neducativo" ></asp:RequiredFieldValidator>
                                         <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_nombre" TargetControlID="rfv_nombre" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="id~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender> 
                                    </tr>
                                </table>
                            </div>
                        </div>

                    </div></td></tr></table>
                </asp:View>
                <asp:View runat="server" ID="v_exito">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_vuelve" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_listado" Text="Volver al listado" CssClass="boton_texto_dentro" OnClick="lb_listado_Click" /></td>
                                    <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_programa" Text="Agregar nuevo programa educativo" CssClass="boton_texto_dentro" OnClick="lb_programa_Click" /></td>
                                    </tr></table></div>           

                                   
                                <div>
                                    <div style="padding-top:150px; text-align:center"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">El programa educativo se ha registrado correctamente en el sistema!
                                        </div>
                                </div>
               
                </asp:View>
                 <asp:View ID="v_error" runat="server">
                  
                        <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar" runat="server" ImageUrl="~/img/arrowback.png"  OnClick="ib_regresar_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Regresar" CssClass="boton_texto_dentro" OnClick="lb_regresar_Click" /></td>
                                    </tr></table></div>
                                <div>
                                    <div style="padding-top:150px;text-align:center"><asp:Image runat="server"  ID="img_error" ImageUrl="~/img/alert.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:( ups!</div>
                                    <div class="titulocelda" style="text-align:center">Ya existe un registro con esa clave!<br /> Favor de regresar e intentar de nuevo con otra clave</div>
                                </div>
                    </asp:View>

                <asp:View runat="server" ID="v_editar">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png"  OnClick="ib_atras_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guarda" Text="Guardar cambios" CssClass="boton_texto_dentro" OnClick="lb_guarda_Click" />
                                    </td>
                                    <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                         <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_elimina" Text="Eliminar programa" CssClass="boton_texto_dentro" /></td>
                                    </tr></table></div>
                    <table class="centrado" style="text-align:center; margin:auto;"><tr><td>
                    <div>
                        <div class="titulocategoria" style="text-align:center;">Editar programa educativo</div>
                        <div class="titulocelda" style="padding:10px; text-align:center;">Editando programa con clave: <strong><asp:Label runat="server" ID="lbl_clave"></asp:Label></strong></div>
                        <div style="padding-left:40px;padding-top:20px;">
                            <asp:DetailsView runat="server" id="dv_editar" AutoGenerateRows="false" GridLines="None" HorizontalAlign="Left">
                                <Fields>
                                    <asp:TemplateField HeaderText="Nivel" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="titulocelda">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtEnivel" CssClass="tbxreg" Text='<%# Bind("nivel")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Clave" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="titulocelda">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtEclave" CssClass="tbxreg" Text='<%# Bind("cv_carrera")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="titulocelda">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtEnombre" CssClass="tbxreg" Text='<%# Bind("nombre")%>' Width="700px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                            </asp:DetailsView>
                           
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
                     <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;"><pre><asp:Button ID="btn_continuar" runat="server" Text="Continuar" CssClass="botones" Font-Size="Large" />     <asp:Button ID="cmd_cancelar" runat="server" Text="Cancelar" CssClass="botones" Font-Size="Large" /></pre></td>

                 </tr>

                 </table></td>
                 </tr>
                </table>
            </asp:Panel>


                        </div>
                    </div></td></tr></table>

                </asp:View>
                <asp:View runat="server" ID="v_elimina_ok">
                    <div class="topbar"><table class="centrado"><tr><td><asp:ImageButton ID="ib_regresa" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_lista" Text="Volver al listado" CssClass="boton_texto_dentro" OnClick="lb_listado_Click" /></td>
                                    
                                    </tr></table></div>           

                                   
                                <div>
                                    <div style="padding-top:150px; text-align:center"><asp:Image runat="server"  ID="Image1" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">El programa educativo se ha eliminado correctamente del sistema!
                                        </div>
                                </div>
               
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

