<%@ Page Title="SIAAA - Reporte de promedio de aspirantes" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="rpbachiller.aspx.vb" Inherits="contents_rpbachiller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <!--<script type="text/javascript">
        function mostrar() {
            document.getElementById('oculto').style.display = 'inline';
        }
</script>-->
    <asp:UpdatePanel runat="server" ID="up_rpromedio">
        <ContentTemplate>

            <asp:MultiView runat="server" ID="mv_rpromedio">
                <asp:View runat="server" ID="v_cero">
                     <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Reporte de promedio de bachillerato de aspirantes UTJ</td></tr>
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
               
                <asp:View runat="server" ID="v_uno">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_exportar" Text="Exportar a Excel" CssClass="boton_texto_dentro"  /></td>
                        </tr></table></div>
                    <div>
                        <table class="tablacien">
                        <tr><td class="titulocategoria" style="text-align: center;">Reporte de promedio de aspirantes UTJ de la carrera <asp:Label ID="lbl_carrera" runat="server"></asp:Label> del ciclo <asp:Label runat="server" ID="lbl_ciclo" Text="" Visible="true"></asp:Label></td></tr>
                        <tr><td>
                            <div>
                                <asp:GridView runat="server" ID="gv_promedioCarrera" GridLines="None" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" 
                                    HorizontalAlign="Center" style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                    <AlternatingRowStyle CssClass="gvrow_alt"/>
                                   <Columns>
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ReadOnly="true" SortExpression="NOMBRE" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PATERNO" HeaderText="Apellido Paterno" ReadOnly="true" SortExpression="PATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="MATERNO" HeaderText="Apellido Materno" ReadOnly="true" SortExpression="MATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CARRERA" HeaderText="Carrera" ReadOnly="true" SortExpression="CARRERA" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TURNO" HeaderText="Turno" ReadOnly="true" SortExpression="TURNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BACHILLERATO" HeaderText="P. Bachillerato" ReadOnly="true" SortExpression="BACHILLERATO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                 <asp:View runat="server" ID="v_dos">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_atras_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_atras__Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_all" Text="Ver General" CssClass="boton_texto_dentro" OnClick="lb_all_Click" /></td>
            </tr></table></div>
                    <table class="centrado" style="text-align:center;"><tr><td>
                    <div>
                        <div class="titulocategoria" style="text-align:center">Elegir carrera</div>
                        
                        <div class="titulocelda" style="text-align:center; padding: 20px;">Haga click en la clave de un programa para ver el promedio del aspirante.</div>
                        <div>
                            <asp:GridView runat="server" ID="gv_listado" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="center"
                                style="border:solid 1px #ccc" CellSpacing="0" CellPadding="10" HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Clave">
                                        <ItemTemplate>
                                            <div>   
                                                <asp:LinkButton runat="server" ID="lb_clave" Text='<%# Bind("CLAVE")%>' CssClass="texto_boton_gv" OnClick="lb_clave_Click" CommandArgument='<%# Bind("CLAVE")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Left"/>
                                     
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div><table><tr><td>
                </asp:View>
                 <asp:View runat="server" ID="v_tres">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_export" Text="Exportar a Excel" CssClass="boton_texto_dentro"  /></td>
                        </tr></table></div>
                    <div>
                        <table class="tablacien">
                        <tr><td class="titulocategoria" style="text-align: center;">Reporte General de promedio de&nbsp; aspirantes UTJ del ciclo <asp:Label runat="server" ID="Label1" Text="" Visible="true"></asp:Label></td></tr>
                        <tr><td>
                            <div>
                                <asp:GridView runat="server" ID="gv_promedioAll" GridLines="None" AutoGenerateColumns="False" RowStyle-CssClass="gvrow" 
                                    HorizontalAlign="Center" style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                    <AlternatingRowStyle CssClass="gvrow_alt"/>
                                    <Columns>
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ReadOnly="true" SortExpression="NOMBRE" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PATERNO" HeaderText="Apellido Paterno" ReadOnly="true" SortExpression="PATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="MATERNO" HeaderText="Apellido Materno" ReadOnly="true" SortExpression="MATERNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CARRERA" HeaderText="Carrera" ReadOnly="true" SortExpression="CARRERA" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TURNO" HeaderText="Turno" ReadOnly="true" SortExpression="TURNO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BACHILLERATO" HeaderText="P. Bachillerato" ReadOnly="true" SortExpression="BACHILLERATO" >
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
    <!--<div id='oculto' style='display:none;'>
        <asp:Button runat="server" ID="cmd_excel" Text="Excel" CssClass="botones" />
        </div>-->
</asp:Content>

