using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessStore.Data;
using FitnessStore.Models;
using System.Net;
using System.Net.Mail;

namespace FitnessStore.Controllers
{
    
    public class ContactsController : Controller
    {
        private readonly FitnessStoreContext _context;

        public ContactsController(FitnessStoreContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        [ValidateAntiForgeryToken]
        public void SendEmail(string Email, string Name)
        {
            
            var fromAddress = new MailAddress("fitnesshubstoretlv@gmail.com");
            var toAddress = new MailAddress(Email);
            const string fromPassword = "1qaz!QAZ2wsx@WSX";
            const string subject = "Hello from fitnessHubStoreTLV";
            const string body = "Thank you for contacting fitnessHubStoreTLV support";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("fitnesshubstoretlv@gmail.com", fromPassword),
                Timeout = 20000
            };
            
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            
                smtp.Send(message);
            
        }

        // GET: Contacts/Create
        public IActionResult Contact()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<bool> Contact([Bind("Id,Name,Email,Subject,Body")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                SendEmail(contact.Email, contact.Name);
                //return redirecttoaction(nameof(index));
                return true;
            }
            return false;
            //return View(contact);
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
            
        }
    }
}
