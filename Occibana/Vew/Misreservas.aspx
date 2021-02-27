<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Misreservas.aspx.cs" Inherits="Vew_Misreservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }
        .auto-style17 {
            width: 80%;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style18 {
            text-align: center;
            background: #0056FF;
        }
        #Gridmisreservas{
            background: #0040BD;
        }
        .auto-style19 {
            text-align: center;
            color: azure;
        }
        .auto-style20 {
            text-align: center;
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
                            <td class="auto-style18">RESERVAS REALIZADAS POR:
                                <asp:Label ID="L_Usuario" runat="server"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td id="Gridmisreservas" class="auto-style20">
                                <div class="auto-style19">
                                <asp:GridView ID="GV_Mishoteles" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_MisReservas" Width="591px" OnRowCommand="GV_Mishoteles_RowCommand" DataKeyNames="Id">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                        <asp:BoundField DataField="Numpersona" HeaderText="Numpersona" SortExpression="Numpersona" />
                                        <asp:BoundField DataField="Fecha_llegada" HeaderText="Fecha_llegada" SortExpression="Fecha_llegada" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Fecha_salida" HeaderText="Fecha_salida" SortExpression="Fecha_salida" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                        <asp:BoundField DataField="Mediopago" HeaderText="Mediopago" SortExpression="Mediopago" />
                                        <asp:BoundField DataField="Calificacion" HeaderText="Calificacion" SortExpression="Calificacion" Visible="False" />
                                        <asp:BoundField DataField="Nombrehotel" HeaderText="Nombrehotel" SortExpression="Nombrehotel" />
                                        <asp:BoundField DataField="Calificacion" HeaderText="Calificacion" SortExpression="Calificacion" />
                                        <asp:ButtonField CommandName="calificarreserva" HeaderText="Calificar y comentar" Text="calificar/comentar" >
                                        <ControlStyle BackColor="#999999" BorderColor="#999999" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="Idhotel" HeaderText="Idhotel" SortExpression="Idhotel" Visible="False" />
                                        <asp:ButtonField CommandName="cancelarreserva" HeaderText="Cancelar reserva" Text="Cancelar">
                                        <ControlStyle BackColor="#FF3300" />
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                                <br />
                                <asp:ObjectDataSource ID="ODS_MisReservas" runat="server" SelectMethod="mostrarmisreservas" TypeName="DAOReserva">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="disponibilidadE" SessionField="usuario" Type="Object" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:Button ID="B_ReporteReservas" runat="server" Text="Generar reporte" OnClick="B_ReporteReservas_Click" />
                                <br />
                                <br />
                                <asp:Button ID="B_Volver" runat="server" Text="VOLVER" OnClick="B_Volver_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

