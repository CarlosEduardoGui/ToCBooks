using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using ToCBooks.Domain.Entidades;

namespace ToCBooks.Infraestrutura.Mapping
{
    public class LivrosCategoriasMapping : IEntityTypeConfiguration<LivrosCategorias>
    {
        public void Configure(EntityTypeBuilder<LivrosCategorias> builder)
        {
            builder
                .ToTable("LivrosCategorias")
                .HasKey(x => x.Id);

            builder
                .HasOne(l => l.Livro)
                .WithMany(c => c.Categorias)
                .HasForeignKey(l => l.IdCategoria);

            builder
                .HasOne(c => c.Categoria)
                .WithMany(l => l.Livro)
                .HasForeignKey(c => c.IdLivro);
        }
    }
}
