using GerenciadorLivros.API.Entities;

namespace GerenciadorLivros.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
    }
}
