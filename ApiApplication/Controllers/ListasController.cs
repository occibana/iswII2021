using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    public class ListasController : ApiController
    {
        [HttpGet]
        [Route("api/listas/getListasZonas")]
        public List<UHotelZona> GetLisasZonas()
        {
            return new Listas().listaZonas();
        }

        [HttpGet]
        [Route("api/listas/getListasMunicipios")]
        public List<UHotelMunicipio> GetLisasMunicipios()
        {
            return new Listas().listaMunicipios();
        }

        //tablas

        [HttpPost]
        [Route("api/listas/postHotelesPrincipal")]
        public List<UHotel> PostHotelesPrincipal(UFiltro consulta)
        {

            return new Listas().hotelesPrincipal(consulta);
        }

        [HttpGet]
        [Route("api/listas/getHotelesDestacados")]
        public List<UHotel> GetHotelesDestacados()
        {
            return new Listas().hotelesDestacados();
        }

        [HttpPost]
        [Route("api/listas/postMostrarMisreservas")]
        public List<UReserva> PostMostrarMisreservas(URegistro disponibilidadE)
        {
            return new Listas().mostrarMisreservas(disponibilidadE);
        }

        [HttpPost]
        [Route("api/listas/postHabitacionesHotel")]
        public List<UHabitacion> PostHabitacionesHotel(UHotel idE, UFiltro consulta)
        {
            return new Listas().habitacionesHotel(idE, consulta);
        }

        [HttpPost]
        [Route("api/listas/getMostrarReservas")]
        public List<UReserva> GetMostrarReservas(int disponibilidadE)
        {
            return new Listas().mostrarreservas(disponibilidadE);
        }
        
        [HttpGet]
        [Route("api/listas/getMostrarReservasCompletadas")]
        public List<UReserva> GetMostrarReservasCompletadas(int disponibilidadE)
        {
            return new Listas().mostrarreservascompletadas(disponibilidadE);
        }
        
        [HttpPost]
        [Route("api/listas/postObtenerComentarios")]
        public List<UComentarios> GetObtenerComentarios(UHotel id)
        {
            return new Listas().obtenerComentarios(id);
        }

        //Tablas-Acciones
        [HttpPost]
        [Route("api/listas/postObtenerComentarios")]
        public void PostEliminarHotelTabla(UHotel id)
        {
            new Listas().eliminarHotelTabla(id);
        }
    }
}
