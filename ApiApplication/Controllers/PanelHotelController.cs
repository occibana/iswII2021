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
        ///  {
        ///  "IdDelHotelSession","int"
        ///  }
        /// </summary>
        /// <returns>
        /// Informacion del hotel
        /// </returns>
        [HttpPost]
        [Route("api/panelHotel/postInformacionDelHotel")]
        public async Task<IHttpActionResult> postInformacionDelHotel([FromBody] JObject hotel)
        {
            UHotel hotelinfo = new UHotel();

            try
            {
                hotelinfo.Idhotel = int.Parse(hotel["IdDelHotelSession"].ToString());
                return Ok(await new LPanelHotel().informacion_del_hotel(hotelinfo));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }

            
        }

        /// <summary>
        ///  Servicio para cargar información de la habitacion seleccionada en un hotel
        /// {
        /// "IdHabitacionSession":"int" 
        /// }
        /// </summary>
        /// <returns>
        /// Informacion dela habitacion
        /// </returns>

        [HttpPost]
        [Route("api/panelHotel/postInformacionDelHabitacion")]
        public IHttpActionResult postInformacionHabitacion([FromBody] JObject habitacion)
        {
            UHabitacion habitacionInfo = new UHabitacion();

            try
            {
                habitacionInfo.Idhotel = int.Parse(habitacion["IdHabitacionSession"].ToString());
                return Ok(new LPanelHotel().informacion_de_habitacion(habitacionInfo));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
        }

        /// <summary>
        ///  Servicio para buscar disponibilidad en el hospedaje
        ///  {
        ///  "IdDelHotelSession":"int","FechaLlegada":"string aaaa-mm-dd","FechaSalida":"string aaaa-mm-dd","NumeroDePersonas":"int", "HabitacionIdSession":"int"
        ///  }
        /// </summary>
        /// <returns>
        /// 
        /// </returns>

        [HttpPost]
        [Route("api/panelHotel/postBuscarDisponibilidadHotel")]
        public IHttpActionResult postBuscarDisponibilidadHotel([FromBody] JObject hotel)
        {
            UReserva reserva = new UReserva();
            try
            {
                reserva.Idhotel = int.Parse(hotel["IdDelHotelSession"].ToString());
                reserva.Fecha_salida = DateTime.Parse(hotel["FechaSalida"].ToString());
                reserva.Fecha_llegada = DateTime.Parse(hotel["FechaLlegada"].ToString());
                DateTime fechaMaxima = reserva.Fecha_llegada.AddDays(30);
                reserva.Numpersona = int.Parse(hotel["NumeroDePersonas"].ToString());
                reserva.Id_habitacion = int.Parse(hotel["HabitacionIdSession"].ToString());

                return Ok(new LReserva().buscarDisponibilidad(reserva, fechaMaxima));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
        }

        /// <summary>
        ///  Servicio para reservar hospedaje
        /// {
        /// "UsuarioSession":string
        ///  "IdDelHotelSession":int
        ///  "Nombre":string,
        ///  "Apellido":string
        ///  "IdHabitacion":int
        ///  "FechaLlegada":string
        ///  "Fechasalida":string
        ///  "NumPersonas":int,
        ///  "ModoDePago":string
        ///  "PrecioNoche":int
        /// }
        /// </summary>
        /// <returns>
        /// Informacion del hotel
        /// </returns>

        [HttpPost]
        [Route("api/panelHotel/postReservarHospedaje")]
        public async Task<IHttpActionResult> postReservarHospedaje([FromBody] JObject reserva)
        {
            UHotel hotelinfo = new UHotel();
            UReserva infoReserva = new UReserva();
            URegistro datoUsuario = new URegistro();
            UPerfil perfil = new UPerfil();
            try
            {
                datoUsuario.Usuario = reserva["UsuarioSession"].ToString();


                perfil = new LPerfil().cargardatos(datoUsuario);

                hotelinfo.Idhotel = int.Parse(reserva["IdDelHotelSession"].ToString());
                hotelinfo = await new LPanelHotel().informacion_del_hotel(hotelinfo);
                infoReserva.Nombre = reserva["Nombre"].ToString();
                infoReserva.Apellido = reserva["Apellido"].ToString();
                infoReserva.PrecioNoche = int.Parse(reserva["PrecioNoche"].ToString());
                infoReserva.Idhotel = hotelinfo.Idhotel;
                infoReserva.Id_habitacion = int.Parse(reserva["IdHabitacion"].ToString());
                infoReserva.Fecha_llegada = DateTime.Parse(reserva["FechaLlegada"].ToString());
                infoReserva.Fecha_salida = DateTime.Parse(reserva["Fechasalida"].ToString());
                infoReserva.Numpersona = int.Parse(reserva["NumPersonas"].ToString());
                infoReserva.Mediopago = reserva["ModoDePago"].ToString();
                infoReserva.Idusuario = perfil.Datos.Id;
                infoReserva.Correo = perfil.Datos.Correo;
                return Ok(await new LReserva().confirmarReserva(hotelinfo, infoReserva));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
            
        }

        /// <summary>
        ///  Servicio para subir 
        /// </summary>
        /// <returns>
        /// Informacion del hotel
        /// </returns>
        [HttpPost]
        [Route("api/panelHotel/postAgregarHotel")]
        public IHttpActionResult agregarHotel([FromBody] JObject datosHotel)
        {
            try
            {
                UHotel hotel = new UHotel();
                UPerfil perfil = new UPerfil();
                URegistro usuario = new URegistro();
                hotel.Nombre = datosHotel["nombreH"].ToString();
                hotel.Municipio = datosHotel["municipio"].ToString();
                hotel.Idmunicipio = int.Parse(datosHotel["idMunicipio"].ToString());
                // hotel.Numhabitacion = datosHotel.Numhabitacion;
                hotel.Precionoche = int.Parse(datosHotel["precioBasica"].ToString());
                hotel.PrecioNocheDoble = int.Parse(datosHotel["precioDoble"].ToString());
                hotel.PrecioNochePremium = int.Parse(datosHotel["precioPremium"].ToString());
                hotel.Descripcion = datosHotel["Descripcion"].ToString();
                hotel.Condicion = datosHotel["Condicion"].ToString();
                hotel.Checkin = datosHotel["Checkin"].ToString();
                hotel.Checkout = datosHotel["Checkout"].ToString();
                hotel.Usuarioencargado = datosHotel["UsuarioEncargado"].ToString();
                hotel.Idusuario = int.Parse(datosHotel["idUsuario"].ToString());
                hotel.Idzona = int.Parse(datosHotel["Idzona"].ToString());
                hotel.Condicionesbioseguridad = datosHotel["Condicionesbioseguridad"].ToString();
                hotel.Direccion = datosHotel["Direccion"].ToString();

                JToken imagenPrin = datosHotel["imagenPrincipal"];
                List<byte> listadebytes = new List<byte>();
                foreach (JToken bite in imagenPrin)
                {
                    listadebytes.Add(byte.Parse(bite.ToString()));
                }
                byte[] imagenPrincipal = listadebytes.ToArray();

                JToken imagensec = datosHotel["imagen2"];
                List<byte> listadebytes2 = new List<byte>();
                foreach (JToken bite in imagensec)
                {
                    listadebytes2.Add(byte.Parse(bite.ToString()));
                }
                byte[] imagen2 = listadebytes2.ToArray();

                JToken imagenter = datosHotel["imagen3"];
                List<byte> listadebytes3 = new List<byte>();
                foreach (JToken bite in imagenter)
                {
                    listadebytes3.Add(byte.Parse(bite.ToString()));
                }
                byte[] imagen3 = listadebytes3.ToArray();

                string nombreArchivo1;
                string ext1;
                string direccion1;
                string nombreArchivo2;
                string nombreArchivo3;
                string ext2 = null;
                string ext3 = null;
                string direccion2 = null;
                string direccion3 = null;
                if (imagenPrincipal != null)
                {
                    nombreArchivo1 = usuario.Usuario + "Principal";
                    ext1 = datosHotel["ext1"].ToString();
                    direccion1 = "~\\Imagenes\\imagenesHotel\\" + nombreArchivo1 + ext1;
                    if (imagen2 == null)
                    {
                        nombreArchivo2 = null;
                        ext2 = null;

                    }
                    else if (imagen3 == null)
                    {
                        nombreArchivo3 = null;
                        ext3 = null;
                    }
                    else
                    {
                        nombreArchivo2 = usuario.Usuario + "Secundaria";
                        nombreArchivo3 = usuario.Usuario + "Terciaria";
                        //string imagen = HttpContext.Current.Server.MapPath("~\\Vew\\imgusuarios\\") + nombreArchivo;

                        ext2 = datosHotel["ext2"].ToString();
                        ext3 = datosHotel["ext3"].ToString();

                        direccion2 = "~\\Imagenes\\imagenesHotel\\" + nombreArchivo2 + ext2;
                        direccion3 = "~\\Imagenes\\imagenesHotel\\" + nombreArchivo3 + ext3;
                    }
                    return Ok(new LAgregarServicioHotel().insertHotel(imagenPrincipal, imagen2, imagen3, direccion1, direccion2, direccion3, ext1, ext2, ext3, hotel));
                }
                else
                {
                    return BadRequest("Debe cargar una imagen principal");
                }
                // string imagenEliminar = perfil.Datos.Fotoperfil;
                //imagenEliminar = HttpContext.Current.Server.MapPath(imagenEliminar);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
