using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Giving__FinalProcekt_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Giving__FinalProcekt_.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        //About Section
        public IActionResult Index()
        {

            VmAbout model = new VmAbout();
            model.Setting = _context.Settings.FirstOrDefault();
            model.HappyFaces = _context.HappyFaces.ToList();
            model.Socials = _context.Socials.ToList();

            model.Banner = _context.Banners.FirstOrDefault();
            model.Partners = _context.Partners.ToList();
            model.Cause = _context.Causes.
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Cause).
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Donateee).
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Priceee).FirstOrDefault();

            model.About = _context.Abouts.FirstOrDefault();
            model.AboutOptions = _context.AboutOptions.ToList();

            //ViewBag.PrizeId = _context.Prices.FirstOrDefault(p=>p.Id == model.Cause.Id);
            //var w = _context.DonatePrices.Include(d => d.Priceee).Where(c => c.CauseId == model.Cause.Id);
            //var a = 0;
            //foreach (var item in w)
            //{
            //    a += item.Priceee.Money;
            //}

            //ViewBag.total = a;

            return View(model);
        }
    }
}
