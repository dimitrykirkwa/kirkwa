using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEPernits.Controllers
{
    public class EmployeesController : Controller
    {
        private DowntownEmployeeParkingEntities db = new DowntownEmployeeParkingEntities();

        //
        // GET: /Employees/

        public ActionResult Index()
        {
            var demployees = db.DEmployees.Include(d => d.State).Include(d => d.State1);
            return View(demployees.ToList());
        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(int id = 0)
        {
            DEmployee demployee = db.DEmployees.Find(id);
            if (demployee == null)
            {
                return HttpNotFound();
            }
            return View(demployee);
        }

        //
        // GET: /Employees/Create

        public ActionResult Create()
        {
            ViewBag.EmplState = new SelectList(db.States, "Code", "Name","WA");
            ViewBag.DEP_DLSTATE = new SelectList(db.States, "Code", "Name","WA");
            
            //ViewBag.DEP_DLSTATE = new[] { new SelectListItem { Text = "Select State" }}.Concat(
            //    from s in db.States
            //        orderby s.Name
            //    select new SelectListItem { Text = s.Name, Value=s.Name, Selected=(s.Name=="wa")}
            //        );
            // http://stackoverflow.com/questions/894130/adding-a-default-selectlistitem



            ViewBag.BUSNum = HttpContext.Application["BUSNum"] as string;

            //var w = new DEmployee();
            //w.EmplState = "wa";
            //a.CreateDate = DateTime.Now;

            return View();
        }

        //
        // POST: /Employees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DEmployee demployee)
        {
            if (ModelState.IsValid)
            {
                db.DEmployees.Add(demployee);
                db.SaveChanges();
                TempData["Success"] = true;
                return RedirectToAction("Create");
                //return RedirectToAction("Index");
            }

            ViewBag.EmplState = new SelectList(db.States, "Code", "Name", demployee.EmplState);
            ViewBag.DEP_DLSTATE = new SelectList(db.States, "Code", "Name", demployee.DEP_DLSTATE);
            ViewBag.BUSNum = HttpContext.Application["BUSNum"] as string;
            return View(demployee);
        }

        //
        // GET: /Employees/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DEmployee demployee = db.DEmployees.Find(id);
            if (demployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmplState = new SelectList(db.States, "Code", "Name", demployee.EmplState);
            ViewBag.DEP_DLSTATE = new SelectList(db.States, "Code", "Name", demployee.DEP_DLSTATE);
            return View(demployee);
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DEmployee demployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmplState = new SelectList(db.States, "Code", "Name", demployee.EmplState);
            ViewBag.DEP_DLSTATE = new SelectList(db.States, "Code", "Name", demployee.DEP_DLSTATE);
            return View(demployee);
        }

        //
        // GET: /Employees/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DEmployee demployee = db.DEmployees.Find(id);
            if (demployee == null)
            {
                return HttpNotFound();
            }
            return View(demployee);
        }

        //
        // POST: /Employees/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEmployee demployee = db.DEmployees.Find(id);
            db.DEmployees.Remove(demployee);
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