using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PuntoEncuento;

namespace PuntoEncuento.Controllers
{
    public class CanchasController : Controller
    {
        private PuntoEncuentroDataContext db = new PuntoEncuentroDataContext();

        // GET: Canchas
        public ActionResult Index()
        {
            var cancha = db.Cancha.Include(c => c.Predio).Include(c => c.Suelo);
            return View(cancha.ToList());
        }

        // GET: Canchas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancha cancha = db.Cancha.Find(id);
            if (cancha == null)
            {
                return HttpNotFound();
            }
            return View(cancha);
        }

        // GET: Canchas/Create
        public ActionResult Create()
        {
            ViewBag.IdPredio = new SelectList(db.Predio, "IdPredio", "Nombre");
            ViewBag.IdSuelo = new SelectList(db.Suelo, "IdSuelo", "Nombre");
            return View();
        }

        // POST: Canchas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCancha,Nombre,Techado,IdPredio,ImagenCancha,TiempoReserva,IdSuelo")] Cancha cancha, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        Stream InputStream = file.InputStream; // Get the input value from the file/other source
                        byte[] result;
                        using (var streamReader = new MemoryStream())
                        {
                            InputStream.CopyTo(streamReader);
                            result = streamReader.ToArray();
                        }
                        cancha.ImagenCancha = result;
                    }
                    catch (Exception ex)
                    {
                        //ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }

                db.Cancha.Add(cancha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPredio = new SelectList(db.Predio, "IdPredio", "Nombre", cancha.IdPredio);
            ViewBag.IdSuelo = new SelectList(db.Suelo, "IdSuelo", "Nombre", cancha.IdSuelo);
            return View(cancha);
        }

        // GET: Canchas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancha cancha = db.Cancha.Find(id);
            if (cancha == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPredio = new SelectList(db.Predio, "IdPredio", "Nombre", cancha.IdPredio);
            ViewBag.IdSuelo = new SelectList(db.Suelo, "IdSuelo", "Nombre", cancha.IdSuelo);
            return View(cancha);
        }

        // POST: Canchas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCancha,Nombre,Techado,IdPredio,ImagenCancha,TiempoReserva,IdSuelo")] Cancha cancha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPredio = new SelectList(db.Predio, "IdPredio", "Nombre", cancha.IdPredio);
            ViewBag.IdSuelo = new SelectList(db.Suelo, "IdSuelo", "Nombre", cancha.IdSuelo);
            return View(cancha);
        }

        // GET: Canchas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancha cancha = db.Cancha.Find(id);
            if (cancha == null)
            {
                return HttpNotFound();
            }
            return View(cancha);
        }

        // POST: Canchas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cancha cancha = db.Cancha.Find(id);
            db.Cancha.Remove(cancha);
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
