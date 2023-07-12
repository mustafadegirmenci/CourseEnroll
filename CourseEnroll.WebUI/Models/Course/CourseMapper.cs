using AutoMapper;

namespace CourseEnroll.WebUI.Models.Course;

public sealed class CourseMapper : Profile
{
    public CourseMapper()
    {
        CreateMap<Domain.Entities.Course, CourseViewModel>();
        CreateMap<CourseViewModel, Domain.Entities.Course>();
    }
}