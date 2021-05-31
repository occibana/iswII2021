using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("token_recuperacion", Schema = "login")]
    public class UToken
    {
        private int id;
        private int user_id;
        private string tokengenerado;
        private DateTime fecha_inicio;
        private DateTime fecha_caducidad;

        [NotMapped]
        private string mensajeTransversal;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("user_id")]
        public int User_id { get => user_id; set => user_id = value; }
        [Column("tokengenerado")]
        public string Tokengenerado { get => tokengenerado; set => tokengenerado = value; }
        [Column("fecha_inicio")]
        public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        [Column("fecha_caducidad")]
        public DateTime Fecha_caducidad { get => fecha_caducidad; set => fecha_caducidad = value; }
        [NotMapped]
        public string MensajeTransversal { get => mensajeTransversal; set => mensajeTransversal = value; }
    }
}
