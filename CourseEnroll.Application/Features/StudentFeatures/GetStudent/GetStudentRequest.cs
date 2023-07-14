using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.GetStudent;

public sealed record GetStudentRequest(
    int Id
) : IRequest<GetStudentResponse>;
