using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Entrada
{
    public class LoginRequest
    {

        [Required (ErrorMessage ="Se requiere usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Se requiere contrasena")]
        public string Contrasena { get; set; }
    }
}
