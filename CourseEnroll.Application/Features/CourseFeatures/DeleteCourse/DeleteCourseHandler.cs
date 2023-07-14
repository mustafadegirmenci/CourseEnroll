using AutoMapper;
using CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;
using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.DeleteCourse;

public sealed class DeleteCourseHandler : IRequestHandler<DeleteCourseRequest, DeleteCourseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public DeleteCourseHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    
    public async Task<DeleteCourseResponse> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.Get(request.Id, cancellationToken);
        if (course != null)
        {
            _courseRepository.Delete(course);
            await _unitOfWork.Save(cancellationToken);
        }
        
        return _mapper.Map<DeleteCourseResponse>(course);
    }
}
