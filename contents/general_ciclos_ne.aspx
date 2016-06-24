<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="general_ciclos_ne.aspx.vb" Inherits="contents_general_ciclos_ne" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_general_ciclos">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_general_ciclos">

                <asp:View runat="server" ID="v_cero">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_refresh" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><%--<asp:Linkbutton runat="server" ID="lb_nuevo" Text="Agregar ciclo" CssClass="boton_texto_dentro" OnClick="lb_nuevo_Click" />--%></td>
                        </tr></table></div>

                     <div>
                        <table class="tablacien">
                            <tr><td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 15px 5px 15px 5px;">Información general sobre los ciclos</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un ciclo para mostrar detalles.</td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_ciclos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Ciclo">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lb_ciclo" runat="server" Text='<%# Bind("ciclo")%>' CssClass="texto_boton_gv" OnClick="lb_ciclo_Click" CommandArgument='<%# Bind("ciclo")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:BoundField DataField="fechas" HeaderText="Periodo" ReadOnly="True" SortExpression="FECHAS" />
                                    <asp:BoundField DataField="inicio" HeaderText="Inicio del ciclo" ReadOnly="True" SortExpression="INICIO" />
                                    <asp:BoundField DataField="fin" HeaderText="Fin del ciclo" ReadOnly="True" SortExpression="FIN" />
                                    <asp:CheckBoxField DataField="active" HeaderText="Activo" SortExpression="ACTIVO" />
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
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="Guardar" Text="Guardar ciclo" CssClass="boton_texto_dentro" OnClick="Guardar_Click"  ValidationGroup="nciclo"/></td>
                        </tr></table></div>

                    <div style="text-align:center" class="titulocategoria">Agregar ciclo</div>
                    <div>
                        <table style="width: 50%" class="centrado">
                            <tr>
                                <td>Ciclo</td>
                                <td>Fecha inicio</td>
                                <td>Fecha fin</td>
                                <td>Activo</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtciclo" CssClass="tbxreg"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_ciclo" runat="server" ErrorMessage="El identificador del ciclo es indispensable (ej. 2013B)"
                                        Display="None" ControlToValidate="txtCiclo" SetFocusOnError="True" ValidationGroup="nciclo"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_ciclo" runat="server" TargetControlID="rfv_ciclo" CloseImageUrl="../img/close_coe.png"
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True">
                                    </ajax:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtInicio" CssClass="tbxreg"></asp:TextBox>
                                    <ajax:CalendarExtender ID="cal_inicio" runat="server" TargetControlID="txtInicio" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="rfv_inicio" runat="server" ErrorMessage="Debe elejir la fecha de inicio del ciclo. El formato es AAAA/MM/DD (ej. 2013/09/25)"
                                        Display="None" ControlToValidate="txtInicio" SetFocusOnError="True" ValidationGroup="nciclo"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_inicio" runat="server" TargetControlID="rfv_inicio" CloseImageUrl="../img/close_coe.png"
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True">
                                    </ajax:ValidatorCalloutExtender>
                                </td>
                           
                                <td>
                                    <asp:TextBox runat="server" ID="txtFin" CssClass="tbxreg"></asp:TextBox>
                                    <ajax:CalendarExtender ID="cal_fin" runat="server" TargetControlID="txtFin" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="rfv_fin" runat="server" ErrorMessage="Es importante la fecha de termino del ciclo. El formato es AAAA/MM/DD (ej. 2013/09/25)"
                                        Display="None" ControlToValidate="txtFin" SetFocusOnError="True" ValidationGroup="nciclo"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_fin" runat="server" TargetControlID="rfv_fin" CloseImageUrl="../img/close_coe.png"
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True">
                                    </ajax:ValidatorCalloutExtender>
                               
                            </td>
                                <td>
                                    <asp:CheckBox runat="server" ID="cbx_activo" /></td>
                            </tr>
                           <asp:HiddenField runat="server" ID="hf_ciclo"></asp:HiddenField>
                                

                            
                        </table>

                    </div>

                </asp:View>

                <asp:View runat="server" ID="v_dos">

                    <div class="topbar"><table><tr><td><asp:ImageButton ID="un_atras" runat="server" ImageUrl="~/img/arrowback.png" OnClick="un_atras_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_atras" Text="Regresar" CssClass="boton_texto_dentro" OnClick="lb_atras_Click" ValidationGroup="gciclo"/></td>
                        </tr></table></div>
                    
                        <div class="titulocategoria" style="text-align:center;padding-top:10px;">Información detallada del ciclo: <asp:Label runat="server" Font-Bold="true" ID="lbl_ciclo"></asp:Label></div>


                        <div style="padding-left:50px;">

                        <div style="float:left">

                       
                        <div class="titulocategoria" style="text-align:left;padding-top:20px;padding-left:300px;">Actividades Académicas</div>
                      
                        <div>
                            <table style="width:100%;padding-left:300px">
                                <tr>
                                    <td style="width:20%;text-align:right">Inicio de clases</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_inicio" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_inicio" runat="server" TargetControlID="tbx_inicio" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_inicio" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_inicio" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_inicio" TargetControlID="rfv_tbx_inicio" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                
                                <tr>
                                    <td style="width:20%;text-align:right">Inicio de registro de evaluación continua en periodo ordinario</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_inicio_continua" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_inicio_continua" runat="server" TargetControlID="tbx_inicio_continua" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_inicio_continua" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_inicio_continua" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_inicio_continua" TargetControlID="rfv_tbx_inicio_continua" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                  <tr>
                                    <td style="width:20%;text-align:right">Fin de registro de evaluación continua en periodo ordinario</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_fin_continua" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ec_tbx_fin_continua" runat="server" TargetControlID="tbx_fin_continua" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_fin_continua" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_fin_continua" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_fin_continua" TargetControlID="rfv_tbx_fin_continua" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                
                                <tr>
                                    <td style="width:20%;text-align:right">Inicio de captura de alumnos egresados (aprobación de estadía)</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_inicio_estadia" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_inicio_estadia" runat="server" TargetControlID="tbx_inicio_estadia" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_inicio_estadia" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_inicio_estadia" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_inicio_estadia" TargetControlID="rfv_tbx_inicio_estadia" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                 <tr>
                                    <td style="width:20%;text-align:right">Fin de captura de alumnos egresados (aprobación de estadía)</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_fin_estadia" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                     <ajax:CalendarExtender ID="ce_tbx_fin_estadia" runat="server" TargetControlID="tbx_fin_estadia" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_fin_estadia" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_fin_estadia" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_fin_estadia" TargetControlID="rfv_tbx_fin_estadia" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td style="width:20%;text-align:right">Fin de cursos</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_fin_curso" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                     <ajax:CalendarExtender ID="ce_tbx_fin_curso" runat="server" TargetControlID="tbx_fin_curso" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_fin_curso" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_fin_curso" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_fin_curso" TargetControlID="rfv_tbx_fin_curso" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td style="width:20%;text-align:right"> Inicio de evaluaciones por acciones remediales</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_inicio_remediales" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_inicio_remediales" runat="server" TargetControlID="tbx_inicio_remediales" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_inicio_remediales" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_inicio_remediales" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_inicio_remediales" TargetControlID="rfv_tbx_inicio_remediales" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td style="width:20%;text-align:right"> Fin de evaluaciones por acciones remediales</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_fin_remediales" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_fin_remediales" runat="server" TargetControlID="tbx_fin_remediales" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_fin_remediales" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_fin_remediales" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_fin_remediales" TargetControlID="rfv_tbx_fin_remediales" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td style="width:20%;text-align:right">Inicio de registro de evaluaciones por acciones remediales</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_inicio_reg_remediales" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_inicio_reg_remediales" runat="server" TargetControlID="tbx_inicio_reg_remediales" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_inicio_reg_remediales" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_inicio_reg_remediales" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_inicio_reg_remediales" TargetControlID="rfv_tbx_inicio_reg_remediales" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td style="width:20%;text-align:right">Fin de registro de evaluaciones por acciones remediales</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_fin_reg_remediales" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_fin_reg_remediales" runat="server" TargetControlID="tbx_fin_reg_remediales" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_fin_reg_remediales" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_fin_reg_remediales" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_fin_reg_remediales" TargetControlID="rfv_tbx_fin_reg_remediales" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                                <tr>
                                    <td style="width:20%;text-align:right">Fin de ciclo escolar</td>
                                    <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_fin" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <ajax:CalendarExtender ID="ce_tbx_fin" runat="server" TargetControlID="tbx_fin" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_fin" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_fin" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_fin" TargetControlID="rfv_tbx_fin" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                </tr>
                            </table>
                        </div>
                        </div>
                        <div style="float:right;position:relative; bottom:665px;left:100px">

                            
                            <div class="titulocategoria" style="text-align:left;padding-top:20px;">Suspensión de actividades</div>
                                <div>
                                    <table style="width:100%;padding-left:30px">
                                        <tr>
                                            <td style="width:20%;text-align:right">Días no laborables</td>
                                            <td style="padding-left:20px;text-align:left;padding-top:20px">
                                                <asp:TextBox runat="server" ID="tbx_no_laborables" CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:20%;text-align:right">Otros días no laborables</td>
                                            <td style="padding-left:20px;text-align:left;padding-top:20px">
                                                <asp:TextBox runat="server" ID="tbx_otro" CssClass="tbxreg" Width="400px" Enabled="False" ReadOnly="True"></asp:TextBox> 
                                            </td>
                                        </tr>

                                         <ajax:CalendarExtender ID="ce_tbx_no_laborables" runat="server" TargetControlID="tbx_no_laborables" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_no_laborables" ErrorMessage="No puedes agregar un campo nuevo si este campo esta vacío"
                                             Display="None" ControlToValidate="tbx_no_laborables" SetFocusOnError="true" ValidationGroup="uno"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_no_laborables" TargetControlID="rfv_tbx_no_laborables" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                   
                                        <tr>
                                            <td style="width:20%;text-align:right">Inicio de vacaciones de <asp:Label runat="server" ID="lbl_inicio_vacaciones" Text="Estación"></asp:Label></td>
                                            <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_inicio_vacaciones"  CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                            <ajax:CalendarExtender ID="ce_tbx_inicio_vacaciones" runat="server" TargetControlID="tbx_inicio_vacaciones" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_inicio_vacaciones" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_inicio_vacaciones" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="cvoe_rfv_tbx_inicio_vacaciones" TargetControlID="rfv_tbx_inicio_vacaciones" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                        </tr>
                                        <tr>
                                            <td style="width:20%;text-align:right">Fin de vacaciones de <asp:Label runat="server" ID="lbl_fin_vaciones" Text="Estación"></asp:Label></td>
                                            <td style="padding-left:20px;text-align:left;padding-top:20px"><asp:TextBox runat="server" ID="tbx_fin_vacaciones"  CssClass="tbxreg" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                             <ajax:CalendarExtender ID="ce_tbx_fin_vacaciones" runat="server" TargetControlID="tbx_fin_vacaciones" Format="yyyy/MM/dd"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_fin_vacaciones" ErrorMessage="Este campo no puede estar vacio"
                                             Display="None" ControlToValidate="tbx_fin_vacaciones" SetFocusOnError="true" ValidationGroup="gciclo"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender runat="server" ID="vcoe_rfv_tbx_fin_vacaciones" TargetControlID="rfv_tbx_fin_vacaciones" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></ajax:ValidatorCalloutExtender>
                                        </tr>
                                
                                    </table>
                                </div>
                            </div>
                        </div>
                   
                </asp:View>
                <asp:View runat="server" ID="v_tres">
                     <div class="topbar">
                         <table>
                             <tr>
                                 <td>
                                     <asp:ImageButton ID="ib_regresar_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar__Click"/></td>
                                 <td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>                                  
                                    <td style="font-size: 1.5em;">
                                        <asp:LinkButton ID="lb_regresar_" runat="server" CssClass="boton_texto_dentro" Text="Volver al inicio" OnClick="lb_regresar__Click" />
                                    </td>
                                    </tr>
                         </table>
                     </div>           

                                   
                                <div style="text-align: center" class="centrado">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">El periodo escolar se ha modificado correctamente en el sistema!
                                        
                                </div>
               
                 </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

