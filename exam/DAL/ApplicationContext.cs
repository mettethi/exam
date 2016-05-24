using exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace exam.DAL
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Students { get; set; }
        public DbSet<User> Teachers { get; set; }
    }
}