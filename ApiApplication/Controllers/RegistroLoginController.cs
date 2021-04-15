using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Utilitarios;

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

        [HttpPost]
        [Route("api/registroLogin/postIngresoLogin")]
        public UMAC PostIngresoLogin(URegistro login)
        {
            return new LLogin().ingreso_login(login);
        }
    }
}
