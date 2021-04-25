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

    public class PanelHotelController : ApiController
    {

        /// <summary>
        ///  Servicio para cargar información hotel seleccionado
        /// </summary>
        /// <returns>
        /// Informacion del hotel
        /// </returns>

        [HttpPost]
        [Route("api/registroLogin/postInformacionDelHotel")]
        public async Task<UHotel> postInformacionDelHotel([FromBody] JObject hotel)
        {
            UHotel hotelinfo = new UHotel();
            hotelinfo.Idhotel = int.Parse(hotel["IdDelHotelSession"].ToString());
            return await new LPanelHotel().informacion_del_hotel(hotelinfo);
        }

        /// <summary>
        ///  Servicio para cargar información de la habitacion seleccionada en un hotel
        /// </summary>
        /// <returns>
        /// Informacion dela habitacion
        /// </returns>

        [HttpPost]
        [Route("api/registroLogin/postInformacionDelHotel")]
        public UHabitacion postInformacionHabitacion([FromBody] JObject habitacion)
        {
            UHabitacion habitacionInfo = new UHabitacion();
            habitacionInfo.Idhotel = int.Parse(habitacion["IdHabitacionSession"].ToString());
            return new LPanelHotel().informacion_de_habitacion(habitacionInfo);
        }


    }
}
