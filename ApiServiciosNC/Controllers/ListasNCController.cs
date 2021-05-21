using System.Collections.Generic;
using DataNC;
using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Utilitarios;

namespace ApiServiciosNC.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ListasNCController : ControllerBase
    {
        private readonly Mapeo _context;

        public ListasNCController(Mapeo context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/listasNC/getListasZonas")]
        public List<UHotelZona> GetLisasZonas()
        {
            return new Listas(_context).listaZonas();
        }


        [HttpGet]
        [Route("api/listasNC/getListasMunicipios")]
        public List<UHotelMunicipio> GetListasMunicipios()
        {
            return new Listas(_context).listaMunicipios();
        }

        [HttpPost]
        [Route("api/listasNC/postHotelesPrincipal")]
        public List<UHotel> PostHotelesPrincipal(UFiltro consulta)
        {

            return new Listas(_context).hotelesPrincipal(consulta);
        }

        [HttpGet]
        [Route("api/listasNC/getHotelesDestacados")]
        public List<UHotel> GetHotelesDestacados()
        {
            return new Listas(_context).hotelesDestacados();
        }

        [HttpPost]
        [Route("api/listasNC/postMostrarMisreservas")]
        public List<UReserva> PostMostrarMisreservas(URegistro disponibilidadE)
        {
            return new Listas(_context).mostrarMisreservas(disponibilidadE);
        }

        //[HttpPost]
        //[Route("api/listasNC/postHabitacionesHotel")]
        //public List<UHabitacion> PostHabitacionesHotel(UHotel idE, UFiltro consulta)
        //{
        //    return new Listas(_context).habitacionesHotel(idE, consulta);
        //}

        [HttpPost]
        [Route("api/listasNC/getMostrarReservas")]
        public List<UReserva> GetMostrarReservas(int disponibilidadE)
        {
            return new Listas(_context).mostrarreservas(disponibilidadE);
        }

        [HttpGet]
        [Route("api/listasNC/getMostrarReservasCompletadas")]
        public List<UReserva> GetMostrarReservasCompletadas(int disponibilidadE)
        {
            return new Listas(_context).mostrarreservascompletadas(disponibilidadE);
        }

        [HttpPost]
        [Route("api/listasNC/postObtenerComentarios")]
        public List<UComentarios> GetObtenerComentarios(UHotel id)
        {
            return new Listas(_context).obtenerComentarios(id);
        }

        [HttpPost]
        [Route("api/listasNC/postEliminarHotelTabla")]
        public void PostEliminarHotelTabla(UHotel id)
        {
            new Listas(_context).eliminarHotelTabla(id);
        }

    }
}