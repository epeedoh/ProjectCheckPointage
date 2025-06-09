using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectCheckPointage.Api.Data;
using ProjectCheckPointage.Api.DTOs;
using ProjectCheckPointage.Api.Repositories.Interfaces;
using ProjectCheckPointage.Api.Services.Authentication;

namespace ProjectCheckPointage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepo;      // votre couche d’accès aux Utilisateur
        private readonly IPasswordHasher<Utilisateur> _hasher;

        public AuthController(
            ITokenService tokenService,
            IUserRepository userRepo,
            IPasswordHasher<Utilisateur> hasher)
        {
            _tokenService = tokenService;
            _userRepo = userRepo;
            _hasher = hasher;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userRepo.GetByUsernameAsync(dto.Username);
            if (user is null)
                return Unauthorized("Utilisateur non trouvé");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Mot de passe incorrect");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegistration([FromBody] RegisterDto userDto)
        {
            if (await _userRepo.GetByUsernameAsync(userDto.Username) is not null)
                return Conflict("Nom d'utilisateur déja utilisé");
            var user = new Utilisateur()
            {
                DateCreation = DateTime.UtcNow,
                UtilisateurID = Guid.NewGuid(),
                Username = userDto.Username,
                Nom = userDto.Nom,
                Prenoms = userDto.Prenoms,
                Telephone = userDto.Telephone,
                NomComplet = $"{userDto.Nom} {userDto.Prenoms}",
                // Image = userDto.Image,
                PasswordSalt = null, // Assuming you handle salt generation in the hasher
                PasswordHash = _hasher.HashPassword(null, userDto.Password),
                Email = userDto.Email,
                RoleTypeID = userDto.RoleTypeId

            };

            await _userRepo.AddAsync(user);

            return CreatedAtAction(nameof(UserRegistration), new { id = user.UtilisateurID, user }, userDto);

        }
    }

}
