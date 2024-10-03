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
    public class AgenciaController : Controller
    {
        private VentaAutosEntities1 db = new VentaAutosEntities1();

        // GET: Agencia
        public ActionResult Index()
        {
            var agencia = db.Agencia.Include(a => a.Direcciones);
            return View(agencia.ToList());
        }

        // GET: Agencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // GET: Agencia/Create
        public ActionResult Create()
        {
            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle");
            return View();
        }

        // POST: Agencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Agencia,Nombre,Telefono,Direccion_ID")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Agencia.Add(agencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle", agencia.Direccion_ID);
            return View(agencia);
        }

        // GET: Agencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle", agencia.Direccion_ID);
            return View(agencia);
        }

        // POST: Agencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Agencia,Nombre,Telefono,Direccion_ID")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle", agencia.Direccion_ID);
            return View(agencia);
        }

        // GET: Agencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agencia agencia = db.Agencia.Find(id);
            db.Agencia.Remove(agencia);
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
