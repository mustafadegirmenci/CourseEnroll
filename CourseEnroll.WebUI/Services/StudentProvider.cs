using CourseEnroll.WebUI.Models;
using Newtonsoft.Json;

namespace CourseEnroll.WebUI.Services;

public class StudentProvider
{
    private readonly HttpService _httpService;
    private const string StudentUri = "student";

    public StudentProvider(HttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<StudentViewModel>?> GetAll()
    {
        var jsonResponse = await _httpService.GetAsync(StudentUri);
        var students = JsonConvert.DeserializeObject<List<StudentViewModel>>(jsonResponse);

        return students;
    }
    
    public async Task<StudentViewModel?> GetById(int id)
    {
        var jsonResponse = await _httpService.GetAsync($"{StudentUri}/{id}");
        var student = JsonConvert.DeserializeObject<StudentViewModel>(jsonResponse);

        return student;
    }
    
    public async Task DeleteById(int id)
    {
        await _httpService.DeleteAsync($"{StudentUri}/{id}");
    }
    
    public async Task Create(StudentViewModel studentViewModel)
    {
        await _httpService.PostAsync(StudentUri, studentViewModel);
    }    
    
    public async Task Update(StudentViewModel studentViewModel)
    {
        await _httpService.PutAsync(StudentUri, studentViewModel);
    }    
}
