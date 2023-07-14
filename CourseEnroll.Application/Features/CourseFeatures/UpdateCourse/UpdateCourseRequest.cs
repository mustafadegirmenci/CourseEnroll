using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.UpdateCourse;

public sealed record UpdateCourseRequest(
    int Id,
    string CourseCode,
    string CourseName
) : IRequest<UpdateCourseResponse>;
