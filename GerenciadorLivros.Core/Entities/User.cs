using GerenciadorLivros.Core.Entities;

namespace GerenciadorLivros.API.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email; 
            Active = true;
            Password = password;
            Role = role;

            Reader = new List<Loan>();            
        }

        public string Name { get; private set; }
        public string Email { get; private set; }       
        public bool Active { get; set; }
        public string Password { get; set; }
        public string Role {  get; set; }

        public List<Loan> Reader { get; private set; }
        
    }
}
