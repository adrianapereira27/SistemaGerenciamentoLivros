using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Services.Interfaces;
using GerenciadorLivros.Application.ViewModels;
using GerenciadorLivros.Infrastructure.Persistence;

namespace GerenciadorLivros.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly GerenciadorLivrosDbContext _dbContext;

        public UserService(GerenciadorLivrosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // comentado, porque será usado no padrão CQRS (MediatR)

        /*public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.Name, inputModel.Email);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);

            if (user == null) return null;
            
            return new UserDetailsViewModel(user.Name, user.Email);
        }*/
    }
}
