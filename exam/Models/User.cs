using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exam.Models
{
    public enum UserType { Teacher, Student }

    public abstract class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public abstract void AddUser();
        public abstract void EditUser();
        public abstract void DeleteUser();

    }

}