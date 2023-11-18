namespace GerenciadorLivros.API.Models
{
    public class UserViewModel    // DTO - dados que serão enviados
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
