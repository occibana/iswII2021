using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UDatosUsuario
    {
        private UHotel hotel;
        private URegistro registro;
        private UHabitacion habitacion;
        string url;

        public UHotel Hotel { get => hotel; set => hotel = value; }
        public URegistro Registro { get => registro; set => registro = value; }
        public UHabitacion Habitacion { get => habitacion; set => habitacion = value; }
        public string Url { get => url; set => url = value; }
    }
}
