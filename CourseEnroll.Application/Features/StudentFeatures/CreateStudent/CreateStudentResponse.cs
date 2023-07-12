namespace CourseEnroll.Application.Features.StudentFeatures.CreateStudent;

public sealed record CreateStudentResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
