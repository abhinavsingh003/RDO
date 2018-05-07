using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RdoCallLogger.Models;
using System.Web.Security;

namespace RdoCallLogger.Controllers
{ 
    [Authorize]
    public class CustomerController : Controller
    {
        private RdoEntities db = new RdoEntities();

        //
        // GET: /Customer/

        public ViewResult Index()
        {
            ViewData[CustomerSearch.SearchOptionString] = new SelectList(CustomerSearch.AvailableOptions());

            return View(db.Customers.Include(m => m.Farm).ToList());
        }

        [HttpPost]
        public ViewResult Index(CustomerSearch search)
        {
            ViewData[CustomerSearch.SearchOptionString] = new SelectList(CustomerSearch.AvailableOptions(), search.SearchOption);

            if (search.SearchOption == "Phone Number")
            {
                var customers = db.Customers.Include(m => m.Farm)
                                .Where(m => m.CellPhone == search.Keyword || m.WorkPhone == search.Keyword);

                return View(customers);
            }
            else
            {
                var customers = db.Customers.Include(m => m.Farm)
                                .Where(m => m.Farm.Name.Contains(search.Keyword));

                return View(customers);
            }
        }

        //
        // GET: /Customer/Details/5

        public ViewResult Details(int id)
        {
            Customer customer = db.Customers.Find(id);
            Farm farm = db.Farms.Find(customer.FarmID);
            customer.Farm = farm;

            return View(customer);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create(int farmId=0)
        {
            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", farmId);
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", customer.FarmID);
            return View(customer);
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Customer customer = db.Customers.Find(id);
            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", customer.FarmID);
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", customer.FarmID);
            return View(customer);
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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