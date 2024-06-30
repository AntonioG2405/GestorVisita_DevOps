

using GestorVisita.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorVisita.Data.Context
{
    public class GV_Context : DbContext
    {
        public GV_Context(DbContextOptions<GV_Context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("Gestor_Visita");
        }

        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
