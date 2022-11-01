using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Areas.admin.Controllers
{
    [Area("Admin")]
    public class PriceController : Controller
    {
        private readonly AppDbContext _context;

        public PriceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Price> model = _context.Prices.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Price model)
        {
            if (ModelState.IsValid)
            {
                _context.Prices.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Update(int id)
        {
            return View(_context.Prices.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Price model)
        {
            if (ModelState.IsValid)
            {
                _context.Prices.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Price price = _context.Prices.Find(id);
            _context.Prices.Remove(price);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
