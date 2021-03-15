<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/AgregarServicioHotel.aspx.cs" Inherits="Vew_AgregarServicioHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }
        .auto-style17 {
            width: 85%;
            background: #0056FF;
            margin-left: auto;
            margin-right: auto;
            color: #ffffff;
            text-align: center;
        }
        .auto-style18 {
            text-align: center;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style19 {
            width: 78%;
            margin-left: auto;
            margin-right: auto;
            background: #E60004;
            height: 343px;
        }
        .auto-style20 {
            width: 100%;
            height: 1103px;
        }
        .auto-style22 {
            text-align: center;
            width: 205px;
        }
        .auto-style23 {
            width: 100%;
            height: 431px;
            margin-top: 0px;
            background: #0040BD;
        }
        .auto-style24 {
            height: 468px;
        }
        .auto-style26 {
            font-size: small;
        }
        .auto-style28 {
            width: 100%;
            height: 233px;
            text-align: center;
        }
        .auto-style29 {
            height: 35px;
        }
        .auto-style30 {
            height: 68px;
        }
        .auto-style31 {
            font-size: large;
        }
        .auto-style32 {
            height: 79px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tr>
            <td>
                <div class="auto-style17">
                    <table class="auto-style20">
                        <tr>
                            <td class="auto-style18">
                                <h1>AÑADIR HOTEL</h1>
                                <p><span class="auto-style31">Bienvenido:
                                    </span>
                                    <asp:Label ID="L_SesionAnadirHotel" runat="server" CssClass="auto-style31"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">
                                <table class="auto-style23">
                                    <tr>
                                        <td class="auto-style30">
                                            <br />
                                            NOMBRE DEL HOTEL:<br />
                                        </td>
                                        <td class="auto-style30">
                                            <br />
                                            <asp:TextBox ID="TB_NombreHotel" runat="server" MaxLength="30"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TB_NombreHotel" runat="server" ControlToValidate="TB_NombreHotel" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_TB_Nombredelhotel" runat="server" ControlToValidate="TB_NombreHotel" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9 ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                        <td colspan="2" rowspan="8">CONDICIONES DE BIOSEGURIDAD DEL HOTEL:<br />
                                            <span class="auto-style26">(Descripción sobre los articulos para evitar el COVID-19)</span><br />
                                            <br />
                                            <div class="auto-style18">
                                                <asp:TextBox ID="TB_descripcioncovid19" runat="server" Height="280px" Width="268px" MaxLength="150"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TB_descripcioncovid19" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_descripcioncovid19" runat="server" ControlToValidate="TB_descripcioncovid19" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9,.: ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            PRECIO HABITACION BÁSICA:<br />
                                            <br />
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="TB_PrecioNoche" runat="server" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TB_PrecioNoche" runat="server" ControlToValidate="TB_PrecioNoche" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_TB_Precionoche" runat="server" ControlToValidate="TB_PrecioNoche" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9 ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            PRECIO HABITACIÓN DOBLE:<br />
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="TB_PrecioNocheDoble" runat="server" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_PrecioNocheDoble" runat="server" ControlToValidate="TB_PrecioNocheDoble" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_TB_PrecionocheDoble" runat="server" ControlToValidate="TB_PrecioNocheDoble" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9 ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style32">
                                            <br />
                                            PRECIO HABITACIÓN PREMIUM:<br />
                                        </td>
                                        <td class="auto-style32">
                                            <br />
                                            <asp:TextBox ID="TB_PrecioNochePremium" runat="server" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TB_PrecioNochePremium" runat="server" ControlToValidate="TB_PrecioNochePremium" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="REV_TB_PrecionochePremium" runat="server" ControlToValidate="TB_PrecioNochePremium" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9 ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>MUNICIPIO:</td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Municipio" runat="server" DataSourceID="ODS_Municipio" DataTextField="Nombre" DataValueField="Idmunicipio">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>ZONA:</td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Zona" runat="server" DataSourceID="ODS_Zona" DataTextField="Nombre" DataValueField="Idzona">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ODS_Zona" runat="server" SelectMethod="zona" TypeName="DAOhotel"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>IMAGEN PRINCIPAL:</td>
                                        <td class="auto-style18">
                                            <asp:Image ID="I_AnadirHotelPrincipal" runat="server" Height="112px" ImageUrl="~/Vew/img/hotelvacio.png" Width="167px" />
                                            <br />
                                            <asp:FileUpload ID="FU_ImgPrincipal" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="FU_ImgPrincipal" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:Label ID="L_CargarimagenAgregarHotel" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="3">IMAGEN ADICIONAL:</td>
                                        <td class="auto-style18" rowspan="3">
                                            <asp:Image ID="I_AdicionalAnadirHotel" runat="server" Height="112px" ImageUrl="~/Vew/img/hotelvacio.png" Width="167px" />
                                            <br />
                                            <asp:FileUpload ID="FU_ImgAdicional" runat="server" />
                                            <br />
                                            <br />
                                            <asp:Label ID="L_CargarimagenAgregarHotel0" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style22">DIRECCION/UBICACIÓN</td>
                                        <td>
                                            <asp:TextBox ID="TB_Direccion" runat="server" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TB_Direccion" runat="server" ControlToValidate="TB_Direccion" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Direccion" runat="server" ControlToValidate="TB_Direccion" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9,.:# ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style22">CHECK IN:</td>
                                        <td>
                                            <asp:TextBox ID="TB_Checkin" runat="server" TextMode="Time"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TB_Checkin" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>IMAGEN ADICIONAL:</td>
                                        <td>
                                            <asp:Image ID="I_AdicionalAnadirHotel0" runat="server" Height="112px" ImageUrl="~/Vew/img/hotelvacio.png" Width="167px" />
                                            <br />
                                            <asp:FileUpload ID="FU_ImgAdicional0" runat="server" />
                                            <br />
                                            <br />
                                            <asp:Label ID="L_CargarimagenAgregarHotel1" runat="server"></asp:Label>
                                            </td>
                                        <td class="auto-style22">CHECK OUT:</td>
                                        <td>
                                            <asp:TextBox ID="TB_Checkout" runat="server" TextMode="Time"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TB_Checkout" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="auto-style19">
                                    <table class="auto-style28">
                                        <tr>
                                            <td>DESCRIPCIÓN (Escriba un apartado para describir generalidades del hotel y servicos):<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TB_Descripcion" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style18">
                                                <br />
                                                <asp:TextBox ID="TB_Descripcion" runat="server" Height="49px" Width="503px" MaxLength="150"></asp:TextBox>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Descripcion" runat="server" ControlToValidate="TB_Descripcion" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9,.: ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style29">CONDICIONES (Escriba un apartado para los condiciones del hotel):<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TB_Condiciones" ErrorMessage="*" ValidationGroup="AnadirHotel"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:TextBox ID="TB_Condiciones" runat="server" Height="49px" Width="503px" MaxLength="150"></asp:TextBox>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Condiciones" runat="server" ControlToValidate="TB_Condiciones" ErrorMessage="Caracteres no validos" ValidationExpression="[A-Za-z0-9,.: ]+" ValidationGroup="AnadirHotel"></asp:RegularExpressionValidator>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <asp:Button ID="B_CargarHotel" runat="server" Text="CARGAR HOTEL" Width="189px" Height="38px" ValidationGroup="AnadirHotel" OnClick="B_CargarHotel_Click" />
                                    <br />
                                    <asp:Label ID="L_Fallo" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="B_Volver" runat="server" Text="VOLVER AL PERFIL" OnClick="B_Volver_Click" />
                    <br />
                    <br />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

