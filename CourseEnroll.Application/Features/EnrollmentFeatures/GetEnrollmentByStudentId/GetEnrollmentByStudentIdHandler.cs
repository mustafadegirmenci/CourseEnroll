using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByStudentId;

public class GetEnrollmentByStudentIdHandler : IRequestHandler<GetEnrollmentByStudentIdRequest, GetEnrollmentByStudentIdResponse>
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public GetEnrollmentByStudentIdHandler(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }
    
    public async Task<GetEnrollmentByStudentIdResponse> Handle(GetEnrollmentByStudentIdRequest request, CancellationToken cancellationToken)
    {
        var allEnrollments = await _enrollmentRepository.GetAll(cancellationToken);

        var enrollmentsByStudentId = allEnrollments.Where(e => e.StudentId == request.Id).ToList();
        
        return new GetEnrollmentByStudentIdResponse { Enrollments = enrollmentsByStudentId };
    }
}