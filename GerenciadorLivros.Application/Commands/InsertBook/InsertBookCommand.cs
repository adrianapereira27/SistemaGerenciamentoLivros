using MediatR;

namespace GerenciadorLivros.Application.Commands.InsertBook
{
    // usado no padrão CQRS
    public class InsertBookCommand : IRequest<int>
    {
        // mesmos campos do InputModel (NewBookInputModel)
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublicacion { get; set; }
    }
}
