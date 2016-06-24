<%@ Page Title="Evaluación de Alumnos - SIAAA 2016" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="gradeassign.aspx.vb" Inherits="gradeassign" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    <div>
    <asp:MultiView ID="mv_evaluacion" runat="server">
        <asp:View ID="v_listaicus" runat="server">
        <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Herramienta de evaluación de alumnos</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click sobre el icu correspondiente al curso que desea Evaluar.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_listas" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                        style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay materias en el ciclo actual...">
                                        <AlternatingRowStyle CssClass="gvrow_alt" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ICU"><ItemTemplate><div><asp:LinkButton ID="lb_icu" runat="server" Text='<%# Bind("icu")%>' 
                                                CssClass="texto_boton_gv" OnClick="lb_icu_Click" CommandArgument='<%# Bind("icu")%>'></asp:LinkButton></div></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField DataField="cve_materia" HeaderText="Clave" ReadOnly="True"/>
                                            <asp:BoundField DataField="materia" HeaderText="Curso" ReadOnly="True"/>
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
        <asp:View ID="v_listaalumnos" runat="server">
            <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_temp" Text="Guardar temporal " CssClass="boton_texto_dentro" ValidationGroup="temp"/></td>
                        <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_def" Text="Guardar definitiva" CssClass="boton_texto_dentro"/></td>                      
                        </tr></table></div>
            <div style="padding-top:20px;padding-bottom:20px;">
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Herramienta de evaluación de alumnos</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Escriba la calificación en base 10 de cada alumno.<br />Según las fechas establecidas por
                                        el director de carrera puede evaluar de forma temporal y definitiva.
                                        </td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_alumnos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                        style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay alumnos inscritos en el icu seleccionado...">
                                        <AlternatingRowStyle CssClass="gvrow_alt" />
                                        <Columns>
                                            <asp:TemplateField><ItemTemplate><div><asp:HiddenField ID="hf_matricula" runat="server" Value='<%# Bind("icu")%>'>
                                            </asp:HiddenField></div></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField DataField="matricula" HeaderText="Matricula" ReadOnly="True"/>
                                            <asp:BoundField DataField="fullname" HeaderText="Alumno" ReadOnly="True"/>
                                            <asp:TemplateField HeaderText="Ev.Continua" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Textbox ID="tbx_continua" runat="server" Text='<%# Bind("evcont")%>' CssClass="tbx_eval" Width="50px"></asp:Textbox>
                                                    </div>
                                                    <ajax:FilteredTextBoxExtender ID="ftbe_tbx_continua" runat="server" FilterType="Numbers, Custom"
                                                         ValidChars="." TargetControlID="tbx_continua" />
                                                    <asp:RegularExpressionValidator ID="rev_tbx_continua" runat="server" Display="None" ErrorMessage="La calificación es base 10 con un punto decimal. Esta no parece una calificacón válida :(" 
                                                     ControlToValidate="tbx_continua" ValidationGroup="temp" ValidationExpression="^[7-9](\.\d{1})?|10$" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vco_rev_tbx_continua" runat="server" TargetControlID="rev_tbx_continua" CloseImageUrl="../img/close_coe.png" 
                                                    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>          
                                                    <asp:RequiredFieldValidator ID="rfv_tbx_continua" runat="server" ErrorMessage="¡Este alumno no tiene calificación, por favor de asigne una!." 
                                                        Display="None" ControlToValidate="tbx_continua" SetFocusOnError="True" ValidationGroup="temp"></asp:RequiredFieldValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_tbx_continua" runat="server" TargetControlID="rfv_tbx_continua" CloseImageUrl="../img/close_coe.png" 
                                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                   </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ev.Remedial" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Textbox ID="tbx_remedial" runat="server" Text='<%# Bind("evrem")%>' CssClass="tbx_eval" Width="50px"></asp:Textbox>
                                                    </div>
                                                    <ajax:FilteredTextBoxExtender ID="ftbe_tbx_remedial" runat="server" FilterType="Numbers, Custom"
                                                         ValidChars="." TargetControlID="tbx_remedial" />
                                                    <asp:RegularExpressionValidator ID="rev_tbx_remedial" runat="server" Display="None" ErrorMessage="La calificación es base 10 con un punto decimal. Esta no parece una calificacón válida :(" 
                                                     ControlToValidate="tbx_remedial" ValidationGroup="rem" ValidationExpression="^[1-9](\.\d{1})?|10$" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vco_rev_tbx_remedial" runat="server" TargetControlID="rev_tbx_remedial" CloseImageUrl="../img/close_coe.png" 
                                                    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>          
                                                    <asp:RequiredFieldValidator ID="rfv_tbx_remedial" runat="server" ErrorMessage="¡Este alumno no tiene calificación, favor de asignarle una!." 
                                                        Display="None" ControlToValidate="tbx_remedial" SetFocusOnError="True" ValidationGroup="rem"></asp:RequiredFieldValidator>
                                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_tbx_remedial" runat="server" TargetControlID="rfv_tbx_remedial" CloseImageUrl="../img/close_coe.png" 
                                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                                   </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            
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
    </asp:MultiView>
          
                    
               
    
      
        </div>
</asp:Content>

