using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectCheckPointage.Api.Configuration;
using ProjectCheckPointage.Api.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectCheckPointage.Api.Services.Authentication
{
    public class TokenService : ITokenService
    {

        private readonly JwtSettings _settings;

        public TokenService(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        public string GenerateToken(Utilisateur user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(_settings.ExpiresInMinutes);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim("userId", user.UtilisateurID.ToString()),
           new Claim(ClaimTypes.Role, user.RoleType?.Libelle ?? "User"), // Assurez-vous que RoleTypeID est un objet avec une propriété Name
            // ajoutez d'autres claims si besoin (rôles, etc.)
        };

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }

}
