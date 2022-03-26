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
    public class CVSkillsController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        // GET: CVSkills
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var cVSkills = db.CVSkills.Include(c => c.Profile).Where(p => p.Profile.UserId == userId);
            return View(cVSkills.ToList());
        }

        // GET: CVSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVSkill cVSkill = db.CVSkills.Find(id);
            if (cVSkill == null)
            {
                return HttpNotFound();
            }
            return View(cVSkill);
        }

        // GET: CVSkills/Create
        public ActionResult Create()
        {
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName");
            return View();
        }

        // POST: CVSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserProfileId,Skilles")] CVSkill cVSkill)
        {
            var userId = User.Identity.GetUserId();
            var profile = db.Profiles.Where(p => p.UserId == userId).SingleOrDefault();
            if (profile != null)
            {
                cVSkill.UserProfileId = profile.Id;
            }

            if (ModelState.IsValid)
            {
                db.CVSkills.Add(cVSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cVSkill.UserProfileId);
            return View(cVSkill);
        }

        // GET: CVSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVSkill cVSkill = db.CVSkills.Find(id);
            if (cVSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cVSkill.UserProfileId);
            return View(cVSkill);
        }

        // POST: CVSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserProfileId,Skilles")] CVSkill cVSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserProfileId = new SelectList(db.Profiles, "Id", "FullName", cVSkill.UserProfileId);
            return View(cVSkill);
        }

        // GET: CVSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVSkill cVSkill = db.CVSkills.Find(id);
            if (cVSkill == null)
            {
                return HttpNotFound();
            }
            return View(cVSkill);
        }

        // POST: CVSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVSkill cVSkill = db.CVSkills.Find(id);
            db.CVSkills.Remove(cVSkill);
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
