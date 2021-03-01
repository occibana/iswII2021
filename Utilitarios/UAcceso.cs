using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("acceso", Schema = "seguridad")]
    public class UAcceso
    {
        private int id;
        private int userid;
        private string ip;
        private string mac;
        private string session;
        private DateTime fechaInicio;
        private Nullable<DateTime> fechaFin;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("userid")]
        public int Userid { get => userid; set => userid = value; }
        [Column("ip")]
        public string Ip { get => ip; set => ip = value; }
        [Column("mac")]
        public string Mac { get => mac; set => mac = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        [Column("fecha_fin")]
        public Nullable<DateTime> FechaFin { get => fechaFin; set => fechaFin = value; }
    }
}

