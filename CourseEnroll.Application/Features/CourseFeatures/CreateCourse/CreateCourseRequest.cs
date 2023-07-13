using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.CreateCourse;

public sealed record CreateCourseRequest(
    string CourseCode,
    string CourseName
) : IRequest<CreateCourseResponse>;
