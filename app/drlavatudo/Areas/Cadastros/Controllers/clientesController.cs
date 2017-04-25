using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using app.drlavatudo.Models;
using app.drlavatudo.Areas.Cadastros.Models;

namespace app.drlavatudo.Areas.Cadastros.Controllers
{
    public class clientesController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: clientes
        public ActionResult Index()
        {
            var clientes = db.clientes.Include(c => c.categorias);
            return View(clientes.ToList());
        }

        // GET: clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo");
            return View();
        }

        // POST: clientes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,tipo,categoria,eh_empresa,cpf_cnpj,logradouro,bairro,municipio,codigo_postal,unidade_federativa,pais,email,telefone_fixo,telefone_movel,situacao")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", clientes.categoria);
            return View(clientes);
        }

        // GET: clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", clientes.categoria);
            return View(clientes);
        }

        // POST: clientes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,tipo,categoria,eh_empresa,cpf_cnpj,logradouro,bairro,municipio,codigo_postal,unidade_federativa,pais,email,telefone_fixo,telefone_movel,situacao")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.categorias, "codigo", "tipo", clientes.categoria);
            return View(clientes);
        }

        // GET: clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clientes clientes = db.clientes.Find(id);
            db.clientes.Remove(clientes);
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
