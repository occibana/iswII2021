using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Utilitarios;

namespace Logica
{
    //Clase conexion DAO listas y tablas
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
        //tablas
        public List<UHotel> hotelesPrincipal(UFiltro consulta)
        {
            return new DAOhotel().hotelesregistrados(consulta);
        }

        public List<UHotel> hotelesDestacados()
        {
            return new DAOhotel().hotelesdestacados();
        }

        public List<UHotel> obtenerHoteles(URegistro session)
        {
            return new DAOhotel().obtenerhoteles(session);
        }

        public List<UReserva> mostrarMisreservas(URegistro disponibilidadE)
        {
            return new DAOReserva().mostrarmisreservas(disponibilidadE);
        }

        public List<UHotel> mostrarMisHoteles(URegistro usuarioId)
        {
            return new DAOhotel().obtenerhoteles(usuarioId);
        }

        public List<UHabitacion> habitacionesHotel(UHotel idE, UFiltro consulta)
        {
            return new DAOHabitacion().habitacionesHotel(idE,consulta);
        }

        public List<UReserva> mostrarreservas(int disponibilidadE)
        {
            return new DAOReserva().mostrarreservas(disponibilidadE);
        }

        public List<UReserva> mostrarreservascompletadas(int disponibilidadE)
        {
            return new DAOReserva().mostrarreservascompletadas(disponibilidadE);
        }

        public List<UComentarios> obtenerComentarios(UHotel id)
        {
            return new DAOComentarios().obtenerComentarios(id);
        }

        //Tablas-Acciones
        public void eliminarHotelTabla(UHotel id)
        {
              new DAOhotel().deleteHabitacion(id);
        }

    }
}
