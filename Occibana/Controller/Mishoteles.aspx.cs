using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_Mishoteles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        try
        {
            L_Usuario.Text = ((Registro)Session["usuario"]).Usuario;
        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
        */
    }

    protected void GV_Mishoteles_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["tabla"] = GV_Mishoteles.SelectedDataKey.Value;
        Response.Redirect("Habitacion.aspx");
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }

    protected void GV_Mishoteles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());

        if (e.CommandName == "reservashotel")
        {
            
            Session["tabla"] = GV_Mishoteles.DataKeys[index].Value.ToString();
            Response.Redirect("Reservas.aspx");
        }
    }

    protected void B_GenerarReporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reportes/ReporteHoteles/ReporteHoteles.aspx");
    }
}