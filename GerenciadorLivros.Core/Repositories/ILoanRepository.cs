using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Core.DTOs;

namespace GerenciadorLivros.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<LoanDTO>> GetAllAsync();
        Task<Loan> GetByIdAsync(int id);
        Task AddAsync(Loan loan);
        Task SaveChangesAsync();
    }
}
