using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Utilitarios;

namespace ApiServicios.Controllers
{
    [RoutePrefix("api/listas")]
    public class ListasController : ApiController
    {

        [Route("GetListas")]
        public async Task<List<UHotelZona>> GetListaZonas()
        {
            return new Listas().listaZonas();
        }

        [Route("GetPrueba")]
        public string Get(int id)
        {
            return "Funciona";
        }
    }
}
