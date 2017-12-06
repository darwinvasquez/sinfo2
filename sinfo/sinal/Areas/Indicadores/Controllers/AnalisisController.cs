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
    [Authorize]
    public class AnalisisController : Controller
    {
        private ContextIndicador db = new ContextIndicador();

        // GET: Indicadores/Analisis
        public ActionResult Index()
        {
            var analisis = db.Analisis.Include(a => a.Indicador);
            return View(analisis.ToList());
        }

        // GET: Indicadores/Analisis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analisis analisis = db.Analisis.Find(id);
            if (analisis == null)
            {
                return HttpNotFound();
            }
            return View(analisis);
        }

        // GET: Indicadores/Analisis/Create
        public ActionResult Create()
        {
            ViewBag.IndicadorId = new SelectList(db.Indicador, "IndicadorId", "Nombre");
            return View();
        }

        // POST: Indicadores/Analisis/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeguimientoId,IndicadorId,Descripcion,FechaCreacion,UsuarioCreacion,MaquinaCreacion")] Analisis analisis)
        {
            analisis.FechaCreacion = DateTime.Now;
            analisis.UsuarioCreacion = User.Identity.Name;
            analisis.MaquinaCreacion ="sddsd";

            if (ModelState.IsValid)
            {
                db.Analisis.Add(analisis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IndicadorId = new SelectList(db.Indicador, "IndicadorId", "Nombre", analisis.IndicadorId);
            return View(analisis);
        }

        // GET: Indicadores/Analisis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analisis analisis = db.Analisis.Find(id);
            if (analisis == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndicadorId = new SelectList(db.Indicador, "IndicadorId", "Nombre", analisis.IndicadorId);
            return View(analisis);
        }

        // POST: Indicadores/Analisis/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeguimientoId,IndicadorId,Descripcion,FechaCreacion,UsuarioCreacion,MaquinaCreacion")] Analisis analisis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analisis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IndicadorId = new SelectList(db.Indicador, "IndicadorId", "Nombre", analisis.IndicadorId);
            return View(analisis);
        }

        // GET: Indicadores/Analisis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analisis analisis = db.Analisis.Find(id);
            if (analisis == null)
            {
                return HttpNotFound();
            }
            return View(analisis);
        }

        // POST: Indicadores/Analisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Analisis analisis = db.Analisis.Find(id);
            db.Analisis.Remove(analisis);
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
