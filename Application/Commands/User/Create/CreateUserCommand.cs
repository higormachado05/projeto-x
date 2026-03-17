using System.ComponentModel.DataAnnotations;

namespace Application.Commands.User.Create
{
    public class CreateUserCommand
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}