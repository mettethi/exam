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
    public class StatisticController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Statistic
        public ActionResult Index()
        {
            var statisticViewModel = new StatisticViewModel();
            List<Assignment> assignments = db.Assignments.ToList();

            statisticViewModel.Assignments = assignments;

            return View("StatisticIndex", statisticViewModel);
        }



    }
}