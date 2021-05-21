using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServiciosNC.Security;
using DataNC;
using LogicaNC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Utilitarios;
using Utilitarios.Entrada;

namespace ApiServiciosNC.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SeguridadLoginNCController : ControllerBase
    {
        private readonly Mapeo _context;

        public SeguridadLoginNCController(Mapeo context)
        {
            _context = context;
        }

        //[Route("login")]
        //[HttpPost]

        //public async Task<ActionResult> login(LoginRequest login)
        //{
        //    string mensaje;
        //    if (!ModelState.IsValid)
        //    {
        //        string error = "Datos incorrectos.";

        //        foreach (var state in ModelState)
        //        {
        //            foreach (var item in state.Value.Errors)
        //            {
        //                error += $" {item.ErrorMessage}";
        //            }
        //        }
        //        return BadRequest(error);
        //    }
        //    //URegistro user = await new LLogin().ingreso(login);
        //    URegistro user = await new LLogin(_context).ingresoLogin(login);
        //    if (user == null)
        //        return Unauthorized();
        //    else
        //    {
        //        var token = TokenGenerator.GenerateTokenJwt();
        //        return Ok(token);
        //    }
        //}

        [HttpPost]
        [Route("api/seguridadNC/postCorreoRecuperacion")]
        [Authorize]
        public string postCorreoRecuperacion(URegistro usuario)
        {
            return new LRecuperarcontrasena(_context).enviar_token(usuario);
        }

        [HttpPut]
        [Route("api/seguridadNC/putReactivarCuenta")]
        [Authorize]
        public URegistro putContrasenaRecuperada([FromBody] JObject recuperacion)
        {
            URegistro datos = new URegistro();
            UPerfil perfil = new UPerfil();
            datos.Usuario = recuperacion["usuario"].ToString();
            datos.Contrasena = recuperacion["contrasena"].ToString();
            string codigo = recuperacion["codigo"].ToString();
            perfil = new LPerfil(_context).cargardatos(datos);
            datos.Id = perfil.Datos.Id;

            return new LReactivarCuenta(_context).recuperarContrasena(codigo, datos);

        }

    }
}