<%@ Page Title="SIAAA - Reporte alumnos sin Certificado" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="rnocertificado.aspx.vb" Inherits="contents_rnocertificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    
     <asp:UpdatePanel runat="server" ID="up_nocertificado">
        <ContentTemplate>

            <asp:MultiView runat="server" ID="mv_rnocertificado">
                <asp:View runat="server" ID="v_primera">
                    
                     <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Reporte de aspirantes UTJ que no han entregado Certificado</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un ciclo para mostrar el reporte. <br />
                                        Se ordena por carrera y despues por nombre. Podrá importar el reporte a un archivo excel para su manipulación.
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

                <asp:View runat="server" ID="v_segunda">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_exportar" Text="Exportar a Excel" CssClass="boton_texto_dentro"  /></td>
                        </tr></table></div>
                     <div>
                        <table class="tablacien">
                            <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Reporte de aspirantes UTJ del ciclo <asp:Label ID="lbl_ciclo" runat="server"></asp:Label> que no han entregado Certificado</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Exporte a excel desde al boton de arriba.</td></tr>
                        <tr><td>
                            <div>
                                <asp:GridView runat="server" ID="gv_nocertificado" GridLines="None" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                    style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                    <Columns>
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ReadOnly="true" SortExpression="NOMBRE" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="APATERNO" HeaderText="Primer Apellido" ReadOnly="true" SortExpression="APATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMATERNO" HeaderText="Segundo Apellido" ReadOnly="true" SortExpression="AMATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CARRERA" HeaderText="Carrera" ReadOnly="true" SortExpression="CARRERA" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TURNO" HeaderText="Turno" ReadOnly="true" SortExpression="TURNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FIJO" HeaderText="Tel. Fijo" ReadOnly="true" SortExpression="FIJO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MOVIL" HeaderText="Tel. Movil" ReadOnly="true" SortExpression="MOVIL" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OTRO" HeaderText="Otro Tel." ReadOnly="true" SortExpression="OTRO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EMAIL" HeaderText="Email" ReadOnly="true" SortExpression="EMAIL" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <RowStyle CssClass="gvrow" />
                                    <HeaderStyle CssClass="gvheader" />
                                </asp:GridView>
                            </div>
                            
                             </td></tr>
                        
                    </table>
                    </div>
                </asp:View>

            </asp:MultiView>

        </ContentTemplate>
    </asp:UpdatePanel>

    <br />
                    
    
</asp:Content>

