using System.Collections.Generic;
using DataNC;
using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Utilitarios;

namespace ApiServiciosNC.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ListasNCController : ControllerBase
    {
        private readonly Mapeo _context;

        public ListasNCController(Mapeo context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/listasNC/getListasZonas")]
        public List<UHotelZona> GetLisasZonas()
        {
            return new Listas(_context).listaZonas();
        }


        [HttpGet]
        [Route("api/listasNC/getListasMunicipios")]
        public List<UHotelMunicipio> GetLisasMunicipios()
        {
            return new Listas(_context).listaMunicipios();
        }

    }
}