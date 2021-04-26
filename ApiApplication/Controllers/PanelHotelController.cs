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
        [Route("api/panelHotel/postInformacionDelHotel")]
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
        [Route("api/panelHotel/postInformacionDelHotel")]
        public UHabitacion postInformacionHabitacion([FromBody] JObject habitacion)
        {
            UHabitacion habitacionInfo = new UHabitacion();
            habitacionInfo.Idhotel = int.Parse(habitacion["IdHabitacionSession"].ToString());
            return new LPanelHotel().informacion_de_habitacion(habitacionInfo);
        }

        /// <summary>
        ///  Servicio para buscar disponibilidad en el hospedaje
        /// </summary>
        /// <returns>
        /// 
        /// </returns>

        [HttpPost]
        [Route("api/panelHotel/postBuscarDisponibilidadHotel")]
        public UDatosUsuario postBuscarDisponibilidadHotel([FromBody] JObject hotel)
        {
            UReserva reserva = new UReserva();
            reserva.Idhotel = int.Parse(hotel["IdDelHotelSession"].ToString());
            reserva.Fecha_salida = DateTime.Parse(hotel["FechaLlegada"].ToString());
            reserva.Fecha_llegada = DateTime.Parse(hotel["FechaSalida"].ToString());
            DateTime fechaMaxima = reserva.Fecha_llegada.AddDays(30);
            reserva.Numpersona = int.Parse(hotel["NumeroDePersonas"].ToString());
            reserva.Id_habitacion = int.Parse(hotel["HabitacionIdSession"].ToString());

            return new LReserva().buscarDisponibilidad(reserva, fechaMaxima); 
        }

        /// <summary>
        ///  Servicio para reservar hospedaje
        /// </summary>
        /// <returns>
        /// Informacion del hotel
        /// </returns>

        [HttpPost]
        [Route("api/panelHotel/postReservarHospedaje")]
        public async Task<UHotel> postReservarHospedaje([FromBody] JObject hotel)
        {
            UHotel hotelinfo = new UHotel();
            hotelinfo.Idhotel = int.Parse(hotel["IdDelHotelSession"].ToString());
            return await new LPanelHotel().informacion_del_hotel(hotelinfo);
        }

    }
}
