using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sinal.Areas.Indicadores.Models;

namespace sinal.Areas.Indicadores.Controllers
{
    public class InstitucionsController : Controller
    {
        private ContextIndicador db = new ContextIndicador();

        // GET: Indicadores/Institucions
        public ActionResult Index()
        {
            return View(db.Institucion.ToList());
        }

        // GET: Indicadores/Institucions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institucion institucion = db.Institucion.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        // GET: Indicadores/Institucions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indicadores/Institucions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstitucionId,Nombre,Vigente")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.Institucion.Add(institucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(institucion);
        }

        // GET: Indicadores/Institucions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institucion institucion = db.Institucion.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: Indicadores/Institucions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstitucionId,Nombre,Vigente")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(institucion);
        }

        // GET: Indicadores/Institucions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institucion institucion = db.Institucion.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: Indicadores/Institucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Institucion institucion = db.Institucion.Find(id);
            db.Institucion.Remove(institucion);
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
