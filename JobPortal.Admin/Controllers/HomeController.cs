using JobPortal.Admin.Data;
using JobPortal.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class HomeController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();
        public ActionResult Index()
        {
            DashboardModel dashboardModel = new DashboardModel();
            dashboardModel.JobsCount = db.JobsDefinitions.Count(p => p.IsActive);
            dashboardModel.AppliedToJobsCount = db.JobApplications.Count();
            dashboardModel.NumberOfUsers = db.AspNetUsers.Count();
            //bde a7wlhom l view model
            var queryJobDef = from c in db.JobsDefinitions
                              where c.IsActive == true
                              orderby c.Id descending
                              select new JobsDefinitionModel()
                              {
                                  Id = c.Id,
                                  JobTitle = c.JobTitle,
                                  JobDescription = c.JobDescription.Substring(0, 100)
                              };
            dashboardModel.JobsList = queryJobDef.Take(5).ToList();

            var queryJobApplication = from c in db.JobApplications
                                      orderby c.Id descending
                                      select new JobApplicationModel()
                                      {
                                          ApplyDate = c.ApplicationDate,
                                          JobAppliactionId = c.Id,
                                          JobId = c.JobId,
                                          JobTitle = c.JobsDefinition.JobTitle,
                                          UserName = c.Profile.FullName
                                      };

            dashboardModel.JobApplications = queryJobApplication.Take(5).ToList(); 

            return View(dashboardModel);
        }

     

   
    }
}