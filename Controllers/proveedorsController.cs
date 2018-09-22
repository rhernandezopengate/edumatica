using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenGateLogistics.Models;
using System.Linq.Dynamic;
using PagedList;
using Rotativa.MVC;
using Newtonsoft.Json;

namespace OpenGateLogistics.Controllers
{
    public class proveedorsController : Controller
    {
        private dbOpenGateEntities db = new dbOpenGateEntities();

        // GET: proveedors

        public ActionResult Index(string buscar, int? page)
        {            
            var proveedores = db.proveedor.AsQueryable();

            proveedores = proveedores.Where(x => x.RazonSocial.Contains(buscar) || buscar == null);           

            return View(proveedores.ToList().OrderByDescending(x => x.id).ToPagedList(page ?? 1,10));                        
        }

        public ActionResult DownloadViewPDF(int idProveedor)
        {
            localhost.WebService1 service1 = new localhost.WebService1();

            List<GraficaJs> proList = JsonConvert.DeserializeObject<List<GraficaJs>>(service1.getProveedoresCategorias());
            List<GraficaJs> lista = new List<GraficaJs>();

            foreach (var item in proList)
            {
                lista.Add(new GraficaJs(item.Label, (double)item.Y));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(lista);

            //Code to get content
            return new Rotativa.MVC.PartialViewAsPdf("_DescargaProveedor", db.proveedor.Find(idProveedor)) { FileName = "TestViewAsPdf.pdf" };
        }

        public ActionResult ListaProveedores(string buscar, int? page)
        {
            return PartialView("_ListaProveedores", db.proveedor.Where(x => x.RazonSocial.Contains(buscar) || buscar == null).ToList().OrderByDescending(x => x.id).ToPagedList(page ?? 1, 11));
        }

        public ActionResult GraficaWebService()
        {
            localhost.WebService1 service1 = new localhost.WebService1();

            List<GraficaJs> proList = JsonConvert.DeserializeObject<List<GraficaJs>>(service1.getProveedoresCategorias());
            List<GraficaJs> lista = new List<GraficaJs>();

            foreach (var item in proList)
            {
                lista.Add(new GraficaJs(item.Label, (double)item.Y));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(lista);

            return View();
        }

        // GET: proveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: proveedors/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaProveedor_Id = new SelectList(db.categoriaproveedor.OrderBy(x => x.descripcion), "id", "descripcion");
            ViewBag.EstadoProveedor_Id = new SelectList(db.estadoproveedor, "id", "descripcion");
            ViewBag.NacionalidadProveedor_Id = new SelectList(db.nacionalidadproveedor, "id", "descripcion");
            return View();
        }        

        // POST: proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,RazonSocial,RFC,CategoriaProveedor_Id,NacionalidadProveedor_Id,EstadoProveedor_Id")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaProveedor_Id = new SelectList(db.categoriaproveedor, "id", "descripcion", proveedor.CategoriaProveedor_Id);
            ViewBag.EstadoProveedor_Id = new SelectList(db.estadoproveedor, "id", "descripcion", proveedor.EstadoProveedor_Id);
            ViewBag.NacionalidadProveedor_Id = new SelectList(db.nacionalidadproveedor, "id", "descripcion", proveedor.NacionalidadProveedor_Id);
            return View(proveedor);
        }

        // GET: proveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaProveedor_Id = new SelectList(db.categoriaproveedor, "id", "descripcion", proveedor.CategoriaProveedor_Id);
            ViewBag.EstadoProveedor_Id = new SelectList(db.estadoproveedor, "id", "descripcion", proveedor.EstadoProveedor_Id);
            ViewBag.NacionalidadProveedor_Id = new SelectList(db.nacionalidadproveedor, "id", "descripcion", proveedor.NacionalidadProveedor_Id);
            return View(proveedor);
        }

        // POST: proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public bool Edit(int id, string razonSocial, string rfc, int categoria_id, int nacionalidad_id, int estado_id)
        {
            proveedor proveedors = db.proveedor.Find(id);
            proveedors.RazonSocial = razonSocial;
            proveedors.RFC = rfc;
            proveedors.CategoriaProveedor_Id = categoria_id;
            proveedors.NacionalidadProveedor_Id = nacionalidad_id;
            proveedors.EstadoProveedor_Id = estado_id;
            //return id.ToString() + razonSocial + rfc + categoria_id.ToString() + nacionalidad_id.ToString()+ estado_id.ToString();

            if (ModelState.IsValid)
            {
                db.Entry(proveedors).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            ViewBag.CategoriaProveedor_Id = new SelectList(db.categoriaproveedor, "id", "descripcion", proveedors.CategoriaProveedor_Id);
            ViewBag.EstadoProveedor_Id = new SelectList(db.estadoproveedor, "id", "descripcion", proveedors.EstadoProveedor_Id);
            ViewBag.NacionalidadProveedor_Id = new SelectList(db.nacionalidadproveedor, "id", "descripcion", proveedors.NacionalidadProveedor_Id);
            return false;
        }

        // GET: proveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            db.proveedor.Remove(proveedor);
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
