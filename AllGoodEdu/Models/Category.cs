using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllGoodEdu.Models
{
    public class Category
    {
        [Display(Name = "Category Id")] 
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty strings")]
        [MaxLength(100)]
        public string Name { get; set; }

        // Reference to child property
        public List<Course> Courses { get; set; }
    }
}
