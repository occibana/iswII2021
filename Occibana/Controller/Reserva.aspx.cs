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
        hotel.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
        UHabitacion habitacion = new UHabitacion();
        habitacion = (UHabitacion)Session["idhabitacion"];
        URegistro registro = new URegistro();
        registro = (URegistro)Session["usuario"];
        UDatosUsuario datos = new UDatosUsuario();
        LReserva reserva = new LReserva();
        datos = reserva.pageload_ingreso_reserva(hotel,habitacion,registro);

        L_NombreHotel.Text = datos.Hotel.Nombre;
        L_PrecioNoche.Text = datos.Hotel.Precionoche.ToString();
        L_NumeroDePersonas.Text = datos.Habitacion.Numpersonas.ToString();
        L_Habitaciondisponible.Text = "Seleccione una fecha";
        L_Nombreusuario.Text = datos.Registro.Nombre;
        TB_Apellido.Text = datos.Registro.Apellido;
        TB_Nombre.Text = datos.Registro.Nombre;
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("PanelHotel.aspx");
    }

    protected void B_BuscarDisponibilidad_Click(object sender, EventArgs e)
    {
        /*
        ClientScriptManager cm = this.ClientScript;//script
        Reserva reserva = new Reserva();
        reserva.Idhotel = ((Hotel)Session["visitarhotel"]).Idhotel;
        reserva.Fecha_salida = C_FechaSalida.SelectedDate;
        reserva.Fecha_llegada = C_FechaLlegada.SelectedDate;
        DateTime fechaMaxima = reserva.Fecha_llegada.AddDays(30);
        reserva.Numpersona = int.Parse(L_NumeroDePersonas.Text);
        reserva.Id_habitacion = ((Habitacion)Session["idhabitacion"]).Id;
        if (reserva.Fecha_llegada < DateTime.Now)
        {
            L_Habitaciondisponible.Text = "Seleccione fechas de llegada despues de "+ DateTime.Now.Date;
            deshabilitarbotones();
        }
        else
        {
            if (reserva.Fecha_salida > fechaMaxima)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su estadia en el hotel no puede superar los 30 dias.');</script>");
                deshabilitarbotones();
            }
            else
            {
                if (reserva.Fecha_llegada == null || reserva.Fecha_salida == null)
                {
                    L_Habitaciondisponible.Text = "Seleccione las fechas correctamente";
                    deshabilitarbotones();
                }
                else if (reserva.Fecha_llegada != null || reserva.Fecha_salida != null)
                {
                    if (C_FechaLlegada.SelectedDate > C_FechaSalida.SelectedDate)
                    {
                        L_Habitaciondisponible.Text = "Seleccione una fecha de salida posterior a\n" + C_FechaLlegada.SelectedDate;
                    }
                    else if (C_FechaLlegada.SelectedDate <= C_FechaSalida.SelectedDate)
                    {
                        var hdisponibles = new DAOReserva().habitacionesdisponibles(reserva);//numero de habitaciones en ese hotel para ese numero maximo de personas
                        var fechasreservadas = new DAOReserva().fechasdisponibles(reserva);
                        //var disponibilidad = hdisponibles - fechasreservadas;
                        if (hdisponibles >= 1)
                        {
                            if (fechasreservadas == 1)
                            {
                                L_Habitaciondisponible.Text = "No hay disponibilidad para las fechas selccionadas";
                                deshabilitarbotones();
                            }
                            else if (fechasreservadas == 0)
                            {
                                L_Habitaciondisponible.Text = "habitación disponible para las fechas selccionadas";
                                habilitarbotones();
                            }
                        }
                        else
                        {
                            L_Habitaciondisponible.Text = "No hay habitaciones disponibles para ese numero de personas";
                            deshabilitarbotones();
                        }
                    }
                }
            }


        }
        */
    }

    protected void deshabilitarbotones()
    {
        TB_Nombre.Enabled = false;
        TB_Correo.Enabled = false;
        TB_Apellido.Enabled = false;
        TB_CCorreo.Enabled = false;
        B_ConfirmarReserva.Enabled = false;
    }

    protected void habilitarbotones()
    {
        TB_Nombre.Enabled = true;
        TB_Correo.Enabled = true;
        TB_Apellido.Enabled = true;
        TB_CCorreo.Enabled = true;
        B_ConfirmarReserva.Enabled = true;
    }
    
    protected void B_ConfirmarReserva_Click(object sender, EventArgs e)
    {
        /*
        ClientScriptManager cm = this.ClientScript;//script
        Hotel hotel = new Hotel();
        hotel.Idhotel = ((Hotel)Session["visitarhotel"]).Idhotel;
        hotel = new DAOhotel().infohotel(hotel);
        Reserva reserva = new Reserva();

        reserva.Apellido = TB_Apellido.Text;
        reserva.Nombre = TB_Nombre.Text;
        reserva.Numpersona = int.Parse(L_NumeroDePersonas.Text);
        reserva.Correo = TB_Correo.Text;
        reserva.Idhotel = ((Hotel)Session["visitarhotel"]).Idhotel;
        reserva.Fecha_llegada = C_FechaLlegada.SelectedDate;
        reserva.Fecha_salida = C_FechaSalida.SelectedDate;
        DateTime fechaMaxima = reserva.Fecha_llegada.AddDays(30);
        reserva.Mediopago = CHBL_Mediodepago.Text;
        reserva.Id_habitacion = ((Habitacion)Session["idhabitacion"]).Id;
        reserva.Limite_comentario = reserva.Fecha_salida.AddDays(3);
        reserva.PrecioNoche = int.Parse(L_PrecioNoche.Text);
        var fechasreservadas = new DAOReserva().fechasdisponibles(reserva);
        int cantReservas = new DAOReserva().verificarreserva(reserva);
        string fechaLlegada = (reserva.Fecha_llegada).ToString();
        string fechaSalida = (reserva.Fecha_salida).ToString();
        //if (reserva.Fecha_salida > fechaMaxima)
        //{
        //    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su estadia en el hotel no puede superar los 30 dias.');</script>");

        //}
        //else
        //{
            if (fechasreservadas == 1)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No hay disponibilidad entre estas fechas');</script>");
            }
            else if (fechasreservadas == 0)
            {
                if (cantReservas == 0)
                {
                    if (Session["usuario"] != null)
                    {
                        reserva.Idusuario = ((Registro)Session["usuario"]).Id;
                        new DAOReserva().insertReserva(reserva);
                        L_MensajeestadoSession.Text = "REESERVA EXITOSA";//, REVISE SU CORREO PARA MÁS DETALLES
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('La reserva ha sido exitosa');</script>");
                        new Mail().mailconfirmarreserva(reserva);
                    }
                    else
                    {
                        new DAOReserva().insertReserva(reserva);
                        new Mail().mailconfirmarreserva(reserva);
                        L_MensajeestadoSession.Text = "REESERVA EXITOSA";//, REVISE SU CORREO PARA MÁS DETALLES
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('La reserva ha sido exitosa');</script>");
                        
                    }
                }
                else
                {
                    L_MensajeestadoSession.Text = "RESERVA OCUPADA";//, REVISE SU CORREO PARA MÁS DETALLES
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('ESTA RESERVA SE ENCUENTRA OCUPADA');</script>");
                }
            }
        //}
           */   
    }
}