﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}