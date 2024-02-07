using Dapper;
using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Core.DTOs;
using GerenciadorLivros.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GerenciadorLivros.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly GerenciadorLivrosDbContext _dbContext;
        private readonly string _connectionString;

        public LoanRepository(GerenciadorLivrosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("LibraryCs"); // usado no Dapper
        }

        public async Task AddAsync(Loan loan)
        {            
            await _dbContext.Loans.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LoanDTO>> GetAllAsync()
        {
            // Dapper
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, LoanDate, LoanReturnDate FROM Loans";

                var loans = await sqlConnection.QueryAsync<LoanDTO>(script);

                return loans.ToList();
            }

            // EntityFrameworkCore
            /*var loans = _dbContext.Loans;

            var loansViewModel = loans.Select(l => new LoanViewModel(l.Id, l.LoanDate, l.LoanReturnDate))
                .ToList();

            return loansViewModel;*/
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _dbContext.Loans
                .Include(b => b.Book)  // inclui o title da classe Book.cs (retorna o objeto na consulta)
                .Include(u => u.User)  // inclui o name da classe User.cs (retorna o objeto na consulta)
                .SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
