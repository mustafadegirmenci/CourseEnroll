using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByCourseId;

public class GetEnrollmentByCourseIdHandler : IRequestHandler<GetEnrollmentByCourseIdRequest, GetEnrollmentByCourseIdResponse>
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public GetEnrollmentByCourseIdHandler(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }
    
    public async Task<GetEnrollmentByCourseIdResponse> Handle(GetEnrollmentByCourseIdRequest request, CancellationToken cancellationToken)
    {
        var allEnrollments = await _enrollmentRepository.GetAll(cancellationToken);

        var enrollmentsByCourseId = allEnrollments.Where(e => e.CourseId == request.Id).ToList();
        
        return new GetEnrollmentByCourseIdResponse { Enrollments = enrollmentsByCourseId };
    }
}