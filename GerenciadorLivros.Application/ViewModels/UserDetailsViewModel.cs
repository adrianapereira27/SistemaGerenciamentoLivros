namespace GerenciadorLivros.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string name, string email)
        {
            Name = name;
            Email = email;            
        }

        public string Name { get; private set; }
        public string Email { get; private set; }        
    }
}
