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
        private string URL;
        private string mensaje;

        private bool B_ComprarMembresia;
        private bool B_ActualizarMembresia;
        private bool B_AgregarHotel;
        private bool B_mishoteles;

        private string fotoperfil;


        private URegistro datos;




        public string EstadoMembresia { get => estadoMembresia; set => estadoMembresia = value; }
        public string URL1 { get => URL; set => URL = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public URegistro Datos { get => datos; set => datos = value; }

        public bool B_ComprarMembresia1 { get => B_ComprarMembresia; set => B_ComprarMembresia = value; }
        public bool B_ActualizarMembresia1 { get => B_ActualizarMembresia; set => B_ActualizarMembresia = value; }
        public bool B_AgregarHotel1 { get => B_AgregarHotel; set => B_AgregarHotel = value; }
        public bool B_mishoteles1 { get => B_mishoteles; set => B_mishoteles = value; }
        public string Fotoperfil { get => fotoperfil; set => fotoperfil = value; }
    }
}
