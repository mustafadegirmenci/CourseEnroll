using AutoMapper;
using CourseEnroll.Application.Features.CourseFeatures.CreateCourse;
using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Entities;
using MediatR;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.CreateEnrollment;

public class CreateEnrollmentHandler : IRequestHandler<CreateEnrollmentRequest, CreateEnrollmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IMapper _mapper;
    
    public CreateEnrollmentHandler(IUnitOfWork unitOfWork, IEnrollmentRepository courseRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _enrollmentRepository = courseRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateEnrollmentResponse> Handle(CreateEnrollmentRequest request, CancellationToken cancellationToken)
    {
        var enrollment = _mapper.Map<Enrollment>(request);
        
        _enrollmentRepository.Create(enrollment);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateEnrollmentResponse>(enrollment);
    }
}
