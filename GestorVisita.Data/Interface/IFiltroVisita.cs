using GestorVisita.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVisita.Data.Interface
{
    public interface IFiltroVisita
    {
        IEnumerable<Visita> ObtenerTodas();

        IEnumerable<Visita> FiltrarPorFecha(DateTime fecha);
    }
}
