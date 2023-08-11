using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Entities;
using CourseEnroll.Persistence.Context;

namespace CourseEnroll.Persistence.Repositories;

public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(DataContext context) : base(context)
    {
    }
}
