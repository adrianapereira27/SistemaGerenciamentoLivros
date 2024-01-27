using GerenciadorLivros.Core.Entities;
using GerenciadorLivros.Core.Enums;

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
            Status = BookStatusEnum.Normal;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublicacion { get; private set; }  
        public BookStatusEnum Status { get; private set; }

        public void Delete()
        {
            if (Status == BookStatusEnum.Normal)
            {
                Status = BookStatusEnum.Deleted;
            }
        }

    }        
}
