using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.GetCourse;

public class GetCourseHandler : IRequestHandler<GetCourseRequest, GetCourseResponse>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<GetCourseResponse> Handle(GetCourseRequest request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.Get(request.Id, cancellationToken);
        
        return new GetCourseResponse { Course = course };
    }
}
