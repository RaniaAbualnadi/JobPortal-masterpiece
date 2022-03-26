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
    [Authorize]
    public class CvJobsController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        // GET: CvJobs
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (!db.Profiles.Any(p => p.UserId == userId))
            {
                return RedirectToAction("Create", "Profiles", new { showMessage = true });
            }
            var cvJobs = db.CvJobs.Include(c => c.Profile).Where(p=>p.Profile.UserId == userId);
            return View(cvJobs.ToList());
        }

        // GET: CvJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CvJob cvJob = db.CvJobs.Find(id);
            if (cvJob == null)
            {
                return HttpNotFound();
            }
            return View(cvJob);
        }

        // GET: CvJobs/Create
        public ActionResult Create()
        {
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName");
            return View();
        }

        // POST: CvJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserProfileId,JobTitle,JobDescription,StartDate,EndDate,jobResponsibilities")] CvJob cvJob)
        {

            var userId = User.Identity.GetUserId();
            var profile = db.Profiles.Where(p => p.UserId == userId).SingleOrDefault();
            if (profile !=null )
            {
                cvJob.UserProfileId = profile.Id; 
            }
            if (ModelState.IsValid)
            {
                db.CvJobs.Add(cvJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cvJob.UserProfileId);
            return View(cvJob);
        }

        // GET: CvJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CvJob cvJob = db.CvJobs.Find(id);
            if (cvJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cvJob.UserProfileId);
            return View(cvJob);
        }

        // POST: CvJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserProfileId,JobTitle,JobDescription,StartDate,EndDate,jobResponsibilities")] CvJob cvJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cvJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cvJob.UserProfileId);
            return View(cvJob);
        }

        // GET: CvJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CvJob cvJob = db.CvJobs.Find(id);
            if (cvJob == null)
            {
                return HttpNotFound();
            }
            return View(cvJob);
        }

        // POST: CvJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CvJob cvJob = db.CvJobs.Find(id);
            db.CvJobs.Remove(cvJob);
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
