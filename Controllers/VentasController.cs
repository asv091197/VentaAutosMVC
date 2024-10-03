using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaAutosMVC.Models;
using DTO;

namespace VentaAutosMVC.Controllers
{
    public class VentasController : Controller
    {
        private VentaAutosEntities1 db = new VentaAutosEntities1();

        // GET: Ventas
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.Agencia).Include(v => v.Auto).Include(v => v.Cliente).Include(v => v.Vendedor);
            return View(venta.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.Agencia_ID = new SelectList(db.Agencia, "ID_Agencia", "Nombre");
            ViewBag.Auto_ID = new SelectList(db.Auto, "ID_Auto", "Modelo");
            ViewBag.Cliente_ID = new SelectList(db.Cliente, "ID_Cliente", "Nombre");
            ViewBag.Vendedor_ID = new SelectList(db.Vendedor, "ID_Vendedor", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Venta,Auto_ID,Cliente_ID,Vendedor_ID,Estatus,Agencia_ID,IVA,Fecha")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Agencia_ID = new SelectList(db.Agencia, "ID_Agencia", "Nombre", venta.Agencia_ID);
            ViewBag.Auto_ID = new SelectList(db.Auto, "ID_Auto", "Modelo", venta.Auto_ID);
            ViewBag.Cliente_ID = new SelectList(db.Cliente, "ID_Cliente", "Nombre", venta.Cliente_ID);
            ViewBag.Vendedor_ID = new SelectList(db.Vendedor, "ID_Vendedor", "Nombre", venta.Vendedor_ID);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Agencia_ID = new SelectList(db.Agencia, "ID_Agencia", "Nombre", venta.Agencia_ID);
            ViewBag.Auto_ID = new SelectList(db.Auto, "ID_Auto", "Modelo", venta.Auto_ID);
            ViewBag.Cliente_ID = new SelectList(db.Cliente, "ID_Cliente", "Nombre", venta.Cliente_ID);
            ViewBag.Vendedor_ID = new SelectList(db.Vendedor, "ID_Vendedor", "Nombre", venta.Vendedor_ID);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Venta,Auto_ID,Cliente_ID,Vendedor_ID,Estatus,Agencia_ID,IVA,Fecha")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Agencia_ID = new SelectList(db.Agencia, "ID_Agencia", "Nombre", venta.Agencia_ID);
            ViewBag.Auto_ID = new SelectList(db.Auto, "ID_Auto", "Modelo", venta.Auto_ID);
            ViewBag.Cliente_ID = new SelectList(db.Cliente, "ID_Cliente", "Nombre", venta.Cliente_ID);
            ViewBag.Vendedor_ID = new SelectList(db.Vendedor, "ID_Vendedor", "Nombre", venta.Vendedor_ID);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
