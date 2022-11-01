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
    public class AboutOptionController : Controller
    {
        private readonly AppDbContext _context;

        public AboutOptionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<AboutOption > model = _context.AboutOptions.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AboutOption model)
        {
            if (ModelState.IsValid)
            {
                if (model.Icon != null && model.Title !=null && model.Subtitle != null)
                {
                    _context.AboutOptions.Add(model);
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
            return View(_context.AboutOptions.Find(id));
        }

        [HttpPost]
        public IActionResult Update(AboutOption model)
        {
            if (ModelState.IsValid)
            {
                if (model.Icon != null && model.Title != null && model.Subtitle != null)
                {
                    _context.AboutOptions.Update(model);
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
            AboutOption social = _context.AboutOptions.Find(id);
            _context.AboutOptions.Remove(social);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
