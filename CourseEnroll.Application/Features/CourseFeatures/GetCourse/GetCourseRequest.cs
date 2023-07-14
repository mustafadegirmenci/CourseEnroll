using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.GetCourse;

public sealed record GetCourseRequest(
    int Id
) : IRequest<GetCourseResponse>;
