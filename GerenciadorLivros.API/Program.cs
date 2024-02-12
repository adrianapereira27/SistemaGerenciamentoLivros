using GerenciadorLivros.API;
using GerenciadorLivros.API.Filters;
using GerenciadorLivros.Application.Commands.InsertBook;
using GerenciadorLivros.Core.Repositories;
using GerenciadorLivros.Infrastructure.Persistence;
using GerenciadorLivros.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<GerenciadorLivrosDbContext>();  // uma inst�ncia para toda a aplica��o enquanto estiver no ar (Singleton)
var connectionString = builder.Configuration.GetConnectionString("LibraryCs"); // LibraryCs est� declarado no appsettings.json
builder.Services.AddDbContext<GerenciadorLivrosDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddScoped<IBookService, BookService>();   // usado no padr�o de arquitetura limpa (substitu�do pelo padr�o repository)
//builder.Services.AddScoped<IUserService, UserService>();   // usado no padr�o de arquitetura limpa (substitu�do pelo padr�o repository)
//builder.Services.AddScoped<ILoanService, LoanService>();   // usado no padr�o de arquitetura limpa (substitu�do pelo padr�o repository)

builder.Services.AddScoped<IBookRepository, BookRepository>();   // padr�o repository
builder.Services.AddScoped<ILoanRepository, LoanRepository>();   // padr�o repository
builder.Services.AddScoped<IUserRepository, UserRepository>();   // padr�o repository

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));  // validationFilter

builder.Services.AddApplication();     // classe de configura��o

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciadorLivros.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
