using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSTA.DB;
using FSTA.Models;
using FSTA.Models.ViewModel;

namespace FSTA.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        public ActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Index(int Id, int duration)
        {
            TourLeaderDTO lead = TourLeaderData.GetTourLeaderById(Id);

            string name = lead.Name;
            string Rank = lead.Rank;
            string email = lead.Email;
            int phone = lead.Phone;
            decimal cost = 0m;
            int DailyRate = 0;
            int dur = 0;

            if (Rank == "M1")
            {
                DailyRate = 500;
            }
            else if (Rank == "M2")
            {
                DailyRate = 400;
            }
            else if (Rank == "M3")
            {
                DailyRate = 300;
            }

            cost = DailyRate * duration;

           
            //}
            ViewData["phone"] = phone;
            ViewData["email"] = email;
            ViewData["duration"] = duration;
            ViewData["cost"] = cost;
            ViewData["Id"] = Id;
            ViewData["Name"] = name;
            ViewData["Rank"] = Rank;
            return View();
        }
    }
}