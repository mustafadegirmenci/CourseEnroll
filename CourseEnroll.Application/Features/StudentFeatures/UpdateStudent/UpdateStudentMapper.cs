using AutoMapper;
using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;

public sealed class UpdateStudentMapper : Profile
{
    public UpdateStudentMapper()
    {
        CreateMap<UpdateStudentRequest, Student>();
        CreateMap<Student, UpdateStudentResponse>();
    }
}
