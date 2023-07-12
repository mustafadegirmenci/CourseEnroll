using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseEnroll.Domain.Common;

namespace CourseEnroll.Domain.Entities;

public sealed class Course : BaseEntity
{
    [Required] public string CourseCode { get; set; }
    [Required] public string CourseName { get; set; }

    public List<Student> Students { get; set; }

    public Course()
    {
        Students = new();
    }
}
