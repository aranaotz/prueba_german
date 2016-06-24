<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master"  AutoEventWireup="false" CodeFile="accion_tutoriado.aspx.vb" Inherits="contents_accion_tutoriado" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_accion">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_accion">
               
                <asp:View runat="server" ID="v_cero">
                    
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Acciones tutoria</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un grupo para mostrar el listado de alumnos.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_grupos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Grupo">
                                        
                                        <ItemTemplate>
                                            
                                            <div>
                                                
                                                <asp:LinkButton ID="lb_grupo" runat="server" Text='<%# Bind("id_grupo")%>' CssClass="texto_boton_gv" OnClick="lb_grupo_Click" CommandArgument='<%# Bind("id_grupo")%>'>
                                                </asp:LinkButton>
                                               
                                                
                                            </div>
                                            
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="CICLO" HeaderText="Ciclo" ReadOnly="True" SortExpression="CICLO" Visible="False" />--%>
                                    <asp:BoundField DataField="nombre" HeaderText="Carrera" ReadOnly="True" SortExpression="nombre" ItemStyle-HorizontalAlign="Center" /> 
                                    <asp:BoundField DataField="grado" HeaderText="Grado" ReadOnly="True" SortExpression="grado" ItemStyle-HorizontalAlign="Center" />
                                     <asp:BoundField DataField="grupo" HeaderText="Grupo" ReadOnly="True" SortExpression="grupo" ItemStyle-HorizontalAlign="Center" />
                                     <asp:BoundField DataField="turno" HeaderText="Turno" ReadOnly="True" SortExpression="turno" ItemStyle-HorizontalAlign="Center" />
                                    
                                </Columns>
                                <HeaderStyle CssClass="gvheader" />
                                <RowStyle CssClass="gvrow" />
                            </asp:GridView>
                                      </td></tr>
                                </table>
                                </td></tr>
                        </table>
                        <asp:HiddenField  runat="server" ID="hf_ciclo"/>
                    </div>

                </asp:View>
                 <asp:View runat="server" ID="v_uno">
                      <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        
                                               </tr></table></div>
                   
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Listado de alumnos</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en la matrícula del alumno para mostrar mas detalles.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_alumnos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                     <asp:BoundField DataField="R" HeaderText="No." ReadOnly="True" SortExpression="R" ItemStyle-HorizontalAlign="Center" /> 
                                    
                                    <asp:TemplateField HeaderText="Matrícula">
                                        
                                        <ItemTemplate>
                                            
                                            <div>
                                                
                                                <asp:LinkButton ID="lb_matricula" runat="server" Text='<%# Bind("matricula")%>' CssClass="texto_boton_gv" OnClick="lb_matricula_Click" CommandArgument='<%# Bind("matricula")%>'>

                                                </asp:LinkButton>
                                                
                                                
                                            </div>
                                            
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="nombre" HeaderText="Nombre Completo" ReadOnly="True" SortExpression="nombre" />                        
                                     <asp:BoundField DataField="estatus" HeaderText="Estatus" ReadOnly="True" SortExpression="estatus" ItemStyle-HorizontalAlign="Center" />
                                    
                                </Columns>
                                <HeaderStyle CssClass="gvheader" />
                                <RowStyle CssClass="gvrow" />
                            </asp:GridView>
                                      </td></tr>
                                </table>
                                </td></tr>
                        </table>
                        <asp:HiddenField runat="server" ID="hf_matricula" />
                    </div>

                </asp:View>
                 <asp:View runat="server" ID="v_dos">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guarda_alumno" Text="Actualizar datos" CssClass="boton_texto_dentro"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_justificacion" Text="Justificantes" CssClass="boton_texto_dentro" /></td>
                         <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_accion" Text="Acción tutoría" CssClass="boton_texto_dentro" /></td>
                                               </tr></table></div>
                    <div style="padding-top:20px;text-align:center;" class="titulocategoria">Datos del alumno</div>
                      <div style="padding-top:20px;text-align:center;" class="titulocelda">Si deseas actualizar la infomación del alumno solo escribe en el cuadro de texto que deseas <br /> modificar y al finalizar presiona "Actualizar datos"</div>
                    
                    <div style="padding-top:20px;text-align:center;">
                        <table class="centrado" style="width:80%">
                            <tr>
                               <td class="titulocelda"style="width:25%"><asp:Image runat="server" ID="img_alumno" Width="150"   AlternateText="Foto no asignada"/></td>
                                <td class="titulocelda"style="width:25%"></td>
                                <td class="titulocelda"style="width:20%"> </td>
                                <td class="titulocelda"style="width:20%"> </td>
                            </tr>
                            <tr>
                               <td class="titulocelda"style="width:15%">Matricula</td>
                                <td class="titulocelda"style="width:25%">Nombres</td>
                                <td class="titulocelda"style="width:20%">Primer Apellido</td>
                                <td class="titulocelda"style="width:20%">Segundo Apellido</td>
                                <td class="titulocelda"style="width:20%">Fecha de nacimiento</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:15%"><asp:TextBox runat="server" ID="tbx_matricula" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_nombres" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_primero" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_segundo" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_nacimiento" CssClass="tbxreg" Enabled="False" ReadOnly="True"></asp:TextBox></td>
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
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_curp" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_rfc" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_nss" CssClass="tbxreg"></asp:TextBox></td>
                            </tr>
                            </table>
                         <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:50%">Correo Electrónico</td>
                                <td class="titulocelda"style="width:25%">Telefono Fijo</td>
                                <td class="titulocelda"style="width:25%">Telefono Móvil</td>                               
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:50%"><asp:TextBox runat="server" ID="tbx_email" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_fijo" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_movil" CssClass="tbxreg"></asp:TextBox></td>                              
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
                                <td class="titulocelda" style="width:50%"><asp:TextBox runat="server" ID="tbx_domicilio" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_ext" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_int" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:10%"><asp:TextBox runat="server" ID="tbx_cp" CssClass="tbxreg"></asp:TextBox></td>
                            </tr>
                            </table>
                        <table style="width:80%" class="centrado">
                            <tr>
                                <td class="titulocelda" style="width:50%">Padre o tutor</td>
                                <td class="titulocelda">Teléfono de contacto 1</td>
                                 <td class="titulocelda">Teléfono de contacto 2</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:50%"><asp:TextBox runat="server" ID="tbx_padre" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"><asp:TextBox runat="server" ID="tbx_contacto1" CssClass="tbxreg"></asp:TextBox></td>
                                 <td class="titulocelda"><asp:TextBox runat="server" ID="tbx_contacto2" CssClass="tbxreg"></asp:TextBox></td>
                            </tr>
                        </table>
                        
                    </div>  
                    
                    
                </asp:View>
                 <asp:View runat="server" ID="v_tres">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_vuelve" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Volver al inicio" CssClass="boton_texto_dentro" OnClick="lb_regresar_Click" /></td>
                                   
                                    </tr></table></div>           

                                   
                                <div>
                                    <div style="padding-top:150px; text-align:center;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">Los datos se han registrado correctamente en el sistema!
                                        </div>
                                </div>
               
                </asp:View>
                <asp:View runat="server" ID="v_cuatro">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras_" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        
                                               </tr></table></div>
                    
                    <div>
                        <div style="text-align:center;padding-top:20px" class="titulocategoria">Justificación de faltas</div>
                        <div style="text-align:center;padding-top:20px" class="titulocelda">Para justificar alguna falta del alumno primero elige la materia, después elige el mes<br />
                            y por último elige la cantidad de días a justificar
                             <div style="text-align:center;padding-top:20px"><asp:DropDownList runat="server" ID="ddl_materias" CssClass="ddlreg" AutoPostBack="true"></asp:DropDownList></div>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="v_cinco">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras_2" runat="server" ImageUrl="~/img/arrowback.png"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_temas" Text="Temas Abordados" CssClass="boton_texto_dentro" /></td>  
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_metas" Text="Metas y acuerdos" CssClass="boton_texto_dentro" /></td>
                         <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_giagnostico" Text="Diagnostico cuatrimestral" CssClass="boton_texto_dentro" /></td>
                        
                                               </tr></table></div>
                    
                    <div>
                          <div style="text-align:center;padding-top:20px" class="titulocategoria">ACCIÓN TUTORÍA<br />-- <asp:Label runat="server" ID="Label2"></asp:Label> --</div>

                        <div style="text-align:center;padding-top:40px" class="titulocelda">DESDE ESTA HERRAMIENTA PODRÁS LLEVAR A CABO LAS ACCIONES REFERENTES A LA TUTORÍA INDIVIDUAL
                            <br />
                            PARA LLEVAR A CABO ALGUNA ACCIÓN ELIGE ENTRE LAS TRES OPCIONES
                        </div>
                        

                        
                        
                    </div>
                </asp:View>
                <asp:View runat="server" ID="v_seis">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_accion" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_accion_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                       <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nuevameta" Text="Agregar Meta" CssClass="boton_texto_dentro" OnClick="lb_nuevameta_Click" /></td>   
                                               </tr></table></div>
                    
                    <div>
                        <div style="text-align:center;padding-top:20px" class="titulocategoria">ACCIÓN TUTORÍA<br />-- <asp:Label runat="server" ID="Label1"></asp:Label> --</div>
                         <div style="text-align:center;padding-top:20px" class="titulocelda"></div>
                        
                                        <table class="centrado" style="width:60%;padding-top:15px"">
                                            <tr>
                                                <td style="width:15px"><asp:Button runat="server" ID="cmd_guarda_meta" Text="Guardar" CssClass="botones" Font-Size="Large" ValidationGroup="vg_metas"/></td>
                                               
                                             
                                        </table>
                         <table class="centrado" style="width:60%" >
                                            <tr>
                                                  <td>
                                                      <asp:TextBox runat="server" ID="tbx_metas" CssClass="tbxreg" TextMode="MultiLine" Rows="4" ></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="rfv_tbx_metas" runat="server" ErrorMessage="¡Ingresa una meta!." 
                                                        Display="None" ControlToValidate="tbx_metas" SetFocusOnError="True" ValidationGroup="vg_metas" ></asp:RequiredFieldValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_tbx_metas" runat="server" TargetControlID="rfv_tbx_metas" CloseImageUrl="../img/close_coe.png" 
                                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                  </td>
                                              </tr>
                                        </table>
                        <div style="text-align:center;padding-top:20px;padding-bottom:20px;border: outset 1px  #BEBEBE; background: #BEBEBE; color:white" class="titulocelda">METAS Y ACUERDOS TOMADOS CON EL ALUMNO (A)</div>

                       
                        <div style="padding-top:10px">
                            <table class="centrado" style="width:80%">
                                <tr><td><asp:GridView runat="server" ID="gv_metas" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="5" EmptyDataText=":( Aun no se registra ninguna meta">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                   
                                    <Columns>
                                        <asp:BoundField DataField="fecha" HeaderText="FECHA" ReadOnly="True" SortExpression="fecha" ItemStyle-Width="100"  />
                                         <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" ReadOnly="True" SortExpression="descripcion"   />
                                          
                                              
                                                                                        
                                    </Columns>
                                        </asp:GridView>
                                     <asp:HiddenField runat="server" ID="hf_id_meta" />
                                    </td>

                                </tr>
                              
                            </table>
                             <asp:HiddenField runat="server" ID="hf_metas" />
                                                        <ajax:ModalPopupExtender ID="mpe_hf_metas" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_metas" PopupControlID="p_metas" BackgroundCssClass="modalBackground_gris" CancelControlID="lb_closeok">
                                                            </ajax:ModalPopupExtender>
                                                        <asp:Panel ID="p_metas" runat="server" style="display:none" DefaultButton="cmd_cancelar">
                                                        <table><tr><td>
                                                           <table class="popupmsg" style="width: 100%"><tr><td></td>
                                                           <td>
                                  
                                                           </td></tr>
                                                               <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="lb_closeok" runat="server"></asp:LinkButton>
                                           <div style="text-align:center">
                                               <asp:Image runat="server" ID="Image1" ImageUrl="~/img/alert.png" /><br /><br />Para guardar la meta es necesaria la contraseña del aspirante<br /><br />
                                               <table class="centrado" style="width:80%">
                                                   <tr>
                                                       <td> Matrícula:</td><td style="text-align:left"><strong><asp:Label runat="server" ID="lbl_matricula"></asp:Label></strong><br /></td>
                                                   </tr>
                                                   <tr>
                                                       <td>Constraseña:</td><td style="text-align:left"> <asp:TextBox runat="server" id="tbx_contra" CssClass="tbxreg_min" Width="200px" TextMode="Password"></asp:TextBox></td>
                                                   </tr>
                                               </table>

                                               <br />
                                              
                                                <asp:RequiredFieldValidator ID="rfv_contra" runat="server" ErrorMessage="Para guardar digita la contraseña del alumno"
                                                Display="None" ControlToValidate="tbx_contra" SetFocusOnError="True" ValidationGroup="vg_contra" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_contra" runat="server" TargetControlID="rfv_contra" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                               
                                           </div>
                                          
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%; text-align:center">
                                           <asp:Button ID="cmd_ok" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Continuar" OnClick="cmd_ok_Click" ValidationGroup="vg_contra"/>
                                            <asp:Button ID="cmd_cancelar" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Cancelar"/>
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel> 

                             <asp:HiddenField runat="server" ID="hf_contra" />
                                                        <ajax:ModalPopupExtender ID="mpe_hf_contra" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_contra" PopupControlID="p_contra" BackgroundCssClass="modalBackground_gris">
                                                            
                                                            </ajax:ModalPopupExtender>
                                                        <asp:Panel ID="p_contra" runat="server" style="display:none" DefaultButton="cmd_contra">
                                                        <table><tr><td>
                                                           <table class="popupmsg" style="width: 100%"><tr><td></td>
                                                           <td>
                                  
                                                           </td></tr>
                                                               <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                           <div style="text-align:center">
                                               <asp:Image runat="server" ID="Image2" ImageUrl="~/img/alert.png" /><br /><br />
                                               La contraseña es incorrecta, favor de intentar de nuevo
                                           </div>
                                          
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%; text-align:center">
                                           <asp:Button ID="cmd_contra" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Continuar" UseSubmitBehavior="false" />
                                           
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel> 
                                         
                        </div>

                </asp:View>
                <asp:View runat="server" ID="v_siete">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="lb_accion2" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_accion_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                     <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nuevotema" Text="Agregar Tema" CssClass="boton_texto_dentro" OnClick="lb_nuevotema_Click" /></td>   
                                               </tr></table></div>
                    
                    <div>

                        <div style="text-align:center;padding-top:20px" class="titulocategoria">ACCIÓN TUTORÍA<br />-- <asp:Label runat="server" ID="lbl_alumno"></asp:Label> --</div>
                         <div style="text-align:center;padding-top:20px;padding-bottom:20px;border: outset 1px  #BEBEBE; background: #BEBEBE; color:white" class="titulocelda">TEMAS ABORDADOS EN LA TUTORÍA INDIVIDUAL</div>
                       
                        <div style="padding-top:10px">
                            
                                        <table class="centrado" style="width:60%;padding-top:15px"">
                                            <tr>
                                                <td style="width:15px"><asp:Button runat="server" ID="cmd_guardar" Text="Guardar" CssClass="botones" Font-Size="Large" ValidationGroup="vg_temas"/></td>
                                                <td>
                                                    <asp:Button runat="server" ID="cmd_canalizar" Text="Canalizar" CssClass="botones" Font-Size="Large" ValidationGroup="vg_temas"/>
                                                             </td>
                                            </tr>
                                             
                                        </table>
                            <table class="centrado" style="width:60%" >
                                            <tr>
                                                  <td>
                                                      <asp:TextBox runat="server" ID="tbx_temas" CssClass="tbxreg" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="rfv_tbx_temas" runat="server" ErrorMessage="¡Ingresa una descripción!." 
                                                        Display="None" ControlToValidate="tbx_temas" SetFocusOnError="True" ValidationGroup="vg_temas" ></asp:RequiredFieldValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_tbx_temas" runat="server" TargetControlID="rfv_tbx_temas" CloseImageUrl="../img/close_coe.png" 
                                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                  </td>
                                              </tr>
                                        </table>
                            <table class="centrado" style="width:80%">
                                <tr><td> <div style="text-align:center;padding-top:20px;padding-bottom:10px" class="titulocelda">*Para modificar el contenido de un tema, da clic sobre la descripción de el, cuando termines de modificar da clic en Actualizar</div>
                                    <asp:GridView runat="server" ID="gv_temas" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="5" EmptyDataText=":( Aun no se registra ningún tema">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                   
                                    <Columns>
                                        <asp:BoundField DataField="fecha" HeaderText="FECHA" ReadOnly="True" SortExpression="fecha" ItemStyle-Width="100"  />
                                          <asp:TemplateField HeaderText="DESCRIPCIÓN">
                                              
                                        <ItemTemplate>
                                            
                                            <div>
                                                
                                                <asp:LinkButton ID="lb_descripion" runat="server" Text='<%# Bind("descripcion")%>' CssClass="texto_boton_gv" OnClick="lb_descripion_Click" CommandArgument='<%# Bind("id")%>'>

                                                </asp:LinkButton>
     
                                            </div>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>                      
                                        
                                        <asp:BoundField DataField="estatus" HeaderText="ESTATUS" ReadOnly="True" SortExpression="estatus" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                    </Columns>
                                        </asp:GridView>
                                     <asp:HiddenField runat="server" ID="hf_id" />
                                    </td>

                                </tr>
                               
                                <tr>
                                    <td>
                                        
                                    </td>
                                </tr> 
                            </table>
                             <asp:HiddenField runat="server" ID="hf_canalizar" />
                                                        <ajax:ModalPopupExtender ID="moe_hf_canalizar" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_canalizar" PopupControlID="p_canalizar" BackgroundCssClass="modalBackground_gris" CancelControlID="lb_closeok1">
                                                            
                                                            </ajax:ModalPopupExtender>
                                                        <asp:Panel ID="p_canalizar" runat="server" style="display:none" DefaultButton="cmd_no">
                                                        <table><tr><td>
                                                           <table class="popupmsg" style="width: 100%"><tr><td></td>
                                                           <td>
                                  
                                                           </td></tr>
                                                               <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="lb_closeok1" runat="server"></asp:LinkButton>
                                           <div style="text-align:center">
                                               <asp:Image runat="server" ID="img_alert" ImageUrl="~/img/alert.png" /><br />
                                               Estas a punto de canalizar al alumno para atención especializada, ¿deseas continuar?
                                           </div>
                                          
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%; text-align:center">
                                           <asp:Button ID="cmd_ok1" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Continuar" OnClick="cmd_ok1_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="cmd_no" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Cancelar"/>
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel> 
                                         
                        </div>

                </asp:View>
                <asp:View runat="server" ID="v_ocho">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="lb_accion3" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_accion_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td> 
                          <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guarda" Text="Guardar diagnostico" CssClass="boton_texto_dentro" OnClick="lb_guarda_Click" ValidationGroup="vg_diagnostico" /></td> 
                         <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td> 
                          <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_imprime_tutorias" Text="Imprimir registro" CssClass="boton_texto_dentro" ValidationGroup="vg_diagnostico" /></td>                          
                          </tr></table></div>                 
                    <div>
                        <div style="text-align:center;padding-top:20px" class="titulocategoria">ACCIÓN TUTORÍA<br />-- <asp:Label runat="server" ID="Label3"></asp:Label> --</div>
                         <div style="text-align:center;padding-top:20px;padding-bottom:20px;border: outset 1px  #BEBEBE; background: #BEBEBE; color:white" class="titulocelda">TEMAS ABORDADOS EN LA TUTORÍA INDIVIDUAL</div>
                        <div style="padding-bottom:20px;padding-top:20px">
                            <table class="centrado" style="width:60%">
                                <tr><td> 
                                    <asp:GridView runat="server" ID="gv_temas_diagnostico" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="5" EmptyDataText=":( Aun no se registra ningún tema">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />                                   
                                    <Columns>
                                        <asp:BoundField DataField="fecha" HeaderText="FECHA" ReadOnly="True" SortExpression="fecha" ItemStyle-Width="100"  />
                                         <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCION" ReadOnly="True" SortExpression="descripcion"   /> 
                                        <asp:BoundField DataField="estatus" HeaderText="ESTATUS" ReadOnly="True" SortExpression="estatus" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                    </Columns>
                                        </asp:GridView>                                     
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="text-align:center;padding-top:20px;padding-bottom:20px;border: outset 1px  #BEBEBE; background: #BEBEBE; color:white" class="titulocelda">METAS Y ACUERDOS TOMADOS CON EL ALUMNO (A)</div>

                        <div style="padding:20px 0 20px 0">
                             <table class="centrado" style="width:60%">
                                <tr><td><asp:GridView runat="server" ID="gv_metas_diagnostico" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="5" EmptyDataText=":( Aun no se registra ninguna meta">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                   
                                    <Columns>
                                        <asp:BoundField DataField="fecha" HeaderText="FECHA" ReadOnly="True" SortExpression="fecha" ItemStyle-Width="100"  />
                                         <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" ReadOnly="True" SortExpression="descripcion"   />
                                          
                                              
                                                                                        
                                    </Columns>
                                        </asp:GridView>
                                    
                                    </td>

                                </tr>
                              
                            </table>
                        </div>
                        <div style="text-align:center;padding-top:20px;padding-bottom:20px;border: outset 1px  #BEBEBE; background: #BEBEBE; color:white" class="titulocelda">DIAGNOSTICO CUATRIMESTRAL</div>
                        <div style="text-align:center;padding: 20px 0 10px 0"><strong><asp:Label runat="server" ID="lbl_msgs"></asp:Label></strong></div>
                         <div style="text-align:left;padding-top:40PX;padding-left:340px">DIAGNOSTICO DEL ALUMNO GUARDADO EL:  <strong><asp:Label runat="server" ID="lbl_fecha" Text="(AUN NO SE GUARDA EL DIAGNOSTICO)"></asp:Label></strong></div>
                          <div style="text-align:center"><asp:TextBox runat="server" ID="tbx_diagnostico" CssClass="tbxreg" Width="1000px" TextMode="MultiLine" Rows="10"></asp:TextBox></div>
                         
                                               <asp:RequiredFieldValidator ID="rfv_tbx_diagnostico" runat="server" ErrorMessage="Aun no escribes el diagnostico"
                                                Display="None" ControlToValidate="tbx_diagnostico" SetFocusOnError="True" ValidationGroup="vg_diagnostico" ></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vcoe_diagnostico" runat="server" TargetControlID="rfv_tbx_diagnostico" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>

                        </div>

                    <asp:HiddenField runat="server" ID="hf_diagnostico" />
                                                        <ajax:ModalPopupExtender ID="mpe_hf_diagnostico" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_diagnostico" PopupControlID="p_diagnostico" BackgroundCssClass="modalBackground_gris" CancelControlID="lb_closeok2">
                                                            
                                                            </ajax:ModalPopupExtender>
                                                        <asp:Panel ID="p_diagnostico" runat="server" style="display:none" DefaultButton="cmd_cancelardiag">
                                                        <table><tr><td>
                                                           <table class="popupmsg" style="width: 100%"><tr><td></td>
                                                           <td>
                                  
                                                           </td></tr>
                                                               <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="lb_closeok2" runat="server"></asp:LinkButton>
                                           <div style="text-align:center">
                                               <asp:Image runat="server" ID="Image3" ImageUrl="~/img/alert.png" /><br />
                                               Este (a) alumno (a) ya tiene una diagnostico cuatrimestral este ciclo, si deseas modificarlo presiona "Modifcar"
                                               <br />de lo contrario presiona "Cancelar"
                                           </div>
                                          
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%; text-align:center">
                                           <asp:Button ID="cmd_modificar" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Modificar" OnClick="cmd_modificar_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="cmd_cancelardiag" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Cancelar"/>
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel> 

                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

