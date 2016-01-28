using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using DEPernits.Models;
using System.Web.Script.Serialization;
using System.Net;

namespace DEPernits.Controllers
{
    public class HomeController : Controller
    {

        public DowntownEmployeeParkingEntities db = new DowntownEmployeeParkingEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "text";

            return View(db.vw_ui_dashboard1);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Downtown parking program";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Reports()
        {
            ViewBag.Message = "Reports";

            ///*Credentials of a user that has access to SSRS*/
            //string userid = "UserId";
            //string password = "MyPassword";
            //string domain = "MyDomain";

            //string reportURL = "http://ServerName/ReportServer?/ReportsFolder/ReportName&Parameter=UserName&rs:Command=Render&rs:Format=PDF";

            //NetworkCredential nwc = new NetworkCredential(userid, password, domain);

            //WebClient client = new WebClient();
            //client.Credentials = nwc;

            //Byte[] pageData = client.DownloadData(reportURL);

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now);
            //Response.BinaryWrite(pageData);
            //Response.Flush();
            //Response.End();

            return View();
        }

        public ActionResult CreatePermitForm()
        {

            
            ViewBag.Message = "text";

            return View();
            
        }

        [HttpPost]
        public ActionResult CreatePermitForm(string BUSNum)
        {

            if (BUSNum != null)
            {
                vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses = db.vw_DowntownActiveBusinessLicenses.Where(d => d.License_Number == BUSNum).FirstOrDefault();
                if (vw_downtownactivebusinesslicenses == null)
                {
                    return HttpNotFound();
                }
                //return View(vw_downtownactivebusinesslicenses);
                return Json(vw_downtownactivebusinesslicenses, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Message = "text";

                return View();
            }
        }


        [HttpPost]
        public ActionResult CreatePermitFormJson(string BUSNum)
        {

            
            
            //var t = new JavaScriptSerializer();
            //var message = t.Deserialize<string>("[{Errpr: 'No data, please look up in BUssines table for a right number'}]");
            var message = "{\"Status\":true,\"ErrorCode\":0,\"Messages\":[\"No Data.\"],\"Data\": [{\"Error\":\"Nothing to display\"]}";



            //vw_DowntownActiveBusinessLicenses vw_downtownactivebusinesslicenses = db.vw_DowntownActiveBusinessLicenses.Where(d => d.License_Number == BUSNum).FirstOrDefault();
            var vw_downtownactivebusinesslicenses = db.vw_DowntownActiveBusinessLicenses.Where(d => d.License_Number == BUSNum).Select(m => new { Name = m.DBA, Status = m.License_Status, Address = m.DBA_Address_Line1, Emlpoyees = m.Employees }).ToList(); //.FirstOrDefault();
                if (vw_downtownactivebusinesslicenses == null) 
                {
                    HttpContext.Application["BUSNum"] = null;
                    //return Json("[{\"Errpr\": \"No data, please look up in BUssines table for a right number\"}]", JsonRequestBehavior.AllowGet); //HttpNotFound();
                    return Json(message, JsonRequestBehavior.AllowGet); //HttpNotFound();
                }
                //return View(vw_downtownactivebusinesslicenses);

                HttpContext.Application["BUSNum"] = BUSNum;
            return Json(vw_downtownactivebusinesslicenses, JsonRequestBehavior.AllowGet);
                //return Json(BUSNum, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public ActionResult CreatePermitFormRegisteredJson(string BUSNum)
        {

            //var zz = db.vw_TotalCarPerBus.Where(x => x.BUSNum == BUSNum).Select(m => new { Registered_Cars = m.TotalCarsPerBus, Registered_Employees = m.TotalEmplPerBus, m.Name, m.TotalCarsPerEmpl }).ToList();
            var zz = db.vw_TotalCarPerBus.Where(x => x.BUSNum == BUSNum).Select(m => new { m.Name, Cars = m.TotalCarsPerEmpl }).ToList(); 
            if (zz == null)
            {
                HttpContext.Application["BUSNum"] = null;
                return Json("[{\"Status\":true,\"Errpr\": \"No data, please look up in BUssines table for a right number\"}]", JsonRequestBehavior.AllowGet); //HttpNotFound();
            }
            //return View(vw_downtownactivebusinesslicenses);

            ViewBag.RegisteredCars = "eeeef";//db.vw_TotalCarPerBus.Where(x => x.BUSNum == BUSNum).Select(m => new { Registered_Cars = m.TotalCarsPerBus}).FirstOrDefault();
            ViewData["RegisteredEmployees"] = "asdf";//db.vw_TotalCarPerBus.Where(x => x.BUSNum == BUSNum).Select(m => new { Registered_Employees = m.TotalEmplPerBus }).FirstOrDefault();
            

            HttpContext.Application["BUSNum"] = BUSNum;
            
            return Json(zz, JsonRequestBehavior.AllowGet);


        }





        public ActionResult Test()
        {
            ViewBag.Message = "text";

            ViewBag.RegisteredCars = "eeeef";//db.vw_TotalCarPerBus.Where(x => x.BUSNum == BUSNum).Select(m => new { Registered_Cars = m.TotalCarsPerBus}).FirstOrDefault();
            ViewData["RegisteredEmployees"] = "asdf";//db.vw_TotalCarPerBus.Where(x => x.BUSNum == BUSNum).Select(m => new { Registered_Employees = m.TotalEmplPerBus }).FirstOrDefault();
            

            //var vm = new CreatePermitViewModel();

            //vm.DEPermits_History=db.DEPermits_History.Include(d=>d.DECar)

            var q = from c in db.DECars
                    join p in db.DEPermits_History on c.DECarsID equals p.DECarID
                    join e in db.DEmployees on c.OwnerId equals e.EmplID
                    select new { id = c.DECarsID, Driver = e.Name, car = c.CarMakeModel };

            return View(q.FirstOrDefault());
            //return PartialView();
        }


        //public ActionResult dashboard1()
        //{
        //    using (DowntownEmployeeParkingEntities db = new DowntownEmployeeParkingEntities())
        //    {
        //        return View(db.vw_ui_dashboard1);
        //    }
        //}


        public ActionResult DashboardUI1()
        {
            //using ( DowntownEmployeeParkingEntities db = new DowntownEmployeeParkingEntities())
            //{
            //    var t = db.vw_ui_dashboard1.ToList();
            //    return PartialView("_test2", t);
            //}


            return View(db.vw_ui_dashboard1);


        }

    }

}
