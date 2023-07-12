using AutoMapper;
using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Entities;
using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.CreateStudent;

public sealed class CreateStudentHandler : IRequestHandler<CreateStudentRequest, CreateStudentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public CreateStudentHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateStudentResponse> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request);
        
        _studentRepository.Create(student);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateStudentResponse>(student);
    }
}
