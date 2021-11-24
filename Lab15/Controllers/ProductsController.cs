using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Lab15.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        // GET: Categories
        #region Contexto

        private NORTHWNDEntities _contexto;

        public NORTHWNDEntities contexto
        {
            set { _contexto = value; }
            get
            {
                if (_contexto == null)
                    _contexto = new NORTHWNDEntities();
                return _contexto;
            }
        }
        #endregion

        public ActionResult Index()
        {
            return View(contexto.Products.ToList());
        }

        public ActionResult Details(int id)
        {
            var productos = from p in contexto.Products
                            orderby p.ProductName ascending
                            where p.ProductID == id
                            select p;
            return View(productos.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products nuevoProducto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Products.Add(nuevoProducto);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(nuevoProducto);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Products productoEditar = contexto.Products.Find(id);

            if (productoEditar == null)
                return HttpNotFound();

            return View(productoEditar);
        }

        [HttpPost]
        public ActionResult Edit(Products ProductoEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Entry(ProductoEditar).State = EntityState.Modified;
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(ProductoEditar);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Products productoEliminar = contexto.Products.Find(id);

            if (productoEliminar == null)
                return HttpNotFound();

            return View(productoEliminar);
        }

        public ActionResult Delete(int? id, Products Producto1)
        {
            try
            {
                Products ProductoEliminar = new Products();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    ProductoEliminar = contexto.Products.Find(id);

                    if (ProductoEliminar == null)
                        return HttpNotFound();

                    contexto.Products.Remove(ProductoEliminar);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(ProductoEliminar);
            }
            catch
            {
                return View();
            }
        }

    }
}