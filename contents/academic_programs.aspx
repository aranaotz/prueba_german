<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="academic_programs.aspx.vb" Inherits="contents_academic_programs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <asp:UpdatePanel runat="server" ID="up_academic">
        <ContentTemplate>
            <asp:MultiView runat="server" id="mv_academic">
                <asp:View runat="server" ID="v_cero">
                    <div>
                        <div style="text-align:center;padding-top:20px" class="titulocategoria">Oferta académica</div>
                        <div style="text-align:center;padding-top:20px" class="titulocalda">Selecciona una carrera para ver la oferta académica disponible para ella</div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

