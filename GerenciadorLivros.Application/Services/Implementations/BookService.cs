using GerenciadorLivros.API.Entities;
using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Services.Interfaces;
using GerenciadorLivros.Application.ViewModels;
using GerenciadorLivros.Infrastructure.Persistence;

namespace GerenciadorLivros.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly GerenciadorLivrosDbContext _dbContext;
        public BookService(GerenciadorLivrosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewBookInputModel inputModel)
        {
            var book = new Book(inputModel.Title, inputModel.Author, inputModel.ISBN, inputModel.YearPublicacion);

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(p => p.Id == id);

            if (book != null)
            {
                book.Delete();
                _dbContext.SaveChanges();
            }            
        }

        public List<BookViewModel> GetAll(string query)
        {
            var books = _dbContext.Books;

            var booksViewModel = books.Select(p => new BookViewModel(p.Id, p.Title, p.Author, p.YearPublicacion))
                .ToList();

            return booksViewModel;
        }

        public BookDetailsViewModel GetById(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(p => p.Id == id);

            if (book == null) return null;

            var bookDetailsViewModel = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.YearPublicacion,
                book.Status
                );
            return bookDetailsViewModel;
        }
    }
}
