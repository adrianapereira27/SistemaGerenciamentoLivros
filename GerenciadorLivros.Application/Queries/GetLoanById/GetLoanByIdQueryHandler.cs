using GerenciadorLivros.Application.ViewModels;
using GerenciadorLivros.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivros.Application.Queries.GetLoanById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, LoanDetailsViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<LoanDetailsViewModel> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

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
    }
}
