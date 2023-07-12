namespace CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;

public sealed record UpdateStudentResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
