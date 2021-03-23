using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("hotel", Schema = "hotel")]
    public class UHotel
    {
        private int idhotel;
        private string municipio;
        private int idmunicipio;
        private int numhabitacion;
        private int precionoche;
        private int precioNocheDoble;
        private int precioNochePremium;
        private string descripcion;
        private string condicion;
        private string checkin;
        private string checkout;
        private string imagen;
        private string nombre;
        private string usuarioencargado;
        private int idusuario;
        private int idzona;
        private string imagen_secundaria;
        private string imagen_secundaria2;
        private string condicionesbioseguridad;
        private Nullable<int> promediocalificacion;
        private string direccion;
        [NotMapped]
        private string mensaje;
        [NotMapped]
        private string mensaje2;
        [NotMapped]
        private string mensaje3;
        [NotMapped]
        private string zona;
        [NotMapped]
        private int nummaxpersonas;
        [NotMapped]
        private string tipo;
        [NotMapped]
        private DateTime fecha_antesde;
        [NotMapped]
        private DateTime fecha_despuesde;
        [NotMapped]
        private int numHabitDisponibles;
        [NotMapped]
        private string url;
        [NotMapped]
        private bool boton;


        [Key]
        [Column("idhotel")]
        public int Idhotel { get => idhotel; set => idhotel = value; }
        [Column("idmunicipio")]
        public int Idmunicipio { get => idmunicipio; set => idmunicipio = value; }
        [Column("numhabitacion")]
        public int Numhabitacion { get => numhabitacion; set => numhabitacion = value; }
        [Column("precionoche")]
        public int Precionoche { get => precionoche; set => precionoche = value; }
        [Column("precionochedoble")]
        public int PrecioNocheDoble { get => precioNocheDoble; set => precioNocheDoble = value; }
        [Column("precionochepremium")]
        public int PrecioNochePremium { get => precioNochePremium; set => precioNochePremium = value; }
        [Column("descripcion")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        [Column("condicion")]
        public string Condicion { get => condicion; set => condicion = value; }
        [Column("checkin")]
        public string Checkin { get => checkin; set => checkin = value; }
        [Column("checkout")]
        public string Checkout { get => checkout; set => checkout = value; }
        [Column("imagen")]
        public string Imagen { get => imagen; set => imagen = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("idzona")]
        public int Idzona { get => idzona; set => idzona = value; }
        [Column("usuarioencargado")]
        public string Usuarioencargado { get => usuarioencargado; set => usuarioencargado = value; }
        [Column("idusuario")]
        public int Idusuario { get => idusuario; set => idusuario = value; }
        [Column("imagen_secundaria")]
        public string Imagen_secundaria { get => imagen_secundaria; set => imagen_secundaria = value; }
        [Column("imagen_secundaria2")]
        public string Imagen_secundaria2 { get => imagen_secundaria2; set => imagen_secundaria2 = value; }
        [Column("condicionesbioseguridad")]
        public string Condicionesbioseguridad { get => condicionesbioseguridad; set => condicionesbioseguridad = value; }
        [Column("promcalificacion")]
        public Nullable<int> Promediocalificacion { get => promediocalificacion; set => promediocalificacion = value; }
        [Column("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }

        [NotMapped]
        public string Mensaje { get => mensaje; set => mensaje = value; }
        [NotMapped]
        public string Municipio { get => municipio; set => municipio = value; }
        [NotMapped]
        public string Zona { get => zona; set => zona = value; }
        [NotMapped]
        public int NumMaxPersonas { get => nummaxpersonas; set => nummaxpersonas = value; }
        [NotMapped]
        public string Tipo { get => tipo; set => tipo = value; }
        [NotMapped]
        public DateTime Fecha_despuesde { get => fecha_despuesde; set => fecha_despuesde = value; }
        [NotMapped]
        public DateTime Fecha_antesde { get => fecha_antesde; set => fecha_antesde = value; }
        [NotMapped]
        public int NumHabitDisponibles { get => numHabitDisponibles; set => numHabitDisponibles = value; }
        [NotMapped]
        public string Url { get => url; set => url = value; }
        [NotMapped]
        public string Mensaje2 { get => mensaje2; set => mensaje2 = value; }
        [NotMapped]
        public string Mensaje3 { get => mensaje3; set => mensaje3 = value; }
        [NotMapped]
        public bool Boton { get => boton; set => boton = value; }
    }
}
