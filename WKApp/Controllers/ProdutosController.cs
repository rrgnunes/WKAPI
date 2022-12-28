using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WKApp.Interfaces;
using WKApp.Models;

namespace WKApp.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProduto _IProduto;
        public ProdutosController(IProduto IProduto)
        {
            _IProduto = IProduto;
        }

        // GET: ProdutosController
        public ActionResult Index()
        {
            return View(_IProduto.GetProdutos());
        }

        // GET: ProdutosController/Details/5
        public ActionResult Details(int id)
        {
            return View(_IProduto.GetProduto(id));
        }

        // GET: ProdutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto collection)
        {
            try
            {
                _IProduto.PostProduto(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_IProduto.GetProduto(id));
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produto collection)
        {
            try
            {
                _IProduto.PutProduto(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_IProduto.GetProduto(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produto collection)
        {
            try
            {
                _IProduto.DeleteProduto(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
