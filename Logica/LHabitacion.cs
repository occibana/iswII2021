using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LHabitacion
    {
        public UHabitacion agregarHabitacion(int idtipo, UHabitacion habitacion)
        {
            UHabitacion mensaje = new UHabitacion();
            if (habitacion.Tipo != "--Seleccionar--")
            {
                UHotel infohotel = new UHotel();
                infohotel.Idhotel = habitacion.Idhotel;
                infohotel = new DAOhotel().infohotel(infohotel);
                if (idtipo == 1)//basica
                {
                    habitacion.Precio = infohotel.Precionoche;
                }
                if (idtipo == 2)//doble
                {
                    habitacion.Precio = infohotel.PrecioNocheDoble;
                }
                if (idtipo == 3)//premium
                {
                    habitacion.Precio = infohotel.PrecioNochePremium;
                }
                int cantHabitaciones = new DAOHabitacion().cantidadHabitaciones(habitacion);
                if (cantHabitaciones == 150)
                {
                    mensaje.Mensaje = " Limite de habitaciones alcanzado";
                }
                else
                {
                    new DAOHabitacion().insertHabitacion(habitacion);
                    new DAOhotel().actualizarhabiatacion(habitacion);
                    mensaje.Mensaje = " Habitacion añadida con exito";
                    mensaje.Tb_NumPersonas = "";
                    mensaje.Tb_NumBanio = "";
                    mensaje.Tb_NumeroDeCamas = "";
                }
            }
            else
            {
                mensaje.Mensaje = "Seleccione una opción";
            }

            return mensaje;
        }
    }
}
