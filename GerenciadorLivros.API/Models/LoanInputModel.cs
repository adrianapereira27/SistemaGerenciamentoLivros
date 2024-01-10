namespace GerenciadorLivros.API.Models
{
    public class LoanInputModel    // DTO - dados que serão recebidos
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set;}
        public DateTime LoanDate { get; set;}
    }
}
