﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllGoodEdu.Models
{
    public class Course
    {
        [Required()]
        [Range(0,9999)]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Required()]
        [MinLength(2)]
        public string Name { get; set; }

        [Required()]
        [Range(0, 9999)]
        public int CategoryId { get; set; }

        [Required()]
        [Range(0, 9999)]
        public int InstructorId { get; set; }

        [Required()]
        [MinLength(10)]
        public string description { get; set; }

        [Required()]
        [Range(minimum: 0.01, maximum: 999)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        // References from parent properties
        public Category Category { get; set; }
        public Instructor Instructor { get; set; }

        // Reference to child property
        public List<Enrollment> Enrollments { get; set; }
    }
}
