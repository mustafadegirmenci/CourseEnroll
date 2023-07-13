using AutoMapper;
using CourseEnroll.Domain.Entities;
using CourseEnroll.Persistence.Context;
using CourseEnroll.WebUI.Models.Course;
using CourseEnroll.WebUI.Models.Student;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnroll.WebUI.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly DataContext _databaseContext;
        private readonly IMapper _mapper;

        public EnrollmentController(DataContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
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
        public IActionResult AddCourse(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _databaseContext.Add(_mapper.Map<Course>(courseViewModel));
                _databaseContext.SaveChanges();

                return RedirectToAction("AddCourse");
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public IActionResult DeleteCourse(int id)
        {
            try
            {
                var course = _databaseContext.Courses.Find(id);
                if (course != null)
                {
                    _databaseContext.Remove(course);
                    _databaseContext.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            return RedirectToAction(nameof(DisplayAllStudents));
        }

        public IActionResult EditCourse(int Id)
        {
            var course = _databaseContext.Courses.Find(Id);
            return View(_mapper.Map<CourseViewModel>(course));
        }

        [HttpPost]
        public IActionResult EditCourse(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _databaseContext.Update(_mapper.Map<Course>(courseViewModel));
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(DisplayAllCourses));
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public IActionResult DisplayAllCourses()
        {
            var courses = _databaseContext.Courses.ToList();
            return View(_mapper.Map<List<Course>, IEnumerable<CourseViewModel>>(courses));
        }
        #endregion

        #region Student Methods
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _databaseContext.Add(_mapper.Map<Student>(studentViewModel));
                _databaseContext.SaveChanges();

                return RedirectToAction("AddStudent");
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var student = _databaseContext.Students.Find(id);
                if (student != null)
                {
                    _databaseContext.Remove(student);
                    _databaseContext.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            return RedirectToAction(nameof(DisplayAllStudents));
        }

        public IActionResult EditStudent(int id)
        {
            var student = _databaseContext.Students.Find(id);
            return View(_mapper.Map<StudentViewModel>(student));
        }

        [HttpPost]
        public IActionResult EditStudent(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _databaseContext.Update(_mapper.Map<Student>(studentViewModel));
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(DisplayAllStudents));
            }
            catch (Exception)
            {
                TempData["msg"] = "Student could not be updated!";
                return View();
            }
        }

        public IActionResult EnrollStudentInCourses(int id)
        {
            var student = _databaseContext.Students.Find(id);
            var notEnrolledCourses = _databaseContext.Courses.Where(c => !c.Students.Contains(student)).ToList();
            var enrolledCourses = _databaseContext.Courses.Where(c => c.Students.Contains(student)).ToList();
            
            //Check here
            ViewBag.notEnrolledCourses = _mapper.Map<List<Course>, IEnumerable<CourseViewModel>>(notEnrolledCourses);
            ViewBag.enrolledCourses = _mapper.Map<List<Course>, IEnumerable<CourseViewModel>>(enrolledCourses);
            
            return View(_mapper.Map<StudentViewModel>(student));
        }

        [HttpPost]
        public IActionResult EnrollStudentInCourses(int Id, List<int> courseIDs)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var student = _databaseContext.Students.FirstOrDefault(s => s.Id == Id);
                _databaseContext.Entry(student).Collection(s => s.EnrolledCourses).Load();
                
                var courses = _databaseContext.Courses.Where(c => courseIDs.Contains(c.Id)).ToList();

                student.EnrolledCourses.Clear();
                student.EnrolledCourses.AddRange(courses);

                _databaseContext.Update(student);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(DisplayAllStudents));
            }
            catch (Exception e)
            {
                TempData["msg"] = e;
                return View();
            }
        }

        public IActionResult DisplayAllStudents()
        {
            var students = _databaseContext.Students.ToList();
            foreach (var student in students)
            {
                _databaseContext.Entry(student).Collection(s => s.EnrolledCourses).Load();
            }
            return View(_mapper.Map<List<Student>, IEnumerable<StudentViewModel>>(students));
        }
        #endregion
    }
}
