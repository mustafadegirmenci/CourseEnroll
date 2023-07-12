using AutoMapper;
using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;

public sealed class DeleteStudentMapper : Profile
{
    public DeleteStudentMapper()
    {
        CreateMap<Student, DeleteStudentResponse>();
    }
}
