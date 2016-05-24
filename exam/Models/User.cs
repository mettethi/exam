using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exam.Models
{
    abstract class User
    {
        [Key]
        protected int UserId { get; set; }
        protected string Name { get; set; }
        protected string Email { get; set; }
        protected string Password { get; set; }

        public abstract void AddUser();
        public abstract void EditUser();
        public abstract void DeleteUser();

    }

}