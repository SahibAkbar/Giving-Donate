using Giving__FinalProcekt_.Data;
using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Hosting;
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
    public class VolunteerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VolunteerController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Volunteer> model = _context.Volunteers.ToList();
            return View(model);
        }
        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_context.Volunteers.Find(Id) != null)
                {
                    Volunteer model = _context.Volunteers.FirstOrDefault(p => p.Id == Id);
                    return View(model);

                }
                else
                {
                    TempData["BlogError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["BlogError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Volunteer model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Description != null && model.ImageFile != null && model.Position != null && model.Experience != null && model.DonaterTitle != null && model.DonaterCount != null && model.VoluteerTitle != null && model.VoluteerCount != null)
                { 
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 2000000)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;
                            _context.Volunteers.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View(model);

                        }
                    }
                    else
                    {
                        return View(model);
                    }
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
            return View(_context.Volunteers.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Volunteer model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Description != null && model.ImageFile != null && model.Position != null && model.Experience != null && model.DonaterTitle != null && model.DonaterCount != null && model.VoluteerTitle != null && model.VoluteerCount != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 2000000)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;
                            _context.Volunteers.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View(model);

                        }
                    }
                    else
                    {
                        return View(model);
                    }
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
            Volunteer volunteer = _context.Volunteers.Find(id);
            _context.Volunteers.Remove(volunteer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
