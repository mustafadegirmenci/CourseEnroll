using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.GetAllCourse;

public class GetAllCourseHandler : IRequestHandler<GetAllCourseRequest, GetAllCourseResponse>
{
    private readonly ICourseRepository _courseRepository;

    public GetAllCourseHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<GetAllCourseResponse> Handle(GetAllCourseRequest request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetAll(cancellationToken);
        return new GetAllCourseResponse { Courses = courses };
    }
}
