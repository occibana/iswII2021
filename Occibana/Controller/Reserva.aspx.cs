using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using Utilitarios;

public partial class Vew_Reserva : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UHotel hotel = new UHotel();
        UHabitacion habitacion = new UHabitacion();
        try
        {
            hotel.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
            habitacion = (UHabitacion)Session["idhabitacion"];
        }
        catch
        {
            Response.Redirect("index.aspx");
        }
        URegistro registro = new URegistro();
        registro = (URegistro)Session["usuario"];
        UDatosUsuario datos = new UDatosUsuario();
        LReserva reserva = new LReserva();
        datos = reserva.pageload_ingreso_reserva(hotel,habitacion,registro);

        TB_Nombre.Enabled = datos.Aviso;
        TB_Correo.Enabled = datos.Aviso;
        TB_Apellido.Enabled = datos.Aviso;
        TB_CCorreo.Enabled = datos.Aviso;
        B_ConfirmarReserva.Enabled = datos.Aviso;

        L_NombreHotel.Text = datos.Hotel.Nombre;
        L_PrecioNoche.Text = datos.Hotel.Precionoche.ToString();
        L_NumeroDePersonas.Text = datos.Habitacion.Numpersonas.ToString();
        L_Habitaciondisponible.Text = "Seleccione una fecha";

        if (Session["usuario"] != null)
        {
            L_Nombreusuario.Text = datos.Registro.Nombre;
            L_MensajeestadoSession.Text = "Si la reserva no se hará a su nombre ingrese los datos de la persona que será responsable de la reserva";            
            TB_Apellido.Text = datos.Registro.Apellido;
            TB_Nombre.Text = datos.Registro.Nombre;

        }
        else
        {
            L_Nombreusuario.Text = "Cliente";
            L_MensajeestadoSession.Text = "Al parecer no te haz registrado o iniciado sesión, no hay problema igualmente puedes reservar, solo dejanos saber algunos datos.";
        }
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("PanelHotel.aspx");
    }

    protected void B_BuscarDisponibilidad_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;//script
        UReserva reserva = new UReserva();
        reserva.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
        reserva.Fecha_salida = C_FechaSalida.SelectedDate;
        reserva.Fecha_llegada = C_FechaLlegada.SelectedDate;
        DateTime fechaMaxima = reserva.Fecha_llegada.AddDays(30);
        reserva.Numpersona = int.Parse(L_NumeroDePersonas.Text);
        reserva.Id_habitacion = ((UHabitacion)Session["idhabitacion"]).Id;
        UDatosUsuario datos = new LReserva().buscarDisponibilidad(reserva, fechaMaxima);
        L_Habitaciondisponible.Text = datos.Mensaje;

        TB_Nombre.Enabled = datos.Aviso;
        TB_Correo.Enabled = datos.Aviso;
        TB_Apellido.Enabled = datos.Aviso;
        TB_CCorreo.Enabled = datos.Aviso;
        B_ConfirmarReserva.Enabled = datos.Aviso;

    }
 
    protected void B_ConfirmarReserva_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;//script
        UHotel hotel = new UHotel();
        hotel.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
        //hotel = new DAOhotel().infohotel(hotel);
        UReserva reserva = new UReserva();
        try
        {
            reserva.Idusuario = ((URegistro)Session["usuario"]).Id;
        }catch
        {
            reserva.Idusuario = 0;
        }
        
        reserva.Apellido = TB_Apellido.Text;
        reserva.Nombre = TB_Nombre.Text;
        reserva.Numpersona = int.Parse(L_NumeroDePersonas.Text);
        reserva.Correo = TB_Correo.Text;
        reserva.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
        reserva.Fecha_llegada = C_FechaLlegada.SelectedDate;
        reserva.Fecha_salida = C_FechaSalida.SelectedDate;
        DateTime fechaMaxima = reserva.Fecha_llegada.AddDays(30);
        reserva.Mediopago = CHBL_Mediodepago.Text;
        reserva.Id_habitacion = ((UHabitacion)Session["idhabitacion"]).Id;
        reserva.Limite_comentario = reserva.Fecha_salida.AddDays(3);
        reserva.PrecioNoche = int.Parse(L_PrecioNoche.Text);
        hotel = new LReserva().confirmarReserva(hotel, reserva);
        if (hotel.Mensaje != null)
        {
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + hotel.Mensaje + "');window.location=\"Perfil.aspx\"</script>");
        }
        else
        {
            L_MensajeestadoSession.Text = hotel.Mensaje2;
        }     
    }
}