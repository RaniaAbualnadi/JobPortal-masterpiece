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
    public class CVEducationsController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        // GET: CVEducations
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var cVEducations = db.CVEducations.Include(c => c.Degree).Include(c => c.Profile).Where(p => p.Profile.UserId == userId);
            return View(cVEducations.ToList());
        }

        // GET: CVEducations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVEducation cVEducation = db.CVEducations.Find(id);
            if (cVEducation == null)
            {
                return HttpNotFound();
            }
            return View(cVEducation);
        }

        // GET: CVEducations/Create
        public ActionResult Create()
        {
            ViewBag.EducationalDegreeId = new SelectList(db.Degrees, "Id", "Value");
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName");
            return View();
        }

        // POST: CVEducations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserProfileId,EducationalDegreeId,StartDate,EndDate,MajorId,Institute,GPA")] CVEducation cVEducation)
        {
            var userId = User.Identity.GetUserId();
            var profile = db.Profiles.Where(p => p.UserId == userId).SingleOrDefault();
            if (profile != null)
            {
                cVEducation.UserProfileId = profile.Id;
            }

            if (ModelState.IsValid)
            {
                db.CVEducations.Add(cVEducation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EducationalDegreeId = new SelectList(db.Degrees, "Id", "Value", cVEducation.EducationalDegreeId);
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cVEducation.UserProfileId);
            return View(cVEducation);
        }

        // GET: CVEducations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVEducation cVEducation = db.CVEducations.Find(id);
            if (cVEducation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationalDegreeId = new SelectList(db.Degrees, "Id", "Value", cVEducation.EducationalDegreeId);
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cVEducation.UserProfileId);
            return View(cVEducation);
        }

        // POST: CVEducations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserProfileId,EducationalDegreeId,StartDate,EndDate,MajorId,Institute,GPA")] CVEducation cVEducation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVEducation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EducationalDegreeId = new SelectList(db.Degrees, "Id", "Value", cVEducation.EducationalDegreeId);
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cVEducation.UserProfileId);
            return View(cVEducation);
        }

        // GET: CVEducations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVEducation cVEducation = db.CVEducations.Find(id);
            if (cVEducation == null)
            {
                return HttpNotFound();
            }
            return View(cVEducation);
        }

        // POST: CVEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVEducation cVEducation = db.CVEducations.Find(id);
            db.CVEducations.Remove(cVEducation);
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
