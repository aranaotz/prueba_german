<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="rrazones.aspx.vb" Inherits="contents_rrazones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_rrazones">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_rrazones">
                <asp:View runat="server" ID="v_cero">
                  
                     <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Reporte motivos de inscripcion de aspirantes UTJ</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un ciclo para mostrar el reporte. <br />                                        
                                        </td></tr>
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
                <asp:View runat="server" ID="v_uno">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_exportar" Text="Exportar a Excel" CssClass="boton_texto_dentro"  OnClick="lb_exportar_Click"/></td>
                        </tr></table></div>
                    <div>
                        <table class="tablacien">
                            <tr><td class="titulocategoria" style="text-align:center;">Reporte de medios de difusion del ciclo <strong><asp:Label runat="server" ID="lbl_ciclo"></asp:Label></strong></td></tr>
                            <tr><td>
                                <div>
                                    <asp:GridView runat="server" ID="gv_razones" AutoGenerateColumns="false"  GridLines="None" RowStyle-CssClass="gvrow"
                                         HorizontalAlign="Center" style="border: solid 1px #ccc;" CellPadding="5" CellSpacing="5  " EmptyDataText=":( No hay datos para mostrar">
                                        <AlternatingRowStyle CssClass="gvrow_alt" />
                                        <Columns>
                                            <asp:BoundField DataField="descripcion" HeaderText="Motivo" ReadOnly="true" SortExpression="descripcion" >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="razmat" HeaderText="Mat" ReadOnly="true" SortExpression="razmat" >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="razvesp" HeaderText="Vesp" ReadOnly="true" SortExpression="razvesp" >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="raztot" HeaderText="Total" ReadOnly="true" SortExpression="raztot" >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    
                                </div>
                                </td></tr>
                        </table>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

