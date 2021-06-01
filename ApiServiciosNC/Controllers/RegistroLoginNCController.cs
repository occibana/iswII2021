using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Entrada;
using Utilitarios;
using LogicaNC;
using ApiServiciosNC.Security;
using DataNC;
using Microsoft.Extensions.Configuration;
using System;

namespace ApiServiciosNC.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class RegistroLoginNCController : ControllerBase
    {
        private readonly Mapeo _context;
        private readonly IConfiguration _configuration;

        public RegistroLoginNCController(Mapeo context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/registroLoginNC/postRegistroUsuario")]
        public async Task<URegistroMensaje> PostRegistroUsuario(URegistro registro)
        {
            return await new LRegistro(_context).registro(registro);
        }

        [HttpPost]
        [Route("api/registroLoginNC/postIngresoLogin")]
        public async Task<ActionResult> login(LoginRequest login)
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
            URegistro usuario_login = await new LLogin(_context).ingresoLogin(login);
            if (usuario_login == null)
            {
                return Unauthorized();
            }
            else
            {
                var JWT_SECRET_KEY = _configuration["JWT_SECRET_KEY"];
                var JWT_AUDIENCE_TOKEN = _configuration["JWT_AUDIENCE_TOKEN"];
                var JWT_ISSUER_TOKEN = _configuration["JWT_ISSUER_TOKEN"];
                var JWT_EXPIRE_HOURS = _configuration["JWT_EXPIRE_HOURS"];

                LoginToken token = new LoginToken();
                token.FechaGenerado = DateTime.Now;
                token.FechaVigencia = DateTime.Now.AddMinutes(15);
                token.User_id = usuario_login.Id;
                //token.Token = jwtTokenString;

                token.Token = TokenGenerator.GenerateTokenJwt(usuario_login, JWT_SECRET_KEY, JWT_AUDIENCE_TOKEN, JWT_ISSUER_TOKEN, JWT_EXPIRE_HOURS);
                await new LLogin(_context).guardarToken(token);
                return Ok(token.Token);
            }
        }

    }
}