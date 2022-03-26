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
    public class EmailNotificationsController : Controller
    {
        private EmploymentGateEntities db = new EmploymentGateEntities();

        // GET: EmailNotifications
        public ActionResult Index()
        {
            return View(db.EmailNotifications.ToList());
        }

        // GET: EmailNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailNotification emailNotification = db.EmailNotifications.Find(id);
            if (emailNotification == null)
            {
                return HttpNotFound();
            }
            return View(emailNotification);
        }

        // GET: EmailNotifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailNotifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,NotificationMessage,NotificationDatet")] EmailNotification emailNotification)
        {
            if (ModelState.IsValid)
            {
                db.EmailNotifications.Add(emailNotification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailNotification);
        }

        // GET: EmailNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailNotification emailNotification = db.EmailNotifications.Find(id);
            if (emailNotification == null)
            {
                return HttpNotFound();
            }
            return View(emailNotification);
        }

        // POST: EmailNotifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,NotificationMessage,NotificationDatet")] EmailNotification emailNotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailNotification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailNotification);
        }

        // GET: EmailNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailNotification emailNotification = db.EmailNotifications.Find(id);
            if (emailNotification == null)
            {
                return HttpNotFound();
            }
            return View(emailNotification);
        }

        // POST: EmailNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailNotification emailNotification = db.EmailNotifications.Find(id);
            db.EmailNotifications.Remove(emailNotification);
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
