using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPMail.Models;
using ASPMail.Service;
using ASPMail.Repository;

namespace ASPMail.Controllers
{
    public class ContactFormController : Controller
    {
        private EmailService _emailService;
        private ContactFormRepository _contactFormRepository;

        public ContactFormController()
        {
            _emailService = new EmailService();
            _contactFormRepository = new ContactFormRepository();
        }               

        // GET: ContactForm
        public ActionResult Index()
        {
            return View(_contactFormRepository.GetWhere(x => x.Id > 0));
        }

        // GET: ContactForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = _contactFormRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
                _contactFormRepository.Create(contactForm);                
                var message = _emailService.CreateMailMessage(contactForm);
                _emailService.SendEmail(message);
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
            ContactForm contactForm = _contactFormRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
            ContactForm contactForm = _contactFormRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _contactFormRepository.Delete(contactForm);
            return RedirectToAction("Index");
        }

       
    }
}
