using GestorVisita.Data.Daos;
using GestorVisita.Data.Entities;
using GestorVisita.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorVisitas.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IDaoUsuario daoUsuario;

        public UsuariosController(IDaoUsuario daoUsuario)
        {
            this.daoUsuario = daoUsuario;
        }

        // GET: UsuariosController
        public ActionResult Index()
        {
            var result = daoUsuario.GetUsuarios();
            var data = result.OrderBy(x => x.Id).ToList();
            return View(data);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            var result = daoUsuario.GetUsuariosById(id);
            return View(result);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios collection)
        {
            try
            {
                daoUsuario.AddUsuario(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = daoUsuario.GetUsuariosById(id);
            return View(result);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuarios collection)
        {
            try
            {
                daoUsuario.UpdateUsuario(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = daoUsuario.GetUsuariosById(id);
            return View(result);
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                daoUsuario.DeleteUsuario(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
