using FIAP.Hackathon.OES.Worker.Contracts;
using FIAP.Hackathon.OES.Worker.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace FIAP.Hackathon.OES.Worker.Services;

public class TokenService(HttpClient httpClient, IConfiguration configuration) : ITokenService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;

    public async Task<string> GetTokenAsync()
    {
        var request = new ServiceTokenRequest
        {
            ClientId = _configuration["AuthApi:ClientId"]!,
            ClientSecret = _configuration["AuthApi:ClientSecret"]!
        };

        var endpoint = _configuration["AuthApi:ServiceTokenEndpoint"]!;
        try
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, request);
            response.EnsureSuccessStatusCode();

            var tokenResponse = await response.Content.ReadAsStringAsync();

            if (tokenResponse == null)
                throw new Exception("Token de serviço não retornado pela API de autenticação.");

            return tokenResponse;
        }
        catch (Exception e)
        {
            throw;
        }



    }


}
