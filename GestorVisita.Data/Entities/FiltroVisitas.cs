using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVisita.Data.Entities
{
    public class FiltroVisitas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string? Detalles { get; set; }
    }
}
