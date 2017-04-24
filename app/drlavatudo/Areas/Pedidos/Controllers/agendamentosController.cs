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
    public class agendamentosOController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: agendamentos
        public ActionResult Index()
        {
            var agendamentos = db.agendamentos.Include(a => a.colaboradores).Include(a => a.colaboradores1).Include(a => a.pedidos);
            return View(agendamentos.ToList());
        }

        // GET: agendamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agendamentos agendamentos = db.agendamentos.Find(id);
            if (agendamentos == null)
            {
                return HttpNotFound();
            }
            return View(agendamentos);
        }

        // GET: agendamentos/Create
        public ActionResult Create()
        {
            ViewBag.atendente = new SelectList(db.colaboradores, "codigo", "nome");
            ViewBag.responsavel = new SelectList(db.colaboradores, "codigo", "nome");
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao");
            return View();
        }

        // POST: agendamentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,quando,duracao,pedido,complemento,atendente,responsavel,situacao")] agendamentos agendamentos)
        {
            if (ModelState.IsValid)
            {
                db.agendamentos.Add(agendamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.atendente = new SelectList(db.colaboradores, "codigo", "nome", agendamentos.atendente);
            ViewBag.responsavel = new SelectList(db.colaboradores, "codigo", "nome", agendamentos.responsavel);
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", agendamentos.pedido);
            return View(agendamentos);
        }

        // GET: agendamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agendamentos agendamentos = db.agendamentos.Find(id);
            if (agendamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.atendente = new SelectList(db.colaboradores, "codigo", "nome", agendamentos.atendente);
            ViewBag.responsavel = new SelectList(db.colaboradores, "codigo", "nome", agendamentos.responsavel);
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", agendamentos.pedido);
            return View(agendamentos);
        }

        // POST: agendamentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,quando,duracao,pedido,complemento,atendente,responsavel,situacao")] agendamentos agendamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.atendente = new SelectList(db.colaboradores, "codigo", "nome", agendamentos.atendente);
            ViewBag.responsavel = new SelectList(db.colaboradores, "codigo", "nome", agendamentos.responsavel);
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", agendamentos.pedido);
            return View(agendamentos);
        }

        // GET: agendamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agendamentos agendamentos = db.agendamentos.Find(id);
            if (agendamentos == null)
            {
                return HttpNotFound();
            }
            return View(agendamentos);
        }

        // POST: agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            agendamentos agendamentos = db.agendamentos.Find(id);
            db.agendamentos.Remove(agendamentos);
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
