using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

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
        public IHttpActionResult GetLisasZonas()
        {
            try
            {
                return Ok(new Listas().listaZonas());
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
           
        }

        /// <summary>
        ///  Servicio para obtener el listado de municipios de Cundinamarca
        /// </summary>
        /// <param name="idMunicipio">IdZona</param>
        /// <param name="Nombre">Nombreeeee</param>
        /// <returns>Listado de municipios</returns>

        [HttpGet]
        [Route("api/listas/getListasMunicipios")]
        public IHttpActionResult GetLisasMunicipios()
        {
            try
            {
                return Ok(new Listas().listaMunicipios());
            }
            catch(Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }
           
        }

        //tablas


        /// <summary>
        ///  Servicio para obtener el listado de hoteles 
        /// </summary>
        /// <returns>Listado de zonas</returns>

        [HttpPost]
        [Route("api/listas/postHotelesPrincipal")]
        public IHttpActionResult PostHotelesPrincipal(UFiltro consulta)
        {

            try
            {
                return Ok(new Listas().hotelesPrincipal(consulta));
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        ///  Servicio para obtener el listado de hoteles destacados
        /// </summary>
        /// <returns>Listado de hoteles destacados</returns>

        [HttpGet]
        [Route("api/listas/getHotelesDestacados")]
        public IHttpActionResult GetHotelesDestacados()
        {
            try
            {
                return Ok(new Listas().hotelesDestacados());
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }
        }


        /// <summary>
        ///  Servicio para obtener el listado de reservas realizadas por un usuario (mis-reservas)
        ///  {"id": "int"}
        /// </summary>
        /// <returns>Listado de reservas realizadas por un usuario (mis-reservas)</returns>
        [Authorize]
        [HttpPost]
        [Route("api/listas/postMostrarMisreservas")]
        public IHttpActionResult PostMostrarMisreservas(URegistro disponibilidadE)
        {
            try
            {
                return Ok(new Listas().mostrarMisreservas(disponibilidadE));
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }
            
        }


        /// <summary>
        ///  Servicio para obtener el listado de reservas realizadas por un usuario (mis-reservas)
        ///  {"idReserva": "int"}
        /// </summary>
        /// <returns>Listado de reservas realizadas por un usuario (mis-reservas)</returns>
        [Authorize]
        [HttpPost]
        [Route("api/listas/postCancelarMireserva")]
        public Task<UMisReservas> PostCancelarMireserva([FromBody] JObject idReserva)
        {
            UReserva Reserva = new UReserva();
            Reserva.Id = int.Parse(idReserva["idReserva"].ToString());
            Task<UMisReservas> cancelar = new LMisReservas().cancelarReserva(Reserva);
            return cancelar;
        }

        /// <summary>
        ///  Servicio para obtener el listado de hoteles agregados por un usuario (mis-reservas)
        ///  {"idUsuario": "int"}
        /// </summary>
        /// <returns>Listado de hoteles agregados por un usuario (mis-reservas)</returns>
        [Authorize]
        [HttpPost]
        [Route("api/listas/postMostrarMisHoteles")]
        public IHttpActionResult PostMostrarMisHoteles([FromBody] JObject usuarioId)
        {
            URegistro RegistroInfo = new URegistro();
            try
            {
                RegistroInfo.Id = int.Parse(usuarioId["idUsuario"].ToString());
                return Ok(new Listas().obtenerHoteles(RegistroInfo));
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }        
        }


        /// <summary>
        ///  Servicio para obtener el listado de habitaciones por hotel {"idHotel":"int","numPersonas":"int o null"}
        /// </summary>
        /// <returns>Listado de habitaciones por hotel</returns>

        [HttpPost]
        [Route("api/listas/postHabitacionesHotel")]
        public IHttpActionResult PostHabitacionesHotel([FromBody] JObject hHotel )
        {
            UHotel idE = new UHotel();
            UFiltro consulta = new UFiltro();
            try
            {
                idE.Idhotel = int.Parse(hHotel["idHotel"].ToString());
                try
                {
                    consulta.numpersonas = int.Parse(hHotel["numPersonas"].ToString());
                }
                catch
                {
                    consulta.numpersonas = null;
                }
                return Ok(new Listas().habitacionesHotel(idE, consulta));
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }

        }
        
        /// <summary>
        ///  Servicio para obtener el listado de reservas realizadas por un usuario (reservas por hotel)
        /// </summary>
        /// <returns>Listado de reservas realizadas por un usuario (reservas por hotel)</returns>
        [Authorize]
        [HttpGet]
        [Route("api/listas/getMostrarReservas")]
        public IHttpActionResult GetMostrarReservas(int idHotel)
        {
            try
            {
                return Ok(new Listas().mostrarreservas(idHotel));
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            } 
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        //F
        /// <summary>
        ///  Servicio para obtener el listado de reservas completadas (reservas por hotel)
        /// </summary>
        /// <returns>Listado de reservas completadas (reservas por hotel)</returns>
        [Authorize]
        [HttpGet]
        [Route("api/listas/getMostrarReservasCompletadas")]
        public IHttpActionResult GetMostrarReservasCompletadas(int idHotel)
        {
            try
            {
                return Ok(new Listas().mostrarreservascompletadas(idHotel));
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }
            
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        ///  Servicio para obtener el listado de comentarios por hotel {"idhotel": 67}
        /// </summary>
        /// <returns>Listado de comentarios por hotel</returns>

        [HttpPost]
        [Route("api/listas/postObtenerComentarios")]
        public IHttpActionResult GetObtenerComentarios(UHotel idHotel)
        {
            try
            {
                return Ok(new Listas().obtenerComentarios(idHotel));
            }
            catch (Exception ex)
            {
                return BadRequest("surgio el siguente error: " + ex.Message.ToString());
            }
            
        }


        //Tablas-Acciones

        /// <summary>
        ///  Servicio para eliminar un hotel de la tabla (mis Hoteles)
        /// </summary>
        /// <returns>Eliminar un hotel</returns>
        [Authorize]
        [HttpPost]
        [Route("api/listas/postEliminarHotelTabla")]
        public IHttpActionResult PostEliminarHotelTabla(UHotel idHotel)
        {
            string mensaje= null;
            try
            {
                mensaje = new Listas().eliminarHotelTabla(idHotel);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
            
        }
    }
}
