using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.StudentFeatures.GetAllStudent;

public sealed record GetAllStudentResponse
{
    public List<Student> Students { get; set; }
}
