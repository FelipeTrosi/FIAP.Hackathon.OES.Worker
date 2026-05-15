using FIAP.Hackathon.OES.Worker.Services.Interfaces;
using System.Net.Http.Json;

namespace FIAP.Hackathon.OES.Worker.Services;

public class CampaignClient(HttpClient httpClient, ITokenService tokenService) : ICampaignClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ITokenService _tokenService = tokenService;

    public async Task UpdateCampaignDonationValue(long campaignId, decimal value)
    {
        var token = await _tokenService.GetTokenAsync();

        _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PutAsJsonAsync(
            $"/Campaign/UpdateCampaignValue",
            new
            {
                Value = value,
                CampaignId = campaignId
            });

        response.EnsureSuccessStatusCode();
    }
}
