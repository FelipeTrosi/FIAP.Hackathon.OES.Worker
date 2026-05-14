using FIAP.Hackathon.OES.Worker;
using FIAP.Hackathon.OES.Worker.Consumers;
using FIAP.Hackathon.OES.Worker.Services;
using FIAP.Hackathon.OES.Worker.Services.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);


builder.Services.AddHttpClient<ITokenService, TokenService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AuthApi:BaseUrl"]!);
});

builder.Services.AddHttpClient<ICampaignClient, CampaignClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CampaignApi:BaseUrl"]!);
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateDonationConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"], "/", h =>
        {
            h.Username(builder.Configuration["RabbitMQ:User"]!);
            h.Password(builder.Configuration["RabbitMQ:Pass"]!);
        });

        cfg.ReceiveEndpoint("create-donation", e =>
        {
            e.UseMessageRetry(r => r.Interval(5, TimeSpan.FromSeconds(5)));

            e.ConfigureConsumer<CreateDonationConsumer>(context);
        });
    });
});

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
