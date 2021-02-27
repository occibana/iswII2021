<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Perfil.aspx.cs" Inherits="Vew_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 85%;
            margin-left: auto;
            margin-right: auto;
            color: #ffffff;
        }
        .auto-style17 {
            width: 100%;
            height: 692px;
            margin-left: auto;
            margin-right: auto;
            background: #0056FF;
        }
        .auto-style18 {
            text-align: center;
        }
        .auto-style19 {
            text-align: center;
            width: 567px;
        }
        .auto-style20 {
            text-align: right;
        }
        .auto-style21 {
            width: 250px;
        }
        .auto-style22 {
            width: 90%;
            height: 500px;
            background: #0040BD;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style23 {
            width: 100%;
            height: 479px;
        }
        .auto-style24 {
            text-align: center;
            height: 225px;
        }
        .auto-style25 {
            font-size: xx-large;
        }
        .auto-style26 {
            width: 90%;
            margin-right: auto;
            margin-left: auto;
        }
        .auto-style27 {
            width: 180px;
        }
        .auto-style28 {
            width: 404px;
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
                            <td class="auto-style19">
                                <h1 class="auto-style25">BIENVENIDO USUARIO</h1>
                            </td>
                            <td class="auto-style18">
                                <asp:Button ID="B_AgregarHotel" runat="server" Height="31px" Text="AGREGAR HOTEL" Width="136px" OnClick="B_AgregarHotel_Click" />
                                <br />
                                <asp:Button ID="B_mishoteles" runat="server" OnClick="B_mishoteles_Click" Text="MIS HOTELES" Width="136px"/>
                                <br />
                                <asp:Button ID="B_Misreservas" runat="server" OnClick="B_Misreservas_Click" Text="MIS RESERVAS" Width="136px" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table class="auto-style16">
                            <tr>
                                <td class="auto-style21">
                                    <table class="auto-style16">
                                        <tr>
                                            <td>
                                                <asp:Image ID="fotoperfil" runat="server" Height="216px" Width="247px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style24">
                                                <asp:Label ID="L_Pcargaimagen" runat="server"></asp:Label>
                                                <br />
                                                <asp:FileUpload ID="FU_FotoPerfil" runat="server" />
                                                <br />
                                                <br />
                                                <asp:Button ID="B_SubirFoto" runat="server" Text="SUBIR FOTO" OnClick="B_SubirFoto_Click" />
                                                <br />
                                                <br />
                                                SESIÓN:
                                                <br />
                                                <asp:Label ID="L_Pusuario" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                                ESTADO DE LA MEMBRESIA:<br />
                                                <asp:Label ID="L_EstadoMembresia" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                <asp:Button ID="B_ComprarMembresia" runat="server" Text="COMPRAR MEMBRESIA" Width="189px" Height="29px" OnClick="B_ComprarMembresia_Click" />
                                                <br />
                                                <br />
                                                <asp:Button ID="B_ActualizarMembresia" runat="server" Height="31px" Text="ACTUALIZAR MEMBRESÍA" Width="197px" OnClick="B_ActualizarMembresia_Click" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="auto-style28">
                                    <div class="auto-style22">
                                        <table class="auto-style23">
                                            <tr>
                                                <td>
                                                    <table class="auto-style26">
                                                        <tr>
                                                            <td class="auto-style18" colspan="2">
                                                    <br />
                                                                <strong>DATOS PERSONALES</strong><br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">
                                                                <br />
                                                    NOMBRE<br />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="L_Pnombre" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">
                                                                <br />
                                                    CORREO<br />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="L_Pcorreo" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">
                                                                <br />
                                                    TELÉFONO<br />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="L_Ptelefono" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">
                                                                <br />
                                                    USUARIO<br />
                                                            </td>
                                                            <td>
                                                <asp:Label ID="L_Pusuariodatospersonales" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18">
                                                    <asp:Button ID="B_ActualizarDatos" runat="server" Height="31px" Text="EDITAR MIS DATOS" Width="197px" OnClick="B_ActualizarDatos_Click"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18">
                                                    <br />
                                                    <br />
                                                    <strong>SEGURIDAD</strong><br />
                                                    <br />
                                                    <asp:Button ID="B_CambiarContrasena" runat="server" Height="33px" Text="CAMBIAR CONTRASEÑA" Width="197px" OnClick="B_CambiarContrasena_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18">
                                                    <br />
                                                    REPORTE ACTIVIDAD DE LA CUENTA<br />
                                                    <asp:Button ID="B_VerReporte" runat="server" OnClick="B_VerReporte_Click" Text="VER REPORTE" Width="197px" />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20" colspan="2">
                                    <asp:Button ID="B_CerrarSession" runat="server" Height="31px" Text="CERRAR SESIÓN" Width="136px" OnClick="B_CerrarSession_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

