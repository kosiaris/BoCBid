using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoCBid.ApiCalls;
using BoCBid.ClassHelpers;
using BoCBid.Models;
using Microsoft.AspNet.Identity;

namespace BoCBid.Controllers
{
    public class SetBidsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SetBids
        public ActionResult Index()
        {
            var SetBids = db.SetBids.Include(s => s.Products);
            return View(SetBids.ToList());
        }

        // GET: SetBids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetBid SetBid = db.SetBids.Find(id);
            if (SetBid == null)
            {
                return HttpNotFound();
            }
            return View(SetBid);
        }

        // GET: SetBids/Create
        public ActionResult Create(int id)
        {
            ViewBag.ProductsId = new SelectList(db.Products.Where(o => o.Id == id), "Id", "ItemName", id);
            ViewBag.Product = db.Products.Where(o => o.Id == id).FirstOrDefault();
            var results = GetAccounts.Get();
            List<AccountsResponse> accountid = new List<AccountsResponse>();

            foreach(var item in results )
            {
                AccountsResponse accid = new AccountsResponse();
                accid.AccountId = item.AccountId;
                accountid.Add(accid);
            }

            ViewBag.AccountNo = new SelectList(accountid, "AccountId","AccountId");
            return View();
        }

        // POST: SetBids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Account,ProductsId,OfferBitPrice")] SetBid SetBid)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Where(p => p.Id == SetBid.ProductsId).FirstOrDefault();
                product.LastBidPrice = SetBid.OfferBitPrice;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                var userid=  User.Identity.GetUserId();
                SetBid.ApplicationUserId = userid;

                db.SetBids.Add(SetBid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var results = GetAccounts.Get();
            ViewBag.AccountNo = new SelectList(results, "AccountId", "AccountId", SetBid.Account);
            ViewBag.ProductsId = new SelectList(db.Products, "Id", "ItemName", SetBid.ProductsId);
            return View(SetBid);
        }

        // GET: SetBids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetBid SetBid = db.SetBids.Find(id);
            if (SetBid == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductsId = new SelectList(db.Products, "Id", "ItemName", SetBid.ProductsId);
            return View(SetBid);
        }

        // POST: SetBids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Account,ProductsId,OfferBitPrice")] SetBid SetBid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(SetBid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductsId = new SelectList(db.Products, "Id", "ItemName", SetBid.ProductsId);
            return View(SetBid);
        }

        // GET: SetBids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetBid SetBid = db.SetBids.Find(id);
            if (SetBid == null)
            {
                return HttpNotFound();
            }
            return View(SetBid);
        }

        // POST: SetBids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetBid SetBid = db.SetBids.Find(id);
            db.SetBids.Remove(SetBid);
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

        public string GetBalanceAvailable(string accountno)
        {
            var balance= GetBalance.Get(accountno);
            return balance;

        }
    }
}
