<%@ Page Title="SIAAA - Reporte de seguimiento de aspirantes" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="rseguimiento.aspx.vb" Inherits="contents_rseguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_rseguimiento">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_rseguimento">
                <asp:View runat="server" ID="v_primera">
                    <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Reporte de seguimiento de aspirantes UTJ</td></tr>
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
                
            <asp:View runat="server" ID="v_segunda">
                <asp:Label runat="server" ID="lbl_ciclo" Text="" Visible="false"></asp:Label>
                 <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_exportar" Text="Exportar a Excel" CssClass="boton_texto_dentro"  /></td>
                        </tr></table></div>
                    <div>
                        <%--asp:Label runat="server" ID="Label1" Text="" Visible="false"></asp:Label>--%>
                        <table class="tablacien">
                        <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Reporte de seguimiento de aspirantes UTJ del ciclo <asp:Label ID="lbl_ciclo1" runat="server"></asp:Label></td></tr>
                        <tr><td>
                          
                                <asp:GridView runat="server" ID="gv_seguimiento" GridLines="Vertical" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" HorizontalAlign="Center" 
                                    style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="5"  EmptyDataText=":( No hay datos por mostrar..">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Carrera">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lb_carrera" runat="server" Text='<%# Bind("CARRERA")%>' CssClass="texto_boton_gv" OnClick="lb_carrera_Click" CommandArgument='<%# Bind("CARRERA")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                        <asp:BoundField DataField="PRERREGISTRADOS" HeaderText="Registrados" ReadOnly="true" SortExpression="PRERREGISTRADOS" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PREMAT" HeaderText="Matutino" ReadOnly="true" SortExpression="PREMAT" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PREVESP" HeaderText="Vespertino" ReadOnly="true" SortExpression="PREVESP" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENTREVISTADOS" HeaderText="Entrevistados" ReadOnly="true" SortExpression="ENTREVISTADOS" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENTMAT" HeaderText="Matutino" ReadOnly="true" SortExpression="ENTMAT" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="ENTVESP" HeaderText="Vespertino" ReadOnly="true" SortExpression="ENTVESP" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENTREGADOS" HeaderText="Docs. Entregados" ReadOnly="true" SortExpression="ENTREGADOS" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENTREGMAT" HeaderText="Matutino" ReadOnly="true" SortExpression="ENTREGMAT" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENTREGVESP" HeaderText="Vespertino" ReadOnly="true" SortExpression="ENTREGVESP" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXAMEN" HeaderText="Examen realizado" ReadOnly="true" SortExpression="EXAMEN" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXAMAT" HeaderText="Matutino" ReadOnly="true" SortExpression="EXAMAT" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXAVESP" HeaderText="Vespertino" ReadOnly="true" SortExpression="EXAVESP" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="INDUCCION" HeaderText="Curso inducción" ReadOnly="true" SortExpression="INDUCCION" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="INDMAT" HeaderText="Matutino" ReadOnly="true" SortExpression="INDMAT" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="INDVESP" HeaderText="Vespertino" ReadOnly="true" SortExpression="INDVESP" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DICTAMINADOS" HeaderText="Dictaminados" ReadOnly="true" SortExpression="DICTAMINADOS" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DICMAT" HeaderText="Matutino" ReadOnly="true" SortExpression="DICMAT" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="DICVESP" HeaderText="Vespertino" ReadOnly="true" SortExpression="DICVESPT" >
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

                <asp:View runat="server" ID="v_tercera">
                 <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_exportaDetalle" Text="Exportar a Excel" CssClass="boton_texto_dentro"  OnClick="lb_exportaDetalle_Click" /></td>
                        </tr></table></div>

                    <div>
                        
                        <asp:HiddenField runat="server" ID="hf_ciclo" />
                        
                        <table class="tablacien">
                        <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Detalle de alumnos de la carrera <asp:Label runat="server" ID="lbl_carrera" Text="" Visible="true"> en el ciclo <asp:Label runat="server" ID="lbl_c" Text="" Visible="true"></asp:Label></asp:Label></td></tr>
                        <tr><td>
                            <div>
                                <asp:GridView runat="server" ID="gv_detalle" GridLines="None" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" HorizontalAlign="Center" 
                                    style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10" EmptyDataText=":( No hay datos por mostrar..">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                    <Columns>
                                        <asp:BoundField DataField="FOLIO" HeaderText="Folio" ReadOnly="true" SortExpression="FOLIO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Aspirante" ReadOnly="true" SortExpression="NOMBRE" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="APATERNO" HeaderText="Primer Apelldo" ReadOnly="true" SortExpression="APATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="AMATERNO" HeaderText="Segundo Apellido" ReadOnly="true" SortExpression="AMATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CARRERA" HeaderText="Carrera" ReadOnly="true" SortExpression="CARRERA" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="TURNO" HeaderText="Turno" ReadOnly="true" SortExpression="TURNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENTREVISTA" HeaderText="Entrevista" ReadOnly="true" SortExpression="ENTREVISTA" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="DOCUMENTOS" HeaderText="Documentos entregados" ReadOnly="true" SortExpression="DOCUMENTOS" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXAMEN" HeaderText="Examen realizado" ReadOnly="true" SortExpression="EXAMEN" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="INDUCCION" HeaderText="Inducción" ReadOnly="true" SortExpression="INDUCCION" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DICTAMINADO" HeaderText="Dictaminado" ReadOnly="true" SortExpression="DICTAMINADO" >
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

