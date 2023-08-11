using AutoMapper;
using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;

public sealed class UpdateStudentHandler : IRequestHandler<UpdateStudentRequest, UpdateStudentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public UpdateStudentHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateStudentResponse> Handle(UpdateStudentRequest request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetAsNoTracking(request.Id, cancellationToken);

        if (student != null)
        {        
            _mapper.Map(request, student);

            _studentRepository.Update(student);
        }

        return _mapper.Map<UpdateStudentResponse>(student);
    }
}
