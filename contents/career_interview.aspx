<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master"  AutoEventWireup="false" CodeFile="career_interview.aspx.vb" Inherits="contents_career_interview" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControls" namespace="AjaxControls" tagprefix="asp2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
    
    <script type="text/javascript">
             function detectar_tecla(){
                if (keyCode==13) {
                    alert('enter');
                    return false;
                }
        }
    </script>

    <asp:UpdatePanel runat="server" ID="up_pinrevis">
        <ContentTemplate>
            <div style="padding-bottom:200px">
                <asp:MultiView runat="server" ID="mv_general">
                        <asp:view ID="v_busqueda" runat="server">
                             <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
           
        </tr></table></div>
                            <table class="centrado"><tr><td class="titulocategoria" style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">Revisión de registro</td></tr><tr><td>
                                <asp:Panel ID="p_busqueda" runat="server" DefaultButton="cmd_buscar">
                                <table class="centrado"><tr><td style="padding: 0 10px 0 0">Aspirante</td><td>
                                <asp:TextBox ID="tbx_busqueda" runat="server" CssClass="tbxreg" MaxLength="100" Width="400px"></asp:TextBox></td>
                                <td><asp:Button ID="cmd_buscar" runat="server" Text="Buscar aspirante(s)" CssClass="botones" style="font-size: 100%;" CausesValidation="True"/></td></tr></table></asp:Panel>
                                </td></tr>
                                <tr><td style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">
                                    <asp:GridView ID="gv_resultados" runat="server" AutoGenerateColumns="false" EmptyDataText="No se han encontrado coincidencias :(" GridLines="None" ShowHeader="False" HorizontalAlign="center">
                                        <Columns>
                                            <asp:TemplateField><ItemTemplate>
                                                <div id="gv_result" style="text-align:left;"><table><tr><td><asp:LinkButton ID="lb_gvresultado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item")%>'
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' CssClass="boton_texto_resultados" OnClick="lb_gvresultado_Click"></asp:LinkButton></td>
                                                    <td style="padding: 7px 0px 0px 5px;"><asp:imageButton ID="ib_delete" runat="server" ImageUrl="../img/close_coer.png"/></td></tr></table></div>
                                                   <%-- <asp:HiddenField runat="server" ID="hf_ustring" Value='<%# Eval("ustring")%>' />--%>
                                   
                                                               </ItemTemplate></asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    </td></tr>
                            </table>
                    </asp:view>
                    
                    <asp:View ID="v_datos" runat="server">
     
                 <asp:HiddenField ID="hf_popup_ok" runat="server" />

        <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="cmd_save" Text="Guardar cambios" CssClass="boton_texto_dentro" ValidationGroup="ntrvwr"/></td>
            
        </tr></table></div>
              
                
        <table class="tablacien" style="width:70%"><tr><td style="padding: 10px;"><asp:Label ID="lbl_msg" runat="server" visible="False"/></td></tr>
        <tr><td><table><tr><td><asp:Image ID="img_user" runat="server" ImageUrl="../img/egg.png" style="width: 150px;"/></td><td style="vertical-align: bottom; text-align: left;">
            <table><tr><td>&nbsp;</td></tr><tr><td>
                La fotografia sólo es editable en la primer cita.</td></tr></table>
            </td></tr></table></td></tr>
            <tr>
                <td class="titulocategoria">Revisión de Registro</td>
                <asp:HiddenField runat="server" ID="id"/>
               
            </tr>
            <tr><td>
            <asp:UpdatePanel ID="up_carreras" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
              <table class="tablacien" style="text-align: left;"><tr><td class="titulocelda">Elije la carrera que deseas ingresar</td><td class="titulocelda">Turno al que asistirás a clases</td></tr>
               <tr>
              <td class="celdascien" style="width: 80%"><asp:DropDownList ID="ddl_carreras" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" ValidationGroup="reg" Enabled="False"></asp:DropDownList></td>
              <td class="celdascien" style="width: 20%"><asp:DropDownList ID="ddl_turno" runat="server" CssClass="ddlreg_cien" ValidationGroup="reg" Enabled="False"></asp:DropDownList></td></tr></table>
                <asp:RequiredFieldValidator ID="rfv_ddl_carrera" runat="server" ErrorMessage="¡Es necesaria tu elección de carrera!." 
                    Display="None" ControlToValidate="ddl_carreras" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="vcoe_rfv_carrera" runat="server" TargetControlID="rfv_ddl_carrera" CloseImageUrl="../img/close_coe.png" 
                    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                
                <asp:RequiredFieldValidator ID="rfv_ddl_turno" runat="server" ErrorMessage="¡Selecciona el turno!." 
                    Display="None" ControlToValidate="ddl_turno" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_turno" runat="server" TargetControlID="rfv_ddl_turno" CloseImageUrl="../img/close_coe.png" 
                    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
            </ContentTemplate></asp:UpdatePanel>
            </td></tr>

        <tr><td class="titulocategoria">Personales</td></tr><tr><td>
        <table class="tablacien" style="text-align: left;"><tr><td class="titulocelda">Nombres</td><td class="titulocelda">Apellido Paterno</td><td class="titulocelda">Apellido Materno</td><td class="titulocelda">Sexo</td><td class="titulocelda">Tipo de Sangre</td><td class="titulocelda">Estado Civil</td>
            <td class="titulocelda">
                <asp:UpdatePanel runat="server" ID="up_nac">
                    <ContentTemplate>
                        <asp:LinkButton runat="server" ID="lb_nacionalidad" Text="Nacionalidad" CssClass="boton_texto_dentro_negro" OnClick="lb_nacionalidad_Click"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

              </tr><tr><td class="celdascien" style="width: 33%">
            <asp:TextBox ID="tbx_1" runat="server" CssClass="tbxreg" MaxLength="50" AutoCompleteType="FirstName" Enabled="False"></asp:TextBox></td><td class="celdascien" style="width: 33%"><asp:TextBox ID="tbx_2" runat="server" CssClass="tbxreg" MaxLength="50" AutoCompleteType="LastName" Enabled="False"></asp:TextBox>
            </td><td class="celdascien" style="width: 33%"><asp:TextBox ID="tbx_3" runat="server" CssClass="tbxreg" MaxLength="50" Enabled="False"></asp:TextBox></td>
            <td class="celdascero"><asp:DropDownList ID="ddl_4" runat="server" CssClass="ddlreg" Enabled="False">
                <asp:ListItem Text="Elije uno..." Value="0"></asp:ListItem>
                <asp:ListItem Text="Masculino" Value="1"></asp:ListItem>
                <asp:ListItem Text="Femenino" Value="2"></asp:ListItem></asp:DropDownList></td>
            <td class="celdascero"><asp:DropDownList ID="ddl_5" runat="server" CssClass="ddlreg" Enabled="False">
                <asp:ListItem Text="Elije uno..." Value="0"></asp:ListItem>
                <asp:ListItem Text="O Positivo" Value="2"></asp:ListItem>
                <asp:ListItem Text="A Positivo" Value="3"></asp:ListItem>
                <asp:ListItem Text="B Positivo" Value="4"></asp:ListItem>
                <asp:ListItem Text="AB Positivo" Value="5"></asp:ListItem>

                <asp:ListItem Text="A Negativo" Value="7"></asp:ListItem>
                <asp:ListItem Text="B Negativo" Value="8"></asp:ListItem>
                <asp:ListItem Text="AB Negativo" Value="9"></asp:ListItem>
                <asp:ListItem Text="¡No lo sé!" Value="1"></asp:ListItem></asp:DropDownList></td>
            <td class="celdascero"><asp:DropDownList ID="ddl_6" runat="server" CssClass="ddlreg" Enabled="False">
                <asp:ListItem Text="Elije uno..." Value="0"></asp:ListItem>
                <asp:ListItem Text="Soltero(a)" Value="1"></asp:ListItem>
                <asp:ListItem Text="Casado(a)" Value="2"></asp:ListItem>
                <asp:ListItem Text="Divorciado(a)" Value="3"></asp:ListItem>
                <asp:ListItem Text="Viudo(a)" Value="4"></asp:ListItem>
                <asp:ListItem Text="Unión libre" Value="5"></asp:ListItem>
                </asp:DropDownList></td>
            <td class="celdascero">
               <asp:UpdatePanel runat="server" ID="up_nacionalidad" ChildrenAsTriggers="false" UpdateMode="Conditional">
                   <ContentTemplate>
                       <asp:DropDownList ID="ddl_nacionalidad" runat="server" CssClass="ddlreg" AutoPostBack="true" Enabled="False">
                        <asp:ListItem Text="Elige una..." Value="0"></asp:ListItem>
                         <asp:ListItem Text="Mexicano (a)" Value="1"></asp:ListItem>
                         <asp:ListItem Text="Extranjero (a)" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                       
                   </ContentTemplate>
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="cmd_cancelarpais" EventName="Click" />
                   </Triggers>
               </asp:UpdatePanel>
                </td>    
             </tr></table>

             <asp:RequiredFieldValidator ID="rfv_tbx_1" runat="server" ErrorMessage="¡El nombre es imprescindible!."                                         
                 Display="None" ControlToValidate="tbx_1" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_1" runat="server" TargetControlID="rfv_tbx_1" CloseImageUrl="../img/close_coe.png" 
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
             <asp:FilteredTextBoxExtender ID="ftbe_rfv_tbx_1" runat="server" TargetControlID="tbx_1" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz áéíóúÁÉÍÓÚ" />
             
             <asp:RequiredFieldValidator ID="rfv_tbx_2" runat="server" ErrorMessage="¡Ambos apellidos son necesarios!." 
                 Display="None" ControlToValidate="tbx_2" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_2" runat="server" TargetControlID="rfv_tbx_2" CloseImageUrl="../img/close_coe.png" 
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
             <asp:FilteredTextBoxExtender ID="ftbe_rfv_tbx_2" runat="server" TargetControlID="tbx_2" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz áéíóúÁÉÍÓÚ" />
             
             <asp:RequiredFieldValidator ID="rfv_tbx_3" runat="server" ErrorMessage="¡Ambos apellidos son necesarios!." 
                 Display="None" ControlToValidate="tbx_3" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_3" runat="server" TargetControlID="rfv_tbx_3" CloseImageUrl="../img/close_coe.png" 
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
             <asp:FilteredTextBoxExtender ID="ftbe_rfv_tbx_3" runat="server" TargetControlID="tbx_3" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz áéíóúÁÉÍÓÚ" />
             
             <asp:RequiredFieldValidator ID="rfv_ddl_4" runat="server" ErrorMessage="¡Selecciona tu sexo!." 
                 Display="None" ControlToValidate="ddl_4" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_4" runat="server" TargetControlID="rfv_ddl_4" CloseImageUrl="../img/close_coe.png" 
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
             
             <asp:RequiredFieldValidator ID="rfv_ddl_5" runat="server" ErrorMessage="¡El tipo de sangre es indispensable!." 
                 Display="None" ControlToValidate="ddl_5" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_5" runat="server" TargetControlID="rfv_ddl_5" CloseImageUrl="../img/close_coe.png" 
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
             
             <asp:RequiredFieldValidator ID="rfv_ddl_6" runat="server" ErrorMessage="¡Selecciona tu estado civil!." 
                 Display="None" ControlToValidate="ddl_6" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_6" runat="server" TargetControlID="rfv_ddl_6" CloseImageUrl="../img/close_coe.png" 
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
            <asp:RequiredFieldValidator ID="rfv_ddl_nacionalidad" runat="server" ErrorMessage="¡Selecciona tu nacionalidad!." 
                 Display="None" ControlToValidate="ddl_nacionalidad" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
             <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_nacionalidad" runat="server" TargetControlID="rfv_ddl_nacionalidad" CloseImageUrl="../img/close_coe.png" 
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
        </td></tr>
        <tr><td class="celdascien">
            <table class="tablacien" style="text-align: left;"><tr><td class="titulocelda">Fecha de nacimiento</td><td class="titulocelda">Lugar de nacimiento</td><td></td>
                <td>
                    <asp:UpdatePanel runat="server" ID="up_et">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lb_etnia" CssClass="boton_texto_dentro_negro" Text="Perteneces a alguna etnia" OnClick="lb_etnia_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>

                                                               </tr>
            <tr><td class="celdacero" style="vertical-align: top;">
                <table class="tablainterna" style="width: 0%; text-align: left;">
                    <tr><td class="celdascero">
                    <asp:DropDownList ID="ddl_7" runat="server" CssClass="ddlreg_short" Enabled="False">
                    <asp:ListItem Text="Año..."></asp:ListItem>
                    <asp:ListItem Text="2000"></asp:ListItem>
                    <asp:ListItem Text="1999"></asp:ListItem>
                    <asp:ListItem Text="1998"></asp:ListItem>
                    <asp:ListItem Text="1997"></asp:ListItem>
                    <asp:ListItem Text="1996"></asp:ListItem>
                    <asp:ListItem Text="1995"></asp:ListItem>
                    <asp:ListItem Text="1994"></asp:ListItem>
                    <asp:ListItem Text="1993"></asp:ListItem>
                    <asp:ListItem Text="1992"></asp:ListItem>
                    <asp:ListItem Text="1991"></asp:ListItem>
                    <asp:ListItem Text="1990"></asp:ListItem>
                    <asp:ListItem Text="1989"></asp:ListItem>
                    <asp:ListItem Text="1988"></asp:ListItem>
                    <asp:ListItem Text="1987"></asp:ListItem>
                    <asp:ListItem Text="1986"></asp:ListItem>
                    <asp:ListItem Text="1985"></asp:ListItem>
                    <asp:ListItem Text="1984"></asp:ListItem>
                    <asp:ListItem Text="1983"></asp:ListItem>
                    <asp:ListItem Text="1982"></asp:ListItem>
                    <asp:ListItem Text="1981"></asp:ListItem>
                    <asp:ListItem Text="1980"></asp:ListItem>
                    <asp:ListItem Text="1979"></asp:ListItem>
                    <asp:ListItem Text="1978"></asp:ListItem>
                    <asp:ListItem Text="1977"></asp:ListItem>
                    <asp:ListItem Text="1976"></asp:ListItem>
                    <asp:ListItem Text="1975"></asp:ListItem>
                    <asp:ListItem Text="1974"></asp:ListItem>
                    <asp:ListItem Text="1973"></asp:ListItem>
                    <asp:ListItem Text="1972"></asp:ListItem>
                    <asp:ListItem Text="1971"></asp:ListItem>
                    <asp:ListItem Text="1970"></asp:ListItem>
                    <asp:ListItem Text="1969"></asp:ListItem>
                    <asp:ListItem Text="1968"></asp:ListItem>
                    <asp:ListItem Text="1967"></asp:ListItem>
                    <asp:ListItem Text="1966"></asp:ListItem>
                    <asp:ListItem Text="1965"></asp:ListItem>
                    <asp:ListItem Text="1964"></asp:ListItem>
                    <asp:ListItem Text="1963"></asp:ListItem>
                    <asp:ListItem Text="1962"></asp:ListItem>
                    <asp:ListItem Text="1961"></asp:ListItem>
                    <asp:ListItem Text="1960"></asp:ListItem>
                    <asp:ListItem Text="1959"></asp:ListItem>
                    <asp:ListItem Text="1958"></asp:ListItem>
                    <asp:ListItem Text="1957"></asp:ListItem>
                    <asp:ListItem Text="1956"></asp:ListItem>
                    <asp:ListItem Text="1955"></asp:ListItem>
                    <asp:ListItem Text="1954"></asp:ListItem>
                    <asp:ListItem Text="1953"></asp:ListItem>
                    <asp:ListItem Text="1952"></asp:ListItem>
                    <asp:ListItem Text="1951"></asp:ListItem>
                    <asp:ListItem Text="1950"></asp:ListItem>
                    <asp:ListItem Text="1949"></asp:ListItem>
                    <asp:ListItem Text="1948"></asp:ListItem>
                    <asp:ListItem Text="1947"></asp:ListItem>
                    <asp:ListItem Text="1946"></asp:ListItem>
                    <asp:ListItem Text="1945"></asp:ListItem>
                    <asp:ListItem Text="1944"></asp:ListItem>
                    <asp:ListItem Text="1943"></asp:ListItem>
                    <asp:ListItem Text="1942"></asp:ListItem>
                    <asp:ListItem Text="1941"></asp:ListItem>
                    <asp:ListItem Text="1940"></asp:ListItem>
                  </asp:DropDownList></td>
                    <td class="celdascero"><asp:DropDownList ID="ddl_8" runat="server" CssClass="ddlreg_short" Enabled="False">
                        <asp:ListItem Text="Mes..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Enero" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Febrero" Value="02"></asp:ListItem>
                        <asp:ListItem Text="Marzo" Value="03"></asp:ListItem>
                        <asp:ListItem Text="Abril" Value="04"></asp:ListItem>
                        <asp:ListItem Text="Mayo" Value="05"></asp:ListItem>
                        <asp:ListItem Text="Junio" Value="06"></asp:ListItem>
                        <asp:ListItem Text="Julio" Value="07"></asp:ListItem>
                        <asp:ListItem Text="Agosto" Value="08"></asp:ListItem>
                        <asp:ListItem Text="Septiembre" Value="09"></asp:ListItem>
                        <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                        <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                        <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem></asp:DropDownList></td>
                    <td class="celdascero"><asp:DropDownList ID="ddl_9" runat="server" CssClass="ddlreg_short" Enabled="False">
                        <asp:ListItem Text="Dia..." Value="00"></asp:ListItem>
                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                        <asp:ListItem Text="31" Value="31"></asp:ListItem></asp:DropDownList>
                    </td></tr></table></td><td class="celdascien" style="width:100%;">
                        <table class="tablainterna" style="text-align: left;"><tr>
                            <td class="celdascien" style="width: 100%">
                                <asp:UpdatePanel ID="up_tbx_10" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                                    <asp:TextBox ID="tbx_10" runat="server" CssClass="tbxreg" ReadOnly="true" MaxLength="200" AutoCompleteType="Disabled" Enabled="False"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="ftbe_tbx_10" runat="server" TargetControlID="tbx_10" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz 1234567890,.áéíóúÁÉÍÓÚ" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gv_poblacion" EventName="RowCommand" />
                                    </Triggers></asp:UpdatePanel></td></tr></table></td>
                            <td class="celdacero"><asp:Button ID="cmd_bln" runat="server" Text="Buscar población" CssClass="botones" style="font-size: 100%;" CausesValidation="False" Enabled="False"/></td>
                            
                              <td class="celdascero">
                               <asp:UpdatePanel runat="server" ID="up_etnias" ChildrenAsTriggers="false" UpdateMode="Conditional">
                               <ContentTemplate>
                                   <asp:DropDownList ID="ddl_etnias" runat="server" CssClass="ddlreg_cien" AutoPostBack="true" Width="200px" Enabled="False">
                                    <asp:ListItem Text="Elige una opción..." Value="0"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Si" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                       
                               </ContentTemplate>
                               <Triggers>
                                   <asp:AsyncPostBackTrigger ControlID="cmd_cancelaretnia" EventName="Click" />
                               </Triggers>
                           </asp:UpdatePanel>
                                </td>    
                        </tr></table>

                    <asp:RequiredFieldValidator ID="rfv_ddl_7" runat="server" ErrorMessage="¡Dinos el año en que naciste!." 
                        Display="None" ControlToValidate="ddl_7" SetFocusOnError="True" ValidationGroup="reg" InitialValue="Año..."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_7" runat="server" TargetControlID="rfv_ddl_7" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    
                    <asp:RequiredFieldValidator ID="rfv_ddl_8" runat="server" ErrorMessage="¡Dinos el mes en que naciste!." 
                        Display="None" ControlToValidate="ddl_8" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_8" runat="server" TargetControlID="rfv_ddl_8" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    
                    <asp:RequiredFieldValidator ID="rfv_ddl_9" runat="server" ErrorMessage="¡Dinos el dia en que naciste!." 
                        Display="None" ControlToValidate="ddl_9" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_9" runat="server" TargetControlID="rfv_ddl_9" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    
                    <asp:RequiredFieldValidator ID="rfv_tbx_10" runat="server" ErrorMessage="¡Indica correctamente la poblacion en que naciste!." 
                        Display="None" ControlToValidate="tbx_10" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_10" runat="server" TargetControlID="rfv_tbx_10" CloseImageUrl="../img/close_coe.png" 
                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="rfv_ddl_etnias" runat="server" ErrorMessage="¡Selecciona una opcion!" 
                         Display="None" ControlToValidate="ddl_etnias" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
                     <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_etnias" runat="server" TargetControlID="rfv_ddl_etnias" CloseImageUrl="../img/close_coe.png" 
                         CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
            </td></tr>

        <tr><td><table class="tablacien" style="width: 100%; text-align: left;"><tr><td class="titulocelda">Dirección actual: Calle y número</td><td class="titulocelda">Código postal</td><td class="titulocelda"></td>
           <td rowspan="2" class="celdascien" style="width: 48%;">
               <asp:UpdatePanel ID="up_actuales" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                   <table class="tablacien" style="width: 100%; text-align: left;"><tr>
                          <td class="titulocelda">Colonia</td><td class="titulocelda">Ciudad</td><td class="titulocelda">Estado</td></tr>
                          <tr>            
                          <td class="celdascien" style="width: 33%;"><asp:TextBox ID="tbx_13" runat="server" CssClass="tbxreg" ReadOnly="true" MaxLength="100" AutoCompleteType="HomeState" Enabled="False"></asp:TextBox></td>
                          <td class="celdascien" style="width: 33%;"><asp:TextBox ID="tbx_14" runat="server" CssClass="tbxreg" ReadOnly="true" MaxLength="50" AutoCompleteType="HomeCity" Enabled="False"></asp:TextBox></td>
                          <td class="celdascien" style="width: 33%;"><asp:TextBox ID="tbx_15" runat="server" CssClass="tbxreg" ReadOnly="true" MaxLength="50" AutoCompleteType="HomeState" Enabled="False"></asp:TextBox></td>

                              <asp:RequiredFieldValidator ID="rfv_tbx_13" runat="server" ErrorMessage="¡Escribe tu Código Postal y pulsa el indicador para traer los datos!." 
                                  Display="None" ControlToValidate="tbx_13" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_13" runat="server" TargetControlID="rfv_tbx_13" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                            
                              <asp:RequiredFieldValidator ID="rfv_tbx_14" runat="server" ErrorMessage="¡Escribe tu Código Postal y pulsa el indicador para traer los datos!." 
                                  Display="None" ControlToValidate="tbx_14" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_14" runat="server" TargetControlID="rfv_tbx_14" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                            
                              <asp:RequiredFieldValidator ID="rfv_tbx_15" runat="server" ErrorMessage="¡Escribe tu Código Postal y pulsa el indicador para traer los datos!." 
                                  Display="None" ControlToValidate="tbx_15" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_15" runat="server" TargetControlID="rfv_tbx_15" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                  </tr></table></ContentTemplate>
                      <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="gv_cps" EventName="RowCommand" />
                      </Triggers>
                   </asp:UpdatePanel></td></tr><tr>
                          <td class="celdascien" style="width: 40%;"><asp:TextBox ID="tbx_11" runat="server" CssClass="tbxreg" MaxLength="200" AutoCompleteType="HomeStreetAddress" Enabled="False"></asp:TextBox></td>
                          <td class="celdascien" style="width: 15%;"><asp:TextBox ID="tbx_12" runat="server" CssClass="tbxreg" MaxLength="5" AutoCompleteType="HomeZipCode" Enabled="False"></asp:TextBox></td>

                                   <asp:RequiredFieldValidator ID="rfv_tbx_11" runat="server" ErrorMessage="¡Escribe tu dirección actual correctamente!." 
                                       Display="None" ControlToValidate="tbx_11" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                   <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_11" runat="server" TargetControlID="rfv_tbx_11" CloseImageUrl="../img/close_coe.png" 
                                       CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                   <asp:FilteredTextBoxExtender ID="ftbe_rfv_tbx_11" runat="server" TargetControlID="tbx_11" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz1234567890,.áéíóúÁÉÍÓÚ "/>
                                   
                                   <asp:RequiredFieldValidator ID="rfv_tbx_12" runat="server" ErrorMessage="¡Escribe tu Código Postal y pulsa el indicador para traer los datos!." 
                                       Display="None" ControlToValidate="tbx_12" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                   <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_12" runat="server" TargetControlID="rfv_tbx_12" CloseImageUrl="../img/close_coe.png" 
                                       CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                   <asp:FilteredTextBoxExtender ID="ftbe_rfv_tbx_12" runat="server" TargetControlID="tbx_12" FilterType="Numbers"/>
                                   <asp:RequiredFieldValidator ID="rfv_tbx_12_" runat="server" ErrorMessage="¡Escribe tu Código Postal y vuelve a hacer click!." 
                                       Display="None" ControlToValidate="tbx_12" SetFocusOnError="True" ValidationGroup="regcp"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_12_" runat="server" TargetControlID="rfv_tbx_12_" CloseImageUrl="../img/close_coe.png" 
                                       CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                          <td class="celdacero" style="width: 0%;"><asp:ImageButton ID="ib_bcp" runat="server" ImageUrl="../img/marker.png" ValidationGroup="regcp" Enabled="False"/></td>
               </tr></table></td></tr>

         <tr><td>
             <table class="tablacien" style="text-align: left;"><tr>
                 <td class="titulocelda">Teléfono fijo</td><td class="titulocelda">Teléfono móvil</td>
                 <td class="titulocelda">Otro teléfono</td><td class="titulocelda">Correo electónico</td>
                 <td class="titulocelda">CURP</td><td class="titulocelda">Peso (kg)</td>
                 <td class="titulocelda">Estatura (cm)</td></tr><tr>
                 <td class="celdascien" style="width: 10%"><asp:TextBox ID="tbx_16" runat="server" CssClass="tbxreg" MaxLength="10" Enabled="False"></asp:TextBox></td>
                 <td class="celdascien" style="width: 10%"><asp:TextBox ID="tbx_17" runat="server" CssClass="tbxreg" MaxLength="10" Enabled="False"></asp:TextBox></td>
                 <td class="celdascien" style="width: 10%"><asp:TextBox ID="tbx_18" runat="server" CssClass="tbxreg" MaxLength="10" Enabled="False"></asp:TextBox></td>
                 <td class="celdascien" style="width: 40%"><asp:TextBox ID="tbx_19" runat="server" CssClass="tbxreg" Enabled="False"></asp:TextBox></td>
                 <td class="celdascien" style="width: 16%"><asp:TextBox ID="tbx_20" runat="server" CssClass="tbxreg_min" Enabled="False"></asp:TextBox></td>
                 <td class="celdascien" style="width: 7%"><asp:TextBox ID="tbx_21" runat="server" CssClass="tbxreg" MaxLength="3" Enabled="False"></asp:TextBox></td>
                 <td class="celdascien" style="width: 7%"><asp:TextBox ID="tbx_22" runat="server" CssClass="tbxreg" MaxLength="3" Enabled="False"></asp:TextBox></td></tr></table>
             </td></tr>
        <tr><td class="titulocategoria">Antecedentes escolares</td></tr>
        <tr><td>
            <table class="tablacien" style="width: 100%; text-align: left;"><tr><td>Bachillerato de procedencia</td><td></td><td>Ingreso</td><td>Egreso</td><td>Promedio</td></tr>
                   <tr><td class="celdascien" style="width: 100%;">
                       
                       <asp:UpdatePanel ID="up_tbx_23" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                       <asp:TextBox ID="tbx_23" runat="server" CssClass="tbxreg" ReadOnly="true" Enabled="False"></asp:TextBox>
                       </ContentTemplate>
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="gv_escuela" EventName="RowCommand" />
                           </Triggers>
                       </asp:UpdatePanel>

                       </td>
                       <td class="celdascien"  style="width: 0%;"><asp:Button ID="cmd_besc" runat="server" Text="Buscar bachillerato" CssClass="botones" style="font-size: 100%;" CausesValidation="False" Enabled="False"/></td>
                       <td class="celdacero" style="vertical-align: top;"><table class="tablainterna" style="width: 0%; text-align: left;"><tr><td class="celdascero"><asp:DropDownList ID="ddl_24" runat="server" CssClass="ddlreg_short" Enabled="False">
                    <asp:ListItem Text="Año..." Value="0"></asp:ListItem>
                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                    <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                    <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                    <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                    <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                    <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                    <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                    <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                    <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                    <asp:ListItem Text="2003" Value="2003"></asp:ListItem>
                    <asp:ListItem Text="2002" Value="2002"></asp:ListItem>
                    <asp:ListItem Text="2001" Value="2001"></asp:ListItem>
                    <asp:ListItem Text="2000" Value="2000"></asp:ListItem>
                    <asp:ListItem Text="1999" Value="1999"></asp:ListItem>
                    <asp:ListItem Text="1998" Value="1998"></asp:ListItem>
                    <asp:ListItem Text="1997" Value="1997"></asp:ListItem>
                    <asp:ListItem Text="1996" Value="1996"></asp:ListItem>
                    <asp:ListItem Text="1995" Value="1995"></asp:ListItem>
                    <asp:ListItem Text="1994" Value="1994"></asp:ListItem>
                    <asp:ListItem Text="1993" Value="1993"></asp:ListItem>
                    <asp:ListItem Text="1992" Value="1992"></asp:ListItem>
                    <asp:ListItem Text="1991" Value="1991"></asp:ListItem>
                    <asp:ListItem Text="1990" Value="1990"></asp:ListItem>
                    <asp:ListItem Text="1989" Value="1989"></asp:ListItem>
                    <asp:ListItem Text="1988" Value="1988"></asp:ListItem>
                    <asp:ListItem Text="1987" Value="1987"></asp:ListItem>
                    <asp:ListItem Text="1986" Value="1986"></asp:ListItem>
                    <asp:ListItem Text="1985" Value="1985"></asp:ListItem>
                    <asp:ListItem Text="1984" Value="1984"></asp:ListItem>
                    <asp:ListItem Text="1983" Value="1983"></asp:ListItem>
                    <asp:ListItem Text="1982" Value="1982"></asp:ListItem>
                    <asp:ListItem Text="1981" Value="1981"></asp:ListItem>
                    <asp:ListItem Text="1980" Value="1980"></asp:ListItem>
                    <asp:ListItem Text="1979" Value="1979"></asp:ListItem>
                    <asp:ListItem Text="1978" Value="1978"></asp:ListItem>
                    <asp:ListItem Text="1977" Value="1977"></asp:ListItem>
                    <asp:ListItem Text="1976" Value="1976"></asp:ListItem>
                    <asp:ListItem Text="1975" Value="1975"></asp:ListItem>
                    <asp:ListItem Text="1974" Value="1974"></asp:ListItem>
                    <asp:ListItem Text="1973" Value="1973"></asp:ListItem>
                    <asp:ListItem Text="1972" Value="1972"></asp:ListItem>
                    <asp:ListItem Text="1971" Value="1971"></asp:ListItem>
                    <asp:ListItem Text="1970" Value="1970"></asp:ListItem>
                    </asp:DropDownList></td>
                    <td class="celdascero"><asp:DropDownList ID="ddl_25" runat="server" CssClass="ddlreg_short" Enabled="false" ValidationGroup="reg">
                        <asp:ListItem Text="Mes..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Enero" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Febrero" Value="02"></asp:ListItem>
                        <asp:ListItem Text="Marzo" Value="03"></asp:ListItem>
                        <asp:ListItem Text="Abril" Value="04"></asp:ListItem>
                        <asp:ListItem Text="Mayo" Value="05"></asp:ListItem>
                        <asp:ListItem Text="Junio" Value="06"></asp:ListItem>
                        <asp:ListItem Text="Julio" Value="07"></asp:ListItem>
                        <asp:ListItem Text="Agosto" Value="08"></asp:ListItem>
                        <asp:ListItem Text="Septiembre" Value="09"></asp:ListItem>
                        <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                        <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                        <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                        </asp:DropDownList></td>
                    </tr></table></td>
                       <td class="celdacero" style="vertical-align: top;"><table class="tablainterna" style="width: 0%; text-align: left;"><tr><td class="celdascero"><asp:DropDownList ID="ddl_26" runat="server" CssClass="ddlreg_short" ValidationGroup="reg" Enabled="False">
                    <asp:ListItem Text="Año..." Value="0"></asp:ListItem>
                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                    <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                    <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                    <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                    <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                    <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                    <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                    <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                    <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                    <asp:ListItem Text="2003" Value="2003"></asp:ListItem>
                    <asp:ListItem Text="2002" Value="2002"></asp:ListItem>
                    <asp:ListItem Text="2001" Value="2001"></asp:ListItem>
                    <asp:ListItem Text="2000" Value="2000"></asp:ListItem>
                    <asp:ListItem Text="1999" Value="1999"></asp:ListItem>
                    <asp:ListItem Text="1998" Value="1998"></asp:ListItem>
                    <asp:ListItem Text="1997" Value="1997"></asp:ListItem>
                    <asp:ListItem Text="1996" Value="1996"></asp:ListItem>
                    <asp:ListItem Text="1995" Value="1995"></asp:ListItem>
                    <asp:ListItem Text="1994" Value="1994"></asp:ListItem>
                    <asp:ListItem Text="1993" Value="1993"></asp:ListItem>
                    <asp:ListItem Text="1992" Value="1992"></asp:ListItem>
                    <asp:ListItem Text="1991" Value="1991"></asp:ListItem>
                    <asp:ListItem Text="1990" Value="1990"></asp:ListItem>
                    <asp:ListItem Text="1989" Value="1989"></asp:ListItem>
                    <asp:ListItem Text="1988" Value="1988"></asp:ListItem>
                    <asp:ListItem Text="1987" Value="1987"></asp:ListItem>
                    <asp:ListItem Text="1986" Value="1986"></asp:ListItem>
                    <asp:ListItem Text="1985" Value="1985"></asp:ListItem>
                    <asp:ListItem Text="1984" Value="1984"></asp:ListItem>
                    <asp:ListItem Text="1983" Value="1983"></asp:ListItem>
                    <asp:ListItem Text="1982" Value="1982"></asp:ListItem>
                    <asp:ListItem Text="1981" Value="1981"></asp:ListItem>
                    <asp:ListItem Text="1980" Value="1980"></asp:ListItem>
                    <asp:ListItem Text="1979" Value="1979"></asp:ListItem>
                    <asp:ListItem Text="1978" Value="1978"></asp:ListItem>
                    <asp:ListItem Text="1977" Value="1977"></asp:ListItem>
                    <asp:ListItem Text="1976" Value="1976"></asp:ListItem>
                    <asp:ListItem Text="1975" Value="1975"></asp:ListItem>
                    <asp:ListItem Text="1974" Value="1974"></asp:ListItem>
                    <asp:ListItem Text="1973" Value="1973"></asp:ListItem>
                    <asp:ListItem Text="1972" Value="1972"></asp:ListItem>
                    <asp:ListItem Text="1971" Value="1971"></asp:ListItem>
                    <asp:ListItem Text="1970" Value="1970"></asp:ListItem>
                    </asp:DropDownList></td>
                    <td class="celdascero"><asp:DropDownList ID="ddl_27" runat="server" CssClass="ddlreg_short" ValidationGroup="reg" Enabled="False">
                        <asp:ListItem Text="Mes..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Enero" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Febrero" Value="02"></asp:ListItem>
                        <asp:ListItem Text="Marzo" Value="03"></asp:ListItem>
                        <asp:ListItem Text="Abril" Value="04"></asp:ListItem>
                        <asp:ListItem Text="Mayo" Value="05"></asp:ListItem>
                        <asp:ListItem Text="Junio" Value="06"></asp:ListItem>
                        <asp:ListItem Text="Julio" Value="07"></asp:ListItem>
                        <asp:ListItem Text="Agosto" Value="08"></asp:ListItem>
                        <asp:ListItem Text="Septiembre" Value="09"></asp:ListItem>
                        <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                        <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                        <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                        </asp:DropDownList></td>
                    </tr></table></td>
                       <td class="celdascien" style="width: 0%;"><asp:TextBox ID="tbx_28" runat="server" CssClass="tbxreg" Enabled="false"></asp:TextBox></td></tr></table>
            </td></tr><tr><td>
                <table class="tablacien" style="text-align: left;"><tr>
                 
                    <td class="titulocelda">
                        <asp:UpdatePanel runat="server" ID="up_dosbachi">
                            <ContentTemplate>
                                <asp:LinkButton runat="server" ID="lb_dosbachi" Text="¿Estudiaste tu bachillerato en dos o más instituciones educativas?" CssClass="boton_texto_dentro_negro"
                                     OnClick="lb_dosbachi_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="titulocelda">
                        <asp:UpdatePanel runat="server" ID="up_extra">
                            <ContentTemplate>
                                <asp:LinkButton runat="server" ID="lb_extra" Text="Tuvo exámenes extraordinaros" CssClass="boton_texto_dentro_negro"
                                     OnClick="lb_extra_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                 <td class="titulocelda">
                      <asp:UpdatePanel runat="server" ID="up_certi">
                            <ContentTemplate>
                                <asp:LinkButton runat="server" ID="lb_certi" Text="Cuenta con certificado" CssClass="boton_texto_dentro_negro"
                                     OnClick="lb_certi_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                 </td></tr><tr>
                 
                 <td class="celdascien" style="width: 40%">
                     <asp:UpdatePanel ID="up_bachillerato" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                        <asp:DropDownList ID="ddl_74" runat="server" CssClass="ddlreg_cien" ValidationGroup="reg" AutoPostBack="true" Enabled="false">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="02"></asp:ListItem></asp:DropDownList>
                         </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="cmd_cancelarbachillerato" EventName="Click" />
                     </Triggers>
                     </asp:UpdatePanel>
                 </td>
                 <td class="celdascien" style="width: 15%">
                     <asp:UpdatePanel ID="up_extraordinario" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                     <asp:DropDownList ID="ddl_32" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" ValidationGroup="reg" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="2"></asp:ListItem></asp:DropDownList>
                     </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelarextra" EventName="Click" />
                         </Triggers>
                     </asp:UpdatePanel>
                         </td>
                 <td class="celdascien" style="width: 15%">
                     <asp:UpdatePanel ID="up_certificado" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                     <asp:DropDownList ID="ddl_33" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem></asp:DropDownList>
                     </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelarcert" EventName="Click" />
                         </Triggers>
                     </asp:UpdatePanel>
                         </td></tr></table>
            </td></tr>
       
        <tr><td>
            <table class="tablacien" style="text-align: left;"><tr><td class="titulocelda">Especialidad cursada en tu bachillerato</td><td>Tipo de Escuela</td><td>Tipo de Bachillerato</td></tr><tr><td class="celdascien">
            <asp:DropDownList ID="ddl_31" runat="server" CssClass="ddlreg_cien" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Artes graficas" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Bachillerato general" Value="02"></asp:ListItem>
                        <asp:ListItem Text="Ciencias y humanidades" Value="03"></asp:ListItem>
                        <asp:ListItem Text="Dibujo arquitectonico" Value="04"></asp:ListItem>
                        <asp:ListItem Text="Economico-adminstrativo" Value="05"></asp:ListItem>
                        <asp:ListItem Text="Electronica" Value="06"></asp:ListItem>
                        <asp:ListItem Text="Fisico-Matematico" Value="07"></asp:ListItem>
                        <asp:ListItem Text="Fundicion y maquinaria" Value="08"></asp:ListItem>
                        <asp:ListItem Text="Informatica administrativa" Value="09"></asp:ListItem>
                        <asp:ListItem Text="Instrumentacion" Value="10"></asp:ListItem>
                        <asp:ListItem Text="Laboratorio quimico" Value="11"></asp:ListItem>
                        <asp:ListItem Text="Mantenimiento de equipos de computo" Value="12"></asp:ListItem>
                        <asp:ListItem Text="Mantenimiento industrial" Value="13"></asp:ListItem>
                        <asp:ListItem Text="Manufactura de plasticos" Value="14"></asp:ListItem>
                        <asp:ListItem Text="Maquinas de combustion interna" Value="15"></asp:ListItem>
                        <asp:ListItem Text="Mecanica" Value="16"></asp:ListItem>
                        <asp:ListItem Text="Mecatronica" Value="17"></asp:ListItem>
                        <asp:ListItem Text="Nutricion" Value="18"></asp:ListItem>
                        <asp:ListItem Text="Practica docente" Value="19"></asp:ListItem>
                        <asp:ListItem Text="Profesional tecnica en refrigeracion" Value="20"></asp:ListItem>
                        <asp:ListItem Text="Programador analista" Value="21"></asp:ListItem>
                        <asp:ListItem Text="Promotor deportivo" Value="22"></asp:ListItem>
                        <asp:ListItem Text="Psicopedagogico" Value="23"></asp:ListItem>
                        <asp:ListItem Text="Quimico biologo" Value="24"></asp:ListItem>
                        <asp:ListItem Text="Quimico biologo con turismo" Value="25"></asp:ListItem>
                        <asp:ListItem Text="Quimico biologo e informatica" Value="26"></asp:ListItem>
                        <asp:ListItem Text="Quimico biologo en el area de alimentos" Value="27"></asp:ListItem>
                        <asp:ListItem Text="Recursos humanos" Value="28"></asp:ListItem>
                        <asp:ListItem Text="Relaciones humanas" Value="29"></asp:ListItem>
                        <asp:ListItem Text="Secretaria ejecutiva en español" Value="30"></asp:ListItem>
                        <asp:ListItem Text="Tecnica agropecuaria" Value="31"></asp:ListItem>
                        <asp:ListItem Text="Tecnica en computacion" Value="32"></asp:ListItem>
                        <asp:ListItem Text="Tecnica en informatica agropecuaria" Value="33"></asp:ListItem>
                        <asp:ListItem Text="Tecnico agropecuario" Value="34"></asp:ListItem>
                        <asp:ListItem Text="Tecnico electrisista industrial" Value="35"></asp:ListItem>
                        <asp:ListItem Text="Tecnico electromecanico" Value="36"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en administracion" Value="37"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en alimentos" Value="38"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en artes graficas" Value="39"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en ceramica" Value="40"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en citologia e histologia" Value="41"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en computacion" Value="42"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en computacion fiscal contable" Value="43"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en construccion urbana" Value="44"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en contablidad" Value="45"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en diseño grafico" Value="46"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en diseño y construccion" Value="47"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en electronica insdustrial" Value="48"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en enfermeria" Value="49"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en hoteleria" Value="50"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en industria del vestir" Value="51"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en maquinas y herramientas" Value="52"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en nutricion" Value="53"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en puericultura" Value="54"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en seguridad industrial" Value="55"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en trabajo social" Value="56"></asp:ListItem>
                        <asp:ListItem Text="Tecnico en turismo" Value="57"></asp:ListItem>
                        <asp:ListItem Text="Tecnico laboratosita clinico" Value="58"></asp:ListItem>
                        <asp:ListItem Text="Tecnico mecanico automotriz" Value="59"></asp:ListItem>
                        <asp:ListItem Text="Tecnico mecanico insdustrial" Value="60"></asp:ListItem>
                        <asp:ListItem Text="Tecnico produccion" Value="61"></asp:ListItem>
                        <asp:ListItem Text="Tecnico quimico industrial" Value="62"></asp:ListItem>
                        <asp:ListItem Text="Tecnico topografo" Value="63"></asp:ListItem>
                        <asp:ListItem Text="Tecnologia de los alimentos" Value="64"></asp:ListItem>
                        <asp:ListItem Text="Tecnologo en construccion" Value="65"></asp:ListItem>
                        <asp:ListItem Text="Trabajadora social" Value="66"></asp:ListItem>
                        <asp:ListItem Text="Turismo" Value="67"></asp:ListItem>
                        <asp:ListItem Text="Viveros" Value="68"></asp:ListItem>
                        <asp:ListItem Text="No aparece en la lista" Value="69"></asp:ListItem></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="ddl_29" runat="server" CssClass="ddlreg_cien" ValidationGroup="reg" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Pública" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Privada" Value="02"></asp:ListItem></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_30" runat="server" CssClass="ddlreg_cien" ValidationGroup="reg" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Técnico" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Unitario" Value="02"></asp:ListItem>
                        <asp:ListItem Text="General" Value="03"></asp:ListItem>
                        <asp:ListItem Text="Semiescolarizado" Value="04"></asp:ListItem>
                        <asp:ListItem Text="Por competencias" Value="05"></asp:ListItem></asp:DropDownList>
                </td>
                                                                                                                                                                                           </tr></table>
                </td></tr>
             <tr><td>
            <table class="tablacien" style="text-align: left;"><tr><td class="titulocelda">En el bachillerato, ¿Qué materias te gustaron más y por qué?</td><td class="titulocelda">¿Qué materias te gustaron menos y por qué?</td></tr><tr><td class="celdascien" style="width: 50%">
            <asp:TextBox ID="tbx_34" runat="server" CssClass="tbxreg" TextMode="MultiLine" Rows="5" Enabled="False"></asp:TextBox></td><td class="celdascien" style="width: 50%"><asp:TextBox ID="tbx_35" runat="server" CssClass="tbxreg" TextMode="MultiLine" Rows="5" Enabled="False"></asp:TextBox></td></tr></table>
        </td></tr>
            <tr><td>
                <table class="tablacien" style="text-align: left;">
                    <tr>
                        <td class="titulocelda" style="width:30%">
                            <asp:UpdatePanel runat="server" id="up_becas">
                                <ContentTemplate>
                                    <asp:LinkButton runat="server" ID="lb_becas" CssClass="boton_texto_dentro_negro" Text="¿Tuviste alguna beca durante tu estancia en el bachillerato?"
                                         OnClick="lb_becas_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td><td style="width:5%"></td>
                        <td class="titulocelda" style="width:60%">
                            <asp:UpdatePanel runat="server" id="up_apoyos">
                                <ContentTemplate>
                                    <asp:LinkButton runat="server" ID="lb_apoyo" CssClass="boton_texto_dentro_negro" Text="En caso de convertirte en estudiante de la UTJ, ¿consideras necesario el apoyo con una beca?"
                                         OnClick="lb_apoyo_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>

                    </tr>
                    <tr>
                        <td class="titulocelda" style="width:30%">
                            <asp:UpdatePanel runat="server" ID="up_beca" ChildrenAsTriggers="False" UpdateMode="Conditional">
                               <ContentTemplate>
                                   <asp:DropDownList runat="server" ID="ddl_beca" CssClass="ddlreg_cien" AutoPostBack="true" ValidationGroup="reg" Enabled="False">
                                    <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                               </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmd_cancelarbeca" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            
                        </td><td style="width:5%"></td>
                        <td class="titulocelda" style="width:60%">
                            <asp:UpdatePanel runat="server" ID="up_apoyo" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddl_apoyo" CssClass="ddlreg_cien" AutoPostBack="true" ValidationGroup="reg" Enabled="False">
                                    <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmd_cancelarapoyo" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        
                            </td>
                    </tr>
                </table>
                </td></tr> 
        <tr><td class="titulocategoria">Antecedentes médicos</td></tr>
        <tr><td>
            <table class="tablacien" style="text-align: left;"><tr>
                 
                <td class="titulocelda">
                    <asp:UpdatePanel runat="server" ID="up_cronic">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lb_cronicas" Text="¿Tiene algún padecimiento crónico?" CssClass="boton_texto_dentro_negro" OnClick="lb_cronicas_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                 <td class="titulocelda">
                     <asp:UpdatePanel runat="server" ID="up_psico">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lb_psico" Text="¿Recibe o ha recibido atención psicológica alguna vez en su vida?" CssClass="boton_texto_dentro_negro" OnClick="lb_psico_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </td></tr><tr>
                 
                 
                 
                 <td class="celdascien" style="width: 25%">
                     <asp:UpdatePanel ID="up_cronico" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                        <asp:DropDownList ID="ddl_39" runat="server" CssClass="ddlreg_cien" AutoPostBack="true" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="2"></asp:ListItem></asp:DropDownList>
                     </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelarcronicos" EventName="Click" />
                         </Triggers>
                     </asp:UpdatePanel>
                 </td>
                 <td class="celdascien" style="width: 30%">
                     <asp:UpdatePanel ID="up_psicologico" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>   
                        <asp:DropDownList ID="ddl_40" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="2"></asp:ListItem></asp:DropDownList>
                     </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelarpsicologicos" EventName="Click" />
                         </Triggers>
                     </asp:UpdatePanel>
                  </td></tr></table>
         </td></tr>
        <tr><td class="titulocategoria">Información adicional importante</td></tr>
        <tr><td>
            <table class="tablacien" style="text-align: left;"><tr>
                 <td class="titulocelda">
                     <asp:UpdatePanel runat="server" ID="up_hij">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lb_hijos" Text="¿Tiene hijos?" CssClass="boton_texto_dentro_negro" OnClick="lb_hijos_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </td><td class="titulocelda">
                     <asp:UpdatePanel runat="server" ID="up_zmgout">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lb_zmgout" Text="¿Vive fuera de la ZMG?" CssClass="boton_texto_dentro_negro" OnClick="lb_zmgout_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                      </td>
                 <td class="titulocelda">
                     <asp:UpdatePanel runat="server" ID="up_trabaja">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lb_trabaja" Text="¿Trabaja actualmente?" CssClass="boton_texto_dentro_negro" OnClick="lb_trabaja_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </td><td class="titulocelda">¿Busca empleo?</td>
                 <td class="titulocelda">
                     <asp:UpdatePanel runat="server" ID="up_otrauni">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lb_otrauni" Text="¿Has hecho trámites a otra Universidad?" CssClass="boton_texto_dentro_negro" OnClick="lb_otrauni_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </td>
                 </tr><tr>
                 <td class="celdascien" style="width: 20%">
                      <asp:UpdatePanel ID="up_hijos" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                        <asp:DropDownList ID="ddl_41" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="02"></asp:ListItem></asp:DropDownList>
                      </ContentTemplate>
                          <Triggers>

                              <asp:AsyncPostBackTrigger ControlID="cmd_cancelarhijos" EventName="Click" />

                          </Triggers>
                      </asp:UpdatePanel>
                 </td>
                 <td class="celdascien" style="width: 20%">
                     <asp:UpdatePanel ID="up_casa" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                        <asp:DropDownList ID="ddl_42" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="02"></asp:ListItem></asp:DropDownList>
                     </ContentTemplate>
                         <Triggers>

                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelarcasa" EventName="Click" />

                         </Triggers>
                     </asp:UpdatePanel>
                 </td>
                 <td class="celdascien" style="width: 20%">
                     <asp:UpdatePanel ID="up_labor" runat="server"><ContentTemplate>
                     <asp:DropDownList ID="ddl_43" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="02"></asp:ListItem></asp:DropDownList>
                     </ContentTemplate>
                          <Triggers>

                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelartrabajo" EventName="Click" />

                         </Triggers>
                     </asp:UpdatePanel>

                         </td>
                 <td class="celdascien" style="width: 20%"><asp:DropDownList ID="ddl_44" runat="server" CssClass="ddlreg_cien" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="01"></asp:ListItem>
                        <asp:ListItem Text="No" Value="02"></asp:ListItem></asp:DropDownList></td>
                 <td class="celdascien" style="width: 20%">
                     <asp:UpdatePanel ID="up_registro" runat="server"><ContentTemplate>
                     <asp:DropDownList ID="ddl_45" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="02"></asp:ListItem></asp:DropDownList>
                         </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelaregistro" EventName="Click" />
                         </Triggers>
                     </asp:UpdatePanel>
                         </td>
                 </tr>
                <tr>
                    <td class="titulocelda" style="padding-top:10px;">
                        <asp:UpdatePanel runat="server" ID="up_deporte">
                            <ContentTemplate>
                                <asp:LinkButton runat="server" ID="lb_deporte" Text="¿Practicas o te gustaría practicar alguna actividad deportiva o sociocultural?"
                                     CssClass="boton_texto_dentro_negro" OnClick="lb_deporte_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="celdascien">
                     <asp:UpdatePanel ID="up_deportes" runat="server"><ContentTemplate>
                     <asp:DropDownList ID="ddl_deporte" runat="server" CssClass="ddlreg_cien" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="No" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="02"></asp:ListItem></asp:DropDownList>
                         </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="cmd_cancelardeporte" EventName="Click" />
                         </Triggers>
                     </asp:UpdatePanel>
                         </td>
                </tr>
            </table>
        </td></tr>
        <tr><td>
            <%--<table class="tablacien" style="text-align: left;"><tr>
                 <td class="titulocelda" style="padding-top: 10px;">¿Cuál es la razón o razones de tu inscripción a la UTJ? (Elije al menos una)</td></tr><tr>
                 <td class="celdascien" style="width: 100%">
                     <asp:GridView runat="server" ID="gv_razon" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Left"
                          CellPadding="5" CellSpacing="5" ShowFooter="false" ShowHeader="false">
                         <AlternatingRowStyle  CssClass="gvrow_alt"/>
                         <Columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <div style="text-align:left">
                                         <asp:HiddenField  runat="server" ID="hf_id" Value='<%# DataBinder.Eval(Container.DataItem, "id")%>'/>
                                         <asp:CheckBox runat="server" id="cbx_razon" Text='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>' />
                                     </div>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                    <<div style="padding:20px 0 0 0">
                             <asp:DataList runat="server" ID="dl_razon" RepeatColumns="2" Enabled="false">
                                <ItemTemplate>
                                    <div style="text-align:left; padding:0 30px 0 0; color:#b30430">
                                                 <asp:HiddenField  runat="server" ID="hf_id" Value='<%# DataBinder.Eval(Container.DataItem, "id_motivo_inscripcion")%>'/>
                                                 <asp:CheckBox runat="server" id="cbx_select" Text='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>' 
                                                     Checked='<%# DataBinder.Eval(Container.DataItem, "seleccionado")%>' />
                                             </div>
                                </ItemTemplate>
                             </asp:DataList>
                     </div>--%>
                 </td></tr></table>
        </td></tr>
        <tr><td>

            <%--<table class="tablacien" style="text-align: left;"><tr>
                 <td class="titulocelda" style="padding-top: 10px;">¿De qué forma te enteraste de la UTJ? (Elije al menos una)</td></tr><tr>
                 <td class="celdascien" style="width: 100%">
                      <asp:GridView runat="server" ID="gv_medios" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Left"
                          CellPadding="5" CellSpacing="5" ShowFooter="false" ShowHeader="false">
                         <AlternatingRowStyle  CssClass="gvrow_alt"/>
                         <Columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <div style="text-align:left">
                                         <asp:HiddenField  runat="server" ID="hf_id" Value='<%# DataBinder.Eval(Container.DataItem, "id")%>'/>
                                         <asp:CheckBox runat="server" id="cbx_razon" Text='<%# DataBinder.Eval(Container.DataItem, "medio")%>' />
                                     </div>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                     <div style="padding:20px 0 0 0"></div>
                      <asp:DataList runat="server" ID="dl_medios" RepeatColumns="2" Enabled="false">
                        <ItemTemplate>
                            <div style="text-align:left; padding:0 65px 0 0; color:#b30430">
                                         <asp:HiddenField  runat="server" ID="hf_id" Value='<%# DataBinder.Eval(Container.DataItem, "id_medio")%>'/>
                                         <asp:CheckBox runat="server" id="cbx_select" Text='<%# DataBinder.Eval(Container.DataItem, "medio")%>'
                                              Checked='<%# DataBinder.Eval(Container.DataItem, "seleccionado")%>' />
                                     </div>
                        </ItemTemplate>
                     </asp:DataList>
                 </td></tr></table>--%>

        </td></tr>
            <tr><td>
                 <table class="tablacien" style="text-align: left;"><tr>
                 <td class="titulocelda" style="padding-top: 10px;">FACTORES DE VULNERABILIDAD PARA SU INGRESO A LA UTJ O BIEN, PARA SU PERMANENCIA COMO ALUMNO (ELIJE AL MENOS UNA)</td></tr><tr>
                 <td class="celdascien" style="width: 100%">
                    
                                       
                       <asp:GridView runat="server" ID="gv_cat1" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Left"
                        CellSpacing="5" CellPadding="10" ShowFooter="false" ShowHeader="false" >
                        <AlternatingRowStyle CssClass="gvrow_alt" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div style="text-align:left">
                                        <asp:HiddenField runat="server" ID="hf_id" Value='<%# DataBinder.Eval(Container.DataItem, "id")%>' />
                                        <asp:CheckBox runat="server" ID="cbx_seleccionado" Text='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>'
                                             Checked='<%# DataBinder.Eval(Container.DataItem, "seleccionado")%>' />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 </td></tr></table>
                </td></tr>
            <tr><td class="titulocelda">OBSERVACIONES <br />
                <asp:TextBox runat="server" ID="tbx_observaciones" CssClass="tbxreg" Rows="3" TextMode="MultiLine"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="rfv_tbx_observaciones" ErrorMessage="Debes indicarnos tus observaciones!" Display="None"
                                             ControlToValidate="tbx_observaciones" SetFocusOnError="true" ValidationGroup="ntrvwr" ></asp:RequiredFieldValidator>
                                         <asp:ValidatorCalloutExtender runat="server" ID="vcoe_observaciones" TargetControlID="rfv_tbx_observaciones" CloseImageUrl="~/img/close_coe.png"
                                             CssClass="customCalloutStyle" WarningIconImageUrl="~/img/alert_yel.png" Enabled="true"></asp:ValidatorCalloutExtender>
                 <table class="tablacien" style="text-align: left;">
                     <tr>
                         <td class="titulocelda" style="padding-top: 10px;">CONCLUSION(ELIJE AL MENOS UNA)</td>
                     </tr>
                     <tr>
                         <td class="celdascien" style="width: 100%">
                             <asp:GridView ID="gv_cat2" runat="server" AutoGenerateColumns="false" CellPadding="10" CellSpacing="5" GridLines="None" HorizontalAlign="Left" RowStyle-CssClass="gvrow" ShowFooter="false" ShowHeader="false">
                                 <AlternatingRowStyle CssClass="gvrow_alt" />
                                 <Columns>
                                     <asp:TemplateField>
                                         <ItemTemplate>
                                             <div style="text-align:left">
                                                 <asp:HiddenField ID="hf_id" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id")%>' />
                                                 <asp:CheckBox ID="cbx_seleccionado" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "seleccionado")%>' Text='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>' />
                                             </div>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                         </td>
                     </tr>
                </table>
                 
                 </td></tr> 
       
            <tr><td>
                &nbsp;</td></tr>
            <tr><td class="tituloceldaNegrita">INFORMACION ADICIONAL IMPORTANTE</td></tr>
            <tr><td>
                  <table class="tablacien" style="text-align: left;"><tr>
                 <td class="titulocelda" style="padding-top: 10px;"></td></tr><tr>
                 <td class="celdascien" style="width: 100%">
                     <asp:GridView runat="server" ID="gv_cat3" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Left"
                        CellSpacing="5" CellPadding="10" ShowFooter="false" ShowHeader="false" >
                        <AlternatingRowStyle CssClass="gvrow_alt" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div style="text-align:left">
                                        <asp:HiddenField runat="server" ID="hf_id" Value='<%# DataBinder.Eval(Container.DataItem, "id")%>' />
                                        <asp:CheckBox runat="server" ID="cbx_seleccionado" Text='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>'
                                             Checked='<%# DataBinder.Eval(Container.DataItem, "seleccionado")%>' />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 </td></tr></table>
                </td></tr>
                        <asp:HiddenField runat="server" id="hf_nombre" />
             <tr><td class="tituloceldaNegrita">ENTREVISTO: <asp:Label runat="server" ID="lbl_entrevisto"></asp:Label> </td></tr>
        <%--<tr><td class="titulocategoria">Cita para tu entrevista</td></tr>
        <tr><td class="titulocelda">El siguiente paso para tu registro es tu entrevista en la UTJ. Elije primero el día y después la hora disponible para que asistas.</td></tr>
        <tr><td>
            <asp:UpdatePanel ID="up_calendario" runat="server" UpdateMode="Conditional"><ContentTemplate>
            <div><table><tr><td style="font-size: 1.0em; border-radius: 4px;" class="calendarWrapper">
            <asp:calendar ID="cal_48" runat="server" CssClass="calendario" 
                ShowNextPrevMonth="True" NextPrevFormat="FullMonth" NextPrevStyle-ForeColor="Yellow">
                <TitleStyle CssClass="titulo_calendario" />
                <DayHeaderStyle CssClass="nombredias_calendario"/>
                <DayStyle CssClass="dias_calendario"/>
                <OtherMonthDayStyle CssClass="otrosdias_calendario"/>
                <SelectedDayStyle BackColor="#b30430"/>
                <SelectorStyle CssClass="selector_calendario"/>
                <TodayDayStyle CssClass="today_calendario"/>
                <NextPrevStyle CssClass="nextback_calendario"/>
            </asp:calendar></td>
            <td style="font-size: 1.2em; padding-left: 10px;"><asp:RadioButtonList ID="rbl_49" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" ValidationGroup="reg" CellPadding="4" CellSpacing="4"></asp:RadioButtonList></td></tr>
            </table></div>
            </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cal_48" EventName="SelectionChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_carreras" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
         </td></tr>--%>
       <%-- <tr><td><table><tr><td style="padding: 10px;">
            <asp:Button ID="Button1" runat="server" Text="Guardar Registro" CssClass="botones" style="font-size: 100%;" OnClientClick="bPreguntar = false;" ValidationGroup="reg"/>
            </td><td style="padding: 10px;">
            <asp:Button ID="cmd_cancelar" runat="server" Text="Cancelar" CssClass="botones" style="font-size: 100%;" CausesValidation="False"/>
        </td></tr></table></td></tr>--%>
        <tr><td>
            <asp:HiddenField ID="hf_popupo" runat="server" />
            <asp:HiddenField ID="hf_popupok" runat="server" />
            <asp:ModalPopupExtender ID="hf_popupo_mpe" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_popupo" PopupControlID="p_test" BackgroundCssClass="modalBackground_gris" CancelControlID="ib_close">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="hf_popupok_mpe" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="hf_popupok" PopupControlID="p_registrok" BackgroundCssClass="modalBackground_gris" CancelControlID="">
            </asp:ModalPopupExtender>
        </td></tr>
        <tr><td>
            <asp:UpdatePanel ID="p_test" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
            <asp:Panel ID="p_mensajes" runat="server" style="display: table">
             <table style="width: 100%;"><tr><td style="text-align: right; padding: 5px;"><asp:ImageButton ID="ib_close" runat="server" ImageUrl="../img/close_coe.png" /></td></tr><tr><td>
              <asp:UpdatePanel ID="up_mensajes" runat="server"><ContentTemplate>
                <asp:MultiView ID="mv_msgs" runat="server">
                  <asp:View ID="v_poblacion" runat="server">
                      <table class="popupmsg"><tr><td id="pad">Ingresa el nombre completo o parte de él o código postal de la población en donde naciste, haz click en buscar para encontrar coincidencias.<br />
                                     Al encontrar la población haz click en ella para enviarla a tu solicitud.
                                 </td></tr><tr><td id="Td1">
                                     <asp:Panel ID="p_busqueda1" runat="server" DefaultButton="cmd_buscar_poblacion"><table style="width: 100%"><tr><td id="Td2" style="width: 100%;"><asp:TextBox ID="tbx_50" runat="server" CssClass="tbxreg" ValidationGroup="bln" Enabled="False"></asp:TextBox></td><td id="Td3">
                                         <asp:Button ID="cmd_buscar_poblacion" runat="server" CssClass="botones" Text="Buscar población" style="font-size: 100%;" ValidationGroup="bln" Enabled="False" />
                                     </td></tr></table></asp:Panel>
                                      </td></tr><tr><td id="Td4"><div style="overflow-x:hidden;overflow-y:scroll;max-height:400px">

                                          <asp:RequiredFieldValidator ID="rfv_tbx_50" runat="server" ErrorMessage="¡Es necesario escribir algo!." 
                                              Display="None" ControlToValidate="tbx_50" SetFocusOnError="True" ValidationGroup="bln"></asp:RequiredFieldValidator>
                                          <asp:ValidatorCalloutExtender ID="vco_tbx_50" runat="server" TargetControlID="rfv_tbx_50" CloseImageUrl="../img/close_coe.png" 
                                              CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                        
                                          <asp:GridView ID="gv_poblacion" runat="server" EmptyDataText=":( En este momento no hay resultados, intentalo." 
                                              EmptyDataRowStyle-CssClass="triste" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" HorizontalAlign="left"
                                              OnRowCommand="gv_poblacion_RowCommand" style="margin-left: 20px;">
                                          <Columns>
                                              <asp:TemplateField><ItemTemplate><table style="border-collapse: collapse; margin-left:10px;"><tr><td style="padding: 0px;">
                                              <asp:LinkButton ID="lb_select" runat="server" CssClass="boton_texto_dentroblanco" 
                                               CommandArgument='<%# DataBinder.Eval(Container.DataItem, "fullpoblacion")%>'
                                               Text='<%# DataBinder.Eval(Container.DataItem, "fullpoblacion")%>'></asp:LinkButton></td></tr></table>
                                              </ItemTemplate></asp:TemplateField>
                                          </Columns>
                                      </asp:GridView></div>
                       </td></tr></table>
                  </asp:View>

                  <asp:View ID="v_buscarcp" runat="server">
                      <table class="popupmsg"><tr><td id="Td5">Al encontrar la población, haz click en ella para llenar los campos de Colonia, Ciudad y Estado.
                                 </td></tr>
                         
                              <tr>
                                  <td id="Td6">
                                      <div style="overflow-x:hidden;overflow-y:scroll;max-height:400px">
                                          <asp:GridView ID="gv_cps" runat="server" AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="triste" EmptyDataText=":( No se encontraron resultados con el código postal escrito. Intenta de nuevo con uno válido." GridLines="None" HorizontalAlign="left" OnRowCommand="gv_cps_RowCommand" ShowHeader="False" style="margin-left: 20px;">
                                              <Columns>
                                                  <asp:TemplateField>
                                                      <ItemTemplate>
                                                          <table style="border-collapse: collapse; margin-left:10px;">
                                                              <tr>
                                                                  <td style="padding: 0px;">
                                                                      <asp:LinkButton ID="lb_select" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' CssClass="boton_texto_dentroblanco" Text='<%# DataBinder.Eval(Container.DataItem, "fullpoblacion")%>'></asp:LinkButton>
                                                                  </td>
                                                              </tr>
                                                          </table>
                                                      </ItemTemplate>
                                                  </asp:TemplateField>
                                              </Columns>
                                          </asp:GridView>
                                      </div>
                                  </td>
                              </tr>
                          
                      </table>
                  </asp:View>

                    <asp:View ID="v_escuela" runat="server">
                      <table class="popupmsg"><tr><td id="Td7">Ingresa parte del nombre la preparatoria donde estudiaste.<br />
                                     Al encontrarla haz click en ella para enviarla a tu solicitud.
                                 </td></tr><tr><td id="Td8">
                                     <asp:Panel ID="p_buscar_escuela" runat="server" DefaultButton="cmd_buscar_escuela"><table style="width: 100%"><tr><td id="Td9" style="width: 100%;"><asp:TextBox ID="tbx_bescuela" runat="server" CssClass="tbxreg" ValidationGroup="bes" Enabled="False"></asp:TextBox></td><td id="Td10">
                                         <asp:Button ID="cmd_buscar_escuela" runat="server" CssClass="botones" Text="Buscar preparatoria" style="font-size: 100%;" ValidationGroup="bes" Enabled="False" />
                                     </td></tr></table></asp:Panel>
                                      </td></tr><tr><td id="Td11"><div style="overflow-x:hidden;overflow-y:scroll;max-height:400px">

                                          <asp:RequiredFieldValidator ID="rfv_tbx_bescuela" runat="server" ErrorMessage="¡Es necesario escribir algo!." 
                                              Display="None" ControlToValidate="tbx_bescuela" SetFocusOnError="True" ValidationGroup="bes"></asp:RequiredFieldValidator>
                                          <asp:ValidatorCalloutExtender ID="vcoe_tbx_bescuela" runat="server" TargetControlID="rfv_tbx_bescuela" CloseImageUrl="../img/close_coe.png" 
                                              CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                        
                                          <asp:GridView ID="gv_escuela" runat="server" EmptyDataText=":( En este momento no hay resultados, intentalo." 
                                              EmptyDataRowStyle-CssClass="triste" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" HorizontalAlign="left"
                                              OnRowCommand="gv_escuela_RowCommand" style="margin-left: 20px;">
                                          <Columns>
                                              <asp:TemplateField><ItemTemplate><table style="border-collapse: collapse; margin-left:10px;"><tr><td style="padding: 0px;">
                                              <asp:LinkButton ID="lb_select" runat="server" CssClass="boton_texto_dentroblanco" 
                                               CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'
                                               Text='<%# DataBinder.Eval(Container.DataItem, "nombre_ct")%>'></asp:LinkButton></td></tr></table>
                                              </ItemTemplate></asp:TemplateField>
                                          </Columns>
                                      </asp:GridView></div>
                       </td></tr></table>
                  </asp:View>

                    <asp:View ID="v_extraordinarios" runat="server">
                      <table class="popupmsg"><tr><td id="Td12">Referente a los examenes extraordinarios contesta lo siguiente.<br />
                                     (Haz click en Guardar y seguir para finalizar)
                                 </td></tr><tr><td id="Td13">
                                     <asp:Panel ID="p_extraordinarios" runat="server" DefaultButton="cmd_extraordinarios">
                                         <table style="width: 100%"><tr><td style="width: 20%;">
                                             ¿Cuántos extraordinarios tuviste?</td><td style="width: 40%;">
                                                 ¿De qué materia fueron los extraordinarios?</td><td style="width: 40%;">
                                                     ¿Por qué motivo reprobaste e hiciste el extraordinario?</td></tr><tr>
                                         <td id="Td14" style="width: 20%;">
                                             <asp:TextBox ID="tbx_51" runat="server" CssClass="tbxreg" ValidationGroup="gext" Enabled="False"></asp:TextBox></td>
                                             <td id="Td15" style="width: 40%;">
                                                 <asp:TextBox ID="tbx_52" runat="server" CssClass="tbxreg" ValidationGroup="gext" Enabled="False"></asp:TextBox></td>
                                                     <td id="Td16" style="width: 40%;">
                                                         <asp:TextBox ID="tbx_53" runat="server" CssClass="tbxreg" ValidationGroup="gext" Enabled="False"></asp:TextBox></td></tr><tr><td colspan="3" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td17">
                                             <asp:Button ID="cmd_extraordinarios" runat="server" CssClass="botones" Text="Guardar y seguir" style="font-size: 100%;" ValidationGroup="gext" Enabled="False" />
                                             </td><td id="Td18">
                                             <asp:Button ID="cmd_cancelarextra" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                                        </td></tr></table>
                                     </asp:Panel>
                              <asp:RequiredFieldValidator ID="rfv_tbx_51" runat="server" ErrorMessage="¡Indica en cuantos extraordinarios caíste!." 
                                  Display="None" ControlToValidate="tbx_51" SetFocusOnError="True" ValidationGroup="gext"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_51" runat="server" TargetControlID="rfv_tbx_51" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                              <asp:FilteredTextBoxExtender ID="ftbe_rfv_tbx_51" runat="server" TargetControlID="tbx_51" FilterType="Numbers" />
                              
                              <asp:RequiredFieldValidator ID="rfv_tbx_52" runat="server" ErrorMessage="¿Por cuales materias fueron los extraordinarios?." 
                                  Display="None" ControlToValidate="tbx_52" SetFocusOnError="True" ValidationGroup="gext"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_52" runat="server" TargetControlID="rfv_tbx_52" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                                            
                              <asp:RequiredFieldValidator ID="rfv_tbx_53" runat="server" ErrorMessage="¿Cuál fue el motivo por el que no aprobaste las materias en ordinario?." 
                                  Display="None" ControlToValidate="tbx_53" SetFocusOnError="True" ValidationGroup="gext"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_53" runat="server" TargetControlID="rfv_tbx_53" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                       </td></tr></table>
                  </asp:View>

                    <asp:View ID="v_certificado" runat="server">
                      <table class="popupmsg"><tr><td id="Td19">Referente a la falta de tu certificado contesta lo siguiente.<br />
                                     (Haz click en guardar para finalizar)
                                 </td></tr><tr><td id="Td20">
                                     <asp:Panel ID="p_certificado" runat="server" DefaultButton="cmd_certificado">
                                         <table style="width: 100%"><tr><td style="width: 80%;">
                                             ¿Por que no cuentas con el certificado?</td><td style="width: 10%;"></td><td style="width: 10%;"></td></tr><tr>
                                         <td id="Td21" style="width: 80%;">
                                             <asp:TextBox ID="tbx_54" runat="server" CssClass="tbxreg" ValidationGroup="cext" Enabled="False"></asp:TextBox></td>
                                             <td id="Td22" style="width: 10%;">
                                                 <asp:Button ID="cmd_certificado" runat="server" CssClass="botones" Text="Guardar" style="font-size: 100%;" ValidationGroup="cext" Enabled="False" />
                                             </td><td id="Td23" style="width: 10%;">
                                                 <asp:Button ID="cmd_cancelarcert" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false" EnableTheming="False"/>
                                          </td></tr></table>
                                     </asp:Panel>
                              <asp:RequiredFieldValidator ID="rfv_tbx_54" runat="server" ErrorMessage="Por favor escribe una razón por la cual no tengas el certificado." 
                                  Display="None" ControlToValidate="tbx_54" SetFocusOnError="True" ValidationGroup="cext"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_54" runat="server" TargetControlID="rfv_tbx_54" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                       </td></tr></table>
                  </asp:View>

                  <asp:View ID="v_cronico" runat="server">
                   <table class="popupmsg">
                       <tr><td id="Td24">Referente a los padecimientos cronicos.</td></tr>
                       <tr><td id="Td25">
                           <asp:Panel runat="server" ID="p_cronicos" DefaultButton="cmd_cronicos" style="width:100%;">
                               <table style="width:100%;">
                                   <tr>
                                       <td id="Td26" style="width:60%; white-space:nowrap">¿Qué enfermedad padeces?</td>
                                       <td id="Td27" style="width:40%; white-space:nowrap">¿Recibes algún tratamiento?</td>
                                   </tr>
                                   <tr>
                                       <td id="Td28" style="width:60%; white-space:nowrap">
                                           <asp:DropDownList runat="server" ID="ddl_cronicas" CssClass="ddlreg_cien" AutoPostBack="true" ValidationGroup="cronicos" Enabled="False"></asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="rfv_ddl_cronicas" runat="server" ErrorMessage="Selecciona una enfermedad!" 
                                              Display="None" ControlToValidate="ddl_cronicas" SetFocusOnError="True" ValidationGroup="cronicos" InitialValue="0"></asp:RequiredFieldValidator>
                                          <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_cornicas" runat="server" TargetControlID="rfv_ddl_cronicas" CloseImageUrl="../img/close_coe.png" 
                                              CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                       </td>
                                       <td id="Td29" style="width:40%; white-space:nowrap">
                                           <asp:DropDownList runat="server" ID="ddl_tratamiento" CssClass="ddlreg_cien" AutoPostBack="true" ValidationGroup="cronicos" Enabled="False">
                                               <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                               <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                               <asp:ListItem Text="Si" Value="2"></asp:ListItem>
                                           </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_tratamiento" runat="server" ErrorMessage="¿Recibes tratamiento?" 
                                              Display="None" ControlToValidate="ddl_tratamiento" SetFocusOnError="True" ValidationGroup="cronicos" InitialValue="0"></asp:RequiredFieldValidator>
                                          <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_tratamiento" runat="server" TargetControlID="rfv_ddl_tratamiento" CloseImageUrl="../img/close_coe.png" 
                                              CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                       </td>
                                   </tr>
                                    <tr>
                                       <td id="Td30" style="width:60%; white-space:nowrap">
                                           <asp:Label runat="server" ID="lbl_otra" Text="¿Cúal?"></asp:Label>
                                       </td>
                                       <td id="Td31" style="width:40%; white-space:nowrap">
                                           <asp:Label runat="server" ID="lbl_tratamiento" Text="¿Qué tratamiento recibes?"></asp:Label>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td id="Td32" style="width:60%; white-space:nowrap">
                                           <asp:TextBox runat="server" ID="tbx_otra" CssClass="tbxreg" ValidationGroup="cronicos" Enabled="False"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="rfv_tbx_otra" runat="server" ErrorMessage="Especifica cual!" 
                                              Display="None" ControlToValidate="tbx_otra" SetFocusOnError="True" ValidationGroup="cronicos"></asp:RequiredFieldValidator>
                                          <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_otra" runat="server" TargetControlID="rfv_tbx_otra" CloseImageUrl="../img/close_coe.png" 
                                              CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                       </td>
                                       <td id="Td33" style="width:40%; white-space:nowrap">
                                           <asp:TextBox runat="server" ID="tbx_tratamiento" CssClass="tbxreg" ValidationGroup="cronicos" Enabled="False"></asp:TextBox>               
                                           <asp:RequiredFieldValidator ID="rfv_tbx_tratamiento" runat="server" ErrorMessage="¿Qué tratamiento recibes?" 
                                              Display="None" ControlToValidate="tbx_tratamiento" SetFocusOnError="True" ValidationGroup="cronicos"></asp:RequiredFieldValidator>
                                          <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_tratamiento" runat="server" TargetControlID="rfv_tbx_tratamiento" CloseImageUrl="../img/close_coe.png" 
                                              CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td colspan="2" style="text-align: center;">
                                             <table style="margin: auto;">
                                                 <tr>
                                                     <td id="Td34">
                                                        <asp:Button ID="cmd_cronicos" runat="server" CssClass="botones" Text="Guardar" style="font-size: 100%;" ValidationGroup="cronicos" Enabled="False" />
                                                </td>
                                                     <td id="Td35">
                                                        <asp:Button ID="cmd_cancelarcronicos" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false" EnableTheming="True"/>
                                                    </td></tr></table>
                                         </td></tr>
                               </table>
                           </asp:Panel>
                           <%--<asp:RequiredFieldValidator ID="rfv_ddl_cronicas" runat="server" ErrorMessage="Selecciona tu enfermadad." 
                                  Display="None" ControlToValidate="ddl_cronicas" SetFocusOnError="True" ValidationGroup="cronicos" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_cronicas" runat="server" TargetControlID="rfv_ddl_cronicas" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                            <asp:RequiredFieldValidator ID="rfv_ddl_tratamiento" runat="server" ErrorMessage="Indica si recibes o no tratamiento." 
                                  Display="None" ControlToValidate="ddl_tratamienyo" SetFocusOnError="True" ValidationGroup="cronicos" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_tratamiento" runat="server" TargetControlID="rfv_ddl_tratamiento" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                           <asp:RequiredFieldValidator ID="rfv_tbx_otra" runat="server" ErrorMessage="Indica el tipo de enfermedad que padeces." 
                                  Display="None" ControlToValidate="tbx_otra" SetFocusOnError="True" ValidationGroup="psico"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_otra" runat="server" TargetControlID="rfv_tbx_otra" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>
                           </td></tr>
                   </table>

                      
                  </asp:View>

                    <asp:View ID="v_psicologicos" runat="server">
                      <table class="popupmsg"><tr><td id="Td36">Referente a la atención Psicológica.
                                 </td></tr><tr><td id="Td37">
                                     <asp:Panel ID="p_psicologicos" runat="server" DefaultButton="cmd_psicologicos" style="width: 100%;">
                                         <table style="width: 100%"><tr><td id="Td38" style="width: 60%; white-space: nowrap">
                                             ¿Qué tipo de atención recibe actualmente o recibió alguna vez?</td><td id="Td39" style="width: 40%; white-space: nowrap">
                                                 ¿Hace cuánto tiempo?</td></tr><tr>
                                         <td id="Td40" style="width: 60%;">
                                             <asp:TextBox ID="tbx_57" runat="server" CssClass="tbxreg" ValidationGroup="psico" Enabled="False"></asp:TextBox></td>
                                             <td id="Td41" style="width: 40%;">
                                                 <asp:DropDownList ID="ddl_58" runat="server" CssClass="ddlreg_cien" ValidationGroup="psico" Enabled="False">
                                                   <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                   <asp:ListItem Text="Actualmente" Value="01"></asp:ListItem>
                                                   <asp:ListItem Text="Entre 3 y 12 meses" Value="02"></asp:ListItem>
                                                   <asp:ListItem Text="Hace más de 1 año" Value="03"></asp:ListItem>
                                                   <asp:ListItem Text="Hace más de 5 años" Value="04"></asp:ListItem> 
                                                 </asp:DropDownList>
                                             </td></tr><tr><td colspan="2" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td42">
                                             <asp:Button ID="cmd_psicologicos" runat="server" CssClass="botones" Text="Guardar" style="font-size: 100%;" ValidationGroup="psico" Enabled="False" />
                                             </td><td id="Td43">
                                             <asp:Button ID="cmd_cancelarpsicologicos" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr></table>
                                     </asp:Panel>
                              <asp:RequiredFieldValidator ID="rfv_tbx_57" runat="server" ErrorMessage="Indica el tipo de tratamiento psicológico." 
                                  Display="None" ControlToValidate="tbx_57" SetFocusOnError="True" ValidationGroup="psico"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_57" runat="server" TargetControlID="rfv_tbx_57" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                              
                              <asp:RequiredFieldValidator ID="rfv_ddl_58" runat="server" ErrorMessage="Selecciona el tiempo que llevas con el tratamiento." 
                                  Display="None" ControlToValidate="ddl_58" SetFocusOnError="True" ValidationGroup="psico" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_58" runat="server" TargetControlID="rfv_ddl_58" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                       </td></tr></table>
                  </asp:View>

                    <asp:View ID="v_hijos" runat="server">
                      <table class="popupmsg"><tr><td id="Td44">Referente a los hijos...
                                 </td></tr><tr><td id="Td45">
                                     <asp:Panel ID="p_hijos" runat="server" DefaultButton="cmd_hijos">
                                         <table style="width: 100%"><tr><td id="Td46" style="width: 30%; white-space: nowrap">
                                             ¿Cuantos hijos tiene?</td><td id="Td47" style="width: 70%; white-space: nowrap">
                                                 Escriba sus edades.<br />Separe con una coma en caso de que sean más de uno.</td></tr><tr>
                                         <td id="Td48" style="width: 30%;">
                                             <asp:DropDownList ID="ddl_59" runat="server" CssClass="ddlreg_cien" ValidationGroup="hijos" Enabled="False">
                                                   <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                   <asp:ListItem Text="1" Value="01"></asp:ListItem>
                                                   <asp:ListItem Text="2" Value="02"></asp:ListItem>
                                                   <asp:ListItem Text="3" Value="03"></asp:ListItem>
                                                   <asp:ListItem Text="4" Value="04"></asp:ListItem> 
                                                   <asp:ListItem Text="5" Value="05"></asp:ListItem>
                                                   <asp:ListItem Text="6" Value="06"></asp:ListItem>
                                                   <asp:ListItem Text="7" Value="07"></asp:ListItem>
                                                   <asp:ListItem Text="8" Value="08"></asp:ListItem>
                                                   <asp:ListItem Text="Más de 8...?" Value="09"></asp:ListItem>
                                             </asp:DropDownList></td>
                                             <td id="Td49" style="width: 70%;">
                                                 <asp:TextBox ID="tbx_60" runat="server" CssClass="tbxreg" ValidationGroup="hijos" Enabled="False"></asp:TextBox></td>
                                             </tr><tr><td colspan="2" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td50">
                                             <asp:Button ID="cmd_hijos" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="hijos" />
                                             </td><td id="Td51">
                                             <asp:Button ID="cmd_cancelarhijos" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr></table>
                                     </asp:Panel>
                              <asp:RequiredFieldValidator ID="rfv_tbx_60" runat="server" ErrorMessage="Por favor escriba las edades de sus hijos." 
                                  Display="None" ControlToValidate="tbx_60" SetFocusOnError="True" ValidationGroup="hijos"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_60" runat="server" TargetControlID="rfv_tbx_60" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                              
                              <asp:RequiredFieldValidator ID="rfv_ddl_59" runat="server" ErrorMessage="Selecciona la cantidad de hijos." 
                                  Display="None" ControlToValidate="ddl_59" SetFocusOnError="True" ValidationGroup="hijos" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_59" runat="server" TargetControlID="rfv_ddl_59" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                       </td></tr></table>
                  </asp:View>

                  <asp:View ID="v_casa" runat="server">
                      <table class="popupmsg"><tr><td id="Td52">Referente a tu domicilio fuera la ZMG...
                                 </td></tr><tr><td id="Td53">
                                     <asp:Panel ID="p_casa" runat="server" DefaultButton="cmd_casa">
                                         <table style="width: 100%"><tr><td id="Td54" style="width: 100%;">
                                             Al ingresar a la UTJ, tu domicilio será...</td></tr><tr>
                                         <td id="Td55" style="width: 100%;">
                                             <asp:DropDownList ID="ddl_61" runat="server" CssClass="ddlreg_cien" ValidationGroup="casa" Enabled="False">
                                                   <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                   <asp:ListItem Text="Casa propia" Value="01"></asp:ListItem>
                                                   <asp:ListItem Text="Casa rentada" Value="02"></asp:ListItem>
                                                   <asp:ListItem Text="Con familiares" Value="03"></asp:ListItem>
                                                   <asp:ListItem Text="Con amigos" Value="04"></asp:ListItem>
                                                   <asp:ListItem Text="El actual (fuera de la ZMG)" Value="05"></asp:ListItem> 
                                                   <asp:ListItem Text="No lo he pensado" Value="06"></asp:ListItem>
                                             </asp:DropDownList>
                                             </td></tr><tr><td colspan="2" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td56">
                                             <asp:Button ID="cmd_casa" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="casa" Enabled="False" />
                                             </td><td id="Td57">
                                             <asp:Button ID="cmd_cancelarcasa" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr></table>
                                     </asp:Panel>
                              <asp:RequiredFieldValidator ID="rfv_ddl_61" runat="server" ErrorMessage="Elija el tipo de vivienda." 
                                  Display="None" ControlToValidate="ddl_61" SetFocusOnError="True" ValidationGroup="casa" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_61" runat="server" TargetControlID="rfv_ddl_61" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                       </td></tr></table>
                  </asp:View>

                  <asp:View ID="v_trabajo" runat="server">
                      <table class="popupmsg"><tr><td id="Td58">Referente al tema laboral, contesta lo siguiente:<br />
                                     (Haz click en Guardar y Seguir para continuar)
                                 </td></tr><tr><td id="Td59">
                                     <asp:Panel ID="p_trabajo" runat="server" DefaultButton="cmd_trabajo" style="width: 100%;">
                                         <table style="width: 100%"><tr><td style="width: 33%; white-space: nowrap">
                                             ¿En qué empresa laboras?</td><td style="width: 33%; white-space: nowrap">
                                                 ¿Cuáles son sus funciones en la empresa?</td><td style="width: 34%; white-space: nowrap">
                                                     ¿Cual es el horario?</td></tr><tr>
                                         <td id="Td60" style="width: 33%;">
                                             <asp:TextBox ID="tbx_62" runat="server" CssClass="tbxreg" ValidationGroup="labor" Enabled="False"></asp:TextBox></td>
                                             <td id="Td61" style="width: 33%;">
                                                 <asp:TextBox ID="tbx_63" runat="server" CssClass="tbxreg" ValidationGroup="labor" Enabled="False"></asp:TextBox></td>
                                                     <td id="Td62" style="width: 34%;">
                                                         <asp:TextBox ID="tbx_64" runat="server" CssClass="tbxreg" ValidationGroup="labor"></asp:TextBox></td></tr>
                                             <tr>
                                                 <td style="width: 33%;">
                                             ¿Cual es el giro de la empresa?</td><td style="width: 33%;">
                                                 ¿Rolas turno?</td><td style="width: 34%;">
                                                     ¿Tu horario laboral interfiere con el horario escolar?</td></tr><tr>
                                         <td id="Td63" style="width: 33%;">
                                             <asp:TextBox ID="tbx_65" runat="server" CssClass="tbxreg" ValidationGroup="labor" Enabled="False"></asp:TextBox>
                                             <td id="Td64" style="width: 33%;">
                                                 
                                                     <asp:DropDownList ID="ddl_66" runat="server" CssClass="ddlreg_cien" ValidationGroup="labor" Enabled="False">
                                                         <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                         <asp:ListItem Text="No" Value="01"></asp:ListItem>
                                                         <asp:ListItem Text="Si" Value="02"></asp:ListItem>
                                                     </asp:DropDownList>
                                                 
                                                     <td id="Td65" style="width: 34%;">
                                                         
                                                         <asp:DropDownList ID="ddl_67" runat="server" CssClass="ddlreg_cien" ValidationGroup="labor" Enabled="False" EnableTheming="True">
                                                             <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                             <asp:ListItem Text="No" Value="01"></asp:ListItem>
                                                             <asp:ListItem Text="Si" Value="02"></asp:ListItem>
                                                         </asp:DropDownList>
                                                         
                                                     </td>
                                             </tr>
                                             <tr><td colspan="3" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td66">
                                             <asp:Button ID="cmd_trabajo" runat="server" CssClass="botones" Text="Guardar y seguir" style="font-size: 100%;" ValidationGroup="labor" Enabled="False" />
                                             </td><td id="Td67">
                                             <asp:Button ID="cmd_cancelartrabajo" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                                        </td></tr></table>
                                     </asp:Panel>
                              <asp:RequiredFieldValidator ID="rfv_tbx_62" runat="server" ErrorMessage="¡Por favor indica cual es la empresa en donde laboras!." 
                                  Display="None" ControlToValidate="tbx_62" SetFocusOnError="True" ValidationGroup="labor"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_62" runat="server" TargetControlID="rfv_tbx_62" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                              
                              <asp:RequiredFieldValidator ID="rfv_tbx_63" runat="server" ErrorMessage="Describe tus funciones en la empresa." 
                                  Display="None" ControlToValidate="tbx_63" SetFocusOnError="True" ValidationGroup="labor"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_63" runat="server" TargetControlID="rfv_tbx_63" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                                            
                              <asp:RequiredFieldValidator ID="rfv_tbx_64" runat="server" ErrorMessage="¿Cuál es el horario de tu trabajo?." 
                                  Display="None" ControlToValidate="tbx_64" SetFocusOnError="True" ValidationGroup="labor"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_64" runat="server" TargetControlID="rfv_tbx_64" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                              <asp:RequiredFieldValidator ID="rfv_tbx_65" runat="server" ErrorMessage="Describe el giro de la empresa." 
                                  Display="None" ControlToValidate="tbx_65" SetFocusOnError="True" ValidationGroup="labor"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_65" runat="server" TargetControlID="rfv_tbx_65" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                              <asp:RequiredFieldValidator ID="rfv_ddl_66" runat="server" ErrorMessage="¡Indica si rolas turnos!." 
                                  Display="None" ControlToValidate="ddl_66" SetFocusOnError="True" ValidationGroup="labor" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_66" runat="server" TargetControlID="rfv_ddl_66" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                              <asp:RequiredFieldValidator ID="rfv_ddl_67" runat="server" ErrorMessage="¡Indica tu estrategia!." 
                                  Display="None" ControlToValidate="ddl_67" SetFocusOnError="True" ValidationGroup="labor" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_67" runat="server" TargetControlID="rfv_ddl_67" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                       </td></tr></table>
                  </asp:View>

                    <asp:View ID="v_registro" runat="server">
                      <table class="popupmsg"><tr><td id="Td68">Por favor responde sobre tu anterior tramite a otra universidad:<br />
                                     (Haz click en Guardar finalizar)
                                 </td></tr><tr><td id="Td69">
                                     <asp:Panel ID="p_registro" runat="server" DefaultButton="cmd_registro">
                                         <table style="width: 100%"><tr><td style="width: 33%; white-space: nowrap">
                                             ¿En que Universidad hiciste tramite?</td><td style="width: 33%; white-space: nowrap">
                                                 ¿En que periodo?</td><td style="width: 34%; white-space: nowrap">
                                                     ¿Y después de tu trámite...?</td></tr><tr>
                                         <td id="Td70" style="width: 33%;">
                                             
                                             <asp:DropDownList ID="ddl_68" runat="server" CssClass="ddlreg_cien" ValidationGroup="registro" Enabled="False">
                                             </asp:DropDownList>
                                         </td>
                                             <td id="Td71" style="width: 33%;">
                                             
                                             <asp:DropDownList ID="ddl_69" runat="server" CssClass="ddlreg_cien" ValidationGroup="registro" Enabled="False">
                                                <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Actual" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="2015" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="2014" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="2013" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="2012" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="2011" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="2010" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="2009" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="2008" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="2007" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="2006" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="2005" Value="12"></asp:ListItem>
                                                <asp:ListItem Text="2004" Value="13"></asp:ListItem>
                                                <asp:ListItem Text="2003" Value="14"></asp:ListItem>
                                             </asp:DropDownList>    
                                             
                                             </td>
                                             <td id="Td72" style="width: 34%;">

                                             <asp:DropDownList ID="ddl_70" runat="server" CssClass="ddlreg_cien" ValidationGroup="registro" Enabled="False">
                                                <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Ingresé y deje trunca la carrera" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="Ingresé y terminé la carrera" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="No ingresé por que me faltaron documentos" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="No obtuve el puntaje requerido" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="Al final me decidí por otra carrera" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="Problemas laborales me obligaron posponer" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="Problemas personales me obligaron posponer" Value="07"></asp:ListItem>
                                             </asp:DropDownList>           
                                             </td></tr>
                                             <tr>
                                                 <td colspan="3" style="text-align: center; width: 100%">
                                                     <table style="width: 100%; margin: auto;"><tr><td id="Td73" style="width: 50%;">De que especialidad era la carrera</td><td id="Td74" style="width: 50%;">Especificamente a que carrera hiciste trámite</td></tr>
                                                         <tr><td id="Td75" style="width: 50%;">
                                                             
                                                             <asp:DropDownList ID="ddl_71" runat="server" CssClass="ddlreg_cien" ValidationGroup="registro" Enabled="False">
                                                                <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Ingeniería y Tecnología" Value="01"></asp:ListItem>
                                                                <asp:ListItem Text="Económicas o Administrativas" Value="02"></asp:ListItem>
                                                                <asp:ListItem Text="Ciencias de la Salud" Value="03"></asp:ListItem>
                                                                <asp:ListItem Text="Artisticas" Value="04"></asp:ListItem>
                                                                <asp:ListItem Text="Sin definir" Value="05"></asp:ListItem>
                                                             </asp:DropDownList>
                                                                                                                          
                                                             </td><td id="Td76" style="width: 50%;">

                                                                 <asp:TextBox ID="tbx_72" runat="server" CssClass="tbxreg" ValidationGroup="registro" Enabled="False"></asp:TextBox>

                                                             </td></tr>
                                                     </table>
                                                </td>
                                             </tr>
                                             <tr><td colspan="3" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td77">
                                             <asp:Button ID="cmd_registro" runat="server" CssClass="botones" Text="Guardar y seguir" style="font-size: 100%;" ValidationGroup="registro" Enabled="False" />
                                             </td><td id="Td78">
                                             <asp:Button ID="cmd_cancelaregistro" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                       </td></tr></table>
                                     </asp:Panel>

                              <asp:RequiredFieldValidator ID="rfv_ddl_68" runat="server" ErrorMessage="¡Elije la escuela a la que realizaste trámite de ingreso!." 
                                  Display="None" ControlToValidate="ddl_68" SetFocusOnError="True" ValidationGroup="registro" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_68" runat="server" TargetControlID="rfv_ddl_68" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                              <asp:RequiredFieldValidator ID="rfv_ddl_69" runat="server" ErrorMessage="¡Elije el año del trámite de ingreso a la anterior universidad!." 
                                  Display="None" ControlToValidate="ddl_69" SetFocusOnError="True" ValidationGroup="registro" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_69" runat="server" TargetControlID="rfv_ddl_69" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                              <asp:RequiredFieldValidator ID="rfv_ddl_70" runat="server" ErrorMessage="Platicanos que pasó con ese ingreso a otra universidad." 
                                  Display="None" ControlToValidate="ddl_70" SetFocusOnError="True" ValidationGroup="registro" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_70" runat="server" TargetControlID="rfv_ddl_70" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                              <asp:RequiredFieldValidator ID="rfv_ddl_71" runat="server" ErrorMessage="Que orientación tiene la carrera de anterior aspiración." 
                                  Display="None" ControlToValidate="ddl_71" SetFocusOnError="True" ValidationGroup="registro" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_71" runat="server" TargetControlID="rfv_ddl_71" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

                              <asp:RequiredFieldValidator ID="rfv_tbx_72" runat="server" ErrorMessage="¿A que carrera hiciste tramite la aspiración anterior?." 
                                  Display="None" ControlToValidate="tbx_72" SetFocusOnError="True" ValidationGroup="registro"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_72" runat="server" TargetControlID="rfv_tbx_72" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                       </td></tr></table>
                  </asp:View>

                  <asp:View ID="v_bachillerato" runat="server">
                      <table class="popupmsg"><tr><td id="Td79">Referente a las escuelas en donde cursaste el bachillerato...<br />Pulsa Aceptar para continuar.
                                 </td></tr><tr><td id="Td80">
                                     <asp:Panel ID="p_bachillerato" runat="server" DefaultButton="cmd_bachillerato">
                                         <table style="width: 100%"><tr><td id="Td81" style="width: 100%;">
                                             ¿Al ingresar a la preparatoria donde concluíste tu bachillerato, te fueron revalidadas las materias que habías cursado antes?</td></tr><tr>
                                         <td id="Td82" style="width: 100%;">
                                             <asp:DropDownList ID="ddl_75" runat="server" CssClass="ddlreg_cien" ValidationGroup="bachillerato" Enabled="False">
                                                   <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                                   <asp:ListItem Text="Si" Value="01"></asp:ListItem>
                                                   <asp:ListItem Text="No" Value="02"></asp:ListItem>
                                             </asp:DropDownList>
                                             </td></tr><tr><td colspan="2" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td83">
                                             <asp:Button ID="cmd_bachillerato" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="bachillerato" Enabled="False" />
                                             </td><td id="Td84">
                                             <asp:Button ID="cmd_cancelarbachillerato" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr></table>
                                     </asp:Panel>
                              <asp:RequiredFieldValidator ID="rfv_ddl_75" runat="server" ErrorMessage="Elija una opcion..." 
                                  Display="None" ControlToValidate="ddl_75" SetFocusOnError="True" ValidationGroup="bachillerato" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_75" runat="server" TargetControlID="rfv_ddl_75" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                       </td></tr></table>
                  </asp:View>
                    <asp:View runat="server" ID="v_doce">
                         <table class="popupmsg">
                        <tr><td id="Td85">Referente a la nacionalidad...</td></tr>
                        <tr><td id="Td86">
                            <asp:Panel runat="server" ID="p_nacionalidad" DefaultButton="cmd_aceptar">
                                 <table style="width: 100%"><tr><td id="Td87" style="white-space: nowrap" class="auto-style1">
                                             Selecciona tu pais de origen</td></tr><tr>
                                         <td id="Td88" style="padding:0 180px 0 180px" >
                                             <asp:DropDownList ID="ddl_paises" runat="server" CssClass="ddlreg_cien" ValidationGroup="pais" Enabled="False">
                                                  
                                             </asp:DropDownList></td>
                                             
                                             </tr><tr><td colspan="2" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td89">
                                             <asp:Button ID="cmd_aceptar" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="pais" Enabled="False" />
                                             </td><td id="Td90">
                                             <asp:Button ID="cmd_cancelarpais" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr></table>
                            </asp:Panel>
                            
                              <asp:RequiredFieldValidator ID="rfv_ddl_paises" runat="server" ErrorMessage="Selecciona tu pais!" 
                                  Display="None" ControlToValidate="ddl_paises" SetFocusOnError="True" ValidationGroup="pais" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_ddl_paises" runat="server" TargetControlID="rfv_ddl_paises" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                            </td></tr>
                    </table>
                    </asp:View>
                    <asp:View runat="server" ID="v_trece">
                         <table class="popupmsg">
                        <tr><td id="Td91">Referente a tu grupo etnico...</td></tr>
                        <tr><td id="Td92">
                            <asp:Panel runat="server" ID="p_etnias" DefaultButton="cmd_aceptaretnia">
                                 <table style="width: 100%"><tr><td id="Td93" style="width: 30%; white-space: nowrap">
                                             Selecciona tu grupo en las opciones</td></tr><tr>
                                         <td id="Td94" style="padding:0 180px 0 180px" >
                                             <asp:DropDownList ID="ddl_grupo_etnico" runat="server" CssClass="ddlreg_cien" ValidationGroup="etnias" Enabled="False">
                                                  
                                             </asp:DropDownList></td>
                                             
                                             </tr><tr><td colspan="2" style="text-align: center;">
                                             <table style="margin: auto;"><tr><td id="Td95">
                                             <asp:Button ID="cmd_aceptaretnia" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="etnias" Enabled="False" />
                                             </td><td id="Td96">
                                             <asp:Button ID="cmd_cancelaretnia" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr></table>
                            </asp:Panel>
                            <asp:RequiredFieldValidator ID="rfv_ddl_grupo_etnico" runat="server" ErrorMessage="Selecciona tu grupo etnico!" 
                                  Display="None" ControlToValidate="ddl_grupo_etnico" SetFocusOnError="True" ValidationGroup="etnia" InitialValue="0"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_grupo_etnico" runat="server" TargetControlID="rfv_ddl_grupo_etnico" CloseImageUrl="../img/close_coe.png" 
                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                            </td></tr>
                    </table>
                    </asp:View>
                   
                    <asp:View runat="server" ID="v_catorce">
                        <table class="popupmsg">
                            <tr><td id="Td97" style="padding-top:20px">Referente a tu beca</td></tr>
                            <tr><td id="Td98">
                                <asp:Panel runat="server" ID="p_becas" DefaultButton="cmd_becas">
                                    <table style="width: 100%">
                                        <tr><td id="Td99" style="white-space: nowrap;padding-top:20px">¿Cuál era el motivo por el que recibías la beca?</td>  
                                        </tr>
                                        <tr><td id="Td100" style="white-space: nowrap;padding-top:20px">
                                            <asp:DropDownList runat="server" ID="ddl_becas" CssClass="ddlreg_cien" AutoPostBack="true" ValidationGroup="becas" Width="80%" Enabled="False"></asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="rfv_ddl_becas" runat="server" ErrorMessage="Selecciona un motivo!" 
                                                  Display="None" ControlToValidate="ddl_becas" SetFocusOnError="True" ValidationGroup="becas" InitialValue="0"></asp:RequiredFieldValidator>
                                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_becas" runat="server" TargetControlID="rfv_ddl_becas" CloseImageUrl="../img/close_coe.png" 
                                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                            </td> 
                                        </tr>
                                        <tr>
                                            <td id="reg" style="white-space:normal;padding-top:20px">
                                                <asp:Label runat="server" ID="lbl_beca" Text="Especifica cual"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                             <td id="Td101" style="white-space: nowrap;padding-top:20px">
                                                <asp:TextBox runat="server" ID="tbx_becas" CssClass="tbxreg" Width="80%" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_tbx_becas" runat="server" ErrorMessage="Debes especificar cual!" 
                                                  Display="None" ControlToValidate="tbx_becas" SetFocusOnError="True" ValidationGroup="becas"></asp:RequiredFieldValidator>
                                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_becas" runat="server" TargetControlID="rfv_tbx_becas" CloseImageUrl="../img/close_coe.png" 
                                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>  
                                                                </td>
                                        </tr>
                                        <tr><td colspan="2" style="text-align: center;padding-top:20px">
                                             <table style="margin: auto;"><tr><td id="Td102">
                                             <asp:Button ID="cmd_becas" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="becas" Enabled="False" />
                                             </td><td id="Td103">
                                             <asp:Button ID="cmd_cancelarbeca" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr>
                                    </table>
                                </asp:Panel>
                                </td></tr>
                        </table>
                    </asp:View>

                    <asp:View runat="server" ID="v_quince">
                       <table class="popupmsg">
                            <tr><td id="Td104" style="padding-top:20px">Sobre el apoyo de beca</td></tr>
                            <tr><td id="Td105">
                                <asp:Panel runat="server" ID="p_apoyo" DefaultButton="cmd_apoyo">
                                    <table style="width: 100%">
                                        <tr><td id="Td106" style="white-space: nowrap;padding-top:20px">¿Por qué motivo?</td>                                           
                                        </tr>
                                        <tr><td id="Td107" style="white-space: nowrap;padding-top:20px">
                                            <asp:DropDownList runat="server" ID="ddl_apoyos" CssClass="ddlreg_cien" AutoPostBack="true"  Width="80%" Enabled="False"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_apoyos" runat="server" ErrorMessage="Selecciona un motivo!" 
                                                  Display="None" ControlToValidate="ddl_apoyos" SetFocusOnError="True" ValidationGroup="apoyo" InitialValue="0"></asp:RequiredFieldValidator>
                                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_apoyos" runat="server" TargetControlID="rfv_ddl_apoyos" CloseImageUrl="../img/close_coe.png" 
                                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                             <td id="Td108" style="white-space:normal;padding-top:20px">
                                                <asp:Label runat="server" ID="lbl_apoyo" Text="Especifica uno"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="Td109" style="white-space: nowrap;padding-top:20px">
                                                <asp:TextBox runat="server" ID="tbx_apoyo" CssClass="tbxreg" Width="80%" Enabled="False"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="rfv_tbx_apoyo" runat="server" ErrorMessage="Debes especificar cual!" 
                                                  Display="None" ControlToValidate="tbx_apoyo" SetFocusOnError="True" ValidationGroup="apoyo"></asp:RequiredFieldValidator>
                                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_apoyo" runat="server" TargetControlID="rfv_tbx_apoyo" CloseImageUrl="../img/close_coe.png" 
                                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>  
                                            </td>
                                        </tr>
                                        <tr><td colspan="2" style="text-align: center;padding-top:20px">
                                             <table style="margin: auto;"><tr><td id="Td110">
                                             <asp:Button ID="cmd_apoyo" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="apoyo" Enabled="False" />
                                             </td><td id="Td111">
                                             <asp:Button ID="cmd_cancelarapoyo" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr>
                                    </table>
                                </asp:Panel>
                                </td></tr>
                        </table>
                    </asp:View>
                    <asp:View runat="server" ID="v_dieciseis">
                       <table class="popupmsg">
                            <tr><td id="Td112" style="padding-top:20px">Sobre las actividades deportivas y/o socioculturales</td></tr>
                            <tr><td id="Td113">
                                <asp:Panel runat="server" ID="p_deportes" DefaultButton="cmd_deportes">
                                    <table style="width: 100%">
                                        <tr><td id="Td114" style="white-space: nowrap;padding-top:20px">¿Qué deporte o actividad sociocultural practicas o te gustaría practicar?</td>                                        
                                        </tr>
                                        <tr><td id="Td115" style="white-space: nowrap;padding-top:20px">
                                            <asp:DropDownList runat="server" ID="ddl_deportes" CssClass="ddlreg_cien" AutoPostBack="true" ValidationGroup="deportes" Width="300px" Enabled="False"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_ddl_deportes" runat="server" ErrorMessage="Selecciona una opcion!" 
                                                  Display="None" ControlToValidate="ddl_deportes" SetFocusOnError="True" ValidationGroup="deportes" InitialValue="0"></asp:RequiredFieldValidator>
                                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_deportes" runat="server" TargetControlID="rfv_ddl_deportes" CloseImageUrl="../img/close_coe.png" 
                                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
                                            </td>                                        
                                           </tr>
                                        <tr>
                                             <td id="Td116" style="white-space:normal;padding-top:20px">
                                                <asp:Label runat="server" ID="lbl_deportes" Text="Especifica cual"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="Td117" style="white-space: nowrap;padding-top:20px">
                                                <asp:TextBox runat="server" ID="txt_deportes" CssClass="tbxreg" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_txt_deportes" runat="server" ErrorMessage="Debes especificar cual!" 
                                                  Display="None" ControlToValidate="txt_deportes" SetFocusOnError="True" ValidationGroup="deportes"></asp:RequiredFieldValidator>
                                              <asp:ValidatorCalloutExtender ID="vcoe_rfv_txt_deportes" runat="server" TargetControlID="rfv_txt_deportes" CloseImageUrl="../img/close_coe.png" 
                                                  CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>  
                                            </td>
                                        </tr>
                                        <tr><td colspan="2" style="text-align: center;padding-top:20px">
                                             <table style="margin: auto;"><tr><td id="Td118">
                                             <asp:Button ID="cmd_deportes" runat="server" CssClass="botones" Text="Aceptar" style="font-size: 100%;" ValidationGroup="deportes" Enabled="False" />
                                             </td><td id="Td119">
                                             <asp:Button ID="cmd_cancelardeporte" runat="server" CssClass="botones" Text="Cancelar" style="font-size: 100%;" CausesValidation="false"/>
                                             </td></tr></table>
                                         </td></tr>
                                    </table>
                                </asp:Panel>
                                </td></tr>
                        </table>
                    </asp:View>
                     
                     

                </asp:MultiView>
              </ContentTemplate></asp:UpdatePanel></td></tr></table>

            </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cmd_bln" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ib_bcp" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cmd_besc" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_32" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_33" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_39" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_40" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_41" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_42" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_43" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_45" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_74" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_nacionalidad" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_etnias" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_becas" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddl_apoyo" EventName="SelectedIndexChanged" />

                </Triggers>
            </asp:UpdatePanel>


                        <asp:Panel ID="p_registrok" runat="server" style="display: none" DefaultButton="cmd_ok">
                            <table><tr><td style="text-align: right; padding: 5px;"><asp:ImageButton ID="ib_closem" runat="server" ImageUrl="../img/close_coe.png"/></td></tr><tr><td>
                               <table class="popupmsg" style="width: 100%"><tr><td></td><td style="width: 100%; padding: 10px 0px 5px 0px;"><img alt="Correcto" src="..\img\ok_green.png"/></td>
                               <td>
                                  
                               </td></tr>
                                   <tr>
                                       <td>&nbsp;</td><td id="Td120" style="padding: 10px; width: 100%;">
                                           <asp:LinkButton ID="lb_closeok" runat="server"></asp:LinkButton>
                                           El registro se ha actualizado correctamente.</td><td>&nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td></td>
                                       <td id="Td121" style="padding: 10px; width: 100%;">
                                           <asp:Button ID="cmd_ok" runat="server" CausesValidation="False" CssClass="botones" style="font-size: 100%;" Text="Buscar otro aspirante" />
                                       </td>
                                       <td></td>
                                   </tr>
                                </table>
                             </td></tr></table>
                         </asp:Panel>
        </td></tr>
        
        </table>

                        
         </asp:View>

                    <asp:View runat="server" ID="v_primera">
                
        <div class="topbar"><table><tr><td><asp:ImageButton ID="im_back" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_siguiente" Text="Continuar" CssClass="boton_texto_dentro"/></td>
                                   </tr></table></div>   
        
                <div style="text-align:left">
                    <div class="titulocategoria" style="padding-left:30px">RECUERDA QUE DEBES TOMAR ESTOS PUNTOS EN CUENTA PARA LA ENTREVISTA</div>
                    <div class="titulocelda" style="padding-left:30px; font-style:italic;">Guía de entrevista a los aspirantes a ingresar a la Universidad Tecnológica de Jalisco</div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-weight:bold;">Categorías a considerarse:</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>-          Datos generales acerca de su historial en el bachillerato</div>
                        <div>-          Motivación hacia la carrera que se pretende estudiar</div>
                        <div>-          Información y experiencia previa sobre la carrera elegida</div>       
                        <div>-          Metas a corto y mediano plazo</div> 
                        <div>-          Posibilidad de dedicar tiempo a los estudios</div> 
                        <div>-          Respaldo familiar</div> 
                        <div>-           Habilidades sociales (en base sobre todo a la observación)</div> 
                    </div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-weight:bold;">Preguntas base para la entrevista:</div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-style:italic;">Datos generales acerca de su historial en el bachillerato</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>1.       Ahondar en cómo considera que fue su desempeño en el bachillerato</div>
                        <div>2.       ¿Sus calificaciones reflejan realmente su aprendizaje y aprovechamiento escolar?</div>
                        <div>3.       Si pudiera cambiar algo de lo vivido en la preparatoria, ¿qué cambiaría?</div>       
                    </div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-style:italic;">Motivación hacia la carrera que se pretende estudiar</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>4.       Si realizó trámites a otra universidad</div>
                        <div>5.       ¿A qué carrera había realizado trámites?</div>
                        <div>6.       Si no había realizado antes trámites, ¿qué otras carreras había considerado?</div>       
                        <div>7.       ¿Había realizado trámites antes para esta universidad?</div> 
                        <div>8.       ¿Por qué eligió esta institución para cursar sus estudios universitarios?</div> 
                        
                    </div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-style:italic;">Información y experiencia previa sobre la carrera elegida</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>9.       ¿Cómo es que entre tantas carreras finalmente se decidió por ésta?</div>
                        <div>10.   ¿Qué le llamó la atención de la carrera elegida?</div>
                        <div>11.   ¿Qué espera aprender de esta carrera?</div>       
                        <div>12.   ¿Sabe en qué trabajan las personas que estudian esta profesión?</div> 
                        <div>13.   ¿Ha tomado algún curso previo relacionado con la carrera elegida?</div> 
                        <div>14.   ¿Ha trabajado o trabaja en algo relacionado con la carrera que pretende estudiar?</div> 
                        <div>15.   ¿Había escuchado hablar sobre esta carrera o tiene parientes o conocidos que la ejerzan?</div> 
                    </div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-style:italic;">Metas a corto y mediano plazo</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>16.   ¿Qué planea hacer cuando termine esta carrera?</div>
                        <div>17.   ¿Estudiará la ingeniería posteriormente?</div>
                        <div>18.   ¿Iniciará su propio negocio?</div>       
                        <div>19.   ¿Trabajará en algún negocio de la familia?</div>  
                    </div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-style:italic;">Posibilidad de dedicar tiempo a los estudios</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>20.   ¿Qué planes tiene mientras estudie aquí; trabajará medio tiempo, tiempo completo, sólo estudiará, estudiará algún idioma o alguna otra disciplina?</div>
                        <div>21.   ¿Considera importante que se tenga establecido en casa un tiempo y espacio definidos para estudiar?</div>    
                    </div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-style:italic;">Respaldo familiar</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>22.   ¿Con quiénes vive actualmente?</div>
                        <div>23.   ¿Sus familiares están enterados de que continuará estudiando y qué carrera?</div>
                        <div>24.   ¿Qué opinan sus padres o pareja sobre su decisión de continuar estudiando una carrera a nivel profesional?</div>       
                        <div>25.   ¿Cuenta con apoyo económico de su familia?</div>
                        <div>26.   ¿Cuenta con apoyo moral de su familia?</div>    
                    </div>
                    <div class="titulocelda" style="padding-left:30px; padding-top:20px; font-style:italic;">Habilidades sociales</div>
                    <div style="padding-left:60px;padding-top:20px">
                        <div>27.   ¿En qué inviertes tu tiempo libre?</div>
                        <div>28.   ¿Tienes algún pasatiempo en especial?</div>
                        <div>29.   ¿Practicas algún deporte?</div>       
                        <div>30.   ¿Perteneces a alguna asociación, grupo juvenil, etc.?</div>
                    </div>
                </div>
                
 
                    </asp:View>

                     <asp:View runat="server" ID="v_exito">
                    <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_vuelve" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_vuelve_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                    <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_listado" Text="Volver a la busqueda" CssClass="boton_texto_dentro" OnClick="lb_listado_Click" /></td>
                                   
                                    </tr></table></div>           

                                   
                                <div>
                                    <div style="padding-top:150px; text-align:center"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">Los datos se han guardado correctamente en el sistema!
                                        </div>
                                </div>
               
                </asp:View>
                    <asp:View runat="server" ID="v_cuatro">

                        <div>
                        <table class="tablacien"><tr>
                            <td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Entrevista de carrera</td></tr>
                                    <tr><td style="text-align: center; font-size: 1.1em; padding:5px;">Haga click en un ciclo para buscar a los(as) aspirantes.
                                        </td></tr>
                                    <tr><td>
                                        <asp:GridView ID="gv_ciclos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="Center"
                                style="border: solid 1px #ccc;" CellSpacing="0" CellPadding="10"  EmptyDataText=":( No hay datos por mostrar..">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Ciclo">
                                        <ItemTemplate>
                                            <div>
                                                <asp:LinkButton ID="lb_ciclo" runat="server" Text='<%# Bind("CICLO")%>' CssClass="texto_boton_gv" OnClick="lb_ciclo_Click" CommandArgument='<%# Bind("CICLO")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="CICLO" HeaderText="Ciclo" ReadOnly="True" SortExpression="CICLO" Visible="False" />--%>
                                    <asp:BoundField DataField="FECHAS" HeaderText="Periodo" ReadOnly="True" SortExpression="FECHAS" />
                                    <asp:BoundField DataField="INICIO" HeaderText="Inicio del ciclo" ReadOnly="True" SortExpression="INICIO" />
                                    <asp:BoundField DataField="FIN" HeaderText="Fin del ciclo" ReadOnly="True" SortExpression="FIN" />
                                    <asp:CheckBoxField DataField="ACTIVO" HeaderText="Activo" SortExpression="ACTIVO" />
                                </Columns>
                                <HeaderStyle CssClass="gvheader" />
                                <RowStyle CssClass="gvrow" />
                            </asp:GridView>
                                      </td></tr>
                                </table>
                                </td></tr>
                        </table>
                            <asp:HiddenField runat="server" ID="hf_ciclo" />
                    </div>

        </asp:View>
                </asp:MultiView>
            </div>

                

    <asp:RequiredFieldValidator ID="rfv_tbx_16" runat="server" ErrorMessage="¡Por favor danos un telefono fijo!." 
        Display="None" ControlToValidate="tbx_16" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_16" runat="server" TargetControlID="rfv_tbx_16" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:FilteredTextBoxExtender ID="ftbe_tbx_16" runat="server" TargetControlID="tbx_16" ValidChars="1234567890"/>
      <%'<asp:RegularExpressionValidator ID="rev_tbx_16" runat="server" Display="None" ErrorMessage="No parece un numero válido :(" 
