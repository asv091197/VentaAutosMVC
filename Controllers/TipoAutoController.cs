using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using VentaAutosMVC.Models;

namespace VentaAutosMVC.Controllers
{
    public class TipoAutoController : Controller
    {
        private VentaAutosEntities1 context = new VentaAutosEntities1();

        // GET: TipoAuto
        public ActionResult Index()
        {
            var tipoAutos = context.TipoAuto.ToList();
            return View(tipoAutos);
        }

        // GET: TipoAuto/Details/5
        public ActionResult Details(int id)
        {
            var tipoAutos = context.TipoAuto.Find(id);
            if (tipoAutos == null)
            {
                return HttpNotFound();
            }
            return View(tipoAutos);
        }

        // GET: TipoAuto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAuto/Create
        [HttpPost]
        public ActionResult Create(TipoAuto tipoAuto)
        {
            if (ModelState.IsValid)
            {
                context.TipoAuto.Add(tipoAuto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAuto);
        }

        // GET: TipoAuto/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoAuto = context.TipoAuto.Find(id);
            if (tipoAuto == null)
            {
                return HttpNotFound();
            }
            return View(tipoAuto);
        }

        // POST: TipoAuto/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoAuto tipoAuto)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tipoAuto).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAuto);
        }

        // GET: TipoAuto/Delete/5
        public ActionResult Delete(int id)
        {
            var tipoAuto = context.TipoAuto.Find(id);
            if (tipoAuto == null)
            {
                return HttpNotFound();
            }
            return View(tipoAuto);
        }

        // POST: TipoAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var marca = context.Marca.Find(id);
            context.Marca.Remove(marca);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
