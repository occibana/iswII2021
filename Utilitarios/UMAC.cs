using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UMAC
    {
        private URegistro registro;
        private DateTime fechaInicio;
        private string url;
        private string mensaje;

        public URegistro Registro { get => registro; set => registro = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string Url { get => url; set => url = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
