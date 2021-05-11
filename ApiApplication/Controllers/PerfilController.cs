using Logica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//cors
using System.Web.Http.Cors;
using Utilitarios;

namespace ApiApplication.Controllers
{
    //[EnableCors(origins:"*", headers: "*", methods:"*")]
    [EnableCors("*", "*", "*")]

    [Route("api/[controller]")]
    [Authorize]
    public class PerfilController : ApiController
    {
        /// <summary>
        ///  Servicio para cargar datos peronales en perfil
        /// </summary>
        /// <returns>
        /// datos peronales en perfil
        /// </returns>
        [Authorize]
        [HttpPost]
        [Route("api/perfil/postCargarDatosPerfil")]
        public UPerfil postCargarDatosPerfil(URegistro dato)
        {
            return new LPerfil().cargardatos(dato);
        }

        /// <summary>
        ///  Servicio para actualizar contraseña
        /// </summary>
        /// <returns>
        /// actualizacion contraseña
        /// </returns>

        [HttpPut]
        [Route("api/perfil/putActualizarContrasena")]
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
        [Route("api/perfil/postCerrarSesion")]
        public string postCerrarSesion([FromBody] JObject datoUsuario)
        {
            URegistro datos = new URegistro();
            datos.Usuario = datoUsuario["usuario"].ToString();
            return new LPerfil().cerrarsession(datos);
        }

        /// <summary>
        ///  Servicio para Actualizar datos personales
        /// </summary>

        [HttpPost]
        [Route("api/perfil/postActualizarDatos")]
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
        ///  Servicio para agregar habitacion
        /// </summary>

        [HttpPost]
        [Route("api/perfil/postAgregarhabitacion")]
        public async Task<UHabitacion> postAgregarhabitacion([FromBody] JObject datoUsuario)
        {
            UHabitacion habitacion = new UHabitacion();
            habitacion.Tipo = datoUsuario["TipoHabitacion"].ToString();
            habitacion.Idhotel = int.Parse(datoUsuario["IdHotel"].ToString());
            int idTipo = int.Parse(datoUsuario["usuario"].ToString());
            return await new LHabitacion().agregarHabitacion(idTipo,habitacion);
        }

        /// <summary>
        ///  Servicio para comprar membresias
        /// </summary>
        /// <returns>
        /// 
        /// </returns>

        [HttpPost]
        [Route("api/perfil/postComprarMembresias")]
        public async Task<UMembresias> postComprarMembresias([FromBody] JObject dato)
        {
            UMembresia datoscompra = new UMembresia();
            URegistro usuario = new URegistro();
            URegistro usuarioSession = new URegistro();

            datoscompra.Cedulapropietario = dato["Cedula"].ToString();
            datoscompra.Codigoseguridad = dato["CodigoDeSeguridad"].ToString();
            datoscompra.Direccionpropietario = dato["DireccionPropietario"].ToString();
            datoscompra.Nombrepropietario = dato["NombreDelPropietario"].ToString();
            datoscompra.Numerotarjeta = dato["NumeroTarjeta"].ToString();
            datoscompra.Fecha_compra = DateTime.Now;
            datoscompra.Fecha_vencimiento = DateTime.Now.AddYears(1);
            usuario.Usuario = dato["Usuario"].ToString();
            usuario.Contrasena = dato["Contrasena"].ToString();
            usuario.Id = int.Parse(dato["Id"].ToString());
            usuario.Correo = dato["Correo"].ToString();

            usuarioSession.Usuario = dato["UsuarioSession"].ToString();
            usuarioSession.Id = int.Parse(dato["IdUsuarioSession"].ToString());

            return await new LMembresias().comprar(datoscompra,usuario,usuarioSession);
        }

        /// <summary>
        /// Servicio para cargar imagen de perfil.
        /// </summary> 
        /// <returns>Mensaje de aviso de subido o error</returns>
        /// <Autor>Jonathan Cardenas</Autor>
        /// <Fecha>2021/04/26</Fecha>
        /// <UltimaActualizacion>2021/04/26 - Jonathan Cardenas - Creación del servicio</UltimaActualizacion>

        [HttpPost]
        [Route("api/perfil/postSubirFoto")]
        public UPerfil postSubirFoto([FromBody] JObject foto)
        {
            UPerfil perfil = new UPerfil();
            URegistro usuario = new URegistro();

            JToken imagenPerfil = foto["imagen"];
            List<byte> listadebytes = new List<byte>();
            foreach (JToken bite in imagenPerfil)
            {
                listadebytes.Add(byte.Parse(bite.ToString()));
            }
            byte[] fotoPerfil = listadebytes.ToArray();

            usuario.Usuario = foto["usuario"].ToString();
            perfil = new LPerfil().cargardatos(usuario);
            usuario.Id = perfil.Datos.Id;
            string nombreArchivo = usuario.Usuario + "Perfil";
           
            //string imagen = HttpContext.Current.Server.MapPath("~\\Vew\\imgusuarios\\") + nombreArchivo;
            string ext = foto["extension"].ToString();
            string direccion = "~\\Vew\\imgusuarios\\" + nombreArchivo + ext;
            string imagenEliminar = perfil.Datos.Fotoperfil;
            imagenEliminar = HttpContext.Current.Server.MapPath(imagenEliminar);

            return  new LPerfil().subirFoto(fotoPerfil, usuario,direccion,ext,imagenEliminar);
        }



    }
}
