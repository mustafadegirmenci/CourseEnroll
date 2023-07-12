namespace CourseEnroll.Application.Features.CourseFeatures.CreateCourse;

public sealed record CreateCourseResponse
{
    public string CourseID { get; set; }
    public string CourseName { get; set; }
}
