using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseModels;
using ProjetoLoja.Models;

namespace ProjetoLoja.Controllers
{
    public class ProdutobonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produtobones
        public ActionResult Index()
        {
            var produtobones = db.Produtobones.Include(p => p._Categoria);
            return View(produtobones.ToList());
        }

        // GET: Produtobones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtobone produtobone = db.Produtobones.Find(id);
            if (produtobone == null)
            {
                return HttpNotFound();
            }
            return View(produtobone);
        }

        // GET: Produtobones/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
            return View();
        }

        // POST: Produtobones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoboneID,Nome,Descricao,Preco,Disponibilidade,CategoriaID")] Produtobone produtobone)
        {
            if (ModelState.IsValid)
            {
                db.Produtobones.Add(produtobone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", produtobone.CategoriaID);
            return View(produtobone);
        }

        // GET: Produtobones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtobone produtobone = db.Produtobones.Find(id);
            if (produtobone == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", produtobone.CategoriaID);
            return View(produtobone);
        }

        // POST: Produtobones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoboneID,Nome,Descricao,Preco,Disponibilidade,CategoriaID")] Produtobone produtobone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtobone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", produtobone.CategoriaID);
            return View(produtobone);
        }

        // GET: Produtobones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtobone produtobone = db.Produtobones.Find(id);
            if (produtobone == null)
            {
                return HttpNotFound();
            }
            return View(produtobone);
        }

        // POST: Produtobones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtobone produtobone = db.Produtobones.Find(id);
            db.Produtobones.Remove(produtobone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
