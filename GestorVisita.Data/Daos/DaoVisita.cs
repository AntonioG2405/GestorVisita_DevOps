

using GestorVisita.Data.Context;
using GestorVisita.Data.Entities;
using GestorVisita.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestorVisita.Data.Daos
{
    public class DaoVisita : IDaoVisita
    {
        private readonly GV_Context context;

        public DaoVisita(GV_Context Context)
        {
            context = Context;
        }
        public void AddVisita(Visita visita)
        {
            if (visita == null)
            {
                throw new ArgumentNullException(nameof(visita), "El objeto Visita no puede ser nulo.");
            }
            int nextId = context.Visitas.Count() > 0 ? context.Visitas.Max(v => v.Id) + 1 : 1;
            visita.Id = nextId;
            context.Visitas.Add(visita);
            context.SaveChanges();
        }

        public void UpdateVisita(Visita visita)
        {
            if (visita == null)
            {
                throw new ArgumentNullException(nameof(visita), "El objeto Visita no puede ser nulo.");
            }

            context.Entry(visita).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteVisita(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException("EL ID NO PUEDE SER 0.");
            }
            var visita = context.Visitas.Find(id);
            if (visita != null)
            {
                context.Visitas.Remove(visita);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("NO SE ENCONTRO LA VISTA CON EL ID QUE SE PASO.");
            }
        }

        public List<Visita> GetVisitas()
        {
            return context.Visitas.ToList();
        }

        public Visita GetVisitaById(int id)
        {
            return context.Visitas.Find(id);
        }
    }
}
