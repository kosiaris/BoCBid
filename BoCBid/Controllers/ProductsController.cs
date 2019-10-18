using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BoCBid.Models;

namespace BoCBid.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Status);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,ItemName,Description,StartingPrice,LastBidPrice,StatusId,StartBidOn,EndOfBidOn")] Products products ,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.NewGuid();
              //  products.PhotoUrl = imageId.ToString();

                string imgpathvalue = WebConfigurationManager.AppSettings["ImagesPath"];
                //  string path = imgpathvalue + imageId.ToString();
                string path = System.IO.Path.Combine(Server.MapPath(imgpathvalue), imageId.ToString());

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }



                string pic = System.IO.Path.GetFileName(file.FileName.Replace(" ", "_").Replace("%", "_"));
                path = System.IO.Path.Combine(
                                      Server.MapPath(imgpathvalue + imageId.ToString()), pic);
                // file is uploaded

                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                path = System.IO.Path.Combine("Images/" + imageId.ToString(), pic);
                products.PhotoUrl = path;
                db.Products.Add(products);
                db.SaveChanges();





                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", products.StatusId);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", products.StatusId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,ItemName,Description,StartingPrice,LastBidPrice,StatusId,StartBidOn,EndOfBidOn")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", products.StatusId);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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

        public ActionResult GotCreateBid(int? idparam)
        {

            return RedirectToAction("Create", "SetBids",new { id= idparam });
        }
    }
}
