namespace GerenciadorLivros.Core.Entities
{
    public class BorrowedBooks : BaseEntity
    {
        public int IdBook { get; private set; }
        public int IdUser { get; private set; }
    }
}
