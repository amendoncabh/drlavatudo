using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using app.drlavatudo.Models;
using app.drlavatudo.Areas.Pedidos.Models;

namespace app.drlavatudo.Areas.Pedidos.Controllers
{
    public class itens_pedidoController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: itens_pedido
        public ActionResult Index()
        {
            var itens_pedido = db.itens_pedido.Include(i => i.pedidos).Include(i => i.produtos);
            return View(itens_pedido.ToList());
        }

        // GET: itens_pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens_pedido itens_pedido = db.itens_pedido.Find(id);
            if (itens_pedido == null)
            {
                return HttpNotFound();
            }
            return View(itens_pedido);
        }

        // GET: itens_pedido/Create
        public ActionResult Create()
        {
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao");
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome");
            return View();
        }

        // POST: itens_pedido/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,pedido,produto,quantidade,preco,valor,comissao,situacao")] itens_pedido itens_pedido)
        {
            if (ModelState.IsValid)
            {
                db.itens_pedido.Add(itens_pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", itens_pedido.pedido);
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome", itens_pedido.produto);
            return View(itens_pedido);
        }

        // GET: itens_pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens_pedido itens_pedido = db.itens_pedido.Find(id);
            if (itens_pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", itens_pedido.pedido);
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome", itens_pedido.produto);
            return View(itens_pedido);
        }

        // POST: itens_pedido/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,pedido,produto,quantidade,preco,valor,comissao,situacao")] itens_pedido itens_pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itens_pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pedido = new SelectList(db.pedidos, "codigo", "situacao", itens_pedido.pedido);
            ViewBag.produto = new SelectList(db.produtos, "codigo", "nome", itens_pedido.produto);
            return View(itens_pedido);
        }

        // GET: itens_pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens_pedido itens_pedido = db.itens_pedido.Find(id);
            if (itens_pedido == null)
            {
                return HttpNotFound();
            }
            return View(itens_pedido);
        }

        // POST: itens_pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itens_pedido itens_pedido = db.itens_pedido.Find(id);
            db.itens_pedido.Remove(itens_pedido);
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
