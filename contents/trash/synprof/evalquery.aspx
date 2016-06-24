<%@ Page Title="Consulta de Resultados - SADIN CGI 2010" Language="VB" MasterPageFile="profworking.master" AutoEventWireup="false" CodeFile="evalquery.aspx.vb" Inherits="evalquery" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControls" namespace="AjaxControls" tagprefix="cc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="prof.css" rel="stylesheet" type="text/css" />
    <link href="general.css" rel="stylesheet" type="text/css" />
<link href="calendar.css" rel="stylesheet" type="text/css" />

 <div style="padding: 0px; font-family: 'Segoe UI','Helvetica Neue', 'Lucida Grande', Arial, Helvetica, Verdana, sans-serif; font-size: 1em; color: #333333">
<cc3:ModalUpdateProgress ID="mup_this" runat="server" 
                        AssociatedUpdatePanelID="up_consulta" 
                        BackgroundCssClass="modalBackground_blanco" CancelControlID="lb_cancel" 
                        DisplayAfter="100"><ProgressTemplate>
                        <table align="center" style="width:100%; "><tr><td style="vertical-align: middle; text-align: center">
                            <!--<img alt="Recuperando Informacion" src="img/loading_mac.gif" />
                            <asp:Image ID="im_progress" runat="server" ImageUrl="~/sadin_stock/img/sadin_loading.gif" />-->
                            </td></tr>
                        <tr><td style="vertical-align: middle; text-align: center; font-family: 'Segoe UI', Arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                            <asp:LinkButton ID="lb_cancel" runat="server" style="text-decoration:none; white-space:nowrap;">&lt;&lt; Cargando datos &gt;&gt;</asp:LinkButton>
                            </td></tr></table>
                        </ProgressTemplate>
     </cc3:ModalUpdateProgress>
        <table style="width:100%; margin: auto; text-align: center">
            <tr>
                <td>
                    <cc1:ToolkitScriptManager ID="sm_consulta" runat="server" 
                        EnableScriptGlobalization="True">
                    </cc1:ToolkitScriptManager>
                    Pulse sobre un curso para consultar la evaluación
                    </td>
                        </tr>
                    </table>
                
                    <div style="margin: auto; text-align: center">
                    <asp:UpdatePanel ID="up_consulta" runat="server">
                            <ContentTemplate>
                                <table style="margin: auto; width:100%; text-align: center;">
                                   <tr>
                                        <td>
                                            <asp:MultiView ID="mv_consulta" runat="server">
                                            <asp:View ID='v_cursos' runat="server">
                                            <table style="margin: auto">
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:DataList ID="dl_materias" runat="server" HorizontalAlign="Center" RepeatColumns="2" RepeatDirection="Horizontal" CellSpacing="5" ShowFooter="False" ShowHeader="False" CellPadding="2">
                                                <ItemStyle Height="70px" HorizontalAlign="Center" VerticalAlign="Middle" Width="50%" Wrap="true"/>
                                                <ItemTemplate>
                                                    <div>
                                                        <table class="menu_selection">
                                                            <tr>
                                                                <td style="padding: 2px 0px 2px 5px; text-align: left; width:0%;">
                                                                    <asp:Image ID="im_imagen" runat="server" ImageUrl="img/note.png" />
                                                                </td>
                                                                <td style="padding-left: 10px; padding-right: 10px; text-align: left; width:100%;">
                                                                    <asp:LinkButton ID="lb_materia" runat="server" CssClass="boton_texto" style="text-decoration:none;" Text='<%# DataBinder.Eval(Container.DataItem,"mtr") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"icu") %>' CommandName="mostrar" OnClick="docommand"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                            </table>
                                            </asp:View>
                                                <asp:View ID="v_alumnos" runat="server">
                                                    <div style="margin: auto; text-align: center">
                                                        <table style="margin: auto; width:100%; text-align: center;">
                                                            <tr>
                                                                <td style="padding-left: 10px; text-align: center; padding-top: 15px; padding-bottom: 5px;">
                                                                    <table style="margin: auto">
                                                                        <tr>
                                                                            <td>
                                                                                Se muestra
                                                                                <asp:Label ID="lbl_etiqueta" runat="server"></asp:Label><br />
                                                                                Pulse el ícono para cambiar</td>
                                                                            <td style="padding-right: 5px; padding-left: 5px">
                                                                                <asp:ImageButton ID="ib_cambiarcurso" runat="server" 
                                                                                    ImageUrl="img/note.png" style="width: 42px"/>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DataList ID="dl_reportes" runat="server" HorizontalAlign="Center" 
                                                                        Width="90%" CellPadding="2" CellSpacing="2">
                                                                        <ItemTemplate>
                                                                            <table style="width:100%;" 
                                                                                cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td style="height: 40px; ">
                                                                                        <table cellpadding="0" cellspacing="0" style="width:100%;">
                                                                                            <tr>
                                                                                                <td style="vertical-align: middle; text-align: center; padding-left: 15px;">
                                                                                                    <asp:HiddenField ID="hf_icu" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"icu") %>' />&nbsp;
                                                                                                    </td>
                                                                                                <td style="vertical-align: middle; text-align: center; width: 100%; height: 40px;">
                                                                                                    Reporte correspondiente al mes de
                                                                                                    <asp:Label ID="lbl_mes" runat="server" 
                                                                                                        TabIndex='<%# DataBinder.Eval(Container.DataItem,"nmes") %>' 
                                                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"mes") %>'></asp:Label>
                                                                                                    &nbsp;<strong>(Inicia el
                                                                                                    <asp:Label ID="lbl_fdi" runat="server" 
                                                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"inicio", "{0:dddd dd MMMM yyyy}") %>'></asp:Label>
                                                                                                    &nbsp;y finaliza el
                                                                                                    <asp:Label ID="lbl_fdf" runat="server" 
                                                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"final","{0:dddd dd MMMM yyyy}") %>'></asp:Label>
                                                                                                    </strong>)
                                                                                                    <asp:HiddenField ID="hf_nmes" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"nmes") %>' />
                                                                                                    <asp:HiddenField ID="hf_ide" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"ide") %>' />
                                                                                                    <asp:HiddenField ID="hf_type" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"finalex") %>' />
                                                                                                    <asp:HiddenField ID="hf_finalex" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"finalex") %>' />
                                                                                                    <asp:HiddenField ID="hf_tipo" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"tipo") %>' />
                                                                                                    <asp:HiddenField ID="hf_fdi" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"inicio") %>' />
                                                                                                    <asp:HiddenField ID="hf_fdf" runat="server" 
                                                                                                        value='<%# DataBinder.Eval(Container.DataItem,"final") %>' />
                                                                                                </td>
                                                                                                <td style="background-image: url('img/report_top_r.png'); background-repeat: no-repeat; background-position: right top; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; font-size: 9pt; vertical-align: middle; text-align: center; padding-right: 19px;"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    <asp:MultiView ID="mv_cal" runat="server">
                                                                                    <asp:View ID="normal" runat="server">
                                                                                    <asp:GridView ID="evaluacion" runat="server" AutoGenerateColumns="False" 
                                                                                            GridLines="Horizontal" HorizontalAlign="Center" Width="100%">
                                                                                            <RowStyle VerticalAlign="Middle" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField><ItemTemplate>
                                                                                                <asp:HiddenField ID="hf_matr" runat="server" Value='<%# Databinder.Eval(Container.DataItem,"alumno") %>'/>
                                                                                                </ItemTemplate></asp:TemplateField>
                                                                                                <asp:BoundField DataField="fname" HeaderText="Alumno" >
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Faltas">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lb_faltas" runat="server" CommandName="faltas" OnClick="dofunction" Text='<%# Databinder.Eval(Container.DataItem,"textasistence") %>' CommandArgument='<%# Databinder.Eval(Container.DataItem,"icu") %>' valmatr='<%# Databinder.Eval(Container.DataItem,"alumno") %>' TabIndex='<%# Databinder.Eval(Container.DataItem,"nmes") %>' Enabled='<%# Databinder.Eval(Container.DataItem,"asistenceenable") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ev. Continua">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lb_evc" runat="server" CommandName="evc" OnClick="dofunction" Text='<%# Databinder.Eval(Container.DataItem,"evc") %>' CommandArgument='<%# Databinder.Eval(Container.DataItem,"icu") %>' valmatr='<%# Databinder.Eval(Container.DataItem,"alumno") %>' TabIndex='<%# Databinder.Eval(Container.DataItem,"nmes") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Punto Extra">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lb_pe" runat="server" CommandName="pe" OnClick="dofunction" Text='<%# Databinder.Eval(Container.DataItem,"ep") %>' CommandArgument='<%# Databinder.Eval(Container.DataItem,"icu") %>' valmatr='<%# Databinder.Eval(Container.DataItem,"alumno") %>' TabIndex='<%# Databinder.Eval(Container.DataItem,"nmes") %>' Enabled='<%# Databinder.Eval(Container.DataItem,"infoepu") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="P.E.Continua">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lb_peec" runat="server" CommandName="pee" OnClick="dofunction" Text='<%# Databinder.Eval(Container.DataItem,"evcpe") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Examen">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_examen" runat="server" Text='<%# Databinder.Eval(Container.DataItem,"calif") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Promedio" DataField="final" />
                                                                                            </Columns>
                                                                                            <HeaderStyle Height="25px" CssClass="percent" />
                                                                                            <AlternatingRowStyle BackColor="#fcf9f9" VerticalAlign="Middle" />
                                                                                        </asp:GridView>
                                                                                    </asp:View><asp:View ID="v_exam" runat="server">
                                                                                    <asp:GridView ID="gv_examen" runat="server" AutoGenerateColumns="False" 
                                                                                            GridLines="Horizontal" HorizontalAlign="Center" Width="100%">
                                                                                            <RowStyle BackColor="White" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField><ItemTemplate>
                                                                                                <asp:HiddenField ID="hf_matr" runat="server" Value='<%# Databinder.Eval(Container.DataItem,"matr") %>'/>
                                                                                                </ItemTemplate></asp:TemplateField>
                                                                                                <asp:BoundField DataField="fname" HeaderText="Alumno" >
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                            <asp:BoundField HeaderText="Ev.1,2,3." />
                                                                                                <asp:TemplateField HeaderText="Examen Ord.">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lb_examen" runat="server" CommandName="examen" 
                                                                        OnClick="dofunction"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Cursos (pts)">
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lbl_pextra" runat="server" Text='<%# Databinder.Eval(Container.DataItem,"pnts") %>' ToolTip='<%# Databinder.Eval(Container.DataItem,"justify") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                                                <asp:BoundField HeaderText="Final" />
                                                                                                <asp:BoundField HeaderText="Estado" DataField="commn">
                                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="Extraordinario" />
                                                                                            </Columns>
                                                                                            <HeaderStyle ForeColor="White" Height="24px" BackColor="#666666" />
                                                                                            <AlternatingRowStyle BackColor="#E0FF9F" />
                                                                                        </asp:GridView>
                                                                                    </asp:View>
                                                                                    </asp:MultiView>
                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="padding-right: 10px; text-align: right;">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Button ID="cmd_print" runat="server" 
                                                                                                        CommandName='<%# Databinder.Eval(Container.DataItem,"mes") %>' 
                                                                                                        CssClass="botones_chaparros" OnClick="cmd_print_Click" 
                                                                                                        CommandArgument='<%# Databinder.Eval(Container.DataItem,"icu") %>'
                                                                                                        TabIndex="<%# Container.ItemIndex %>" Text="Imprimir reporte" />
                                                                                                </td>
                                                                                                <td style="padding-right: 10px; padding-left: 10px">
                                                                                                    <asp:Label ID="lbl_fecha" runat="server" Font-Italic="True" ForeColor="#333333"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:HiddenField ID="hf_faltas" runat="server" />
                             <asp:HiddenField ID="hf_evc" runat="server" />
                            <cc1:ModalPopupExtender ID="hf_evc_mpe" runat="server" 
                                BackgroundCssClass="modalBackground_blanco" CancelControlID="ib_closeevc" 
                                DynamicServicePath="" Enabled="True" PopupControlID="p_evc" 
                                TargetControlID="hf_evc"></cc1:ModalPopupExtender>
                            <cc1:ModalPopupExtender ID="hf_faltas_mpe" runat="server" 
                                BackgroundCssClass="modalBackground_blanco" CancelControlID="ib_closef" 
                                DynamicServicePath="" Enabled="True" PopupControlID="p_faltas" 
                                TargetControlID="hf_faltas"></cc1:ModalPopupExtender>
                            <asp:Panel ID="p_faltas" runat="server" style="display:none;">
                            <table>
                                <tr>
                                    <td style="text-align: right; padding-bottom: 10px">
                                        <asp:ImageButton ID="ib_closef" runat="server" 
                                            ImageUrl="img/closewindow.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" 
                                            
                                            style="margin: auto; border: 1px solid #666666; background-color: #FFFFFF; width: 100%;">
                                            <tr>
                                                <td style="background-image: url('img/topgvorange.gif'); background-repeat: repeat-x; background-position: center center; color: #FFFFFF; font-family: verdana; font-size: 7.5pt; height: 25px; padding-right: 20px; padding-left: 20px;">
                                                    Consulta de Faltas del Alumno</td>
                                            </tr>
                                            <tr>
                                                <td style="margin: auto; padding: 7px; text-align: center;">
                                                    <asp:GridView ID="gv_faltas" runat="server" AutoGenerateColumns="False" 
                                                        GridLines="Horizontal" HorizontalAlign="Center" Width="100%">
                                                        <RowStyle BackColor="White" Height="18px" />
                                                        <Columns>
                                                            <asp:BoundField DataField="eval_cal" HeaderText="Tipo" />
                                                            <asp:BoundField DataField="fecha" HeaderText="Fecha" 
                                                                DataFormatString='{0:dd/MM/yyyy}' ItemStyle-ForeColor="Maroon" >
                                                                <ItemStyle ForeColor="Maroon" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="alias" HeaderText="Hora" />
                                                         </Columns>
                                                        <HeaderStyle CssClass="top-header" ForeColor="White" Height="22px" />
                                                        <AlternatingRowStyle BackColor="#FFDDDD" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 4px; background-color: #333333; color: #FFFFFF">
                                                    SADIN CGI MMX</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="p_evc" runat="server" style="display:none;">
                            <table>
                                <tr>
                                    <td style="text-align: right; padding-bottom: 10px">
                                        <asp:ImageButton ID="ib_closeevc" runat="server" 
                                            ImageUrl="img/closewindow.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" 
                                            style="border: 1px solid #666666; background-color: #FFFFFF; width: 100%;">
                                            <tr>
                                                <td style="background-image: url('img/topgvorange.gif'); background-repeat: repeat-x; background-position: center center; color: #FFFFFF; font-family: verdana; font-size: 7.5pt; height: 25px; padding-right: 20px; padding-left: 20px;">
                                                    Evaluación Continua del Alumno</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 7px; text-align: center;">
                                                    <asp:GridView ID="gv_evc" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                                                HeaderText="Fecha" />
                                                            <asp:BoundField DataField="forma" HeaderText="Rubro">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="description" HeaderText="Descripcion">
                                                            <ItemStyle BackColor="#E9F2A6" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="eval_cal" HeaderText="Calif." />
                                                            <asp:BoundField DataField="xcent" HeaderText="%" />
                                                            <asp:BoundField DataField="puntos" HeaderText="Puntos" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 4px; background-color: #333333; color: #FFFFFF">
                                                    SADIN CGI MMX</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                                                    </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </asp:View>
                                            </asp:MultiView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
               
    </div>
</asp:Content>

