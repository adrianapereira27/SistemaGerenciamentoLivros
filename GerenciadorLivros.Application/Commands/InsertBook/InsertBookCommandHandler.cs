using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Core.Repositories;
using MediatR;

namespace GerenciadorLivros.Application.Commands.InsertBook
{
    public class InsertBookCommandHandler : IRequestHandler<InsertBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public InsertBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Author, request.ISBN, request.YearPublicacion);

            await _bookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
