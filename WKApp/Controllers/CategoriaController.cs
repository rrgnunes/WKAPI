using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WKApp.Interfaces;
using WKApp.Models;

namespace WKApp.Controllers
{
    public class CategoriaController : Controller
    {

        private ICategoria _ICategoria;

        public CategoriaController(ICategoria ICategoria)
        {
            _ICategoria = ICategoria;
        }

        // GET: CategoriaController
        public ActionResult Index()
        {
            return View(_ICategoria.GetCategorias());
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View(_ICategoria.GetCategoria(id));
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria collection)
        {
            try
            {
                _ICategoria.PostCategoria(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ICategoria.GetCategoria(id));

        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria collection)
        {
            try
            {
                _ICategoria.PutCategoria(id, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ICategoria.GetCategoria(id));
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categoria collection)
        {
            try
            {
                _ICategoria.DeleteCategoria(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
