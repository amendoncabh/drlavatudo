using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ns.drlavatudo.Models;

namespace ns.drlavatudo.Controllers
{
    public class listas_precoController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: listas_preco
        public ActionResult Index()
        {
            var listas_preco = db.listas_preco.Include(l => l.categorias);
            return View(listas_preco.ToList());
        }

        // GET: listas_preco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listas_preco listas_preco = db.listas_preco.Find(id);
            if (listas_preco == null)
            {
                return HttpNotFound();
            }
            return View(listas_preco);
        }

        // GET: listas_preco/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo");
            return View();
        }

        // POST: listas_preco/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,descricao,tipo,categoria,validade_de,validade_ate,condicao,situacao")] listas_preco listas_preco)
        {
            if (ModelState.IsValid)
            {
                db.listas_preco.Add(listas_preco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", listas_preco.categoria);
            return View(listas_preco);
        }

        // GET: listas_preco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listas_preco listas_preco = db.listas_preco.Find(id);
            if (listas_preco == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", listas_preco.categoria);
            return View(listas_preco);
        }

        // POST: listas_preco/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,descricao,tipo,categoria,validade_de,validade_ate,condicao,situacao")] listas_preco listas_preco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listas_preco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", listas_preco.categoria);
            return View(listas_preco);
        }

        // GET: listas_preco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listas_preco listas_preco = db.listas_preco.Find(id);
            if (listas_preco == null)
            {
                return HttpNotFound();
            }
            return View(listas_preco);
        }

        // POST: listas_preco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            listas_preco listas_preco = db.listas_preco.Find(id);
            db.listas_preco.Remove(listas_preco);
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
