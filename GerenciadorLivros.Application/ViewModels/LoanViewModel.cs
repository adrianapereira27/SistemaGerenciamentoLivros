namespace GerenciadorLivros.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, DateTime loanDate, DateTime? loanReturnDate)
        {
            Id = id;
            LoanDate = loanDate;
            LoanReturnDate = loanReturnDate;
        }

        public int Id { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? LoanReturnDate { get; private set; }
    }
}
