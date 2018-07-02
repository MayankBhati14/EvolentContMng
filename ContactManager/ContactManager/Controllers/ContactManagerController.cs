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
