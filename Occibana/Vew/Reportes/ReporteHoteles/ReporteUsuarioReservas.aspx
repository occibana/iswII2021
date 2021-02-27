<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Reportes/ReporteHoteles/ReporteUsuarioReservas.aspx.cs" Inherits="Vew_Reportes_ReporteHoteles_ReporteUsuarioReservas" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            Bienvenido:&nbsp;
            <asp:Label ID="L_NombreUsuario" runat="server"></asp:Label>
            <CR:CrystalReportViewer ID="CRV_Reserva" runat="server" AutoDataBind="True" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_ReservasUsuario" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
            <CR:CrystalReportSource ID="CRS_ReservasUsuario" runat="server">
                <Report FileName="~\ReportesOccibana\CR_HistorialReservas.rpt">
                </Report>
            </CR:CrystalReportSource>
        </div>
    </form>
</body>
</html>
