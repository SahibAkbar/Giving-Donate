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
    public class HomeSliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeSliderController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<HomeSlider> model = _context.HomeSliders.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeSlider model)
        {
            if (ModelState.IsValid)
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
                        _context.HomeSliders.Add(model);
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

            return View(model);

        }
        public IActionResult Update(int id)
        {
            return View(_context.HomeSliders.Find(id));
        }

        [HttpPost]
        public IActionResult Update(HomeSlider model)
        {
            if (model.ImageFile != null)
            {
                if (ModelState.IsValid)
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
                            _context.HomeSliders.Update(model);
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
            }
            else
            {
                return RedirectToAction("Update");
            }


            return View(model);
        }
        public IActionResult Delete(int id)
        {
            HomeSlider homeSlider = _context.HomeSliders.Find(id);
            _context.HomeSliders.Remove(homeSlider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
