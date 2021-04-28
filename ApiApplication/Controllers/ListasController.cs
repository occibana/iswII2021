using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers
{
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class ListasController : ApiController
    {
        /// <summary>
        ///  Servicio para obtener el listado de zonas municipio Cundinamarca
        /// </summary>
        /// <param name="idzona">IdZona</param>
        /// <param name="Nombre">Nombre</param>
        /// <returns>Listado de zonas</returns>
        /// <Autor>Jonathan Cardenas</Autor>
        /// <Fecha>2021/04/26</Fecha>
        /// <UltimaActualizacion>2021/04/26 - Jonathan Cardenas - Creación del servicio</UltimaActualizacion>
        [HttpGet]
        [Route("api/listas/getListasZonas")]
        public List<UHotelZona> GetLisasZonas()
        {
            return new Listas().listaZonas();
        }

        /// <summary>
        ///  Servicio para obtener el listado de municipios de Cundinamarca
        /// </summary>
        /// <param name="idMunicipio">IdZona</param>
        /// <param name="Nombre">Nombreeeee</param>
        /// <returns>Listado de municipios</returns>

        [HttpGet]
        [Route("api/listas/getListasMunicipios")]
        public List<UHotelMunicipio> GetLisasMunicipios()
        {
            return new Listas().listaMunicipios();
        }

        //tablas


        /// <summary>
        ///  Servicio para obtener el listado de hoteles 
        /// </summary>
        /// <returns>Listado de zonas</returns>

        [HttpPost]
        [Route("api/listas/postHotelesPrincipal")]
        public List<UHotel> PostHotelesPrincipal(UFiltro consulta)
        {

            return new Listas().hotelesPrincipal(consulta);
        }

        /// <summary>
        ///  Servicio para obtener el listado de hoteles destacados
        /// </summary>
        /// <returns>Listado de hoteles destacados</returns>

        [HttpGet]
        [Route("api/listas/getHotelesDestacados")]
        public List<UHotel> GetHotelesDestacados()
        {
            return new Listas().hotelesDestacados();
        }

        /// <summary>
        ///  Servicio para obtener el listado de reservas realizadas por un usuario (mis-reservas)
        /// </summary>
        /// <returns>Listado de reservas realizadas por un usuario (mis-reservas)</returns>

        [HttpPost]
        [Route("api/listas/postMostrarMisreservas")]
        public List<UReserva> PostMostrarMisreservas(URegistro disponibilidadE)
        {
            return new Listas().mostrarMisreservas(disponibilidadE);
        }

        /// <summary>
        ///  Servicio para obtener el listado de habitaciones por hotel
        /// </summary>
        /// <returns>Listado de habitaciones por hotel</returns>

        [HttpPost]
        [Route("api/listas/postHabitacionesHotel")]
        public List<UHabitacion> PostHabitacionesHotel(UHotel idE, UFiltro consulta)
        {
            return new Listas().habitacionesHotel(idE, consulta);
        }

        /// <summary>
        ///  Servicio para obtener el listado de reservas realizadas por un usuario (reservas por hotel)
        /// </summary>
        /// <returns>Listado de reservas realizadas por un usuario (reservas por hotel)</returns>

        [HttpPost]
        [Route("api/listas/getMostrarReservas")]
        public List<UReserva> GetMostrarReservas(int disponibilidadE)
        {
            return new Listas().mostrarreservas(disponibilidadE);
        }

        /// <summary>
        ///  Servicio para obtener el listado de reservas completadas (reservas por hotel)
        /// </summary>
        /// <returns>Listado de reservas completadas (reservas por hotel)</returns>

        [HttpGet]
        [Route("api/listas/getMostrarReservasCompletadas")]
        public List<UReserva> GetMostrarReservasCompletadas(int disponibilidadE)
        {
            return new Listas().mostrarreservascompletadas(disponibilidadE);
        }

        /// <summary>
        ///  Servicio para obtener el listado de comentarios por hotel
        /// </summary>
        /// <returns>Listado de comentarios por hotel</returns>

        [HttpPost]
        [Route("api/listas/postObtenerComentarios")]
        public List<UComentarios> GetObtenerComentarios(UHotel id)
        {
            return new Listas().obtenerComentarios(id);
        }


        //Tablas-Acciones

        /// <summary>
        ///  Servicio para eliminar un hotel de la tabla (mis Hoteles)
        /// </summary>
        /// <returns>Eliminar un hotel</returns>
        [HttpPost]
        [Route("api/listas/postEliminarHotelTabla")]
        public void PostEliminarHotelTabla(UHotel id)
        {
            new Listas().eliminarHotelTabla(id);
        }
    }
}
