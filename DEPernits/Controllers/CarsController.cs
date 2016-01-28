using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEPernits.Controllers
{
    [AllowAnonymous]
    public class CarsController : Controller
    {
        private DowntownEmployeeParkingEntities db = new DowntownEmployeeParkingEntities();

        //
        // GET: /Cars/

        public ActionResult Index()
        {
            var decars = db.DECars.Include(d => d.Color1).Include(d => d.Make).Include(d => d.Model).Include(d => d.DEmployee).Include(d => d.State);
            return View(decars.ToList());
        }

        //
        // GET: /Cars/Details/5

        public ActionResult Details(int id = 2)
        {
            DECar decar = db.DECars.Find(id);
            if (decar == null)
            {
                return HttpNotFound();
            }
            return View(decar);
        }

        //
        // GET: /Cars/Create

        public ActionResult Create()
        {
            ViewBag.Color = new SelectList(db.Colors, "Color1", "Color1");
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "Make1");
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Model1");
            //ViewBag.ModelID = new SelectList(db.vw_DECarsOwnersInfo "ModelID", "ToDisplay",);
            ViewBag.OwnerId = new SelectList(db.DEmployees, "EmplID", "Name");
            ViewBag.PlateState = new SelectList(db.States, "Code", "Name", "WA");
            return View();
        }

        //
        // POST: /Cars/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DECar decar)
        {
            if (ModelState.IsValid)
            {
                db.DECars.Add(decar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Color = new SelectList(db.Colors, "Color1", "Color1", decar.Color);
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "Make1", decar.MakeID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Model1", decar.ModelID);
            ViewBag.OwnerId = new SelectList(db.DEmployees, "EmplID", "Name", decar.OwnerId);
            ViewBag.PlateState = new SelectList(db.States, "Code", "Name", decar.PlateState);
            
            return View(decar);
        }

        //
        // POST Select Car Model based on Make
        //[HttpPost]
        //public ActionResult SelectModel(int? tMakeID)
        //{
        //    var m = tMakeID.HasValue ? db.Models.FirstOrDefault(z => z.MakeID == tMakeID).Make : null;
        //    //Model t= new Model
        //    //{
        //    //    MakeID=tMakeID,
        //    //    Make=db.Makes.ToList(),
        //    //    Models=
        //    //}

            
            
        //    if (Request.IsAjaxRequest())
        //        return PartialView("_States", m);
        //    else
        //        return View("Index", m);

        //}

        //returning JSON or reguar list

        public ActionResult Makelist()
        {

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(db.Makes, "MakeID", "Make1"), JsonRequestBehavior.AllowGet);
            }
            return Json(new SelectList(db.Makes, "MakeID", "Make1"), JsonRequestBehavior.AllowGet);
            //return View(new SelectList(db.Makes, "MakeID", "Make1"));
        }

        public ActionResult Modellist(int MkID)
        {
            IQueryable t = db.Models.Where(x => x.MakeID == MkID).AsQueryable();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(t, "ModelID", "Model1"), JsonRequestBehavior.AllowGet);
            }
            return Json(new SelectList(t, "ModelID", "Model1"), JsonRequestBehavior.AllowGet);
            //return View(t);
        }


        //
        // GET: /Cars/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DECar decar = db.DECars.Find(id);
            if (decar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Color = new SelectList(db.Colors, "Color1", "Color1", decar.Color);
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "Make1", decar.MakeID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Model1", decar.ModelID);
            ViewBag.OwnerId = new SelectList(db.DEmployees, "EmplID", "Name", decar.OwnerId);
            ViewBag.PlateState = new SelectList(db.States, "Code", "Name", decar.PlateState);
            return View(decar);
        }

        //
        // POST: /Cars/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DECar decar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Color = new SelectList(db.Colors, "Color1", "Color1", decar.Color);
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "Make1", decar.MakeID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Model1", decar.ModelID);
            ViewBag.OwnerId = new SelectList(db.DEmployees, "EmplID", "Name", decar.OwnerId);
            ViewBag.PlateState = new SelectList(db.States, "Code", "Name", decar.PlateState);
            return View(decar);
        }

        //
        // GET: /Cars/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DECar decar = db.DECars.Find(id);
            if (decar == null)
            {
                return HttpNotFound();
            }
            return View(decar);
        }

        //
        // POST: /Cars/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DECar decar = db.DECars.Find(id);
            db.DECars.Remove(decar);
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