using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.GetAllStudent;

public class GetAllStudentHandler : IRequestHandler<GetAllStudentRequest, GetAllStudentResponse>
{
    private readonly IStudentRepository _studentRepository;

    public GetAllStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<GetAllStudentResponse> Handle(GetAllStudentRequest request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAll(cancellationToken);
        return new GetAllStudentResponse { Students = students };
    }
}
