<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="rgeneral.aspx.vb" Inherits="contents_rgeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_rgeneral">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_rgeneral">
                <asp:View runat="server" ID="v_primera">
                     <div>
                        <table class="tablacien">
                            <tr><td class="titulocategoria">FECHAS DE EXAMEN</td></tr>
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td style="width:5%"></td><td class="titulocelda" style="width:90%">SELECCIONA EL CICLO</td><td style="width:5%"></td></tr>
                                    <tr><td style="width:5%"></td><td style="width:90%">
                                        <asp:GridView runat="server" ID="gv_ciclos" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" CellPadding="10" HorizontalAlign="Center">
                                            <AlternatingRowStyle CssClass="gvrow_alt" />
                                            <Columns>
                                    <asp:TemplateField HeaderText="CICLO">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lb_ciclo" runat="server" Text='<%# Bind("CICLO")%>' CssClass="boton_texto_dentro" OnClick="lb_ciclo_Click"  CommandArgument='<%# Bind("CICLO")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FECHAS" HeaderText="FECHAS" ReadOnly="True" SortExpression="FECHAS" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                    <asp:BoundField DataField="INICIO" HeaderText="INICIO" ReadOnly="True" SortExpression="INICIO" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                    <asp:BoundField DataField="FIN" HeaderText="FIN" ReadOnly="True" SortExpression="FIN" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                    <asp:CheckBoxField DataField="ACTIVO" HeaderText="ACTIVO" SortExpression="ACTIVO" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:CheckBoxField>
                                </Columns>
                                            <RowStyle CssClass="gvrow" />
                                        </asp:GridView>
                                      </td><td style="width:5%"></td></tr>
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
                        <asp:Label runat="server" ID="lbl_carrera" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="lbl_c" Text="" Visible="false"></asp:Label>
                        <table class="tablacien">
                        <tr><td style="width:5%"></td><td class="titulocelda" style="width:90%">REPORTE GENERAL</td><td style="width:5%"></td></tr>
                        <tr><td style="width:5%"></td><td style="width:90%">
                            <div>
                                <asp:GridView runat="server" ID="gv_general" GridLines="None" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" HorizontalAlign="Center" CellPadding="5">
                                    <AlternatingRowStyle CssClass="gvrow_alt" />
                                    <Columns>
                                        <asp:BoundField DataField="FOLIO" HeaderText="FOLIO" ReadOnly="true" SortExpression="FOLIO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE COMPLETO" ReadOnly="true" SortExpression="NOMBRE" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CARRERA" HeaderText="CARRERA" ReadOnly="true" SortExpression="CARRERA" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="TURNO" HeaderText="TURNO" ReadOnly="true" SortExpression="TURNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENTREVISTA" HeaderText="ENTREVISTA" ReadOnly="true" SortExpression="ENTREVISTA" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="DOCUMENTOS" HeaderText="DOCUMENTOS ENTREGADOS" ReadOnly="true" SortExpression="DOCUMENTOS" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXAMEN" HeaderText="EXAMEN REALIZADO" ReadOnly="true" SortExpression="EXAMEN" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="INDUCCION" HeaderText="INDUCCION" ReadOnly="true" SortExpression="INDUCCION" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DICTAMINADO" HeaderText="DICTAMINADO" ReadOnly="true" SortExpression="DICTAMINADO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        
                                    </Columns>
                                    <RowStyle CssClass="gvrow" />
                                </asp:GridView>
                            </div>
                            <br />
                                
                           
                            
                             </td><td style="width:5%"></td></tr>
                        
                            <tr>
                                <td style="width:5%">&nbsp;</td>
                                <td style="width:90%"></td>
                                <td style="width:5%">&nbsp;</td>
                            </tr>
                        
                    </table>
                    </div>
                </asp:View>


                </asp:View>
            </asp:MultiView>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>

