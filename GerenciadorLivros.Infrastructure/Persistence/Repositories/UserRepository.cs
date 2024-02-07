using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivros.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GerenciadorLivrosDbContext _dbContext;

        public UserRepository(GerenciadorLivrosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(p => p.Id == id);                       
        }
    }
}
