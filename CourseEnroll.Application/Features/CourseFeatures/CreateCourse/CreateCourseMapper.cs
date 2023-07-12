using AutoMapper;
using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.CourseFeatures.CreateCourse;

public sealed class CreateCourseMapper : Profile
{
    public CreateCourseMapper()
    {
        CreateMap<CreateCourseRequest, Course>();
        CreateMap<Course, CreateCourseResponse>();
    }
}
