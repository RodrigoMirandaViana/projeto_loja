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
    public class ProdutobolasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produtobolas
        public ActionResult Index()
        {
            var produtobolas = db.Produtobolas.Include(p => p._Categoria);
            return View(produtobolas.ToList());
        }

        // GET: Produtobolas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtobola produtobola = db.Produtobolas.Find(id);
            if (produtobola == null)
            {
                return HttpNotFound();
            }
            return View(produtobola);
        }

        // GET: Produtobolas/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
            return View();
        }

        // POST: Produtobolas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutobolaID,Nome,Descricao,Preco,Disponibilidade,CategoriaID")] Produtobola produtobola)
        {
            if (ModelState.IsValid)
            {
                db.Produtobolas.Add(produtobola);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", produtobola.CategoriaID);
            return View(produtobola);
        }

        // GET: Produtobolas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtobola produtobola = db.Produtobolas.Find(id);
            if (produtobola == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", produtobola.CategoriaID);
            return View(produtobola);
        }

        // POST: Produtobolas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutobolaID,Nome,Descricao,Preco,Disponibilidade,CategoriaID")] Produtobola produtobola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtobola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", produtobola.CategoriaID);
            return View(produtobola);
        }

        // GET: Produtobolas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtobola produtobola = db.Produtobolas.Find(id);
            if (produtobola == null)
            {
                return HttpNotFound();
            }
            return View(produtobola);
        }

        // POST: Produtobolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtobola produtobola = db.Produtobolas.Find(id);
            db.Produtobolas.Remove(produtobola);
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
