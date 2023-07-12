using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.CreateStudent;

public sealed record CreateStudentRequest(
    string FirstName,
    string LastName,
    DateTime BirthDate
) : IRequest<CreateStudentResponse>;
