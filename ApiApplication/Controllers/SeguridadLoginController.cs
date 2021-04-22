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
using ApiApplication.Seguridad;

namespace ApiApplication.Controllers
{
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


