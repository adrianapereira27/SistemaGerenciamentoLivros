using GerenciadorLivros.Core.Entities;

namespace GerenciadorLivros.API.Entities
{
    public class Loan : BaseEntity
    {
        public Loan()
        {
            LoanDate = DateTime.Now;
            
            Books = new List<BorrowedBooks>();
        }

        public DateTime LoanDate { get; private set; }
        public DateTime? LoanReturnDate { get; private set; }

        public List<BorrowedBooks> Books { get; private set; }

        public void Update()
        {
            LoanReturnDate = DateTime.Today;
        }
    }
}
