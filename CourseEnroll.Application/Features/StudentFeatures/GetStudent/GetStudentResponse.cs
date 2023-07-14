using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.StudentFeatures.GetStudent;

public sealed record GetStudentResponse
{
    public Student Student { get; set; }
}
