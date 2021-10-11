using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllGoodEdu.Models
{
    public class Instructor
    {
        [Required()]
        public int InstructorID { get; set; }

        [Required()]
        [MinLength(2)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // Reference to child property
        public List<Course> Courses { get; set; }
    }
}
