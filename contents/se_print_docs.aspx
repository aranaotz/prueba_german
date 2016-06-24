<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="se_print_docs.aspx.vb" Inherits="contents_se_print_docs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_se_print_docs">
        <ContentTemplate>

            <asp:MultiView runat="server" ID="mv_se_print_docs">
                <asp:View runat="server" ID="v_cero">

                   <div>
                       <div>
                           <table style="width:100%;">
                        <tr><td class="titulocategoria" style="text-align:center;padding-top:30px">Impresión de documentos Servicios Escolares</td></tr>
                        <tr><td class="titulocelda" style="text-align:center;padding-top:30px">Da clic sobre la descripción del documento para consultar las peticiones de los alumnos</td></tr>
                        <tr><td style="padding-top:30px">
                            <asp:GridView runat="server" ID="gv_docs" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border:solid 1px #ccc" CellPadding="5" CellSpacing="5" HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Descripción">
                                        <ItemTemplate>
                                            <div style="text-align:left">
                                                <asp:LinkButton runat="server" ID="lb_doc" Text='<%# Bind("DESCRIPCION") %>' CssClass="texto_boton_gv" OnClick="lb_doc_Click" CommandArgument='<%# Bind("DESCRIPCION") %>'></asp:LinkButton>
                                                   
                                                
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                            </td></tr>                  
                    </table>
                       </div>
                   </div>

                </asp:View>
            </asp:MultiView>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

