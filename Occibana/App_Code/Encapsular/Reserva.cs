using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Descripción breve de Reserva
/// </summary>
//[Serializable]//permite que se tenga relacion en cadena (volver objeto)
//[Table("reserva", Schema = "hotel")]
//public class Reserva
//{

//    private int id;
//    private int idusuario;
//    private int numpersona;
//    private DateTime fecha_llegada;
//    private DateTime fecha_salida;
//    private string nombre;
//    private string apellido;
//    private string correo;
//    private int idhotel;
//    private string mediopago;
//    private Nullable <int> calificacion;
//    private DateTime limite_comentario;
//    private int id_habitacion;
//    private int precioNoche;
//    [NotMapped]
//    private string nombrehotel;
//    [NotMapped]
//    private DateTime fecha_comentario;

    

//    [Key]
//    [Column("id")]
//    public int Id { get => id; set => id = value; }
//    [Column("idusuario")]
//    public int Idusuario { get => idusuario; set => idusuario = value; }
//    [Column("numpersona")]
//    public int Numpersona { get => numpersona; set => numpersona = value; }
//    [Column("fecha_llegada")]
//    public DateTime Fecha_llegada { get => fecha_llegada; set => fecha_llegada = value; }
//    [Column("fecha_salida")]
//    public DateTime Fecha_salida { get => fecha_salida; set => fecha_salida = value; }
//    [Column("nombre")]
//    public string Nombre { get => nombre; set => nombre = value; }
//    [Column("apellido")]
//    public string Apellido { get => apellido; set => apellido = value; }
//    [Column("correo")]
//    public string Correo { get => correo; set => correo = value; }
//    [Column("idhotel")]
//    public int Idhotel { get => idhotel; set => idhotel = value; }
//    [Column("mediopago")]
//    public string Mediopago { get => mediopago; set => mediopago = value; }
//    [Column("calificacion")]
//    public Nullable<int> Calificacion { get => calificacion; set => calificacion = value; }
//    [Column("limite_comentario")]
//    public DateTime Limite_comentario { get => limite_comentario; set => limite_comentario = value; }
//    [Column("id_habitacion")]
//    public int Id_habitacion { get => id_habitacion; set => id_habitacion = value; }
//    [Column("precioNoche")]
//    public int PrecioNoche { get => precioNoche; set => precioNoche = value; }
//    [NotMapped]
//    public string Nombrehotel { get => nombrehotel; set => nombrehotel = value; }
//    [NotMapped]
//    public DateTime Fecha_comentario { get => fecha_comentario; set => fecha_comentario = value; }
 
    
//}