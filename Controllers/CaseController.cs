using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.WebPages;
using RdoCallLogger.Models;

namespace RdoCallLogger.Controllers
{ 
    [Authorize]
    public class CaseController : Controller
    {
        private RdoEntities db = new RdoEntities();

        //
        // GET: /Case/

        public ViewResult Index(int page = 1, string sort = "CaseTitle", string sortDir = "ASC")
        {
            // Clear search keyword for case
            Session["CaseKeyword"] = "";

            int totalRows = 0;
            int pageSize = 10;
            List<Case> cases = new List<Case>();

            totalRows = db.Cases.Count();
            cases = (db.Cases.OrderBy(m => m.CaseDescription).Skip((page - 1) * pageSize).Take(pageSize)).ToList();

            PruneLongDescriptions(cases);
            PagedCases pCases = new PagedCases(cases, pageSize, page, totalRows);

            return View(pCases);
        }

        //
        // GET: /Case/Details/5

        public ViewResult Details(int id)
        {
            Case rdoCase = db.Cases.Find(id);
            Farm farm = db.Farms.Find(rdoCase.FarmID);
            rdoCase.Farm = farm;

            return View(rdoCase);
        }

        //
        // GET: /Case/Create

        public ActionResult Create(int farmId=0)
        {
            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", farmId);
            return View();
        } 

        //
        // POST: /Case/Create

        [HttpPost]
        public ActionResult Create(Case rdoCase)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(rdoCase);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", rdoCase.FarmID);
            return View(rdoCase);
        }
        
        //
        // GET: /Case/Edit/5
 
        public ActionResult Edit(int id)
        {
            Case rdoCase = db.Cases.Find(id);
            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", rdoCase.FarmID);
            return View(rdoCase);
        }

        //
        // POST: /Case/Edit/5

        [HttpPost]
        public ActionResult Edit(Case rdoCase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rdoCase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmList = new SelectList(db.Farms, "ID", "Name", rdoCase.FarmID);
            return View(rdoCase);
        }

        //
        // GET: /Case/Delete/5
 
        public ActionResult Delete(int id)
        {
            Case rdoCase = db.Cases.Find(id);
            return View(rdoCase);
        }

        //
        // POST: /Case/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Case rdoCase = db.Cases.Find(id);
            db.Cases.Remove(rdoCase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult Search(int page = 1, string keyword = "")
        {
            string savedKeyword = (string)Session["CaseKeyword"];
            if (!String.IsNullOrEmpty(savedKeyword))
                keyword = savedKeyword;

            int totalRows = 0;
            int pageSize = 10;
            List<Case> cases = new List<Case>();

            if (keyword == "")
            {
                totalRows = db.Cases.Count();
                cases = (db.Cases.OrderBy(m => m.ID).Skip((page - 1) * pageSize).Take(pageSize)).ToList();
            }
            else
            {
                totalRows = db.Cases
                                .Where(m => m.CaseTitle.Contains(keyword) || m.CaseDescription.Contains(keyword))
                                .Count();
                cases = (db.Cases
                            .Where(m => m.CaseTitle.Contains(keyword) || m.CaseDescription.Contains(keyword))
                            .OrderBy(m => m.ID)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)).ToList();
            }

            Session["keyword"] = keyword;
            PruneLongDescriptions(cases);
            PagedCases pCases = new PagedCases(cases, pageSize, page, totalRows);

            return View(pCases);
        }

        // Pruning long description
        private void PruneLongDescriptions(List<Case> cases)
        {
            foreach (Case rdocase in cases)
            {
                if (rdocase.CaseDescription.Length > 150)
                    rdocase.CaseDescription = rdocase.CaseDescription.Substring(0, 150);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}