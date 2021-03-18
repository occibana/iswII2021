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
            if (datos.User_id != null)
            {
                Session["user_id"] = datos.User_id;
                L_Error_noregistro.Text = datos.Mensaje;
            }
            else
            {
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+ datos.Mensaje +"');window.location=\"Login.aspx\"</script>");
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        URegistro contrasenausuario = new URegistro();
        contrasenausuario.Contrasena = TB_UsuarioRecuperarcontrasena.Text;
        contrasenausuario.Id = int.Parse(Session["user_id"].ToString());
        LReactivarCuenta logica = new LReactivarCuenta();
        contrasenausuario = logica.actualizarContrasena(contrasenausuario);
        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+ contrasenausuario.Mensaje+"');window.location=\""+contrasenausuario.Url+"\"</script>");
        
    }
}