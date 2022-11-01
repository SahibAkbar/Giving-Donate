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
    public class CausesController : Controller
    {
        private readonly AppDbContext _context;

        public CausesController(AppDbContext context)
        {
            _context = context;
        }

        //Causes section

        public IActionResult Index()
        {
            VmCauses model = new VmCauses();
            model.Setting = _context.Settings.FirstOrDefault();
            //model.Subscribe = _context.Subscribes.FirstOrDefault();
            model.HappyFaces = _context.HappyFaces.ToList();
            model.Socials = _context.Socials.ToList();
            model.Banner = _context.Banners.FirstOrDefault();

            model.Cause = _context.Causes.FirstOrDefault();
            model.Causes = _context.Causes.
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Cause).
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Donateee).
                                            Include(p => p.DonatePrices).
                                            ThenInclude(p => p.Priceee).ToList();



            model.CauseGalleri = _context.CauseGalleries.FirstOrDefault();
            model.CauseGalleries = _context.CauseGalleries.ToList();
            model.Comment = _context.Comments.FirstOrDefault();
            model.Comments = _context.Comments.ToList();
            ViewBag.AllCount = _context.Causes.ToList().Count;

            return View(model);
        }
        //CausesController Detail Sections
    
        public IActionResult Detail(int? id,VmSearch search)
        {

            if (id != null)
            {
                VmCauses model = new();
                if (model != null)
                {
                    ViewBag.PrizeId = _context.Prices.ToList();
                    var w = _context.DonatePrices.Include(d => d.Priceee).Where(c => c.CauseId == id).ToList();
                    var a = 0;
                    foreach (var item in w)
                    {
                        a += item.Priceee.Money;
                    }

                    ViewBag.total = a;

                    model.Banner = _context.Banners.FirstOrDefault();
                    model.HappyFaces = _context.HappyFaces.ToList();
                    model.CauseGalleries = _context.CauseGalleries.ToList();
                    model.Socials = _context.Socials.ToList();
                    model.Setting = _context.Settings.FirstOrDefault();
                    model.Subscribe = _context.Subscribes.FirstOrDefault();
                    model.Cause = _context.Causes
                                             .Include(c => c.Comments)
                                             .ThenInclude(cp => cp.CommentPost)
                                             .FirstOrDefault(p => p.Id == id);

                 

                    ViewBag.PageCount = _context.Causes.ToList().Count;
                    return View(model);

                }
                else
                {
                    TempData["Erroor"] = "Please fill in the blanks";
                }

                return RedirectToAction("Index");

            }
            else
            {
                TempData["Erroor"] = "Please fill in the blanks";
            }
            return RedirectToAction("Index");
        }


        //CausesController Comment Section

        [HttpPost]
        public IActionResult PostComment(CommentPost1 commentPost)
        {
            if (ModelState.IsValid)
            {
                _context.CommentPosts.Add(commentPost);
                _context.SaveChanges();

                Comment1 comment = new();
                comment.CauseId = commentPost.CauseId;
                comment.CommentPostId = commentPost.Id;
                comment.CreatedDate = DateTime.Now;
                comment.Content = commentPost.Content;

                if (commentPost.CommentId > 0)
                {
                    comment.ParentCommentId = commentPost.CommentId;
                }

                _context.Comments.Add(comment);
                _context.SaveChanges();


            }
            else
            {
                TempData["Erroor"] = "Please fill in the blanks";
            }

            return RedirectToAction("Detail", new { Id = commentPost.CauseId });

        }
    }
}
