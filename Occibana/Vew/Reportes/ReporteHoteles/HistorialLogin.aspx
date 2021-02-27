<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Reportes/ReporteIngresos/HistorialLogin.aspx.cs" Inherits="Vew_Reportes_ReporteHoteles_HistorialLogin" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="auto-style16">
        <br />
        BIENVENIDO:
        <asp:Label ID="L_NombreUsuario" runat="server"></asp:Label>
        <br />
        <br />
        <CR:CrystalReportViewer ID="CRV_HistorialLogin" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_HistorialLogin" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
        <CR:CrystalReportSource ID="CRS_HistorialLogin" runat="server">
            <Report FileName="~\ReportesOccibana\CR_HistorialLogin.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
</asp:Content>

