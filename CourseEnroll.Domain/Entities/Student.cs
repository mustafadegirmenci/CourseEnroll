using System.ComponentModel.DataAnnotations;
using CourseEnroll.Domain.Common;

namespace CourseEnroll.Domain.Entities;

public class Student : BaseEntity
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] [DataType(DataType.Date)] public DateTime BirthDate { get; set; }

    public List<Course> EnrolledCourses { get; set; }

    public Student()
    {
        EnrolledCourses = new();
    }
}
