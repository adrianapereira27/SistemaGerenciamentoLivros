using GerenciadorLivros.Core.Entities;

namespace GerenciadorLivros.API.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email; 
            Active = true;

            Reader = new List<Loan>();            
        }

        public string Name { get; private set; }
        public string Email { get; private set; }       
        public bool Active { get; set; }

        public List<Loan> Reader { get; private set; }
        
    }
}
