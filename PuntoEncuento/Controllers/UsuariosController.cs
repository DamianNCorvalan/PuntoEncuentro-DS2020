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
    public class UsuariosController : Controller
    {
        private PuntoEncuentroDataContext db = new PuntoEncuentroDataContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Domicilio).Include(u => u.Rol);
            return View(usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle");
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre");
            ViewBag.Localidad = db.Localidad;
            ViewBag.Partido = db.Partido;
            ViewBag.Provincia = db.Provincia;
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Nombre,Apellido,IdRol,ImagenUsuario,Domicilio,IdLocalidad,IdPartido,IdProvincia,CorreoElectronico")] Usuario usuario, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                usuario.Domicilio.Localidad = db.Localidad.FirstOrDefault(x => x.IdLocalidad == usuario.IdLocalidad);
                usuario.Domicilio.Localidad.Partido = db.Partido.FirstOrDefault(x => x.IdPartido == usuario.IdPartido);
                usuario.Domicilio.Localidad.Partido.Provincia = db.Provincia.FirstOrDefault(x => x.IdProvincia == usuario.IdProvincia);
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
                        usuario.ImagenUsuario = result;
                    }
                    catch (Exception ex)
                    {
                        //ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }

                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle", usuario.IdDomicilio);
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre", usuario.IdRol);
            ViewBag.Localidad = db.Localidad;
            ViewBag.Partido = db.Partido;
            ViewBag.Provincia = db.Provincia;
            return View(usuario);
        }

        // GET: Usuarios/perfil/5
        public ActionResult perfil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle", usuario.IdDomicilio);
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre", usuario.IdRol);
            ViewBag.Localidad = db.Localidad;
            ViewBag.Partido = db.Partido;
            ViewBag.Provincia = db.Provincia;
            return View(usuario);
        }

        // POST: Usuarios/perfil/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult perfil([Bind(Include = "IdUsuario,Nombre,Apellido,IdRol,ImagenUsuario,IdDomicilio,CorreoElectronico")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDomicilio = new SelectList(db.Domicilio, "IdDomicilio", "Calle", usuario.IdDomicilio);
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "Nombre", usuario.IdRol);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
