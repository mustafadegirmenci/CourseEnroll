using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.GetAllStudent;

public sealed record GetAllStudentRequest : IRequest<GetAllStudentResponse>;
