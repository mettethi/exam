using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam.Models
{
    public class Statistic
    {
        public int StatisticId { get; set; }
        public int AssignmentId { get; set; }
        public string Type { get; set; }
    }
}