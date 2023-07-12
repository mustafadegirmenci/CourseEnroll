using AutoMapper;
using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.StudentFeatures.CreateStudent;

public sealed class CreateStudentMapper : Profile
{
    public CreateStudentMapper()
    {
        CreateMap<CreateStudentRequest, Student>();
        CreateMap<Student, CreateStudentResponse>();
    }
}
