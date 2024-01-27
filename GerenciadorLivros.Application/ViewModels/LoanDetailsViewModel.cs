namespace GerenciadorLivros.Application.ViewModels
{
    public class LoanDetailsViewModel
    {
        public LoanDetailsViewModel(int id, DateTime loanDate, DateTime? loanReturnDate, string bookName, string userName)
        {
            Id = id;
            LoanDate = loanDate;
            LoanReturnDate = loanReturnDate;
            BookName = bookName;
            UserName = userName;
        }

        public int Id { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? LoanReturnDate { get; private set; }
        public string BookName { get; private set; }
        public string UserName { get; private set; }
    }
}
