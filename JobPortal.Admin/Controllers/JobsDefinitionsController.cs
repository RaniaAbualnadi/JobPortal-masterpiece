using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortal.Admin.Data;

namespace JobPortal.Admin.Controllers
{

    [Authorize(Roles = "SuperAdmin,Admin")]
    public class JobsDefinitionsController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        
        // GET: JobsDefinitions
        public ActionResult Index()
        {
            var jobsDefinitions = db.JobsDefinitions.Include(j => j.Degree);
            return View(jobsDefinitions.ToList());
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
        public ActionResult Create([Bind(Include = "JobTitle,JobDescription,StartPublishDate,EndPublishDate,MinDegreeId,Major,MinYearsOfExperance,JobRequirement,IsActive")] JobsDefinition jobsDefinition)
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
            jobsDefinition.IsActive = false;
            db.Entry(jobsDefinition).State = EntityState.Modified;
            //db.JobsDefinitions.Remove(jobsDefinition); 
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
