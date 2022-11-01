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
    public class DonateController : Controller
    {
        private readonly AppDbContext _context;

        public DonateController(AppDbContext context)
        {
            _context = context;
        }
        //Donate sections

        [HttpPost]
        public IActionResult Index(VmDonate vmDonate)
        {
            if (ModelState.IsValid)
            {
                Cause cause2 = _context.Causes.Find(vmDonate.CauseId);

                var a2 = _context.Prices.Find(vmDonate.PriceId).Money;
                //cause2.CreatedDate = DateTime.Now;
                vmDonate.Donate.CreatedDate = DateTime.Now;

                if (cause2.CauseNeed-a2>0||cause2.CauseNeed-a2==0)
                {
                    Donate donate = new();
                    donate.FName = vmDonate.Donate.FName;
                    donate.LName = vmDonate.Donate.LName;
                    donate.Address = vmDonate.Donate.Address;
                    donate.Phone = vmDonate.Donate.Phone;
                    donate.Not = vmDonate.Donate.Not;
                    donate.Email = vmDonate.Donate.Email;
                    donate.CreatedDate = vmDonate.Donate.CreatedDate;


                    _context.Donates.Add(donate);
                    _context.SaveChanges();


                    DonatePrice donatePrice = new();
                    donatePrice.CauseId = vmDonate.CauseId;
                    donatePrice.PriceId = vmDonate.PriceId;
                    donatePrice.DonateId = donate.Id;

                    _context.DonatePrices.Add(donatePrice);
                    _context.SaveChanges();

                    Cause cause = _context.Causes.Find(vmDonate.CauseId);

                    var a = _context.Prices.Find(vmDonate.PriceId).Money;

                    cause.CauseNeed -= a;

                    _context.Causes.Update(cause);
                    _context.SaveChanges();

                    TempData["DonateSuccess"] = "You Donate Successfully!";

                    return RedirectToAction("Detail", "Causes", new { Id = vmDonate.CauseId });
                }
                else
                {
                    TempData["DonateSuccess"] = "Uje dolufdu!";

                    return RedirectToAction("Detail", "Causes", new { Id = vmDonate.CauseId });
                }

                
            }
            return RedirectToAction();
        }


    }
}
