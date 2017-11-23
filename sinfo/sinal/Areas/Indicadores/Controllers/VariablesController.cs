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
    public class VariablesController : Controller
    {
        private ContextIndicador db = new ContextIndicador();

        // GET: Indicadores/Variables
        public ActionResult Index()
        {
            return View(db.Variable.ToList());
        }

        // GET: Indicadores/Variables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variable variable = db.Variable.Find(id);
            if (variable == null)
            {
                return HttpNotFound();
            }
            return View(variable);
        }

        // GET: Indicadores/Variables/Create
        public ActionResult Create()
        {
            ViewBag.IndicadorId = new SelectList(db.Indicador, "IndicadorId", "Nombre");
            return View();
        }

        // POST: Indicadores/Variables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IndicadorId,Nombre,Vigente")] Variable variable)
        {
            //Indicador indicador = db.Indicador.Find(variable.IndicadorId);

           // Indicador indicador = new Indicador { IndicadorId = variable.IndicadorId };

            variable.Indicador.Add(new Indicador { IndicadorId = variable.IndicadorId });
                        

            if (ModelState.IsValid)
            {
                db.Variable.Add(variable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(variable);
        }

        // GET: Indicadores/Variables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variable variable = db.Variable.Find(id);
            if (variable == null)
            {
                return HttpNotFound();
            }
            return View(variable);
        }

        // POST: Indicadores/Variables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndicadorId,Nombre,Vigente")] Variable variable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(variable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(variable);
        }

        // GET: Indicadores/Variables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variable variable = db.Variable.Find(id);
            if (variable == null)
            {
                return HttpNotFound();
            }
            return View(variable);
        }

        // POST: Indicadores/Variables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Variable variable = db.Variable.Find(id);
            db.Variable.Remove(variable);
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
