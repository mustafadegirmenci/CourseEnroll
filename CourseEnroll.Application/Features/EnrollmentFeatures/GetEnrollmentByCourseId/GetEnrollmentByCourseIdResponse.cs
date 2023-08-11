using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByCourseId;

public sealed record GetEnrollmentByCourseIdResponse
{
    public List<Enrollment> Enrollments { get; set; }
}
