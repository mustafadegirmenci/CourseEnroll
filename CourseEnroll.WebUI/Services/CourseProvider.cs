using CourseEnroll.WebUI.Models;
using Newtonsoft.Json;

namespace CourseEnroll.WebUI.Services;

public class CourseProvider
{
    private readonly HttpService _httpService;
    private const string CourseUri = "course";

    public CourseProvider(HttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<CourseViewModel>?> GetAll()
    {
        var jsonResponse = await _httpService.GetAsync(CourseUri);
        var courses = JsonConvert.DeserializeObject<List<CourseViewModel>>(jsonResponse);

        return courses;
    }
    
    public async Task<CourseViewModel?> GetById(int id)
    {
        var jsonResponse = await _httpService.GetAsync($"{CourseUri}/{id}");
        var course = JsonConvert.DeserializeObject<CourseViewModel>(jsonResponse);

        return course;
    }
        
    public async Task DeleteById(int id)
    {
        await _httpService.DeleteAsync($"{CourseUri}/{id}");
    }

    public async Task Create(CourseViewModel courseViewModel)
    {
        await _httpService.PostAsync(CourseUri, courseViewModel);
    }    
    
    public async Task Update(CourseViewModel courseViewModel)
    {
        await _httpService.PutAsync(CourseUri, courseViewModel);
    }
}