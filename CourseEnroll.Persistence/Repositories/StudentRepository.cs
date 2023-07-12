using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Entities;
using CourseEnroll.Persistence.Context;

namespace CourseEnroll.Persistence.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(DataContext context) : base(context)
    {
    }
}
