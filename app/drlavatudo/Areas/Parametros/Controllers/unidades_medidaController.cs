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
    public class unidades_medidaController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: unidades_medida
        public ActionResult Index()
        {
            return View(db.unidades_medida.ToList());
        }

        // GET: unidades_medida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unidades_medida unidades_medida = db.unidades_medida.Find(id);
            if (unidades_medida == null)
            {
                return HttpNotFound();
            }
            return View(unidades_medida);
        }

        // GET: unidades_medida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: unidades_medida/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,grandeza,simbolo,fator")] unidades_medida unidades_medida)
        {
            if (ModelState.IsValid)
            {
                db.unidades_medida.Add(unidades_medida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidades_medida);
        }

        // GET: unidades_medida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unidades_medida unidades_medida = db.unidades_medida.Find(id);
            if (unidades_medida == null)
            {
                return HttpNotFound();
            }
            return View(unidades_medida);
        }

        // POST: unidades_medida/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,grandeza,simbolo,fator")] unidades_medida unidades_medida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidades_medida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidades_medida);
        }

        // GET: unidades_medida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unidades_medida unidades_medida = db.unidades_medida.Find(id);
            if (unidades_medida == null)
            {
                return HttpNotFound();
            }
            return View(unidades_medida);
        }

        // POST: unidades_medida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unidades_medida unidades_medida = db.unidades_medida.Find(id);
            db.unidades_medida.Remove(unidades_medida);
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
