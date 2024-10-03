using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentaAutosMVC.Models;
using DTO;
using System.Text.RegularExpressions;


namespace VentaAutosMVC.Controllers
{
    public class MarcaController : Controller
    {

        private VentaAutosEntities1 context=new VentaAutosEntities1();

        // GET: Marca
        public ActionResult Index()
        {
            var marcas = context.Marca.ToList();
            return View(marcas);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int id)
        {
            var marca = context.Marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                context.Marca.Add(marca);
                context.SaveChanges();
                TempData["SweetAlertMessage"] = "Marca registrada correctamente.";
                //    TempData["SweetAlertMessage"] = SweetAlert.Sweet_Alert("¡Registrado!", "Marca registrada correctamente.", NotificationType.success);
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int id)
        {
            var marca = context.Marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(Marca marca)
        {
            if (ModelState.IsValid)
            {
                context.Entry(marca).State = EntityState.Modified;
                context.SaveChanges();

                TempData["SweetAlertMessage"] = "Marca actualizada correctamente.";
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int id)
        {
            var marca = context.Marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var marca = context.Marca.Find(id);
            context.Marca.Remove(marca);
            context.SaveChanges();
            TempData["SweetAlertMessage"] = "Marca eliminada correctamente.";
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
