using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivros.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly GerenciadorLivrosDbContext _dbContext;

        public BookRepository(GerenciadorLivrosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }
                
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
