using BCrypt.Net;
using PJ_API.Domain.Entities;
using PJ_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.User.Create
{
    public class CreateUserCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly CreateUserCommandValidator _validator;
        public CreateUserCommandHandler(AppDbContext context)
        {
            _context = context;
            _validator = new CreateUserCommandValidator();
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                throw new System.Exception(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));

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