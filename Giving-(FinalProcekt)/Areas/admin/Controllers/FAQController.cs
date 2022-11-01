using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Areas.admin.Controllers
{
    [Area("admin")]
    public class FAQController : Controller
    {
        private readonly AppDbContext _context;

        public FAQController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<FAQ> model = _context.FAQs.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FAQ model)
        {
            if (ModelState.IsValid)
            {
                _context.FAQs.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Update(int id)
        {
            return View(_context.FAQs.Find(id));
        }

        [HttpPost]
        public IActionResult Update(FAQ model)
        {
            if (ModelState.IsValid)
            {
                _context.FAQs.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            FAQ faq = _context.FAQs.Find(id);
            _context.FAQs.Remove(faq);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