'  ControlToValidate="tbx_16" ValidationGroup="reg" ValidationExpression="^[0-9]\d{7}"></asp:RegularExpressionValidator>
'<asp:ValidatorCalloutExtender ID="vcoe_rev_tbx_16" runat="server" TargetControlID="rev_tbx_16" CloseImageUrl="../img/close_coe.png" 
'CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender> %>
  
    <asp:RequiredFieldValidator ID="rfv_tbx_17" runat="server" ErrorMessage="¡Por favor danos tu telefono movil!." 
        Display="None" ControlToValidate="tbx_17" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_17" runat="server" TargetControlID="rfv_tbx_17" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:FilteredTextBoxExtender ID="ftbe_tbx_17" runat="server" TargetControlID="tbx_17" ValidChars="1234567890"/>
    <asp:RegularExpressionValidator ID="rev_tbx_17" runat="server" Display="None" ErrorMessage="No parece un numero válido :(" 
        ControlToValidate="tbx_17" ValidationGroup="reg" ValidationExpression="^[0-9]\d{9}" SetFocusOnError="true"></asp:RegularExpressionValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rev_tbx_17" runat="server" TargetControlID="rev_tbx_17" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
  
    <asp:RequiredFieldValidator ID="rfv_tbx_18" runat="server" ErrorMessage="¡Por favor danos un telefono de recados!." 
        Display="None" ControlToValidate="tbx_18" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_18" runat="server" TargetControlID="rfv_tbx_18" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:FilteredTextBoxExtender ID="ftbe_tbx_18" runat="server" TargetControlID="tbx_18" ValidChars="1234567890"/>
    <%'<asp:RegularExpressionValidator ID="rev_tbx_18" runat="server" Display="None" ErrorMessage="No parece un numero válido :(" 
