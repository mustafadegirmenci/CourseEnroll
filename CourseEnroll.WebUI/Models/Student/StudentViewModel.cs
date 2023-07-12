using System.ComponentModel.DataAnnotations;
using CourseEnroll.WebUI.Models.Common;
using CourseEnroll.WebUI.Models.Course;

namespace CourseEnroll.WebUI.Models.Student;

public class StudentViewModel : BaseModel
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public DateTime BirthDate { get; set; }

    public List<CourseViewModel> EnrolledCourses { get; set; }

    public StudentViewModel()
    {
        EnrolledCourses = new();
    }
}
