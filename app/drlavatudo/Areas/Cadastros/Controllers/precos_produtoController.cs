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
    public class precos_produtoController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: precos_produto
        public ActionResult Index()
        {
            var precos_produto = db.precos_produto.Include(p => p.listas_preco).Include(p => p.produtos);
            return View(precos_produto.ToList());
        }

        // GET: precos_produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            precos_produto precos_produto = db.precos_produto.Find(id);
            if (precos_produto == null)
            {
                return HttpNotFound();
            }
            return View(precos_produto);
        }

        // GET: precos_produto/Create
        public ActionResult Create()
        {
            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao");
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome");
            return View();
        }

        // POST: precos_produto/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,lista_preco,produto,fator,valor,situacao")] precos_produto precos_produto)
        {
            if (ModelState.IsValid)
            {
                db.precos_produto.Add(precos_produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao", precos_produto.lista_preco);
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome", precos_produto.produto);
            return View(precos_produto);
        }

        // GET: precos_produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            precos_produto precos_produto = db.precos_produto.Find(id);
            if (precos_produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao", precos_produto.lista_preco);
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome", precos_produto.produto);
            return View(precos_produto);
        }

        // POST: precos_produto/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,lista_preco,produto,fator,valor,situacao")] precos_produto precos_produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precos_produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao", precos_produto.lista_preco);
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome", precos_produto.produto);
            return View(precos_produto);
        }

        // GET: precos_produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            precos_produto precos_produto = db.precos_produto.Find(id);
            if (precos_produto == null)
            {
                return HttpNotFound();
            }
            return View(precos_produto);
        }

        // POST: precos_produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            precos_produto precos_produto = db.precos_produto.Find(id);
            db.precos_produto.Remove(precos_produto);
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
