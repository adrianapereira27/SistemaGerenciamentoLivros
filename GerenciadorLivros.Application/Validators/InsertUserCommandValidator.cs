using FluentValidation;
using GerenciadorLivros.Application.Commands.InsertUser;
using System.Text.RegularExpressions;

namespace GerenciadorLivros.Application.Validators
{
    public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
    {
        public InsertUserCommandValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o Nome");
            RuleFor(p => p.Name)
                .MaximumLength(50)
                .WithMessage("Tamanho máximo do Nome é de 50 caracteres");
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido");
            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menor 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caracter especial");

        }
        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
