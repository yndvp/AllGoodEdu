using AllGoodEdu.Data;
using AllGoodEdu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllGoodEdu.Controllers
{
    public class LearningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LearningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Learnings
        public IActionResult Index()
        {
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();

            return View(categories);
        }

        // GET: /Learnings/LearnByCategory/5
        public IActionResult LearnByCategory(int id)
        {
            var courses = _context.Courses.Include(c => c.Instructor).Where(c => c.CategoryId == id).OrderBy(c => c.Name).ToList();

            var category = _context.Categories.Find(id);
            ViewBag.Category = category.Name;

            return View(courses);
        }

        // POST: /Learnings/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int CourseID)
        {
            var course = _context.Courses.Find(CourseID);
            var price = course.Price;

            var userId = GetUserId();

            var cartItem = _context.CartItems.SingleOrDefault(c => c.CourseID == CourseID && c.UserId == userId);

            if (cartItem != null)
            {
                RedirectToAction("Cart");
            }
            else
            {
                cartItem = new CartItem
                {
                    CourseID = CourseID,
                    Price = (double)price,
                    UserId = userId
                };

                _context.CartItems.Add(cartItem);
            }
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }

        private string GetUserId()
        {
            if(HttpContext.Session.GetString("UserId") == null)
            {
                var userId = "";
                if(User.Identity.IsAuthenticated)
                {
                    userId = User.Identity.Name;
                }
                else
                {
                    userId = Guid.NewGuid().ToString();
                }

                HttpContext.Session.SetString("UserId", userId);
            }

            return HttpContext.Session.GetString("UserId");
        }

        // GET: /Learnings/Cart
        public IActionResult Cart()
        {
            var userId = GetUserId();

            var cartItems = _context.CartItems
                .Include(c => c.Course)
                .Where(c => c.UserId == userId).ToList();

            return View(cartItems);
        }

        // GET: /Learnings/RemoveFromCart/5
        public IActionResult RemoveFromCart(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }
    }
}
