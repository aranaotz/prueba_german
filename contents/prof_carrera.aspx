<%@ Page Title="" Language="VB" MasterPageFile="~/logins/logins.master" AutoEventWireup="false" CodeFile="prof_carrera.aspx.vb" Inherits="contents_prof_carrera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    
    <asp:UpdatePanel runat="server" ID="up_prof_carrera">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_prof_carrera">
                <asp:View runat="server" ID="v_cero">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_recarga" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar cambios" CssClass="boton_texto_dentro"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_cambiar" Text="Cambiar contraseña" CssClass="boton_texto_dentro"/></td>
                        </tr></table></div>
                    <div>
                        <div class="titulocategoria" style="text-align:center;padding-top:30px">Administración de docentes</div>
                        <div class="titulocelda" style="text-align:center;padding-top:30px">Selecciona una carrera de la lista para ver a los profesores <asp:Label runat="server" ID="lbl_clave"></asp:Label></div>
                        <div style="padding-top:30PX;text-align:center">
                            <asp:DropDownList runat="server" ID="ddl_carreras" CssClass="ddlreg" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div style="padding-top:30px">
                            <asp:GridView runat="server" ID="gv_prof" GridLines="None" CssClass="gvrow" AutoGenerateColumns="false" HorizontalAlign="Center"  style="border: solid 1px #ccc;"
                                CellPadding="5" CellSpacing="0">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id. Empleado">
                                        <ItemTemplate>
                                            <div style="text-align:center">
                                                <asp:LinkButton ID="lb_id_prof" runat="server" Text='<%# Bind("clavetrab") %>' CssClass="texto_boton_gv" CommandArgument='<%# Bind("clavetrab") %>'></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="apellidopat" HeaderText="Primer Apellido" SortExpression="apepat" />
                                    <asp:BoundField DataField="apellidomat" HeaderText="Segundo Apellido" SortExpression="apemat" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombre(s)" SortExpression="nombres" />
                                    <asp:BoundField  DataField="cargo" HeaderText="Puesto" SortExpression="cargo"/>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>

