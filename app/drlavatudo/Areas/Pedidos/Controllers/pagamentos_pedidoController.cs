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
    public class pagamentos_pedidoController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: pagamentos_pedido
        public ActionResult Index()
        {
            var pagamentos_pedido = db.pagamentos_pedido.Include(p => p.metodos_pagamento).Include(p => p.pedidos);
            return View(pagamentos_pedido.ToList());
        }

        // GET: pagamentos_pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagamentos_pedido pagamentos_pedido = db.pagamentos_pedido.Find(id);
            if (pagamentos_pedido == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos_pedido);
        }

        // GET: pagamentos_pedido/Create
        public ActionResult Create()
        {
            ViewBag.metodo = new SelectList(db.metodos_pagamento, "codigo", "nome");
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao");
            return View();
        }

        // POST: pagamentos_pedido/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,pedido,metodo,situacao")] pagamentos_pedido pagamentos_pedido)
        {
            if (ModelState.IsValid)
            {
                db.pagamentos_pedido.Add(pagamentos_pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.metodo = new SelectList(db.metodos_pagamento, "codigo", "nome", pagamentos_pedido.metodo);
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", pagamentos_pedido.pedido);
            return View(pagamentos_pedido);
        }

        // GET: pagamentos_pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagamentos_pedido pagamentos_pedido = db.pagamentos_pedido.Find(id);
            if (pagamentos_pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.metodo = new SelectList(db.metodos_pagamento, "codigo", "nome", pagamentos_pedido.metodo);
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", pagamentos_pedido.pedido);
            return View(pagamentos_pedido);
        }

        // POST: pagamentos_pedido/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,pedido,metodo,situacao")] pagamentos_pedido pagamentos_pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentos_pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.metodo = new SelectList(db.metodos_pagamento, "codigo", "nome", pagamentos_pedido.metodo);
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", pagamentos_pedido.pedido);
            return View(pagamentos_pedido);
        }

        // GET: pagamentos_pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagamentos_pedido pagamentos_pedido = db.pagamentos_pedido.Find(id);
            if (pagamentos_pedido == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos_pedido);
        }

        // POST: pagamentos_pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pagamentos_pedido pagamentos_pedido = db.pagamentos_pedido.Find(id);
            db.pagamentos_pedido.Remove(pagamentos_pedido);
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
