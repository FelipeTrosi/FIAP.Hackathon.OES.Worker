namespace FIAP.Hackathon.OES.Worker.Services.Interfaces;

public interface ICampaignClient
{
    Task UpdateCampaignDonationValue(long campaignId, decimal value);
}
