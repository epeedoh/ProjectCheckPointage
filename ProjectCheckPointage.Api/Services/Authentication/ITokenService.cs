using ProjectCheckPointage.Api.Data;

namespace ProjectCheckPointage.Api.Services.Authentication
{
    public interface ITokenService
    {
        string GenerateToken(Utilisateur user);
    }
}
