using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace exam.Models
{
    public class HelplistHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void AddToHelplist(int userId)
        {
            //gå i db og find user
            User user = new User { ID = userId, Name = "MetteLisa" };
            Clients.All.getHelplist(user);
        }
    }
}