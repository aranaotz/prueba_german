<%@ Page Title="Reporte de Faltantes en Evaluacion y Asistencias" Language="VB" MasterPageFile="profworking.master" AutoEventWireup="false" CodeFile="eva_repf.aspx.vb" Inherits="eva_repf" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="general.css" rel="stylesheet" type="text/css" />
<link href="calendar.css" rel="stylesheet" type="text/css" />
    <div style="font-family: 'Segoe UI', Helvetica, Arial, Verdana; font-size: 10pt; color: #333333; vertical-align: middle; text-align: center; padding-right: 5px; padding-left: 5px; padding-bottom: 5px">
    <cc1:ToolkitScriptManager ID="sm_rfea" runat="server"></cc1:ToolkitScriptManager>
        <table style="width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding: 7px; background-position: center center; color: #FFFFFF; text-decoration: none; border: 1px solid #004174; background-color: #00376A; font-weight: bold;">
                    Reporte General de Fechas de Captura</td>
            </tr>
            <tr>
                <td style="border-color: #61B5C0; padding: 7px; background-color: #E3F2F4; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid;">
                    &nbsp;&nbsp;&nbsp;&nbsp; Puede consultar los reportes faltantes de asistencia y evaluación continua 
                    por separado. Seleccione que es lo que desea consultar y haga click en mostrar. 
                    Si desea ver solo los reportes faltantes, seleccione Ocultar entregados.</td>
            </tr>
            <tr>
                <td style="padding: 7px">
                    <table style="margin: auto">
                        <tr>
                            <td style="vertical-align: top; text-align: left; padding-top: 7px;">
                                Consultar fechas...</td>
                            <td style="border: 1px solid #999999; text-align: left; vertical-align: top; background-color: #EEEEEE;">
                                <asp:RadioButtonList ID="rbl_options" runat="server">
                                    <asp:ListItem Value="0" Selected="True">Por Evaluación Continua</asp:ListItem>
                                    <asp:ListItem Value="1">Por Asistencia</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left; vertical-align: top; padding-right: 7px; padding-left: 7px; padding-top: 3px;">
                                <asp:CheckBox ID="cbx_hide" runat="server" Text="Ocultar entregados" />
                            </td>
                            <td style="vertical-align: top; text-align: left; padding-right: 7px; padding-left: 7px; padding-top: 7px;">
                                <asp:Button ID="cmd_mostrar" runat="server" Text="Mostrar" 
                                    CssClass="botones_minis" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv_reporte" runat="server" AutoGenerateColumns="False" 
                        GridLines="Horizontal" Width="85%">
                        <HeaderStyle BackColor="#333333" ForeColor="White" Height="25px" />
                        <RowStyle BackColor="White" Height="18px" />
                        <Columns>
                            <asp:BoundField DataField="dias" HeaderText="Dia de Reporte" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha" HeaderText="Dia / Mes / Año" 
                                DataFormatString="{0:dd/MMMM/yyyy}" >
                            <ItemStyle HorizontalAlign="Left" BackColor="#E8F3FF" />
                            </asp:BoundField>
                            <asp:BoundField DataField="materia" HeaderText="Nombre del Curso" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="grupo" HeaderText="Grupo" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Estado"><ItemTemplate>
                            <asp:Image ID="ib_estado" runat="server" ImageUrl='<%# "img/" & DataBinder.Eval(Container.DataItem,"estado") & ".gif"%>' />
                            </ItemTemplate></asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="#E0F1EF" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>

