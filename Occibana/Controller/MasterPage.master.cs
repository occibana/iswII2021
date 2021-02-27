using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            B_Login.Text = "VISITAR PERFIL";
        }
    }

    protected void B_Login_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vew/Login.aspx");
    }

    protected void B_Inicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vew/index.aspx");
    }

    protected void B_Registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vew/Registro.aspx");
    }
}
