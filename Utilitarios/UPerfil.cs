using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UPerfil
    {
        private string estadoMembresia;
        private bool visivilidadBoton;
        private string URL;
        private string mensaje;
        private URegistro datos;

        public string EstadoMembresia { get => estadoMembresia; set => estadoMembresia = value; }
        public bool VisivilidadBoton { get => visivilidadBoton; set => visivilidadBoton = value; }
        public string URL1 { get => URL; set => URL = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public URegistro Datos { get => datos; set => datos = value; }
    }
}
