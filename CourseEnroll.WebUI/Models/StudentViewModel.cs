using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CourseEnroll.WebUI.Models;

public class StudentViewModel : BaseModel
{
    [Required] 
    [JsonProperty("firstName")] 
    public string FirstName { get; set; }
    
    [Required] 
    [JsonProperty("lastName")] 
    public string LastName { get; set; }
    
    [Required] 
    [JsonProperty("birthDate")] 
    public DateTime BirthDate { get; set; }

    [JsonProperty("enrolledCourses")] 
    public List<CourseViewModel> EnrolledCourses { get; set; }

    public StudentViewModel()
    {
        EnrolledCourses = new();
    }
}
