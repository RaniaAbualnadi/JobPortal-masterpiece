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
    public class ProfilesController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        //// GET: Profiles
        //public ActionResult Index()
        //{
        //    var profiles = db.Profiles.Include(p => p.Gender).Include(p => p.Nationality);
        //    return View(profiles.ToList());
        //}

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create(bool showMessage = false)
        {
            if (showMessage)
            {
                ViewBag.Message = "Please Create profile to continue";
            }
            var userId = User.Identity.GetUserId();
            if (db.Profiles.Any(p => p.UserId == userId))
            {
                return RedirectToAction("Edit", "Profiles");
            }
            Profile profile = new Profile() { Email = User.Identity.GetUserName() };

            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Value");
            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Value");
            return View(profile);
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Birthdate,GenderId,NationalityId,Email,UserId,MobileNumber,FullAddress,CoverLetter")] Profile profile, bool showMessage = false)
        {
            var userId = User.Identity.GetUserId();
            profile.UserId = userId;
            if (ModelState.IsValid)
            {

                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index", "CvJobs");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Value", profile.GenderId);
            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Value", profile.NationalityId);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit( )
        {
            var userId = User.Identity.GetUserId();
            if (!db.Profiles.Any(p => p.UserId == userId))
            {
                return RedirectToAction("Create", "Profiles", new { showMessage = true });
            }
            Profile profile = db.Profiles.Where(p=>p.UserId == userId).SingleOrDefault();

            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Value", profile.GenderId);
            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Value", profile.NationalityId);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Edit([Bind(Include = "Id,FullName,Birthdate,GenderId,NationalityId,Email,UserId,MobileNumber,FullAddress,CoverLetter")] Profile profile,string btn)
        {
            var userId = User.Identity.GetUserId();
            profile.UserId = userId;
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges(); 
                return RedirectToAction("Index", "CvJobs");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Value", profile.GenderId);
            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Value", profile.NationalityId);
            return View(profile);
        }

        public ActionResult CVViewer()
        {
            var userId = User.Identity.GetUserId();
            if (!db.Profiles.Any(p => p.UserId == userId))
            {
                return RedirectToAction("Create", "Profiles", new { showMessage =true});
            } 
            var profileInfo = db.Profiles.Where(p => p.UserId == userId).Include("CvJobs").Include("CVEducations").Include("CVSkills").FirstOrDefault();
            return View(profileInfo);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
