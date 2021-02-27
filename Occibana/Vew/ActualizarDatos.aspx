<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/ActualizarDatos.aspx.cs" Inherits="Vew_ActualizarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }
        .auto-style17 {
            width: 85%;
            margin-left: auto;
            margin-right: auto;
            
            background: #0040BD;
            
        }
        .auto-style18 {
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 15px;
            margin-bottom: 15px;
            background: #0056FF;
            color: #ffffff;
        }
        .auto-style19 {
            text-align: center;
        }
        .auto-style20 {
            text-align: center;
            width: 350px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tr>
            <td>
                <div class="auto-style17">
                            <table class="auto-style18" __designer:mapid="1e">
                                <tr __designer:mapid="1f">
                                    <td class="auto-style19" colspan="2" __designer:mapid="20">
                                <br __designer:mapid="21" />
                                        <asp:Label ID="L_Actusuario" runat="server"></asp:Label>
                                <br __designer:mapid="23" />
                                        ACTUALICE AQUÍ SUS DATOS PERSONALES<br __designer:mapid="24" />
                                <br __designer:mapid="25" />
                                    </td>
                                </tr>
                                <tr __designer:mapid="26">
                                    <td class="auto-style20" __designer:mapid="27">NOMBRE/S<br __designer:mapid="28" />
                                        <asp:Label ID="L_Actnombre" runat="server"></asp:Label>
                                <br __designer:mapid="2a" />
                                        <asp:TextBox ID="TB_Actnombre" runat="server" MaxLength="20"></asp:TextBox>
                                <br __designer:mapid="2c" />
                                        <asp:RegularExpressionValidator ID="REV_TB_Actnombre" runat="server" ControlToValidate="TB_Actnombre" ErrorMessage="Caracteres invalidos" ValidationExpression="[A-Za-z ]+" ValidationGroup="Actualizacionperfil"></asp:RegularExpressionValidator>
                                <br __designer:mapid="2e" />
                                    </td>
                                    <td class="auto-style19" __designer:mapid="2f">APELLIDO/S<br __designer:mapid="30" />
                                        <asp:Label ID="L_Actapellido" runat="server"></asp:Label>
                                <br __designer:mapid="32" />
                                        <asp:TextBox ID="TB_Actapellido" runat="server" MaxLength="20"></asp:TextBox>
                                <br __designer:mapid="34" />
                                        <asp:RegularExpressionValidator ID="REV_TB_Actapellido" runat="server" ControlToValidate="TB_Actapellido" ErrorMessage="Caracteres invalidos" ValidationExpression="[A-Za-z ]+" ValidationGroup="Actualizacionperfil"></asp:RegularExpressionValidator>
                                <br __designer:mapid="36" />
                                    </td>
                                </tr>
                                <tr __designer:mapid="37">
                                    <td class="auto-style20" __designer:mapid="38">CORREO ELECTRÓNICO<br __designer:mapid="39" />
                                        <asp:Label ID="L_Actcorreo" runat="server"></asp:Label>
                                <br __designer:mapid="3b" />
                                        <asp:TextBox ID="TB_Actcorreo" runat="server" TextMode="Email" MaxLength="30"></asp:TextBox>
                                <br __designer:mapid="3d" />
                                <br __designer:mapid="3e" />
                                    </td>
                                    <td class="auto-style19" __designer:mapid="3f">TELÉFONO<br __designer:mapid="40" />
                                        <asp:Label ID="L_Acttelefono" runat="server"></asp:Label>
                                <br __designer:mapid="42" />
                                        <asp:TextBox ID="TB_Acttelefono" runat="server" MaxLength="15"></asp:TextBox>
                                <br __designer:mapid="44" />
                                        <asp:RegularExpressionValidator ID="REV_TB_Acttelefono" runat="server" ControlToValidate="TB_Acttelefono" ErrorMessage="Caracteres invalidos" ValidationExpression="[0-9+ ]+" ValidationGroup="Actualizacionperfil"></asp:RegularExpressionValidator>
                                <br __designer:mapid="46" />
                                    </td>
                                </tr>
                                <tr __designer:mapid="47">
                                    <td class="auto-style20" __designer:mapid="48">USUARIO<br __designer:mapid="49" />
                                        <asp:Label ID="L_Actusuario0" runat="server"></asp:Label>
                                <br __designer:mapid="4b" />
                                        <asp:TextBox ID="TB_Actusuario" runat="server" MaxLength="10"></asp:TextBox>
                                <br __designer:mapid="4d" />
                                        <asp:RegularExpressionValidator ID="REV_TB_Actusuario" runat="server" ControlToValidate="TB_Actusuario" ErrorMessage="Caracteres invalidos" ValidationExpression="[A-Za-z0-9 ]+" ValidationGroup="Actualizacionperfil"></asp:RegularExpressionValidator>
                                <br __designer:mapid="4f" />
                                    </td>
                                    <td class="auto-style19" __designer:mapid="50">
                                        <asp:Label ID="LB_Actfallo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr __designer:mapid="52">
                                    <td class="auto-style20" __designer:mapid="53">
                                <br __designer:mapid="54" />
                                        <asp:Button ID="B_Volver" runat="server" Height="33px" OnClick="B_Volver_Click" Text="CANCELAR" Width="113px" />
                                <br __designer:mapid="56" />
                                <br __designer:mapid="57" />
                                    </td>
                                    <td class="auto-style19" __designer:mapid="58"><strong __designer:mapid="59">
                                        <asp:Button ID="B_Actualizar" runat="server" Height="33px" OnClick="B_Actualizar_Click" Text="ACTUALIZAR" ValidationGroup="Actualizacionperfil" Width="113px" />
                                        </strong></td>
                                </tr>
                            </table>
                    <br />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

