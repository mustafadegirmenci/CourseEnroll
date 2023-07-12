namespace CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;

public sealed record DeleteStudentResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
