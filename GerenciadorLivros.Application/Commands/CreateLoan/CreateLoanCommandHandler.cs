using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Core.Repositories;
using MediatR;

namespace GerenciadorLivros.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, int>
    {
        private readonly ILoanRepository _loanRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(request.idUser, request.idBook);

            await _loanRepository.AddAsync(loan);

            return loan.Id;
        }
    }
}
