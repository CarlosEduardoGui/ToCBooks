using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToCBooks.App.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class LivrosMapping : IEntityTypeConfiguration<LivrosModel>
    {
        public void Configure(EntityTypeBuilder<LivrosModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.Property(c => c.Preco)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.ToTable("Livros");
        }
    }
}
