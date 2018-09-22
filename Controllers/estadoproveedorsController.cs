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
    public class estadoproveedorsController : Controller
    {
        private dbOpenGateEntities db = new dbOpenGateEntities();

        // GET: estadoproveedors
        public ActionResult Index()
        {
            return View(db.estadoproveedor.ToList());
        }

        // GET: estadoproveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoproveedor estadoproveedor = db.estadoproveedor.Find(id);
            if (estadoproveedor == null)
            {
                return HttpNotFound();
            }
            return View(estadoproveedor);
        }

        // GET: estadoproveedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estadoproveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion")] estadoproveedor estadoproveedor)
        {
            if (ModelState.IsValid)
            {
                db.estadoproveedor.Add(estadoproveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoproveedor);
        }

        // GET: estadoproveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoproveedor estadoproveedor = db.estadoproveedor.Find(id);
            if (estadoproveedor == null)
            {
                return HttpNotFound();
            }
            return View(estadoproveedor);
        }

        // POST: estadoproveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] estadoproveedor estadoproveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoproveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoproveedor);
        }

        // GET: estadoproveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoproveedor estadoproveedor = db.estadoproveedor.Find(id);
            if (estadoproveedor == null)
            {
                return HttpNotFound();
            }
            return View(estadoproveedor);
        }

        // POST: estadoproveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estadoproveedor estadoproveedor = db.estadoproveedor.Find(id);
            db.estadoproveedor.Remove(estadoproveedor);
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
