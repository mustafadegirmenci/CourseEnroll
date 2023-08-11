using MediatR;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.DeleteEnrollment;

public sealed record DeleteEnrollmentRequest(int Id) : IRequest<DeleteEnrollmentResponse>;
