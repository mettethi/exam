using exam.DAL;
using exam.Models;
using exam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exam.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            List<Helplist> helplists = db.Helplist.ToList();
            List<Assignment> assignments = db.Assignments.ToList();

            User user = db.Users.Where(i => i.Email == email && i.Password == password).FirstOrDefault();
            if (user == null)
            {
                ViewBag.message = "Wrong email or password";
                return View();
            }
            else
            {
                if (user.UserType == UserType.Teacher)
                {
                    return View("_HelplistPartial", helplists);
                }
                else if (user.UserType == UserType.Student)
                {
                    Session["student"] = user;
                    User foundUser = (User)Session["student"];

                    var studentViewModel = new StudentViewModel();

                    studentViewModel.User = foundUser;
                    studentViewModel.Assignments = assignments;

                    return View("_StudentAssignmentView", studentViewModel);

                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Delete", "Helplists", id);
        }
    }
}