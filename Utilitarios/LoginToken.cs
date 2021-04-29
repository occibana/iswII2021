using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("token_login_aplicacion", Schema = "seguridad")]
    public class LoginToken
    {
        private int id;
        private int user_id;
        private DateTime fechaGenerado;
        private DateTime fechaVigencia;
        private String token;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("user_id")]
        public int User_id { get => user_id; set => user_id = value; }
        [Column("fecha_generado")]
        public DateTime FechaGenerado { get => fechaGenerado; set => fechaGenerado = value; }
        [Column("fecha_vigencia")]
        public DateTime FechaVigencia { get => fechaVigencia; set => fechaVigencia = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
    }
}
