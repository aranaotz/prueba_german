<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="indcourse.aspx.vb" Inherits="contents_indcourse" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<script runat="server">

    Protected Sub cbxl_select_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_induccion">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_induccion">
                <asp:View runat="server" ID="v_ciclo">
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Captura de asistencia a Propedéutico</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un ciclo para mostrar carreras.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_ciclos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" EmptyDataText=":( No hay datos por mostrar.." HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Ciclo">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lb_ciclo" runat="server" Text='<%# Bind("CICLO")%>' CssClass="texto_boton_gv" CommandArgument='<%# Bind("CICLO")%>' OnClick="lb_ciclo_Click">

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
                <asp:View runat="server" ID="v_carreras">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_refresh" runat="server" ImageUrl="~/img/reload.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar" Text="Regresar" CssClass="boton_texto_dentro" OnClick="lb_regresar_Click" /></td>
                        </tr></table></div>
                    <div>
                        <table class="tablacien"><tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px; text-align:center; margin:auto;">Captura de asistencia a Propedéutico</td></tr></table>
                        <div style="text-align:center;padding-top:20px;">Selecciona el campo clave para ver la lista de aspirantes,</div>
                        <asp:HiddenField runat="server" ID="hf_ciclo"></asp:HiddenField>
                        <div style="padding:20px 0 0 0"></div>
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
                               
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="v_lista">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_atras_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_atras" Text="Regresar al inicio" CssClass="boton_texto_dentro" OnClick="lb_regresar_Click" /></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_captura" Text="Capturar asistencia" CssClass="boton_texto_dentro" ValidationGroup="vg_turnos"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em; margin-left: 40px;"><asp:Linkbutton runat="server" ID="lb_lista" Text="Imprimir Lista" CssClass="boton_texto_dentro" ValidationGroup="vg_turnos"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em; margin-left: 40px;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar asistencia" CssClass="boton_texto_dentro" ValidationGroup="vg_turnos"/></td>
                        </tr></table></div> 
                    <div>
                        <table class="tablacien"><tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px; text-align:center; margin:auto;">Captura de asistencia a Propedéutico</td></tr></table>    
                        <div class="titulocelda" style=" text-align:center;padding-top:20px;">Selecciona el turno de la carrera <strong><asp:Label runat="server" ID="lbl_carrera"></asp:Label>&nbsp;</strong>y pulsa en una tarea de la barra de menu.<br /> <strong>Debe guardar la asistencia capturada haciendo click en Guardar asistencia.</strong></div>
                            <div style=" text-align:center;padding-top:20px">
                            <asp:DropDownList runat="server" ID="ddl_turnos" CssClass="tbxreg" Width="200px" AutoPostBack="True"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="rfv_ddl_turnos" runat="server" ErrorMessage="Es necesario elegir turno" 
                                                Display="None" ControlToValidate="ddl_turnos" SetFocusOnError="True" ValidationGroup="vg_turnos" InitialValue="0"></asp:RequiredFieldValidator>
                                               <ajax:ValidatorCalloutExtender ID="vcoe_rfv_turnos" runat="server" TargetControlID="rfv_ddl_turnos" CloseImageUrl="../img/close_coe.png" 
                                                CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                        </div>
                        <div style="padding-top:50px;">
                          
                           <asp:GridView runat="server" ID="gv_listado" GridLines="None" AutoGenerateColumns="false" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                               style="border:solid 1px #CCC" CellPadding="10" CellSpacing="0" EmptyDataText=":( No hay datos para mostrar." HeaderStyle-CssClass="gvheader"
                                AlternatingRowStyle-CssClass="gvrow_alt">
                               <Columns>
                                   <asp:BoundField DataField="R" HeaderText="No." SortExpression="NO" ItemStyle-HorizontalAlign="Left" />
                                   <asp:BoundField DataField="NOMBRE" HeaderText="Nombre(s)" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Left" />
                                   <asp:BoundField DataField="PATERNO" HeaderText="Apellido Paterno" SortExpression="PATERNO" ItemStyle-HorizontalAlign="Left" />
                                   <asp:BoundField DataField="MATERNO" HeaderText="Apellido Materno" SortExpression="MATERNO" ItemStyle-HorizontalAlign="Left" />
                                   <asp:TemplateField HeaderText="Dias 1-2-3"><ItemTemplate>
                                       <asp:HiddenField ID="hf_ustring" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ustring")%>' />
                                       <asp:HiddenField ID="hf_insorupd" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ins_or_upd")%>' />
                                       <asp:HiddenField ID="hf_carrera" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "carrera")%>' />
                                       <asp:HiddenField ID="hf_turno" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "turno")%>' />
                                       <asp:HiddenField ID="hf_css" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "css")%>' />
                                       <asp:UpdatePanel runat="server"><ContentTemplate>
                                       <table class="tablacien">
                                           <tr><td>
                                           <asp:CheckBox ID="cbx_dia1" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_dia1_CheckedChanged" Checked='<%# Bind("dia1")%>'/>   
                                           </td><td>
                                           <asp:CheckBox ID="cbx_dia2" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_dia1_CheckedChanged" Checked='<%# Bind("dia2")%>'/>   
                                           </td><td>
                                           <asp:CheckBox ID="cbx_dia3" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_dia1_CheckedChanged" Checked='<%# Bind("dia3")%>'/>   
                                           </td></tr>
                                       </table></ContentTemplate></asp:UpdatePanel>
                                   </ItemTemplate></asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="v_ok" runat="server">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_regresar1" Text="Calificar otro turno" CssClass="boton_texto_dentro"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                            <td style="font-size: 1.5em;"><asp:LinkButton ID="lb_regresar2" runat="server" CssClass="boton_texto_dentro" Text="Ir a otra carrera" /></td>
                        </tr></table></div>
                    <div>
                        <table class="tablacien"><tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px; text-align:center; margin:auto;">Captura de asistencia a Propedéutico</td></tr></table>
                        <div style="text-align:center;padding-top:20px;">Se han guardado correctamente los cambios</div>
                        <div style="padding:20px; text-align:center;"><img alt="Guardado Correcto" src="../img/ok_green.png"/></div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

