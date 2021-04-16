using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApiApplication.Seguridad;
using Logica;
using Utilitarios;
using Utilitarios.Entrada;

namespace ApiApplication.Controllers
{
    
    [Route("api/[controller]")]

    public class RegistroLoginController : ApiController
    {
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
            URegistro usuario_login = await new LLogin().ingreso(login);
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
