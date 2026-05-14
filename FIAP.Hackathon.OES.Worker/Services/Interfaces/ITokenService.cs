namespace FIAP.Hackathon.OES.Worker.Services.Interfaces;

public interface ITokenService
{
    Task<string> GetTokenAsync();
}
