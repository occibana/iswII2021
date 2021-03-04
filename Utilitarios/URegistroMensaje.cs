using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class URegistroMensaje
    {
        private string tB_ccontrasena;
        private string tB_contrasenaregistro;
        private string tB_nombre;
        private string tB_apellido;
        private string tB_correo;
        private string tB_telefono;
        private string tB_usuarioregistro;
        private string mensaje;
        private string URL;

        public string TB_ccontrasena { get => tB_ccontrasena; set => tB_ccontrasena = value; }
        public string TB_contrasenaregistro { get => tB_contrasenaregistro; set => tB_contrasenaregistro = value; }
        public string TB_nombre { get => tB_nombre; set => tB_nombre = value; }
        public string TB_apellido { get => tB_apellido; set => tB_apellido = value; }
        public string TB_correo { get => tB_correo; set => tB_correo = value; }
        public string TB_telefono { get => tB_telefono; set => tB_telefono = value; }
        public string TB_usuarioregistro { get => tB_usuarioregistro; set => tB_usuarioregistro = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string URL1 { get => URL; set => URL = value; }
    }
}
