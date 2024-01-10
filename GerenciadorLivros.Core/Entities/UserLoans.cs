namespace GerenciadorLivros.Core.Entities
{
    public class UserLoans : BaseEntity
    {
        public UserLoans(int idUser, int idLoan)
        {
            IdUser = idUser;
            IdLoan = idLoan;
        }

        public int IdUser { get; private set; }
        public int IdLoan { get; private set; }
    }
}
