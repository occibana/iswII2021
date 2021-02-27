using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("hotelmunicipio", Schema = "hotel")]
    public class UHotelMunicipio
    {
        private int idmunicipio;
        private string nombre;

        [Key]
        [Column("idmunicipio")]
        public int Idmunicipio { get => idmunicipio; set => idmunicipio = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
