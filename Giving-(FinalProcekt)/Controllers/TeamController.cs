using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Giving__FinalProcekt_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }


        //Teams sections
        public IActionResult Index()
        {
            VmVolunteer model = new VmVolunteer();
            model.Setting = _context.Settings.FirstOrDefault();
            //model.Subscribe = _context.Subscribes.FirstOrDefault();
            model.HappyFaces = _context.HappyFaces.ToList();
            model.Socials = _context.Socials.ToList();
            model.Banner = _context.Banners.FirstOrDefault();

            model.Volunteer = _context.Volunteers.FirstOrDefault();
            model.Volunteers = _context.Volunteers.ToList();

            return View(model);
        }

        //Temas sections details
        public IActionResult Detail(int? id)
        {
            Volunteer volunteer = null;
            Setting setting = _context.Settings.FirstOrDefault();
            Banner banner = _context.Banners.FirstOrDefault();
            Subscribe subscribe = _context.Subscribes.FirstOrDefault();
            List<HappyFaces> happyFaces = _context.HappyFaces.ToList();
            List<Social> socials = _context.Socials.ToList();
            //List<Comment> comments = _context.Comments.OrderByDescending(bc => bc.cr).Where(i => i.BlogId == id).ToList();
            if (id != null)
            {
                volunteer = _context.Volunteers.Find(id);
            }
            VmVolunteer vmVolunteer = new VmVolunteer()
            {
                Socials = socials,
                Setting = setting,
                Volunteer = volunteer,
                Banner = banner,
                Subscribe = subscribe,
                HappyFaces = happyFaces,
            };
            return View(vmVolunteer);
        }
    }
}
