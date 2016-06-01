using exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam.ViewModels
{
    public class StudentViewModel
    {
        public virtual User User { get; set; }
        //public Assignment Ass { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}