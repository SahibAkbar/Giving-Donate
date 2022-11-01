using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Controllers
{
    public class FAQController : Controller
    {
        private readonly AppDbContext _context;

        public FAQController(AppDbContext context)
        {
            _context = context;
        }

        //FAQ sectiosn

        public IActionResult Index()
        {
            VmFAQ model = new VmFAQ();

            model.Setting = _context.Settings.FirstOrDefault();
            //model.Subscribe = _context.Subscribes.FirstOrDefault();
            model.HappyFaces = _context.HappyFaces.ToList();
            model.Socials = _context.Socials.ToList();
            model.Banner = _context.Banners.FirstOrDefault();
            model.FAQ = _context.FAQs.ToList();

            return View(model);
        }
    }
}
