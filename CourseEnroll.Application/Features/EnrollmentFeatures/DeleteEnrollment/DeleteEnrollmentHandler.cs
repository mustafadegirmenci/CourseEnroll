using AutoMapper;
using CourseEnroll.Application.Features.EnrollmentFeatures.DeleteEnrollment;
using CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;
using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.DeleteCourse;

public sealed class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollmentRequest, DeleteEnrollmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IMapper _mapper;

    public DeleteEnrollmentHandler(IUnitOfWork unitOfWork, IEnrollmentRepository enrollmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _enrollmentRepository = enrollmentRepository;
        _mapper = mapper;
    }
    
    public async Task<DeleteEnrollmentResponse> Handle(DeleteEnrollmentRequest request, CancellationToken cancellationToken)
    {
        var enrollment = await _enrollmentRepository.Get(request.Id, cancellationToken);
        if (enrollment != null)
        {
            _enrollmentRepository.Delete(enrollment);
        }
        
        return _mapper.Map<DeleteEnrollmentResponse>(enrollment);
    }
}
