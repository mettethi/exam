using exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace exam.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Helplist> Helplist { get; set; }
        
        //public System.Data.Entity.DbSet<exam.Models.Assignment> Assignments { get; set; }
    }
}