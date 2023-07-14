using AutoMapper;
using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.CourseFeatures.UpdateCourse;

public sealed class UpdateCourseMapper : Profile
{
    public UpdateCourseMapper()
    {
        CreateMap<UpdateCourseRequest, Course>();
        CreateMap<Course, UpdateCourseResponse>();
    }
}
