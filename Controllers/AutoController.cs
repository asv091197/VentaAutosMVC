using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaAutosMVC.Models;

namespace VentaAutosMVC.Controllers
{
    public class AutoController : Controller
    {
        private VentaAutosEntities1 db = new VentaAutosEntities1();

        // GET: Auto
        public ActionResult Index()
        {
            var auto = db.Auto.Include(a => a.Marca).Include(a => a.TipoAuto);
            return View(auto.ToList());
        }

        // GET: Auto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Auto/Create
        public ActionResult Create()
        {
            ViewBag.Marca_ID = new SelectList(db.Marca, "ID_Marca", "Nombre");
            ViewBag.Tipo_ID = new SelectList(db.TipoAuto, "ID_Tipo", "Tipo");
            return View();
        }

        // POST: Auto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Auto,Marca_ID,Modelo,Color,Cilindros,Precio,Anio,Tipo_ID,Estado")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Auto.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Marca_ID = new SelectList(db.Marca, "ID_Marca", "Nombre", auto.Marca_ID);
            ViewBag.Tipo_ID = new SelectList(db.TipoAuto, "ID_Tipo", "Tipo", auto.Tipo_ID);
            return View(auto);
        }

        // GET: Auto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Marca_ID = new SelectList(db.Marca, "ID_Marca", "Nombre", auto.Marca_ID);
            ViewBag.Tipo_ID = new SelectList(db.TipoAuto, "ID_Tipo", "Tipo", auto.Tipo_ID);
            return View(auto);
        }

        // POST: Auto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Auto,Marca_ID,Modelo,Color,Cilindros,Precio,Anio,Tipo_ID,Estado")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Marca_ID = new SelectList(db.Marca, "ID_Marca", "Nombre", auto.Marca_ID);
            ViewBag.Tipo_ID = new SelectList(db.TipoAuto, "ID_Tipo", "Tipo", auto.Tipo_ID);
            return View(auto);
        }

        // GET: Auto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto auto = db.Auto.Find(id);
            db.Auto.Remove(auto);
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
