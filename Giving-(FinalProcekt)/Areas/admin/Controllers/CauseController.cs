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
    public class CauseController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CauseController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Cause> causes = _appDbContext.Causes.ToList();
            return View(causes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cause model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.Title != null && model.Content != null && model.CauseNeed != 0)
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
                            model.CreatedDate = DateTime.Now;
                            _appDbContext.Causes.Add(model);
                            _appDbContext.SaveChanges();
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
            return View(_appDbContext.Causes.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Cause model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.Title != null && model.Content != null && model.CauseNeed != 0)
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
                            _appDbContext.Causes.Update(model);
                            _appDbContext.SaveChanges();
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
            Cause cause = _appDbContext.Causes.Find(id);
            _appDbContext.Causes.Remove(cause);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_appDbContext.Causes.Find(Id) != null)
                {

                    Cause cause = _appDbContext.Causes.Include(cg => cg.CauseGalleries).FirstOrDefault(c => c.Id ==Id );

                    // Include(mr => mr.MenuToRestourants)
                    //.ThenInclude(m => m.Menu)
                    //.Include(r => r.RestourantTagToRestourants).ThenInclude(rt => rt.RestourantTag)
                    //.Include(rf => rf.RestourantFeatureToRestourants).ThenInclude(f => f.RestourantFeature)
                    //.Include(rc => rc.RestourantComments).ThenInclude(cp => cp.CommentPost)
                    //.Include(r => r.Reservations).ThenInclude(g => g.Guest).FirstOrDefault(r => r.Id == Id);
                    return View(cause);
                }
                else
                {
                    TempData["CauseError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["CauseError"] = "Id must not be null";
                return RedirectToAction("Index");
            }

        }
    }
}
