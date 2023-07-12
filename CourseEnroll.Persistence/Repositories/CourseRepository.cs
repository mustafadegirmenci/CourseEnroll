using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Entities;
using CourseEnroll.Persistence.Context;

namespace CourseEnroll.Persistence.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(DataContext context) : base(context)
    {
    }
}
