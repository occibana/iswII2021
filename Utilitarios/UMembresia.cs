using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]//permite que se tenga relacion en cadena (volver objeto)
    [Table("compra", Schema = "seguridad")]
    public class UMembresia
    {
        private int id;
        private int idusuario;
        private string numerotarjeta;
        private string nombrepropietario;
        private string direccionpropietario;
        private string cedulapropietario;
        private string codigoseguridad;
        private DateTime fecha_compra;
        private DateTime fecha_vencimiento;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("idusuario")]
        public int Idusuario { get => idusuario; set => idusuario = value; }
        [Column("numerotarjeta")]
        public string Numerotarjeta { get => numerotarjeta; set => numerotarjeta = value; }
        [Column("nombrepropietario")]
        public string Nombrepropietario { get => nombrepropietario; set => nombrepropietario = value; }
        [Column("direccionpropietario")]
        public string Direccionpropietario { get => direccionpropietario; set => direccionpropietario = value; }
        [Column("cedulapropietario")]
        public string Cedulapropietario { get => cedulapropietario; set => cedulapropietario = value; }
        [Column("codigoseguridad")]
        public string Codigoseguridad { get => codigoseguridad; set => codigoseguridad = value; }
        [Column("fecha_compra")]
        public DateTime Fecha_compra { get => fecha_compra; set => fecha_compra = value; }
        [Column("fecha_vencimiento")]
        public DateTime Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }

    }
}
