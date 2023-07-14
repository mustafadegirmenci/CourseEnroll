using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.GetStudent;

public class GetStudentHandler : IRequestHandler<GetStudentRequest, GetStudentResponse>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<GetStudentResponse> Handle(GetStudentRequest request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.Get(request.Id, cancellationToken);
        
        return new GetStudentResponse { Student = student };
    }
}