'    ControlToValidate="tbx_18" ValidationGroup="reg" ValidationExpression="^[0-9]\d{7}"></asp:RegularExpressionValidator>
'<asp:ValidatorCalloutExtender ID="vcoe_rev_tbx_18" runat="server" TargetControlID="rev_tbx_18" CloseImageUrl="../img/close_coe.png" 
'    CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>%>
  
    <asp:RequiredFieldValidator ID="rfv_tbx_19" runat="server" ErrorMessage="¡Es necesario proporcional el correo!." 
        Display="None" ControlToValidate="tbx_19" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_19" runat="server" TargetControlID="rfv_tbx_19" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:RegularExpressionValidator ID="rev_tbx_19" runat="server" Display="None" ErrorMessage="No parece un correo válido :(" 
        ControlToValidate="tbx_19" ValidationGroup="reg" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" SetFocusOnError="true"></asp:RegularExpressionValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_tbx_19_2" runat="server" TargetControlID="rev_tbx_19" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
     
    <asp:RequiredFieldValidator ID="rfv_tbx_20" runat="server" ErrorMessage="¡Debes de proporcionarnos la CURP para tu registro!." 
        Display="None" ControlToValidate="tbx_20" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_20" runat="server" TargetControlID="rfv_tbx_20" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:RegularExpressionValidator ID="rev_tbx_20" runat="server" Display="None" ErrorMessage="No parece una CURP válida :(, captura en mayúsculas." 
        ControlToValidate="tbx_20" ValidationGroup="reg" SetFocusOnError="true" ValidationExpression="^[A-Z]{1}[AEIOUX]{1}[A-Z]{2}((\d{2}((0[13578]|1[02])(0[1-9]|[12][0-9]|3[01])|(0[13-9]|1[0-2])(0[1-9]|[12][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8])))|([02468][048]|[13579][26])0229)[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]$"></asp:RegularExpressionValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_20_2" runat="server" TargetControlID="rev_tbx_20" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
  
    <asp:RequiredFieldValidator ID="rfv_tbx_21" runat="server" ErrorMessage="¡Son cuestiones de salud, por favor danos este dato!." 
        Display="None" ControlToValidate="tbx_21" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_21" runat="server" TargetControlID="rfv_tbx_21" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:FilteredTextBoxExtender ID="ftbe_tbx_21" runat="server" TargetControlID="tbx_21" FilterType="Numbers"/>
  
    <asp:RequiredFieldValidator ID="rfv_tbx_22" runat="server" ErrorMessage="¡Es necesaria la estatura para seguir con el registro!." 
        Display="None" ControlToValidate="tbx_22" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_22" runat="server" TargetControlID="rfv_tbx_22" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:FilteredTextBoxExtender ID="ftbe_tbx_22" runat="server" TargetControlID="tbx_22" FilterType="Numbers"/>

    <asp:RequiredFieldValidator ID="rfv_tbx_23" runat="server" ErrorMessage="¡Haz click en buscar bachillerato para llenar este campo!." 
        Display="None" ControlToValidate="tbx_23" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_23" runat="server" TargetControlID="rfv_tbx_23" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_24" runat="server" ErrorMessage="¡Elije un año para indicar el ingreso a la prepa!." 
        Display="None" ControlToValidate="ddl_24" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_24" runat="server" TargetControlID="rfv_ddl_24" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_25" runat="server" ErrorMessage="¡Eije un mes para indicar el ingreso a la prepa!." 
        Display="None" ControlToValidate="ddl_25" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_25" runat="server" TargetControlID="rfv_ddl_25" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_26" runat="server" ErrorMessage="¡Elije un año para indicar el egreso de la prepa!." 
        Display="None" ControlToValidate="ddl_26" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_26" runat="server" TargetControlID="rfv_ddl_26" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_27" runat="server" ErrorMessage="¡Eije un mes para indicar el egreso de la prepa!." 
        Display="None" ControlToValidate="ddl_27" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_27" runat="server" TargetControlID="rfv_ddl_27" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
         
    <asp:RequiredFieldValidator ID="rfv_tbx_28" runat="server" ErrorMessage="¡Es necesario tu promedio de la prepa, si aun no la terminas ingresa el más aproximado!." 
        Display="None" ControlToValidate="tbx_28" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_28" runat="server" TargetControlID="rfv_tbx_28" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    <asp:FilteredTextBoxExtender ID="ftbe_tbx_28" runat="server" TargetControlID="tbx_28" ValidChars="1234567890."/>
    <asp:RegularExpressionValidator ID="rev_tbx_28" runat="server" Display="None" ErrorMessage="El promedio mínimo es 7 y en base 10. Éste no parece un promedio válido :(" 
        ControlToValidate="tbx_28" ValidationGroup="reg" ValidationExpression="^[7-9](\.\d{1})?|10$" SetFocusOnError="true"></asp:RegularExpressionValidator>
    <asp:ValidatorCalloutExtender ID="vco_rev_tbx_28" runat="server" TargetControlID="rev_tbx_28" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

        <asp:RequiredFieldValidator ID="rfv_ddl_29" runat="server" ErrorMessage="¡El tipo de escuela es un campo requerido!." 
        Display="None" ControlToValidate="ddl_29" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_29" runat="server" TargetControlID="rfv_ddl_29" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_30" runat="server" ErrorMessage="¡Para seguir es necesario que indiques el tipo de bachillerato!." 
        Display="None" ControlToValidate="ddl_30" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_30" runat="server" TargetControlID="rfv_ddl_30" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_31" runat="server" ErrorMessage="¡Elije la especialidad de tu bachillerato!." 
        Display="None" ControlToValidate="ddl_31" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_31" runat="server" TargetControlID="rfv_ddl_31" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_32" runat="server" ErrorMessage="¡Indica si realizaste exámenes extraordinarios en tu prepa!." 
        Display="None" ControlToValidate="ddl_32" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_32" runat="server" TargetControlID="rfv_ddl_32" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_33" runat="server" ErrorMessage="¡Por favor responde si tienes el certificado de la prepa!." 
        Display="None" ControlToValidate="ddl_33" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_33" runat="server" TargetControlID="rfv_ddl_33" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_74" runat="server" ErrorMessage="Indica si hiciste en una sola escuela tu bachillerato." 
        Display="None" ControlToValidate="ddl_74" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_74" runat="server" TargetControlID="rfv_ddl_74" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
    
    <asp:RequiredFieldValidator ID="rfv_tbx_34" runat="server" ErrorMessage="¡Esta información es necesaria para armar tu perfil correctamente!." 
        Display="None" ControlToValidate="tbx_34" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_34" runat="server" TargetControlID="rfv_tbx_34" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
  
    <asp:RequiredFieldValidator ID="rfv_tbx_35" runat="server" ErrorMessage="¡Esta información es necesaria para armar tu perfil correctamente!." 
        Display="None" ControlToValidate="tbx_35" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_tbx_35" runat="server" TargetControlID="rfv_tbx_35" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    
    <asp:RequiredFieldValidator ID="rfv_ddl_39" runat="server" ErrorMessage="¿Tienes algun problema o padecimiento crónico?." 
        Display="None" ControlToValidate="ddl_39" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_39" runat="server" TargetControlID="rfv_ddl_39" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_40" runat="server" ErrorMessage="¿Estas o estuviste bajo algun tratamiento psicológico?" 
        Display="None" ControlToValidate="ddl_40" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_40" runat="server" TargetControlID="rfv_ddl_40" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <%--<asp:CustomValidator ID="cv_cbx_47" runat="server" ClientValidationFunction="CheckIfCheckBoxListIsChecked" OnServerValidate="CheckIfCheckBoxListIsCheckedServer"
        ErrorMessage="¡Al menos elije un motivo!" Display="Dynamic" ValidationGroup="reg" SetFocusOnError="True"></asp:CustomValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_cv_cbx_47" runat="server" TargetControlID="cv_cbx_47" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>

    <%--<asp:RequiredFieldValidator ID="rfv_calendario" runat="server" ErrorMessage="¡Por favor elije el día y hora de tu cita!." 
        Display="None" ControlToValidate="rbl_49" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_calendario" runat="server" TargetControlID="rfv_calendario" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>

<%--    <asp:CustomValidator ID="cv_cbx_73" runat="server" ClientValidationFunction="CheckIfCheckBoxListIsChecked2" OnServerValidate="CheckIfCheckBoxListIsCheckedServer2"
        ErrorMessage="¡Al menos elije una opcion de como te enteraste de la UTJ!" Display="Dynamic" ValidationGroup="reg" SetFocusOnError="True"></asp:CustomValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_cv_cbx_73" runat="server" TargetControlID="cv_cbx_73" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>
    
    <asp:RequiredFieldValidator ID="rfv_ddl_beca" runat="server" ErrorMessage="¿Tuviste alguna beca durante tu estancia en el bachillerato?" 
        Display="None" ControlToValidate="ddl_beca" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_beca" runat="server" TargetControlID="rfv_ddl_beca" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>

    <asp:RequiredFieldValidator ID="rfv_ddl_apoyo" runat="server" ErrorMessage="¿Consideras necesario el apoyo con una beca?" 
        Display="None" ControlToValidate="ddl_apoyo" SetFocusOnError="True" ValidationGroup="reg" InitialValue="0"></asp:RequiredFieldValidator>
    <asp:ValidatorCalloutExtender ID="vcoe_rfv_ddl_apoyo" runat="server" TargetControlID="rfv_ddl_apoyo" CloseImageUrl="../img/close_coe.png" 
        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

