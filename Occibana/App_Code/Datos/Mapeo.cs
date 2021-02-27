using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Mapeo
/// </summary>
public class Mapeo : DbContext//Hereda de DbContext (contiene referencias a entityFramework)
{
    static Mapeo()
    {
        Database.SetInitializer<Mapeo>(null);
    }

    public Mapeo(): base("name=Occibana")//name=(nombre DB de la cadena de coneccion en el web config)
    {

    }

    //public DbSet<Registro> usuario { get; set; }
    //public DbSet<Hotel> hotel { get; set; }
    //public DbSet<HotelMunicipio> hotelmunicipio { get; set; }
    //public DbSet<HotelZona> hotelzona { get; set; }
    //public DbSet<Token> token { get; set; }
    //public DbSet<Acceso> acceso { get; set; }
    //public DbSet<Membresia> membresia { get; set; }
    //public DbSet<Reserva> reserva { get; set; }
    //public DbSet<Habitacion> habitacion { get; set; }
    //public DbSet<Comentarios> comentario { get; set; }

}