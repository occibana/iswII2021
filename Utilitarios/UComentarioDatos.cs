using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UComentario_CalificacionDatos
    {
        private string mensaje;
        private string comentarioTb;
        private string calificacion;

        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string ComentarioTb { get => comentarioTb; set => comentarioTb = value; }
        public string Calificacion { get => calificacion; set => calificacion = value; }
    }
}
