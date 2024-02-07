using MediatR;

namespace GerenciadorLivros.Application.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<int>
    {
        // mesmos campos do inputModel (NewLoanInputModel)
        public DateTime LoanDate { get; set; }
        public DateTime? LoanReturnDate { get; set; }
        public int idUser { get; set; }
        public int idBook { get; set; }
    }
}
