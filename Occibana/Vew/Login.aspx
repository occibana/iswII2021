<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Login.aspx.cs" Inherits="Vew_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }

        .auto-style17 {
            width: 90%;
            height: 514px;
            text-align: center;
            background: #0056FF;
            margin-top: 15px;
            margin-right: auto;
            margin-left: auto;
            color: #ffffff;
        }

        .auto-style18 {
            width: 90%;
            height: 424px;
            margin-left: auto;
            margin-right: auto;
            color: #ffffff;
            text-decoration: none;
        }

        .auto-style23 {
            width: 100%;
            height: 312px;
            background: #0040BD;
        }

        .auto-style24 {
            height: 283px;
            width: 60%;
            margin-top: 15px;
            margin-left: auto;
            margin-right: auto;
        }

        .auto-style25 {
            width: 100%;
            height: 90%;
        }

        #LB_OlvidemicontrasenaLogin {
            color: #ffffff;
            text-decoration: none;
        }

        #HL_Noestoyregistrado {
            color: #ffffff;
            text-decoration: none;
        }
        .auto-style26 {
            color: #CCCCCC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="auto-style16">
        <tr>
            <td>
                <div class="auto-style17">
                    <br />
                    INGRESO LOGIN<br />
                    <br />
                    <div class="auto-style18">
                        <br />
                        <div class="auto-style23">
                            <div class="auto-style24">
                                <br />
                                <table class="auto-style25">
                                    <tr>
                                        <td>Usuario<br />
                                            <asp:TextBox ID="TB_user" runat="server" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_user" ErrorMessage="*" ValidationGroup="TB_LN"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_TB_usuario" runat="server" ControlToValidate="TB_user" ErrorMessage="Elementos no validos" ValidationExpression="[A-Za-z0-9]+" ValidationGroup="IngresoLogin"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Contraseña<br />
                                            <asp:TextBox ID="TB_contrasena" runat="server" TextMode="Password" ValidateRequestMode="Disabled" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_contrasena" ErrorMessage="*" ValidationGroup="TB_LN"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_TB_contrasena" runat="server" ControlToValidate="TB_contrasena" ErrorMessage="Elementos no validos" ValidationExpression="[A-Za-z0-9]+" ValidationGroup="IngresoLogin"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="B_Ingresar" runat="server" Text="INGRESAR" OnClick="B_Ingresar_Click" ValidationGroup="IngresoLogin" />
                                            <br />
                                            <br />
                                            <asp:Label ID="L_msj" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <br />
                        <asp:LinkButton ID="LB_OlvidemicontrasenaLogin" runat="server" OnClick="LB_OlvidemicontrasenaLogin_Click" CssClass="auto-style26" ForeColor="White">OLVIDE MI CONTRASEÑA</asp:LinkButton>
                        <br />
                        <br />
                        <asp:HyperLink ID="HL_Noestoyregistrado" runat="server" NavigateUrl="~/Vew/Registro.aspx" ForeColor="White">NO ESTOY REGISTRADO Y QUIERO REGISTRARME</asp:HyperLink>
                    </div>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

