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
    public class InterviewTypesController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        // GET: InterviewTypes
        public ActionResult Index()
        {
            return View(db.InterviewTypes.ToList());
        }

        // GET: InterviewTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewType interviewType = db.InterviewTypes.Find(id);
            if (interviewType == null)
            {
                return HttpNotFound();
            }
            return View(interviewType);
        }

        // GET: InterviewTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterviewTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] InterviewType interviewType)
        {
            if (ModelState.IsValid)
            {
                db.InterviewTypes.Add(interviewType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interviewType);
        }

        // GET: InterviewTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewType interviewType = db.InterviewTypes.Find(id);
            if (interviewType == null)
            {
                return HttpNotFound();
            }
            return View(interviewType);
        }

        // POST: InterviewTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] InterviewType interviewType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interviewType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interviewType);
        }

        // GET: InterviewTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewType interviewType = db.InterviewTypes.Find(id);
            if (interviewType == null)
            {
                return HttpNotFound();
            }
            return View(interviewType);
        }

        // POST: InterviewTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterviewType interviewType = db.InterviewTypes.Find(id);
            db.InterviewTypes.Remove(interviewType);
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
