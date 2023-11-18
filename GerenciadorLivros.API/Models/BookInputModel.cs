namespace GerenciadorLivros.API.Models
{
    public class BookInputModel    // DTO - dados que serão recebidos
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublicacion { get; set; }
    }
}
