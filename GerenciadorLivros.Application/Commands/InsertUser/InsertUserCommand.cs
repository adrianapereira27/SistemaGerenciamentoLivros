using MediatR;

namespace GerenciadorLivros.Application.Commands.InsertUser
{
    public class InsertUserCommand : IRequest<int>
    {
        // mesmos campos do NewUserInputModel
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
