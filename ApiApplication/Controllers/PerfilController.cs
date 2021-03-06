﻿using Logica;
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
        ///  {"usuario": "string"}
        /// </summary>
        /// <returns>
        /// datos peronales en perfil
        /// </returns>
        [Authorize]
        [HttpPost]
        [Route("api/perfil/postCargarDatosPerfil")]
        public IHttpActionResult postCargarDatosPerfil(URegistro dato)
        {
            try
            {
                return Ok(new LPerfil().cargardatos(dato));
            }
            catch(Exception ex)
            {
                var mensaje = "surgio el siguente error: "+ex.Message.ToString();
                return BadRequest(mensaje);
            }
            
        }

        /// <summary>
        ///  Servicio para actualizar contraseña
        ///  {
        ///  "usuario":"string",
        ///  "Correo":"string-correo",
        ///  "contrasenaAct":"string",
        ///  "contrasenaNueva":"string"
        ///  }
        /// </summary>
        /// <returns>
        /// actualizacion contraseña
        /// </returns>
        [HttpPut]
        [Route("api/perfil/putActualizarContrasena")]
        public async Task<IHttpActionResult> putActualizarContrasena([FromBody] JObject contrasena)
        {
            URegistro registro = new URegistro();
            try
            {
                //registro.Id = int.Parse(contrasena["Id"].ToString());
                registro.Usuario = contrasena["usuario"].ToString();
                registro.Correo = contrasena["Correo"].ToString();
                string contraAct = contrasena["contrasenaAct"].ToString();
                string contraNueva = contrasena["contrasenaNueva"].ToString();

                UActualizarContrasena actualizarContra = await new LActualizarContrasena().actualizarContrasena(registro, contraAct, contraNueva);
                var datos = actualizarContra;
                return Ok(datos);
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }

        }

        /// <summary>
        ///  Servicio para cerrar session - recibe usuario como parametro
        ///  {"usuario": "string"}
        /// </summary>
        
        [Authorize]
        [HttpPost]
        [Route("api/perfil/postCerrarSesion")]
        public IHttpActionResult postCerrarSesion([FromBody] JObject datoUsuario)
        {
            try
            {
                URegistro datos = new URegistro();
                datos.Usuario = datoUsuario["usuario"].ToString();
                return Ok(new LPerfil().cerrarsession(datos));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
            
        }

        /// <summary>
        /// Servicio para Actualizar datos personales
        /// {
        ///  "NombreRegistro":"string o null",
        ///  "ApellidoRegistro":"string o null",
        ///  "UsuarioRegistro":"string o null",
        ///  "TelefonoRegistro":"string o null",
        ///  "CorreoRegistro":"string o null",
        ///  "NombreSession":"string",
        ///  "ApellidoSession":"string",
        ///  "UsuarioSession":"string",
        ///  "TelefonoSession":"string",
        ///  "CorreoSession":"string",
        ///  "UsuarioIdSession":int
        /// }
        /// </summary>

        [Authorize]
        [HttpPost]
        [Route("api/perfil/postActualizarDatos")]
        public async Task<IHttpActionResult> postActualizarDatos([FromBody] JObject datoUsuario)
        {
            try
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
                datosSession.Id = int.Parse(datoUsuario["UsuarioIdSession"].ToString());
                return Ok(await new LActualizarDatos().actualizarDatos(datosRegistro, datosSession));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }

        }

        /// <summary>
        ///  Servicio para agregar habitacion
        ///  {
        ///  "TipoHabitacion":"string o null",
        ///  "IdHotel":int,
        ///  "NumeroMaximoDePersonas":int
        ///  "NumeroDeBanos":int
        ///  "NumeroDeCamas":int
        ///  "tipoHabitacionNumero":int
        ///  }
        ///  tipoHabitacion 1:basica , 2:doble , 3:premium
        ///  TipoHabitacion por defecto : --Seleccionar--
        /// </summary>

        [Authorize]
        [HttpPost]
        [Route("api/perfil/postAgregarhabitacion")]
        public async Task<IHttpActionResult> postAgregarhabitacion([FromBody] JObject datoUsuario)
        {
            UHabitacion habitacion = new UHabitacion();
            try
            {
                habitacion.Tipo = datoUsuario["TipoHabitacion"].ToString();
                habitacion.Idhotel = int.Parse(datoUsuario["IdHotel"].ToString());
                habitacion.Numpersonas = int.Parse(datoUsuario["NumeroMaximoDePersonas"].ToString());
                habitacion.Numbanio = int.Parse(datoUsuario["NumeroDeBanos"].ToString());
                habitacion.Numcamas = int.Parse(datoUsuario["NumeroDeCamas"].ToString());
                int idTipo = int.Parse(datoUsuario["tipoHabitacionNumero"].ToString());
                return Ok(await new LHabitacion().agregarHabitacion(idTipo, habitacion));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
        }

        /// <summary>
        ///  Servicio para comprar membresias
        ///  {
        ///  "Cedula":"string",
        ///  "CodigoDeSeguridad":"string",
        ///  "DireccionPropietario":"string",
        ///  "NombreDelPropietario":"string",
        ///  "NumeroTarjeta":"string",
        ///  "Usuario":"string",
        ///  "Contrasena":"string",
        ///  "Id":int
        ///  "Correo":"string",
        ///  "UsuarioSession":"string",
        ///  "IdUsuarioSession":"string"
        ///  }
        /// </summary>
        /// <returns>
        /// 
        /// </returns>

        [HttpPost]
        [Route("api/perfil/postComprarMembresias")]
        public async Task<IHttpActionResult> postComprarMembresias([FromBody] JObject dato)
        {
            UMembresia datoscompra = new UMembresia();
            URegistro usuario = new URegistro();
            URegistro usuarioSession = new URegistro();
            try
            {
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

                return Ok(await new LMembresias().comprar(datoscompra, usuario, usuarioSession));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
            
        }

        /// <summary>
        /// Servicio para cargar imagen de perfil.
        /// {
        /// "imagen":string,
        /// "usuario":string,
        /// "extension":string
        /// }
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
            String imagenPerfil = foto["imagen"].ToString();

            byte[] fotoPerfil = Convert.FromBase64String(imagenPerfil);

            usuario.Usuario = foto["usuario"].ToString();
            perfil = new LPerfil().cargardatos(usuario);
            usuario.Id = perfil.Datos.Id;
            string nombreArchivo = usuario.Usuario + "Perfil";
           
            string ext = foto["extension"].ToString();
            string direccion = "~\\Views\\imgusuarios\\" + nombreArchivo + ext;
            string imagenEliminar = perfil.Datos.Fotoperfil;
            imagenEliminar = HttpContext.Current.Server.MapPath(imagenEliminar);

            return  new LPerfil().subirFoto(fotoPerfil, usuario,direccion,ext,imagenEliminar);
        }



    }
}
