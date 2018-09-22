using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenGateLogistics.Models;

namespace OpenGateLogistics.Controllers
{
    public class estadofacturasController : Controller
    {
        private dbOpenGateEntities db = new dbOpenGateEntities();

        // GET: estadofacturas
        public ActionResult Index()
        {
            return View(db.estadofactura.ToList());
        }

        // GET: estadofacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadofactura estadofactura = db.estadofactura.Find(id);
            if (estadofactura == null)
            {
                return HttpNotFound();
            }
            return View(estadofactura);
        }

        // GET: estadofacturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estadofacturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion")] estadofactura estadofactura)
        {
            if (ModelState.IsValid)
            {
                db.estadofactura.Add(estadofactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadofactura);
        }

        // GET: estadofacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadofactura estadofactura = db.estadofactura.Find(id);
            if (estadofactura == null)
            {
                return HttpNotFound();
            }
            return View(estadofactura);
        }

        // POST: estadofacturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] estadofactura estadofactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadofactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadofactura);
        }

        // GET: estadofacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadofactura estadofactura = db.estadofactura.Find(id);
            if (estadofactura == null)
            {
                return HttpNotFound();
            }
            return View(estadofactura);
        }

        // POST: estadofacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estadofactura estadofactura = db.estadofactura.Find(id);
            db.estadofactura.Remove(estadofactura);
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
