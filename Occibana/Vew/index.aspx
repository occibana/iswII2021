<%@ Page Title="" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/index.aspx.cs" Inherits="Vew_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style16 {
            text-align: center;
        }

        .auto-style17 {
            height: 23px;
            text-align: center;
        }

        .auto-style18 {
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            height: 556px;
            background: #E60004;
            color: #ffffff;
            font-weight: 600;
        }

        .auto-style20 {
            width: 100%;
            border: 1px #0056FF;
            height: 379px;
        }

        .auto-style21 {
            height: 296px;
            width: 85%;
            margin-left: auto;
            background: #0040BD;
            margin-right: auto;
        }

        .auto-style23 {
            width: 85%;
            background: #0056FF;
            margin-right: auto;
            margin-left: auto;
            height: 154px;
        }

        .auto-style24 {
            width: 90%;
            margin-right: auto;
            margin-left: auto;
        }

        .auto-style25 {
            height: 582px;
            width: 80%;
            text-align: center;
            margin-left: auto;
            margin-right: auto;
            background: #0040BD;
        }

        .auto-style27 {
            width: 85%;
            height: 460px;
            margin-top: 10px;
            margin-right: auto;
            margin-left: auto;
            background: #0056FF;
        }

        .auto-style28 {
            height: 310px;
        }

        .auto-style29 {
            width: 100%;
            height: 101%;
            color: #ffffff;
            font-weight: 600;
        }

        .auto-style30 {
            width: 246px;
        }

        .auto-style31 {
            width: 209px;
        }

        .auto-style32 {
            width: 33%;
            height: 57px;
        }

        .auto-style33 {
            width: 33%;
            height: 57px;
        }

        .auto-style34 {
            width: 33%;
            height: 57px;
        }

        .auto-style35 {
            width: 100%;
        }

        .auto-style35hoteles {
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 15px;
            background: #E60004;
            height: 346px;
        }

        .auto-style36 {
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            background: #0040BD;
        }

        .auto-style38 {
            width: 63%;
            height: 231px;
            margin-left: auto;
            margin-right: auto;
            background: #ffffff;
        }

        .auto-style39 {
            height: 42px;
        }

        .auto-style40 {
            width: 50%;
        }

        .auto-style41 {
            height: 80px;
        }

        .auto-style42 {
            width: 90%;
            text-align: center;
        }

        .auto-style43 {
            height: 53px;
        }

        .auto-style44 {
            width: 50%;
        }

        .auto-style45 {
            width: 100%;
            height: 82px;
        }

        .auto-style46 {
            width: 60%;
            margin-left: auto;
            margin-right: auto;
            background: #0040BD;
        }

        .DL_Hotelesdestacadosstyle {
            width: 80%;
            margin-top: 5px;
            margin-left: auto;
            margin-right: auto;
            background: #E60004;
            color: #ffffff;
        }
        .auto-style47 {
            font-size: x-large;
            color: #FFFFFF;
        }
        .auto-style48 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="auto-style20">
        <tr>
            <td class="auto-style28">
                <div class="auto-style25">
                    <table class="auto-style35">
                        <tr>
                            <td class="auto-style42">
                                <asp:Label ID="L_Aviso" runat="server" CssClass="auto-style47" Text="Realize su busqueda por el nombre del hotel o empresa"></asp:Label>
                                <br />
                                <asp:TextBox ID="TB_Busquedageneral" runat="server" Width="80%" Height="18px" MaxLength="30"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="REV_TB_Busquedageneral" runat="server" ControlToValidate="TB_Busquedageneral" ErrorMessage="No se permiten caracteres especiales :)" ValidationExpression="^[a-zA-Z0-9 ]*$"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:ImageButton ID="IB_Busquedageneral" runat="server" Height="45px" ImageUrl="~/Vew/img/lupaicon.png" Width="49px" OnClick="IB_Busquedageneral_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="auto-style27">
                        <table class="auto-style29">
                            <tr>
                                <td class="auto-style32">
                                    <h6>&nbsp;</h6>
                                    <h6>$ PRECIOS</h6>
                                    <table class="auto-style35">
                                        <tr>
                                            <td colspan="2">
                                                seleccione el tipo de habitación<br />
                                                <asp:DropDownList ID="DDL_Tipo" runat="server">
                                                    <asp:ListItem Selected="True">--Seleccionar--</asp:ListItem>
                                                    <asp:ListItem Value="Basica">Básica</asp:ListItem>
                                                    <asp:ListItem>Doble</asp:ListItem>
                                                    <asp:ListItem>Premium</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style44">
                                                <br />
                                                maximo<br />
                                                <asp:TextBox ID="TB_PrecioMax" runat="server" Width="90%" MaxLength="10" >
</asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Preciomax" runat="server" ControlToValidate="TB_PrecioMax" ErrorMessage="No caracteres especiales" ValidationExpression="[0-9]+" ValidationGroup="filtrar"></asp:RegularExpressionValidator>
                                                <br />
                                                <asp:RangeValidator ID="RV_TB_Preciomax" runat="server" ControlToValidate="TB_PrecioMax" ErrorMessage="valor no valido" MaximumValue="9999999" MinimumValue="0" Type="Integer" ValidationGroup="filtrar"></asp:RangeValidator>
                                            </td>
                                            <td>
                                                <br />
                                                minimo<asp:TextBox ID="TB_PrecioMin" runat="server" Width="90%" MaxLength="10" EnableTheming="True"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:RegularExpressionValidator ID="REV_TB_Preciomin" runat="server" ControlToValidate="TB_PrecioMin" ErrorMessage="No caracteres especiales" ValidationExpression="[0-9]+" ValidationGroup="filtrar"></asp:RegularExpressionValidator>
                                                <br />
                                                <asp:RangeValidator ID="RV_TB_Preciomin" runat="server" ControlToValidate="TB_PrecioMin" ErrorMessage="valor no valido" MaximumValue="9999999" MinimumValue="0" Type="Integer" ValidationGroup="filtrar"></asp:RangeValidator>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="auto-style33">
                                    <h6>RANGO DE FECHAS</h6>
                                    <table class="auto-style45">
                                        <tr>
                                            <td>después de<br />
                                                <asp:TextBox runat="server" Width="90%" TextMode="Date" ID="TB_DateDespuesDe" ValidationGroup="filtrofechas"></asp:TextBox>
                                            </td>
                                            <td>antes de
                                                <asp:TextBox ID="TB_DateAntesDe" runat="server" Width="90%" TextMode="Date" ValidationGroup="filtrofechas"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <asp:Label ID="L_MensajeFalloFechas" runat="server"></asp:Label>
                                    <br />
                                    <asp:Button ID="B_LimpiarFechas" runat="server" OnClick="B_LimpiarFechas_Click" Text="Limpiar" />
                                </td>
                                <td class="auto-style34">
                                    <h6>ZONAS</h6>
                                    <p>
                                        <asp:DropDownList ID="DDL_Zona" runat="server" Height="17px" Width="90%" DataSourceID="ODS_FiltrarZona" DataTextField="Nombre" DataValueField="Nombre" AppendDataBoundItems="True">
                                            <asp:ListItem Value="--Seleccione--">--Seleccione--</asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ODS_FiltrarZona" runat="server" SelectMethod="zona" TypeName="Data.DAOhotel"></asp:ObjectDataSource>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style30">
                                    <h6 class="auto-style16">PERSONAS MAXIMAS POR HABITACIÓN</h6>
                                    <p>
                                        <asp:TextBox ID="TB_Maxpersonas" runat="server" Width="117px" MaxLength="2" TextMode="Number"></asp:TextBox>
                                    </p>
                                    <p>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_Maxpersonas" ErrorMessage="No se permiten caracteres especiales" ValidationExpression="[0-9 ]" ValidationGroup="filtrar"></asp:RegularExpressionValidator>
                                    </p>
                                </td>
                                <td class="auto-style31">
                                    <h6>
                                    FILTRAR POR CALIFICACIÓN                    
                                    <p>
                                        <asp:Image ID="I_Calificacionestrellas" runat="server" Height="16px" ImageUrl="~/Vew/hoteles/calificaciones/5.jpg" Width="88px" />
                                    </p>
                                    <p>
                                        <asp:DropDownList ID="DDL_Calificacion" runat="server">
                                            <asp:ListItem Selected="True">--Seleccionar--</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                        </asp:DropDownList>
                                    </p>
                                <td>
                                    <h6>MUNICIPIOS</h6>
                                    <p>
                                        <asp:DropDownList ID="DDL_Municipio" runat="server" Height="17px" Width="90%" DataSourceID="ODS_FiltrarMunicipio" DataTextField="Nombre" DataValueField="Nombre" AppendDataBoundItems="True">
                                            <asp:ListItem Value="--Seleccione--">--Seleccione--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ODS_FiltrarMunicipio" runat="server" SelectMethod="municipio" TypeName="Data.DAOhotel"></asp:ObjectDataSource>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="auto-style43">
                                    <asp:Button ID="B_Filtrar" runat="server" Height="27px" Text="FILTRAR" Width="113px" OnClick="B_Filtrar_Click" ValidationGroup="filtrar" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">
                <br />
                <h2>Hoteles a su gusto con Occibana</h2>
                <br />
                <div class="auto-style36">
                    <asp:ScriptManager ID="SM_Hoteles" runat="server">
                    </asp:ScriptManager>
                    <br />
                    <asp:UpdatePanel ID="UP_hoteles" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DataList ID="DL_Listaprincipalhoteles" runat="server" DataSourceID="ODS_Hoteles" RepeatLayout="Flow" OnItemCommand="DL_Listaprincipalhoteles_ItemCommand">
                                <ItemTemplate>
                                    <table class="auto-style35hoteles">
                                        <tr>
                                            <td rowspan="2" class="auto-style40">
                                                <asp:ImageButton ID="IB_Hotelindex" runat="server" Height="230px" Width="70%" ImageUrl='<%# Eval("Imagen") %>' CommandArgument='<%# Eval("Idhotel") %>' />
                                            </td>
                                            <td class="auto-style39">Nombre del hotel:<asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style41">
                                                <div class="auto-style38">
                                                    Precio noche habitación basica:
                                            <asp:Label ID="PrecionocheLabel" runat="server" Text='<%# Eval("Precionoche") %>' />
                                                    <br />
                                                    Precio noche habitación doble:<br />
                                                    <asp:Label ID="L_Precionochedoble" runat="server" Text='<%# Eval("PrecioNocheDoble") %>'></asp:Label>
                                                    <br />
                                                    Precio noche habitación premium:<br />
                                                    <asp:Label ID="L_PrecioNochePremium" runat="server" Text='<%# Eval("PrecioNochePremium") %>'></asp:Label>
                                                    <br />
                                                    Municipio:
                                            <br />
                                                    <asp:Label ID="MunicipioLabel" runat="server" Text='<%# Eval("Municipio") %>' />
                                                    <br />
                                                    # Habitaciones
                                                    <br />
                                                    <asp:Label ID="L_HabitacionesDisponibles" runat="server" Text='<%# Eval("NumHabitDisponibles") %>'></asp:Label>
                                                    <br />
                                                    Calificación promedio<br />
                                                    <asp:Label ID="L_Calificacionprom" runat="server" Text='<%# Eval("Promediocalificacion") %>'></asp:Label>
                                                    <br />
                                                    <br />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:ObjectDataSource ID="ODS_Hoteles" runat="server" SelectMethod="hotelesregistrados" TypeName="Data.DAOhotel">
                                <SelectParameters>
                                    <asp:SessionParameter Name="consulta" SessionField="hotelseleccionado" Type="Object" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TB_Busquedageneral" EventName="TextChanged" />
                        </Triggers>

                    </asp:UpdatePanel>
                    <br />
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style16">
                <br />
                <h3>Sugerencias y hoteles destacados</h3>
                <div class="auto-style46">
                    <div class="DL_Hotelesdestacadosstyle">
                        <asp:DataList ID="DL_Hotelesdestacados" runat="server" DataSourceID="ODS_Hotelesdestacados" RepeatDirection="Horizontal" OnItemCommand="DL_Listaprincipalhoteles_ItemCommand">
                            <ItemTemplate>
                                <div>
                                    <asp:ImageButton ID="IB_HotelDestacado" runat="server" Height="92px" Width="100px" ImageUrl='<%# Eval("Imagen") %>' CommandArgument='<%# Eval("Idhotel") %>' />
                                    <br />
                                    <asp:Label ID="L_NombreHotelDestacado" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <br />
                    <asp:ObjectDataSource ID="ODS_Hotelesdestacados" runat="server" SelectMethod="hotelesdestacados" TypeName="Data.DAOhotel"></asp:ObjectDataSource>
                </div>
                <br />
                <br />
                <h2>SOBRE NOSOTROS           </h2>
                <br />
                <div class="auto-style18">
                    <br />
                    <asp:Image ID="Image2" runat="server" Height="120px" ImageUrl="~/Vew/img/fotoefectos.com_.jpg" Width="148px" />
                    <br />
                    <br />
                    Occibana, los mejores hoteles de la sabana occidente de Cundinamarca en una sola página web y con disponibilidades a un clic<br />
                    <br />
                    <div class="auto-style21">
                        <br />
                        <table class="auto-style23">
                            <tr>
                                <td class="auto-style48">MISION<br />
                                    <br />
                                    Ser reconocidos a nivel municipal y a nivel cundinamarca como la mejor opcion para reserva de hoteles.</td>
                                <td>VISION<br />
                                    <br />
                                    Ser reconocidos en el 2021 como una plataforma segura y servir a nuestros clientes garantizando satisfaccion en cada uno de nuestros servicios.</td>
                            </tr>
                        </table>
                        <div class="auto-style24">
                            <br />
                            LEMA<br />
                            <br />
                            Los mejores hoteles de la sabana occidente a un solo clic</div>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

