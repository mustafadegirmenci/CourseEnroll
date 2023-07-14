namespace CourseEnroll.Application.Features.CourseFeatures.DeleteCourse;

public sealed record DeleteCourseResponse
{
    public int Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
}
