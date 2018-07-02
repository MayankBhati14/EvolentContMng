using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContactManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ContactManager/
        public ActionResult Index()
        {
            return View();
        }

        //// GET: /ContactManager/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PersonContactInfo personcontactinfo = db.PersonContacts.Find(id);
        //    if (personcontactinfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(personcontactinfo);
        //}

        // GET: /ContactManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ContactManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,FistName,LastName,Email,Status")] PersonContactInfo personcontactinfo)
        {
            if (ModelState.IsValid)
            {
                db.PersonContacts.Add(personcontactinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personcontactinfo);
        }

        // GET: /ContactManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            PersonContactInfo personcontactinfo = db.PersonContacts.Find(id);
            if (personcontactinfo == null)
            {
                return HttpNotFound();
            }
            return View(personcontactinfo);
        }

        // POST: /ContactManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,FistName,LastName,Email,Status")] PersonContactInfo personcontactinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personcontactinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personcontactinfo);
        }

        // GET: /ContactManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonContactInfo personcontactinfo = db.PersonContacts.Find(id);
            if (personcontactinfo == null)
            {
                return HttpNotFound();
            }
            return View(personcontactinfo);
        }

        // POST: /ContactManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonContactInfo personcontactinfo = db.PersonContacts.Find(id);
            db.PersonContacts.Remove(personcontactinfo);
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
