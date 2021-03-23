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
        string mensaje;
        bool aviso;

        public UHotel Hotel { get => hotel; set => hotel = value; }
        public URegistro Registro { get => registro; set => registro = value; }
        public UHabitacion Habitacion { get => habitacion; set => habitacion = value; }
        public string Url { get => url; set => url = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public bool Aviso { get => aviso; set => aviso = value; }
    }
}
