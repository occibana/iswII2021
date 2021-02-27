<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Reportes/ReporteHoteles/ReporteHoteles.aspx.cs" Inherits="Vew_Reportes_ReporteHoteles_ReporteHoteles" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="auto-style16">
        Bienvenido usuario:
        <asp:Label ID="L_NombreUsuario" runat="server"></asp:Label>
        <br />
    <CR:CrystalReportViewer ID="CRV_ReporteHoteles" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_ReporteHoteles" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
    </div>
    <CR:CrystalReportSource ID="CRS_ReporteHoteles" runat="server">
        <Report FileName="~\ReportesOccibana\CR_ReporteHoteles.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

