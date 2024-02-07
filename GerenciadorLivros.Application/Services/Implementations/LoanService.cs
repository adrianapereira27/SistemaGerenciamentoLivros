using GerenciadorLivros.Application.Services.Interfaces;
using GerenciadorLivros.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GerenciadorLivros.Application.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly GerenciadorLivrosDbContext _dbContext;
        private readonly string _connectionString;
        public LoanService(GerenciadorLivrosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("LibraryCs");  // usado no Dapper
        }

        // comentado, porque será usado no padrão CQRS (MediatR)

        /*public int Create(NewLoanInputModel inputModel)
        {
            var loan = new Loan(inputModel.idUser, inputModel.idBook);
            
            _dbContext.Loans.Add(loan);
            _dbContext.SaveChanges();

            return loan.Id;
        
        }

        public List<LoanViewModel> GetAll(string query)
        {
            // Dapper
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, LoanDate, LoanReturnDate FROM Loans";

                return sqlConnection.Query<LoanViewModel>(script).ToList();
            }

            // EntityFrameworkCore
            //var loans = _dbContext.Loans;

            //var loansViewModel = loans.Select(l => new LoanViewModel(l.Id, l.LoanDate, l.LoanReturnDate))
            //    .ToList();

            //return loansViewModel;
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
        }*/
    }
}
