using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class LimbleApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;
    private string _accessToken;

    public LimbleApiClient(string apiUrl)
    {
        _apiUrl = apiUrl;
        _httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };
        //Authenticate(clientId, clientSecret).Wait(); // Authenticate and obtain initial bearer token
    }
}