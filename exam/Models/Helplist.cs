using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam.Models
{
    public class Helplist
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Assignment Assignment { get; set; }
        public bool Helped { get; set; }
    }
}