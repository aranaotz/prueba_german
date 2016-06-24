<%@ Page Title="" Language="VB" MasterPageFile="~/logins/logins.master" AutoEventWireup="false" CodeFile="constancia_sencilla_foto.aspx.vb" Inherits="contents_constancia_sencilla_foto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <asp:MultiView runat="server" ID="mv_contastancia_sencilla_foto">

                <asp:View runat="server" ID="v_cero">

                             <table class="centrado"><tr><td class="titulocategoria" style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">Constancia de estudios sencilla con fotografía</td></tr><tr><td>
                               <table class="centrado"><tr><td style="padding: 0 10px 0 0">Matricula, nombres o apellidos</td><td>
                               <asp:TextBox ID="tbx_busqueda" runat="server" CssClass="tbxreg" MaxLength="100" Width="400px"></asp:TextBox></td>
                               <td><asp:Button ID="cmd_buscar" runat="server" Text="Buscar alumno" CssClass="botones" style="font-size: 100%;" CausesValidation="True" /></td></tr></table></td></tr>
                               <tr><td style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">
                                   <asp:GridView ID="gv_resultados" runat="server" AutoGenerateColumns="false" EmptyDataText="No se han encontrado coincidencias :(" GridLines="None" ShowHeader="False" HorizontalAlign="center">
                               <Columns>
                                   <asp:TemplateField><ItemTemplate><div id="gv_result" style="text-align:left;"><table><tr><td><asp:LinkButton ID="lb_gvresultado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item")%>'
                                           CommandArgument='<%# DataBinder.Eval(Container.DataItem, "matricula")%>' CssClass="boton_texto_resultados" OnClick="lb_gvresultado_Click"></asp:LinkButton></td><td style="padding: 7px 0px 0px 5px;"><asp:imageButton ID="ib_delete" runat="server" ImageUrl="../img/close_coer.png"/></td></tr></table></div></ItemTemplate></asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                           </td></tr>
                   </table>

                </asp:View>  

            </asp:MultiView>
</asp:Content>

