using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("hotelzona", Schema = "hotel")]
    public class UHotelZona
    {
        private int idzona;
        private string nombre;

        [Key]
        [Column("idzona")]
        public int Idzona { get => idzona; set => idzona = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }

    }

}
