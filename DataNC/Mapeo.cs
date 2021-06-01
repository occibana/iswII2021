using Microsoft.EntityFrameworkCore;
using Utilitarios;

namespace DataNC
{
    public class Mapeo : DbContext//Hereda de DbContext (contiene referencias a entityFramework)
    {

        public DbSet<URegistro> usuario { get; set; }
        public DbSet<UHotel> hotel { get; set; }
        public DbSet<UHotelMunicipio> hotelmunicipio { get; set; }
        public DbSet<UHotelZona> hotelzona { get; set; }
        public DbSet<UToken> token { get; set; }
        public DbSet<UAcceso> acceso { get; set; }
        public DbSet<UMembresia> membresia { get; set; }
        public DbSet<UReserva> reserva { get; set; }
        public DbSet<UHabitacion> habitacion { get; set; }
        public DbSet<UComentarios> comentario { get; set; }
        public DbSet<LoginToken> login_token { get; set; }

        public Mapeo(DbContextOptions<Mapeo> options) : base(options) { }
    }
}

