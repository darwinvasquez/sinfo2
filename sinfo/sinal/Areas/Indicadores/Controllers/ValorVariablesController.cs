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
    public class ValorVariablesController : Controller
    {
        private ContextIndicador db = new ContextIndicador();

        // GET: Indicadores/ValorVariables
        public ActionResult Index()
        {
            var valorVariable = db.ValorVariable.Include(v => v.Institucion).Include(v => v.Variable);
            return View(valorVariable.ToList());
        }

        // GET: Indicadores/ValorVariables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorVariable valorVariable = db.ValorVariable.Find(id);
            if (valorVariable == null)
            {
                return HttpNotFound();
            }
            return View(valorVariable);
        }

        // GET: Indicadores/ValorVariables/Create
        public ActionResult Create()
        {
            ViewBag.InstitucionId = new SelectList(db.Institucion, "InstitucionId", "Nombre");
            ViewBag.VariableId = new SelectList(db.Variable, "IndicadorId", "Nombre");
            return View();
        }

        // POST: Indicadores/ValorVariables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValorVariableId,VariableId,Fecha,Valor,InstitucionId,Vigente,Nombre")] ValorVariable valorVariable)
        {
            if (ModelState.IsValid)
            {
                db.ValorVariable.Add(valorVariable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstitucionId = new SelectList(db.Institucion, "InstitucionId", "Nombre", valorVariable.InstitucionId);
            ViewBag.VariableId = new SelectList(db.Variable, "IndicadorId", "Nombre", valorVariable.VariableId);
            return View(valorVariable);
        }

        // GET: Indicadores/ValorVariables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorVariable valorVariable = db.ValorVariable.Find(id);
            if (valorVariable == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstitucionId = new SelectList(db.Institucion, "InstitucionId", "Nombre", valorVariable.InstitucionId);
            ViewBag.VariableId = new SelectList(db.Variable, "IndicadorId", "Nombre", valorVariable.VariableId);
            return View(valorVariable);
        }

        // POST: Indicadores/ValorVariables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValorVariableId,VariableId,Fecha,Valor,InstitucionId,Vigente,Nombre")] ValorVariable valorVariable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valorVariable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstitucionId = new SelectList(db.Institucion, "InstitucionId", "Nombre", valorVariable.InstitucionId);
            ViewBag.VariableId = new SelectList(db.Variable, "IndicadorId", "Nombre", valorVariable.VariableId);
            return View(valorVariable);
        }

        // GET: Indicadores/ValorVariables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorVariable valorVariable = db.ValorVariable.Find(id);
            if (valorVariable == null)
            {
                return HttpNotFound();
            }
            return View(valorVariable);
        }

        // POST: Indicadores/ValorVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValorVariable valorVariable = db.ValorVariable.Find(id);
            db.ValorVariable.Remove(valorVariable);
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
