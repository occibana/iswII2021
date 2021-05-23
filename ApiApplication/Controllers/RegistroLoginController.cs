using System.Threading.Tasks;
using System.Web.Http;
using Logica;
using Utilitarios;
using Utilitarios.Entrada;
//cors
using System.Web.Http.Cors;
using WebApiSegura.Security;
using System;

namespace ApiApplication.Controllers
{

    //[EnableCors(origins:"*", headers: "*", methods:"*")]
    [EnableCors("*", "*", "*")]

    [Route("api/[controller]")]

    public class RegistroLoginController : ApiController
    {

        /// <summary>
        ///  Servicio para regitrar un usuario
        /// </summary>
        /// <returns>regitrar un usuario</returns>

        [HttpPost]
        [Route("api/registroLogin/postRegistroUsuario")]
        public async Task<IHttpActionResult> PostRegistroUsuario(URegistro registro)
        {
            URegistroMensaje mensaje = new URegistroMensaje();
            try
            { 
                mensaje = await new LRegistro().registro(registro);
                var msj = mensaje.Mensaje;
                return Ok(msj);
            }
            catch (Exception ex)
            {
                var error = mensaje.Mensaje;
                return BadRequest(error+" "+ex);
            }
        }


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
                var mensaje = "Usuario o contraseña incorrecto";
                return BadRequest(mensaje);
            }
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(usuario_login);
                return Ok(token);
            }
        }
    }
}
