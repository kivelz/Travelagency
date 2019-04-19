using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSTA.Models;
using FSTA.Models.ViewModel;
using Microsoft.Ajax.Utilities;

namespace FSTA.Controllers
{
    public class AssignLeaderController : Controller
    {
        // GET: AssignLeader
        public ActionResult Index(DateTime? start, DateTime? end)//i didn't turn of fanything
        {
            //init the list
            List<PackageDetailsDAO> list = new List<PackageDetailsDAO>();
            List<TourLeader> lead = new List<TourLeader>();

           
            using (FourSTAContainer db = new FourSTAContainer())
            {
               
                if (start == null && end == null)
                {
                    list = db.PackageDetailsDAOs.ToList();
                    lead = db.TourLeaders.ToList();
                }
                else
                {
                    list = db.PackageDetailsDAOs.Where(x => x.StartDate == start && x.EndDate == end).ToList();
                    lead = db.TourLeaders.ToList();
                }

             }

            ViewData["Lead"] = lead;
          
     
                return View(list);
        }

        public ActionResult AssignLeader()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignLeader(PackageDetailsDTO model)
        {
          
 
            using (FourSTAContainer db = new FourSTAContainer())
            {
                var leaderName = db.TourLeaders.Where(x => x.Name == model.TourLeaderName).FirstOrDefault();
                var pkn = db.Packages.Where(x => x.PackageName == model.PackageName).FirstOrDefault();
                var occupied = db.PackageDetailsDAOs
                    .Where(x => x.StartDate == model.StartDate && x.EndDate == model.EndDate).FirstOrDefault();

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Invalid input");
                }
             
                if (leaderName == null || pkn == null)
                {
                    TempData["null"] = "Tour Leader or Package Doesn't Exist";
                    return View();
                }
                else if (occupied != null && pkn != null)
                {
                    TempData["null"] = "Current trip has already been assigned with a tour leader";
                    return View();
                }
                else
                {
                    PackageDetailsDAO package = new PackageDetailsDAO();
                    
                        package.PackageName = model.PackageName;
                        package.TourLeaderName = model.TourLeaderName;
                        package.StartDate = model.StartDate;
                        package.EndDate = model.EndDate;
                        package.Duration = pkn.Duration;
                        package.Salary = leaderName.Salary;

                    db.PackageDetailsDAOs.Add(package);
                    db.SaveChanges();
                }

                TempData["suc"] = "Tour Leader has successfully assigned.";
            }

            return RedirectToAction("Index", "AssignLeader");
        }
    }
}
// ok this is my post form for assigning tourleader to specific tour