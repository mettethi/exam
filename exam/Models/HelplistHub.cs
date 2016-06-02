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

        public void Hello()
        {
            Clients.All.hello();
        }


        public void AddToHelplist(int userId, int assignmentId)
        {
            //gå i db og find user
            // User user = new User { ID = userId, Name = "MetteLisa" };

            User user = db.Users.Find(userId);
            Assignment assignment = db.Assignments.Find(assignmentId);
            HelplistsController controller = new HelplistsController();

            Helplist help = new Helplist();
            help.User = user;
            help.Assignment = assignment;

            db.Helplist.Add(help);
            db.SaveChanges();

            Clients.All.getHelplist(user, assignment);
        }

        public void AddToStatistic(int assignmentId)
        {
            Statistic statistic = new Statistic();
            statistic.AssignmentId = assignmentId;
            statistic.Type = "Done";

            db.Statistics.Add(statistic);
            db.SaveChanges();

            Assignment assignment = db.Assignments.Find(assignmentId);

            int doneCount = 0;

            foreach(var i in db.Statistics)
            {
                if(i.Type.Equals("Done"))
                {
                    doneCount++;
                }
                else
                {
                    doneCount = 100;
                }
            }



            /*int doneCount = db.Statistics.Where(i => i.AssignmentId, i => i.Type == "Done" );

            int doneCount2 = db.Statistics.Where(i => i.AssignmentId, i => Equals(i, "Done")).Count;

            int doneCount3 = db.Statistics.Where(i => i.AssignmentId &&  i.Type == "Done").Count;

            int done = db.Statistics.Where(i => i.AssignmentId);*/

            Clients.All.seeDoneStatistic(doneCount, assignmentId);
        }


    }
}