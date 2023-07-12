using System.ComponentModel.DataAnnotations;
using CourseEnroll.WebUI.Models.Common;
using CourseEnroll.WebUI.Models.Student;

namespace CourseEnroll.WebUI.Models.Course;

public class CourseViewModel : BaseModel
{
    [Required] public string CourseCode { get; set; }
    [Required] public string CourseName { get; set; }

    public List<StudentViewModel> Students { get; set; }

    public CourseViewModel()
    {
        Students = new();
    }
}