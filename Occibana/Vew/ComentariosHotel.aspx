<%@ Page Title="Comentarius" Language="C#" MasterPageFile="~/Vew/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/ComentariosHotel.aspx.cs" Inherits="Vew_ComentariosHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 85%;
            background: #808080;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style17 {
            width: 275px;
            text-align: left;
        }
        .auto-style18 {
            width: 30%;
            height: 23px;
        }
        .auto-style20 {
            text-align: center;
        }
        .auto-style21 {
            text-align: left;
        }
        .auto-style23 {
            width: 70%;
            text-align: left;
        }
        .auto-style24 {
            height: 23px;
            text-align: left;
            border: 2px solid #000000;
            
        }
       .style-espacio{
           height: 23px;
           text-align: left;
        }
        .auto-style25 {
            height: 23px;
            text-align: center;
        }
        .auto-style26 {
            width: 100%;
        }
        .auto-style27 {
            margin-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tbody class="auto-style20">
        <tr>
            <td class="auto-style25" colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="L_NombreHotel" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style24" colspan="2">
                <asp:UpdatePanel ID="UP_Comentarios" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Comentario" HorizontalAlign="Center" Width="90%">
                            <Columns>
                                <asp:BoundField DataField="Id_usuario" HeaderText="Id_usuario" SortExpression="Id_usuario" />
                                <asp:BoundField DataField="Nombre_usuario" HeaderText="Nombre_usuario" SortExpression="Nombre_usuario" />
                                <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODS_Comentario" runat="server" SelectMethod="obtenerComentarios" TypeName="Logica.Listas">
                            <SelectParameters>
                                <asp:SessionParameter Name="id" SessionField="visitarhotel" Type="Object" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </ContentTemplate>
                    
                </asp:UpdatePanel>
            </td>
        </tr>
        
        <tr>
            <td class="style-espacio" colspan="2">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td class="auto-style18">
                USUARIO:
                <asp:Label ID="L_Usuario" runat="server" Font-Size="Large"></asp:Label>
            </td>
            <td class="auto-style23" rowspan="2">
                <asp:TextBox ID="TB_Comentario" runat="server" MaxLength="250" TextMode="MultiLine" Width="85%" ValidationGroup="AgregarComentario" Height="94px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RFV_TextComentario" runat="server" ControlToValidate="TB_Comentario" ErrorMessage="*Llene el campo" ForeColor="Black" ValidationGroup="AgregarComentario"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="REV_ExpresionComentario" runat="server" ErrorMessage="Caracteres no validos" ForeColor="Black" ValidationExpression="[A-Za-z0-9,.: ]+" ValidationGroup="AgregarComentario" ControlToValidate="TB_Comentario"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style17" rowspan="2">Califica el Hotel:&nbsp;&nbsp;
                <asp:Label ID="L_Nombrehotel2" runat="server"></asp:Label>
                <br />
                <table class="auto-style26">
                    <tr>
                        <td>
                            <asp:RadioButton ID="RB_0estrella" runat="server" GroupName="estrellas" />
                            <asp:Image ID="I_0estrella" runat="server" Height="25px" ImageUrl="~/Vew/hoteles/calificaciones/0.jpg" Width="94px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RB_1estrella" runat="server" GroupName="estrellas" />
                            <asp:Image ID="I_1estrella" runat="server" Height="25px" ImageUrl="~/Vew/hoteles/calificaciones/1.jpg" Width="94px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RB_2estrella" runat="server" GroupName="estrellas" />
                            <asp:Image ID="I_2estrella" runat="server" Height="25px" ImageUrl="~/Vew/hoteles/calificaciones/2.jpg" Width="94px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RB_3estrella" runat="server" GroupName="estrellas" />
                            <asp:Image ID="I_3estrella" runat="server" Height="25px" ImageUrl="~/Vew/hoteles/calificaciones/3.jpg" Width="94px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RB_4estrella" runat="server" GroupName="estrellas" />
                            <asp:Image ID="I_4estrella" runat="server" Height="25px" ImageUrl="~/Vew/hoteles/calificaciones/4.jpg" Width="94px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RB_5estrella" runat="server" GroupName="estrellas" />
                            <asp:Image ID="I_5estrella" runat="server" Height="25px" ImageUrl="~/Vew/hoteles/calificaciones/5.jpg" Width="94px" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style21" rowspan="2">
                
                <asp:Button ID="Btn_Comentar" runat="server" OnClick="Btn_Comentar_Click" Text="Comentar" />
                <br />
                <asp:Label ID="L_MensajeC" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style17">
                <div>
                    <asp:Button ID="B_Calificar" runat="server" OnClick="B_Calificar_Click" Text="Calificar" Width="122px" />
                    <br />
                    <asp:Label ID="L_Fallocalificacion" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

