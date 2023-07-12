using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.CourseFeatures.GetAllCourse;


public sealed record GetAllCourseResponse
{
    public List<Course> Courses { get; set; }
}
