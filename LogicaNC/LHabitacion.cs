using System.Threading.Tasks;

using Utilitarios;
using DataNC;

namespace LogicaNC
{
    public class LHabitacion
    {
        private readonly Mapeo _context;

        public LHabitacion(Mapeo context)
        {
            _context = context;
        }

        public async Task<UHabitacion> agregarHabitacion(int idtipo, UHabitacion habitacion)
        {
            UHabitacion mensaje = new UHabitacion();
            if (habitacion.Tipo != "--Seleccionar--")
            {
                UHotel infohotel = new UHotel();
                infohotel.Idhotel = habitacion.Idhotel;
                infohotel = await new DAOhotel(_context).infohotel(infohotel);
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
                    new DAOhotel(_context).actualizarhabiatacion(habitacion);
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
