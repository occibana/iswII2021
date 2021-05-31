using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios.Entrada;
using Logica;
using Utilitarios;
using System.Threading.Tasks;

using System.Web.Http.Cors;
using WebApiSegura.Security;
using Newtonsoft.Json.Linq;


namespace ApiApplication.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/admin")]
    public class SeguridadLoginController : ApiController
    {
        /// <summary>
        ///  Servicio para ingreso login - seguridad
        /// </summary>
        /// <returns>
        /// token
        /// </returns>

        [Route("login")]
        [HttpPost]

        public async Task<IHttpActionResult> login(LoginRequest login)
        {
            string mensaje;
            if (!ModelState.IsValid)
            {
                string error = "Datos incorrectos.";

                foreach (var state in ModelState)
                {
                    foreach (var item in state.Value.Errors)
                    {
                        error += $" {item.ErrorMessage}";
                    }
                }
                return BadRequest(error);
            }
            //URegistro user = await new LLogin().ingreso(login);
            URegistro user = await new LLogin().ingresoLogin(login);
            if (user == null)
                return Unauthorized();
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(user);
                return Ok(token);
            }
        }

        /// <summary>
        ///  Servicio para enviar el correo con el codigo de recuperacion
        ///  de contraseña
        /// {
        ///  "usuario":"string",
        ///  "correo":"string"
        /// }
        /// </summary>
        /// <returns>
        /// token
        /// </returns>
        [HttpPost]
        [Route("postCorreoRecuperacion")]
        public IHttpActionResult postCorreoRecuperacion([FromBody] JObject correoRecuperacion)
        {
            try
            {
                URegistro recuperar = new URegistro();
                recuperar.Usuario = correoRecuperacion["usuario"].ToString();
                recuperar.Correo = correoRecuperacion["correo"].ToString();
                return Ok(new LRecuperarcontrasena().enviar_token(recuperar));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }
            
        }

        /// <summary>
        ///  Servicio para enviar el correo con el codigo de recuperacion Transversal
        ///  de contraseña
        /// {
        ///  "usuario":"string",
        ///  "correo":"string"
        /// }
        /// </summary>
        /// <returns>
        /// token
        /// </returns>
        [HttpPost]
        [Route("postCorreoRecuperacionTransversal")]
        public IHttpActionResult postCorreoRecuperacionTransversal([FromBody] JObject correoRecuperacion)
        {
            try
            {
                URegistro recuperar = new URegistro();
                recuperar.Usuario = correoRecuperacion["usuario"].ToString();
                recuperar.Correo = correoRecuperacion["correo"].ToString();
                return Ok(new LRecuperarcontrasena().enviar_token(recuperar));
            }
            catch (Exception ex)
            {
                var mensaje = "surgio el siguente error: " + ex.Message.ToString();
                return BadRequest(mensaje);
            }

        }

        /// <summary>
        ///  Servicio que valida el codigo de recuperacion de contraseña
        ///  y actuzaliza la contraseña con la nueva contreseña
        /// </summary>
        /// <returns>
        /// token
        /// </returns>
        /// 






        [HttpPut]
        [Route("putReactivarCuenta")]
        public URegistro putContrasenaRecuperada([FromBody] JObject recuperacion)
        {
            URegistro datos = new URegistro();
            UPerfil perfil = new UPerfil();
            datos.Usuario = recuperacion["usuario"].ToString();
            datos.Contrasena = recuperacion["contrasena"].ToString();
            string codigo =recuperacion["codigo"].ToString();
            perfil = new LPerfil().cargardatos(datos);
            datos.Id = perfil.Datos.Id;

            return new LReactivarCuenta().recuperarContrasena(codigo, datos);
        }






        /*
        [Route("Get-Users")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetUsers()
        {
            return Ok(new LLogin().GetUsers());
        }*/
    }
}


