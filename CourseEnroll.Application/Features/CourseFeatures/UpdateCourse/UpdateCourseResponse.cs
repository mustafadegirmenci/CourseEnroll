namespace CourseEnroll.Application.Features.CourseFeatures.UpdateCourse;

public sealed record UpdateCourseResponse
{
    public int Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
}