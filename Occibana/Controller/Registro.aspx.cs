using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;



public partial class Vew_Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Registrar_Click(object sender, EventArgs e)
    {
        try
        {
            ClientScriptManager cm = this.ClientScript;
            URegistro registro = new URegistro();

            registro.Nombre = TB_nombre.Text;
            registro.Apellido = TB_apellido.Text;
            registro.Correo = TB_correo.Text;
            registro.Telefono = TB_telefono.Text;
            registro.Usuario = TB_usuarioregistro.Text;
            registro.Contrasena = TB_contrasenaregistro.Text;

            URegistroMensaje registroResult = new LRegistro().registro(registro);
            L_fallo.Text = registroResult.Mensaje;
            TB_nombre.Text = registroResult.TB_nombre;
            TB_apellido.Text = registroResult.TB_apellido;
            TB_correo.Text = registroResult.TB_correo;
            TB_telefono.Text = registroResult.TB_telefono;
            TB_usuarioregistro.Text = registroResult.TB_usuarioregistro;
            TB_contrasenaregistro.Text = registroResult.TB_contrasenaregistro;
            TB_ccontrasena.Text = registroResult.TB_ccontrasena;

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('"+ registroResult.Mensaje + "');</script>");

            //URegistro pedidos = new DAOLogin().verificaruser(registro);
            //if (pedidos == null)
            //{
            //    if (registro.Contrasena.Length < 5)
            //    {
            //        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ingrese una contraseña minimo de 5 caracteres');</script>");
            //        TB_ccontrasena.Text = "";
            //        TB_contrasenaregistro.Text = "";
            //    }
            //    else
            //    {
            //        new DAOLogin().insertRegistro(registro);
            //        new Mail().enviarmail(registro);
            //        L_fallo.Text = " Usuario registrado con exito";
            //        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Registro Exitoso, Por Favor Inice Sesion');</script>");
            //        TB_nombre.Text = "";
            //        TB_apellido.Text = "";
            //        TB_correo.Text = "";
            //        TB_telefono.Text = "";
            //        TB_usuarioregistro.Text = "";
            //    }

            //}
            //else
            //{
            //    L_fallo.Text = "Este usuario o correo ya existe o esta registrado";
            //}
            //Response.Redirect("Login.aspx");

        }
        catch (Exception ex)
        {
            return;
        }
        
    }



}

