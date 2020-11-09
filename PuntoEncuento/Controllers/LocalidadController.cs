using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PuntoEncuento.Controllers
{
    public class LocalidadController : Controller
    {
        private PuntoEncuentroDataContext db = new PuntoEncuentroDataContext();
        // GET: Localidad
        public ActionResult Index()
        {
            return View();
        }

        // GET: Localidad/Details/5
        public ActionResult Details(int id)
        {
            var result = db.Localidad.Where(x => x.IdPartido == id).Select(x => new { x.IdLocalidad, x.Nombre }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Localidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localidad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Localidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Localidad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Localidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Localidad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
