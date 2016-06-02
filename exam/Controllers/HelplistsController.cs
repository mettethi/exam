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
            // return View(db.Helplist.ToList());
            return View();
        }

        // GET: Helplists/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helplist helplist = db.Helplist.Find(id);
            if (helplist == null)
            {
                return HttpNotFound();
            }
            return View(helplist);
        }

        // GET: Helplists/Create
        public ActionResult Create()
        {
            return View();
        }
        */
        //Add to helplist button: 
        // POST: Helplists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToHelplist([Bind(Include = "ID, User, Assignment")] Helplist helplist)
        {
            if (ModelState.IsValid)
            {
                db.Helplist.Add(helplist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(helplist);
        }
        
        /*

        // GET: Helplists/Edit/5
        /*public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helplist helplist = db.Helplist.Find(id);
            if (helplist == null)
            {
                return HttpNotFound();
            }
            return View(helplist);
        }

        // POST: Helplists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Helped")] Helplist helplist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helplist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(helplist);
        }

        // GET: Helplists/Delete/5
        //ADMIN
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helplist helplist = db.Helplist.Find(id);
            if (helplist == null)
            {
                return HttpNotFound();
            }
            return View(helplist);
        }*/

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

        /*public ActionResult CreateHelplistPartial()
        {
            return PartialView("_CreateHelplistPartial");
        }*/
    }
}
