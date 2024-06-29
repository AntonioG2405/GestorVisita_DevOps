using GestorVisita.Data.Entities;
using GestorVisita.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestorVisitas.Web.Controllers
{
    public class VisitaController : Controller
    {
        private readonly IDaoVisita daoVisita;

        public VisitaController(IDaoVisita daoVisita)
        {
            this.daoVisita = daoVisita;
        }
        // GET: VisitaController
        public ActionResult Index()
        {
            var result = daoVisita.GetVisitas();
            var data = result.OrderBy(x => x.Id).ToList();
            return View(data);
        }

        // GET: VisitaController/Details/5
        public ActionResult Details(int id)
        {
            var result = daoVisita.GetVisitaById(id);
            return View(result);
        }

        // GET: VisitaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Visita collection)
        {
            try
            {
                daoVisita.AddVisita(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VisitaController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = daoVisita.GetVisitaById(id);
            return View(result);
        }

        // POST: VisitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Visita collection)
        {
            try
            {
                daoVisita.UpdateVisita(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VisitaController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = daoVisita.GetVisitaById(id);
            return View(result);
        }

        // POST: VisitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                daoVisita.DeleteVisita(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
