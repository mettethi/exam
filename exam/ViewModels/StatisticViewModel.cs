using exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam.ViewModels
{
    public class StatisticViewModel
    {
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}