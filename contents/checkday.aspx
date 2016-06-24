<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="checkday.aspx.vb" Inherits="contents_checkday" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
   
       <asp:UpdatePanel runat="server" ID="up_checkday">
           <ContentTemplate>
               <asp:MultiView runat="server" ID="mv_checkday">
                   <asp:View runat="server" ID="v_cero">
                        <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresa" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresa_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nuevo" Text="Activar dias" CssClass="boton_texto_dentro" ValidationGroup="vg_day" OnClick="lb_nuevo_Click" /></td>
                            <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_lista" Text="Ver dias Activos" CssClass="boton_texto_dentro" OnClick="lb_lista_Click"/></td>  
            </tr></table></div>
                       <asp:Label runat="server" ID="lbl_ciclo" Text="" Visible="false"></asp:Label>
                         <div>
                                <div style="text-align:center;padding-top:20px;" class="titulocategoria">Activación de fechas para entrevista</div>
                                <div style="text-align:center;padding:10px 0 0 350px">
                                    <table style="width:70%;text-align:center">
                                        <tr><td class="titulocelda">FECHA INICIO</td><td class="titulocelda">FECHA FIN</td></tr>
                                        <tr>
                                            <td class="titulocelda">
                                                <asp:TextBox runat="server" ID="txtInicio" CssClass="tbxreg" >
                                                </asp:TextBox>
                                                 <ajax:CalendarExtender ID="cal_inicio" runat="server" TargetControlID="txtInicio" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                     <asp:RequiredFieldValidator ID="rfv_inicio" runat="server" ErrorMessage="Debe elejir la fecha de inicio. " 
                                        Display="None" ControlToValidate="txtInicio" SetFocusOnError="True" ValidationGroup="vg_day" ></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_inicio" runat="server" TargetControlID="rfv_inicio" CloseImageUrl="../img/close_coe.png" 
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                                </td>
                                            <td class="titulocelda">
                                                <asp:TextBox runat="server" ID="txtFin" CssClass="tbxreg"></asp:TextBox>
                                                <ajax:CalendarExtender ID="cal_fin" runat="server" TargetControlID="txtFin" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                     <asp:RequiredFieldValidator ID="rfv_fin" runat="server" ErrorMessage="Es importante la fecha de termino ." 
                                        Display="None" ControlToValidate="txtFin" SetFocusOnError="True" ValidationGroup="vg_day" ></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_fin" runat="server" TargetControlID="rfv_fin" CloseImageUrl="../img/close_coe.png" 
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                                </td>

                                        </tr>
                                    </table>

                                </div>
                             
                             
                            </div>

                   </asp:View>
                   <asp:View runat="server" ID="v_uno">
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guarda" Text="Ver dias Activos" CssClass="boton_texto_dentro" OnClick="lb_lista_Click"  /></td>
                         </tr></table></div>
                      <table class="centrado"><tr><td>
                          Edicion de días seleccionados</td></tr><tr><td>
                       <div style="padding-top:20px">
                             <asp:GridView runat="server" ID="gv_listado" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border:solid 1px #ccc" CellSpacing="0" CellPadding="10">
                                 
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                  
                                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" SortExpression="FECHA" Visible="false" />
                                     <asp:BoundField DataField="FECHACORTA" HeaderText="FECHA" SortExpression="FECHACORTA" />
                                    <asp:BoundField DataField="MES" HeaderText="MES" SortExpression="MES" />
                                   <%-- <asp:BoundField DataField="NUMMES" HeaderText="NUM MES" SortExpression="NUMMES" />--%>
                                    
                                    <%--<asp:BoundField DataField="DIA" HeaderText="DIA" SortExpression="DIA" />--%>
                                      
                                    <asp:BoundField DataField="NOMBREDIA" HeaderText="DIA DE SEMANA" SortExpression="NOMBREDIA" />
                                     <asp:TemplateField HeaderText="ACTIVO">
                                   <ItemTemplate>
                                       <asp:HiddenField ID="hf_mes" runat="server" Value='<%# Eval("NUMMES")%>' />
                                       <asp:HiddenField ID="hf_dia" runat="server" Value='<%# Eval("DIA")%>' />
                                    <asp:CheckBox runat="server" ID="cbx_activo" Checked='<%# Bind("ACTIVO")%>' AutoPostBack="true" OnCheckedChanged="cbx_activo_CheckedChanged"/>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                   <%-- <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/close_coer.png" SelectText="DESHABILITAR" ShowSelectButton="True">
                                    <ControlStyle />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:CommandField>--%>
                                      <%--<asp:CheckBoxField DataField="ACTIVO" HeaderText="ACTIVO" SortExpression="ACTIVO" />--%>
                                 
                                </Columns>
                                  <EmptyDataTemplate>No hay ningun día activo.</EmptyDataTemplate>
                                <RowStyle CssClass="gvrow" />
                                <HeaderStyle CssClass="gvheader" />
                            </asp:GridView>
                                 </div></td></tr></table>
                   </asp:View>
                   <asp:View runat="server" ID="v_dos">
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Activación de días para citas de aspirantes</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un ciclo para mostrar elegir fechas.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_ciclos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Ciclo">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lb_ciclo" runat="server" Text='<%# Bind("CICLO")%>' CssClass="texto_boton_gv" OnClick="lb_ciclo_Click" CommandArgument='<%# Bind("CICLO")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                   <asp:View runat="server" ID="v_tres">
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_agregar" Text="Agregar dias" CssClass="boton_texto_dentro" OnClick="lb_agregar_Click" /></td>
                        </tr></table></div>
                      <table class="centrado"><tr><td style="text-align:center;padding-top:20px;" class="titulocategoria">Días activos para el ciclo <asp:Label ID="lbl_ciclo1" runat="server"></asp:Label></td></tr><tr><td>
                       <div style="padding-top:20px">
                             <asp:GridView runat="server" ID="gv_lista" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border:solid 1px #ccc" CellSpacing="0" CellPadding="10">
                                 
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                  
                                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" SortExpression="FECHA" Visible="false" />
                                     <asp:BoundField DataField="FECHACORTA" HeaderText="FECHA" SortExpression="FECHACORTA" />
                                    <asp:BoundField DataField="MES" HeaderText="MES" SortExpression="MES" />
                                   <%-- <asp:BoundField DataField="NUMMES" HeaderText="NUM MES" SortExpression="NUMMES" />--%>
                                    
                                    <%--<asp:BoundField DataField="DIA" HeaderText="DIA" SortExpression="DIA" />--%>
                                      
                                    <asp:BoundField DataField="NOMBREDIA" HeaderText="DIA DE SEMANA" SortExpression="NOMBREDIA" />
                                      <asp:TemplateField HeaderText="ACTIVO">
                                   <ItemTemplate>
                                       <asp:HiddenField ID="hf_mes" runat="server" Value='<%# Eval("NUMMES")%>' />
                                       <asp:HiddenField ID="hf_dia" runat="server" Value='<%# Eval("DIA")%>' />
                                    <asp:CheckBox runat="server" ID="cbx_activar" Checked='<%# Bind("ACTIVO")%>' AutoPostBack="true" OnCheckedChanged="cbx_activar_CheckedChanged"/>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                   <%-- <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/close_coer.png" SelectText="DESHABILITAR" ShowSelectButton="True">
                                    <ControlStyle />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:CommandField>--%>
                                      <%--<asp:CheckBoxField DataField="ACTIVO" HeaderText="ACTIVO" SortExpression="ACTIVO" />--%>
                                 
                                </Columns>
                                  <EmptyDataTemplate>De momento no hay días activos.</EmptyDataTemplate>
                                <RowStyle CssClass="gvrow" />
                                <HeaderStyle CssClass="gvheader" />
                            </asp:GridView>
                                 </div></td></tr></table>
                   </asp:View> 
               </asp:MultiView>

           </ContentTemplate>
       </asp:UpdatePanel>
   
</asp:Content>

