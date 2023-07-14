using Newtonsoft.Json;

namespace CourseEnroll.WebUI.Models;

public class BaseModel
{
    [JsonProperty("id")] 
    public int Id { get; set; }
    
    [JsonProperty("dateCreated")] 
    public DateTimeOffset DateCreated { get; set; }
    
    [JsonProperty("dateUpdated")] 
    public DateTimeOffset? DateUpdated { get; set; }
    
    [JsonProperty("dateDeleted")] 
    public DateTimeOffset? DateDeleted { get; set; }
}