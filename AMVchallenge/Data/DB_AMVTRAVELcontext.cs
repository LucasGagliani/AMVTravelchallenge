using Microsoft.EntityFrameworkCore;

namespace AMVchallenge.Data
{
    public class DB_AMVTRAVELcontext : DbContext
    {
        public DB_AMVTRAVELcontext(DbContextOptions<DB_AMVTRAVELcontext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}