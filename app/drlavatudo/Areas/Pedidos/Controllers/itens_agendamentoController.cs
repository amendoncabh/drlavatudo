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
    public class itens_agendamentoController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: itens_agendamento
        public ActionResult Index()
        {
            var itens_agendamento = db.itens_agendamento.Include(i => i.agendamentos).Include(i => i.itens_pedido);
            return View(itens_agendamento.ToList());
        }

        // GET: itens_agendamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens_agendamento itens_agendamento = db.itens_agendamento.Find(id);
            if (itens_agendamento == null)
            {
                return HttpNotFound();
            }
            return View(itens_agendamento);
        }

        // GET: itens_agendamento/Create
        public ActionResult Create()
        {
            ViewBag.agenda = new SelectList(db.agendamentos, "codigo", "complemento");
            ViewBag.procedimento = new SelectList(db.itens_pedido, "codigo", "situacao");
            return View();
        }

        // POST: itens_agendamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,agenda,procedimento,complemento,situacao")] itens_agendamento itens_agendamento)
        {
            if (ModelState.IsValid)
            {
                db.itens_agendamento.Add(itens_agendamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.agenda = new SelectList(db.agendamentos, "codigo", "complemento", itens_agendamento.agenda);
            ViewBag.procedimento = new SelectList(db.itens_pedido, "codigo", "situacao", itens_agendamento.procedimento);
            return View(itens_agendamento);
        }

        // GET: itens_agendamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens_agendamento itens_agendamento = db.itens_agendamento.Find(id);
            if (itens_agendamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.agenda = new SelectList(db.agendamentos, "codigo", "complemento", itens_agendamento.agenda);
            ViewBag.procedimento = new SelectList(db.itens_pedido, "codigo", "situacao", itens_agendamento.procedimento);
            return View(itens_agendamento);
        }

        // POST: itens_agendamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,agenda,procedimento,complemento,situacao")] itens_agendamento itens_agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itens_agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.agenda = new SelectList(db.agendamentos, "codigo", "complemento", itens_agendamento.agenda);
            ViewBag.procedimento = new SelectList(db.itens_pedido, "codigo", "situacao", itens_agendamento.procedimento);
            return View(itens_agendamento);
        }

        // GET: itens_agendamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens_agendamento itens_agendamento = db.itens_agendamento.Find(id);
            if (itens_agendamento == null)
            {
                return HttpNotFound();
            }
            return View(itens_agendamento);
        }

        // POST: itens_agendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itens_agendamento itens_agendamento = db.itens_agendamento.Find(id);
            db.itens_agendamento.Remove(itens_agendamento);
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
