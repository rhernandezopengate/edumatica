using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenGateLogistics.Models;
using Newtonsoft.Json;

namespace OpenGateLogistics.Controllers
{
    public class facturasController : Controller
    {
        private dbOpenGateEntities db = new dbOpenGateEntities();

        // GET: facturas

        public ActionResult Index()
        {
            var factura = db.factura.Include(f => f.estadofactura).Include(f => f.proveedor);
            ViewBag.EstadoFactura_Id = new SelectList(db.estadofactura, "id", "descripcion");
            return View(factura.ToList());
        }

        [HttpPost]
        public JsonResult Autotomplete(string razonsocial)
        {
            var facturas = from p in db.proveedor
                           where p.RazonSocial.Contains(razonsocial)
                           select new { p.RazonSocial };

            return Json(facturas, JsonRequestBehavior.AllowGet);
        }

        // GET: facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            ViewBag.EstadoFactura_Id = new SelectList(db.estadofactura, "id", "descripcion");
            ViewBag.Proveedor_Id = new SelectList(db.proveedor, "id", "RazonSocial");
            return View();
        }

        // POST: facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NumeroFactura,FechaFactura,FechaSello,FechaVencimiento,FechaPago,Concepto,DiasVencidos,Observaciones,FechaRegistro,Subtotal,Iva,Descuento,Total,Proveedor_Id,EstadoFactura_Id,UserId")] factura factura)
        {
            if (ModelState.IsValid)
            {
                
                db.factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoFactura_Id = new SelectList(db.estadofactura, "id", "descripcion", factura.EstadoFactura_Id);
            ViewBag.Proveedor_Id = new SelectList(db.proveedor, "id", "RazonSocial", factura.Proveedor_Id);
            return View(factura);
        }

        // GET: facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);

                    

            if (factura.EstadoFactura_Id == 2)
            {
                ViewBag.EstadoFactura_Id = new SelectList(db.estadofactura.Where(x => x.id == 2), "id", "descripcion", factura.EstadoFactura_Id);
            }
            else
            {
                ViewBag.EstadoFactura_Id = new SelectList(db.estadofactura.Where(x => x.id != 2), "id", "descripcion", factura.EstadoFactura_Id);
            }

            if (factura == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Proveedor_Id = new SelectList(db.proveedor, "id", "RazonSocial", factura.Proveedor_Id);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(factura factura)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    db.Entry(factura).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            ViewBag.EstadoFactura_Id = new SelectList(db.estadofactura, "id", "descripcion", factura.EstadoFactura_Id);
            ViewBag.Proveedor_Id = new SelectList(db.proveedor, "id", "RazonSocial", factura.Proveedor_Id);
            return View(factura);
        }

        // GET: facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factura factura = db.factura.Find(id);
            db.factura.Remove(factura);
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
