using GerenciadorLivros.Core.DTOs;
using GerenciadorLivros.Core.Repositories;
using MediatR;

namespace GerenciadorLivros.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoanDTO>>
    {
        private readonly ILoanRepository _loanRepository;
        public GetAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<List<LoanDTO>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            return await _loanRepository.GetAllAsync();
        }
    }
}
