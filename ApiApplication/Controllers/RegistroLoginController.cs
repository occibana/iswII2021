using System.Threading.Tasks;
using System.Web.Http;
using Logica;
using Utilitarios;
using Utilitarios.Entrada;
//cors
using System.Web.Http.Cors;
using WebApiSegura.Security;

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
        public async Task<URegistroMensaje> PostRegistroUsuario(URegistro registro)
        {
            return await new LRegistro().registro(registro);
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
                return Unauthorized();
            }
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(usuario_login);
                return Ok(token);
            }
        }
    }
}
