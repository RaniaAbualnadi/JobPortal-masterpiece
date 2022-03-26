using JobPortalWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalWeb.Controllers
{
    public class HomeController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();
        public ActionResult Index()
        {
            List<JobsDefinition> jobs =  db.JobsDefinitions.OrderByDescending(p => p.Id).Take(4).ToList();   

            return View(jobs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}