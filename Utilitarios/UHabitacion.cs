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
        [NotMapped]
        private string mensaje;
        [NotMapped]
        private string tb_NumPersonas;
        [NotMapped]
        private string tb_NumBanio;
        [NotMapped]
        private string tb_NumeroDeCamas;
            


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
        [NotMapped]
        public string Mensaje { get => mensaje; set => mensaje = value; }
        [NotMapped]
        public string Tb_NumPersonas { get => tb_NumPersonas; set => tb_NumPersonas = value; }
        [NotMapped]
        public string Tb_NumBanio { get => tb_NumBanio; set => tb_NumBanio = value; }
        [NotMapped]
        public string Tb_NumeroDeCamas { get => tb_NumeroDeCamas; set => tb_NumeroDeCamas = value; }
    }
}
