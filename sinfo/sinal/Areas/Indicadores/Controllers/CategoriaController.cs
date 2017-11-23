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
    public class CategoriaController : Controller
    {
        private ContextIndicador db = new ContextIndicador();

        // GET: Indicadores/Categoria
        public ActionResult Index()
        {
            return View(db.CategoriaDerecho.ToList());
        }

        // GET: Indicadores/Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDerecho categoriaDerecho = db.CategoriaDerecho.Find(id);
            if (categoriaDerecho == null)
            {
                return HttpNotFound();
            }
            return View(categoriaDerecho);
        }

        // GET: Indicadores/Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indicadores/Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaDerechoId,Descripcion,Vigente")] CategoriaDerecho categoriaDerecho)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaDerecho.Add(categoriaDerecho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaDerecho);
        }

        // GET: Indicadores/Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDerecho categoriaDerecho = db.CategoriaDerecho.Find(id);
            if (categoriaDerecho == null)
            {
                return HttpNotFound();
            }
            return View(categoriaDerecho);
        }

        // POST: Indicadores/Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaDerechoId,Descripcion,Vigente")] CategoriaDerecho categoriaDerecho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaDerecho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaDerecho);
        }

        // GET: Indicadores/Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDerecho categoriaDerecho = db.CategoriaDerecho.Find(id);
            if (categoriaDerecho == null)
            {
                return HttpNotFound();
            }
            return View(categoriaDerecho);
        }

        // POST: Indicadores/Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaDerecho categoriaDerecho = db.CategoriaDerecho.Find(id);
            db.CategoriaDerecho.Remove(categoriaDerecho);
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
