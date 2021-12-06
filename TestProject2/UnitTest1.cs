using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
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

        [TestMethod]
        public void DeleteNullIdLoads404()
        {
            // act
            var result = (ViewResult)controller.Delete(null).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidIdLoads404()
        {
            // act
            var result = (ViewResult)controller.Delete(500).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdLoadsCourse()
        {
            // act
            var result = (ViewResult)controller.Delete(632).Result;

            // assert
            Assert.AreEqual(courses[1], result.Model);
        }

        [TestMethod]
        public void DeleteValidIdLoadsView()
        {
            // act
            var result = (ViewResult)controller.Delete(632).Result;

            // assert
            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}
