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
    public class PrediosController : Controller
    {
        private PuntoEncuentroDataContext db = new PuntoEncuentroDataContext();

        // GET: Predios
        public ActionResult Index()
        {
            var predio = db.Predio.Include(p => p.Domicilio);
            return View(predio.ToList());
        }

        // GET: Predios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predio predio = db.Predio.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // GET: Predios/Create
        public ActionResult Create()
        {
            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle");
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre");
            ViewBag.Localidad = db.Localidad;
            ViewBag.Partido = db.Partido;
            ViewBag.Provincia = db.Provincia;
            return View();
        }

        // POST: Predios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPredio,Nombre,ImagenPredio,Domicilio,IdLocalidad,IdPartido,IdProvincia")] Predio predio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                predio.Domicilio.Localidad = db.Localidad.FirstOrDefault(x => x.IdLocalidad == predio.IdLocalidad);
                predio.Domicilio.Localidad.Partido = db.Partido.FirstOrDefault(x => x.IdPartido == predio.IdPartido);
                predio.Domicilio.Localidad.Partido.Provincia = db.Provincia.FirstOrDefault(x => x.IdProvincia == predio.IdProvincia);
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
                        predio.ImagenPredio = result;
                    }
                    catch (Exception ex)
                    {
                        //ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }

                db.Predio.Add(predio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle", predio.IdDomicilio);
            ViewBag.Localidad = db.Localidad;
            ViewBag.Partido = db.Partido;
            ViewBag.Provincia = db.Provincia;
            return View(predio);
        }

        // GET: Predios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predio predio = db.Predio.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle", predio.IdDomicilio);
            ViewBag.Localidad = db.Localidad;
            ViewBag.Partido = db.Partido;
            ViewBag.Provincia = db.Provincia;
            return View(predio);
        }

        // POST: Predios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPredio,Nombre,ImagenPredio,IdDomicilio")] Predio predio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle", predio.IdDomicilio);
            return View(predio);
        }

        // GET: Predios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predio predio = db.Predio.Find(id);
            if (predio == null)
            {
                return HttpNotFound();
            }
            return View(predio);
        }

        // POST: Predios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predio predio = db.Predio.Find(id);
            db.Predio.Remove(predio);
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
