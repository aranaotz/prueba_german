<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="dateofntrvw.aspx.vb" Inherits="contents_dateofntrvw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">

    <asp:UpdatePanel runat="server" ID="up_dateofntvw">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_dateofntvw">
                <asp:View runat="server" ID="v_primera">
                    <div>
                        <asp:ListView ID="lv_ciclos" runat="server">
                            <ItemTemplate>
                                <div>
                                    <table><tr><td>Ciclo <asp:Label id="lbl_ciclo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ciclo")%>'/></td></tr>
                                        <tr><td>
                                            <table><tr><td>Primer ingreso inicia</td><td><asp:Label ID="lbl_startdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "startdate")%>' /></td></tr>
                                                <tr><td>El ciclo finaliza</td><td><asp:Label ID="lbl_finaldate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "enddate")%>' /></td></tr>
                                                <tr><td>Las entrevistas terminan</td><td><asp:Label ID="lbl_entrevistas_fin" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "entrevistas_fin")%>' /></td></tr>
                                                <tr><td>El examen de admisión</td><td><asp:Label ID="lbl_fecha_examen" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "fecha_examen")%>' /></td></tr>
                                                <tr><td>La entrega de documentos inicia</td><td><asp:Label ID="lbl_documentos_inicio" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "documentos_inicio")%>' /></td></tr>
                                                <tr><td>y finaliza</td><td><asp:Label ID="lbl_documentos_fin" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "documentos_fin")%>' /></td></tr>
                                                <tr><td>El inicio de las enrevistas</td><td><asp:Label ID="lbl_entrevistastart" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "entrevistastart")%>' /></td></tr>
                                                <tr><td>La ultima fecha de entrevista</td><td><asp:Label ID="lbl_entrevistaend" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "entrevistaend")%>' /></td></tr>
                                            </table></td></tr>
                                        <tr><td><table><tr><td><asp:Button ID="cmd_diasentrevista" runat="server" CssClass="botones" Text="Ver o modificar fecha de entrevista" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ciclo")%>'/></td>
                                            <td><asp:Button ID="cmd_actualizarciclo" runat="server" CssClass="botones" Text="Modificar otras fechas" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ciclo")%>'/></td></tr></table></td></tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="v_segunda">
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                       <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="cmd_save" Text="Guardar cambios" CssClass="boton_texto_dentro"/></td>
                       <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                       <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_mesanterior" Text="Mes Anterior" CssClass="boton_texto_dentro"/></td>
                       <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                       <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_messiguiente" Text="Siguiente mes" CssClass="boton_texto_dentro"/></td>
                       </tr></table></div>
                    <div>
                    <table>
                        <tr><td><asp:Label ID="lbl_mes" runat="server"></asp:Label> del <asp:Label ID="lbl_anio" runat="server"></asp:Label></td></tr>
                        
                        <tr><td>

                        <table><tr><td>Domingo</td><td>Lunes</td><td>Martes</td><td>Miercoles</td><td>Jueves</td><td>Viernes</td><td>Sábado</td></tr>
                            <tr><td><asp:LinkButton ID="lb_detalle" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="cbx_select" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="hf_11" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton1" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton2" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField2" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton3" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField3" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton4" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField4" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton5" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField5" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton6" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField6" runat="server" Value="11"/></td></tr>



                            <tr><td><asp:LinkButton ID="LinkButton7" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField7" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton8" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox8" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField8" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton9" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox9" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField9" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton10" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox10" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField10" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton11" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox11" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField11" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton12" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox12" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField12" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton13" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox13" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField13" runat="server" Value="11"/></td></tr>



                            <tr><td><asp:LinkButton ID="LinkButton14" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox14" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField14" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton15" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox15" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField15" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton16" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox16" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField16" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton17" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox17" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField17" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton18" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox18" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField18" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton19" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox19" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField19" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton20" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox20" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField20" runat="server" Value="11"/></td></tr>



                            <tr><td><asp:LinkButton ID="LinkButton21" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox21" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField21" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton22" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox22" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField22" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton23" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox23" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField23" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton24" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox24" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField24" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton25" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox25" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField25" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton26" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox26" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField26" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton27" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox27" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField27" runat="server" Value="11"/></td></tr>



                            <tr><td><asp:LinkButton ID="LinkButton28" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox28" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField28" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton29" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox29" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField29" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton30" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox30" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField30" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton31" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox31" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField31" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton32" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox32" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField32" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton33" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox33" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField33" runat="server" Value="11"/></td>

                                <td><asp:LinkButton ID="LinkButton34" runat="server" Text="Detalle" />
                                <asp:CheckBox ID="CheckBox34" runat="server" AutoPostBack="true" OnCheckedChanged="cbx_select_CheckedChanged" />
                                <asp:HiddenField ID="HiddenField34" runat="server" Value="11"/></td></tr>
                        </table>

                               </td></tr></table>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

