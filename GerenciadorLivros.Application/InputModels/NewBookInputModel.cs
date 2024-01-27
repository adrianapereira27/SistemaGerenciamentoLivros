namespace GerenciadorLivros.Application.InputModels
{
    public class NewBookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublicacion { get; set; }
    }
}
