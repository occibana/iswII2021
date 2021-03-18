using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using Utilitarios;

public partial class Vew_Actualizarcontrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LActualizarContrasena datosActualizar = new LActualizarContrasena();
            UActualizarContrasena respuesta = new UActualizarContrasena();
            respuesta = datosActualizar.verificarsession((URegistro)Session["usuario"]);
            if (respuesta.URL1 != null)
            {
                Session.Remove("usuario");
                Response.Redirect(respuesta.URL1);
            }
            else
            {
                L_Error_noregistro.Text = respuesta.Mensaje;
            }

        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }

        /*
        try
        {
            Registro login = new Registro();

            login.Usuario = ((Registro)Session["usuario"]).Usuario.ToString();
            login.Contrasena = ((Registro)Session["usuario"]).Contrasena.ToString();

            login = new DAOLogin().verificar(login);
            
            if (login == null)
            {
                L_Error_noregistro.Text = "Verifica tus datos\n usuario o contraseña incorrecto";
            }

        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
        */
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        LActualizarContrasena logica = new LActualizarContrasena();
        UActualizarContrasena mensaje = new UActualizarContrasena();
        
        mensaje = logica.actualizarContrasena((URegistro)Session["usuario"],TB_Contrasenaactual.Text,TB_Nuevacontrasena.Text);
        L_Error_noregistro.Text = mensaje.Mensaje;
        string msj = mensaje.Mensaje;
        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+msj+"');window.location=\"Perfil.aspx\"</script>");
    }
}