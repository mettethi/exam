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


    }
}