<%@ Page Title="Listas de Asistencia - SIAAA 2016" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="asistlistas.aspx.vb" Inherits="asistlistas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_lista">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_lista">
                <asp:View runat="server" ID="v_cero">
                    <div>
    
          
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Impresion de listas de asistencia y captura de evaluación</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click sobre el icu correspondiente al curso que desea evaluar.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_listas" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                        style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay materias en el ciclo actual...">
                                        <AlternatingRowStyle CssClass="gvrow_alt" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ICU"><ItemTemplate><div><asp:LinkButton ID="lb_icu" runat="server" Text='<%# Bind("icu")%>' 
                                                CssClass="texto_boton_gv" OnClick="lb_icu_Click" CommandArgument='<%# Bind("icu")%>'></asp:LinkButton></div></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField DataField="cve_materia" HeaderText="Clave" ReadOnly="True"/>
                                            <asp:BoundField DataField="materia" HeaderText="Curso" ReadOnly="True"/>
                                        </Columns>
                                        <HeaderStyle CssClass="gvheader" />
                                        <RowStyle CssClass="gvrow" />
                                      </asp:GridView>
                                      </td></tr>
                                </table>
                                </td></tr>
                        </table>
                    </div>

                 </div>
                </asp:View>
                <asp:View runat="server" ID="v_uno">
                    
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                         <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_reportefinal" Text="Reporte final de asistencias" CssClass="boton_texto_dentro"/></td>
                        </tr></table></div>
                   
                    <div>
                        <div style="text-align:center; padding-top:20px" class="titulocategoria"> Captura de evaluación y asistencias del curso<br />
                            <asp:Label ID="lbl_materia" runat="server"></asp:Label>(<asp:Label runat="server" ID="lbl_icu"></asp:Label>) </div>
                        <div style="padding-bottom:20px;padding-top:10px">
                            <table class="centrado" style="width:60%">
                               <tr>
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Profesor:</strong></td>
                                   <td style="white-space: nowrap; width: 41%;"><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_profesor" Enabled="False"></asp:TextBox></td>
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Carrera:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_curso" Enabled="False"></asp:TextBox></td>
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Nivel:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_nivel" Enabled="False"></asp:TextBox></td>    
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Ciclo:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_ciclo" Enabled="False"></asp:TextBox></td>   
                               </tr>
                                </table>
                          
                            
                           <table class="centrado" style="width:60%">
                               <tr>

                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Clave:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_clave" Enabled="False"></asp:TextBox></td>   
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Turno:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_turno" Enabled="False"></asp:TextBox></td> 
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Hora inicio:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_h_inicio" Enabled="False"></asp:TextBox></td> 
                                  <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Fecha inicio:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_f_inicio" Enabled="False"></asp:TextBox></td> 
                               </tr>
                                <tr>

                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Días:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_dias" Enabled="False"></asp:TextBox></td>
                                       
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Edificio y Aula:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_aula" Enabled="False"></asp:TextBox></td>
                                     <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Hora fin:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_h_fin" Enabled="False"></asp:TextBox></td>          
                                   
                                   <td style="white-space: nowrap; width: 10%;text-align:right"><strong>Fecha fin:</strong></td>
                                   <td><asp:TextBox CssClass="tbxreg" runat="server" ID="lbl_f_fin" Enabled="False"></asp:TextBox></td>         
                               </tr>
                           </table>
                           
                        </div>
                      
                        <div style="padding-top:5px;text-align:center">Selecciona el periodo que deseas evaluar<br />
                            <asp:DropDownList runat="server" ID="ddl_periodo" CssClass="ddlreg" AutoPostBack="true">
                                <asp:ListItem Value="0" Text="Selecciona..."></asp:ListItem>
                                <asp:ListItem Value="1" Text="Periodo 1"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Periodo 2"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Periodo 3"></asp:ListItem>
                            </asp:DropDownList>
                           
                            
                        </div>
                        
                        <asp:HiddenField ID="hf_popupok" runat="server" />
                        <ajax:ModalPopupExtender ID="hf_popupok_mpe" runat="server" PopupControlID="p_advertencia" CancelControlID="ib_close" BackgroundCssClass="modalBackground_gris" 
                                 TargetControlID="hf_popupok"></ajax:ModalPopupExtender>
                            <asp:Panel ID="p_advertencia" runat="server" style="display:table; width:100%; padding-left:60%;" >
                                    <table style="width: 40%;"><tr><td style="text-align: right; padding: 7px;"><asp:ImageButton ID="ib_close" runat="server" ImageUrl="~/img/close_coe.png" /></td></tr><tr><td>
                                         <table style="background:#FFF; width:100%; border-radius: 5px;">
  
                                             <tr>
                                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;">
                                                    <asp:Image ID="img_advertencia" runat="server" ImageUrl="~/img/alert.png" ImageAlign="AbsMiddle" />
                                                </td>
                                            </tr>
                                               <tr>
                                                <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;">
                                                    <div style="text-align:center">
                                               Total de asistencias en el  <asp:Label runat="server" ID="lbl_periodo"></asp:Label>
                                               <br /> <br />
                                              <asp:DropDownList runat="server" ID="ddl_cantidad" CssClass="ddlreg_short">
                                                    <asp:ListItem Text="Ninguna" Value="0"></asp:ListItem>
                                                   
                                                     <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                     <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                     <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                     <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                     <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                     <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                     <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                     <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                     <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                     <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                     <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                </asp:DropDownList>
                                           </div>
                                                    <asp:RequiredFieldValidator ID="rfv_ddl_cantidad" runat="server" ErrorMessage="¡Selecciona una cantidad!." 
                                                     Display="None" ControlToValidate="ddl_cantidad" SetFocusOnError="True" ValidationGroup="vg_cantidad" InitialValue="0"></asp:RequiredFieldValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vcoe_ddl_cantidad" runat="server" TargetControlID="rfv_ddl_cantidad" CloseImageUrl="../img/close_coe.png" 
                                                     CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                         <tr>
                                             <td colspan="2" style="text-align: center; padding: 10px 5px 10px 5px;"><pre><asp:Button ID="cmd_ok" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Continuar" OnClick="cmd_ok_Click" ValidationGroup="vg_cantidad" /></pre></td>

                                         </tr>

                                         </table></td>
                                         </tr>
                                        </table>
                               </asp:Panel>

                       

                         <asp:HiddenField ID="hf_faltas" runat="server" />
                             <ajax:ModalPopupExtender ID="moe_hf_faltas" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_faltas" PopupControlID="p_faltas" BackgroundCssClass="modalBackground_gris" CancelControlID="lb_closeok1">
                                </ajax:ModalPopupExtender>
                            <asp:Panel ID="p_faltas" runat="server" style="display:none" DefaultButton="cmd_ok1">
                            <table><tr><td>
                               <table class="popupmsg" style="width: 100%"><tr><td></td>
                               <td>
                                  
                               </td></tr>
                                   <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="lb_closeok1" runat="server"></asp:LinkButton>
                                           <div style="text-align:center">
                                               <asp:Image runat="server" ID="img_alert" ImageUrl="~/img/alert.png" /><br />
                                               El número de faltas no puede ser mayor que el número de asistencias
                                               <br />
                                               Total de asistencias en el mes= <strong> <asp:Label runat="server" ID="lbl_asis"></asp:Label></strong>
                                               <br />
                                                Faltas del alumno=<strong> <asp:Label runat="server" ID="lbl_faltas"></asp:Label></strong>
                                                <br />
                                               Favor de corregir los datos
                                           </div>
                                          
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%; text-align:center">
                                           <asp:Button ID="cmd_ok1" runat="server"  CssClass="botones" style="font-size: 100%;" Text="Continuar" OnClick="cmd_ok1_Click" />
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel>

                        <asp:HiddenField ID="hf_ya_ev" runat="server" />
                             <ajax:ModalPopupExtender ID="mpe_hf_ya_ev" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_ya_ev" PopupControlID="p_ya_ev" BackgroundCssClass="modalBackground_gris" CancelControlID="lb_closeok2">
                                </ajax:ModalPopupExtender>
                            <asp:Panel ID="p_ya_ev" runat="server" style="display:none" DefaultButton="cmd_consular">
                            <table><tr><td>
                               <table class="popupmsg" style="width: 100%"><tr><td></td>
                               <td>
                                  
                               </td></tr>
                                   <tr>
                                       <td>&nbsp;</td><td id="pad" style="padding: 10px; width: 100%;" class="tituloceldaNegrita">
                                           <asp:LinkButton ID="lb_closeok2" runat="server"></asp:LinkButton>
                                           <div style="text-align:center">
                                               <asp:Image runat="server" ID="Image1" ImageUrl="~/img/alert.png" /><br />
                                               Este periodo ya ha sido evaluado, puedes consultar su información dándo clic en el botón "Consultar"<br /><br />


                                               O si deseas calificar nuevamente este periodo presiona "Re-evaluar"<br />
                                               *Nota: si presiona el botón "Re-evaluar" los datos de este periodo <br /> regresarán a sus valores por defecto
                                           </div>
                                          
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td1" style="padding: 10px; width: 100%; text-align:center">
                                           <asp:Button ID="cmd_consular" runat="server"  CssClass="botones" style="font-size: 150%;"  Text="Consultar" OnClick="cmd_consular_Click"  />
                                            <asp:Button ID="cmd_rev" runat="server"  CssClass="botones" style="font-size: 150%;" Text="Re-evaluar" OnClick="cmd_rev_Click"  />
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel>

                    </div>
                 </asp:View>
                <asp:View ID="v_dos" runat="server">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_vuelve" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar1" Text="Calificar otro curso" CssClass="boton_texto_dentro"/></td>
                        
                        </tr></table></div>
                    <div>
                        <table class="tablacien"><tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px; text-align:center; margin:auto;">Captura de asistencia</td></tr></table>
                        <div style="text-align:center;padding-top:20px;">Se han guardado correctamente los cambios</div>
                        <div style="padding:20px; text-align:center;"><img alt="Guardado Correcto" src="../img/ok_green.png"/></div>
                    </div>
                </asp:View>
                <asp:View runat="server" id="v_tres">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back1" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_imprimir" Text="Imprmir lista de asistencia" CssClass="boton_texto_dentro" OnClick="lb_imprimir_Click"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar cambios" CssClass="boton_texto_dentro" OnClick="lb_guardar_Click" ValidationGroup="vg_ev"/></td>                      
                        </tr></table></div>

                      <div style="padding-top:10px;text-align:center" class="titulocategoria">
                          Está evaluando el  <strong><asp:Label runat="server" ID="lbl_mes"></asp:Label></strong>

                      </div>
                     <table class="centrado" style="padding-top:20px">
                            <tr>
                                <td>
                                    
                                    <asp:GridView runat="server" ID="gv_listado"  AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" EmptyDataText=":( No hay datos por mostrar.." HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:BoundField DataField="R" HeaderText="No." ReadOnly="True" SortExpression="R" />
                                    <asp:BoundField DataField="matricula" HeaderText="Matrícula" ReadOnly="True" SortExpression="matricula" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre Completo" ReadOnly="True" SortExpression="nombre" />
                                    
                                     <asp:TemplateField HeaderText="Faltas" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <div>
                                                <asp:HiddenField ID="hf_matricula" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "matricula")%>' />
                                                <asp:DropDownList runat="server" ID="ddl_faltas" CssClass="ddlreg_short" AutoPostBack="true" 
                                                 ToolTip='<%#DataBinder.Eval(Container, "RowIndex")%>' OnSelectedIndexChanged="ddl_faltas_SelectedIndexChanged">
                                                    
                                                     
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Porcentaje" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <div>
                                                <asp:UpdatePanel ID="up_percent" runat="server"><ContentTemplate>
                                                <asp:TextBox runat="server" ID="tbx_porcentaje" CssClass="tbxreg_min" Width="50px" Text=" 100" Enabled="false"></asp:TextBox>
                                                </ContentTemplate></asp:UpdatePanel>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calificación" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <div>
                                                <asp:TextBox runat="server" ID="tbx_continua" CssClass="tbxreg" Width="75px" Text="10"></asp:TextBox>
                                                 <ajax:FilteredTextBoxExtender ID="ftbe_tbx_continua" runat="server" FilterType="Numbers, Custom"
                                                         ValidChars="." TargetControlID="tbx_continua" />
                                                    <asp:RegularExpressionValidator ID="rev_tbx_continua" runat="server" Display="None" ErrorMessage="La calificación es base 10 con un decimal. Esta no parece una calificacón válida :(" 
                                                     ControlToValidate="tbx_continua" ValidationGroup="vg_ev" ValidationExpression="^10|[0-9](\.\d{1})?|10$" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vco_rev_tbx_continua" runat="server" TargetControlID="rev_tbx_continua" CloseImageUrl="../img/close_coe.png" 
                                                    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>          
                                                    <asp:RequiredFieldValidator ID="rfv_tbx_continua" runat="server" ErrorMessage="¡Este alumno no tiene calificación, por favor de asigne una!." 
                                                        Display="None" ControlToValidate="tbx_continua" SetFocusOnError="True" ValidationGroup="vg_ev"></asp:RequiredFieldValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_tbx_continua" runat="server" TargetControlID="rfv_tbx_continua" CloseImageUrl="../img/close_coe.png" 
                                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                   
                                </td>
                            </tr>
                        </table>
                </asp:View>
                <asp:View runat="server" ID="v_cuatro">
                <div class="topbar"><table><tr><td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_vuelve_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="Linkbutton1" Text="Calificar otro curso" CssClass="boton_texto_dentro" OnClick="lb_regresar1_Click"/></td>
                    <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="Linkbutton2" Text="Imprmir lista de asistencia" CssClass="boton_texto_dentro" OnClick="lb_imprimir_Click"/></td>
                        </tr></table></div>

                    <div style="padding-top:20px">
                        <div style="padding-top:20px;text-align:center;padding-bottom:20px" class="titulocategoria">Porcentaje de asistencias del <asp:Label runat="server" ID="lbl_mes_"></asp:Label></div>
                        <table class="centrado">
                            <tr>
                                <td>
                                    <asp:GridView runat="server" ID="gv_listado_completo"  AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" EmptyDataText=":( No hay datos por mostrar.." HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:BoundField DataField="R" HeaderText="No." ReadOnly="True" SortExpression="R" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="matricula" HeaderText="Matrícula" ReadOnly="True" SortExpression="matricula" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre Completo" ReadOnly="True" SortExpression="nombre" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="faltas" HeaderText="Faltas" ReadOnly="True" SortExpression="faltas"  ItemStyle-HorizontalAlign="Left"/>
                                    <asp:BoundField DataField="porcentaje" HeaderText="Porcentaje" ReadOnly="True" SortExpression="porcentaje" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                                     
                                    
                                </Columns>
                            </asp:GridView> 
                                </td>
                            </tr>
                        </table>
                    </div>

                </asp:View>
                <asp:View runat="server" ID="v_cinco">
                <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_iback" runat="server" ImageUrl="~/img/arrowback.png"  /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_imprimereporte" Text="Imprimir reporte" CssClass="boton_texto_dentro" /></td>
                        </tr></table></div>

                    <div style="padding-top:20px">
                        <div style="padding-top:20px;text-align:center;padding-bottom:20px" class="titulocategoria">
                            Reporte final de asistencias del curso<br />
                            <strong><asp:Label runat="server" ID="lbl_icu_"></asp:Label></strong>:&nbsp;&nbsp;<strong><asp:Label runat="server" ID="lbl_curso_"></asp:Label></strong> 

                        </div>
                        <table class="centrado">
                            <tr>
                                <td>
                                    <asp:GridView runat="server" ID="gv_reporte"  AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" EmptyDataText=":( No hay datos por mostrar.." HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:BoundField DataField="R" HeaderText="No." ReadOnly="True" SortExpression="R" />
                                    <asp:BoundField DataField="matricula" HeaderText="Matrícula" ReadOnly="True" SortExpression="matricula" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre Completo" ReadOnly="True" SortExpression="nombre" />
                                    <asp:BoundField DataField="faltas" HeaderText="Faltas totales" ReadOnly="True" SortExpression="faltas" ItemStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="porcentaje" HeaderText="Porcentaje %" ReadOnly="True" SortExpression="porcentaje" ItemStyle-HorizontalAlign="Center" />
                                   
                                    
                                </Columns>
                            </asp:GridView> 
                                </td>
                            </tr>
                        </table>
                    </div>

                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

