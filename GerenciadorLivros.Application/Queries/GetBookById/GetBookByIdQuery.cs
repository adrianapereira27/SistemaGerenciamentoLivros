using GerenciadorLivros.Application.ViewModels;
using MediatR;

namespace GerenciadorLivros.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDetailsViewModel>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
