using AutoMapper;

namespace CourseEnroll.WebUI.Models.Student;

public sealed class StudentMapper : Profile
{
    public StudentMapper()
    {
        CreateMap<Domain.Entities.Student, StudentViewModel>();
        CreateMap<StudentViewModel, Domain.Entities.Student>();
    }
}
