using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    public class UReactivarCuentaDatos
    {
        private string mensaje;
        private int user_id;
        private string url;

        public string Mensaje { get => mensaje; set => mensaje = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public string Url { get => url; set => url = value; }
    }

} 