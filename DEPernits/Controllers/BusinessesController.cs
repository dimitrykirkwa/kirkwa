using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEPernits.Controllers
{
    public class BusinessesController : Controller
    {
        private DowntownEmployeeParkingEntities db = new DowntownEmployeeParkingEntities();

        //
        // GET: /Businesses/

        public ActionResult Index()
        {
            return View(db.vw_DowntownActiveBusinessLicenses.ToList());
        }

        //
        // GET: /Businesses/Details/5

        public ActionResult Details(string id = null)
        {
            vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses = db.vw_DowntownActiveBusinessLicenses.Find(id);
            if (vw_downtownactivebusinesslicenses == null)
            {
                return HttpNotFound();
            }
            return View(vw_downtownactivebusinesslicenses);
        }

        //
        // GET: /Businesses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Businesses/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses)
        {
            if (ModelState.IsValid)
            {
                db.vw_DowntownActiveBusinessLicenses.Add(vw_downtownactivebusinesslicenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_downtownactivebusinesslicenses);
        }

        //
        // GET: /Businesses/Edit/5

        public ActionResult Edit(string id = null)
        {
            vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses = db.vw_DowntownActiveBusinessLicenses.Find(id);
            if (vw_downtownactivebusinesslicenses == null)
            {
                return HttpNotFound();
            }
            return View(vw_downtownactivebusinesslicenses);
        }

        //
        // POST: /Businesses/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_downtownactivebusinesslicenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_downtownactivebusinesslicenses);
        }

        //
        // GET: /Businesses/Delete/5

        public ActionResult Delete(string id = null)
        {
            vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses = db.vw_DowntownActiveBusinessLicenses.Find(id);
            if (vw_downtownactivebusinesslicenses == null)
            {
                return HttpNotFound();
            }
            return View(vw_downtownactivebusinesslicenses);
        }

        //
        // POST: /Businesses/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses = db.vw_DowntownActiveBusinessLicenses.Find(id);
            db.vw_DowntownActiveBusinessLicenses.Remove(vw_downtownactivebusinesslicenses);
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