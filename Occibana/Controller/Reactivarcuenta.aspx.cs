using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using Utilitarios;

public partial class Vew_Reactivarcuenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UReactivarCuentaDatos datos = new UReactivarCuentaDatos();
        LReactivarCuenta reactivarCuenta = new LReactivarCuenta();
        datos = reactivarCuenta.page_load(Request.QueryString);
        try
        {
            Response.Redirect(datos.Url);
        }
        catch
        {
            Session["user_id"] = datos.User_id;
        }
        
        /*
        try
        {
            if (Request.QueryString.Count > 0)
            {
                Token token = new DAOSeguridad().validartoken(Request.QueryString[0]);//enviando url+token 
                if (token == null)
                {
                    this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No puede acceder sin un link de recuperacion, verifique su correo');window.location=\"Login.aspx\"</script>");
                }
                else if (token.Fecha_caducidad < DateTime.Now)
                {
                    this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Tiempo de validez de token ha terminado');window.location=\"Login.aspx\"</script>");
                }
                else
                {
                    Session["user_id"] = token.User_id;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch
        {
           
        }
        */
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {

        /*
        Registro contrasenausuario = new Registro();
        contrasenausuario.Contrasena = TB_UsuarioRecuperarcontrasena.Text;
        contrasenausuario.Id = int.Parse(Session["user_id"].ToString());
        new DAOSeguridad().actualizarcontrasenarecuperacion(contrasenausuario);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('su contraseña ha sido actualizada con exito');window.location=\"Login.aspx\"</script>");
        */
    }
}