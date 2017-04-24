using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using app.drlavatudo.Models;

namespace app.drlavatudo.Controllers
{
    public class produtosController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: produtos
        public ActionResult Index()
        {
            var produtos = db.produtos.Include(p => p.unidades_medida);
            return View(produtos.ToList());
        }

        // GET: produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtos produtos = db.produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: produtos/Create
        public ActionResult Create()
        {
            ViewBag.unidade_medida = new SelectList(db.unidades_medida, "codigo", "nome");
            return View();
        }

        // POST: produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,descricao,tipo,categoria,unidade_medida,quantidade,preco,comissao")] produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.unidade_medida = new SelectList(db.unidades_medida, "codigo", "nome", produtos.unidade_medida);
            return View(produtos);
        }

        // GET: produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtos produtos = db.produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.unidade_medida = new SelectList(db.unidades_medida, "codigo", "nome", produtos.unidade_medida);
            return View(produtos);
        }

        // POST: produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,descricao,tipo,categoria,unidade_medida,quantidade,preco,comissao")] produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.unidade_medida = new SelectList(db.unidades_medida, "codigo", "nome", produtos.unidade_medida);
            return View(produtos);
        }

        // GET: produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtos produtos = db.produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produtos produtos = db.produtos.Find(id);
            db.produtos.Remove(produtos);
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
