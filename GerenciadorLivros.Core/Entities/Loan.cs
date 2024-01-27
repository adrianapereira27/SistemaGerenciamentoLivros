using GerenciadorLivros.Core.Entities;

namespace GerenciadorLivros.API.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idBook, int idUser)
        {
            LoanDate = DateTime.Now;
            IdBook = idBook;
            IdUser = idUser;            
        }

        public DateTime LoanDate { get; private set; }
        public DateTime? LoanReturnDate { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }

        public void Update()
        {
            LoanReturnDate = DateTime.Today;
        }
    }
}
