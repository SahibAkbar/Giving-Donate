using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Areas.admin.Controllers
{
    [Area("admin")]
    public class MessageController : Controller
    {
        private readonly AppDbContext _context;

        public MessageController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Contacts.OrderByDescending(m=>m.CreatedDate).ToList());
        }
        public IActionResult Read(int? Id)
        {
            if (Id != null)
            {
                if (_context.Contacts.Find(Id) != null)
                {
                    return View(_context.Contacts.Find(Id));
                }
                else
                {
                    TempData["MessageError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }

            }
            else
            {
                TempData["MessageError"] = "Id must not be null";
                return RedirectToAction("Index");
            }



        }
        public IActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                if (_context.Contacts.Find(Id) != null)
                {
                    _context.Contacts.Remove(_context.Contacts.Find(Id));
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }

            }
            else
            {
                TempData["MessageError"] = "Id must not be null";
                return RedirectToAction("Index");
            }

        }
        //public IActionResult SendMailAll()
        //{
        //    return View(_context.Contacts.ToList());
        //}
        //[HttpPost]
        //public IActionResult SendMailAll(string MailText)
        //{
        //    List<Contact> contacts = _context.Contacts.ToList();
        //    foreach (var item in contacts)
        //    {
        //        MailMessage message = new MailMessage();
        //        message.From = new MailAddress("codegroupsp@gmail.com", "Code Academy P222");
        //        message.To.Add(item.Email);
        //        message.Body = MailText;
        //        message.IsBodyHtml = true;
        //        message.Subject = "Reklam";

        //        SmtpClient smtpClient = new SmtpClient();
        //        smtpClient.Host = "smtp.gmail.com";
        //        smtpClient.EnableSsl = true;
        //        smtpClient.Port = 587;
        //        smtpClient.Credentials = new NetworkCredential("codegroupsp@gmail.com", "codegroupsp2021");
        //        smtpClient.Send(message);
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
