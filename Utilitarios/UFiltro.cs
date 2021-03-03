using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    public class UFiltro
    {               
        public int idhotel;
        public String nombrehotel;
        public Nullable<double> preciomax;
        public Nullable<double> preciomin;
        public Nullable<int> numpersonas;
        public String calificacion;
        public String municipio;
        public String zona;
        public Nullable<DateTime> fecha_antesde;
        public Nullable<DateTime> fecha_despuesde;
        public string tipo;
        public String mensaje;
    }
}
