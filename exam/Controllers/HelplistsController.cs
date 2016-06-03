using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using exam.DAL;
using exam.Models;

namespace exam.Controllers
{
    public class HelplistsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Helplists
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToHelplist([Bind(Include = "ID, User, Assignment, Time")] Helplist helplist)
        {
            if (ModelState.IsValid)
            {
                db.Helplist.Add(helplist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(helplist);
        }
       

        // POST: Helplists/Delete/5
        public ActionResult Delete(int id)
        {
            Helplist helplist = db.Helplist.Find(id);
            db.Helplist.Remove(helplist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //ADMIN "Index"
        public ActionResult HelplistPartial()
        {
            List<Helplist> helplists = db.Helplist.ToList();
            return PartialView("_HelplistPartial", helplists);
        }
    }
}
