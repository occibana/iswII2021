using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UMisReservas
    {
        private UHotel infohotel;
        private string URL;
        private string mensaje;

        public UHotel Infohotel { get => infohotel; set => infohotel = value; }
        public string URL1 { get => URL; set => URL = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
