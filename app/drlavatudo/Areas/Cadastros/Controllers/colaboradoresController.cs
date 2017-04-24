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
    public class colaboradoresController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: colaboradores
        public ActionResult Index()
        {
            var colaboradores = db.colaboradores.Include(c => c.categorias);
            return View(colaboradores.ToList());
        }

        // GET: colaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            colaboradores colaboradores = db.colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // GET: colaboradores/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo");
            return View();
        }

        // POST: colaboradores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,tipo,categoria,cpf,logradouro,bairro,municipio,codigo_postal,unidade_federativa,pais,email,telefone_fixo,telefone_movel,comissao,situacao")] colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                db.colaboradores.Add(colaboradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", colaboradores.categoria);
            return View(colaboradores);
        }

        // GET: colaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            colaboradores colaboradores = db.colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", colaboradores.categoria);
            return View(colaboradores);
        }

        // POST: colaboradores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,tipo,categoria,cpf,logradouro,bairro,municipio,codigo_postal,unidade_federativa,pais,email,telefone_fixo,telefone_movel,comissao,situacao")] colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaboradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", colaboradores.categoria);
            return View(colaboradores);
        }

        // GET: colaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            colaboradores colaboradores = db.colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // POST: colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            colaboradores colaboradores = db.colaboradores.Find(id);
            db.colaboradores.Remove(colaboradores);
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
