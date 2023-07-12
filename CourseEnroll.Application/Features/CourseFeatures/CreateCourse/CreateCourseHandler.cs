using AutoMapper;
using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Entities;
using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.CreateCourse;

public class CreateCourseHandler : IRequestHandler<CreateCourseRequest, CreateCourseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    
    public CreateCourseHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateCourseResponse> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<Course>(request);
        
        _courseRepository.Create(course);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateCourseResponse>(course);
    }
}
