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

    public class ComentarCalificarController : ApiController
    {
        /// <summary>
        ///  Servicio para comentar un servicio de hotel
        /// </summary>


        [HttpPost]
        [Route("api/comentarCalificar/postComentar")]
        public UComentario_CalificacionDatos postComentar([FromBody] JObject dato)
        {
            URegistro session = new URegistro();
            UComentarios comentario = new UComentarios();
            UHotel hotelsession = new UHotel();

            session.Id = int.Parse(dato["IdSession"].ToString());
            comentario.Comentario = dato["Comentario"].ToString();
            hotelsession.Idhotel = int.Parse(dato["IdHotelSession"].ToString());

            return new LComentariosHotel().comentar(session,comentario,hotelsession);
        }
    }
}
