using AutoMapper;
using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;

public sealed class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, DeleteStudentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public DeleteStudentHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<DeleteStudentResponse> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.Get(request.Id, cancellationToken);
        if (student != null)
        {
            _studentRepository.Delete(student);
        }
        
        return _mapper.Map<DeleteStudentResponse>(student);
    }
}
