using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPMail.Models;

namespace ASPMail.Controllers
{
    public class ContactFormController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactForm
        public ActionResult Index()
        {
            return View(db.ContactForms.ToList());
        }

        // GET: ContactForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // GET: ContactForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                db.ContactForms.Add(contactForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactForm);
        }

       

        

        // GET: ContactForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = db.ContactForms.Find(id);
            db.ContactForms.Remove(contactForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
