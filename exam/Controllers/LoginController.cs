using exam.DAL;
using exam.Models;
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
                    return View("_CreateAssignmentPartial");
                }
                /*else if (user.UserType == UserType.Student)
                {
                    return View student 
                }*/
            }

            return View();

        }
    }
}