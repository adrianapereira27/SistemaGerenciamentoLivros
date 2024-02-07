using MediatR;

namespace GerenciadorLivros.Application.Commands.DeleteBook
{
    // usado no padrão CQRS
    public class DeleteBookCommand : IRequest<Unit>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
