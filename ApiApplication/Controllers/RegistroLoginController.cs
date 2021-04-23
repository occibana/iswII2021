using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApiApplication.Seguridad;
using Logica;
using Newtonsoft.Json.Linq;
using Utilitarios;
using Utilitarios.Entrada;

namespace ApiApplication.Controllers
{
    
    [Route("api/[controller]")]

    public class RegistroLoginController : ApiController
    {

        /// <summary>
        ///  Servicio para regitrar un usuario
        /// </summary>
        /// <returns>regitrar un usuario</returns>

        [HttpPost]
        [Route("api/registroLogin/postRegistroUsuario")]
        public URegistroMensaje PostRegistroUsuario(URegistro registro)
        {
            return new LRegistro().registro(registro);
        }
        /*
        [HttpPost]
        [Route("api/registroLogin/postIngresoLogin")]
        public UMAC PostIngresoLogin(URegistro login)
        {
            return new LLogin().ingreso_login(login);
        }*/


        /// <summary>
        ///  Servicio para solicitar ingreso al login
        /// </summary>
        /// <returns>
        /// ingreso al login - Token
        /// </returns>

        [HttpPost]
        [Route("api/registroLogin/postIngresoLogin")]
        public async Task<IHttpActionResult> login(LoginRequest login)
        {
            if (!ModelState.IsValid)
            {
                string error = "Datos incorrectos";
                foreach (var state in ModelState)
                {
                    foreach (var item in state.Value.Errors)
                    {
                        error += $" {item.ErrorMessage}";
                    }
                }
                return BadRequest(error);
            }
            URegistro usuario_login = await new LLogin().ingresoLogin(login);
            if (usuario_login == null)
            {
                return Unauthorized();
            }
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(usuario_login);
                return Ok(token);
            }
        }

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

    }
}
