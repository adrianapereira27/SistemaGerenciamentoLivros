using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.ViewModels;

namespace GerenciadorLivros.Application.Services.Interfaces
{
    public interface IUserService
    {
        // comentado, porque será usado no padrão CQRS (MediatR)

        //UserDetailsViewModel GetById(int id);
        //int Create(NewUserInputModel inputModel);
    }
}
