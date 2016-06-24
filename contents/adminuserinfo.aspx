<%@ Page Title="" Language="VB" MasterPageFile="../logins/logins.master" AutoEventWireup="false" CodeFile="adminuserinfo.aspx.vb" Inherits="contents_adminuserinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" Runat="Server">
   <div>
       <div class="topbar"><table><tr><td></td><td style="padding: 0px 10px 0px 10px; font-size: 2em; color: #fff; vertical-align: top;">|</td>
            <td style="font-size: 1.5em;"><asp:Linkbutton runat="server" ID="lb_guardar" Text="Guardar cambios" CssClass="boton_texto_dentro"/></td>
                                   </tr></table></div>
       <table class="centrado"><tr><td>
       <div class="titulocategoria">Datos de usuario</div></td></tr><tr><td>
       <div class="tituloceldaNegrita" style="padding-left:20px;">Información Personal</div></td></tr><tr><td>
       <div style="text-align:left; padding:40px;padding-right:40px;"><table style="width:80%">
           <tr><td>Nombre(s)</td><td>Apellido Paterno</td><td>Apellido Materno</td></tr>
           <tr><td><asp:TextBox runat="server" ID="txtNombre" CssClass="tbxreg"></asp:TextBox></td>
               <td><asp:TextBox runat="server" ID="txtApellidop" CssClass="tbxreg"></asp:TextBox></td>
               <td><asp:TextBox runat="server" ID="txtApellidom" CssClass="tbxreg"></asp:TextBox></td>

           </tr>
       </table>
           <table style="width:80%">
                <tr><td>Correo electronico personal</td></tr>
           <tr><td><asp:TextBox runat="server" ID="txtCPersonal" CssClass="tbxreg"></asp:TextBox></td></tr>    
           </table>
       </div></td></tr><tr><td>
       <div class="tituloceldaNegrita" style="padding-left:20px;">Información Institucional</div></td></tr><tr><td>
       <div style="text-align:left; padding:40px;padding-right:40px;"><table style="width:80%">
           <tr><td>Cargo</td><td>CClave Trabajador</td></tr>
           <tr><td><asp:TextBox runat="server" ID="txtCargo" CssClass="tbxreg"></asp:TextBox></td>
               <td><asp:TextBox runat="server" ID="txtClave" CssClass="tbxreg"></asp:TextBox></td></tr>
           </table>
           <table style="width:80%">
               <tr><td style="width:80%">Correo Institucional</td><td>Extensión</td></tr>
           <tr><td style="width:80%"><asp:TextBox runat="server" ID="txtCInsti" CssClass="tbxreg"></asp:TextBox></td>
               <td style="width:20%"><asp:TextBox runat="server" ID="txtExtension" CssClass="tbxreg"></asp:TextBox></td></tr>
           </table>
       </div></td></tr><tr><td>

       <div class="tituloceldaNegrita" style="padding-left:20px;">Información de la cuenta</div></td></tr><tr><td>
       <div style="text-align:left; padding:40px;padding-right:40px;"><table style="width:80%">
           <tr><td>Contraseña anterior</td><td>Nueva contraseña</td><td>Repetir contraseña contraseña</td></tr>
           <tr><td><asp:TextBox runat="server" ID="txtAntes" CssClass="tbxreg"></asp:TextBox></td>
               <td><asp:TextBox runat="server" ID="txtNueva" CssClass="tbxreg"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtRepetir" CssClass="tbxreg"></asp:TextBox></td>
           </tr>
                     </table></div></td></tr></table>

   </div>
</asp:Content>

