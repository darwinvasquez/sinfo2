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
    public class IndicadorsController : Controller
    {
        private ContextIndicador db = new ContextIndicador();

        // GET: Indicadores/Indicadors
        public ActionResult Index()
        {
            var indicador = db.Indicador.Include(i => i.CategoriaDerecho);
            return View(indicador.ToList());
        }

        // GET: Indicadores/Indicadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicadors indicadors = db.Indicador.Find(id);
            if (indicadors == null)
            {
                return HttpNotFound();
            }
            return View(indicadors);
        }

        // GET: Indicadores/Indicadors/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaDerechoId = new SelectList(db.CategoriaDerecho, "CategoriaDerechoId", "Descripcion");
            return View();
        }

        // POST: Indicadores/Indicadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IndicadorId,CategoriaDerechoId,CodigoIndicador,Nombre,Fuente,Vigente")] Indicadors indicadors)
        {
            if (ModelState.IsValid)
            {
                db.Indicador.Add(indicadors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaDerechoId = new SelectList(db.CategoriaDerecho, "CategoriaDerechoId", "Descripcion", indicadors.CategoriaDerechoId);
            return View(indicadors);
        }

        // GET: Indicadores/Indicadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicadors indicadors = db.Indicador.Find(id);
            if (indicadors == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaDerechoId = new SelectList(db.CategoriaDerecho, "CategoriaDerechoId", "Descripcion", indicadors.CategoriaDerechoId);
            return View(indicadors);
        }

        // POST: Indicadores/Indicadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndicadorId,CategoriaDerechoId,CodigoIndicador,Nombre,Fuente,Vigente")] Indicadors indicadors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicadors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaDerechoId = new SelectList(db.CategoriaDerecho, "CategoriaDerechoId", "Descripcion", indicadors.CategoriaDerechoId);
            return View(indicadors);
        }

        // GET: Indicadores/Indicadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicadors indicadors = db.Indicador.Find(id);
            if (indicadors == null)
            {
                return HttpNotFound();
            }
            return View(indicadors);
        }

        // POST: Indicadores/Indicadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indicadors indicadors = db.Indicador.Find(id);
            db.Indicador.Remove(indicadors);
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
