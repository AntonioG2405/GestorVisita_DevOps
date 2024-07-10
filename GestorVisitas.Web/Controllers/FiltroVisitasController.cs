using GestorVisita.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestorVisitas.Web.Controllers
{
    public class FiltroVisitasController : Controller
    {
        private readonly IFiltroVisita _visitaDao;

        public FiltroVisitasController(IFiltroVisita visitaDao)
        {
            _visitaDao = visitaDao;
        }

        // Acción para mostrar todas las visitas
        public ActionResult FiltroVisita() 
        {
            var FiltroVisitas = _visitaDao.ObtenerTodas();
            return View(FiltroVisitas);
        }

        // Acción para filtrar visitas por fecha
        public ActionResult FiltrarPorFecha(DateTime fecha)
        {
            var visitasFiltradas = _visitaDao.FiltrarPorFecha(fecha);
            return View("Index", visitasFiltradas);
        }

    }
}
