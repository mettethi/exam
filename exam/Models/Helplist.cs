using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam.Models
{
    public class Helplist
    {
        public int ID { get; set; }
        //public int AssignmentID { get; set; }
        //public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual Assignment Assignment { get; set; }
        public bool Helped { get; set; }
    }
}