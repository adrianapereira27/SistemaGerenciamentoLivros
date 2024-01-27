using GerenciadorLivros.Core.Enums;

namespace GerenciadorLivros.Application.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id, string title, string author, string iSBN, int yearPublicacion, BookStatusEnum status)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublicacion = yearPublicacion;
            Status = status;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublicacion { get; private set; }
        public BookStatusEnum Status { get; private set; }
    }
}
