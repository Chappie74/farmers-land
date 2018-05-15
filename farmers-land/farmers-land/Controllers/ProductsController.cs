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
using System.Text;
using System.Security.Cryptography;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;

namespace farmers_land.Controllers
{
    public class ProductsController : Controller
    {
        private farmersmarketEntities db = new farmersmarketEntities();


        // GET: Sell Product
        public async Task <ActionResult> SellProduct()
        {
            var  dbcategories = await db.Categories.ToListAsync();
            List <SelectListItem> categories = new List<SelectListItem>();

            foreach (var item in dbcategories)
            {
                SelectListItem li = new SelectListItem() { Text = item.categoryName.ToString(), Value = item.category_id.ToString()};
                categories.Add(li);
            }

            ViewBag.Category = categories;
            return View();
        }

        //Http Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SellProduct(SellProduct model, HttpPostedFileBase ImageFile)
        {
            model.ImageFile = ImageFile;

            if(model.ImageFile.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("InvalidImage", "File too large. Must be < 2MB");
                return View(model);
            }

            if (!(model.ImageFile.ContentType == "image/jpg" || model.ImageFile.ContentType == "image/jpeg" ||
                    model.ImageFile.ContentType == "image/bmp" || model.ImageFile.ContentType == "image/png"
                ))
            {
                ModelState.AddModelError("InvalidImage", "Only image formats(jpg, gif,png, bmp)");
                return View(model);
            }

            model.ImageName = model.ImageFile.FileName.ToString();

            if (ModelState.IsValid)
            {
                //hash the name for the image file
                var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(model.ImageName + DateTime.Now.ToString()));
                model.ImageName = string.Join("", hash.Select(b => b.ToString("x2")).ToArray());

                //turn the image uploaded into bytes
                byte[] data = new byte[model.ImageFile.ContentLength];
                model.ImageFile.InputStream.Read(data, 0, model.ImageFile.ContentLength);
                //store the bytes in themodel
                model.ImageData = data;

                Product aProduct = new Product();
                aProduct.name = model.Name;
                aProduct.category_id = int.Parse(model.Category);
                aProduct.imageData = model.ImageData;
                aProduct.imageName = model.ImageName;

                //add to products table
                try
                {

                    db.Products.Add(aProduct);
                    await db.SaveChangesAsync();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                //populate the products for sale table
                ProductsForSale newEntry = new ProductsForSale();
                newEntry.amount = model.Amount;
                newEntry.user_id = User.Identity.GetUserId();
                newEntry.product_id = aProduct.product_id;
                newEntry.price = (decimal) model.Price;
                newEntry.date_listed = DateTime.Now;

                try
                {
                    db.ProductsForSales.Add(newEntry);
                    await db.SaveChangesAsync();
                    return Redirect("https://google.com");
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }


            }

            return View();
        }



        public async Task <ActionResult> MyListings()
        {

            return View();
        }




        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            //if (sellProduct == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Category,ImageName,ImageData,ImageFile,Price,Amount")] SellProduct sellProduct)
        {
            if (ModelState.IsValid)
            {
                //db.SellProducts.Add(sellProduct);
                //await db.SaveChangesAsync();
                //return RedirectToAction("Index");
            }

            return View(sellProduct);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            //if (sellProduct == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Category,ImageName,ImageData,ImageFile,Price,Amount")] SellProduct sellProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sellProduct);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            //if (sellProduct == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //SellProduct sellProduct = await db.SellProducts.FindAsync(id);
            //db.SellProducts.Remove(sellProduct);
            //await db.SaveChangesAsync();
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
