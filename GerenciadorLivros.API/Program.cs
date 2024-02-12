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

//builder.Services.AddSingleton<GerenciadorLivrosDbContext>();  // uma instância para toda a aplicação enquanto estiver no ar (Singleton)
var connectionString = builder.Configuration.GetConnectionString("LibraryCs"); // LibraryCs está declarado no appsettings.json
builder.Services.AddDbContext<GerenciadorLivrosDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddScoped<IBookService, BookService>();   // usado no padrão de arquitetura limpa (substituído pelo padrão repository)
//builder.Services.AddScoped<IUserService, UserService>();   // usado no padrão de arquitetura limpa (substituído pelo padrão repository)
//builder.Services.AddScoped<ILoanService, LoanService>();   // usado no padrão de arquitetura limpa (substituído pelo padrão repository)

builder.Services.AddScoped<IBookRepository, BookRepository>();   // padrão repository
builder.Services.AddScoped<ILoanRepository, LoanRepository>();   // padrão repository
builder.Services.AddScoped<IUserRepository, UserRepository>();   // padrão repository

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));  // validationFilter

builder.Services.AddApplication();     // classe de configuração

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
