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
    public class ScheduledInterviewsController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        // GET: ScheduledInterviews
        public ActionResult Index()
        {
            var scheduledInterviews = db.ScheduledInterviews.Include(s => s.InterviewType).Include(s => s.JobApplication);
            return View(scheduledInterviews.ToList());
        }

        // GET: ScheduledInterviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledInterview scheduledInterview = db.ScheduledInterviews.Find(id);
            if (scheduledInterview == null)
            {
                return HttpNotFound();
            }
            return View(scheduledInterview);
        }

        // GET: ScheduledInterviews/Create
        public ActionResult Create(int? id)
        {
            var queryScheduled  = from c in db.ScheduledInterviews where c.JobApplicationId == id select c;
            if (queryScheduled.Count() > 0 )
            {
                return RedirectToAction("Edit", new { id = queryScheduled.FirstOrDefault().Id });
            }
            ViewBag.InterviewTypeId = new SelectList(db.InterviewTypes, "Id", "Value");
            //linq query 
            var query = from c in db.JobApplications select new 
            {
                Value = c.Profile.FullName + " - "+ c.JobsDefinition.JobTitle ,
                Id= c.Id 
            };
            ViewBag.JobApplicationId = new SelectList(query.ToList(), "Id", "Value",id);
            return View();
        }

        // POST: ScheduledInterviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobApplicationId,InvitationDate,InterviewDate,IsAttended,InterviewTypeId,IsPassed,Score,ArchivedForLater,InterviewReport")] ScheduledInterview scheduledInterview, int? id)
        {
            if (ModelState.IsValid)
            {
                db.ScheduledInterviews.Add(scheduledInterview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var query = from c in db.JobApplications
                        select new
                        {
                            Value = c.Profile.FullName + " - " + c.JobsDefinition.JobTitle,
                            c.Id
                        };
            ViewBag.InterviewTypeId = new SelectList(db.InterviewTypes, "Id", "Value", scheduledInterview.InterviewTypeId);
            ViewBag.JobApplicationId = new SelectList(query.ToList(), "Id", "Value", scheduledInterview.JobApplicationId);
            return View(scheduledInterview);
        }

        // GET: ScheduledInterviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledInterview scheduledInterview = db.ScheduledInterviews.Find(id);
            if (scheduledInterview == null)
            {
                return HttpNotFound();
            }
            var query = from c in db.JobApplications
                        select new
                        {
                            Value = c.Profile.FullName + " - " + c.JobsDefinition.JobTitle,
                            c.Id
                        };
            ViewBag.InterviewTypeId = new SelectList(db.InterviewTypes, "Id", "Value", scheduledInterview.InterviewTypeId);
            ViewBag.JobApplicationId = new SelectList(query.ToList(), "Id", "Value", scheduledInterview.JobApplicationId);
            return View(scheduledInterview);
        }

        // POST: ScheduledInterviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobApplicationId,InvitationDate,InterviewDate,IsAttended,InterviewTypeId,IsPassed,Score,ArchivedForLater,InterviewReport")] ScheduledInterview scheduledInterview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduledInterview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var query = from c in db.JobApplications
                        select new
                        {
                            Value = c.Profile.FullName + " - " + c.JobsDefinition.JobTitle,
                            c.Id
                        };
            ViewBag.InterviewTypeId = new SelectList(db.InterviewTypes, "Id", "Value", scheduledInterview.InterviewTypeId);
            ViewBag.JobApplicationId = new SelectList(query.ToList(), "Id", "Value", scheduledInterview.JobApplicationId);
            return View(scheduledInterview);
        }

        // GET: ScheduledInterviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledInterview scheduledInterview = db.ScheduledInterviews.Find(id);
            if (scheduledInterview == null)
            {
                return HttpNotFound();
            }
            return View(scheduledInterview);
        }

        // POST: ScheduledInterviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduledInterview scheduledInterview = db.ScheduledInterviews.Find(id);
            db.ScheduledInterviews.Remove(scheduledInterview);
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
