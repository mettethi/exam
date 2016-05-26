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
    public class TeachersController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Teachers
        public ActionResult Index()
        {
            return View();

            //return View(db.Users.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            User user = db.Users.Find(id); 
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if(user.UserType == 0)
                {
                    user.UserType = UserType.Teacher;
                }
                else if(user.UserType == 1)
                {
                    user.UserType = UserType.Student;
                }

                //user.UserType = UserType.Teacher;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index"); //redirect tilbage til index
            }

            return View(user); 
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                user.UserType = UserType.Teacher;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //HVORDAN HÅNDTERE VI DELETE?

        // GET: Teachers/Delete/5    
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = (User)db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user); // REDIRECT TIL INDEX
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        public ActionResult studentPartial()
        {
            List<User> users = db.Users.ToList();
            return PartialView("_StudentPartial", users);
        }

        public ActionResult createStudentPartial()
        {
            return PartialView("_CreateStudentPartial");
        }
    }
}
