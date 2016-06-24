<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="desactivado.aspx.vb" Inherits="contents_desactivado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <div>
        
        <div style="padding:80px 80px 80px 80px">
            <asp:Image runat="server" ID="img_alert" ImageUrl="~/img/logosolo.png" ImageAlign="Middle"  />
        </div>
        <div style="text-align:center" class="titulocategoria">
            Actualmente estas fuera del periodo del registro.! <br /> El sistema estará abierto a partir del dia: <strong><asp:Label runat="server" ID="lbl_desactivado"></asp:Label></strong>
        </div>
    </div>
</asp:Content>

