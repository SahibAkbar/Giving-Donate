using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Subscribes.ToList());
        }

        public IActionResult Delete(int id)
        {
            Subscribe subscribe = _context.Subscribes.Find(id);
            _context.Subscribes.Remove(subscribe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SendMailAll()
        {
            return View(_context.Subscribes.ToList());
        }

        [HttpPost]
        public IActionResult SendMailAll(string MailText)
        {
            List<Subscribe> subscribes = _context.Subscribes.ToList();

            foreach (var item in subscribes)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("codegroupsp@gmail.com", "Giving");
                message.To.Add(item.Email);
                message.Body = MailText;
                message.IsBodyHtml = true;
                message.Subject = "Reklam";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("codegroupsp@gmail.com", "codegroupsp2021");
                smtpClient.Send(message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(string MailText, int? id)
        {
            Subscribe subscribe = _context.Subscribes.FirstOrDefault(p => p.Id == id);
            MailMessage message = new MailMessage();
            message.From = new MailAddress("codegroupsp@gmail.com", "Giving");
            message.To.Add(subscribe.Email);
            message.Body = MailText;
            message.IsBodyHtml = true;
            message.Subject = "Communication";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("codegroupsp@gmail.com", "codegroupsp2021");
            smtpClient.Send(message);

            return RedirectToAction("Index");
        }
    }
}
