using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios.Entrada;
using Logica;

namespace ApiApplication.Controllers
{
    [RoutePrefix("api/admin")]
    public class SeguridadLoginController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public IHttpActionResult login(LoginRequest login)
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
            UUsuario user = new LUsuario().Login(login);
            if (user == null)
                return Unauthorized();
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(user);
                return Ok(token);
            }
        }


        [Route("Get-Users")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetUsers()
        {
            return Ok(new LUsuario().GetUsers());
        }
    }
}
}


