using FluentValidation;
using GerenciadorLivros.Application.Commands.InsertBook;

namespace GerenciadorLivros.Application.Validators
{
    public class InsertBookCommandValidator : AbstractValidator<InsertBookCommand>
    {
        public InsertBookCommandValidator() 
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o título");
            RuleFor(p => p.Title)                
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Título é de 255 caracteres");            
            RuleFor(p => p.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o autor");

        }
    }
}
