using GestorVisita.Data.Context;
using GestorVisita.Data.Entities;
using GestorVisita.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestorVisita.Data.Daos
{
    public class DaoFiltroVisitas : IFiltroVisita
    {
        private readonly VisitasDbContext _context;

        public DaoFiltroVisitas(VisitasDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Visita> ObtenerTodas()
        {
            return _context.Visitas.ToList();
        }

        public IEnumerable<Visita> FiltrarPorFecha(DateTime fecha)
        {
            return _context.Visitas.Where(v => v.Fecha.Date == fecha.Date).ToList();
        }
    }
}