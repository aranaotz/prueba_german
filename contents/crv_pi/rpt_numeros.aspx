﻿<%@ Page Title="" Language="VB" MasterPageFile="~/contents/masters/user.master" AutoEventWireup="false" CodeFile="rpt_numeros.aspx.vb" Inherits="contents_crv_pi_rpt_numeros" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_start" Runat="Server">
    <div>
        <CR:CrystalReportViewer ID="crv_numeros" runat="server" AutoDataBind="true" HasCrystalLogo="False" />
    </div>
</asp:Content>
