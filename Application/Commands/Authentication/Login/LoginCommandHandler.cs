using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PJ_API.Application.Responses;
using PJ_API.Domain.Entities;
using PJ_API.Infrastructure.Persistence;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PJ_API.Application.Commands.Authentication.Login
{
    public class LoginCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly string _jwtSecret;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;

        public LoginCommandHandler(AppDbContext context, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
            _jwtSecret = configuration["Jwt:Secret"] ?? string.Empty;
            _jwtIssuer = configuration["Jwt:Issuer"] ?? string.Empty;
            _jwtAudience = configuration["Jwt:Audience"] ?? string.Empty;
        }

        public async Task<LoginResponse?> HandleAsync(LoginCommand command)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == command.Email && u.IsActive);

            if (user is null)
                return null;


            var valid = BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash);
            if (!valid)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _jwtIssuer,
                Audience = _jwtAudience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return new LoginResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Token = jwt
            };
        }
    }
}
