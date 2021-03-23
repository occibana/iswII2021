<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/Habitacion.aspx.cs" Inherits="Vew_Habitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style16 {
            width: 100%;
            height: 303px;
        }
        .auto-style17 {
            width: 85%;
            margin-left: auto;
            margin-right: auto;
            color: #ffffff;
        }
        .auto-style18 {
            width: 100%;
            background: #0056FF;
        }
        .auto-style21 {
            text-align: center;
            width: 80%;
            margin-top: 15px;
            margin-left: auto;
            margin-right: auto;
            height: 203px;
            background: #0040BD;
        }
        
        .auto-style19 {
            text-align: center;
             width: 50%;
        }
        .auto-style22 {
            text-align: center;
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tr>
            <td>
                <div class="auto-style17">
                    <table class="auto-style18">
                        <tr>
                            <td>
                                <table class="auto-style21">
                                    <tr>
                                        <td class="auto-style19">
                                            <asp:Label ID="L_Prueba" runat="server" ForeColor="Black"></asp:Label>
                                            <br />
                                            Numero de baños en
                                            <br />
                                            la habitacion:<br />
                                        </td>
                                        <td class="auto-style19">
                                            <asp:TextBox ID="TB_NumBanio" runat="server" Width="170px" TextMode="Number" ValidationGroup="AgregarHabitacion"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TB_NumBanio" runat="server" ControlToValidate="TB_NumBanio" ErrorMessage="*" ValidationGroup="AgregarHabitacion"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RangeValidator ID="RV_TB_Numbano" runat="server" ControlToValidate="TB_NumBanio" ErrorMessage="Solo positivos hasta 3 o iguales a cero" MaximumValue="3" MinimumValue="0" Type="Integer" ValidationGroup="AgregarHabitacion"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style19">
                                            Numero de personas<br />
                                            por habitacion:<br />
                                        </td>
                                        <td class="auto-style19">
                                            <asp:TextBox ID="TB_NumPersonas" runat="server" Width="170px" TextMode="Number" ValidationGroup="AgregarHabitacion"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TB_Numpersonas" runat="server" ControlToValidate="TB_NumPersonas" ErrorMessage="*" ValidationGroup="AgregarHabitacion"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RangeValidator ID="RV_TB_Numpersonas" runat="server" ControlToValidate="TB_NumPersonas" ErrorMessage="Solo positivos entre 1 y 10" MaximumValue="10" MinimumValue="1" Type="Integer" ValidationGroup="AgregarHabitacion"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="auto-style19">
                                            Tipo de habitación:</td>
                                        <td class="auto-style19">
                                            <br />
                                            <asp:DropDownList ID="DDL_Tipo" runat="server">
                                                <asp:ListItem Selected="True">--Seleccionar--</asp:ListItem>
                                                <asp:ListItem>Básica</asp:ListItem>
                                                <asp:ListItem>Doble</asp:ListItem>
                                                <asp:ListItem>Premium</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:Label ID="L_Tipo" runat="server" Text="Seleccione una opción"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="auto-style19">
                                            Número de camas:
                                            <br />
                                        </td>
                                        <td class="auto-style19">
                                            <br />
                                            <asp:TextBox ID="TB_NumeroDeCamas" runat="server" Width="170px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TB_NumeroDeCamas" runat="server" ControlToValidate="TB_NumeroDeCamas" ErrorMessage="*" ValidationGroup="AgregarHabitacion"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_TB_NumeroDeCamas" runat="server" ControlToValidate="TB_NumeroDeCamas" ErrorMessage="Caracteres no validos" ValidationExpression="[0-9]+" ValidationGroup="AgregarHabitacion" Enabled="False"></asp:RegularExpressionValidator>
                                            <br />
                                            <asp:RangeValidator ID="RV_TB_NumeroDeCamas" runat="server" ControlToValidate="TB_NumeroDeCamas" ErrorMessage="Limite excedido" MaximumValue="4" MinimumValue="1" ValidationGroup="AgregarHabitacion"></asp:RangeValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <div class="auto-style22">
                                    <asp:Label ID="L_Error_habitacion" runat="server"></asp:Label>
                                    <br />
                                    <asp:Button ID="B_AgregarHabitacion" runat="server" Text="ENVIAR" Width="140px" OnClick="B_AgregarHabitacion_Click" ValidationGroup="AgregarHabitacion"  />
                                    <br />
                                    <br />
                                    <asp:Button ID="B_Volver" runat="server" Text="Volver A Perfil" Width="140px" OnClick="B_Volver_Click" />
                                    <br />
                                    <br />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</asp:Content>

