using CourseEnroll.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseEnroll.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
}
