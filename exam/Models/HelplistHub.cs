using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using exam.DAL;
using exam.Controllers;

namespace exam.Models
{
    public class HelplistHub : Hub
    {
        private ApplicationContext db = new ApplicationContext();

        public void AddToHelplist(int userId, int assignmentId)
        {
            User user = db.Users.Find(userId);
            Assignment assignment = db.Assignments.Find(assignmentId);
            HelplistsController controller = new HelplistsController();

            DateTime timeNow = DateTime.Now;
            var stringTime = timeNow.ToString();
            var theTime = SplitTimestamp(stringTime);

            Helplist help = new Helplist();
            help.User = user;
            help.Assignment = assignment;
            help.Time = theTime;

            db.Helplist.Add(help);
            db.SaveChanges();

            Clients.All.getHelplist(user, assignment, theTime);
        }

        public string SplitTimestamp(string timeNow)
        {
            string[] firstSplit = timeNow.Split(' ');
            var reduced = firstSplit[1];
            string[] hourMinute = reduced.Split(':');

            var finalTime = hourMinute[0] + ":" + hourMinute[1];
           
            return finalTime;
        }

        public void AddToStatistic(int assignmentId)
        {
            Statistic statistic = new Statistic();
            statistic.AssignmentId = assignmentId;
            statistic.Type = "Done";

            db.Statistics.Add(statistic);
            db.SaveChanges();

            Clients.All.seeDoneStatistic();
        }

    }
}