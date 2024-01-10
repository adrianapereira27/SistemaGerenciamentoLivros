using GerenciadorLivros.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivros.API.Persistence
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }   // tabela Books
        public DbSet<User> Users { get; set; }   // tabela Users

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(e =>
            {
                e.HasKey(e => e.Id);  

                e.Property(de => de.Title).IsRequired(false); 

                e.Property(de => de.Author)
                    .HasMaxLength(200)              
                    .HasColumnType("varchar(200)"); 
                
                e.Property(de => de.YearPublicacion)
                    .HasColumnName("Year_Publication");   

                e.HasMany(de => de.Speakers)  
                    .WithOne()        
                    .HasForeignKey(s => s.DevEventId);  

            });
            builder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);  
            });
        }

    }
}
