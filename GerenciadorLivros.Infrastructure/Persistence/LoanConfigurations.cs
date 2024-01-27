using GerenciadorLivros.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorLivros.Infrastructure.Persistence
{
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder         // relacionamento do Loan com o Book
                .HasOne(p => p.Book)
                .WithMany()
                .HasForeignKey(f => f.IdBook)
                .OnDelete(DeleteBehavior.Restrict); // não permite deletar uma entidade que tenha relacionamento com outra

            builder         // relacionamento do Loan com o User
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(f => f.IdUser)
                .OnDelete(DeleteBehavior.Restrict); // não permite deletar uma entidade que tenha relacionamento com outra

        }
    }
}
