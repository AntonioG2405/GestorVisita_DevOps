using GestorVisita.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace GestorVisita.Data.Context
{
    public class VisitasDbContext : DbContext
    {
        public DbSet<Visita> Visitas { get; set; }

    }
}
