namespace GerenciadorLivros.API.Models
{
    public class LoanViewModel      // DTO - dados que serão enviados
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
