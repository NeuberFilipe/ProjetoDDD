using AutoMapper;
using ProjetoModelDDD.MVC.ViewModels;
using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoModelDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        // GET: Produtos
        public ActionResult Index(string searchString)
        {
            ViewBag.Nome = String.IsNullOrEmpty(searchString) ? "Nome_desc" : "";
            
            var ProdutoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());

            if (!String.IsNullOrEmpty(searchString))
            {
                ProdutoViewModel = ProdutoViewModel.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper())
                );
            }

            return View(ProdutoViewModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var Produto = _produtoApp.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);

            return View(ProdutoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var ProdutoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(ProdutoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", ProdutoViewModel.ClienteId);
            return View(ProdutoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var ProdutoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(ProdutoDomain);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var Produto = _produtoApp.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);

            return View(ProdutoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var Produto = _produtoApp.GetById(id);
            _produtoApp.Remove(Produto);

            return RedirectToAction("Index");
        }
    }
}
