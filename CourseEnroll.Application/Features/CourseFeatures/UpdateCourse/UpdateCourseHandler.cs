using AutoMapper;
using CourseEnroll.Application.Repositories;
using MediatR;

namespace CourseEnroll.Application.Features.CourseFeatures.UpdateCourse;

public sealed class UpdateCourseHandler : IRequestHandler<UpdateCourseRequest, UpdateCourseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public UpdateCourseHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateCourseResponse> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        var student = await _courseRepository.Get(request.Id, cancellationToken);
        if (student != null)
        {        
            _mapper.Map(request, student);

            _courseRepository.Update(student);
            await _unitOfWork.Save(cancellationToken);
        }
            
        return _mapper.Map<UpdateCourseResponse>(student);
    }
}