using GerenciadorLivros.API;
using GerenciadorLivros.API.Filters;
using GerenciadorLivros.Core.Repositories;
using GerenciadorLivros.Core.Services;
using GerenciadorLivros.Infrastructure.Auth;
using GerenciadorLivros.Infrastructure.Persistence;
using GerenciadorLivros.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));  // validationFilter

builder.Services.AddApplication();     // classe de configuração

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciadorLivros.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
