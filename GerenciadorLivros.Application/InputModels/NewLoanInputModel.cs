namespace GerenciadorLivros.Application.InputModels
{
    public class NewLoanInputModel
    {
        public DateTime LoanDate { get; set; }
        public DateTime? LoanReturnDate { get; set; }
        public int idUser { get; set; }
        public int idBook { get; set; }
    }
}
