using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.ViewModels;

namespace GerenciadorLivros.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserDetailsViewModel GetById(int id);
        int Create(NewUserInputModel inputModel);
    }
}
