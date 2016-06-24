<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="grupos.aspx.vb" Inherits="contents_grupos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">

    <asp:UpdatePanel runat="server" ID="up_grupos">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="mv_grupos">
                <asp:View runat="server" ID="v_cero">
                    <div>
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_recarga" runat="server" ImageUrl="~/img/reload.png"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><%--<asp:Linkbutton runat="server" ID="lb_nuevo" Text="Nuevo programa educativo" CssClass="boton_texto_dentro" />--%></td>
                        </tr></table></div>
                                <table class="centrado" style="text-align:center;"><tr><td>
                    <div>
                        <div class="titulocategoria" style="text-align:center;padding-top:50px;">Información sobre grupos</div>
                        
                        <div class="titulocelda" style="text-align:center; padding: 20px;">Haga click en la clave de carrera para consultar sus grupos.</div>
                        <div>
                            <asp:GridView runat="server" ID="gv_listado" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="center"
                                style="border:solid 1px #ccc" CellSpacing="0" CellPadding="10" HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Clave">
                                        <ItemTemplate>
                                            <div>   
                                                <asp:LinkButton runat="server" ID="lb_clave" Text='<%# Bind("CLAVE")%>' CssClass="texto_boton_gv" OnClick="lb_clave_Click" CommandArgument='<%# Bind("CLAVE")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NIVEL" HeaderText="Nivel" SortExpression="NIVEL" />
                                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div> 
                    </div>
                </asp:View>
                <asp:View runat="server" ID="v_uno">
                    <div>
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back" runat="server" ImageUrl="~/img/arrowback.png" OnClick="lb_Volver_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_nuevo" Text="Agregar grupos" CssClass="boton_texto_dentro" /></td>
                        </tr></table></div>
                                <table class="centrado" style="text-align:center;"><tr><td>
                    <div>
                        <div class="titulocategoria" style="text-align:center;padding-top:20px">Grupos de la carrera: <asp:Label runat="server" ID="lbl_carrera" Font-Bold="true"></asp:Label></div>
                        
                        <div class="titulocelda" style="text-align:center; padding: 20px;">Haga click en el indentificador de grupo (ID) para consultarlo</div>
                        <div>
                            <asp:GridView runat="server" ID="gv_grupos" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="center"
                                style="border:solid 1px #ccc" CellSpacing="0" CellPadding="10" HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <div>   
                                                <asp:LinkButton runat="server" ID="lb_id_grupo" Text='<%# Bind("id_grupo")%>' CssClass="texto_boton_gv" OnClick="lb_id_grupo_Click" CommandArgument='<%# Bind("id_grupo")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="nivel" HeaderText="NIVEL" SortExpression="NIVEL"/>
                                    <asp:BoundField DataField="grado" HeaderText="GRADO" SortExpression="GRADO" />
                                    <asp:BoundField DataField="grupo" HeaderText="GRUPO" SortExpression="GRUPO"/>
                                    <asp:BoundField DataField="turno" HeaderText="TURNO" SortExpression="TURNO"/>
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div> 
                    </div>
                </asp:View>
                 <asp:View runat="server" ID="v_dos">
                    <div>
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regreso" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regreso_Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_Volver" Text="Volver al inicio" CssClass="boton_texto_dentro" OnClick="lb_Volver_Click" /></td>
                        </tr></table></div>
                                <table class="centrado" style="text-align:center;"><tr><td>
                    <div>
                        <div class="titulocategoria" style="text-align:center;padding-top:20px">Alumnos del grupo: <asp:Label runat="server" ID="lbl_grupo" Font-Bold="true"></asp:Label></div>

                        <div class="tituloceldaNegrita" style="text-align:center;padding-top:20px">Tutor del grupo: <asp:Label runat="server" ID="lbl_tutor" Font-Bold="true"></asp:Label></div>

                        <div class="titulocelda" style="text-align:center; padding: 20px;">Haga click en la matrícula del alumno para ver mas detalles</div>
                        <div>
                            <asp:GridView runat="server" ID="gv_alumnos" AutoGenerateColumns="false" GridLines="None" RowStyle-CssClass="gvrow" HorizontalAlign="center"
                                style="border:solid 1px #ccc" CellSpacing="0" CellPadding="10" HeaderStyle-CssClass="gvheader">
                                <AlternatingRowStyle CssClass="gvrow_alt" />
                                <Columns>
                                    <asp:BoundField DataField="numero" HeaderText="NO." SortExpression="num"/>
                                    <asp:TemplateField HeaderText="MATRICULA">
                                        <ItemTemplate>
                                            <div>   
                                                <asp:LinkButton runat="server" ID="lb_matricula" Text='<%# Bind("matricula")%>' CssClass="texto_boton_gv" OnClick="lb_matricula_Click" CommandArgument='<%# Bind("matricula")%>'>

                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="apellido_pat" HeaderText="PRIMER APELLIDO" SortExpression="PRIMER APELLIDO"/>
                                    <asp:BoundField DataField="apellido_mat" HeaderText="SEGUNDO APELLIDO" SortExpression="SEGUNDO APELLIDO" />
                                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE" SortExpression="NOMBRE"/>
                                    <asp:BoundField DataField="estatus" HeaderText="ESTATUS" SortExpression="ESTATUS"/>
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div> 
                    </div>
                </asp:View>  
                <asp:View runat="server" ID="v_tres">
                    <div>
                       <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_back_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_back__Click"/></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                        <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_continuar" Text="Continuar" CssClass="boton_texto_dentro" ValidationGroup="group" OnClick="lb_continuar_Click" /></td>
                        </tr></table></div>

                    <div style="padding-top:30px; text-align:center" class="titulocategoria">Agregando grupos a la carrera <strong><asp:Label runat="server" ID="lbl_carr"></asp:Label></strong></div>
                    <div style="text-align:center">Selecciona cuantos grupos deseas agregar a la carrera y a que turno las agregarás
                        <br />*En este espacio solo se agregara grupos de 1er grado
                    </div>

                    <div style="padding-top:30px">
                        <table class="centrado" style="width:30%">
                            <tr><td>No. de grupos</td><td>Turno</td></tr>
                            <tr>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddl_grupos" CssClass="ddlreg">
                                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddl_grupos" ErrorMessage="¡Es necesario elegir el no. de grupos!" Display="None"
                                         ControlToValidate="ddl_grupos" SetFocusOnError="true" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_ddl_grupos" runat="server" TargetControlID="rfv_ddl_grupos" CloseImageUrl="../img/close_coe.png" 
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddl_turno" CssClass="ddlreg">
                                        <asp:ListItem Text="Selecciona..." Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Matutino" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Vespertino" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddl_turno" ErrorMessage="¡Es necesario elegir el turno!" Display="None"
                                         ControlToValidate="ddl_turno" SetFocusOnError="true" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vcoe_rfv_ddl_turno" runat="server" TargetControlID="rfv_ddl_turno" CloseImageUrl="../img/close_coe.png" 
                                        CssClass="customCalloutStyle" WarningIconImageUrl="../img/alert_yel.png" Enabled="True"></ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </div>

                    
                </asp:View>
                <asp:View runat="server" ID="v_cuatro">
                     <div class="topbar"><table><tr><td><asp:ImageButton ID="ib_regresar_" runat="server" ImageUrl="~/img/arrowback.png" OnClick="ib_regresar__Click" /></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
                                  
                                    <td style="font-size: 1.5em;">
                                        <asp:LinkButton ID="lb_regresar_" runat="server" CssClass="boton_texto_dentro" Text="Volver al inicio" OnClick="lb_regresar__Click" />
                         </td>
                                    </tr></table></div>           

                                   
                                <div style="text-align: center" class="centrado">
                                    <div style="padding-top:150px;"><asp:Image runat="server"  ID="imgExito" ImageUrl="~/img/ok_green.png" ImageAlign="AbsMiddle"/></div>
                                    <div class="titulocategoria" style="text-align:center">:) Completado!</div>
                                    <div class="titulocelda" style="text-align:center">Se ha completado el registro correctamente en el sistema!
                                        
                                </div></div>
               
                 </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

