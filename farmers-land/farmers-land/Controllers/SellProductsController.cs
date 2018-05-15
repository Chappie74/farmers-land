using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using farmers_land.Models;
using farmers_land.Models.DAL;

namespace farmers_land.Controllers
{
    public class SellProductsController : Controller
    {
        private farmersmarketEntities db = new farmersmarketEntities();

        // GET: SellProducts
        public async Task<ActionResult> Index()
        {
            return View(await db.SellProducts.ToListAsync());
        }

        // GET: SellProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            if (sellProduct == null)
            {
                return HttpNotFound();
            }
            return View(sellProduct);
        }

        // GET: SellProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Category,ImageName,ImageData,Price,Amount")] SellProduct sellProduct)
        {
            if (ModelState.IsValid)
            {
                db.SellProducts.Add(sellProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sellProduct);
        }

        // GET: SellProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            if (sellProduct == null)
            {
                return HttpNotFound();
            }
            return View(sellProduct);
        }

        // POST: SellProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Category,ImageName,ImageData,Price,Amount")] SellProduct sellProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sellProduct);
        }

        // GET: SellProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            if (sellProduct == null)
            {
                return HttpNotFound();
            }
            return View(sellProduct);
        }

        // POST: SellProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            db.SellProducts.Remove(sellProduct);
            await db.SaveChangesAsync();
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
