using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;

public sealed record UpdateStudentRequest(
    int Id,
    string FirstName,
    string LastName,
    DateTime BirthDate
) : IRequest<UpdateStudentResponse>;

