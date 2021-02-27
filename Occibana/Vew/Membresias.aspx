<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Membresias.aspx.cs" Inherits="Vew_Membresias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }
        .auto-style17 {
            background: #0056FF;
            color: #ffffff;
            width: 85%;
            text-align: center;
            margin-left: auto;
            margin-right: auto;

        }
        .auto-style18 {
            background: #0040BD;
            color: #ffffff;
            width: 75%;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style20 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tr>
            <td>
                <div class="auto-style17">
                    <br />
                    <asp:Label ID="L_Actualizar_Comprar" runat="server" CssClass="auto-style20"></asp:Label>
                    <br />
                    <br />
                    <div class="auto-style18">
                        <table class="auto-style16">
                            <tr>
                                <td>
                                    <table class="auto-style16">
                                        <tr>
                                            <td>
                                                <br />
                                                Numero de tarjeta<br />
                                                <asp:TextBox ID="TB_Numerotarjeta" runat="server" TextMode="Number" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_TB_Numerotarjeta" runat="server" ControlToValidate="TB_Numerotarjeta" ErrorMessage="*" ValidationGroup="compramembresia"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RangeValidator ID="RV_TB_Numerotarjeta" runat="server" ControlToValidate="TB_Numerotarjeta" ErrorMessage="Numero no valido" MaximumValue="999999999999999999" MinimumValue="10000000000000" ValidationGroup="compramembresia"></asp:RangeValidator>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                Código de seguridád<br />
                                                <asp:TextBox ID="TB_Codigoseguridad" runat="server" TextMode="Number" MaxLength="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_TB_Codigoseguridad" runat="server" ErrorMessage="*" ValidationGroup="compramembresia" ControlToValidate="TB_Codigoseguridad"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RangeValidator ID="RV_TB_Codigoseguridad" runat="server" ControlToValidate="TB_Codigoseguridad" ErrorMessage="Numero no valido" MaximumValue="9999" MinimumValue="1000" ValidationGroup="compramembresia"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="auto-style16">
                                        <tr>
                                            <td>
                                                <br />
                                                Nombre<br />
                                                (Propietario de la tarjeta)<br />
                                                <asp:TextBox ID="TB_Nombrepropietario" runat="server" MaxLength="15"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_TB_Nombreppropietario" runat="server" ErrorMessage="*" ValidationGroup="compramembresia" ControlToValidate="TB_Nombrepropietario"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Nombrepropietario" runat="server" ControlToValidate="TB_Nombrepropietario" ErrorMessage="caracteres no validos" ValidationExpression="[A-Za-zñ ]+" ValidationGroup="compramembresia"></asp:RegularExpressionValidator>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                Direccion de residencia<br />
                                                <asp:TextBox ID="TB_Direccionpropietario" runat="server" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_TB_Direccionpropietario" runat="server" ErrorMessage="*" ValidationGroup="compramembresia" ControlToValidate="TB_Direccionpropietario"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Direccionpropietario" runat="server" ControlToValidate="TB_Direccionpropietario" ErrorMessage="caracteres no validos" ValidationExpression="[A-Za-z1-9# ]+" ValidationGroup="compramembresia"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <br />
                                                Cedula de ciudadania<br />
                                                (Propietario de la tarjeta)<br />
                                                <asp:TextBox ID="TB_cedulapropietario" runat="server" MaxLength="12"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_TB_Cedulapropietario" runat="server" ErrorMessage="*" ValidationGroup="compramembresia" ControlToValidate="TB_cedulapropietario"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_cedulapropietario" runat="server" ControlToValidate="TB_cedulapropietario" ErrorMessage="caracteres no validos" ValidationExpression="[0-9]+" ValidationGroup="compramembresia"></asp:RegularExpressionValidator>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table class="auto-style16">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                Verifique su usuario y contraseña <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                Usuario<br />
                                                <asp:TextBox ID="TB_Usuario" runat="server" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_TB_Usuario" runat="server" ErrorMessage="*" ValidationGroup="compramembresia" ControlToValidate="TB_Usuario"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Usuario" runat="server" ControlToValidate="TB_Usuario" ErrorMessage="caracteres no validos" ValidationExpression="[A-Za-z1-9]+" ValidationGroup="compramembresia"></asp:RegularExpressionValidator>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                Contraseña<br />
                                                <asp:TextBox ID="TB_Contrasena" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_TB_Contrasena" runat="server" ErrorMessage="*" ValidationGroup="compramembresia" ControlToValidate="TB_Contrasena"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Contrasena" runat="server" ControlToValidate="TB_Contrasena" ErrorMessage="caracteres no validos" ValidationExpression="[A-Za-z0-9]+" ValidationGroup="compramembresia"></asp:RegularExpressionValidator>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br />
                                    Tipos de tarjetas validas:<br />
&nbsp;<asp:Image ID="I_Tiposdetarjeta" runat="server" Height="48px" Width="102px" ImageUrl="~/Vew/img/visa_mastercard.jpg" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="B_comprar" runat="server" Text="COMPRAR" OnClick="B_comprar_Click" ValidationGroup="compramembresia" />
                                    <br />
                                    <br />
                                    <asp:Button ID="B_Volver" runat="server" OnClick="B_Volver_Click" Text="VOLVER AL PERFIL" />
                                    <br />
                                    <br />
                                    <asp:Label ID="L_error" runat="server"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <asp:Label ID="L_Mensajecompra" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="L_Costo" runat="server"></asp:Label>
&nbsp;Costo anual (vence el
                    <asp:Label ID="L_vencimiento" runat="server"></asp:Label>
&nbsp;)</div>
            </td>
        </tr>
    </table>
</asp:Content>

