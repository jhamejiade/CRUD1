using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCRUD1._1.Models;

namespace WebCRUD1._1.Controllers
{
    public class usuario_productoController : Controller
    {
        private crudweb1Entities db = new crudweb1Entities();

        // GET: usuario_producto
        public ActionResult Index()
        {
            var usuario_producto = db.usuario_producto.Include(u => u.producto).Include(u => u.usuario);
            return View(usuario_producto.ToList());
        }

        // GET: usuario_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario_producto usuario_producto = db.usuario_producto.Find(id);
            if (usuario_producto == null)
            {
                return HttpNotFound();
            }
            return View(usuario_producto);
        }

        // GET: usuario_producto/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre_producto");
            ViewBag.cedula_usuario = new SelectList(db.usuario, "cedula_usuario", "contraseña_usuario");
            return View();
        }

        // POST: usuario_producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_up,cedula_usuario,id_producto")] usuario_producto usuario_producto)
        {
            if (ModelState.IsValid)
            {
                db.usuario_producto.Add(usuario_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre_producto", usuario_producto.id_producto);
            ViewBag.cedula_usuario = new SelectList(db.usuario, "cedula_usuario", "contraseña_usuario", usuario_producto.cedula_usuario);
            return View(usuario_producto);
        }

        // GET: usuario_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario_producto usuario_producto = db.usuario_producto.Find(id);
            if (usuario_producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre_producto", usuario_producto.id_producto);
            ViewBag.cedula_usuario = new SelectList(db.usuario, "cedula_usuario", "contraseña_usuario", usuario_producto.cedula_usuario);
            return View(usuario_producto);
        }

        // POST: usuario_producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_up,cedula_usuario,id_producto")] usuario_producto usuario_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre_producto", usuario_producto.id_producto);
            ViewBag.cedula_usuario = new SelectList(db.usuario, "cedula_usuario", "contraseña_usuario", usuario_producto.cedula_usuario);
            return View(usuario_producto);
        }

        // GET: usuario_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario_producto usuario_producto = db.usuario_producto.Find(id);
            if (usuario_producto == null)
            {
                return HttpNotFound();
            }
            return View(usuario_producto);
        }

        // POST: usuario_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario_producto usuario_producto = db.usuario_producto.Find(id);
            db.usuario_producto.Remove(usuario_producto);
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
