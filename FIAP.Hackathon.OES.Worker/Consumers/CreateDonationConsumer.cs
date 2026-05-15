using FIAP.Hackathon.OES.Contracts;
using FIAP.Hackathon.OES.Worker.Services.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FIAP.Hackathon.OES.Worker.Consumers;

public class CreateDonationConsumer(ILogger<CreateDonationConsumer> logger, ICampaignClient campaignClient) : IConsumer<CreateDonation>
{
    private readonly ILogger<CreateDonationConsumer> _logger = logger;
    private readonly ICampaignClient _campaignClient = campaignClient;

    public async Task Consume(ConsumeContext<CreateDonation> context)
    {
        var msg = context.Message;

        _logger.LogInformation("Processando doação para a Campanha={CampaignId} Valor={Amount}", msg.CampaignId, msg.Value);

        await _campaignClient.UpdateCampaignDonationValue(msg.CampaignId, msg.Value);

        _logger.LogInformation("Valor arrecadado atualizado na campanha {CampaignId}", msg.CampaignId);
    }
}
