using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Giving__FinalProcekt_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        //Home sections
        
        public IActionResult Index()
        {

            VmHome model = new VmHome();
            model.Setting = _context.Settings.FirstOrDefault();
            //model.Subscribe = _context.Subscribes.FirstOrDefault();
            model.HappyFaces = _context.HappyFaces.ToList();
            model.Socials = _context.Socials.ToList();
            model.HomeSliders = _context.HomeSliders.ToList();
            model.About = _context.Abouts.FirstOrDefault();
            model.Cause = _context.Causes.
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Cause).
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Donateee).
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Priceee).FirstOrDefault();

            model.Causes = _context.Causes.OrderByDescending(e => e.CreatedDate).Take(5).ToList();
            model.Volunteers = _context.Volunteers.OrderByDescending(e => e.Name).Take(3).ToList();

            return View(model);
        }

        //Sucsribe send mails sections

        [HttpPost]
        public IActionResult SendMessage(VmHome model)
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
            return View("Index");
        }



        //public IActionResult Subscribe(string email)
        //{
        //    VmSubscribe response = new VmSubscribe();

        //    if (!string.IsNullOrEmpty(email))
        //    {
        //        if (_context.Subscribes.Any(s => s.Email == email))
        //        {
        //            response.Status1 = false;
        //            return Json(response);
        //        }
        //        else
        //        {
        //            response.Status1 = true;
        //            Subscribe subscribe = new();
        //            subscribe.CreatedDate = DateTime.Now;
        //            subscribe.Email = email;

        //            _context.Subscribes.Add(subscribe);
        //            _context.SaveChanges();

        //            return Json(response);

        //        }
        //    }
        //    else
        //    {
        //        response.Status2 = true;
        //        return Json(response);
        //    }
        //}


        //Subscribe sections

        public IActionResult Subscribe(string email)
        {
            VmSubscribe response = new VmSubscribe();

            if (string.IsNullOrEmpty(email))
            {
                response.Status = false;
                response.Message = "Subscribtion failed! You must enter your email";
                return Json(response);
            }

            bool isExist = _context.Subscribes.Any(s => s.Email == email);

            if (isExist)
            {
                response.Status = false;
                response.Message = "Your email have already subscribed!";
                return Json(response);
            }

            Subscribe subscribe = new Subscribe();
            subscribe.CreatedDate = DateTime.Now;
            subscribe.Email = email;
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();

            response.Status = true;
            response.Message = "Your subscribe successfully!";
            return Json(response);
        }
    }
}
