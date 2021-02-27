using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        /*
        Registro login = new Registro();

        login.Usuario = TB_user.Text;
        login.Contrasena = TB_contrasena.Text;

        login = new DAOLogin().verificar(login);
        if (login == null)
        {
            L_msj.Text = "Verifica tus datos\n usuario o contraseña incorrecto";
        }
        else
        {
            Session["usuario"] = login;
            MAC conexion = new MAC();
            Acceso acceso = new Acceso();
            acceso.FechaInicio = DateTime.Now;
            acceso.Ip = conexion.ip();
            acceso.Mac = conexion.mac();
            acceso.Session = Session.SessionID;
            acceso.Userid = login.Id;
            
            new DAOSeguridad().insertarAcceso(acceso);

            Response.Redirect("Perfil.aspx");
        }      
        */
    }

    protected void LB_OlvidemicontrasenaLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recuperarcontrasena.aspx");
    }
}