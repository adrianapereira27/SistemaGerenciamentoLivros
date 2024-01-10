using GerenciadorLivros.Core.Entities;

namespace GerenciadorLivros.API.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, int yearPublicacion)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublicacion = yearPublicacion;

            IsOnLoan = false;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublicacion { get; private set; }  
        public bool IsOnLoan { get; private set; }  
                
        
        public void UpdateOnLoan(bool isOnLoan)     
        {
            IsOnLoan = isOnLoan;
        }

    }        
}
