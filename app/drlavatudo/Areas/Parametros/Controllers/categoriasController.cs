using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using app.drlavatudo.Models;
using app.drlavatudo.Areas.Parametros.Models;

namespace app.drlavatudo.Areas.Parametros.Controllers
{
    public class categoriasController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: categorias
        public ActionResult Index()
        {
            var categorias = db.categorias.Include(c => c.categorias2);
            return View(categorias.ToList());
        }

        // GET: categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorias categorias = db.categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // GET: categorias/Create
        public ActionResult Create()
        {
            ViewBag.codigo_pai = new SelectList(db.categorias, "codigo", "tipo");
            return View();
        }

        // POST: categorias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,tipo,nome,codigo_pai")] categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.categorias.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_pai = new SelectList(db.categorias, "codigo", "tipo", categorias.codigo_pai);
            return View(categorias);
        }

        // GET: categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorias categorias = db.categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_pai = new SelectList(db.categorias, "codigo", "tipo", categorias.codigo_pai);
            return View(categorias);
        }

        // POST: categorias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,tipo,nome,codigo_pai")] categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_pai = new SelectList(db.categorias, "codigo", "tipo", categorias.codigo_pai);
            return View(categorias);
        }

        // GET: categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorias categorias = db.categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categorias categorias = db.categorias.Find(id);
            db.categorias.Remove(categorias);
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
