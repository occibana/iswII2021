using System.Collections.Generic;
using DataNC;
using Utilitarios;

namespace LogicaNC
{
    //Clase conexion DAO listas y tablas
    public class Listas
    {
        private readonly Mapeo _context;

        public Listas(Mapeo context)
        {
            _context = context;
        }

        public List<UHotelZona> listaZonas()
        {
            return new DAOhotel(_context).zona();
        }

        public List<UHotelMunicipio> listaMunicipios()
        {
            return new DAOhotel(_context).municipio();
        }
        //tablas
        public List<UHotel> hotelesPrincipal(UFiltro consulta)
        {
            return new DAOhotel(_context).hotelesregistrados(consulta);
        }

        public List<UHotel> hotelesDestacados()
        {
            return new DAOhotel(_context).hotelesdestacados();
        }

        public List<UHotel> obtenerHoteles(URegistro session)
        {
            return new DAOhotel(_context).obtenerhoteles(session);
        }

        public List<UReserva> mostrarMisreservas(URegistro disponibilidadE)
        {
            return new DAOReserva().mostrarmisreservas(disponibilidadE);
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
            return new DAOComentarios(_context).obtenerComentarios(id);
        }

        //Tablas-Acciones
        public void eliminarHotelTabla(UHotel id)
        {
              new DAOhotel(_context).deleteHotel(id);
        }

    }
}
