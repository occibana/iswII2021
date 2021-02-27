using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("hotel_habitacion", Schema = "hotel")]
    public class UHabitacion
    {

        private int id;
        private int numpersonas;
        private int numbanio;
        private int idhotel;
        private string tipo;
        private Nullable<int> precio;
        private Nullable<int> numcamas;


        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("numpersona")]
        public int Numpersonas { get => numpersonas; set => numpersonas = value; }
        [Column("numbano")]
        public int Numbanio { get => numbanio; set => numbanio = value; }
        [Column("idhotel")]
        public int Idhotel { get => idhotel; set => idhotel = value; }
        [Column("tipo")]
        public string Tipo { get => tipo; set => tipo = value; }
        [Column("numcamas")]
        public Nullable<int> Numcamas { get => numcamas; set => numcamas = value; }
        [Column("precio")]
        public Nullable<int> Precio { get => precio; set => precio = value; }
    }
}
