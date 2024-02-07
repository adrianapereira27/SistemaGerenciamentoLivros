namespace GerenciadorLivros.Core.DTOs
{
    public class LoanDTO
    {        
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? LoanReturnDate { get; set; }
    }
}
