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
    public class EventController : Controller

    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        //event sections 


        public IActionResult Index(int? tagId)
        {
            VmEvent model = new VmEvent();
            model.Setting = _context.Settings.FirstOrDefault();
            //model.Subscribe = _context.Subscribes.FirstOrDefault();
            model.HappyFaces = _context.HappyFaces.ToList();
            model.Socials = _context.Socials.ToList();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Event = _context.Events.FirstOrDefault();

            ViewBag.tags = _context.TagEvents.ToList();
            if (tagId!=null)
            {
                List<TagToEvent> evnts = _context.TagToEvents.Include(w => w.Event).Include(w => w.TagEvent).ToList();

                model.Events = evnts.Where(t => t.TagEvent.Id == tagId).Select(w => w.Event).ToList();
            }
            else
            {
                model.Events = _context.Events
                                           .Include(tt => tt.TagToEvents).ThenInclude(t => t.TagEvent)
                                           .ToList();
            }
            

            return View(model);
        }

        //Events details sections

        public IActionResult Detail(int? id)
        {
            Event event1 = null;
            Setting setting = _context.Settings.FirstOrDefault();
            Banner banner = _context.Banners.FirstOrDefault();
            Subscribe subscribe = _context.Subscribes.FirstOrDefault();
            List<HappyFaces> happyFaces = _context.HappyFaces.ToList();
            List<Social> socials = _context.Socials.ToList();
            Event relEvent = _context.Events.OrderByDescending(e => e.CreatedDate).Take(1).FirstOrDefault();
            List<Event> pastEvents = _context.Events.OrderBy(e => e.CreatedDate).Take(3).ToList();
            //List<Comment> comments = _context.Comments.OrderByDescending(bc => bc.cr).Where(i => i.BlogId == id).ToList();
            ViewBag.tags = _context.TagEvents.ToList();
            if (id != null)
            {
                event1 = _context.Events.Find(id);
            }
            VmEvent vmEvent = new VmEvent()
            {
                Socials = socials,
                Setting = setting,
                Event = event1,
                Relevent = relEvent,
                PastEvents = pastEvents,
                Banner = banner,
                Subscribe = subscribe,
                HappyFaces = happyFaces,
            };
            return View(vmEvent);
        }
    }
}
