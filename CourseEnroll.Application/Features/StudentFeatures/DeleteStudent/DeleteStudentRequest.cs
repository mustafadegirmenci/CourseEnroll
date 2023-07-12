using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;

public sealed record DeleteStudentRequest(int Id) : IRequest<DeleteStudentResponse>;
