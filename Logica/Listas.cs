using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Utilitarios;

namespace Logica
{
    public class Listas
    {
        public List<UHotelZona> listaZonas()
        {
            return new DAOhotel().zona();
        }

        public List<UHotelMunicipio> listaMunicipios()
        {
            return new DAOhotel().municipio();
        }

        public List<UHotel> hotelesPrincipal(UFiltro consulta)
        {
            return new DAOhotel().hotelesregistrados(consulta);
        }

        public List<UHotel> hotelesDestacados()
        {
            return new DAOhotel().hotelesdestacados();
        }

        public List<UHotel> obtenerHoteles(string usuario)
        {
            return new DAOhotel().obtenerhoteles(usuario);
        }

        public List<UReserva> mostrarMisreservas(URegistro disponibilidadE)
        {
            return new DAOReserva().mostrarmisreservas(disponibilidadE);
        }
        public List<UHabitacion> habitacionesHotel(UHotel idE, UFiltro consulta)
        {
            return new DAOHabitacion().habitacionesHotel(idE,consulta);
        }
    }
}
