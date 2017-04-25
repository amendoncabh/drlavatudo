using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using app.drlavatudo.Models;
using app.drlavatudo.Areas.Cadastros.Models;

namespace app.drlavatudo.Areas.Cadastros.Controllers
{
    public class colaboradoresXregioesController : Controller
    {
        private drlavatudo_db db = new drlavatudo_db();

        // GET: colaboradoresXregioes
        public ActionResult Index()
        {
            var colaboradoresXregioes = db.colaboradoresXregioes.Include(c => c.colaboradores).Include(c => c.regioes);
            return View(colaboradoresXregioes.ToList());
        }

        // GET: colaboradoresXregioes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            colaboradoresXregioes colaboradoresXregioes = db.colaboradoresXregioes.Find(id);
            if (colaboradoresXregioes == null)
            {
                return HttpNotFound();
            }
            return View(colaboradoresXregioes);
        }

        // GET: colaboradoresXregioes/Create
        public ActionResult Create()
        {
            ViewBag.colaborador = new SelectList(db.colaboradores, "codigo", "nome");
            ViewBag.regiao = new SelectList(db.regioes, "codigo", "nome");
            return View();
        }

        // POST: colaboradoresXregioes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,colaborador,regiao,situacao")] colaboradoresXregioes colaboradoresXregioes)
        {
            if (ModelState.IsValid)
            {
                db.colaboradoresXregioes.Add(colaboradoresXregioes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.colaborador = new SelectList(db.colaboradores, "codigo", "nome", colaboradoresXregioes.colaborador);
            ViewBag.regiao = new SelectList(db.regioes, "codigo", "nome", colaboradoresXregioes.regiao);
            return View(colaboradoresXregioes);
        }

        // GET: colaboradoresXregioes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            colaboradoresXregioes colaboradoresXregioes = db.colaboradoresXregioes.Find(id);
            if (colaboradoresXregioes == null)
            {
                return HttpNotFound();
            }
            ViewBag.colaborador = new SelectList(db.colaboradores, "codigo", "nome", colaboradoresXregioes.colaborador);
            ViewBag.regiao = new SelectList(db.regioes, "codigo", "nome", colaboradoresXregioes.regiao);
            return View(colaboradoresXregioes);
        }

        // POST: colaboradoresXregioes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,colaborador,regiao,situacao")] colaboradoresXregioes colaboradoresXregioes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaboradoresXregioes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.colaborador = new SelectList(db.colaboradores, "codigo", "nome", colaboradoresXregioes.colaborador);
            ViewBag.regiao = new SelectList(db.regioes, "codigo", "nome", colaboradoresXregioes.regiao);
            return View(colaboradoresXregioes);
        }

        // GET: colaboradoresXregioes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            colaboradoresXregioes colaboradoresXregioes = db.colaboradoresXregioes.Find(id);
            if (colaboradoresXregioes == null)
            {
                return HttpNotFound();
            }
            return View(colaboradoresXregioes);
        }

        // POST: colaboradoresXregioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            colaboradoresXregioes colaboradoresXregioes = db.colaboradoresXregioes.Find(id);
            db.colaboradoresXregioes.Remove(colaboradoresXregioes);
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
