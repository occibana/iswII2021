using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_Misreservas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        try
        {
            L_Usuario.Text = ((Registro)Session["usuario"]).Nombre;
        }
        catch
        {
            Response.Redirect("Login.aspx");
            Session.Remove("usuario");
        }
        */
    }

    protected void GV_Mishoteles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        /*
        int idreserva = int.Parse(e.CommandArgument.ToString());

        if (e.CommandName == "calificarreserva")
        {
            Reserva inforeserva = new Reserva();
            inforeserva.Id = int.Parse(GV_Mishoteles.DataKeys[idreserva].Value.ToString());
            inforeserva = new DAOReserva().inforeserva(inforeserva);
            Hotel hotelinfo = new Hotel();
            hotelinfo.Idhotel = int.Parse((inforeserva.Idhotel).ToString());
            Session["visitarhotel"] = hotelinfo;
            Session["calificarhotel"] = int.Parse(GV_Mishoteles.DataKeys[idreserva].Value.ToString());
            Response.Redirect("ComentariosHotel.aspx"); 
        }else if (e.CommandName == "cancelarreserva")

        {
            Reserva inforeserva = new Reserva();
            inforeserva.Id = int.Parse(GV_Mishoteles.DataKeys[idreserva].Value.ToString());
            inforeserva = new DAOReserva().inforeserva(inforeserva);
            if (inforeserva.Fecha_salida<=DateTime.Now)
            {
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No es posible eliminar una reserva ya realizada');</script>");
            }
            else if(inforeserva.Fecha_llegada>DateTime.Now)
            {
                new DAOReserva().deleteReserva(inforeserva);
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Reserva eliminada con exito');</script>");
            }
            else if((inforeserva.Fecha_llegada<=DateTime.Now) && (inforeserva.Fecha_salida>=DateTime.Now))
            {
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No es posible realizar la eliminación');</script>");
            }

        }

        */
    }

    protected void B_ReporteReservas_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reportes/ReporteHoteles/ReporteUsuarioReservas.aspx");
    }


    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }
}