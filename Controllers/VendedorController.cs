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
    public class VendedorController : Controller
    {
        private VentaAutosEntities1 db = new VentaAutosEntities1();

        // GET: Vendedor
        public ActionResult Index()
        {
            var vendedor = db.Vendedor.Include(v => v.Direcciones);
            return View(vendedor.ToList());
        }

        // GET: Vendedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // GET: Vendedor/Create
        public ActionResult Create()
        {
            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle");
            return View();
        }

        // POST: Vendedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Vendedor,Nombre,APP,APM,Matricula,Email,Telefono,Direccion_ID")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Vendedor.Add(vendedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle", vendedor.Direccion_ID);
            return View(vendedor);
        }

        // GET: Vendedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle", vendedor.Direccion_ID);
            return View(vendedor);
        }

        // POST: Vendedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Vendedor,Nombre,APP,APM,Matricula,Email,Telefono,Direccion_ID")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Direccion_ID = new SelectList(db.Direcciones, "ID_Direccion", "Calle", vendedor.Direccion_ID);
            return View(vendedor);
        }

        // GET: Vendedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendedor vendedor = db.Vendedor.Find(id);
            db.Vendedor.Remove(vendedor);
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
