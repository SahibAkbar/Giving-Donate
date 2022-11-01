using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Areas.admin.Controllers
{
    [Area("admin")]
    public class SocialController : Controller
    {
        private readonly AppDbContext _context;

        public SocialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Social> model = _context.Socials.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Social model)
        {
            if (ModelState.IsValid)
            {
                if (model.Icon != null && model.Link != null)
                {
                    _context.Socials.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Erroor"] = "Please fill in the blanks";
                }
            }
            else
            {
                TempData["Erroor"] = "Please fill in the blanks";
            }

            return View(model);

        }
        public IActionResult Update(int id)
        {
            return View(_context.Socials.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Social model)
        {
            if (ModelState.IsValid)
            {
                if (model.Icon != null && model.Link != null)
                {
                    _context.Socials.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Erroor"] = "Please fill in the blanks";
                }
            }
            else
            {
                TempData["Erroor"] = "Please fill in the blanks";
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Social social = _context.Socials.Find(id);
            _context.Socials.Remove(social);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
