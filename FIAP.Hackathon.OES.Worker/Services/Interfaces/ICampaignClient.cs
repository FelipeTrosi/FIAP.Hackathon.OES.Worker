namespace FIAP.Hackathon.OES.Worker.Services.Interfaces;

public interface ICampaignClient
{
    void UpdateCampaignDonationValue(long campaignId, decimal value);
}
