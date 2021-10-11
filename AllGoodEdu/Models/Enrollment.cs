﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllGoodEdu.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        // References from parent properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
