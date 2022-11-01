using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        //Contact sections
        public IActionResult Index()
        {
            VmContact model = new VmContact();
            {
                model.Setting = _context.Settings.FirstOrDefault();
                //model.Subscribe = _context.Subscribes.FirstOrDefault();
                model.HappyFaces = _context.HappyFaces.ToList();
                model.Socials = _context.Socials.ToList();
                model.Banner = _context.Banners.FirstOrDefault();

                return View(model);
            }

        }

        //Contact message sections

        [HttpPost]
        public IActionResult SendMessage(VmContact model)
        {
            if (ModelState.IsValid)
            {
                model.Contact.CreatedDate = DateTime.Now;
                _context.Contacts.Add(model.Contact);
                //HttpContext.Session.SetString("Success", "Your message has been sent successfully!");
                TempData["MessageSuccess"] = "Your message has been sent successfully";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MessageError"] = "Please fill out all of the required fields correctly";
            }
            return RedirectToAction("Index");
        }
    }
}
