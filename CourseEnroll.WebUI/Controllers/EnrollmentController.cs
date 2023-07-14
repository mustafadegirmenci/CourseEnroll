using CourseEnroll.WebUI.Models;
using CourseEnroll.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnroll.WebUI.Controllers
{
    public enum ActiveTabIndex
    {
        Dashboard = 0,
        AllCourses = 1,
        AddCourse = 2,
        AllStudents = 3,
        AddStudent = 4,
    }
    
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
        
        public async Task<IActionResult> ShowCourse(int id)
        {
            var course = await _courseProvider.GetById(id);
            return View(course);
        }
        
        public IActionResult AddCourse()
        {
            ViewBag.activeTab = (int)ActiveTabIndex.AddCourse;
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

                return RedirectToAction(nameof(DisplayAllCourses));
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
            return RedirectToAction(nameof(DisplayAllCourses));
        }

        public async Task<IActionResult> EditCourse(int id)
        {
            var course = await _courseProvider.GetById(id);
            ViewBag.activeTab = (int)ActiveTabIndex.AllCourses;
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
            ViewBag.activeTab = (int)ActiveTabIndex.AllCourses;
            var courses = await _courseProvider.GetAll();
            return View(courses);
        }
        #endregion

        #region Student Methods

        public async Task<IActionResult> ShowStudent(int id)
        {
            var student = await _studentProvider.GetById(id);
            return View(student);
        }
        
        public IActionResult AddStudent()
        {
            ViewBag.activeTab = (int)ActiveTabIndex.AddStudent;
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

                return RedirectToAction(nameof(DisplayAllStudents));
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
            ViewBag.activeTab = (int)ActiveTabIndex.AllStudents;
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

            var enrolledCourses = student.EnrolledCourses;
            var enrolledCourseIds = enrolledCourses.Select(c => c.Id);
            
            var notEnrolledCourses = allCourses.Where(c => !enrolledCourseIds.Contains(c.Id)).ToList();

            ViewBag.notEnrolledCourses = notEnrolledCourses;
            ViewBag.enrolledCourses = enrolledCourses;
            ViewBag.activeTab = (int)ActiveTabIndex.AllStudents;
            
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
                await _studentProvider.Update(student);

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
            ViewBag.activeTab = (int)ActiveTabIndex.AllStudents;
            var students = await _studentProvider.GetAll();
            return View(students);
        }
        #endregion
    }
}
