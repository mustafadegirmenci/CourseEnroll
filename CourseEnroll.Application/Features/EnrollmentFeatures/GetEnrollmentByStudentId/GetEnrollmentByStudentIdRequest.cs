using MediatR;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByStudentId;

public sealed record GetEnrollmentByStudentIdRequest(
    int Id
) : IRequest<GetEnrollmentByStudentIdResponse>;

