namespace CourseEnroll.WebUI.Services;

public class HttpService
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://localhost:7278")
    };

    public async Task<string> GetAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task PostAsync(string url, object obj)
    {
        using var response = await _client.PostAsJsonAsync(
            url, obj);
    }    
    
    public async Task PutAsync(string url, object obj)
    {
        using var response = await _client.PutAsJsonAsync(
            url, obj);
    }    
    
    public async Task DeleteAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        await _client.SendAsync(request);
    }
}
