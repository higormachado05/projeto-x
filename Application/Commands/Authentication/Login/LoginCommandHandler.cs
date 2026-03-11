using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PJ_API.Application.DTOs;
using PJ_API.Domain.Entities;
using PJ_API.Infrastructure.Persistence;

namespace PJ_API.Application.Commands.Authentication.Login
{
    public class LoginCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public LoginCommandHandler(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<LoginResponse?> HandleAsync(LoginCommand command)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == command.Email && u.IsActive);

            if (user is null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, command.Password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            return new LoginResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
