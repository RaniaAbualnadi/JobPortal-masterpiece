using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortalWeb.Data;
using Microsoft.AspNet.Identity;

namespace JobPortalWeb.Controllers
{
    public class JobsDefinitionsController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        // GET: JobsDefinitions
        public ActionResult Index(string  SearchPhrase ="" )
        {
            var jobsDefinitions = db.JobsDefinitions.Include(j => j.Degree);
            var result = jobsDefinitions.Where(p => p.JobTitle.ToLower().Contains(SearchPhrase.ToLower()) || p.JobDescription.ToLower().Contains(SearchPhrase.ToLower()) ||  SearchPhrase.Trim() == ""  ).ToList();
            ViewBag.searchPhrase = SearchPhrase;
            return View(result);
        }

        // GET: JobsDefinitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobsDefinition jobsDefinition = db.JobsDefinitions.Find(id);
            if (jobsDefinition == null)
            {
                return HttpNotFound();
            }
            return View(jobsDefinition);
        }

        // GET: JobsDefinitions/Create
        public ActionResult Create()
        {
            ViewBag.MinDegreeId = new SelectList(db.Degrees, "Id", "Value");
            return View();
        }

        // POST: JobsDefinitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobTitle,JobDescription,StartPublishDate,EndPublishDate,MinDegreeId,Major,MinYearsOfExperance,JobRequirement,IsActive")] JobsDefinition jobsDefinition)
        {
            if (ModelState.IsValid)
            {
                db.JobsDefinitions.Add(jobsDefinition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MinDegreeId = new SelectList(db.Degrees, "Id", "Value", jobsDefinition.MinDegreeId);
            return View(jobsDefinition);
        }

        // GET: JobsDefinitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobsDefinition jobsDefinition = db.JobsDefinitions.Find(id);
            if (jobsDefinition == null)
            {
                return HttpNotFound();
            }
            ViewBag.MinDegreeId = new SelectList(db.Degrees, "Id", "Value", jobsDefinition.MinDegreeId);
            return View(jobsDefinition);
        }
        
        // GET: JobsDefinitions/Edit/5
        [Authorize]
        public ActionResult ApplyToJob(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobsDefinition jobsDefinition = db.JobsDefinitions.Find(id);
            if (jobsDefinition == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            var profileInfo = db.Profiles.Where(p => p.UserId == userId).Include("CvJobs").Include("CVEducations").Include("CVSkills").FirstOrDefault();
            if (!db.JobApplications.Any(p=>p.JobId == id && p.ApplicantProfileId == profileInfo.Id))
            {
                JobApplication entity = new JobApplication();
                entity.JobId = id.Value;
                entity.ApplicantProfileId = profileInfo.Id;
                entity.ApplicationDate = DateTime.Now; 
                db.JobApplications.Add(entity);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "JobApplications");
        }

        // POST: JobsDefinitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobTitle,JobDescription,StartPublishDate,EndPublishDate,MinDegreeId,Major,MinYearsOfExperance,JobRequirement,IsActive")] JobsDefinition jobsDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobsDefinition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MinDegreeId = new SelectList(db.Degrees, "Id", "Value", jobsDefinition.MinDegreeId);
            return View(jobsDefinition);
        }

        // GET: JobsDefinitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobsDefinition jobsDefinition = db.JobsDefinitions.Find(id);
            if (jobsDefinition == null)
            {
                return HttpNotFound();
            }
            return View(jobsDefinition);
        }

        // POST: JobsDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobsDefinition jobsDefinition = db.JobsDefinitions.Find(id);
            db.JobsDefinitions.Remove(jobsDefinition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
