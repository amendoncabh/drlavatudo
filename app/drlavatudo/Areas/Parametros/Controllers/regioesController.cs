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
    public class regioesController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: regioes
        public ActionResult Index()
        {
            return View(db.regioes.ToList());
        }

        // GET: regioes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regioes regioes = db.regioes.Find(id);
            if (regioes == null)
            {
                return HttpNotFound();
            }
            return View(regioes);
        }

        // GET: regioes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: regioes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,codigo_postal_de,codigo_postal_ate,municipio,unidade_federativa")] regioes regioes)
        {
            if (ModelState.IsValid)
            {
                db.regioes.Add(regioes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regioes);
        }

        // GET: regioes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regioes regioes = db.regioes.Find(id);
            if (regioes == null)
            {
                return HttpNotFound();
            }
            return View(regioes);
        }

        // POST: regioes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,codigo_postal_de,codigo_postal_ate,municipio,unidade_federativa")] regioes regioes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regioes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regioes);
        }

        // GET: regioes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regioes regioes = db.regioes.Find(id);
            if (regioes == null)
            {
                return HttpNotFound();
            }
            return View(regioes);
        }

        // POST: regioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            regioes regioes = db.regioes.Find(id);
            db.regioes.Remove(regioes);
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
