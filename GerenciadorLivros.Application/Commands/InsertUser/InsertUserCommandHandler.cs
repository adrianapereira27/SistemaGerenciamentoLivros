using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Core.Repositories;
using GerenciadorLivros.Core.Services;
using MediatR;

namespace GerenciadorLivros.Application.Commands.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public InsertUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.Name, request.Email, passwordHash, request.Role);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
