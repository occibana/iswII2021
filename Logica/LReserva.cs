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
        public UDatosUsuario pageload_ingreso_reserva(UHotel hotel_id, UHabitacion infoHabitacion, URegistro infousuario)
        {
            //deshabilitarbotones();
            UDatosUsuario datosUsuario = new UDatosUsuario();
            datosUsuario.Hotel = new UHotel();
            datosUsuario.Habitacion = new UHabitacion();
            datosUsuario.Registro = new URegistro();
            try
            {   
                datosUsuario.Hotel.Idhotel = hotel_id.Idhotel;

                datosUsuario.Hotel = new DAOhotel().infohotel(datosUsuario.Hotel);
                datosUsuario.Hotel.Nombre = datosUsuario.Hotel.Nombre.ToUpper();
                //L_NombreHotel.Text
                if (infoHabitacion.Tipo.Equals("Básica"))
                {
                    datosUsuario.Hotel.Precionoche = datosUsuario.Hotel.Precionoche;
                    //L_PrecioNoche.Text = hotel.Precionoche.ToString();
                }
                if (infoHabitacion.Tipo.Equals("Doble"))
                {
                    datosUsuario.Hotel.PrecioNocheDoble = datosUsuario.Hotel.PrecioNocheDoble;
                    //L_PrecioNoche.Text = hotel.PrecioNocheDoble.ToString();
                }
                if (infoHabitacion.Tipo.Equals("Premium"))
                {
                    datosUsuario.Hotel.PrecioNochePremium = datosUsuario.Hotel.PrecioNochePremium;
                    //L_PrecioNoche.Text = hotel.PrecioNochePremium.ToString();
                }

                datosUsuario.Habitacion.Numpersonas = infoHabitacion.Numpersonas;
                //L_NumeroDePersonas.Text = (((Habitacion)Session["idhabitacion"]).Numpersonas).ToString();
                //L_Habitaciondisponible.Text = "Seleccione una fecha";
                if (infousuario != null)
                {
                    datosUsuario.Registro.Nombre = infousuario.Nombre;
                    //L_Nombreusuario.Text = ((Registro)Session["usuario"]).Nombre;
                    //////////L_MensajeestadoSession.Text = "Si la reserva no se hará a su nombre ingrese los datos de la persona que será responsable de la reserva";
                    datosUsuario.Registro.Apellido = infousuario.Apellido;
                    //TB_Apellido.Text = ((Registro)Session["usuario"]).Apellido;
                    //TB_Nombre.Text = ((Registro)Session["usuario"]).Nombre;
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
    }
}
