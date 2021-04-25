using Logica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
//cors
using System.Web.Http.Cors;
using Utilitarios;

namespace ApiApplication.Controllers
{
    //[EnableCors(origins:"*", headers: "*", methods:"*")]
    [EnableCors("*", "*", "*")]

    [Route("api/[controller]")]

    public class PerfilController : ApiController
    {
        /// <summary>
        ///  Servicio para cargar datos peronales en perfil
        /// </summary>
        /// <returns>
        /// datos peronales en perfil
        /// </returns>

        [HttpPost]
        [Route("api/registroLogin/postCargarDatosPerfil")]
        public async Task<UPerfil> postCargarDatosPerfil(URegistro dato)
        {
            return await new LPerfil().cargardatos(dato);
        }

        /// <summary>
        ///  Servicio para actualizar contraseña
        /// </summary>
        /// <returns>
        /// actualizacion contraseña
        /// </returns>

        [HttpPut]
        [Route("api/registroLogin/putActualizarContrasena")]
        public async Task<IHttpActionResult> putActualizarContrasena([FromBody] JObject contrasena)
        {
            URegistro registro = new URegistro();
            //registro.Id = int.Parse(contrasena["Id"].ToString());
            registro.Usuario = contrasena["usuario"].ToString();
            registro.Correo = contrasena["Correo"].ToString();
            string contraAct = contrasena["contrasenaAct"].ToString();
            string contraNueva = contrasena["contrasenaNueva"].ToString();

            UActualizarContrasena actualizarContra = await new LActualizarContrasena().actualizarContrasena(registro, contraAct, contraNueva);
            var datos = actualizarContra;
            return Ok(datos);
        }

        /// <summary>
        ///  Servicio para cerrar session - recibe usuario como parametro
        /// </summary>

        [HttpPost]
        [Route("api/registroLogin/postCerrarSesion")]
        public async Task<string> postCerrarSesion([FromBody] JObject datoUsuario)
        {
            URegistro datos = new URegistro();
            datos.Usuario = datoUsuario["usuario"].ToString();
            return await new LPerfil().cerrarsession(datos);
        }

        /// <summary>
        ///  Servicio para Actualizar datos personales
        /// </summary>

        [HttpPost]
        [Route("api/registroLogin/postActualizarDatos")]
        public async Task<UActualizarDatos> postActualizarDatos([FromBody] JObject datoUsuario)
        {
            URegistro datosRegistro = new URegistro();
            URegistro datosSession = new URegistro();
            datosRegistro.Nombre = datoUsuario["NombreRegistro"].ToString();
            datosRegistro.Apellido = datoUsuario["ApellidoRegistro"].ToString();
            datosRegistro.Usuario = datoUsuario["UsuarioRegistro"].ToString();
            datosRegistro.Telefono = datoUsuario["TelefonoRegistro"].ToString();
            datosRegistro.Correo = datoUsuario["CorreoRegistro"].ToString();
            datosSession.Nombre = datoUsuario["NombreSession"].ToString();
            datosSession.Apellido = datoUsuario["ApellidoSession"].ToString();
            datosSession.Usuario = datoUsuario["UsuarioSession"].ToString();
            datosSession.Telefono = datoUsuario["TelefonoSession"].ToString();
            datosSession.Correo = datoUsuario["CorreoSession"].ToString();
            datosSession.Correo = datoUsuario["UsuarioIdSession"].ToString();
            return await new LActualizarDatos().actualizarDatos(datosRegistro, datosSession);
        }

        /// <summary>
        ///  Servicio para agregar un servicio de hotel
        /// </summary>
        /*
        [HttpPost]
        [Route("api/registroLogin/postAgregarServicioHotel")]
        public async Task<string> postAgregarServicioHotel([FromBody] JObject datosHotel)
        {
            UHotel hotel = new UHotel();
            
            hotel.Nombre = datosHotel["Nombre"].ToString();
            hotel.Municipio = datosHotel["Municipio"].ToString();
            hotel.Idmunicipio = int.Parse(datosHotel["IdMunicipio"].ToString());
            hotel.Numhabitacion = int.Parse(datosHotel["NumeroDeHabitaciones"].ToString());
            hotel.Precionoche = int.Parse(datosHotel["PrecioNocheBasica"].ToString());
            hotel.PrecioNocheDoble = int.Parse(datosHotel["PrecioNocheDoble"].ToString());
            hotel.PrecioNochePremium = int.Parse(datosHotel["PrecioNochePremium"].ToString());
            hotel.Descripcion = datosHotel["Descripcion"].ToString();;
            hotel.Condicion = datosHotel["Condicion"].ToString();
            hotel.Checkin = datosHotel["CheckIn"].ToString();
            hotel.Checkout = datosHotel["CheckOut"].ToString();
            hotel.Usuarioencargado = datosHotel["UsuarioEncargado"].ToString();
            hotel.Idusuario = int.Parse(datosHotel["IdUsuario"].ToString());
            hotel.Idzona = int.Parse(datosHotel["IdZona"].ToString());
            hotel.Condicionesbioseguridad = datosHotel["CondicionesBioseguridad"].ToString(); 
            hotel.Direccion = datosHotel["Direccion"].ToString();
            string direccionImagen1= datosHotel["DireccionImagen1"].ToString();
            string direccionImagen2 = datosHotel["DireccionImagen2"].ToString();
            string direccionImagen3 = datosHotel["DireccionImagen3"].ToString();
            string direccionImagen1G = datosHotel["DireccionImagen1G"].ToString();
            string direccionImagen2G = datosHotel["DireccionImagen2G"].ToString();
            string direccionImagen3G = datosHotel["DireccionImagen3G"].ToString();
            string Imagen1 = datosHotel["Imagen1"].ToString();
            string Imagen2 = datosHotel["Imagen2"].ToString();
            string Imagen3 = datosHotel["Imagen3G"].ToString();
            return await new LAgregarServicioHotel().insertHotel(Imagen1,Imagen2,Imagen3, direccionImagen1, direccionImagen2, direccionImagen3, direccionImagen1G, direccionImagen2G, direccionImagen3G,hotel);
        }*/
    }
}
