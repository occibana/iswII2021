using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            Response.Redirect("Perfil.aspx");
        }
    }

    protected void B_Ingresar_Click(object sender, EventArgs e)
    {
        URegistro login = new URegistro();
        login.Usuario = TB_user.Text;
        login.Contrasena = TB_contrasena.Text;
        string session_id = Session.SessionID;
        UMAC user = new LLogin().ingreso_login(login,session_id);
        try
        {
            L_msj.Text = user.Mensaje;
            Session["usuario"] = user.Registro;
            Response.Redirect(user.Url);
        }
        catch
        {
            L_msj.Text = user.Mensaje;
        }
    }

    protected void LB_OlvidemicontrasenaLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recuperarcontrasena.aspx");
    }
}