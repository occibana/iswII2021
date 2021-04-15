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
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
    }
}
