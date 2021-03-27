<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Reservas.aspx.cs" Inherits="Vew_Reservas" %>

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
            color: #ffffff;
        }
        #GV_Reservas{
            margin-right: auto;
            margin-left: auto;
            color: #ffffff;
            background: #808080;
        }
        .auto-style19 {
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
                            <td class="auto-style18">RESERVAS REALIZADAS EN EL HOTEL:&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="L_Nombrehotel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                <br />
                                RESERVAS POR EFECTUAR<br />
                                <br />
                                <div class="auto-style19">
                                <asp:GridView ID="GV_Reservas" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Reservas">
                                    <Columns>
                                        <asp:BoundField DataField="Numpersona" HeaderText="Numpersona" SortExpression="Numpersona" />
                                        <asp:BoundField DataField="Fecha_llegada" HeaderText="Fecha_llegada" SortExpression="Fecha_llegada" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Fecha_salida" HeaderText="Fecha_salida" SortExpression="Fecha_salida" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                    </Columns>
                                </asp:GridView>
                                </div>
                                <asp:ObjectDataSource ID="ODS_Reservas" runat="server" SelectMethod="mostrarreservas" TypeName="Logica.Listas">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="disponibilidadE" SessionField="tabla" Type="Object" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                RESERVAS REALIZADAS<br />
                                <br />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_ReservasPasadas">
                                    <Columns>
                                        <asp:BoundField DataField="Numpersona" HeaderText="Numpersona" SortExpression="Numpersona" />
                                        <asp:BoundField DataField="Fecha_llegada" HeaderText="Fecha_llegada" SortExpression="Fecha_llegada" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Fecha_salida" HeaderText="Fecha_salida" SortExpression="Fecha_salida" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                        <asp:BoundField DataField="Mediopago" HeaderText="Mediopago" SortExpression="Mediopago" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ODS_ReservasPasadas" runat="server" SelectMethod="mostrarreservascompletadas" TypeName="Logica.Listas">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="disponibilidadE" SessionField="tabla" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

