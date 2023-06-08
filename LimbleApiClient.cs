using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class LimbleApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;
    private string _accessToken;

    public LimbleApiClient(string clientId, string clientSecret, string apiUrl)
    {
        _apiUrl = apiUrl;
        _httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };
        Authenticate(clientId, clientSecret).Wait(); // Authenticate and obtain initial bearer token
    }

    private async Task Authenticate(string clientId, string clientSecret)
    {
        //var content = new FormUrlEncodedContent(new[]
        //{
        //    new KeyValuePair<string, string>("grant_type", "client_credentials"),
        //    new KeyValuePair<string, string>("client_id", clientId),
        //    new KeyValuePair<string, string>("client_secret", clientSecret)
        //});

        //HttpResponseMessage response = await _httpClient.PostAsync("/oauth/token", content);
        //response.EnsureSuccessStatusCode();

        //var authData = await response.Content.ReadAsAsync<AuthResponse>();
        _accessToken = string.Empty; // authData.access_token;
    }

    public async Task<string> GetApiData(string endpoint)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}