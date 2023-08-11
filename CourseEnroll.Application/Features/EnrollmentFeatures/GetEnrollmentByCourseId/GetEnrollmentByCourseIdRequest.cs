using MediatR;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByCourseId;

public sealed record GetEnrollmentByCourseIdRequest(
    int Id
) : IRequest<GetEnrollmentByCourseIdResponse>;

