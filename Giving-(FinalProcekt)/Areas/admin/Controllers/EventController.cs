using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Areas.admin.Controllers
{
    [Area("admin")]
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Events.Include(b => b.TagToEvents).ThenInclude(bt => bt.TagEvent).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.TagEvent = _appDbContext.TagEvents.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event event1)
        {
            if (ModelState.IsValid)
            {
                if (event1.ImageFile != null)
                {
                    if (event1.ImageFile.ContentType == "image/png" || event1.ImageFile.ContentType == "image/jpeg")
                    {
                        if (event1.ImageFile.Length <= 2097152)
                        {

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + event1.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                event1.ImageFile.CopyTo(fs);
                            }
                            event1.Image = filename;
                            event1.CreatedDate = DateTime.Now;

                            _appDbContext.Events.Add(event1);
                            _appDbContext.SaveChanges();

                            foreach (var item in event1.TagEventId)
                            {
                                TagToEvent eventToTag = new TagToEvent();
                                eventToTag.TagEventId = item;
                                eventToTag.EventId = event1.Id;
                                _appDbContext.TagToEvents.Add(eventToTag);
                            }
                            _appDbContext.SaveChanges();

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.TagEvents = _appDbContext.TagEvents.ToList();
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(event1);
                        }
                    }
                    else
                    {
                        ViewBag.TagEvents = _appDbContext.TagEvents.ToList();
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(event1);
                    }
                }
                else
                {
                    _appDbContext.Events.Add(event1);
                    _appDbContext.SaveChanges();

                    foreach (var item in event1.TagEventId)
                    {
                        TagToEvent blogToTag = new TagToEvent();
                        blogToTag.TagEventId = item;
                        blogToTag.EventId = event1.Id;
                        _appDbContext.TagToEvents.Add(blogToTag);
                    }
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            ViewBag.TagEvents = _appDbContext.TagEvents.ToList();

            return View(event1);
        }
        public IActionResult Update(int? id)
        {
            Event event1 = null;

            if (id != null)
            {
                event1 = _appDbContext.Events.Include(b => b.TagToEvents).ThenInclude(bt => bt.TagEvent).FirstOrDefault(s => s.Id == id);
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", event1.Image);
                if (System.IO.File.Exists(path))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(path);

                    MemoryStream stream = new MemoryStream(bytes);

                    IFormFile file = new FormFile(stream, 0, bytes.Length, "image", "image.png");

                    event1.ImageFile = file;

                    using (var str = new MemoryStream())
                    {
                        event1.ImageFile.CopyTo(str);
                        var filebytes = str.ToArray();
                        event1.Base64 = Convert.ToBase64String(filebytes);
                    }
                }
                ViewBag.TagEvent = _appDbContext.TagEvents.ToList();
                event1.TagEventId = _appDbContext.TagToEvents.Where(te => te.EventId == id).Select(e => e.TagEventId).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }
            return View(event1);
        }
        [HttpPost]
        public IActionResult Update(Event event1)
        {
            if (ModelState.IsValid)
            {
                if (event1.ImageFile != null)
                {
                    if (event1.ImageFile.ContentType == "image/png" || event1.ImageFile.ContentType == "image/jpeg")
                    {
                        if (event1.ImageFile.Length <= 2097152)
                        {
                            string oldPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", event1.Image);

                            if (System.IO.File.Exists(oldPathData))
                            {
                                System.IO.File.Delete(oldPathData);
                            }

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + event1.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                event1.ImageFile.CopyTo(fs);

                            }
                            event1.Image = filename;

                            _appDbContext.Entry(event1).State = EntityState.Modified;
                            _appDbContext.Entry(event1).Property("CreatedDate").IsModified = false;

                            _appDbContext.SaveChanges();

                            List<TagToEvent> tagToEvents = _appDbContext.TagToEvents.Where(i => i.EventId == event1.Id).ToList();

                            if (event1.TagEventId.Count > 0)
                            {
                                foreach (var item in tagToEvents)
                                {
                                    _appDbContext.TagToEvents.Remove(item);
                                }
                            }
                            _appDbContext.SaveChanges();
                            
                            foreach (var item in event1.TagEventId)
                            {
                                TagToEvent tagToEvent = new TagToEvent();
                                tagToEvent.EventId = event1.Id;
                                tagToEvent.TagEventId = item;
                                _appDbContext.TagToEvents.Add(tagToEvent);
                            }
                            
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(event1);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(event1);
                    }
                }
                else
                {
                    _appDbContext.Entry(event1).State = EntityState.Modified;
                    _appDbContext.Entry(event1).Property("CreatedDate").IsModified = false;
                    _appDbContext.SaveChanges();

                    List<TagToEvent> tagToEvents = _appDbContext.TagToEvents.Where(i => i.EventId == event1.Id).ToList();

                    foreach (var item in tagToEvents)
                    {
                        _appDbContext.TagToEvents.Remove(item);
                    }
                    _appDbContext.SaveChanges();

                    foreach (var item in event1.TagEventId)
                    {
                        TagToEvent tagToEvent = new TagToEvent();
                        tagToEvent.TagEventId = item;
                        tagToEvent.EventId = event1.Id;
                        _appDbContext.TagToEvents.Add(tagToEvent);
                    }

                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            }

            return View(event1);
        }
        public IActionResult Delete(int? id)
        {
            Event event1 = null;

            if (id != null)
            {
                event1 = _appDbContext.Events.FirstOrDefault(s => s.Id == id);
            }

            if (event1 != null)
            {
                if (!string.IsNullOrEmpty(event1.Image))
                {
                    string oldPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", event1.Image);

                    if (System.IO.File.Exists(oldPathFile))
                    {
                        System.IO.File.Delete(oldPathFile);
                    }
                    _appDbContext.Events.Remove(event1);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    _appDbContext.Events.Remove(event1);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Event is not found");
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_appDbContext.Events.Find(Id) != null)
                {
                    Event model = _appDbContext.Events.FirstOrDefault(e => e.Id == Id);
                    return View(model);

                }
                else
                {
                    TempData["EventError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["EventError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }

    }
}
