

using System.ComponentModel.DataAnnotations;

namespace GestorVisita.Data.Entities
{
    public class Visita
    {

        public int Id { get; set; }
        public string NombreVisitante { get; set; }
        public string MotivoVisita { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
