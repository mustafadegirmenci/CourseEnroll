using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.DeleteCourse;

public sealed record DeleteCourseRequest(int Id) : IRequest<DeleteCourseResponse>;
