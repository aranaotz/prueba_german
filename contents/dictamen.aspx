<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="dictamen.aspx.vb" Inherits="contents_dictamen" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <div>
    <%'<asp:UpdatePanel runat="server" ID="up_dictamen"><ContentTemplate> %>
           <asp:MultiView runat="server" ID="mv_dictamen">
               <asp:View runat="server" ID="v_cero">
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Dictaminación de aspirantes</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Para consultar un dictamen o realizar un nuevo dictamen, haga click en el ciclo deseado.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_ciclos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                        style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                        <AlternatingRowStyle CssClass="gvrow_alt" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Ciclo"><ItemTemplate><div><asp:LinkButton ID="lb_ciclo" runat="server" Text='<%# Bind("CICLO")%>' CssClass="texto_boton_gv" OnClick="lb_ciclo_Click" CommandArgument='<%# Bind("CICLO")%>'>
                                       
                                                        </asp:LinkButton></div></ItemTemplate></asp:TemplateField>
                                            <%--<asp:BoundField DataField="CICLO" HeaderText="Ciclo" ReadOnly="True" SortExpression="CICLO" Visible="False" />--%>
                                            <asp:BoundField DataField="FECHAS" HeaderText="Periodo" ReadOnly="True" SortExpression="FECHAS" />
                                            <asp:BoundField DataField="INICIO" HeaderText="Inicio del ciclo" ReadOnly="True" SortExpression="INICIO" />
                                            <asp:BoundField DataField="FIN" HeaderText="Fin del ciclo" ReadOnly="True" SortExpression="FIN" />
                                            <asp:CheckBoxField DataField="ACTIVO" HeaderText="Activo" SortExpression="ACTIVO" />
                                        </Columns>
                                        <HeaderStyle CssClass="gvheader" />
                                        <RowStyle CssClass="gvrow" />
                                      </asp:GridView>
                                      </td></tr>
                                </table>
                                </td></tr>
                        </table>
                    </div>
               </asp:View>
               <asp:View runat="server" ID="v_uno">
                   <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_importar" Text="Subir Calificaciones" CssClass="boton_texto_dentro" OnClick="lb_importar_Click"/></td>
                       <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_manual" Text="Agregar Manualmente" CssClass="boton_texto_dentro" OnClick="lb_manual_Click"/></td>
                        </tr></table></div>
                   <table style="margin:auto; text-align: center;"><tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Dictaminación de aspirantes</td></tr></table>
                    <div>
                        <div class="titulocelda" style="text-align:center; padding: 20px;"><span style="font-weight: bold;">*Se muestran todas las carreras que fueron habilitadas para el ciclo actual.</span><br />
                            Si la carrera no tiene aspirantes, aparece un "0" en la columna que lo indica.<br />Para iniciar el proceso de DICTAMINACION es necesario importar los resultados del
                            examen "EXANI". Prepare su archivo de importacion y pulse -Subir Calificaciones- para iniciar.
                        </div>
                        <asp:Label runat="server" ID="lbl_ciclo" Visible="false"></asp:Label>
                        
                        <asp:GridView runat="server" ID="gv_carreras" GridLines="None" AutoGenerateColumns="false" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                            style="border:solid 1px #ccc" CellPadding="10" CellSpacing="0" EmptyDataText=":( No hay datos para mostrar..." HeaderStyle-CssClass="gvheader">
                            <AlternatingRowStyle CssClass="gvrow_alt" />
                            <Columns>
                                <asp:TemplateField HeaderText="Clave" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <div>
                                           <asp:LinkButton runat="server" ID="lb_clave" Text='<%# Bind("CARRERA")%>' CssClass="texto_boton_gv" CommandArgument='<%# Bind("CARRERA")%>' OnClick="lb_clave_Click"
                                                Enabled='<%# Bind("enable")%>'></asp:LinkButton>
                                       </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="NOMBRE" HeaderText="Carrera" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Left"/>
                                <asp:BoundField DataField="CANDIDATOS" HeaderText="Candidatos" SortExpression="CANDIDATOS" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="IMPORTADO" HeaderText="Importada" SortExpression="IMPORTADO" ItemStyle-HorizontalAlign="Center"/>
                            </Columns>
                        </asp:GridView>
                        
                        
                        
                    </div>
                   <asp:Button runat="server" ID="btnModalPopUp" style="display:none"/>
                   <ajax:ModalPopupExtender runat="server" ID="mod_dictamen" TargetControlID="btnModalPopUp" PopupControlID="p_dictamen" CancelControlID="ib_close"
                        BackgroundCssClass="modalBackground_gris"></ajax:ModalPopupExtender>
                  <asp:Panel ID="p_dictamen" runat="server" style="display:none; width:100%; padding-left:60%;" >
                     <table style="width: 40%;"><tr><td style="text-align: right; padding: 7px;"><asp:ImageButton ID="ib_close" runat="server" ImageUrl="~/img/close_coe.png" /></td></tr><tr><td>
                         <table style="background:#FFF; width:100%; border-radius: 5px;">
                             <tr>
                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px; font-size: 1.5em;">
                                     Herramienta de dictaminación de alumnos
                                </td>                               
                            </tr>

                             <tr>
                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;">
                                     Haz seleccionado la carrera: <strong><asp:Label runat="server" ID="lbl_carrera"></asp:Label></strong>
                                </td>                               
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;">
                                   <asp:DropDownList runat="server" ID="ddl_turnos" CssClass="ddlreg_cien" Width="200px"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_turnos" runat="server" ErrorMessage="Es necesario elegir un turno" 
                                                Display="None" ControlToValidate="ddl_turnos" SetFocusOnError="True" ValidationGroup="dictamen" InitialValue="0"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_ddl_turnos" runat="server" TargetControlID="rfv_ddl_turnos" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                </td>
                             </tr>
                              <tr>
                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;">
                                    ¿Cuántos aspirantes deseas dictaminar?<br />
                                    <br />
                                   <asp:TextBox runat="server" ID="tbx_cuantos" CssClass="tbxreg" Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfv_cuantos" ErrorMessage="¿Cuántos aspirantes deseas dictaminar?"
                                         Display="None" ControlToValidate="tbx_cuantos" SetFocusOnError="true" ValidationGroup="dictamen"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_cuantos" TargetControlID="rfv_cuantos" CloseImageUrl="~/img/close_coe.png"
                                         CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                         <tr>
                             <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;"><pre><asp:Button ID="btn_continuar" runat="server" Text="Continuar" ValidationGroup="dictamen" CssClass="botones" Font-Size="Large" OnClick="btn_continuar_Click" />     <asp:Button ID="cmd_cancelar" runat="server" Text="Cancelar" CssClass="botones" Font-Size="Large" /></pre></td>
                         </tr>
                         </table></td>
                         </tr>
                        </table>
                </asp:Panel>
               </asp:View>
                 <asp:View runat="server" ID="v_dos">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_atras_Click1"  /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_atras" Text="Regresar al inicio" CssClass="boton_texto_dentro" OnClick="lb_atras_Click" /></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_exportar" Text="Exportar a Excel" CssClass="boton_texto_dentro" OnClick="lb_exportar_Click" /></td>
                        </tr></table></div> 
                        
                           
                        <div style="padding-top:50px;">
                           <asp:GridView runat="server" ID="gv_listado" GridLines="None" AutoGenerateColumns="false" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                               style="border:solid 1px #CCC" CellPadding="10" CellSpacing="0" EmptyDataText=":( No hay datos para mostrar" HeaderStyle-CssClass="gvheader"
                                AlternatingRowStyle-CssClass="gvrow_alt">
                               <Columns>
                                   <asp:TemplateField><ItemTemplate><asp:HiddenField ID="hf_folio" runat="server" Value='<%# Eval("FOLIO")%>' /></ItemTemplate></asp:TemplateField>
                                    <asp:TemplateField><ItemTemplate><asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("ID")%>' /></ItemTemplate></asp:TemplateField>
                                  <%-- <asp:TemplateField HeaderText="Clave">
                                    <ItemTemplate>
                                       <div>
                                           <asp:LinkButton runat="server" ID="lb_folio" Text='<%# Bind("ustring")%>' CssClass="texto_boton_gv" CommandArgument='<%# Bind("ustring")%>' >

                                           </asp:LinkButton>
                                       </div>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                   <asp:BoundField DataField="NOMBRE" HeaderText="Nombre(s)" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="PATERNO" HeaderText="Apellido Paterno" SortExpression="PATERNO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="MATERNO" HeaderText="Apellido Materno" SortExpression="MATERNO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="TURNO" HeaderText="Turno" SortExpression="TURNO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="BACHILLERATO" HeaderText="P. Bachillerato" SortExpression="BACHILLERATO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="EXANI" HeaderText="Exani" SortExpression="EXANI" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="SUMA" HeaderText="Puntaje" SortExpression="SUMA" ItemStyle-HorizontalAlign="Center" />
                                   <asp:TemplateField HeaderText="Dictaminado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"><ItemTemplate><asp:CheckBox runat="server" ID="cbx_activo" Checked='<%# Bind("DICTAMINADO")%>' AutoPostBack="true" OnCheckedChanged="cbx_activo_CheckedChanged"/></ItemTemplate></asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                        </div>
                   
                </asp:View>
               <asp:View runat="server" ID="v_tres">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresa" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_atras_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_inicio" Text="Volver al inicio" CssClass="boton_texto_dentro" OnClick="lb_inicio_Click"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_subir" Text="Subir datos" CssClass="boton_texto_dentro"/>
                            <ajax:ConfirmButtonExtender ID="cbe_subir" runat="server" ConfirmText="¿Desea importar la vista previa a la base de datos?" TargetControlID="lb_subir"></ajax:ConfirmButtonExtender>
                        </td>
                        </tr></table></div>
                   <table style="margin:auto; text-align: center;"><tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Dictaminación de aspirantes</td></tr></table>

                    <div>
                        <div class="titulocelda" style="text-align:center;padding-top:20px;">Selecciona el archivo de resultados del EXANI.<br />Para visualizar su contenido pulsa en &quot;Vista Previa&quot;. Para importar los resultados pulsa &quot;Subir datos&quot; en la barra superior.</div>
                        <div style="text-align:center; margin: auto;"><table style="margin: auto;"><tr><td>Columna para el FOLIO</td><td><asp:DropDownList runat="server" ID="ddl_folio" /></td>
                                        <td>Columna para la calificacion ICNE</td><td><asp:DropDownList runat="server" ID="ddl_calificacion" /></td>
                                    </tr></table></div>
                        <div style="margin: auto;">
                            <table class="centrado" style="margin: auto; padding: 10px;"><tr><td>
                            <asp:FileUpload runat="server" ID="fu_ceneval"/></td><td>
                                <asp:Button ID="cmd_importar" runat="server" Text="Vista Previa"/>
                            </td></tr></table>
                            <asp:Timer ID="t_import" runat="server" Interval="2000" Enabled="false"></asp:Timer>
                        </div>
                        <div style="text-align:center;padding-top:20px;">
                             <asp:GridView runat="server" ID="gv_ceneval" GridLines="None" AutoGenerateColumns="true" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                            style="border:solid 1px #ccc;" CellPadding="10" CellSpacing="0" EmptyDataText=":( No hay datos para mostrar..." HeaderStyle-CssClass="gvheader" Width="1500px">
                            <AlternatingRowStyle CssClass="gvrow_alt" />
                            <%--<Columns>
                                <asp:BoundField DataField="FOLIO" HeaderText="Folio" SortExpression="Folio" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="ICNE" HeaderText="Puntos" SortExpression="puntos" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="promedio" HeaderText="Calificacion" SortExpression="c_examen" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="ciclo" HeaderText="ciclo" SortExpression="ciclo" ItemStyle-HorizontalAlign="Center"/>
                            </Columns>--%>
                        </asp:GridView>
                        </div>
                    </div>
               </asp:View>
        <asp:View runat="server" ID="v_cuatro">
                     <div class="topbar">
                         <table>
                             <tr>
                                 <td>
                                     <asp:ImageButton ID="ib_regresar_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar__Click" /></td>
                                 <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>                                  
                                    <td style="font-size: 1.5em;">
                                        <asp:LinkButton ID="lb_regresar_" runat="server" CssClass="boton_texto_dentro" Text="Volver al inicio" OnClick="lb_regresar__Click" />
                                    </td>
                                    </tr>
                         </table>
                     </div>           

                                   
                                <div style="text-align: center" class="centrado">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">Las calificaciones se han registrado  correctamente en el sistema!</div>
                                </div>
               
                 </asp:View>
                <asp:view ID="v_cinco" runat="server">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_atras__Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_inicio_" Text="Regresar al inicio" CssClass="boton_texto_dentro" OnClick="lb_inicio__Click"/></td>
                        </tr></table></div>
                   
                <table class="centrado"><tr><td class="titulocategoria" style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">Dictamen Manual de Aspirantes</td></tr><tr><td>
                    <table class="centrado"><tr><td style="padding: 0 10px 0 0">Aspirante</td><td>
                    <asp:TextBox ID="tbx_busqueda" runat="server" CssClass="tbxreg" MaxLength="100" Width="400px"></asp:TextBox></td>
                    <td><asp:Button ID="cmd_buscar" runat="server" Text="Buscar aspirante(s)" CssClass="botones" style="font-size: 100%;" CausesValidation="True"/></td></tr></table></td></tr>
                    <tr><td style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">
                        <asp:GridView ID="gv_resultados" runat="server" AutoGenerateColumns="false" EmptyDataText="No se han encontrado coincidencias :(" GridLines="None" ShowHeader="False" HorizontalAlign="center">
                            <Columns>
                                <asp:TemplateField><ItemTemplate><div id="gv_result" style="text-align:left;"><table><tr><td><asp:LinkButton ID="lb_gvresultado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "USTRING")%>' CssClass="boton_texto_resultados" OnClick="lb_gvresultado_Click"></asp:LinkButton></td><td style="padding: 7px 0px 0px 5px;"></td></tr></table></div></ItemTemplate></asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        </td></tr>
                </table>
               
            </asp:view>
               <asp:View runat="server" ID="v_seis">
                   <div>
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_ini" Text="Regresar al inicio" CssClass="boton_texto_dentro" OnClick="lb_inicio__Click"/></td>
                        </tr></table></div>
                       <div>
                         
                           <asp:GridView runat="server" ID="gv_dmanual" GridLines="None" AutoGenerateColumns="false" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                               style="border:solid 1px #CCC" CellPadding="10" CellSpacing="0" EmptyDataText=":( No hay datos para mostrar" HeaderStyle-CssClass="gvheader"
                                AlternatingRowStyle-CssClass="gvrow_alt">
                               <Columns>
                                    <asp:TemplateField><ItemTemplate><asp:HiddenField ID="hf_ustring" runat="server" Value='<%# Eval("USTRING")%>' /></ItemTemplate></asp:TemplateField>
                                   <asp:BoundField DataField="NOMBRES" HeaderText="Nombre(s)" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="PATERNO" HeaderText="Apellido Paterno" SortExpression="PATERNO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="MATERNO" HeaderText="Apellido Materno" SortExpression="MATERNO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="CARRERA" HeaderText="Carrera" SortExpression="CARRERA" ItemStyle-HorizontalAlign="Center" />                                  
                                   <asp:BoundField DataField="TURNO" HeaderText="Turno" SortExpression="TURNO" ItemStyle-HorizontalAlign="Center" />                                   
                                   <asp:TemplateField HeaderText="Dictaminado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                       <ItemTemplate><asp:CheckBox runat="server" ID="cbx_manual" Checked='<%# Bind("DICTAMINADO")%>' AutoPostBack="true" OnCheckedChanged="cbx_manual_CheckedChanged"/>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                       </div>
                       
                   </div>
               </asp:View>
               
               <asp:View runat="server" ID="v_siete">
                   <div>
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_backbutton" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_dictaminar" Text="Dictaminar Seleccionados" CssClass="boton_texto_dentro"/></td>
                        </tr></table></div>
                       <div>
                           <table><tr><td colspan="5"></td></tr>
                                  <tr><td>Turno</td><td><asp:DropDownList ID="ddl_turno" runat="server"></asp:DropDownList></td>
                                      <td>Puntaje Minimo</td><td><asp:Textbox ID="tbx_inicio" runat="server"></asp:Textbox></td>
                                      <td><asp:Button ID="cmd_filtro" runat="server" Text="Aplicar Filtro" /></td>
                                  </tr><tr>
                                      <td>Cantidad de grupos</td><td><asp:DropDownList ID="ddl_grupos" runat="server"></asp:DropDownList></td>
                                      <td>Numero de alumnos por grupo</td><td><asp:DropDownList ID="ddl_alumnos" runat="server"></asp:DropDownList></td>
                                      <td><asp:Button ID="cmd_dictaminar" runat="server" Text="Dictaminar la lista" /></td>
                                  </tr></table>
                       </div>
                       <div>
                           <asp:GridView runat="server" ID="gv_alumnos" GridLines="None" AutoGenerateColumns="false" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                               style="border:solid 1px #CCC" CellPadding="10" CellSpacing="0" EmptyDataText=":( No hay datos para mostrar" HeaderStyle-CssClass="gvheader"
                                AlternatingRowStyle-CssClass="gvrow_alt">
                               <Columns>
                                    <asp:TemplateField><ItemTemplate><asp:HiddenField ID="hf_ustring" runat="server" Value='<%# Eval("USTRING")%>' /></ItemTemplate></asp:TemplateField>
                                   <asp:BoundField DataField="NOMBRES" HeaderText="Nombre(s)" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="PATERNO" HeaderText="Apellido Paterno" SortExpression="PATERNO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="MATERNO" HeaderText="Apellido Materno" SortExpression="MATERNO" ItemStyle-HorizontalAlign="Center" />
                                   <asp:BoundField DataField="CARRERA" HeaderText="Carrera" SortExpression="CARRERA" ItemStyle-HorizontalAlign="Center" />                                  
                                   <asp:BoundField DataField="TURNO" HeaderText="Turno" SortExpression="TURNO" ItemStyle-HorizontalAlign="Center" />                                   
                                   <asp:TemplateField HeaderText="Dictaminado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                       <ItemTemplate><asp:CheckBox runat="server" ID="cbx_select"/>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                       </div>
                       
                   </div>
               </asp:View>               
           </asp:MultiView>
    
       <%'</ContentTemplate></asp:UpdatePanel> %>
        </div>
</asp:Content>

