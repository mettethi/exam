using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace exam.Models
{
    public class Helplist
    {


        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Assignment")]
        public int AssignmentID { get; set; }
        public virtual Assignment Assignment { get; set; }
        
        
        
        /*public bool Helped { get; set; }

        public Helplist()
        {

        }*/

    }
}