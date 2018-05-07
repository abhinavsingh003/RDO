using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RdoCallLogger.Models;

namespace RdoCallLogger.Controllers
{ 
    public class FarmController : Controller
    {
        private RdoEntities db = new RdoEntities();

        //
        // GET: /Farm/

        public ViewResult Index()
        {
            return View(db.Farms.ToList());
        }

        //
        // GET: /Farm/Details/5

        public ViewResult Details(int id)
        {
            Farm farm = db.Farms.Find(id);
            return View(farm);
        }

        //
        // GET: /Farm/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Farm/Create

        [HttpPost]
        public ActionResult Create(Farm farm)
        {
            if (ModelState.IsValid)
            {
                db.Farms.Add(farm);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(farm);
        }
        
        //
        // GET: /Farm/Edit/5
 
        public ActionResult Edit(int id)
        {
            Farm farm = db.Farms.Find(id);
            return View(farm);
        }

        //
        // POST: /Farm/Edit/5

        [HttpPost]
        public ActionResult Edit(Farm farm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farm);
        }

        //
        // GET: /Farm/Delete/5
 
        public ActionResult Delete(int id)
        {
            Farm farm = db.Farms.Find(id);
            return View(farm);
        }

        //
        // POST: /Farm/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Farm farm = db.Farms.Find(id);
            db.Farms.Remove(farm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}