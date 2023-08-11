using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByStudentId;

public sealed record GetEnrollmentByStudentIdResponse
{
    public List<Enrollment> Enrollments { get; set; }
}
