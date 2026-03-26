using Microsoft.EntityFrameworkCore;
using PJ_API.Infrastructure.Persistence;

namespace PJ_API.Application.Commands.Authentication.Login
{
    public class LoginCommandHandler
    {
        private readonly AppDbContext _context;

        public LoginCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string?> HandleAsync(LoginCommand command)
        {
            var normalizedEmail = command.Email.Trim().ToLower();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == normalizedEmail);

            if (user is null)
                throw new KeyNotFoundException("Usuário não encontrado");

            var valid = BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash);
            if (!valid)
                return null;

            return "Usuário logado com sucesso";
        }
    }
}
