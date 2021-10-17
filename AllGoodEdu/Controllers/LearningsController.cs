using AllGoodEdu.Data;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();

            return View(categories);
        }
    }
}
