using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam.Models
{
    class Teacher : User
    {
        public Teacher(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public override void AddUser()
        {

        }

        public override void DeleteUser()
        {

        }

        public override void EditUser()
        {

        }
    }
}