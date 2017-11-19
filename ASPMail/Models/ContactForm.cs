using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMail.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}