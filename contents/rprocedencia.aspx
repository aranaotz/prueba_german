<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="rprocedencia.aspx.vb" Inherits="contents_rprocedencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_rprocedencia">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_rprocedencia">
                <asp:View runat="server" ID="v_cero">
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Estadistica Escuela de procedencia de aspirantes UTJ</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un ciclo para mostrar el reporte.</td></tr>
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
                <asp:Label runat="server" ID="lbl_ciclo" Text="" Visible="false"></asp:Label>
                 <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_exportar" Text="Exportar a Excel" CssClass="boton_texto_dentro"  /></td>
                        </tr></table></div>
                    <div>
                        <%--asp:Label runat="server" ID="Label1" Text="" Visible="false"></asp:Label>--%>
                        <table class="tablacien">
                        <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Reporte de seguimiento de aspirantes UTJ del ciclo <asp:Label ID="lbl_ciclo1" runat="server"></asp:Label></td></tr>
                        <tr><td>
                            <div class="titulocelda" style="text-align:center;padding-bottom:20px">Da clic sobre el nombre del bachillerato para ver mas información</div>

                                <asp:GridView runat="server" ID="gv_procedencia" GridLines="None" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" HorizontalAlign="center"
                                    style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="5"  EmptyDataText=":( No hay datos por mostrar..">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Escuela de Procedencia">
                                        <ItemTemplate>
                                            <div style="text-align:left">
                                                <asp:LinkButton ID="lb_bachillerato" runat="server" Text='<%# Bind("BACHILLERATO")%>' CssClass="texto_boton_gv" OnClick="lb_bachillerato_Click" CommandArgument='<%# Bind("BACHILLERATO")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                        <asp:BoundField DataField="BACHIMAT" HeaderText="Matutino" ReadOnly="true" SortExpression="BACHIMAT" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BACHIVESP" HeaderText="Vespertino" ReadOnly="true" SortExpression="BACHIVESP" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TOTAL" HeaderText="Total" ReadOnly="true" SortExpression="TOTAL" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
  
                                    </Columns>
                                    <RowStyle CssClass="gvrow" />
                                    <HeaderStyle CssClass="gvheader" />
                                </asp:GridView></tr>
                            
                    </table>
                    </div>
            </asp:View>

                <asp:View runat="server" ID="v_dos">
                 <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"></td>
                        </tr></table></div>

                    <div>
                        
                        
                        <table class="tablacien">
                        <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Detalle del bachillerato <asp:Label runat="server" ID="lbl_bachillerato" Text="" Visible="true"></asp:Label></td></tr>
                        <tr><td>
                            
                            <div>
                                <asp:GridView runat="server" ID="gv_detalle" GridLines="None" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" HorizontalAlign="Center" 
                                    style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" EmptyDataText=":( No hay datos por mostrar..">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                    <Columns>
                                        <asp:BoundField DataField="programa" HeaderText="Programa" ReadOnly="true" SortExpression="programa" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nombre_ct" HeaderText="Nombre de Centro" ReadOnly="true" SortExpression="nombre_ct" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="estado" HeaderText="Estado" ReadOnly="true" SortExpression="estado" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="municipio" HeaderText="Municipio" ReadOnly="true" SortExpression="municipio" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="localidad" HeaderText="Localidad" ReadOnly="true" SortExpression="localidad" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="domicilio" HeaderText="Domicilio" ReadOnly="true" SortExpression="domicilio" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="telefono" HeaderText="Telefono" ReadOnly="true" SortExpression="telefono" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                       
                                        
                                    </Columns>
                                    <RowStyle CssClass="gvrow" />
                                    <HeaderStyle CssClass="gvheader" />
                                </asp:GridView>
                            </div>
                            </tr></table>
                    </div>
                </asp:View>

            </asp:MultiView>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

