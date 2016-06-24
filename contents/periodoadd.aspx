<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="periodoadd.aspx.vb" Inherits="contents_periodoadd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel ID="up_periodoadd" runat="server">
        <ContentTemplate>

        
    <asp:MultiView ID="mv_periodoadd" runat="server">
        <asp:View ID="v_ciclos" runat="server">
            
            <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_recarga" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nuevo" Text="Nuevo Ciclo" CssClass="boton_texto_dentro"/></td>
            </tr></table></div>

            <div>
        <table class="tablacien">
            <tr>
                <td>
                    <table class="centrado" style="text-align:center">
                        <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Mantenimiento de Periodos Escolares</td></tr>
                        <tr><td class="celdascien"style="width:50%; font-size: 1em ">
                            <asp:GridView ID="gv_periodos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Ciclo">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lb_ciclo" runat="server" Text='<%# Bind("ciclo")%>' CssClass="texto_boton_gv" OnClick="lb_ciclo_Click" CommandArgument='<%# Bind("ciclo")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="CICLO" HeaderText="Ciclo" ReadOnly="True" SortExpression="CICLO" Visible="False" />--%>
                                   <%-- <asp:BoundField DataField="FECHAS" HeaderText="Periodo" ReadOnly="True" SortExpression="FECHAS" />--%>
                                    <asp:BoundField DataField="INICIO" HeaderText="Inicio del ciclo" ReadOnly="True" SortExpression="INICIO" />
                                    <asp:BoundField DataField="FIN" HeaderText="Fin del ciclo" ReadOnly="True" SortExpression="FIN" />
                                    <asp:CheckBoxField DataField="ACTIVO" HeaderText="Activo" SortExpression="ACTIVO" />
                                </Columns>
                                <HeaderStyle CssClass="gvheader" />
                                <RowStyle CssClass="gvrow" />
                            </asp:GridView>
                            
                        </td></tr>
                        <tr><td class="celdascien"style="width:50%">
                             
                             <ajax:ModalPopupExtender ID="mod_periodos" runat="server" PopupControlID="p_periodo" CancelControlID="ib_close" BackgroundCssClass="modalBackground_gris" 
                                 TargetControlID="lb_nuevo"></ajax:ModalPopupExtender>
                           </td></tr>

                    </table>
                    
                        </td></tr>
             </table>
        
       
    </div>
              <asp:Panel ID="p_periodo" runat="server" style="display: none;">

             <table style="width: 100%;"><tr><td style="text-align: right; padding: 7px;"><asp:ImageButton ID="ib_close" runat="server" ImageUrl="~/img/close_coe.png" /></td></tr><tr><td>
                 <table style="background:#FFF; width:100%; border-radius: 5px;">
                     <tr><td colspan="2" class="titulocategoria" style="text-align: center; white-space: nowrap; padding: 10px 15px 5px 15px;">Agregar un nuevo ciclo</td></tr>
                     <tr><td colspan="2" style="text-align: center; padding: 0px 10px 10px 10px;">Para agregar un nuevo ciclo llene los campos requeridos y haga clic en guardar</td></tr>
                     <tr>
                     
                     <td style="text-align: center;" class="titulocategoria">Ciclo</td><td style="padding: 3px 10px 0px 3px;"><asp:TextBox ID="txtCiclo" runat="server" CssClass="tbxreg"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="rfv_ciclo" runat="server" ErrorMessage="El identificador del ciclo es indispensable (ej. 2013B)"
                    Display="None" ControlToValidate="txtCiclo" SetFocusOnError="True" ValidationGroup="nciclo" ></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="vcoe_ciclo" runat="server" TargetControlID="rfv_ciclo" CloseImageUrl="../img/close_coe.png" 
                    CssClass="customCalloutStyle" WarningIconImageUrl="id../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></td></tr>
                 <tr>
                     <td style="text-align: center;" class="titulocategoria">Inicio</td><td style="padding: 3px 10px 0px 3px;"><asp:TextBox ID="txtInicio" runat="server" CssClass="tbxreg"></asp:TextBox>
                                     <ajax:CalendarExtender ID="cal_inicio" runat="server" TargetControlID="txtInicio" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                     <asp:RequiredFieldValidator ID="rfv_inicio" runat="server" ErrorMessage="Debe elejir la fecha de inicio del ciclo. El formato es AAAA/MM/DD (ej. 2013/09/25)" 
                    Display="None" ControlToValidate="txtInicio" SetFocusOnError="True" ValidationGroup="nciclo" ></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="vcoe_inicio" runat="server" TargetControlID="rfv_inicio" CloseImageUrl="../img/close_coe.png" 
                    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></td>
                 </tr>
                 <tr>
                     <td style="text-align: center;" class="titulocategoria">Fin</td><td style="padding: 3px 10px 0px 3px;"><asp:TextBox ID="txtFin" runat="server" CssClass="tbxreg"></asp:TextBox>
                                     <ajax:CalendarExtender ID="cal_fin" runat="server" TargetControlID="txtFin" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                     <asp:RequiredFieldValidator ID="rfv_fin" runat="server" ErrorMessage="Es importante la fecha de termino del ciclo. El formato es AAAA/MM/DD (ej. 2013/09/25)" 
                    Display="None" ControlToValidate="txtFin" SetFocusOnError="True" ValidationGroup="nciclo" ></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="vcoe_fin" runat="server" TargetControlID="rfv_fin" CloseImageUrl="../img/close_coe.png" 
                    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></td>
                 </tr>
                 <tr>
                     <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;"><asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="botones" Font-Size="Large" ValidationGroup="nciclo" /></td></tr>

                 </table></td>
                 </tr>
                </table>
            </asp:Panel>

     
        </asp:View>
        <asp:View runat="server" ID="v_detalleCiclo">
            <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar cambios" CssClass="boton_texto_dentro" ValidationGroup="vg_detalle"/>
                <ajax:ConfirmButtonExtender ID="cbe_guardar" runat="server" ConfirmText="Si ya se asignaron los días para enrevista deberá volver a realizar la tarea. ¿Desea continuar?" TargetControlID="lb_guardar"></ajax:ConfirmButtonExtender>
            </td>
            <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_oacademica" Text="Ver o modificar oferta" CssClass="boton_texto_dentro"/></td>
                                   </tr></table></div>
            <table class="tablacien" style="margin: auto;">
                <tr><td class="titulo_medio"style="padding: 5px 5px 15px 5px;">Información del ciclo escolar <asp:Label ID="lbl_ciclo" runat="server"></asp:Label></td></tr>
                    <tr>
                        <td style="padding: 5px 5px 5px 5px; text-align:center;">*Al actualizar la información de fechas de un ciclo, se modifican también las fechas que se asignaron para las citas para toma de foto.<br /> Si éstas ya se asignaron, será necesario volver a realizar la tarea.</td>
                </tr>
                    <tr><td style="text-align: center;">
                    <table style="margin: auto; padding: 5px; background: rgba(0,0,0,0.1); border-radius: 5px;">
                       <tr><td class="celdascien">
                         <div class="tablacien">
                <asp:DetailsView ID="dv_ciclos" runat="server" AutoGenerateRows="False" GridLines="None" HorizontalAlign="Center">
                    <Fields>
                        <asp:TemplateField HeaderText="Inicio del ciclo" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                 <div style="padding: 5px 10px 5px 10px; text-align:center;"><asp:TextBox ID="tbx_inicio" runat="server" Text='<%# Bind("startdate")%>' CssClass="tbxreg"></asp:TextBox>
                                <ajax:CalendarExtender ID="ce_inicio" runat="server" TargetControlID="tbx_inicio" Format="yyyy/MM/dd"></ajax:CalendarExtender></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fin del ciclo" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                 <div style="padding: 5px 10px 5px 10px; text-align:center;"><asp:TextBox ID="tbx_fin" runat="server" Text='<%# Bind("enddate")%>' CssClass="tbxreg"></asp:TextBox>
                                <ajax:CalendarExtender ID="ce_fin" runat="server" TargetControlID="tbx_fin" Format="yyyy/MM/dd"></ajax:CalendarExtender></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Terminan las entrevistas de PI" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <div style="padding: 5px 10px 5px 10px; text-align:center;"><asp:TextBox ID="tbx_entrevista" runat="server" Text='<%# Bind("entrevistas_fin")%>' CssClass="tbxreg"></asp:TextBox>
                                <ajax:CalendarExtender ID="ce_entrevista" runat="server" TargetControlID="tbx_entrevista" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv_entrevista" runat="server" ErrorMessage="Es importante la fecha de entrevista. El formato es AAAA/MM/DD (ej. 2013/09/25)" 
                                 Display="None" ControlToValidate="tbx_entrevista" SetFocusOnError="True" ValidationGroup="vg_detalle" ></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcoe_entrevista" runat="server" TargetControlID="rfv_entrevista" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha del CENEVAL" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <div style="padding: 5px 10px 5px 10px; text-align:center;"><asp:TextBox ID="tbx_examen" runat="server" Text='<%# Bind("fecha_examen") %>' CssClass="tbxreg"></asp:TextBox>
                                <ajax:CalendarExtender ID="ce_examen" runat="server" TargetControlID="tbx_examen" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv_examen" runat="server" ErrorMessage="Es importante la fecha de examen. El formato es AAAA/MM/DD (ej. 2013/09/25)" 
                                 Display="None" ControlToValidate="tbx_examen" SetFocusOnError="True" ValidationGroup="vg_detalle" ></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcoe_examen" runat="server" TargetControlID="rfv_examen" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de inicio de entrega de documentos" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <div style="padding: 5px 10px 5px 10px; text-align:center;"><asp:TextBox runat="server" ID="tbx_docinicio" CssClass="tbxreg" Text='<%# Bind("documentos_inicio")%>'></asp:TextBox>
                                <ajax:CalendarExtender ID="ce_docinicio" runat="server" TargetControlID="tbx_docinicio" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv_docinicio" runat="server" ErrorMessage="Es importante la fecha de inicio de entrega de documentos. El formato es AAAA/MM/DD (ej. 2013/09/25)" 
                                 Display="None" ControlToValidate="tbx_docinicio" SetFocusOnError="True" ValidationGroup="vg_detalle" ></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcoe_docinicio" runat="server" TargetControlID="rfv_docinicio" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de fin de entrega de documentos" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <div style="padding: 5px 10px 5px 10px; text-align:center;"><asp:TextBox runat="server" ID="tbx_docfin" CssClass="tbxreg" Text='<%# Bind("documentos_fin")%>'></asp:TextBox>
                                <ajax:CalendarExtender ID="ce_docfin" runat="server" TargetControlID="tbx_docfin" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv_docfin" runat="server" ErrorMessage="Es importante la fecha final de entrega de documentos. El formato es AAAA/MM/DD (ej. 2013/09/25)" 
                                 Display="None" ControlToValidate="tbx_docfin" SetFocusOnError="True" ValidationGroup="vg_detalle" ></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcoe_docfin" runat="server" TargetControlID="rfv_docfin" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Alumnos que entregarán docs por dia" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <div style="padding: 5px 10px 5px 10px; text-align:center;"><asp:TextBox runat="server" ID="tbx_docsxdia" CssClass="tbxreg" Text='<%# Bind("docsxdia")%>'></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="rfv_docsxdia" runat="server" ErrorMessage="Es importante especificar cuantos alumnos se recibirán al día" 
                                 Display="None" ControlToValidate="tbx_docsxdia" SetFocusOnError="True" ValidationGroup="vg_detalle" ></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcoe_docsxdia" runat="server" TargetControlID="rfv_docsxdia" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Establecer como activo" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                 <div style="padding: 5px 10px 5px 10px; text-align:left;"><asp:CheckBox ID="cbx_activo" runat="server" Checked='<%# Bind("active")%>'/></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView></div>
                        </td></tr></table>
                    
                    </td></tr>
            </table>

        </asp:View>

     <asp:View runat="server" ID="v_oferta">
         <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;">&nbsp;</td>
                                   </tr></table></div>
         <asp:Label ID="lbl_c" runat="server" Visible="false"></asp:Label>
         <table class="tablacien">
             <tr><td class="titulo_medio"style="padding: 5px 5px 15px 5px;">Mantenimiento de la oferta académica para PI del ciclo <asp:Label ID="lbl_ciclo2" runat="server"></asp:Label></td></tr>
             <tr><td style="text-align:center; font-size: 1.1em;">Con los botones de dirección, mueva del catalogo de carreras a las carreras activas en el ciclo.</td></tr>
                 <tr><td>
                 <table style="width: 100%; text-align:center">
                     <tr><td class="titulo_medio" style="font-size: 1.5em;">Carreras activas en el ciclo</td><td></td><td class="titulo_medio" style="font-size: 1.5em;">Catalogo de Carreras</td></tr>
                      <tr><td style="vertical-align:top;">
                          <asp:GridView ID="gv_activo" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" RowStyle-VerticalAlign="Middle" style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" HorizontalAlign="Center" >
                        <Columns>
                            <asp:BoundField DataField="nivel" HeaderText="NIVEL" ReadOnly="true" SortExpression="nivel"/>
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ReadOnly="true" SortExpression="nombre"/>
                             <asp:BoundField DataField="turno" HeaderText="TURNO" ReadOnly="true" SortExpression="turno"/> 
                               <asp:TemplateField>
                                   <ItemTemplate>
                                       <div style="padding: 0px 10px 0px 10px">
                                           <asp:imageButton ID="btn_elimina" runat="server" ImageUrl="~/img/minimenua.png" OnClick="btn_elimina_Click" CommandArgument='<%# Bind("id")%>' />
                                       </div>
                                   </ItemTemplate>
                               </asp:TemplateField>
                        </Columns>
                              <EmptyDataTemplate>Agrega un elemento de las carreras disponibles</EmptyDataTemplate>
                              <RowStyle CssClass="gvrow" />
                              <HeaderStyle CssClass="gvheader" />
                    </asp:GridView>
                        </td><td style="width:30px"></td><td style="vertical-align:top">
                            <asp:GridView ID="gv_noActivo" runat="server" AutoGenerateColumns="False" 
                                OnRowCommand="gv_noActivo_RowCommand" GridLines="None" RowStyle-CssClass="gvrow" style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" HorizontalAlign="Center">
                        <Columns>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnRegistrar"  Text="REGISTRAR" CssClass="botones"/>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                             
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/minimenual.png" SelectText="REGISTRAR" ShowSelectButton="True">
                            <ControlStyle />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:CommandField>
                            <asp:BoundField DataField="nivel" HeaderText="NIVEL" ReadOnly="true" SortExpression="nivel" />
                             
                             
                            <asp:BoundField DataField="cv_carrera" HeaderText="CLAVE" ReadOnly="true" SortExpression="nivel" />
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ReadOnly="true" SortExpression="nombre" />
                            <asp:BoundField DataField="turno" HeaderText="TURNO" ReadOnly="true" SortExpression="turno" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="idturno" runat="server" Value='<%# Bind("id_turno")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                        </Columns>
                                <EmptyDataTemplate>Todas las carreras disponibles han sido ofertadas.</EmptyDataTemplate>
                                <RowStyle CssClass="gvrow" />
                                <HeaderStyle CssClass="gvheader" />
                    </asp:GridView>
                             </td></tr>
                     
                     
                 </table>
                 </td></tr>
            
         </table>
     </asp:View>
        
        <asp:View runat="server" ID="v_exito">
                     <div class="topbar">
                         <table>
                             <tr>
                                 <td>
                                     <asp:ImageButton ID="ib_regresar_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar__Click" /></td>
                                 <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>                                  
                                    <td style="font-size: 1.5em;">
                                        <asp:LinkButton ID="lb_regresar_" runat="server" CssClass="boton_texto_dentro" Text="Ver o modificar oferta" OnClick="lb_oacademica_Click" />
                                    </td>
                                    </tr>
                         </table>
                     </div>           

                                   
                                <div style="text-align: center" class="centrado">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">El periodo escolar se ha modificado correctamente en el sistema!
                                        
                                </div>
               
                 </asp:View>
    </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

