namespace CourseEnroll.Application.Features.CourseFeatures.CreateCourse;

public sealed record CreateCourseResponse
{
    public int Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
}
