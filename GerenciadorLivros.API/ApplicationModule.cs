using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciadorLivros.Application.Commands.CreateLoan;
using GerenciadorLivros.Application.Commands.DeleteBook;
using GerenciadorLivros.Application.Commands.InsertBook;
using GerenciadorLivros.Application.Commands.InsertUser;
using GerenciadorLivros.Application.Commands.LoginUser;
using GerenciadorLivros.Application.Commands.UpdateLoan;
using GerenciadorLivros.Application.Queries.GetAllBooks;
using GerenciadorLivros.Application.Queries.GetAllLoans;
using GerenciadorLivros.Application.Queries.GetBookById;
using GerenciadorLivros.Application.Queries.GetLoanById;
using GerenciadorLivros.Application.Queries.GetUserById;
using GerenciadorLivros.Application.ViewModels;
using GerenciadorLivros.Core.DTOs;
using MediatR;
using System.Reflection;

namespace GerenciadorLivros.API
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediator()
                .AddValidator();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddScoped<IRequestHandler<InsertBookCommand, int>, InsertBookCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteBookCommand, Unit>, DeleteBookCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllBooksQuery, List<BookViewModel>>, GetAllBooksQueryHandler>();
            services.AddScoped<IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>, GetBookByIdQueryHandler>();
            services.AddScoped<IRequestHandler<InsertUserCommand, int>, InsertUserCommandHandler>();
            services.AddScoped<IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>, GetUserByIdQueryHandler>();
            services.AddScoped<IRequestHandler<CreateLoanCommand, int>, CreateLoanCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateLoanCommand, Unit>, UpdateLoanCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllLoansQuery, List<LoanDTO>>, GetAllLoansQueryHandler>();
            services.AddScoped<IRequestHandler<GetLoanByIdQuery, LoanDetailsViewModel>, GetLoanByIdQueryHandler>();
            services.AddScoped<IRequestHandler<LoginUserCommand, LoginUserViewModel>, LoginUserCommandHandler>();
            return services;
        }
        private static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);
            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
