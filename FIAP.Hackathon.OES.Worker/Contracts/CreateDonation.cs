namespace FIAP.Hackathon.OES.Contracts;

public interface CreateDonation
{
    long CampaignId { get; }
    decimal Value { get; }
}
