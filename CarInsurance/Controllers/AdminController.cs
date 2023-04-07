using CarInsurance.Models;
using CarInsurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var insurees = db.Insurees;//.Where(x => x.Removed == null).ToList();
                var insureeVms = new List<InsureeVM>();
                foreach (var insuree in insurees)
                {
                    var insureeVm = new InsureeVM();
                    insureeVm.Id = insuree.Id;
                    insureeVm.FirstName = insuree.FirstName;
                    insureeVm.LastName = insuree.LastName;
                    insureeVm.EmailAddress = insuree.EmailAddress;
                    insureeVm.Quote = insuree.Quote;
                    insureeVms.Add(insureeVm);
                }

                return View(insureeVms);
            }
                
        }

        //public ActionResult Delete(int Id)
        //{
        //    using (InsuranceEntities db = new InsuranceEntities())
        //    {
        //        var insuree = db.Insurees.Find(Id);
        //        insuree.Removed = DateTime.Now;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

    }
}