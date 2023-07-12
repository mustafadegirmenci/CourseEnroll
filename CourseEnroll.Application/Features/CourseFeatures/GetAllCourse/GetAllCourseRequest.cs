using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.GetAllCourse;

public sealed record GetAllCourseRequest : IRequest<GetAllCourseResponse>;
