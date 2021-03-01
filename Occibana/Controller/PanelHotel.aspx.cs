using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_PanelHotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            UHotel hotel = new UHotel();
            hotel.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
            hotel = new LPanelHotel().informacion_del_hotel(hotel);

            L_Panelhotelnombre.Text = hotel.Nombre.ToUpper();

            L_Panelhotelzona.Text = hotel.Zona;
            L_Panelhotelmunicipio.Text = hotel.Municipio;

            L_Panelhotelhabitaciones.Text = hotel.Numhabitacion.ToString();
            L_Panelhotelprecio.Text = hotel.Precionoche.ToString();
            L_PanelHotelPrecioDoble.Text = hotel.PrecioNocheDoble.ToString();
            L_PanelHotelPrecioPremium.Text = hotel.PrecioNochePremium.ToString();
            L_Panelhotelcalificacion.Text = hotel.Promediocalificacion.ToString()+" Estrellas";
            I_Panelimagenprincipal.ImageUrl = hotel.Imagen.ToString();

            L_Direccion.Text = hotel.Direccion;
            L_Descripcion.Text = hotel.Descripcion;
            L_Condicion.Text = hotel.Condicion;
            L_Checkin.Text = hotel.Checkin;
            L_Checkout.Text = hotel.Checkout;

        }
        catch
        {
            Session.Remove("visitarhotel");
            Response.Redirect("index.aspx");
        }
        
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void B_Comentarios_Click(object sender, EventArgs e)
    {
        //UpdatePanel1.Visible = false;
        //UpdatePanel2.Visible = true;
        Response.Redirect("ComentariosHotel.aspx");

    }

    protected void B_Desc_Reserva_Click(object sender, EventArgs e)
    {
        //UpdatePanel1.Visible = true;
        //UpdatePanel2.Visible = false;
    }

    protected void B_Reservar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reserva.aspx");
    }


    protected void DL_Habitaciones_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
        UHabitacion habitacioninfo = new UHabitacion();
        habitacioninfo.Id = int.Parse(e.CommandArgument.ToString());

        habitacioninfo = new LPanelHotel().informacion_de_habitacion(habitacioninfo);
        
        Session["idhabitacion"] = habitacioninfo;
        Response.Redirect("Reserva.aspx");

    }
}