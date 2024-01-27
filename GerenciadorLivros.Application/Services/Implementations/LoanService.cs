using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Services.Interfaces;
using GerenciadorLivros.Application.ViewModels;
using GerenciadorLivros.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivros.Application.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly GerenciadorLivrosDbContext _dbContext;
        public LoanService(GerenciadorLivrosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewLoanInputModel inputModel)
        {
            var loan = new Loan(inputModel.idUser, inputModel.idBook);
            
            _dbContext.Loans.Add(loan);
            _dbContext.SaveChanges();

            return loan.Id;
        
        }

        public List<LoanViewModel> GetAll(string query)
        {
            var loans = _dbContext.Loans;

            var loansViewModel = loans.Select(l => new LoanViewModel(l.Id, l.LoanDate, l.LoanReturnDate))
                .ToList();

            return loansViewModel;
        }

        public LoanDetailsViewModel GetById(int id)
        {
            var loan = _dbContext.Loans
                .Include(b => b.Book)  // inclui o title da classe Book.cs (retorna o objeto na consulta)
                .Include(u => u.User)  // inclui o name da classe User.cs (retorna o objeto na consulta)
                .SingleOrDefault(l => l.Id == id);

            if (loan == null) return null;

            var loanDetailsViewModel = new LoanDetailsViewModel(
                loan.Id,
                loan.LoanDate, 
                loan.LoanReturnDate,
                loan.Book.Title,
                loan.User.Name
                );
            return loanDetailsViewModel;
        }

        public void Update(UpdateLoanInputModel updateModel)
        {
            var loan = _dbContext.Loans.SingleOrDefault(l => l.Id == updateModel.Id);

            if (loan != null)
            {
                loan.Update();
                _dbContext.SaveChanges();
            }
        }
    }
}
