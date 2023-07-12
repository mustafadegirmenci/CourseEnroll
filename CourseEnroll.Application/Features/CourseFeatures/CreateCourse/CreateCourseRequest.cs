using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.CreateCourse;

public sealed record CreateCourseRequest(
    string CourseID,
    string CourseName
) : IRequest<CreateCourseResponse>;
