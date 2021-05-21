﻿using Logica;
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
        [Route("api/panelHotel/postInformacionDelHabitacion")]
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

        /// <summary>
        ///  Servicio para subir 
        /// </summary>
        /// <returns>
        /// Informacion del hotel
        /// </returns>
        //[HttpPost]
        //[Route("api/panelHotel/postAgregarHotel")]
        //public UHotel agregarHotel([FromBody] JObject datosHotel)
        //{
        //    UHotel hotel = new UHotel();
        //    UPerfil perfil = new UPerfil();
        //    URegistro usuario = new URegistro();
        //    hotel.Nombre = datosHotel["nombreH"].ToString();
        //    hotel.Municipio = datosHotel["municipio"].ToString();
        //    hotel.Idmunicipio = int.Parse(datosHotel["idMunicipio"].ToString());
        //    hotel.Numhabitacion = datosHotel.Numhabitacion;
        //    hotel.Precionoche = datosHotel.Precionoche;
        //    hotel.PrecioNocheDoble = datosHotel.PrecioNocheDoble;
        //    hotel.PrecioNochePremium = datosHotel.PrecioNochePremium;
        //    hotel.Descripcion = datosHotel.Descripcion;
        //    hotel.Condicion = datosHotel.Condicion;
        //    hotel.Checkin = datosHotel.Checkin;
        //    hotel.Checkout = datosHotel.Checkout;
        //    hotel.Usuarioencargado = datosHotel.Usuarioencargado;
        //    hotel.Idusuario = int.Parse(datosHotel["idUsuario"].ToString());
        //    hotel.Idzona = datosHotel.Idzona;
        //    hotel.Condicionesbioseguridad = datosHotel.Condicionesbioseguridad;
        //    hotel.Direccion = datosHotel.Direccion;

        //    JToken imagenPrin = datosHotel["imagenPrincipal"];
        //    List<byte> listadebytes = new List<byte>();
        //    foreach (JToken bite in imagenPrin)
        //    {
        //        listadebytes.Add(byte.Parse(bite.ToString()));
        //    }
        //    byte[] imagenPrincipal = listadebytes.ToArray();

        //    hotel.Idusuario = int.Parse(datosHotel["idUsuario"].ToString());
 
        //    //perfil = new LPerfil().cargardatos(usuario);
        //    //usuario.Id = perfil.Datos.Id;
        //    string nombreArchivo = usuario.Usuario + "Perfil";

        //    //string imagen = HttpContext.Current.Server.MapPath("~\\Vew\\imgusuarios\\") + nombreArchivo;
        //    string ext1 = datosHotel["ext1"].ToString();
        //    string ext2 = datosHotel["ext2"].ToString();
        //    string ext3 = datosHotel["ext3"].ToString();
        //    string direccion = "~\\Vew\\imgusuarios\\" + nombreArchivo + ext1;
        //   // string imagenEliminar = perfil.Datos.Fotoperfil;
        //    //imagenEliminar = HttpContext.Current.Server.MapPath(imagenEliminar);

        //    return new LPerfil().subirFoto(imagenPrincipal, usuario, direccion, ext, );
        //}

    }
}
