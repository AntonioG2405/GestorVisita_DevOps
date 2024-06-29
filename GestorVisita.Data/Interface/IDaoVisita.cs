

using GestorVisita.Data.Entities;

namespace GestorVisita.Data.Interface
{
    public interface IDaoVisita
    {
        void AddVisita(Visita visita);
        void UpdateVisita(Visita visita);
        void DeleteVisita(int id);

        List<Visita> GetVisitas();

        Visita GetVisitaById(int id);

    }
}
