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
    public class cadastrosController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: pedidos
        public ActionResult Index()
        {
            var pedidos = db.pedidos.Include(p => p.clientes).Include(p => p.colaboradores).Include(p => p.listas_preco);
            return View(pedidos.ToList());
        }

        // GET: pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: pedidos/Create
        public ActionResult Create()
        {
            ViewBag.cliente = new SelectList(db.clientes, "codigo", "nome");
            ViewBag.vendedor = new SelectList(db.colaboradores, "codigo", "nome");
            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao");
            return View();
        }

        // POST: pedidos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,cliente,vendedor,lista_preco,registrado_em,valido_ate,comissao,situacao")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.pedidos.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente = new SelectList(db.clientes, "codigo", "nome", pedidos.cliente);
            ViewBag.vendedor = new SelectList(db.colaboradores, "codigo", "nome", pedidos.vendedor);
            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao", pedidos.lista_preco);
            return View(pedidos);
        }

        // GET: pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente = new SelectList(db.clientes, "codigo", "nome", pedidos.cliente);
            ViewBag.vendedor = new SelectList(db.colaboradores, "codigo", "nome", pedidos.vendedor);
            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao", pedidos.lista_preco);
            return View(pedidos);
        }

        public ActionResult jqGrid(string sidx, string sord, int page, int rows)
        {
            var pedidos = db.pedidos.Include(p => p.clientes).Include(p => p.colaboradores).Include(p => p.listas_preco);

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = pedidos.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var data = pedidos.OrderBy(x => x.codigo)
                          .Skip(pageSize * (page - 1))
                          .Take(pageSize).ToList();

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // POST: pedidos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,cliente,vendedor,lista_preco,registrado_em,valido_ate,comissao,situacao")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente = new SelectList(db.clientes, "codigo", "nome", pedidos.cliente);
            ViewBag.vendedor = new SelectList(db.colaboradores, "codigo", "nome", pedidos.vendedor);
            ViewBag.lista_preco = new SelectList(db.listas_preco, "codigo", "descricao", pedidos.lista_preco);
            return View(pedidos);
        }

        // GET: pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            db.pedidos.Remove(pedidos);
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
