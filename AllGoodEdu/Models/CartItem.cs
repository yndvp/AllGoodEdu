using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllGoodEdu.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        [Range(0.01, 999999)]
        [Required]
        public double Price { get; set; }

        public int CourseID { get; set; }

        public string UserId { get; set; }

        public Course Course { get; set; } // represents the parent object (1 product to many cartitems)
    }
}
