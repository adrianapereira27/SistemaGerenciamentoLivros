using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.ViewModels;

namespace GerenciadorLivros.Application.Services.Interfaces
{
    public interface ILoanService
    {
        List<LoanViewModel> GetAll(string query);
        LoanDetailsViewModel GetById(int id);
        int Create(NewLoanInputModel inputModel);
        void Update(UpdateLoanInputModel updateModel);
    }
}
