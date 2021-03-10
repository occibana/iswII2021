using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UMembresias
    {
        private bool numeroTarjeta;
        private bool codigoSeguridad;
        private bool nombrePropietario;
        private bool direccionPropietario;
        private bool cedulaPropietario;
        private bool usuario;
        private bool contrasena;
        private bool comprar;

        private string actualizar_Comprar;
        private string mensajecompra;
        private string costo;
        private string vencimiento;
        private string error;

        public bool NumeroTarjeta { get => numeroTarjeta; set => numeroTarjeta = value; }
        public bool CodigoSeguridad { get => codigoSeguridad; set => codigoSeguridad = value; }
        public bool NombrePropietario { get => nombrePropietario; set => nombrePropietario = value; }
        public bool DireccionPropietario { get => direccionPropietario; set => direccionPropietario = value; }
        public bool CedulaPropietario { get => cedulaPropietario; set => cedulaPropietario = value; }
        public bool Usuario { get => usuario; set => usuario = value; }
        public bool Contrasena { get => contrasena; set => contrasena = value; }
        public bool Comprar { get => comprar; set => comprar = value; }
        public string Actualizar_Comprar { get => actualizar_Comprar; set => actualizar_Comprar = value; }
        public string Mensajecompra { get => mensajecompra; set => mensajecompra = value; }
        public string Costo { get => costo; set => costo = value; }
        public string Vencimiento { get => vencimiento; set => vencimiento = value; }
        public string Error { get => error; set => error = value; }
    }
}
