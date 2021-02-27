<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Registro.aspx.cs" Inherits="Vew_Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }

        .auto-style17 {
            width: 80%;
            height: 608px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 15px;
            background: #0040BD;
            color: #ffffff;
        }

        .auto-style18 {
            height: 173px;
            text-align: center;
        }

        .auto-style19 {
            width: 85%;
            height: 398px;
            background: #0056FF;
        }

        .auto-style20 {
            text-align: center;
            height: 39px;
        }

        .auto-style21 {
            width: 50%;
        }

        .auto-style22 {
            width: 100%;
            height: 108px;
        }

        .auto-style23 {
            width: 324px;
            height: 131px;
        }

        .auto-style24 {
            height: 131px;
        }

        #HyperLink1 {
            text-decoration: none;
            color: #ffffff;
        }

        .auto-style25 {
            margin-top: 15px;
            height: 41px;
        }
        .auto-style26 {
            color: #000000;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="auto-style16">
        <tr>
            <td class="auto-style18">
                <div class="auto-style17">
                    <table align="center" class="auto-style19">
                        <tr>
                            <td colspan="2" class="auto-style25">
                                <br />
                                <span class="auto-style26"><em><strong>REGíSTRESE EN OCCIBANA</strong></em></span><br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style21">
                                <br />
                                REGISTRE SU/S
                                NOMBRE/S<br />
                                <br />
                                <asp:TextBox ID="TB_nombre" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_Nombre" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ValidationGroup="TB_registro"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="REV_TB_Nombre" runat="server" ControlToValidate="TB_nombre" ErrorMessage="Caracter no valido" ValidationExpression="[A-Za-z ]+" ValidationGroup="TB_registro"></asp:RegularExpressionValidator>
                                <br />
                            </td>
                            <td>
                                <br />
                                NUM DE TELÉFONO<br />
                                <br />
                                <asp:TextBox ID="TB_telefono" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_Telefono" runat="server" ControlToValidate="TB_telefono" ErrorMessage="*" ValidationGroup="TB_registro"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TB_telefono" ErrorMessage="Caracter no valido" ValidationExpression="[0-9+ ]+" ValidationGroup="TB_registro"></asp:RegularExpressionValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style21">
                                <br />
                                REGISTRE SU/S
                                APELLIDO/S<br />
                                <br />
                                <asp:TextBox ID="TB_apellido" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_Apellido" runat="server" ControlToValidate="TB_apellido" ErrorMessage="*" ValidationGroup="TB_registro"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TB_apellido" ErrorMessage="Caracter no valido" ValidationExpression="[A-Za-z ]+" ValidationGroup="TB_registro"></asp:RegularExpressionValidator>
                                <br />
                            </td>
                            <td>
                                <br />
                                NOMBRE DE USUARIO<br />
                                <br />
                                <asp:TextBox ID="TB_usuarioregistro" runat="server" MaxLength="10"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RFV_NomUsuario" runat="server" ControlToValidate="TB_usuarioregistro" ErrorMessage="*" ValidationGroup="TB_registro"></asp:RequiredFieldValidator>

                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TB_usuarioregistro" ErrorMessage="Caracter no valido" ValidationExpression="[A-Za-z0-9]+" ValidationGroup="TB_registro"></asp:RegularExpressionValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23">
                                <br />
                                REGISTRE SU
                                CORREO 
                                <br />
                                ELECTRÓNICO<br />
                                <br />
                                <asp:TextBox ID="TB_correo" runat="server" TextMode="Email" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_Correo" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ValidationGroup="TB_registro"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td class="auto-style24">
                                <br />
                                <br />
                                <table class="auto-style22">
                                    <tr>
                                        <td>
                                            <br />
                                            REGISTRE SU<br />
                                            CONTRSEÑA<br />
                                            <asp:TextBox ID="TB_contrasenaregistro" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TB_contrasenaregistro" ErrorMessage="*" ValidateRequestMode="Enabled" ValidationGroup="TB_registro"></asp:RequiredFieldValidator>

                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TB_contrasenaregistro" ErrorMessage="Caracter no valido" ValidationExpression="[A-Za-z0-9]+" ValidationGroup="TB_registro"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                        <td>
                                            <br />
                                            CONFIRMAR<br />
                                            CONTRASEÑA<br />
                                            <asp:TextBox ID="TB_ccontrasena" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TB_ccontrasena" ErrorMessage="*" ValidateRequestMode="Enabled" ValidationGroup="TB_registro"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_ConfirmarContra" runat="server" ControlToValidate="TB_ccontrasena" ErrorMessage="Caracter no valido" ValidationExpression="[A-Za-z0-9]+" ValidationGroup="TB_registro"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                &nbsp;<asp:CompareValidator ID="CV_contraseñas" runat="server" ControlToCompare="TB_contrasenaregistro" ControlToValidate="TB_ccontrasena" ErrorMessage="*Las contraseñas deben ser idénticas" ValidationGroup="TB_registro"></asp:CompareValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20" colspan="2">
                                <br />
                                <asp:Button ID="B_Registrar" runat="server" Text="REGISTRARME" OnClick="B_Registrar_Click" Height="24px" ValidationGroup="TB_registro" />
                                <br />
                                <asp:Label ID="L_fallo" runat="server"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Vew/Login.aspx" Font-Size="Small" Font-Underline="True" ForeColor="White">YA ESTOY REGISTRADO, QUIERO INICIAR SESION</asp:HyperLink>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

