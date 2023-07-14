using System.ComponentModel.DataAnnotations;

namespace CourseEnroll.WebUI.Models;

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