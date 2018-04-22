using farmers_land.Models;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace farmers_land.Controllers
{
    public class ProduceController : Controller
    {
        // GET: Produce
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produce/Details
        public ActionResult Details()
        {
            var produce = new Produce{ Sid = 1, Seller = "Paul", Name = "carrot", Category = "Vegtable", Quantity = 30, Price = 100 };
            return View(produce);
        }

        // GET: Produce/Create
        public ActionResult Create()
        {
            var produce = new Produce { Sid = 2, Seller = "Raul", Name = "Mango", Category = "Fruit", Quantity = 20, Price = 100 };
            return View(produce);
        }

        // POST: Produce/Create
        [HttpPost]
        public ActionResult Create(FormCollection details)
        {
            var produce = new Produce { Sid = 2 , Seller = "Raul", Name = "Mango", Category = "Fruit", Quantity = 20 , Price = 100  };
            return View("Details",produce);
            // return RedirectToAction("Index", "Home");
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produce/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produce/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produce/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produce/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
