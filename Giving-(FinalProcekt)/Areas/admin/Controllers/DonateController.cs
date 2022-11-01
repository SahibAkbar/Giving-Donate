using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Areas.admin.Controllers
{
    [Area("admin")]
    public class DonateController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DonateController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_context.Donates.Include(b => b.DonatePrices).ThenInclude(bt => bt.Priceee).ToList());
        }
        //public IActionResult Create()
        //{
        //    ViewBag.Price = _context.Prices.ToList();
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Donate donate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        donate.CreatedDate = DateTime.Now;
        //        _context.Donates.Add(donate);
        //        _context.SaveChanges();

        //        if (donate.PriceID != null && donate.PriceID.Count>0)
        //        {
        //            foreach (var item in donate.PriceID)
        //            {
        //                DonatePrice donatePrice = new ();
        //                donatePrice.PriceId = item;
        //                donatePrice.DonateId = donatePrice.Id;
        //                _context.DonatePrices.Add(donatePrice);
        //            }
        //            _context.SaveChanges();
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Price = _context.Prices.ToList();
        //    return View(donate);
        //}
        //public IActionResult Update(int? id)
        //{
        //    Donate donate = null;

        //    if (id != null)
        //    {
        //        donate = _context.Donates.Include(b => b.DonatePrices).ThenInclude(bt => bt.Priceee).FirstOrDefault(s => s.Id == id);
        //        ViewBag.Price = _context.Prices.ToList();
        //        donate.PriceID = _context.DonatePrices.Where(t => t.DonateId == id).Select(r => r.PriceId).ToList();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Error");
        //    }
        //    return View(donate);
        //}
        //[HttpPost]
        //public IActionResult Update(Donate donate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Entry(donate).State = EntityState.Modified;
        //        _context.Entry(donate).Property("CreatedDate").IsModified = false;

        //        _context.SaveChanges();

        //        List<DonatePrice> donatePrices = _context.DonatePrices.Where(i => i.DonateId == donate.Id).ToList();

        //        if (donate.PriceID.Count > 0)
        //        {
        //            foreach (var item in donatePrices)
        //            {
        //                _context.DonatePrices.Remove(item);
        //            }
        //        }
        //        _context.SaveChanges();

        //        foreach (var item in donate.PriceID)
        //        {
        //            DonatePrice donatePrice = new DonatePrice();
        //            donatePrice.DonateId = item;
        //            donatePrice.PriceId = donatePrice.Id;
        //            _context.DonatePrices.Add(donatePrice);
        //        }
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(donate);
        //}
        public IActionResult Delete(int? id)
        {
            Donate donate = null;

            if (id != null)
            {
                donate = _context.Donates.FirstOrDefault(s => s.Id == id);
            }

            _context.Donates.Remove(donate);
            _context.SaveChanges();
            return RedirectToAction("Index");

            ModelState.AddModelError("", "Event is not found");
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_context.Donates.Find(Id) != null)
                {
                    Donate model = _context.Donates.Include(d=>d.DonatePrices).ThenInclude(dp=>dp.Priceee).FirstOrDefault(e => e.Id == Id);
                    return View(model);

                }
                else
                {
                    TempData["DonateError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["DonateError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }

    }
}
