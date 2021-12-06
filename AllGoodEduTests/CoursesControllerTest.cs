using AllGoodEdu.Controllers;
using AllGoodEdu.Data;
using AllGoodEdu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoodEduTests
{
    [TestClass]
    class CoursesControllerTest
    {
        private ApplicationDbContext _context;
        CoursesController controller;
        List<Course> courses = new List<Course>();

        // this runs automatically before each test
        [TestInitialize]
        public void TestInitialize()
        {
            // create in-memory db
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // populate db with mock data
            var category = new Category
            {
                CategoryId = 100,
                Name = "Fake Category"
            };
            _context.Categories.Add(category);

            var instructor = new Instructor
            {
                InstructorID = 200,
                Name = "Fake Instructor"
            };
            _context.Instructors.Add(instructor);


            courses.Add(new Course
            {
                CourseID = 342,
                Name = "Java",
                Price = 90,
                InstructorId = 200,
                CategoryId = 100,
                Description = "course 1",
            });
            courses.Add(new Course
            {
                CourseID = 632,
                Name = "JavaScript",
                Price = 80,
                InstructorId = 200,
                CategoryId = 100,
                Description = "course 2",
            });
            courses.Add(new Course
            {
                CourseID = 459,
                Name = "React",
                Price = 700,
                InstructorId = 200,
                CategoryId = 100,
                Description = "course 3",
            });

            foreach (var course in courses)
            {
                _context.Courses.Add(course);
            }
            _context.SaveChanges();

            // instantiate controller w/db dependency
            controller = new CoursesController(_context);
        }
    }
}
