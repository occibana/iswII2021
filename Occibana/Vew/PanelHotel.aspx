<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/PanelHotel.aspx.cs" Inherits="Vew_PanelHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
            border: 1px solid #ffffff;
        }
        .auto-style17 {
            width: 85%;
            margin-right: auto;
            margin-right: auto;
            margin-top: 15px;
            margin-left: 97px;
            background: #0040BD;
            color: #ffffff;
        }
        .auto-style18 {
            width: 310px;
            text-align: center;
            height: 217px;
        }
        .auto-style19 {
            width: 196px;
        }
        .auto-style20 {
            text-align: center;
            background: #ffffff;
            color: black;
        }
        .auto-style21 {
            width: 196px;
            height: 23px;
        }
        .auto-style22 {
            height: 23px;
        }
        .auto-style23 {
            text-align: left;
            background: #ffffff;
        }
        .auto-style24 {
            text-align: center;
            background: #00A6FF;
        }
        .auto-style25 {
            height: 217px;
        }
        .auto-style26 {
            font-size: x-large;
        }
        .datalistdiv{
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            background: #ff0000;
        }
        .auto-style27 {
            height: 61px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <table class="auto-style16">
        <tr>
            <td>
                <div class="auto-style17">
                    <table class="auto-style16">
                        <tr>
                            <td class="auto-style20" colspan="2">
                                <asp:Label ID="L_Panelhotelnombre" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                <asp:Image ID="I_Panelimagenprincipal" runat="server" Height="213px" Width="279px" ImageUrl="~/Vew/img/hotelvacio.png" />
                            </td>
                            <td class="auto-style25">
                                <table class="auto-style16">
                                    <tr>
                                        <td class="auto-style19">MUNICIPIO:</td>
                                        <td>
                                            <em>
                                <asp:Label ID="L_Panelhotelmunicipio" runat="server" CssClass="auto-style26"></asp:Label>
                                            </em>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style19">ZONA:</td>
                                        <td>
                                            <em>
                                <asp:Label ID="L_Panelhotelzona" runat="server" CssClass="auto-style26"></asp:Label>
                                            </em>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style21">PRECIO/NOCHE<br />
                                            BASICA:</td>
                                        <td class="auto-style22">
                                            <em>
                                <asp:Label ID="L_Panelhotelprecio" runat="server" CssClass="auto-style26"></asp:Label>
                                            </em>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style19">PRECIO/NOCHE<br />
                                            DOBLE:</td>
                                        <td>
                                            <em>
                                            <asp:Label ID="L_PanelHotelPrecioDoble" runat="server" CssClass="auto-style26"></asp:Label>
                                            </em>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style19">PRECIO/NOCHE<br />
                                            PREMIUM:</td>
                                        <td>
                                            <em>
                                            <asp:Label ID="L_PanelHotelPrecioPremium" runat="server" CssClass="auto-style26"></asp:Label>
                                            </em>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style19">CALIFICACIÓN:</td>
                                        <td>
                                            <em>
                                <asp:Label ID="L_Panelhotelcalificacion" runat="server" CssClass="auto-style26"></asp:Label>
                                            </em>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23" colspan="2">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:Button ID="B_Desc_Reserva" runat="server" Text="Descripcion y reservas" OnClick="B_Desc_Reserva_Click"/>
                                &nbsp;<asp:Button ID="B_Comentarios" runat="server" Text="Comentarios" OnClick="B_Comentarios_Click"/>
                            </td>
                        </tr>
                        <%--<tr>--%>
                            <td class="auto-style24" colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <strong>
                                        <br />
                                        <asp:Button ID="B_Volver0" runat="server" OnClick="B_Volver_Click" Text="VOLVER" Width="100px" />
                                        <br />
                                        <br />
                                        HABITACIONES<br />
                                        <br />
                                        <div class="datalistdiv">
                                            <strong>
                                            <asp:DataList ID="DL_Habitaciones" runat="server" DataSourceID="ODS_Habitaciones" Width="100%" OnItemCommand="DL_Habitaciones_ItemCommand">
                                                <ItemTemplate>
                                                    <div>
                                                        <table class="auto-style16">
                                                            <tr>
                                                                <td colspan="3" class="auto-style27">
                                                                    <br />
                                                                    TIPO HABITACIÓN:
                                                                    <asp:Label ID="L_Tipo" runat="server" Text='<%# Eval("Tipo") %>'></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                    NUMERO DE PERSONAS:<asp:Label ID="L_NumPersonas" runat="server" Text='<%# Eval("Numpersonas") %>'></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td>
                                                                    <br />
                                                                    NUMERO DE CAMAS:<asp:Label ID="L_NumCamas" runat="server" Text='<%# Eval("Numcamas") %>'></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td>
                                                                    <br />
                                                                    CANTIDAD DE BAÑOS:<asp:Label ID="L_NumBanos" runat="server" Text='<%# Eval("Numbanio") %>'></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>PRECIO NOCHE:<br />
                                                                    <asp:Label ID="L_Precio" runat="server" Text='<%# Eval("Precio") %>'></asp:Label>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Button ID="B_Reservar" runat="server" Text="REALIZAR RESERVA !" Width="440px" CommandArgument='<%# Eval("Id") %>'/>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            </strong>
                                            &nbsp;&nbsp;
                                        </div>
                                        <br />
                                        <asp:ObjectDataSource ID="ODS_Habitaciones" runat="server" SelectMethod="habitacionesHotel" TypeName="Logica.Listas">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="idE" SessionField="visitarhotel" Type="Object" />
                                                <asp:Parameter Name="consulta" Type="Object" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <br />
                                        <asp:Button ID="B_Volver" runat="server" OnClick="B_Volver_Click" Text="VOLVER" Width="100px" />
                                        <br />
                                        <br />
                                        <table class="auto-style16">
                                            <tr>
                                                <td colspan="2">DIRECCIÓN<br /> <strong>
                                                    <br />
                                                    <asp:Label ID="L_Direccion" runat="server"></asp:Label>
                                                    <br />
                                                    <br />
                                                    DESCRIPCIÓN Y SERVICIOS<br />
                                                    <br />
                                                    <asp:Label ID="L_Descripcion" runat="server" CssClass="auto-style26"></asp:Label>
                                                    <br />
                                                    </strong></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><strong>
                                                    <br />
                                                    CONDICIONES FISICAS<br />
                                                    <br />
                                                    <asp:Label ID="L_Condicion" runat="server" CssClass="auto-style26"></asp:Label>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    HORARIOS DE REGISTRO</strong></td>
                                            </tr>
                                            <tr>
                                                <td><strong>
                                                    <br />
                                                    CHECK-IN<br />
                                                    <br />
                                                    <asp:Label ID="L_Checkin" runat="server" CssClass="auto-style26"></asp:Label>
                                                    <br />
                                                    </strong></td>
                                                <td><strong>
                                                    <br />
                                                    CHECK-OUT<br />
                                                    <br />
                                                    <asp:Label ID="L_Checkout" runat="server" CssClass="auto-style26"></asp:Label>
                                                    <br />
                                                    </strong></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><strong>
                                                    <br />
                                                    HABITACIONES DISPONIBLES EN EL HOTEL (GENERAL)<br />
                                                    <br />
                                                    <asp:Label ID="L_Panelhotelhabitaciones" runat="server" CssClass="auto-style26"></asp:Label>
                                                    <br />
                                                    </strong></td>
                                            </tr>
                                        </table>
                                        </strong>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_Desc_Reserva" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>

 <!--<script type="text/javascript">
        $('#B_Reservar').click(function () {
            var tiempocarga = 2000;
            $.ajax({
                url: "DescripcionHotel.aspx",
                beforeSend: function () {
                    $('#B_Reservar').text('Cargando...');
                },
                succes: function (data) {
                    setTimeout(function () {
                        $('#B_Reservar').aspx(data);
                    }, tiempocarga
                    );
                }
            });
        });
    </script>-->
</asp:Content>

