using MediatR;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.CreateEnrollment;

public sealed record CreateEnrollmentRequest(
    int CourseId,
    int StudentId
) : IRequest<CreateEnrollmentResponse>;