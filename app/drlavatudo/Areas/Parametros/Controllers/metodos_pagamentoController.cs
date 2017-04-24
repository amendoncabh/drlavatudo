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
    public class metodos_pagamentoController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: metodos_pagamento
        public ActionResult Index()
        {
            return View(db.metodos_pagamento.ToList());
        }

        // GET: metodos_pagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metodos_pagamento metodos_pagamento = db.metodos_pagamento.Find(id);
            if (metodos_pagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodos_pagamento);
        }

        // GET: metodos_pagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: metodos_pagamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,tipo,prefixo,sufixo,termo,situacao")] metodos_pagamento metodos_pagamento)
        {
            if (ModelState.IsValid)
            {
                db.metodos_pagamento.Add(metodos_pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metodos_pagamento);
        }

        // GET: metodos_pagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metodos_pagamento metodos_pagamento = db.metodos_pagamento.Find(id);
            if (metodos_pagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodos_pagamento);
        }

        // POST: metodos_pagamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,tipo,prefixo,sufixo,termo,situacao")] metodos_pagamento metodos_pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodos_pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metodos_pagamento);
        }

        // GET: metodos_pagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metodos_pagamento metodos_pagamento = db.metodos_pagamento.Find(id);
            if (metodos_pagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodos_pagamento);
        }

        // POST: metodos_pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            metodos_pagamento metodos_pagamento = db.metodos_pagamento.Find(id);
            db.metodos_pagamento.Remove(metodos_pagamento);
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
