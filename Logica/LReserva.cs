using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LReserva
    {
        public async Task<UDatosUsuario> pageload_ingreso_reserva(UHotel hotel_id, UHabitacion infoHabitacion, URegistro infousuario)
        {
            //deshabilitarbotones();
            UDatosUsuario datosUsuario = new UDatosUsuario();
            datosUsuario.Hotel = new UHotel();
            datosUsuario.Habitacion = new UHabitacion();
            datosUsuario.Registro = new URegistro();
            datosUsuario.Aviso = false;
            try
            {   
                datosUsuario.Hotel.Idhotel = hotel_id.Idhotel;

                datosUsuario.Hotel = await new DAOhotel().infohotel(datosUsuario.Hotel);
                datosUsuario.Hotel.Nombre = datosUsuario.Hotel.Nombre.ToUpper();
                //L_NombreHotel.Text
                if (infoHabitacion.Tipo.Equals("Básica"))
                {
                    datosUsuario.Hotel.Precionoche = datosUsuario.Hotel.Precionoche;
                    //L_PrecioNoche.Text = hotel.Precionoche.ToString();
                }
                else if (infoHabitacion.Tipo.Equals("Doble"))
                {
                    datosUsuario.Hotel.Precionoche = datosUsuario.Hotel.PrecioNocheDoble;
                    //L_PrecioNoche.Text = hotel.PrecioNocheDoble.ToString();
                }
                else if (infoHabitacion.Tipo.Equals("Premium"))
                {
                    datosUsuario.Hotel.Precionoche = datosUsuario.Hotel.PrecioNochePremium;
                    //L_PrecioNoche.Text = hotel.PrecioNochePremium.ToString();
                }

                datosUsuario.Habitacion.Numpersonas = infoHabitacion.Numpersonas;
              
                if (infousuario != null)
                {
                    datosUsuario.Registro.Nombre = infousuario.Nombre;
                    
                    datosUsuario.Registro.Apellido = infousuario.Apellido;
                   
                    datosUsuario.Registro.Contrasena = infousuario.Correo;
                    //TB_Correo.Text = ((Registro)Session["usuario"]).Correo;
                }
                else
                {
                    datosUsuario.Registro.Apellido = "";
                    //TB_Apellido.Text = "";
                    datosUsuario.Registro.Nombre = "";
                    //TB_Nombre.Text = "";
                    datosUsuario.Registro.Contrasena = "";
                    //TB_Correo.Text = "";
                    datosUsuario.Mensaje = "Al parecer no te haz registrado o iniciado sesión, no hay problema igualmente puedes reservar, solo dejanos saber algunos datos.";
                    ///////////////////L_Nombreusuario.Text = "Cliente";
                    ////////////////////L_MensajeestadoSession.Text = "Al parecer no te haz registrado o iniciado sesión, no hay problema igualmente puedes reservar, solo dejanos saber algunos datos.";
                }
            }
            catch (Exception ex)
            {
                datosUsuario.Url = "index.aspx";
                //Response.Redirect("index.aspx");
            }
            return datosUsuario;
        }
        //buscar Disponibilidad de fecha
        public UDatosUsuario buscarDisponibilidad(UReserva reserva, DateTime fechaMaxima)
        {
            UDatosUsuario mensaje = new UDatosUsuario();

            if (reserva.Fecha_llegada < DateTime.Now)
            {
                mensaje.Mensaje = "Seleccione fechas de llegada despues de " + DateTime.Now.Date;
                //deshabilitarbotones();
                mensaje.Aviso = false;
            }
            else
            {
                if (reserva.Fecha_salida > fechaMaxima)
                {
                    mensaje.Mensaje = "Su estadia en el hotel no puede superar los 30 dias.";
                    //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su estadia en el hotel no puede superar los 30 dias.');</script>");
                    //deshabilitarbotones();
                    mensaje.Aviso = false;
                }
                else
                {
                    if (reserva.Fecha_llegada == null || reserva.Fecha_salida == null)
                    {
                        mensaje.Mensaje = "Seleccione las fechas correctamente";
                        //deshabilitarbotones();
                        mensaje.Aviso = false;
                    }
                    else if (reserva.Fecha_llegada != null || reserva.Fecha_salida != null)
                    {
                        if (reserva.Fecha_llegada > reserva.Fecha_salida)
                        {
                            mensaje.Mensaje = "Seleccione una fecha de salida posterior a\n" + reserva.Fecha_llegada;
                        }
                        else if (reserva.Fecha_llegada <=reserva.Fecha_salida)
                        {
                            var hdisponibles = new DAOReserva().habitacionesdisponibles(reserva);//numero de habitaciones en ese hotel para ese numero maximo de personas
                            var fechasreservadas = new DAOReserva().fechasdisponibles(reserva);
                            //var disponibilidad = hdisponibles - fechasreservadas;
                            if (hdisponibles >= 1)
                            {
                                if (fechasreservadas >= 1)
                                {
                                    mensaje.Mensaje = "No hay disponibilidad para las fechas selccionadas";
                                    //deshabilitarbotones();
                                    mensaje.Aviso = false;
                                }
                                else if (fechasreservadas == 0)
                                {
                                    mensaje.Mensaje = "habitación disponible para las fechas selccionadas";
                                    //habilitarbotones();
                                    mensaje.Aviso = true;
                                }
                            }
                            else
                            {
                                mensaje.Mensaje = "No hay habitaciones disponibles para ese numero de personas";
                                //deshabilitarbotones();
                                mensaje.Aviso = false;
                            }
                        }
                    }
                }
            }
            return mensaje;
        }

        //Confirmar reserva
        public async Task<UHotel> confirmarReserva(UHotel infoHotel, UReserva infoReserva)
        {
            UHotel hotel = new UHotel();
            hotel = await new DAOhotel().infohotel(infoHotel);

            var fechasreservadas = new DAOReserva().fechasdisponibles(infoReserva);
            int cantReservas = new DAOReserva().verificarreserva(infoReserva);

            string fechaLlegada = (infoReserva.Fecha_llegada).ToString();
            string fechaSalida = (infoReserva.Fecha_salida).ToString();

            if (fechasreservadas == 1)
            {
                //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No hay disponibilidad entre estas fechas');</script>");
                hotel.Mensaje2 = "No hay disponibilidad entre estas fechas";
                hotel.Mensaje = null;
            }
            else if (fechasreservadas == 0)
            {
                if (cantReservas == 0)
                {
                    if (infoReserva.Idusuario != 0)
                    {    
                        new DAOReserva().insertReserva(infoReserva);
                        hotel.Mensaje = "La reserva ha sido exitosa";
                        hotel.Mensaje2 = null;
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('La reserva ha sido exitosa');</script>");
                        new Mail().mailconfirmarreserva(infoReserva);  //correo de confirmacion
                    }
                    else
                    {
                        new DAOReserva().insertReserva(infoReserva);
                        new Mail().mailconfirmarreserva(infoReserva);
                        hotel.Mensaje = "La reserva ha sido exitosa";
                        hotel.Mensaje2 = "ESTA RESERVA SE ENCUENTRA OCUPADA";
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('La reserva ha sido exitosa');</script>");

                    }
                }
                else
                {
                    hotel.Mensaje2 = "ESTA RESERVA SE ENCUENTRA OCUPADA";//, REVISE SU CORREO PARA MÁS DETALLES
                    hotel.Mensaje = null;
                    //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('ESTA RESERVA SE ENCUENTRA OCUPADA');</script>");
                }
            }
            

            return hotel;
        }
    }
}
