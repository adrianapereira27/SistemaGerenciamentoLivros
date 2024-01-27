using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.ViewModels;

namespace GerenciadorLivros.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll(string query);
        BookDetailsViewModel GetById(int id);
        int Create(NewBookInputModel inputModel);        
        void Delete(int id);
    }
}
