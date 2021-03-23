<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Mishoteles.aspx.cs" Inherits="Vew_Mishoteles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }
        .auto-style17 {
            width: 85%;
            margin-left: auto;
            margin-right: auto;
            color: #ffffff;
        }
        .auto-style18 {
            text-align: center;
            background: #0056FF;
        }
        .GridView1{
            margin-left: auto;
            margin-right: auto;
            background: #808080;
            border: 2px solid #ffffff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tr>
            <td>
                <div class="auto-style17">
                    <table class="auto-style16">
                        <tr>
                            <td class="auto-style18">
                                <h1>MIS HOTELES</h1>
                                <p>
                                    USUARIO:
                                    <asp:Label ID="L_Usuario" runat="server"></asp:Label>
                                &nbsp;</p>
                                <p>
                                    <asp:Label ID="L_IdUsuario" runat="server"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                <br />
                                <asp:GridView ID="GV_Mishoteles" class="GridView1" runat="server" Height="105px" Width="263px" AutoGenerateColumns="False" DataSourceID="ODS_Mishoteles" DataKeyNames="Idhotel" OnSelectedIndexChanged="GV_Mishoteles_SelectedIndexChanged" OnRowCommand="GV_Mishoteles_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="Numhabitacion" HeaderText="Numhabitacion" SortExpression="Numhabitacion" />
                                        <asp:BoundField DataField="Precionoche" HeaderText="Precionoche" SortExpression="Precionoche" />
                                        <asp:BoundField DataField="PrecioNocheDoble" HeaderText="PrecioDoble" SortExpression="PrecioNocheDoble" />
                                        <asp:BoundField DataField="PrecioNochePremium" HeaderText="PrecioPremium" SortExpression="PrecioNochePremium" />
                                        <asp:BoundField DataField="Checkin" HeaderText="Checkin" SortExpression="Checkin" />
                                        <asp:BoundField DataField="Checkout" HeaderText="Checkout" SortExpression="Checkout" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:CommandField HeaderText="Eliminar Hotel" ShowDeleteButton="True" SortExpression="Idhotel" />
                                        <asp:BoundField DataField="Idhotel" HeaderText="Idhotel" SortExpression="Idhotel" Visible="False" />
                                        <asp:CommandField SelectText="Añadir" ShowSelectButton="True" HeaderText="Añadir habitación" />
                                        <asp:ButtonField CommandName="reservashotel" HeaderText="Reservas/hotel" Text="Ver reservas"  />
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <br />
                                    <asp:Button ID="B_GenerarReporte" runat="server" OnClick="B_GenerarReporte_Click" Text="GENERAR REPORTE" />
                                    <br />
                                    <br />
                                    <asp:Button ID="B_Volver" runat="server" OnClick="B_Volver_Click" Text="VOLVER" />
                                <br />
                                </div>
                                <asp:ObjectDataSource ID="ODS_Mishoteles" runat="server" SelectMethod="obtenerHoteles" TypeName="Logica.Listas" DataObjectTypeName="Utilitarios.UHotel" DeleteMethod="eliminarHotelTabla">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="session" SessionField="usuario" Type="Object" />
                                        
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

