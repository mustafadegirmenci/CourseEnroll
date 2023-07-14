using CourseEnroll.WebUI.Models;
using CourseEnroll.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnroll.WebUI.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly StudentProvider _studentProvider;
        private readonly CourseProvider _courseProvider;

        public EnrollmentController(StudentProvider studentProvider, CourseProvider courseProvider)
        {
            _studentProvider = studentProvider;
            _courseProvider = courseProvider;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Course Methods
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _courseProvider.Create(courseViewModel);

                return RedirectToAction("AddCourse");
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseProvider.DeleteById(id);
            return RedirectToAction(nameof(DisplayAllStudents));
        }

        public async Task<IActionResult> EditCourse(int id)
        {
            var course = await _courseProvider.GetById(id);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _courseProvider.Update(courseViewModel);

                return RedirectToAction(nameof(DisplayAllCourses));
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public async Task<IActionResult> DisplayAllCourses()
        {
            var courses = await _courseProvider.GetAll();
            return View(courses);
        }
        #endregion

        #region Student Methods
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _studentProvider.Create(studentViewModel);

                return RedirectToAction("AddStudent");
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentProvider.DeleteById(id);
            return RedirectToAction(nameof(DisplayAllStudents));
        }

        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await _studentProvider.GetById(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _studentProvider.Update(studentViewModel);

                return RedirectToAction(nameof(DisplayAllStudents));
            }
            catch (Exception)
            {
                TempData["msg"] = "Student could not be updated!";
                return View();
            }
        }

        public async Task<IActionResult> EnrollStudentInCourses(int id)
        {
            var student = await _studentProvider.GetById(id);
            
            //TODO: Optimize here
            var allCourses = await _courseProvider.GetAll();
            
            var notEnrolledCourses = allCourses.Where(c => !c.Students.Contains(student)).ToList();
            var enrolledCourses = allCourses.Where(c => c.Students.Contains(student)).ToList();

            ViewBag.notEnrolledCourses = notEnrolledCourses;
            ViewBag.enrolledCourses = enrolledCourses;
            
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EnrollStudentInCourses(int Id, List<int> courseIDs)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var student = await _studentProvider.GetById(Id);
                //TODO: Optimize here
                var allCourses = await _courseProvider.GetAll();
                
                var courses = allCourses.Where(c => courseIDs.Contains(c.Id)).ToList();

                student.EnrolledCourses.Clear();
                student.EnrolledCourses.AddRange(courses);

                return RedirectToAction(nameof(DisplayAllStudents));
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public async Task<IActionResult> DisplayAllStudents()
        {
            var students = await _studentProvider.GetAll();
            return View(students);
        }
        #endregion
    }
}
