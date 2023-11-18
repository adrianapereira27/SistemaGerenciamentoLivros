namespace GerenciadorLivros.API.Models
{
    public class BookViewModel    // DTO - dados que serão enviados
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublicacion { get; set; }
    }
}