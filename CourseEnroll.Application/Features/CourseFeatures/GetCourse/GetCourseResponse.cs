using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.CourseFeatures.GetCourse;

public sealed record GetCourseResponse
{
    public Course Course { get; set; }
}
