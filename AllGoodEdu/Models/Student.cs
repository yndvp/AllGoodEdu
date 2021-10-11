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
