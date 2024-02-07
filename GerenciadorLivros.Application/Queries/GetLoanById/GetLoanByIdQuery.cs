using GerenciadorLivros.Application.ViewModels;
using MediatR;

namespace GerenciadorLivros.Application.Queries.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<LoanDetailsViewModel>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
