<%@ Page Title="" Language="VB" MasterPageFile="profworking.master" AutoEventWireup="false" CodeFile="htool.aspx.vb" Inherits="htool" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="general.css" rel="stylesheet" type="text/css" />
    <div style="padding: 10px; font-family: 'Segoe UI', Helvetica, Arial, Verdana; font-size: 10pt; color: #333333;">
    <cc1:ToolkitScriptManager ID="sm_htool" runat="server"></cc1:ToolkitScriptManager>
     
    <asp:GridView ID="gv_schedgrupo" runat="server" AutoGenerateColumns="False">
                                <RowStyle BackColor="White" />
                                <Columns>
                                   <asp:BoundField HeaderText="HORA" DataField="full_alias" >
                                       <ItemStyle ForeColor="#333333" HorizontalAlign="Right" BackColor="Silver" 
                                        VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="LUNES">
                                        <ItemTemplate>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center; font-size: 8pt; font-variant: small-caps; font-style: italic;">
                                                        <asp:Label ID="lbl_11" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_12" runat="server" Font-Italic="True" ForeColor="#660033"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_13" runat="server" ForeColor="#FF9B9B"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MARTES">
                                     <ItemTemplate>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center; font-size: 8pt; font-variant: small-caps; font-style: italic;">
                                                        <asp:Label ID="lbl_21" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_22" runat="server" Font-Italic="True" ForeColor="#660033"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_23" runat="server" ForeColor="#FF9B9B"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate></asp:TemplateField>
                                    <asp:TemplateField HeaderText="MIERCOLES">
                                     <ItemTemplate>
                                            <table style="width:100%;">
                                                <tr>
                                                     <td style="padding: 1px; vertical-align: middle; text-align: center; font-size: 8pt; font-variant: small-caps; font-style: italic;">
                                                        <asp:Label ID="lbl_31" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_32" runat="server" Font-Italic="True" ForeColor="#660033"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_33" runat="server" ForeColor="#FF9B9B"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate></asp:TemplateField>
                                    <asp:TemplateField HeaderText="JUEVES">
                                     <ItemTemplate>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center; font-size: 8pt; font-variant: small-caps; font-style: italic;">
                                                        <asp:Label ID="lbl_41" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_42" runat="server" Font-Italic="True" ForeColor="#660033"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_43" runat="server" ForeColor="#FF9B9B"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate></asp:TemplateField>
                                    <asp:TemplateField HeaderText="VIERNES">
                                     <ItemTemplate>
                                            <table style="width:100%;">
                                                <tr>
                                                     <td style="padding: 1px; vertical-align: middle; text-align: center; font-size: 8pt; font-variant: small-caps; font-style: italic;">
                                                        <asp:Label ID="lbl_51" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_52" runat="server" Font-Italic="True" ForeColor="#660033"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_53" runat="server" ForeColor="#FF9B9B"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate></asp:TemplateField>
                                    <asp:TemplateField HeaderText="SABADO">
                                     <ItemTemplate>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center; font-size: 8pt; font-variant: small-caps; font-style: italic;">
                                                        <asp:Label ID="lbl_61" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_62" runat="server" Font-Italic="True" ForeColor="#660033"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 1px; vertical-align: middle; text-align: center;">
                                                        <asp:Label ID="lbl_63" runat="server" ForeColor="#FF9B9B"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate></asp:TemplateField>
                                </Columns>
                                <HeaderStyle ForeColor="White" Height="25px" BackColor="#333333" 
                                    HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:GridView></div>
</asp:Content>

