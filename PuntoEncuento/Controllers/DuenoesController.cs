using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PuntoEncuento;

namespace PuntoEncuento.Controllers
{
    public class DuenoesController : Controller
    {
        private PuntoEncuentroDataContext db = new PuntoEncuentroDataContext();

        // GET: Duenoes
        public ActionResult Index()
        {
            var dueno = db.Dueno.Include(d => d.Usuario);
            return View(dueno.ToList());
        }

        // GET: Duenoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dueno dueno = db.Dueno.Find(id);
            if (dueno == null)
            {
                return HttpNotFound();
            }
            return View(dueno);
        }

        // GET: Duenoes/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Duenoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cuit,IdUsuario")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                db.Dueno.Add(dueno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre", dueno.IdUsuario);
            return View(dueno);
        }

        // GET: Duenoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dueno dueno = db.Dueno.Find(id);
            if (dueno == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre", dueno.IdUsuario);
            return View(dueno);
        }

        // POST: Duenoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cuit,IdUsuario")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dueno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre", dueno.IdUsuario);
            return View(dueno);
        }

        // GET: Duenoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dueno dueno = db.Dueno.Find(id);
            if (dueno == null)
            {
                return HttpNotFound();
            }
            return View(dueno);
        }

        // POST: Duenoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dueno dueno = db.Dueno.Find(id);
            db.Dueno.Remove(dueno);
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
