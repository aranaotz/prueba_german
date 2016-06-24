<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="studentdt - Copia.aspx.vb" Inherits="contents_studentdt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_studentdt">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_studentdt">
                <asp:View runat="server" ID="v_cero">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_generar" Text="Generar contraseña" CssClass="boton_texto_dentro" OnClick ="lb_generar_Click"/></td>
                         </tr></table></div>
                    <div style="padding-top:20px;text-align:center;" class="titulocategoria">Datos del alumno</div>
                    <div style="padding-top:20px;text-align:center;">
                        <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:20%">Matrícula</td>
                                <td class="titulocelda"style="width:25%">Nombres</td>
                                <td class="titulocelda"style="width:20%">Primer Apellido</td>
                                <td class="titulocelda"style="width:20%">Segundo Apellido</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:20%"><asp:TextBox runat="server" ID="tbx_matricula" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_nombres" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_primero" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_segundo" CssClass="tbxreg"></asp:TextBox></td>
                            </tr>
                            </table>
                        <table class="centrado" style="width:80%">
                            <tr>
                               <td class="titulocelda"style="width:40%">Carrera</td>
                                <td class="titulocelda"style="width:5%">Nivel</td>
                                <td class="titulocelda"style="width:5%">Plan</td>
                                <td class="titulocelda"style="width:15%">Turno</td>
                                <td class="titulocelda"style="width:5%">Grado</td>
                                <td class="titulocelda"style="width:5%">Grupo</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:40%"><asp:TextBox runat="server" ID="tbx_carrera" CssClass="tbxreg" ></asp:TextBox></td>
                                <td class="titulocelda" style="width:5%"><asp:TextBox runat="server" ID="tbx_nivel" CssClass="tbxreg" ></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_plan" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:15%"><asp:TextBox runat="server" ID="tbx_turno" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_grado" CssClass="tbxreg" ></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_grupo" CssClass="tbxreg" ></asp:TextBox></td>
                            </tr>
                        </table>
                         <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:30%">Estatus de Alumno</td>
                                <td class="titulocelda"style="width:25%">CURP</td>
                                <td class="titulocelda"style="width:20%">RFC</td>
                                <td class="titulocelda"style="width:25%">NSS</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:30%"><asp:TextBox runat="server" ID="tbx_status" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_curp" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:20%"><asp:TextBox runat="server" ID="tbx_rfc" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_nss" CssClass="tbxreg"></asp:TextBox></td>
                            </tr>
                            </table>
                         <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:50%">Correo Electrónico</td>
                                <td class="titulocelda"style="width:25%">Telefono Fijo</td>
                                <td class="titulocelda"style="width:25%">Telefono Móvil</td>                               
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:50%"><asp:TextBox runat="server" ID="tbx_email" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_fijo" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:25%"><asp:TextBox runat="server" ID="tbx_movil" CssClass="tbxreg"></asp:TextBox></td>                              
                            </tr>
                            </table>
                          <table class="centrado" style="width:80%">
                            <tr>
                                <td class="titulocelda"style="width:50%">Domicilio</td>
                                <td class="titulocelda"style="width:5%">Num. ext.</td>
                                <td class="titulocelda"style="width:5%">Num. int</td>
                                <td class="titulocelda"style="width:10%">CP</td>
                            </tr>
                            <tr>
                                <td class="titulocelda" style="width:50%"><asp:TextBox runat="server" ID="tbx_domicilio" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_ext" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:5%"><asp:TextBox runat="server" ID="tbx_int" CssClass="tbxreg"></asp:TextBox></td>
                                <td class="titulocelda"style="width:10%"><asp:TextBox runat="server" ID="tbx_cp" CssClass="tbxreg"></asp:TextBox></td>
                            </tr>
                            </table>
                        
                    </div>
                    
                    
                </asp:View>

                 <asp:view ID="v_busqueda" runat="server">
                <table class="centrado"><tr><td class="titulocategoria" style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">Registro de datos personales del alumno(a)</td></tr><tr><td>
                    <table class="centrado"><tr><td style="padding: 0 10px 0 0">Alumno</td><td>
                    <asp:TextBox ID="tbx_busqueda" runat="server" CssClass="tbxreg" MaxLength="100" Width="400px"></asp:TextBox></td>
                    <td><asp:Button ID="cmd_buscar" runat="server" Text="Buscar alumno(s)" CssClass="botones" style="font-size: 100%;" CausesValidation="True" /></td></tr></table></td></tr>
                    <tr><td style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">
                        <asp:GridView ID="gv_resultados" runat="server" AutoGenerateColumns="false" EmptyDataText="No se han encontrado coincidencias :(" GridLines="None" ShowHeader="False" HorizontalAlign="center">
                            <Columns>
                                <asp:TemplateField><ItemTemplate>
                                    <div id="gv_result" style="text-align:left;"><table><tr><td><asp:LinkButton ID="lb_gvresultado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item")%>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' CssClass="boton_texto_resultados" OnClick="lb_gvresultado_Click"></asp:LinkButton></td>
                                        <td style="padding: 7px 0px 0px 5px;"><asp:imageButton ID="ib_delete" runat="server" ImageUrl="../img/close_coer.png"/></td></tr></table></div>
                                                   </ItemTemplate></asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </td></tr>
                </table>
            </asp:view>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

