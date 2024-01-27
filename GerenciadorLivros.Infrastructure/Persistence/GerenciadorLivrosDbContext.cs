using GerenciadorLivros.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorLivros.Infrastructure.Persistence
{
    public class GerenciadorLivrosDbContext : DbContext
    {
        public GerenciadorLivrosDbContext(DbContextOptions<GerenciadorLivrosDbContext> options) : base(options)
        {            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                                    
        }

    }
}
