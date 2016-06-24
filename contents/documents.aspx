<%@ Page Title="Recepcion de Documentos - SIAAA UTJ" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="documents.aspx.vb" Inherits="documents" %>

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


        <!--<script type="text/javascript" lang="JavaScript" >
        var bPreguntar = true;
        window.onbeforeunload = preguntarAntesDeSalir;
        function preguntarAntesDeSalir() {
            if (bPreguntar)
                return "¿Al refrescar la página se eliminará la información de los campos que ya llenaste. ¿Deseas hacerlo de todas formas?";
        }
    </script>

     <script type="text/javascript" lang="JavaScript" >
         bPreguntar = false;
         function closewin() {
             var $window = window.self;
             $window.opener = window.self;
             $window.close();
         }
    </script>-->



    <div style="padding-bottom: 200px;">
        <asp:Multiview ID="mv_general" runat="server">
            <asp:view ID="v_busqueda" runat="server">
                <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar_Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
           
        </tr></table></div>
                 <asp:HiddenField runat="server" ID="hf_ciclo" />
                <table class="centrado"><tr><td class="titulocategoria" style="text-align: center; padding: 20px 0px 20px 0px;" colspan="3">Registro de entrega de Documentos de ingreso</td></tr><tr><td>
                    <asp:Panel ID="p_buscar" runat="server" DefaultButton="cmd_buscar">
                    <table class="centrado"><tr><td style="padding: 0 10px 0 0">Aspirante</td><td>
                    <asp:TextBox ID="tbx_busqueda" runat="server" CssClass="tbxreg" MaxLength="100" Width="400px"></asp:TextBox></td>
                    <td><asp:Button ID="cmd_buscar" runat="server" Text="Buscar aspirante(s)" CssClass="botones" style="font-size: 100%;" CausesValidation="True" /></td></tr></table></asp:Panel>
                    </td></tr>
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
            <asp:View ID="v_datos" runat="server">

        <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar folio y documentos" CssClass="boton_texto_dentro"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_imprimircr" Text="Imprimir carta de adeudo de documentos" CssClass="boton_texto_dentro"/></td>
        </tr></table></div>
                    
        <table class="tablacien" style="width:70%;">

            <tr>
                <td class="titulocategoria">Recepción de Documentos</td></tr>
                <tr><td><table><tr>
                    <td style="padding-left: 20px; vertical-align: top;"><asp:GridView ID="gv_documentos" runat="server" AutoGenerateColumns="False" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="left"
                                CellSpacing="0" CellPadding="5" ShowHeader="false" ShowFooter="false">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div style="text-align:left;">
                                                <asp:HiddenField ID="hf_id" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id")%>' />
                                                <asp:CheckBox ID="cbx_entregado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "documento")%>'
                                                    checked='<%# DataBinder.Eval(Container.DataItem, "entregado")%>' TextAlign="right"></asp:CheckBox>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <div>
                                                <asp:TextBox ID="tbx_comentario" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "comentario")%>' style="width: 350px;" CssClass="tbxreg"></asp:TextBox>
                                                <asp:TextBoxWatermarkExtender ID="tbx_comentario_wme" runat="server" Enabled="True" TargetControlID="tbx_comentario" WatermarkText="Comentario" WatermarkCssClass="wmlogin"></asp:TextBoxWatermarkExtender>
                                                
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 </Columns>
                                <HeaderStyle CssClass="gvheader" />
                                <RowStyle CssClass="gvrow" />
                            </asp:GridView></td><td style="vertical-align: top; padding: 10px;">

                                <table class="tablacien" style="text-align:left">
                                <tr><td rowspan="2" style="padding: 0px 10px 0px 10px"><img alt="CENEVAL" src="../img/ceneval.png" /></td><td style="text-align:left; font-size: 1.2em; width: 100%;">Captura del Folio de CENEVAL</td></tr>
                                <tr><td class="celdascien" style="width:30%"><asp:TextBox ID="txtFolio" runat="server" CssClass="tbxreg"></asp:TextBox></td></tr>
            
                            </table>

                                                </td></tr></table></td>
            </tr>

        <tr><td class="titulocategoria">Datos de Carrera</td></tr>
        <tr><td>
            
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
            
            </td></tr>

        <tr><td class="titulocategoria">Personales</td></tr><tr><td>
        <table class="tablacien" style="text-align: left;"><tr><td class="titulocelda" rowspan="2">
            <asp:image ID="img_user" runat="server" style="width: 100px;" /></td>
            <td class="titulocelda">Nombres</td>
            <td class="titulocelda">Primer Apellido</td><td class="titulocelda">Segundo Apellido</td></tr><tr>
            <td class="celdascien" style="width: 33%">
                <asp:TextBox ID="tbx_1" runat="server" AutoCompleteType="FirstName" CssClass="tbxreg" MaxLength="50" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="celdascien" style="width: 33%"><asp:TextBox ID="tbx_2" runat="server" CssClass="tbxreg" MaxLength="50" AutoCompleteType="LastName" ReadOnly="True"></asp:TextBox>
            </td><td class="celdascien" style="width: 33%"><asp:TextBox ID="tbx_3" runat="server" CssClass="tbxreg" MaxLength="50" ReadOnly="True"></asp:TextBox></td>
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
             
             <%--<asp:RequiredFieldValidator ID="rfv_ddl_4" runat="server" ErrorMessage="¡Selecciona tu sexo!." 
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
                 CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>

        </td></tr>
        

        <tr><td></td></tr>

         <tr><td>
             <table class="tablacien" style="text-align: left;"><tr>
                 <td class="titulocelda">Teléfono fijo</td><td class="titulocelda">Teléfono móvil</td>
                 <td class="titulocelda">Otro teléfono</td><td class="titulocelda">Correo electónico</td>
                 <td class="titulocelda">CURP</td>
                 </tr><tr>
                 <td class="celdascien" style="width: 10%"><asp:TextBox ID="tbx_16" runat="server" CssClass="tbxreg" MaxLength="10" ReadOnly="True"></asp:TextBox></td>
                 <td class="celdascien" style="width: 10%"><asp:TextBox ID="tbx_17" runat="server" CssClass="tbxreg" MaxLength="10" ReadOnly="True"></asp:TextBox></td>
                 <td class="celdascien" style="width: 10%"><asp:TextBox ID="tbx_18" runat="server" CssClass="tbxreg" MaxLength="10" ReadOnly="True"></asp:TextBox></td>
                 <td class="celdascien" style="width: 43%"><asp:TextBox ID="tbx_19" runat="server" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td>
                 <td class="celdascien" style="width: 20%"><asp:TextBox ID="tbx_20" runat="server" CssClass="tbxreg" ReadOnly="True"></asp:TextBox></td>
                 
                 </tr></table>
             </td></tr>
        <tr><td class="titulocategoria">Antecedentes escolares</td></tr>
        <tr><td>
            <table class="tablacien" style="width: 100%; text-align: left;"><tr><td>Bachillerato de procedencia</td><td></td><td>Ingreso</td><td>Egreso</td><td>Promedio</td></tr>
                   <tr><td class="celdascien" style="width: 100%;">
                       <asp:TextBox ID="tbx_23" runat="server" CssClass="tbxreg"></asp:TextBox>
                       <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="tbxreg" ReadOnly="true"></asp:TextBox>--%>
                      <%-- <asp:UpdatePanel ID="up_tbx_23" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional"><ContentTemplate>
                       
                       </ContentTemplate>
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="gv_escuela" EventName="RowCommand" />
                           </Triggers>
                       </asp:UpdatePanel>--%>

                       </td>
                       <td class="celdascien"  style="width: 0%;">
                       <!--<asp:Button ID="cmd_besc" runat="server" Text="Buscar bachillerato" CssClass="botones" style="font-size: 100%;" CausesValidation="False" Enabled="true"/>--></td>
                       <td class="celdacero" style="vertical-align: top;"><table class="tablainterna" style="width: 0%; text-align: left;"><tr><td class="celdascero">
                    <asp:DropDownList ID="ddl_24" runat="server" CssClass="ddlreg_short" Enabled="true" ValidationGroup="reg">
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
                    <td class="celdascero"><asp:DropDownList ID="ddl_25" runat="server" CssClass="ddlreg_short" Enabled="true" ValidationGroup="reg">
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
                       <td class="celdacero" style="vertical-align: top;"><table class="tablainterna" style="width: 0%; text-align: left;"><tr><td class="celdascero">
                    <asp:DropDownList ID="ddl_26" runat="server" CssClass="ddlreg_short" ValidationGroup="reg" Enabled="true">
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
                    <td class="celdascero"><asp:DropDownList ID="ddl_27" runat="server" CssClass="ddlreg_short" ValidationGroup="reg" Enabled="true">
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
                       <td class="celdascien" style="width: 0%;"><asp:TextBox ID="tbx_28" runat="server" CssClass="tbxreg" ReadOnly="false" ValidationGroup="reg"></asp:TextBox></td></tr></table>
            </td>
          </table>
                </asp:View>
            <asp:View runat="server" ID="v_dos">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar__Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                  
                                    <td style="font-size: 1.5em;">
                                        <asp:LinkButton ID="lb_regresar_" runat="server" CssClass="boton_texto_dentro" Text="Volver al inicio"  OnClick="lb_regresar__Click" />
                         </td>
                                    </tr></table></div>           

                                   
                                <div style="text-align: center" class="centrado">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">Los documentos se han registrado correctamente en el sistema!
                                        
                                </div></div>
               
                 </asp:View>

             <asp:View runat="server" ID="v_tres">

                        <div>
                        <table class="tablacien"><tr>
                            <td>
                                <table class="tablacien">
                                    <tr><td class="titulo_medio" style="padding: 5px 5px 15px 5px;">Registro de documentos</td></tr>
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
                    </div>

        </asp:View>

        </asp:Multiview>
                </div>
        

   
  
</asp:Content>

