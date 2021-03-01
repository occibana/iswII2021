using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("comentarios", Schema = "hotel")]
    public class UComentarios
    {
        private int id_coment;

        private string comentario;
        private int id_hotel;
        private int id_usuario;
        private DateTime fecha_comentario;
        [NotMapped]
        private string nombre_usuario;
        [NotMapped]
        private DateTime fecha_salida;

        [Key]
        [Column("id_coment")]
        public int Id_coment { get => id_coment; set => id_coment = value; }
        [Column("comentario")]
        public string Comentario { get => comentario; set => comentario = value; }
        [Column("id_hotel")]
        public int Id_hotel { get => id_hotel; set => id_hotel = value; }
        [Column("id_usuario")]
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        [Column("fecha_comentario")]
        public DateTime Fecha_comentario { get => fecha_comentario; set => fecha_comentario = value; }
        [NotMapped]
        public string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        [NotMapped]
        public DateTime Fecha_salida { get => fecha_salida; set => fecha_salida = value; }
    }
}
