using GerenciadorLivros.Core.DTOs;
using MediatR;

namespace GerenciadorLivros.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<List<LoanDTO>>
    {

    }
}
