using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace farmers_land.Controllers
{
    public class BrowseController : Controller
    {
        // GET: Browse
        public ActionResult Index()
        {
            return View();
        }

        // GET: Browse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Browse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Browse/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
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

        // GET: Browse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Browse/Edit/5
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

        // GET: Browse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Browse/Delete/5
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
