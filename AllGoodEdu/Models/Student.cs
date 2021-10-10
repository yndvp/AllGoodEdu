using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllGoodEdu.Models
{
    public class Student
    {
        [Required()]
        [Range(0, 9999)]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }

        [Required()]
        [MinLength(2)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // References to child property
        public List<Enrollment> Enrollments { get; set; }

    }
}
