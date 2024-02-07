using MediatR;

namespace GerenciadorLivros.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<Unit>
    {
        // mesmos campos do inputModel (UpdateLoanInputModel)
        public int Id { get; set; }
        public DateTime LoanReturnDate { get; set; }
    }
}
