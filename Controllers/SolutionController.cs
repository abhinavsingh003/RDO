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
    [Authorize]
    public class SolutionController : Controller
    {
        private RdoEntities db = new RdoEntities();

        //
        // GET: /Solution/

        public ViewResult Index()
        {
            var solutions = db.Solutions.ToList();
            PruneLongDescriptions(solutions);

            return View(solutions);
        }

        //
        // GET: /Solution/Details/5

        public ViewResult Details(int id)
        {
            Solution solution = db.Solutions.Find(id);
            return View(solution);
        }

        //
        // GET: /Solution/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Solution/Create

        [HttpPost]
        public ActionResult Create(Solution solution)
        {
            if (ModelState.IsValid)
            {
                db.Solutions.Add(solution);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(solution);
        }
        
        //
        // GET: /Solution/Edit/5
 
        public ActionResult Edit(int id)
        {
            Solution solution = db.Solutions.Find(id);
            return View(solution);
        }

        //
        // POST: /Solution/Edit/5

        [HttpPost]
        public ActionResult Edit(Solution solution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solution);
        }

        //
        // GET: /Solution/Delete/5
 
        public ActionResult Delete(int id)
        {
            Solution solution = db.Solutions.Find(id);
            return View(solution);
        }

        //
        // POST: /Solution/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Solution solution = db.Solutions.Find(id);
            db.Solutions.Remove(solution);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Pruning long description
        private void PruneLongDescriptions(List<Solution> solutions)
        {
            foreach (Solution solution in solutions)
            {
                if (solution.SolutionDescription.Length > 150)
                    solution.SolutionDescription = solution.SolutionDescription.Substring(0, 150);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}