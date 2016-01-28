using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEPernits.Controllers
{
    public class PermitsController : Controller
    {
        private DowntownEmployeeParkingEntities db = new DowntownEmployeeParkingEntities();

        //
        // GET: /Permits/

        public ActionResult Index()
        {
            var depermits_history = db.DEPermits_History.Include(d => d.DECar).Include(d => d.Status);
            return View(depermits_history.ToList());
        }

        //
        // GET: /Permits/Details/5

        public ActionResult Details(int id = 0)
        {
            DEPermits_History depermits_history = db.DEPermits_History.Find(id);
            if (depermits_history == null)
            {
                return HttpNotFound();
            }
            return View(depermits_history);
        }


        //
        // GET: /Permits/Create

        public ActionResult Create()
        {
            //DEPermits_History d = new DEPermits_History( d.BUSNum="222"; d.DEP_APPDATE );
            

            //var dd = db.DECars.Include(d=>d.DEmployee).ToList().Select(s => new {DECarsID=s.DECarsID, cbText=})
            //ViewBag.DECarID = new SelectList(db.DECars, "DECarsID", "CarMakeModel");
            ViewBag.DECarID = new SelectList(db.vw_DECarsOwnersInfo, "DECarsID", "ToDisplay");
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1");
            ViewBag.BUSNum = HttpContext.Application["BUSNum"] as string;
            //ViewBag.SysDate = Convert.ToDateTime(DateTime.Now, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss"); 
            ViewBag.SysDate = Convert.ToDateTime(DateTime.Now, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy"); 

            return View();
        }

        //
        // POST: /Permits/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DEPermits_History depermits_history)
        {
            if (ModelState.IsValid)
            {
                db.DEPermits_History.Add(depermits_history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DECarID = new SelectList(db.DECars, "DECarsID", "CarMakeModel", depermits_history.DECarID);
            ViewBag.DECarID = new SelectList(db.vw_DECarsOwnersInfo, "DECarsID", "ToDisplay", depermits_history.DECarID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1", depermits_history.StatusID);
            return View(depermits_history);
        }

        //
        // GET: /Permits/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DEPermits_History depermits_history = db.DEPermits_History.Find(id);
            if (depermits_history == null)
            {
                return HttpNotFound();
            }
            ViewBag.DECarID = new SelectList(db.DECars, "DECarsID", "CarMakeModel", depermits_history.DECarID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1", depermits_history.StatusID);
            return View(depermits_history);
        }

        //
        // POST: /Permits/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DEPermits_History depermits_history)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depermits_history).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DECarID = new SelectList(db.DECars, "DECarsID", "CarMakeModel", depermits_history.DECarID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1", depermits_history.StatusID);
            return View(depermits_history);
        }

        //
        // GET: /Permits/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DEPermits_History depermits_history = db.DEPermits_History.Find(id);
            if (depermits_history == null)
            {
                return HttpNotFound();
            }
            return View(depermits_history);
        }

        //
        // POST: /Permits/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPermits_History depermits_history = db.DEPermits_History.Find(id);
            db.DEPermits_History.Remove(depermits_history);
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