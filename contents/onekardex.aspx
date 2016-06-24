<%@ Page Title="Kardex del Alumno - SIAAA UTJ 2016" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="onekardex.aspx.vb" Inherits="onekardex" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <div>
      <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
           <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_importar" Text="Imprimir Kardex" CssClass="boton_texto_dentro"/></td>
          <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
           </tr></table></div>
      <div class="div_titulo_medio">Kardex del Estudiante</div>
      <div style="background-color: rgba(149, 48, 79,0.8)">
        <asp:FormView ID="fv_datos" runat="server" Width="100%"><ItemTemplate>
          <div class="div_subtitulo_medio" style="color: #fff;">Datos del estudiante</div>
          <div class="div_texto_medio" style="color: #fff;">
              <table style="margin: auto; border-collapse:separate;"><tr><td rowspan="2"><asp:Image ID="img_user" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "imageminipath")%>' Width="50" style="border-radius: 5px;"/></td>
                  <td style="text-align:right; padding: 0px 5px 0px 5px;">Nombre</td><td class="datoscabezalkardex"><asp:Label ID="lbl_nombre" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "nombre_completo")%>'></asp:Label></td>
              <td style="text-align:right; padding: 0px 5px 0px 5px;">Matricula</td><td class="datoscabezalkardex"><asp:Label ID="lbl_matricula" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "matricula")%>'></asp:Label></td></tr><tr><td style="text-align:right; padding: 0px 5px 0px 5px;">Carrera</td>
                  <td colspan="3" class="datoscabezalkardex" style=""><asp:Label ID="lbl_carrera" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "nombre")%>'></asp:Label></td></tr></table></div>
        </ItemTemplate></asp:FormView>
      </div>
        <asp:DataList ID="dl_kardex" runat="server" HorizontalAlign="Center" CellPadding="10">
            <ItemTemplate>
                <table class="folder_view"><tr><td style="padding: 10px; font-size: 1.5em;">Ciclo <asp:Label ID="lbl_ciclo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ciclo")%>'></asp:Label>
                           <asp:HiddenField ID="hf_matricula" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "matricula")%>'/> </td></tr><tr><td style="border-radius: 0px 0px 5px 5px; padding: 5px;">
                    <asp:GridView ID="gv_calificaciones" runat="server" style="background: rgba(0,168,144,1); width: 100%;" AutoGenerateColumns="False" GridLines="None" CellPadding="5" RowStyle-CssClass="gvrow" ShowHeader="false">
                        <Columns>
                            <asp:BoundField DataField="materia" ItemStyle-HorizontalAlign="Left"/>
                            <asp:BoundField DataField="calificacion" />
                            <asp:BoundField DataField="descripcion" />
                            <asp:BoundField DataField="tipocalificacion" />
                        </Columns>
                    </asp:GridView>
                </td></tr></table>
            </ItemTemplate>
        </asp:DataList>
     </div>
</asp:Content>

