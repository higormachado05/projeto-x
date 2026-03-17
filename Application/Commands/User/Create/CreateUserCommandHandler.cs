using BCrypt.Net;
using PJ_API.Domain.Entities;
using PJ_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.User.Create
{
    public class CreateUserCommandHandler
    {
        private readonly AppDbContext _context;
        public CreateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new System.Exception("Nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Email é obrigatório.");
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Senha é obrigatória.");

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(request.Email))
                throw new System.Exception("Email inválido.");

            if (await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken))
                throw new System.Exception("Email já cadastrado.");

            var user = new PJ_API.Domain.Entities.User
            {
                Name = request.Name!,
                Email = request.Email!,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password!)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}