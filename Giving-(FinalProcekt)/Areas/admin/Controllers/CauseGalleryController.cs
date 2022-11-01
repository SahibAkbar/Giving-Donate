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
    public class CauseGalleryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CauseGalleryController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<CauseGallery> causeGalleries = _appDbContext.CauseGalleries.Include(c => c.Cause).ToList();
            return View(causeGalleries);
        }
        public IActionResult Create()
        {
            ViewBag.Cause = _appDbContext.Causes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CauseGallery model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && _appDbContext.Causes.Find(model.CauseId) != null)
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
                            _appDbContext.CauseGalleries.Add(model);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Cause = _appDbContext.Causes.ToList();
                            return View(model);

                        }
                    }
                    else
                    {
                        ViewBag.Cause = _appDbContext.Causes.ToList();
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Cause = _appDbContext.Causes.ToList();
                    TempData["Erroor"] = "Please fill in the blanks";
                }
            }
            else
            {
                ViewBag.Cause = _appDbContext.Causes.ToList();
                TempData["Erroor"] = "Please fill in the blanks";
            }

            return View(model);

        }
        public IActionResult Update(int id)
        {
            ViewBag.Cause = _appDbContext.Causes.ToList();
            return View(_appDbContext.CauseGalleries.Find(id));
        }

        [HttpPost]
        public IActionResult Update(CauseGallery model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && _appDbContext.Causes.Find(model.CauseId) != null)
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
                            _appDbContext.CauseGalleries.Update(model);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Cause = _appDbContext.Causes.ToList();
                            return View(model);

                        }
                    }
                    else
                    {
                        ViewBag.Cause = _appDbContext.Causes.ToList();
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Cause = _appDbContext.Causes.ToList();
                    TempData["Erroor"] = "Please fill in the blanks";
                }
            }
            else
            {
                ViewBag.Cause = _appDbContext.Causes.ToList();
                TempData["Erroor"] = "Please fill in the blanks";
            }


            return View(model);
        }
        public IActionResult Delete(int id)
        {
            CauseGallery causeGallery = _appDbContext.CauseGalleries.Find(id);
            _appDbContext.CauseGalleries.Remove(causeGallery);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
