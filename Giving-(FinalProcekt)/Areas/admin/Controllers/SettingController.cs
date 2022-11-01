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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            Setting model = _context.Settings.FirstOrDefault();
            return View(model);
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Setting model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model.LogoFile.ContentType == "image/jpeg" || model.LogoFile.ContentType == "image/png")
        //        {
        //            if (model.LogoFile.Length <= 2000000)
        //            {
        //                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.LogoFile.FileName;
        //                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    model.LogoFile.CopyTo(stream);
        //                }
        //                model.Logo = fileName;
        //                _context.Settings.Add(model);
        //                _context.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                return View(model);

        //            }
        //        }
        //        else
        //        {
        //            return View(model);
        //        }
        //    }

        //    return View(model);

        //}
        public IActionResult Update(int id)
        {
            return View(_context.Settings.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Setting model)
        {
            if (ModelState.IsValid)
            {
                if (model.LogoFile != null && model.Email != null && model.Adress != null && model.Phone != null && model.IframeLink != null)
                {
                    if (model.LogoFile.ContentType == "image/jpeg" || model.LogoFile.ContentType == "image/png")
                    {
                        if (model.LogoFile.Length <= 2000000)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.LogoFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.LogoFile.CopyTo(stream);
                            }
                            model.Logo = fileName;
                            _context.Settings.Update(model);
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
        //public IActionResult Delete(int id)
        //{
        //    Setting setting = _context.Settings.Find(id);
        //    _context.Settings.Remove(setting);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
