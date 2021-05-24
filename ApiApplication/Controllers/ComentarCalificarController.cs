using Logica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Utilitarios;

namespace ApiApplication.Controllers
{

    [EnableCors("*", "*", "*")]

    [Route("api/[controller]")]
    [Authorize]
    public class ComentarCalificarController : ApiController
    {
        /// <summary>
        ///  Servicio para comentar un servicio de hotel
        /// </summary>


        [HttpPost]
        [Route("api/comentarCalificar/postComentar")]
        public IHttpActionResult postComentar([FromBody] JObject dato)
        {
            URegistro session = new URegistro();
            UComentarios comentario = new UComentarios();
            UHotel hotelsession = new UHotel();
            try
            {
                session.Id = int.Parse(dato["IdSession"].ToString());
                comentario.Comentario = dato["Comentario"].ToString();
                hotelsession.Idhotel = int.Parse(dato["IdHotelSession"].ToString());

                return Ok(new LComentariosHotel().comentar(session, comentario, hotelsession));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
        }


        /// <summary>
        ///  Servicio para calificar un servicio de hotel
        /// </summary>


        [HttpPost]
        [Route("api/comentarCalificar/postCalificar")]
        public async Task<IHttpActionResult> postCalificar([FromBody] JObject dato)
        {
            URegistro sessionUsuario = new URegistro();
            UReserva infoReserva = new UReserva();
            UHotel hotelsession = new UHotel();
            UComentarios comentario = new UComentarios();
            try
            {
                sessionUsuario.Id = int.Parse(dato["IdSession"].ToString());
                infoReserva.Id = int.Parse(dato["IdReserva"].ToString());
                hotelsession.Idhotel = int.Parse(dato["IdHotelSession"].ToString());
                int calificacion = int.Parse(dato["Calificacion"].ToString());

                return Ok(await new LComentariosHotel().calificar(sessionUsuario, hotelsession, infoReserva, calificacion));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
            
        }
    }
}
